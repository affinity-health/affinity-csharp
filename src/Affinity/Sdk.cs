using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Runtime.CompilerServices;
using Affinity.Core;
namespace Affinity;

public partial class RequestOptions {
 public string? PracticeId { get; init; }
 public string? IdempotencyKey { get; init; }
 public string? OrganizationId { get; init; }
 public string? ActorId { get; init; }
 public string? ActorType { get; init; }
}
public sealed class AffinityException : Exception {
 public int Status {get;} public string? Code {get;} public string? RequestId {get;} public bool Retryable {get;} public double? RetryAfter {get;}
 internal AffinityException(int status,string? code,string? requestId,double? retryAfter):base($"Affinity API request failed ({status})") {Status=status;Code=code;RequestId=requestId;RetryAfter=retryAfter;Retryable=new[]{408,429,500,502,503,504}.Contains(status);}
}
public abstract class SDKParameters : Dictionary<string,object?> {
 protected T? Value<T>(string name)=>TryGetValue(name,out var value)?(T?)value:default;
}
internal sealed class SDKOperation {
 public string Path {get;set;}=""; public string Verb {get;set;}=""; public string[] Ids {get;set;}=[]; public string[] Query {get;set;}=[]; public Dictionary<string,string> Headers {get;set;}=new(); public bool Body {get;set;} public string Practice {get;set;}="none"; public bool RootOnly {get;set;} public string Idempotency {get;set;}="none";
}
internal sealed class SDKTransport {
 private readonly string key;private readonly ClientOptions options;private readonly SemaphoreSlim gate=new(1,1);private Dictionary<string,string>? identity;
 internal SDKTransport(string key,ClientOptions options){if(string.IsNullOrWhiteSpace(key))throw new ArgumentException("An API key is required");if(options.Timeout<=TimeSpan.Zero||options.MaxRetries<0||options.MaxRetries>10)throw new ArgumentException("Invalid timeout or retry limit");this.key=key;this.options=options;}
 internal async Task<Dictionary<string,string>> Access(CancellationToken cancellation){await gate.WaitAsync(cancellation).ConfigureAwait(false);try{if(identity==null){var data=await Request<JsonElement>("/v1/auth/access","GET",null,new(),cancellation).ConfigureAwait(false);var subject=data.GetProperty("serviceAccount");identity=new(){{"subjectType",subject.GetProperty("subjectType").GetString()!},{"subjectId",subject.GetProperty("subjectId").GetString()!}};}return identity;}finally{gate.Release();}}
 internal async Task<T> Request<T>(string path,string method,object? body,Dictionary<string,string> headers,CancellationToken cancellation,TimeSpan? requestTimeout=null,int? requestRetries=null){
  var payload=body==null?null:JsonSerializer.Serialize(body);var retries=method=="GET"||headers.ContainsKey("Idempotency-Key")?(requestRetries??options.MaxRetries):0;var duration=requestTimeout??options.Timeout;if(duration<=TimeSpan.Zero||retries<0||retries>10)throw new ArgumentException("Invalid timeout or retry limit");
  for(var attempt=0;;attempt++){
   cancellation.ThrowIfCancellationRequested();using var timeout=CancellationTokenSource.CreateLinkedTokenSource(cancellation);timeout.CancelAfter(duration);
   using var request=new HttpRequestMessage(new HttpMethod(method),options.BaseUrl.TrimEnd('/')+path);request.Headers.TryAddWithoutValidation("Authorization","Bearer "+key);request.Headers.TryAddWithoutValidation("Affinity-Version","2026-09-28");foreach(var h in headers)request.Headers.TryAddWithoutValidation(h.Key,h.Value);if(payload!=null)request.Content=new StringContent(payload,Encoding.UTF8,"application/json");
   double delay=250*Math.Pow(2,attempt);
   try{
    using var response=await options.HttpClient.SendAsync(request,HttpCompletionOption.ResponseContentRead,timeout.Token).ConfigureAwait(false);var raw=await response.Content.ReadAsStringAsync().ConfigureAwait(false);
    if(response.IsSuccessStatusCode)return string.IsNullOrWhiteSpace(raw)?default!:JsonUtils.Deserialize<T>(raw)!;
    JsonElement problem;try{problem=JsonSerializer.Deserialize<JsonElement>(raw);}catch(JsonException){problem=default;}
    string? Field(string name)=>problem.ValueKind==JsonValueKind.Object&&problem.TryGetProperty(name,out var v)?v.GetString():null;
    var retry=response.Headers.RetryAfter;double? seconds=retry?.Delta?.TotalSeconds??(retry?.Date-DateTimeOffset.UtcNow)?.TotalSeconds;if(seconds.HasValue)seconds=Math.Max(0,seconds.Value);
    var error=new AffinityException((int)response.StatusCode,Field("code"),Field("requestId"),seconds);if(!error.Retryable||attempt>=retries)throw error;delay=Math.Max(delay,(seconds??0)*1000);
   }catch(HttpRequestException){if(attempt>=retries)throw;}catch(OperationCanceledException){if(cancellation.IsCancellationRequested||attempt>=retries)throw;}
   await Task.Delay(TimeSpan.FromMilliseconds(Math.Min(30000,delay)),cancellation).ConfigureAwait(false);
  }
 }
}
internal sealed class SDKContext {
 internal readonly SDKTransport Transport;internal readonly string? PracticeId;
 internal SDKContext(SDKTransport transport,string? practiceId=null){Transport=transport;PracticeId=practiceId;}
 internal async Task<T> Call<T>(string operationId,string[] ids,object? parameters,RequestOptions? options,CancellationToken cancellation){
  var op=SDKOperations.All[operationId];options??=new();
  if(op.RootOnly&&PracticeId!=null)throw new ArgumentException("Use the root client for platform-wide operations");
  if(PracticeId!=null&&options.PracticeId!=null&&PracticeId!=options.PracticeId)throw new ArgumentException("Conflicting practice ID");
  var key=options.IdempotencyKey;if(key!=null&&string.IsNullOrWhiteSpace(key))throw new ArgumentException("IdempotencyKey must not be empty");if(op.Idempotency=="required"&&key==null)throw new ArgumentException("A persisted IdempotencyKey is required");if(op.Idempotency=="none"&&key!=null)throw new ArgumentException("This endpoint does not support idempotency keys");if(op.Idempotency=="auto"&&key==null)key=Guid.NewGuid().ToString();
  var practice=options.PracticeId??PracticeId;
  if(op.Practice!="none"){var identity=await Transport.Access(cancellation).ConfigureAwait(false);if(identity["subjectType"]=="practice"){if(practice!=null&&practice!=identity["subjectId"])throw new ArgumentException("Practice context conflicts with the API key");practice=identity["subjectId"];}if(string.IsNullOrWhiteSpace(practice))throw new ArgumentException("A platform key requires PracticeId");}else if(options.PracticeId!=null)throw new ArgumentException("This endpoint does not accept practice context");
  var data=parameters==null?new Dictionary<string,object?>():JsonSerializer.Deserialize<Dictionary<string,object?>>(JsonSerializer.Serialize(parameters))!;
  if(operationId=="updatePatient"&&data.TryGetValue("status",out var state)&&state?.ToString()=="archived")data["status"]="inactive";
  if(data.ContainsKey("practiceId"))throw new ArgumentException("Pass PracticeId in request options");
  var path=op.Path;for(int i=0;i<op.Ids.Length;i++){if(i>=ids.Length||string.IsNullOrWhiteSpace(ids[i]))throw new ArgumentException("A resource ID is required");path=path.Replace("{"+op.Ids[i]+"}",Uri.EscapeDataString(ids[i]));}
  if(op.Practice=="path")path=path.Replace("{practiceId}",Uri.EscapeDataString(practice!));if(op.Practice=="body"||op.Practice=="query")data["practiceId"]=practice;
  if(op.Practice=="order"){var order=await Transport.Request<JsonElement>("/v1/orders/"+Uri.EscapeDataString(ids[Array.IndexOf(op.Ids,"orderId")]),"GET",null,new(),cancellation).ConfigureAwait(false);if(order.GetProperty("practiceId").GetString()!=practice)throw new ArgumentException("Order does not belong to the selected practice");if(operationId=="getOrder")return JsonUtils.Deserialize<T>(order.GetRawText())!;}
  var query=new List<string>();foreach(var name in op.Query){if(data.TryGetValue(name,out var value)&&value!=null){var text=value is JsonElement el?el.ValueKind==JsonValueKind.True?"true":el.ValueKind==JsonValueKind.False?"false":el.ToString():value.ToString();query.Add(Uri.EscapeDataString(name)+"="+Uri.EscapeDataString(text!));data.Remove(name);}}if(query.Count>0)path+="?"+string.Join("&",query);
  var headers=new Dictionary<string,string>();var values=new Dictionary<string,string?>{{"organizationId",options.OrganizationId},{"actorId",options.ActorId},{"actorType",options.ActorType}};foreach(var h in op.Headers)if(values.TryGetValue(h.Key,out var v)&&v!=null)headers[h.Value]=v;if(key!=null)headers["Idempotency-Key"]=key;
  return await Transport.Request<T>(path,op.Verb,op.Body?data:null,headers,cancellation,options.Timeout,options.MaxRetries).ConfigureAwait(false);
 }
 internal async IAsyncEnumerable<T> Iterate<T>(string operationId,string[] ids,object parameters,RequestOptions? options,[EnumeratorCancellation]CancellationToken cancellation){
  var query=JsonSerializer.Deserialize<Dictionary<string,object?>>(JsonSerializer.Serialize(parameters))!;if(query.ContainsKey("endingBefore"))throw new ArgumentException("Iterate supports forward pagination");
  while(true){var page=await Call<JsonElement>(operationId,ids,query,options,cancellation).ConfigureAwait(false);var records=page.GetProperty("data");foreach(var item in records.EnumerateArray()){cancellation.ThrowIfCancellationRequested();yield return JsonUtils.Deserialize<T>(item.GetRawText())!;}if(!page.GetProperty("hasMore").GetBoolean())yield break;var cursor=records.GetArrayLength()>0?records[records.GetArrayLength()-1].GetProperty("id").GetString():null;if(cursor==null||(query.TryGetValue("startingAfter",out var before)&&before?.ToString()==cursor))throw new InvalidOperationException("Pagination did not advance");query["startingAfter"]=cursor;}
 }
}

public sealed class LocationListParams:SDKParameters{public int? Limit {get=>Value<int?>("limit")!;set=>this["limit"]=value;}
public string? StartingAfter {get=>Value<string?>("startingAfter")!;set=>this["startingAfter"]=value;}
public string? EndingBefore {get=>Value<string?>("endingBefore")!;set=>this["endingBefore"]=value;}
public string? Status {get=>Value<string?>("status")!;set=>this["status"]=value;}}

public sealed class LocationCreateParams:SDKParameters{public string? City {get=>Value<string?>("city")!;set=>this["city"]=value;}
public string? Country {get=>Value<string?>("country")!;set=>this["country"]=value;}
public string? Line1 {get=>Value<string?>("line1")!;set=>this["line1"]=value;}
public string? Line2 {get=>Value<string?>("line2")!;set=>this["line2"]=value;}
public string Name {get=>Value<string>("name")!;set=>this["name"]=value;}
public string? Phone {get=>Value<string?>("phone")!;set=>this["phone"]=value;}
public string? PostalCode {get=>Value<string?>("postalCode")!;set=>this["postalCode"]=value;}
public string? State {get=>Value<string?>("state")!;set=>this["state"]=value;}
public string? Timezone {get=>Value<string?>("timezone")!;set=>this["timezone"]=value;}}

public sealed class LocationUpdateParams:SDKParameters{public string? City {get=>Value<string?>("city")!;set=>this["city"]=value;}
public string? Country {get=>Value<string?>("country")!;set=>this["country"]=value;}
public string? Line1 {get=>Value<string?>("line1")!;set=>this["line1"]=value;}
public string? Line2 {get=>Value<string?>("line2")!;set=>this["line2"]=value;}
public string? Name {get=>Value<string?>("name")!;set=>this["name"]=value;}
public string? Phone {get=>Value<string?>("phone")!;set=>this["phone"]=value;}
public string? PostalCode {get=>Value<string?>("postalCode")!;set=>this["postalCode"]=value;}
public string? State {get=>Value<string?>("state")!;set=>this["state"]=value;}
public string? Timezone {get=>Value<string?>("timezone")!;set=>this["timezone"]=value;}}

public sealed class ApiKeyCreateParams:SDKParameters{public List<object>? AllowedIps {get=>Value<List<object>?>("allowedIps")!;set=>this["allowedIps"]=value;}
public string? ExpiresAt {get=>Value<string?>("expiresAt")!;set=>this["expiresAt"]=value;}
public string Name {get=>Value<string>("name")!;set=>this["name"]=value;}
public List<string>? Scopes {get=>Value<List<string>?>("scopes")!;set=>this["scopes"]=value;}}

public sealed class AccountGetParams:SDKParameters{public string? OrgId {get=>Value<string?>("orgId")!;set=>this["orgId"]=value;}}

public sealed class CatalogItemListParams:SDKParameters{public string? View {get=>Value<string?>("view")!;set=>this["view"]=value;}
public string? RelatedToCatalogItemId {get=>Value<string?>("relatedToCatalogItemId")!;set=>this["relatedToCatalogItemId"]=value;}
public string? CatalogKind {get=>Value<string?>("catalogKind")!;set=>this["catalogKind"]=value;}
public string? Sort {get=>Value<string?>("sort")!;set=>this["sort"]=value;}
public string? CatalogItemId {get=>Value<string?>("catalogItemId")!;set=>this["catalogItemId"]=value;}
public string? Availability {get=>Value<string?>("availability")!;set=>this["availability"]=value;}
public object? PharmacyIds {get=>Value<object?>("pharmacyIds")!;set=>this["pharmacyIds"]=value;}
public object? DosageForms {get=>Value<object?>("dosageForms")!;set=>this["dosageForms"]=value;}
public string? EndingBefore {get=>Value<string?>("endingBefore")!;set=>this["endingBefore"]=value;}
public bool? HideControlledSubstances {get=>Value<bool?>("hideControlledSubstances")!;set=>this["hideControlledSubstances"]=value;}
public bool? HideUnpriced {get=>Value<bool?>("hideUnpriced")!;set=>this["hideUnpriced"]=value;}
public int? Limit {get=>Value<int?>("limit")!;set=>this["limit"]=value;}
public string? OrgId {get=>Value<string?>("orgId")!;set=>this["orgId"]=value;}
public string? Query {get=>Value<string?>("query")!;set=>this["query"]=value;}
public string? Requirement {get=>Value<string?>("requirement")!;set=>this["requirement"]=value;}
public object? Routes {get=>Value<object?>("routes")!;set=>this["routes"]=value;}
public string? StartingAfter {get=>Value<string?>("startingAfter")!;set=>this["startingAfter"]=value;}}

public sealed class PharmacyListParams:SDKParameters{public string? EndingBefore {get=>Value<string?>("endingBefore")!;set=>this["endingBefore"]=value;}
public int? Limit {get=>Value<int?>("limit")!;set=>this["limit"]=value;}
public string? OrgId {get=>Value<string?>("orgId")!;set=>this["orgId"]=value;}
public string? PharmacyId {get=>Value<string?>("pharmacyId")!;set=>this["pharmacyId"]=value;}
public string? Query {get=>Value<string?>("query")!;set=>this["query"]=value;}
public string? ShipsToState {get=>Value<string?>("shipsToState")!;set=>this["shipsToState"]=value;}
public string? StartingAfter {get=>Value<string?>("startingAfter")!;set=>this["startingAfter"]=value;}}

public sealed class ShippingOptionListParams:SDKParameters{public string DestinationState {get=>Value<string>("destinationState")!;set=>this["destinationState"]=value;}
public string? DestinationType {get=>Value<string?>("destinationType")!;set=>this["destinationType"]=value;}}

public sealed class OrderListParams:SDKParameters{public string? Query {get=>Value<string?>("query")!;set=>this["query"]=value;}
public string? ExternalOrderId {get=>Value<string?>("externalOrderId")!;set=>this["externalOrderId"]=value;}
public string? CreatedAfter {get=>Value<string?>("createdAfter")!;set=>this["createdAfter"]=value;}
public string? CreatedBefore {get=>Value<string?>("createdBefore")!;set=>this["createdBefore"]=value;}
public string? EndingBefore {get=>Value<string?>("endingBefore")!;set=>this["endingBefore"]=value;}
public int? Limit {get=>Value<int?>("limit")!;set=>this["limit"]=value;}
public string? OrderId {get=>Value<string?>("orderId")!;set=>this["orderId"]=value;}
public string? PatientId {get=>Value<string?>("patientId")!;set=>this["patientId"]=value;}
public string? PatientExternalId {get=>Value<string?>("patientExternalId")!;set=>this["patientExternalId"]=value;}
public string? Sort {get=>Value<string?>("sort")!;set=>this["sort"]=value;}
public string? StartingAfter {get=>Value<string?>("startingAfter")!;set=>this["startingAfter"]=value;}
public string? Status {get=>Value<string?>("status")!;set=>this["status"]=value;}}

public sealed class OrderCreateParams:SDKParameters{public string? UserId {get=>Value<string?>("userId")!;set=>this["userId"]=value;}
public PrescriberSelector? Prescriber {get=>Value<PrescriberSelector?>("prescriber")!;set=>this["prescriber"]=value;}
public List<OrderCreateParamsOtcItemsItem>? OtcItems {get=>Value<List<OrderCreateParamsOtcItemsItem>?>("otcItems")!;set=>this["otcItems"]=value;}
public string? ExternalOrderId {get=>Value<string?>("externalOrderId")!;set=>this["externalOrderId"]=value;}
public Dictionary<string,object>? Metadata {get=>Value<Dictionary<string,object>?>("metadata")!;set=>this["metadata"]=value;}
public string? PatientId {get=>Value<string?>("patientId")!;set=>this["patientId"]=value;}
public OrderCreateParamsPatient? Patient {get=>Value<OrderCreateParamsPatient?>("patient")!;set=>this["patient"]=value;}
public string? ShippingAddressId {get=>Value<string?>("shippingAddressId")!;set=>this["shippingAddressId"]=value;}
public List<OrderCreateParamsPrescriptionsItem> Prescriptions {get=>Value<List<OrderCreateParamsPrescriptionsItem>>("prescriptions")!;set=>this["prescriptions"]=value;}}

public sealed class PrescriberSelector:SDKParameters{public string? Id {get=>Value<string?>("id")!;set=>this["id"]=value;}
public string? Npi {get=>Value<string?>("npi")!;set=>this["npi"]=value;}
public string? ExternalId {get=>Value<string?>("externalId")!;set=>this["externalId"]=value;}
public PrescriberSelectorProfile? Profile {get=>Value<PrescriberSelectorProfile?>("profile")!;set=>this["profile"]=value;}}

public sealed class PrescriberSelectorProfile:SDKParameters{public string? Email {get=>Value<string?>("email")!;set=>this["email"]=value;}
public string? Phone {get=>Value<string?>("phone")!;set=>this["phone"]=value;}}

public sealed class OrderCreateParamsOtcItemsItem:SDKParameters{public string CatalogItemId {get=>Value<string>("catalogItemId")!;set=>this["catalogItemId"]=value;}
public int Quantity {get=>Value<int>("quantity")!;set=>this["quantity"]=value;}}

public sealed class OrderCreateParamsPatient:SDKParameters{public OrderCreateParamsPatientAddress? Address {get=>Value<OrderCreateParamsPatientAddress?>("address")!;set=>this["address"]=value;}
public OrderCreateParamsPatientClinicalProfile? ClinicalProfile {get=>Value<OrderCreateParamsPatientClinicalProfile?>("clinicalProfile")!;set=>this["clinicalProfile"]=value;}
public string DateOfBirth {get=>Value<string>("dateOfBirth")!;set=>this["dateOfBirth"]=value;}
public string? Email {get=>Value<string?>("email")!;set=>this["email"]=value;}
public string? ExternalId {get=>Value<string?>("externalId")!;set=>this["externalId"]=value;}
public List<OrderCreateParamsPatientExternalIdentitiesItem>? ExternalIdentities {get=>Value<List<OrderCreateParamsPatientExternalIdentitiesItem>?>("externalIdentities")!;set=>this["externalIdentities"]=value;}
public List<OrderCreateParamsPatientAddressesItem>? Addresses {get=>Value<List<OrderCreateParamsPatientAddressesItem>?>("addresses")!;set=>this["addresses"]=value;}
public List<OrderCreateParamsPatientEncountersItem>? Encounters {get=>Value<List<OrderCreateParamsPatientEncountersItem>?>("encounters")!;set=>this["encounters"]=value;}
public string? Gender {get=>Value<string?>("gender")!;set=>this["gender"]=value;}
public string? LocationId {get=>Value<string?>("locationId")!;set=>this["locationId"]=value;}
public object? Metadata {get=>Value<object?>("metadata")!;set=>this["metadata"]=value;}
public string? MedicalRecordNumber {get=>Value<string?>("medicalRecordNumber")!;set=>this["medicalRecordNumber"]=value;}
public List<OrderCreateParamsPatientMeasurementsItem>? Measurements {get=>Value<List<OrderCreateParamsPatientMeasurementsItem>?>("measurements")!;set=>this["measurements"]=value;}
public OrderCreateParamsPatientName Name {get=>Value<OrderCreateParamsPatientName>("name")!;set=>this["name"]=value;}
public string? Phone {get=>Value<string?>("phone")!;set=>this["phone"]=value;}
public List<OrderCreateParamsPatientProgramsItem>? Programs {get=>Value<List<OrderCreateParamsPatientProgramsItem>?>("programs")!;set=>this["programs"]=value;}}

public sealed class OrderCreateParamsPatientAddress:SDKParameters{public string City {get=>Value<string>("city")!;set=>this["city"]=value;}
public string Line1 {get=>Value<string>("line1")!;set=>this["line1"]=value;}
public string? Line2 {get=>Value<string?>("line2")!;set=>this["line2"]=value;}
public string PostalCode {get=>Value<string>("postalCode")!;set=>this["postalCode"]=value;}
public string State {get=>Value<string>("state")!;set=>this["state"]=value;}
public string? Country {get=>Value<string?>("country")!;set=>this["country"]=value;}}

public sealed class OrderCreateParamsPatientClinicalProfile:SDKParameters{public List<string> CurrentMedications {get=>Value<List<string>>("currentMedications")!;set=>this["currentMedications"]=value;}
public object? HeightInches {get=>Value<object?>("heightInches")!;set=>this["heightInches"]=value;}
public string? ReviewedAt {get=>Value<string?>("reviewedAt")!;set=>this["reviewedAt"]=value;}
public object? WeightPounds {get=>Value<object?>("weightPounds")!;set=>this["weightPounds"]=value;}}

public sealed class OrderCreateParamsPatientExternalIdentitiesItem:SDKParameters{public string Source {get=>Value<string>("source")!;set=>this["source"]=value;}
public string Value {get=>Value<string>("value")!;set=>this["value"]=value;}}

public sealed class OrderCreateParamsPatientAddressesItem:SDKParameters{public string? Id {get=>Value<string?>("id")!;set=>this["id"]=value;}
public OrderCreateParamsPatientAddressesItemAddress Address {get=>Value<OrderCreateParamsPatientAddressesItemAddress>("address")!;set=>this["address"]=value;}
public string Label {get=>Value<string>("label")!;set=>this["label"]=value;}
public bool PreferredShipping {get=>Value<bool>("preferredShipping")!;set=>this["preferredShipping"]=value;}
public string? RecipientName {get=>Value<string?>("recipientName")!;set=>this["recipientName"]=value;}}

public sealed class OrderCreateParamsPatientAddressesItemAddress:SDKParameters{public string City {get=>Value<string>("city")!;set=>this["city"]=value;}
public string? Country {get=>Value<string?>("country")!;set=>this["country"]=value;}
public string Line1 {get=>Value<string>("line1")!;set=>this["line1"]=value;}
public string? Line2 {get=>Value<string?>("line2")!;set=>this["line2"]=value;}
public string PostalCode {get=>Value<string>("postalCode")!;set=>this["postalCode"]=value;}
public string State {get=>Value<string>("state")!;set=>this["state"]=value;}}

public sealed class OrderCreateParamsPatientEncountersItem:SDKParameters{public string? Notes {get=>Value<string?>("notes")!;set=>this["notes"]=value;}
public string OccurredAt {get=>Value<string>("occurredAt")!;set=>this["occurredAt"]=value;}
public string? ProviderName {get=>Value<string?>("providerName")!;set=>this["providerName"]=value;}
public string Type {get=>Value<string>("type")!;set=>this["type"]=value;}}

public sealed class OrderCreateParamsPatientMeasurementsItem:SDKParameters{public object? HeightCentimeters {get=>Value<object?>("heightCentimeters")!;set=>this["heightCentimeters"]=value;}
public string RecordedAt {get=>Value<string>("recordedAt")!;set=>this["recordedAt"]=value;}
public string Source {get=>Value<string>("source")!;set=>this["source"]=value;}
public object? WeightKilograms {get=>Value<object?>("weightKilograms")!;set=>this["weightKilograms"]=value;}}

public sealed class OrderCreateParamsPatientName:SDKParameters{public string First {get=>Value<string>("first")!;set=>this["first"]=value;}
public string Last {get=>Value<string>("last")!;set=>this["last"]=value;}
public string? Middle {get=>Value<string?>("middle")!;set=>this["middle"]=value;}
public string? Preferred {get=>Value<string?>("preferred")!;set=>this["preferred"]=value;}}

public sealed class OrderCreateParamsPatientProgramsItem:SDKParameters{public string? EndedAt {get=>Value<string?>("endedAt")!;set=>this["endedAt"]=value;}
public string Name {get=>Value<string>("name")!;set=>this["name"]=value;}
public string StartedAt {get=>Value<string>("startedAt")!;set=>this["startedAt"]=value;}
public string Status {get=>Value<string>("status")!;set=>this["status"]=value;}}

public sealed class OrderCreateParamsPrescriptionsItem:SDKParameters{public string? ExternalPrescriptionId {get=>Value<string?>("externalPrescriptionId")!;set=>this["externalPrescriptionId"]=value;}
public OrderCreateParamsPrescriptionsItemClinical? Clinical {get=>Value<OrderCreateParamsPrescriptionsItemClinical?>("clinical")!;set=>this["clinical"]=value;}
public string? PharmacyId {get=>Value<string?>("pharmacyId")!;set=>this["pharmacyId"]=value;}
public int DaysSupply {get=>Value<int>("daysSupply")!;set=>this["daysSupply"]=value;}
public OrderCreateParamsPrescriptionsItemDispensing Dispensing {get=>Value<OrderCreateParamsPrescriptionsItemDispensing>("dispensing")!;set=>this["dispensing"]=value;}
public string Directions {get=>Value<string>("directions")!;set=>this["directions"]=value;}
public string MedicationId {get=>Value<string>("medicationId")!;set=>this["medicationId"]=value;}
public object Quantity {get=>Value<object>("quantity")!;set=>this["quantity"]=value;}
public string QuantityUnit {get=>Value<string>("quantityUnit")!;set=>this["quantityUnit"]=value;}
public int Refills {get=>Value<int>("refills")!;set=>this["refills"]=value;}
public OrderCreateParamsPrescriptionsItemStructuredSig? StructuredSig {get=>Value<OrderCreateParamsPrescriptionsItemStructuredSig?>("structuredSig")!;set=>this["structuredSig"]=value;}}

public sealed class OrderCreateParamsPrescriptionsItemClinical:SDKParameters{public OrderCreateParamsPrescriptionsItemClinicalCompoundingReason? CompoundingReason {get=>Value<OrderCreateParamsPrescriptionsItemClinicalCompoundingReason?>("compoundingReason")!;set=>this["compoundingReason"]=value;}
public string? MedicationReviewStatus {get=>Value<string?>("medicationReviewStatus")!;set=>this["medicationReviewStatus"]=value;}
public string? DiagnosisReviewStatus {get=>Value<string?>("diagnosisReviewStatus")!;set=>this["diagnosisReviewStatus"]=value;}
public List<string>? CurrentMedications {get=>Value<List<string>?>("currentMedications")!;set=>this["currentMedications"]=value;}
public List<OrderCreateParamsPrescriptionsItemClinicalDiagnosesItem>? Diagnoses {get=>Value<List<OrderCreateParamsPrescriptionsItemClinicalDiagnosesItem>?>("diagnoses")!;set=>this["diagnoses"]=value;}
public List<OrderCreateParamsPrescriptionsItemClinicalObservationsItem>? Observations {get=>Value<List<OrderCreateParamsPrescriptionsItemClinicalObservationsItem>?>("observations")!;set=>this["observations"]=value;}}

public sealed class OrderCreateParamsPrescriptionsItemClinicalCompoundingReason:SDKParameters{public string? Category {get=>Value<string?>("category")!;set=>this["category"]=value;}
public string? Context {get=>Value<string?>("context")!;set=>this["context"]=value;}}

public sealed class OrderCreateParamsPrescriptionsItemClinicalDiagnosesItem:SDKParameters{public string Code {get=>Value<string>("code")!;set=>this["code"]=value;}
public string Display {get=>Value<string>("display")!;set=>this["display"]=value;}}

public sealed class OrderCreateParamsPrescriptionsItemClinicalObservationsItem:SDKParameters{public string Display {get=>Value<string>("display")!;set=>this["display"]=value;}
public string Unit {get=>Value<string>("unit")!;set=>this["unit"]=value;}
public object Value {get=>Value<object>("value")!;set=>this["value"]=value;}}

public sealed class OrderCreateParamsPrescriptionsItemDispensing:SDKParameters{public bool? DispenseUponAcceptance {get=>Value<bool?>("dispenseUponAcceptance")!;set=>this["dispenseUponAcceptance"]=value;}
public string? ShippingOptionId {get=>Value<string?>("shippingOptionId")!;set=>this["shippingOptionId"]=value;}
public int? ShippingAmountCents {get=>Value<int?>("shippingAmountCents")!;set=>this["shippingAmountCents"]=value;}
public string? ShippingDestinationType {get=>Value<string?>("shippingDestinationType")!;set=>this["shippingDestinationType"]=value;}
public string? PharmacyNotes {get=>Value<string?>("pharmacyNotes")!;set=>this["pharmacyNotes"]=value;}
public string? RequestedFillDate {get=>Value<string?>("requestedFillDate")!;set=>this["requestedFillDate"]=value;}
public bool? SubstitutionPermitted {get=>Value<bool?>("substitutionPermitted")!;set=>this["substitutionPermitted"]=value;}}

public sealed class OrderCreateParamsPrescriptionsItemStructuredSig:SDKParameters{public string Dose {get=>Value<string>("dose")!;set=>this["dose"]=value;}
public string DoseUnit {get=>Value<string>("doseUnit")!;set=>this["doseUnit"]=value;}
public string? Duration {get=>Value<string?>("duration")!;set=>this["duration"]=value;}
public string Frequency {get=>Value<string>("frequency")!;set=>this["frequency"]=value;}
public string? Indication {get=>Value<string?>("indication")!;set=>this["indication"]=value;}
public string? MaxDailyUse {get=>Value<string?>("maxDailyUse")!;set=>this["maxDailyUse"]=value;}
public bool? Prn {get=>Value<bool?>("prn")!;set=>this["prn"]=value;}
public string Route {get=>Value<string>("route")!;set=>this["route"]=value;}
public string? TitrationSchedule {get=>Value<string?>("titrationSchedule")!;set=>this["titrationSchedule"]=value;}}

public sealed class OrderCancelParams:SDKParameters{public string Reason {get=>Value<string>("reason")!;set=>this["reason"]=value;}}

public sealed class OrderExceptionActParams:SDKParameters{public string Action {get=>Value<string>("action")!;set=>this["action"]=value;}
public string? Note {get=>Value<string?>("note")!;set=>this["note"]=value;}}

public sealed class OrderEventListParams:SDKParameters{public string? EndingBefore {get=>Value<string?>("endingBefore")!;set=>this["endingBefore"]=value;}
public int? Limit {get=>Value<int?>("limit")!;set=>this["limit"]=value;}
public string? StartingAfter {get=>Value<string?>("startingAfter")!;set=>this["startingAfter"]=value;}}

public sealed class WebhookEndpointListParams:SDKParameters{public string? EndingBefore {get=>Value<string?>("endingBefore")!;set=>this["endingBefore"]=value;}
public int? Limit {get=>Value<int?>("limit")!;set=>this["limit"]=value;}
public string? StartingAfter {get=>Value<string?>("startingAfter")!;set=>this["startingAfter"]=value;}}

public sealed class WebhookEndpointCreateParams:SDKParameters{public List<string>? PracticeIds {get=>Value<List<string>?>("practiceIds")!;set=>this["practiceIds"]=value;}
public string? Description {get=>Value<string?>("description")!;set=>this["description"]=value;}
public string? PayloadStyle {get=>Value<string?>("payloadStyle")!;set=>this["payloadStyle"]=value;}
public List<string>? SubscribedEvents {get=>Value<List<string>?>("subscribedEvents")!;set=>this["subscribedEvents"]=value;}
public string Url {get=>Value<string>("url")!;set=>this["url"]=value;}}

public sealed class WebhookEndpointUpdateParams:SDKParameters{public List<string>? PracticeIds {get=>Value<List<string>?>("practiceIds")!;set=>this["practiceIds"]=value;}
public string? Description {get=>Value<string?>("description")!;set=>this["description"]=value;}
public string? PayloadStyle {get=>Value<string?>("payloadStyle")!;set=>this["payloadStyle"]=value;}
public string? Status {get=>Value<string?>("status")!;set=>this["status"]=value;}
public List<string>? SubscribedEvents {get=>Value<List<string>?>("subscribedEvents")!;set=>this["subscribedEvents"]=value;}
public string? Url {get=>Value<string?>("url")!;set=>this["url"]=value;}}

public sealed class WebhookEventListParams:SDKParameters{public string? EndingBefore {get=>Value<string?>("endingBefore")!;set=>this["endingBefore"]=value;}
public int? Limit {get=>Value<int?>("limit")!;set=>this["limit"]=value;}
public string? Status {get=>Value<string?>("status")!;set=>this["status"]=value;}
public string? StartingAfter {get=>Value<string?>("startingAfter")!;set=>this["startingAfter"]=value;}}

public sealed class OrderTestSimulationUpdateParams:SDKParameters{public string Mode {get=>Value<string>("mode")!;set=>this["mode"]=value;}
public string Scenario {get=>Value<string>("scenario")!;set=>this["scenario"]=value;}
public string? Action {get=>Value<string?>("action")!;set=>this["action"]=value;}}

public sealed class OrderPreviewParams:SDKParameters{public List<OrderPreviewParamsOtcItemsItem>? OtcItems {get=>Value<List<OrderPreviewParamsOtcItemsItem>?>("otcItems")!;set=>this["otcItems"]=value;}
public string? PatientId {get=>Value<string?>("patientId")!;set=>this["patientId"]=value;}
public string? PatientExternalId {get=>Value<string?>("patientExternalId")!;set=>this["patientExternalId"]=value;}
public OrderPreviewParamsPatient? Patient {get=>Value<OrderPreviewParamsPatient?>("patient")!;set=>this["patient"]=value;}
public string? UserId {get=>Value<string?>("userId")!;set=>this["userId"]=value;}
public PrescriberSelector? Prescriber {get=>Value<PrescriberSelector?>("prescriber")!;set=>this["prescriber"]=value;}
public string? ShippingAddressId {get=>Value<string?>("shippingAddressId")!;set=>this["shippingAddressId"]=value;}
public string? ExternalOrderId {get=>Value<string?>("externalOrderId")!;set=>this["externalOrderId"]=value;}
public List<OrderPreviewParamsPrescriptionsItem> Prescriptions {get=>Value<List<OrderPreviewParamsPrescriptionsItem>>("prescriptions")!;set=>this["prescriptions"]=value;}
public OrderPreviewParamsShipping? Shipping {get=>Value<OrderPreviewParamsShipping?>("shipping")!;set=>this["shipping"]=value;}}

public sealed class OrderPreviewParamsOtcItemsItem:SDKParameters{public string CatalogItemId {get=>Value<string>("catalogItemId")!;set=>this["catalogItemId"]=value;}
public int Quantity {get=>Value<int>("quantity")!;set=>this["quantity"]=value;}}

public sealed class OrderPreviewParamsPatient:SDKParameters{public OrderPreviewParamsPatientAddress? Address {get=>Value<OrderPreviewParamsPatientAddress?>("address")!;set=>this["address"]=value;}
public OrderPreviewParamsPatientClinicalProfile? ClinicalProfile {get=>Value<OrderPreviewParamsPatientClinicalProfile?>("clinicalProfile")!;set=>this["clinicalProfile"]=value;}
public string DateOfBirth {get=>Value<string>("dateOfBirth")!;set=>this["dateOfBirth"]=value;}
public string? Email {get=>Value<string?>("email")!;set=>this["email"]=value;}
public string? ExternalId {get=>Value<string?>("externalId")!;set=>this["externalId"]=value;}
public List<OrderPreviewParamsPatientExternalIdentitiesItem>? ExternalIdentities {get=>Value<List<OrderPreviewParamsPatientExternalIdentitiesItem>?>("externalIdentities")!;set=>this["externalIdentities"]=value;}
public List<OrderPreviewParamsPatientAddressesItem>? Addresses {get=>Value<List<OrderPreviewParamsPatientAddressesItem>?>("addresses")!;set=>this["addresses"]=value;}
public List<OrderPreviewParamsPatientEncountersItem>? Encounters {get=>Value<List<OrderPreviewParamsPatientEncountersItem>?>("encounters")!;set=>this["encounters"]=value;}
public string? Gender {get=>Value<string?>("gender")!;set=>this["gender"]=value;}
public string? LocationId {get=>Value<string?>("locationId")!;set=>this["locationId"]=value;}
public object? Metadata {get=>Value<object?>("metadata")!;set=>this["metadata"]=value;}
public string? MedicalRecordNumber {get=>Value<string?>("medicalRecordNumber")!;set=>this["medicalRecordNumber"]=value;}
public List<OrderPreviewParamsPatientMeasurementsItem>? Measurements {get=>Value<List<OrderPreviewParamsPatientMeasurementsItem>?>("measurements")!;set=>this["measurements"]=value;}
public OrderPreviewParamsPatientName Name {get=>Value<OrderPreviewParamsPatientName>("name")!;set=>this["name"]=value;}
public string? Phone {get=>Value<string?>("phone")!;set=>this["phone"]=value;}
public List<OrderPreviewParamsPatientProgramsItem>? Programs {get=>Value<List<OrderPreviewParamsPatientProgramsItem>?>("programs")!;set=>this["programs"]=value;}}

public sealed class OrderPreviewParamsPatientAddress:SDKParameters{public string City {get=>Value<string>("city")!;set=>this["city"]=value;}
public string Line1 {get=>Value<string>("line1")!;set=>this["line1"]=value;}
public string? Line2 {get=>Value<string?>("line2")!;set=>this["line2"]=value;}
public string PostalCode {get=>Value<string>("postalCode")!;set=>this["postalCode"]=value;}
public string State {get=>Value<string>("state")!;set=>this["state"]=value;}
public string? Country {get=>Value<string?>("country")!;set=>this["country"]=value;}}

public sealed class OrderPreviewParamsPatientClinicalProfile:SDKParameters{public List<string> CurrentMedications {get=>Value<List<string>>("currentMedications")!;set=>this["currentMedications"]=value;}
public object? HeightInches {get=>Value<object?>("heightInches")!;set=>this["heightInches"]=value;}
public string? ReviewedAt {get=>Value<string?>("reviewedAt")!;set=>this["reviewedAt"]=value;}
public object? WeightPounds {get=>Value<object?>("weightPounds")!;set=>this["weightPounds"]=value;}}

public sealed class OrderPreviewParamsPatientExternalIdentitiesItem:SDKParameters{public string Source {get=>Value<string>("source")!;set=>this["source"]=value;}
public string Value {get=>Value<string>("value")!;set=>this["value"]=value;}}

public sealed class OrderPreviewParamsPatientAddressesItem:SDKParameters{public string? Id {get=>Value<string?>("id")!;set=>this["id"]=value;}
public OrderPreviewParamsPatientAddressesItemAddress Address {get=>Value<OrderPreviewParamsPatientAddressesItemAddress>("address")!;set=>this["address"]=value;}
public string Label {get=>Value<string>("label")!;set=>this["label"]=value;}
public bool PreferredShipping {get=>Value<bool>("preferredShipping")!;set=>this["preferredShipping"]=value;}
public string? RecipientName {get=>Value<string?>("recipientName")!;set=>this["recipientName"]=value;}}

public sealed class OrderPreviewParamsPatientAddressesItemAddress:SDKParameters{public string City {get=>Value<string>("city")!;set=>this["city"]=value;}
public string? Country {get=>Value<string?>("country")!;set=>this["country"]=value;}
public string Line1 {get=>Value<string>("line1")!;set=>this["line1"]=value;}
public string? Line2 {get=>Value<string?>("line2")!;set=>this["line2"]=value;}
public string PostalCode {get=>Value<string>("postalCode")!;set=>this["postalCode"]=value;}
public string State {get=>Value<string>("state")!;set=>this["state"]=value;}}

public sealed class OrderPreviewParamsPatientEncountersItem:SDKParameters{public string? Notes {get=>Value<string?>("notes")!;set=>this["notes"]=value;}
public string OccurredAt {get=>Value<string>("occurredAt")!;set=>this["occurredAt"]=value;}
public string? ProviderName {get=>Value<string?>("providerName")!;set=>this["providerName"]=value;}
public string Type {get=>Value<string>("type")!;set=>this["type"]=value;}}

public sealed class OrderPreviewParamsPatientMeasurementsItem:SDKParameters{public object? HeightCentimeters {get=>Value<object?>("heightCentimeters")!;set=>this["heightCentimeters"]=value;}
public string RecordedAt {get=>Value<string>("recordedAt")!;set=>this["recordedAt"]=value;}
public string Source {get=>Value<string>("source")!;set=>this["source"]=value;}
public object? WeightKilograms {get=>Value<object?>("weightKilograms")!;set=>this["weightKilograms"]=value;}}

public sealed class OrderPreviewParamsPatientName:SDKParameters{public string First {get=>Value<string>("first")!;set=>this["first"]=value;}
public string Last {get=>Value<string>("last")!;set=>this["last"]=value;}
public string? Middle {get=>Value<string?>("middle")!;set=>this["middle"]=value;}
public string? Preferred {get=>Value<string?>("preferred")!;set=>this["preferred"]=value;}}

public sealed class OrderPreviewParamsPatientProgramsItem:SDKParameters{public string? EndedAt {get=>Value<string?>("endedAt")!;set=>this["endedAt"]=value;}
public string Name {get=>Value<string>("name")!;set=>this["name"]=value;}
public string StartedAt {get=>Value<string>("startedAt")!;set=>this["startedAt"]=value;}
public string Status {get=>Value<string>("status")!;set=>this["status"]=value;}}

public sealed class OrderPreviewParamsPrescriptionsItem:SDKParameters{public string MedicationId {get=>Value<string>("medicationId")!;set=>this["medicationId"]=value;}
public string? ExternalPrescriptionId {get=>Value<string?>("externalPrescriptionId")!;set=>this["externalPrescriptionId"]=value;}
public string? Preset {get=>Value<string?>("preset")!;set=>this["preset"]=value;}
public string? ExpectedRevision {get=>Value<string?>("expectedRevision")!;set=>this["expectedRevision"]=value;}
public OrderPreviewParamsPrescriptionsItemOverrides? Overrides {get=>Value<OrderPreviewParamsPrescriptionsItemOverrides?>("overrides")!;set=>this["overrides"]=value;}}

public sealed class OrderPreviewParamsPrescriptionsItemOverrides:SDKParameters{public object? Sig {get=>Value<object?>("sig")!;set=>this["sig"]=value;}
public OrderPreviewParamsPrescriptionsItemOverridesQuantity? Quantity {get=>Value<OrderPreviewParamsPrescriptionsItemOverridesQuantity?>("quantity")!;set=>this["quantity"]=value;}
public int? DaysSupply {get=>Value<int?>("daysSupply")!;set=>this["daysSupply"]=value;}
public int? Refills {get=>Value<int?>("refills")!;set=>this["refills"]=value;}
public OrderPreviewParamsPrescriptionsItemOverridesClinical? Clinical {get=>Value<OrderPreviewParamsPrescriptionsItemOverridesClinical?>("clinical")!;set=>this["clinical"]=value;}
public OrderPreviewParamsPrescriptionsItemOverridesDispensing? Dispensing {get=>Value<OrderPreviewParamsPrescriptionsItemOverridesDispensing?>("dispensing")!;set=>this["dispensing"]=value;}}

public sealed class OrderPreviewParamsPrescriptionsItemOverridesQuantity:SDKParameters{public double Value {get=>Value<double>("value")!;set=>this["value"]=value;}
public string Unit {get=>Value<string>("unit")!;set=>this["unit"]=value;}}

public sealed class OrderPreviewParamsPrescriptionsItemOverridesClinical:SDKParameters{public OrderPreviewParamsPrescriptionsItemOverridesClinicalCompoundingReason? CompoundingReason {get=>Value<OrderPreviewParamsPrescriptionsItemOverridesClinicalCompoundingReason?>("compoundingReason")!;set=>this["compoundingReason"]=value;}
public string? MedicationReviewStatus {get=>Value<string?>("medicationReviewStatus")!;set=>this["medicationReviewStatus"]=value;}
public string? DiagnosisReviewStatus {get=>Value<string?>("diagnosisReviewStatus")!;set=>this["diagnosisReviewStatus"]=value;}
public List<string>? CurrentMedications {get=>Value<List<string>?>("currentMedications")!;set=>this["currentMedications"]=value;}
public List<OrderPreviewParamsPrescriptionsItemOverridesClinicalDiagnosesItem>? Diagnoses {get=>Value<List<OrderPreviewParamsPrescriptionsItemOverridesClinicalDiagnosesItem>?>("diagnoses")!;set=>this["diagnoses"]=value;}
public List<OrderPreviewParamsPrescriptionsItemOverridesClinicalObservationsItem>? Observations {get=>Value<List<OrderPreviewParamsPrescriptionsItemOverridesClinicalObservationsItem>?>("observations")!;set=>this["observations"]=value;}}

public sealed class OrderPreviewParamsPrescriptionsItemOverridesClinicalCompoundingReason:SDKParameters{public string? Category {get=>Value<string?>("category")!;set=>this["category"]=value;}
public string? Context {get=>Value<string?>("context")!;set=>this["context"]=value;}}

public sealed class OrderPreviewParamsPrescriptionsItemOverridesClinicalDiagnosesItem:SDKParameters{public string Code {get=>Value<string>("code")!;set=>this["code"]=value;}
public string Display {get=>Value<string>("display")!;set=>this["display"]=value;}}

public sealed class OrderPreviewParamsPrescriptionsItemOverridesClinicalObservationsItem:SDKParameters{public string Display {get=>Value<string>("display")!;set=>this["display"]=value;}
public string Unit {get=>Value<string>("unit")!;set=>this["unit"]=value;}
public object Value {get=>Value<object>("value")!;set=>this["value"]=value;}}

public sealed class OrderPreviewParamsPrescriptionsItemOverridesDispensing:SDKParameters{public bool? DispenseUponAcceptance {get=>Value<bool?>("dispenseUponAcceptance")!;set=>this["dispenseUponAcceptance"]=value;}
public string? ShippingOptionId {get=>Value<string?>("shippingOptionId")!;set=>this["shippingOptionId"]=value;}
public int? ShippingAmountCents {get=>Value<int?>("shippingAmountCents")!;set=>this["shippingAmountCents"]=value;}
public string? ShippingDestinationType {get=>Value<string?>("shippingDestinationType")!;set=>this["shippingDestinationType"]=value;}
public string? PharmacyNotes {get=>Value<string?>("pharmacyNotes")!;set=>this["pharmacyNotes"]=value;}
public string? RequestedFillDate {get=>Value<string?>("requestedFillDate")!;set=>this["requestedFillDate"]=value;}
public bool? SubstitutionPermitted {get=>Value<bool?>("substitutionPermitted")!;set=>this["substitutionPermitted"]=value;}}

public sealed class OrderPreviewParamsShipping:SDKParameters{public string? Selection {get=>Value<string?>("selection")!;set=>this["selection"]=value;}}

public sealed class OrderSignParams:SDKParameters{public string? UserId {get=>Value<string?>("userId")!;set=>this["userId"]=value;}
public PrescriberSelector? Prescriber {get=>Value<PrescriberSelector?>("prescriber")!;set=>this["prescriber"]=value;}
public bool SignatureAttestation {get=>Value<bool>("signatureAttestation")!;set=>this["signatureAttestation"]=value;}
public string? ExpectedRevision {get=>Value<string?>("expectedRevision")!;set=>this["expectedRevision"]=value;}
public List<OrderSignParamsExpectedVersionsItem>? ExpectedVersions {get=>Value<List<OrderSignParamsExpectedVersionsItem>?>("expectedVersions")!;set=>this["expectedVersions"]=value;}}

public sealed class OrderSignParamsExpectedVersionsItem:SDKParameters{public string PrescriptionId {get=>Value<string>("prescriptionId")!;set=>this["prescriptionId"]=value;}
public int Version {get=>Value<int>("version")!;set=>this["version"]=value;}}

public sealed class OrderSignAndSubmitParams:SDKParameters{public string? UserId {get=>Value<string?>("userId")!;set=>this["userId"]=value;}
public PrescriberSelector? Prescriber {get=>Value<PrescriberSelector?>("prescriber")!;set=>this["prescriber"]=value;}
public bool SignatureAttestation {get=>Value<bool>("signatureAttestation")!;set=>this["signatureAttestation"]=value;}
public string? ExpectedRevision {get=>Value<string?>("expectedRevision")!;set=>this["expectedRevision"]=value;}
public List<OrderSignAndSubmitParamsExpectedVersionsItem>? ExpectedVersions {get=>Value<List<OrderSignAndSubmitParamsExpectedVersionsItem>?>("expectedVersions")!;set=>this["expectedVersions"]=value;}}

public sealed class OrderSignAndSubmitParamsExpectedVersionsItem:SDKParameters{public string PrescriptionId {get=>Value<string>("prescriptionId")!;set=>this["prescriptionId"]=value;}
public int Version {get=>Value<int>("version")!;set=>this["version"]=value;}}

public sealed class OrderRejectParams:SDKParameters{public string? UserId {get=>Value<string?>("userId")!;set=>this["userId"]=value;}
public PrescriberSelector? Prescriber {get=>Value<PrescriberSelector?>("prescriber")!;set=>this["prescriber"]=value;}
public string Reason {get=>Value<string>("reason")!;set=>this["reason"]=value;}
public string? ExpectedRevision {get=>Value<string?>("expectedRevision")!;set=>this["expectedRevision"]=value;}
public List<OrderRejectParamsExpectedVersionsItem>? ExpectedVersions {get=>Value<List<OrderRejectParamsExpectedVersionsItem>?>("expectedVersions")!;set=>this["expectedVersions"]=value;}}

public sealed class OrderRejectParamsExpectedVersionsItem:SDKParameters{public string PrescriptionId {get=>Value<string>("prescriptionId")!;set=>this["prescriptionId"]=value;}
public int Version {get=>Value<int>("version")!;set=>this["version"]=value;}}

public sealed class TeamRegisterParams:SDKParameters{public string ExternalId {get=>Value<string>("externalId")!;set=>this["externalId"]=value;}
public string Email {get=>Value<string>("email")!;set=>this["email"]=value;}
public string Name {get=>Value<string>("name")!;set=>this["name"]=value;}
public string Role {get=>Value<string>("role")!;set=>this["role"]=value;}
public List<string>? Roles {get=>Value<List<string>?>("roles")!;set=>this["roles"]=value;}
public TeamRegisterParamsProfileDetails? ProfileDetails {get=>Value<TeamRegisterParamsProfileDetails?>("profileDetails")!;set=>this["profileDetails"]=value;}
public string? Npi {get=>Value<string?>("npi")!;set=>this["npi"]=value;}
public List<TeamRegisterParamsLicensesItem>? Licenses {get=>Value<List<TeamRegisterParamsLicensesItem>?>("licenses")!;set=>this["licenses"]=value;}
public string? LegalName {get=>Value<string?>("legalName")!;set=>this["legalName"]=value;}
public string? DisplayName {get=>Value<string?>("displayName")!;set=>this["displayName"]=value;}
public string? Credentials {get=>Value<string?>("credentials")!;set=>this["credentials"]=value;}
public TeamRegisterParamsAddress? Address {get=>Value<TeamRegisterParamsAddress?>("address")!;set=>this["address"]=value;}
public string? Phone {get=>Value<string?>("phone")!;set=>this["phone"]=value;}
public List<string>? LocationIds {get=>Value<List<string>?>("locationIds")!;set=>this["locationIds"]=value;}
public bool IdentityAttestation {get=>Value<bool>("identityAttestation")!;set=>this["identityAttestation"]=value;}}

public sealed class TeamRegisterParamsProfileDetails:SDKParameters{public string? FirstName {get=>Value<string?>("firstName")!;set=>this["firstName"]=value;}
public string? MiddleName {get=>Value<string?>("middleName")!;set=>this["middleName"]=value;}
public string? LastName {get=>Value<string?>("lastName")!;set=>this["lastName"]=value;}
public string? NamePrefix {get=>Value<string?>("namePrefix")!;set=>this["namePrefix"]=value;}
public string? NameSuffix {get=>Value<string?>("nameSuffix")!;set=>this["nameSuffix"]=value;}
public string? Fax {get=>Value<string?>("fax")!;set=>this["fax"]=value;}
public List<TeamRegisterParamsProfileDetailsSpecialtiesItem>? Specialties {get=>Value<List<TeamRegisterParamsProfileDetailsSpecialtiesItem>?>("specialties")!;set=>this["specialties"]=value;}
public List<TeamRegisterParamsProfileDetailsAddressesItem>? Addresses {get=>Value<List<TeamRegisterParamsProfileDetailsAddressesItem>?>("addresses")!;set=>this["addresses"]=value;}
public List<TeamRegisterParamsProfileDetailsOtherNamesItem>? OtherNames {get=>Value<List<TeamRegisterParamsProfileDetailsOtherNamesItem>?>("otherNames")!;set=>this["otherNames"]=value;}
public List<TeamRegisterParamsProfileDetailsIdentifiersItem>? Identifiers {get=>Value<List<TeamRegisterParamsProfileDetailsIdentifiersItem>?>("identifiers")!;set=>this["identifiers"]=value;}
public List<TeamRegisterParamsProfileDetailsEndpointsItem>? Endpoints {get=>Value<List<TeamRegisterParamsProfileDetailsEndpointsItem>?>("endpoints")!;set=>this["endpoints"]=value;}
public List<TeamRegisterParamsProfileDetailsCertificationsItem>? Certifications {get=>Value<List<TeamRegisterParamsProfileDetailsCertificationsItem>?>("certifications")!;set=>this["certifications"]=value;}}

public sealed class TeamRegisterParamsProfileDetailsSpecialtiesItem:SDKParameters{public string Code {get=>Value<string>("code")!;set=>this["code"]=value;}
public string Description {get=>Value<string>("description")!;set=>this["description"]=value;}
public bool Primary {get=>Value<bool>("primary")!;set=>this["primary"]=value;}}

public sealed class TeamRegisterParamsProfileDetailsAddressesItem:SDKParameters{public string Purpose {get=>Value<string>("purpose")!;set=>this["purpose"]=value;}
public string Line1 {get=>Value<string>("line1")!;set=>this["line1"]=value;}
public string Line2 {get=>Value<string>("line2")!;set=>this["line2"]=value;}
public string City {get=>Value<string>("city")!;set=>this["city"]=value;}
public string State {get=>Value<string>("state")!;set=>this["state"]=value;}
public string PostalCode {get=>Value<string>("postalCode")!;set=>this["postalCode"]=value;}
public string Country {get=>Value<string>("country")!;set=>this["country"]=value;}
public string Phone {get=>Value<string>("phone")!;set=>this["phone"]=value;}
public string Fax {get=>Value<string>("fax")!;set=>this["fax"]=value;}}

public sealed class TeamRegisterParamsProfileDetailsOtherNamesItem:SDKParameters{public string Name {get=>Value<string>("name")!;set=>this["name"]=value;}
public string Credentials {get=>Value<string>("credentials")!;set=>this["credentials"]=value;}
public string Type {get=>Value<string>("type")!;set=>this["type"]=value;}}

public sealed class TeamRegisterParamsProfileDetailsIdentifiersItem:SDKParameters{public string Identifier {get=>Value<string>("identifier")!;set=>this["identifier"]=value;}
public string Issuer {get=>Value<string>("issuer")!;set=>this["issuer"]=value;}
public string State {get=>Value<string>("state")!;set=>this["state"]=value;}
public string Description {get=>Value<string>("description")!;set=>this["description"]=value;}}

public sealed class TeamRegisterParamsProfileDetailsEndpointsItem:SDKParameters{public string Endpoint {get=>Value<string>("endpoint")!;set=>this["endpoint"]=value;}
public string Type {get=>Value<string>("type")!;set=>this["type"]=value;}
public string Description {get=>Value<string>("description")!;set=>this["description"]=value;}
public string Use {get=>Value<string>("use")!;set=>this["use"]=value;}
public string Affiliation {get=>Value<string>("affiliation")!;set=>this["affiliation"]=value;}}

public sealed class TeamRegisterParamsProfileDetailsCertificationsItem:SDKParameters{public string Name {get=>Value<string>("name")!;set=>this["name"]=value;}
public string Issuer {get=>Value<string>("issuer")!;set=>this["issuer"]=value;}
public string ExpiresAt {get=>Value<string>("expiresAt")!;set=>this["expiresAt"]=value;}}

public sealed class TeamRegisterParamsLicensesItem:SDKParameters{public string State {get=>Value<string>("state")!;set=>this["state"]=value;}
public string LicenseNumber {get=>Value<string>("licenseNumber")!;set=>this["licenseNumber"]=value;}
public string? ExpiresAt {get=>Value<string?>("expiresAt")!;set=>this["expiresAt"]=value;}}

public sealed class TeamRegisterParamsAddress:SDKParameters{public string City {get=>Value<string>("city")!;set=>this["city"]=value;}
public string Country {get=>Value<string>("country")!;set=>this["country"]=value;}
public string Line1 {get=>Value<string>("line1")!;set=>this["line1"]=value;}
public string? Line2 {get=>Value<string?>("line2")!;set=>this["line2"]=value;}
public string PostalCode {get=>Value<string>("postalCode")!;set=>this["postalCode"]=value;}
public string State {get=>Value<string>("state")!;set=>this["state"]=value;}}

public sealed class PatientAddressListParams:SDKParameters{public string? Status {get=>Value<string?>("status")!;set=>this["status"]=value;}
public string? StartingAfter {get=>Value<string?>("startingAfter")!;set=>this["startingAfter"]=value;}
public string? EndingBefore {get=>Value<string?>("endingBefore")!;set=>this["endingBefore"]=value;}
public int? Limit {get=>Value<int?>("limit")!;set=>this["limit"]=value;}}

public sealed class PatientAddressCreateParams:SDKParameters{public PatientAddressCreateParamsAddress Address {get=>Value<PatientAddressCreateParamsAddress>("address")!;set=>this["address"]=value;}
public string? Label {get=>Value<string?>("label")!;set=>this["label"]=value;}
public bool? PreferredShipping {get=>Value<bool?>("preferredShipping")!;set=>this["preferredShipping"]=value;}
public string? RecipientName {get=>Value<string?>("recipientName")!;set=>this["recipientName"]=value;}}

public sealed class PatientAddressCreateParamsAddress:SDKParameters{public string City {get=>Value<string>("city")!;set=>this["city"]=value;}
public string? Country {get=>Value<string?>("country")!;set=>this["country"]=value;}
public string Line1 {get=>Value<string>("line1")!;set=>this["line1"]=value;}
public string? Line2 {get=>Value<string?>("line2")!;set=>this["line2"]=value;}
public string PostalCode {get=>Value<string>("postalCode")!;set=>this["postalCode"]=value;}
public string State {get=>Value<string>("state")!;set=>this["state"]=value;}}

public sealed class PatientAddressUpdateParams:SDKParameters{public PatientAddressUpdateParamsAddress? Address {get=>Value<PatientAddressUpdateParamsAddress?>("address")!;set=>this["address"]=value;}
public string? Label {get=>Value<string?>("label")!;set=>this["label"]=value;}
public string? RecipientName {get=>Value<string?>("recipientName")!;set=>this["recipientName"]=value;}
public bool? PreferredShipping {get=>Value<bool?>("preferredShipping")!;set=>this["preferredShipping"]=value;}}

public sealed class PatientAddressUpdateParamsAddress:SDKParameters{public string City {get=>Value<string>("city")!;set=>this["city"]=value;}
public string? Country {get=>Value<string?>("country")!;set=>this["country"]=value;}
public string Line1 {get=>Value<string>("line1")!;set=>this["line1"]=value;}
public string? Line2 {get=>Value<string?>("line2")!;set=>this["line2"]=value;}
public string PostalCode {get=>Value<string>("postalCode")!;set=>this["postalCode"]=value;}
public string State {get=>Value<string>("state")!;set=>this["state"]=value;}}

public sealed class TeamInvitationCreateParams:SDKParameters{public string ExternalId {get=>Value<string>("externalId")!;set=>this["externalId"]=value;}
public string Email {get=>Value<string>("email")!;set=>this["email"]=value;}
public string Name {get=>Value<string>("name")!;set=>this["name"]=value;}
public string? Role {get=>Value<string?>("role")!;set=>this["role"]=value;}
public List<string>? Roles {get=>Value<List<string>?>("roles")!;set=>this["roles"]=value;}
public TeamInvitationCreateParamsProfileDetails? ProfileDetails {get=>Value<TeamInvitationCreateParamsProfileDetails?>("profileDetails")!;set=>this["profileDetails"]=value;}
public string? Npi {get=>Value<string?>("npi")!;set=>this["npi"]=value;}
public List<TeamInvitationCreateParamsLicensesItem>? Licenses {get=>Value<List<TeamInvitationCreateParamsLicensesItem>?>("licenses")!;set=>this["licenses"]=value;}
public string? LegalName {get=>Value<string?>("legalName")!;set=>this["legalName"]=value;}
public string? DisplayName {get=>Value<string?>("displayName")!;set=>this["displayName"]=value;}
public string? Credentials {get=>Value<string?>("credentials")!;set=>this["credentials"]=value;}
public TeamInvitationCreateParamsAddress? Address {get=>Value<TeamInvitationCreateParamsAddress?>("address")!;set=>this["address"]=value;}
public string? Phone {get=>Value<string?>("phone")!;set=>this["phone"]=value;}
public List<string>? LocationIds {get=>Value<List<string>?>("locationIds")!;set=>this["locationIds"]=value;}}

public sealed class TeamInvitationCreateParamsProfileDetails:SDKParameters{public string? FirstName {get=>Value<string?>("firstName")!;set=>this["firstName"]=value;}
public string? MiddleName {get=>Value<string?>("middleName")!;set=>this["middleName"]=value;}
public string? LastName {get=>Value<string?>("lastName")!;set=>this["lastName"]=value;}
public string? NamePrefix {get=>Value<string?>("namePrefix")!;set=>this["namePrefix"]=value;}
public string? NameSuffix {get=>Value<string?>("nameSuffix")!;set=>this["nameSuffix"]=value;}
public string? Fax {get=>Value<string?>("fax")!;set=>this["fax"]=value;}
public List<TeamInvitationCreateParamsProfileDetailsSpecialtiesItem>? Specialties {get=>Value<List<TeamInvitationCreateParamsProfileDetailsSpecialtiesItem>?>("specialties")!;set=>this["specialties"]=value;}
public List<TeamInvitationCreateParamsProfileDetailsAddressesItem>? Addresses {get=>Value<List<TeamInvitationCreateParamsProfileDetailsAddressesItem>?>("addresses")!;set=>this["addresses"]=value;}
public List<TeamInvitationCreateParamsProfileDetailsOtherNamesItem>? OtherNames {get=>Value<List<TeamInvitationCreateParamsProfileDetailsOtherNamesItem>?>("otherNames")!;set=>this["otherNames"]=value;}
public List<TeamInvitationCreateParamsProfileDetailsIdentifiersItem>? Identifiers {get=>Value<List<TeamInvitationCreateParamsProfileDetailsIdentifiersItem>?>("identifiers")!;set=>this["identifiers"]=value;}
public List<TeamInvitationCreateParamsProfileDetailsEndpointsItem>? Endpoints {get=>Value<List<TeamInvitationCreateParamsProfileDetailsEndpointsItem>?>("endpoints")!;set=>this["endpoints"]=value;}
public List<TeamInvitationCreateParamsProfileDetailsCertificationsItem>? Certifications {get=>Value<List<TeamInvitationCreateParamsProfileDetailsCertificationsItem>?>("certifications")!;set=>this["certifications"]=value;}}

public sealed class TeamInvitationCreateParamsProfileDetailsSpecialtiesItem:SDKParameters{public string Code {get=>Value<string>("code")!;set=>this["code"]=value;}
public string Description {get=>Value<string>("description")!;set=>this["description"]=value;}
public bool Primary {get=>Value<bool>("primary")!;set=>this["primary"]=value;}}

public sealed class TeamInvitationCreateParamsProfileDetailsAddressesItem:SDKParameters{public string Purpose {get=>Value<string>("purpose")!;set=>this["purpose"]=value;}
public string Line1 {get=>Value<string>("line1")!;set=>this["line1"]=value;}
public string Line2 {get=>Value<string>("line2")!;set=>this["line2"]=value;}
public string City {get=>Value<string>("city")!;set=>this["city"]=value;}
public string State {get=>Value<string>("state")!;set=>this["state"]=value;}
public string PostalCode {get=>Value<string>("postalCode")!;set=>this["postalCode"]=value;}
public string Country {get=>Value<string>("country")!;set=>this["country"]=value;}
public string Phone {get=>Value<string>("phone")!;set=>this["phone"]=value;}
public string Fax {get=>Value<string>("fax")!;set=>this["fax"]=value;}}

public sealed class TeamInvitationCreateParamsProfileDetailsOtherNamesItem:SDKParameters{public string Name {get=>Value<string>("name")!;set=>this["name"]=value;}
public string Credentials {get=>Value<string>("credentials")!;set=>this["credentials"]=value;}
public string Type {get=>Value<string>("type")!;set=>this["type"]=value;}}

public sealed class TeamInvitationCreateParamsProfileDetailsIdentifiersItem:SDKParameters{public string Identifier {get=>Value<string>("identifier")!;set=>this["identifier"]=value;}
public string Issuer {get=>Value<string>("issuer")!;set=>this["issuer"]=value;}
public string State {get=>Value<string>("state")!;set=>this["state"]=value;}
public string Description {get=>Value<string>("description")!;set=>this["description"]=value;}}

public sealed class TeamInvitationCreateParamsProfileDetailsEndpointsItem:SDKParameters{public string Endpoint {get=>Value<string>("endpoint")!;set=>this["endpoint"]=value;}
public string Type {get=>Value<string>("type")!;set=>this["type"]=value;}
public string Description {get=>Value<string>("description")!;set=>this["description"]=value;}
public string Use {get=>Value<string>("use")!;set=>this["use"]=value;}
public string Affiliation {get=>Value<string>("affiliation")!;set=>this["affiliation"]=value;}}

public sealed class TeamInvitationCreateParamsProfileDetailsCertificationsItem:SDKParameters{public string Name {get=>Value<string>("name")!;set=>this["name"]=value;}
public string Issuer {get=>Value<string>("issuer")!;set=>this["issuer"]=value;}
public string ExpiresAt {get=>Value<string>("expiresAt")!;set=>this["expiresAt"]=value;}}

public sealed class TeamInvitationCreateParamsLicensesItem:SDKParameters{public string State {get=>Value<string>("state")!;set=>this["state"]=value;}
public string LicenseNumber {get=>Value<string>("licenseNumber")!;set=>this["licenseNumber"]=value;}
public string? ExpiresAt {get=>Value<string?>("expiresAt")!;set=>this["expiresAt"]=value;}}

public sealed class TeamInvitationCreateParamsAddress:SDKParameters{public string City {get=>Value<string>("city")!;set=>this["city"]=value;}
public string Country {get=>Value<string>("country")!;set=>this["country"]=value;}
public string Line1 {get=>Value<string>("line1")!;set=>this["line1"]=value;}
public string? Line2 {get=>Value<string?>("line2")!;set=>this["line2"]=value;}
public string PostalCode {get=>Value<string>("postalCode")!;set=>this["postalCode"]=value;}
public string State {get=>Value<string>("state")!;set=>this["state"]=value;}}

public sealed class TeamInvitationListParams:SDKParameters{public int? Limit {get=>Value<int?>("limit")!;set=>this["limit"]=value;}
public string? StartingAfter {get=>Value<string?>("startingAfter")!;set=>this["startingAfter"]=value;}
public string? EndingBefore {get=>Value<string?>("endingBefore")!;set=>this["endingBefore"]=value;}
public string? Status {get=>Value<string?>("status")!;set=>this["status"]=value;}
public string? Email {get=>Value<string?>("email")!;set=>this["email"]=value;}
public string? ExternalId {get=>Value<string?>("externalId")!;set=>this["externalId"]=value;}}

public sealed class TeamMemberListParams:SDKParameters{public int? Limit {get=>Value<int?>("limit")!;set=>this["limit"]=value;}
public string? StartingAfter {get=>Value<string?>("startingAfter")!;set=>this["startingAfter"]=value;}
public string? EndingBefore {get=>Value<string?>("endingBefore")!;set=>this["endingBefore"]=value;}
public string? Search {get=>Value<string?>("search")!;set=>this["search"]=value;}
public string? Role {get=>Value<string?>("role")!;set=>this["role"]=value;}
public string? Status {get=>Value<string?>("status")!;set=>this["status"]=value;}}

public sealed class TeamPrescriberListParams:SDKParameters{public int? Limit {get=>Value<int?>("limit")!;set=>this["limit"]=value;}
public string? StartingAfter {get=>Value<string?>("startingAfter")!;set=>this["startingAfter"]=value;}
public string? EndingBefore {get=>Value<string?>("endingBefore")!;set=>this["endingBefore"]=value;}
public string? Search {get=>Value<string?>("search")!;set=>this["search"]=value;}
public string? Npi {get=>Value<string?>("npi")!;set=>this["npi"]=value;}
public string? State {get=>Value<string?>("state")!;set=>this["state"]=value;}
public string? Status {get=>Value<string?>("status")!;set=>this["status"]=value;}}

public sealed class TeamMemberUpdateParams:SDKParameters{public string? Role {get=>Value<string?>("role")!;set=>this["role"]=value;}
public List<string>? Roles {get=>Value<List<string>?>("roles")!;set=>this["roles"]=value;}
public string? Status {get=>Value<string?>("status")!;set=>this["status"]=value;}
public List<string>? LocationIds {get=>Value<List<string>?>("locationIds")!;set=>this["locationIds"]=value;}}

public sealed class TeamPrescriberUpdateParams:SDKParameters{public string? DisplayName {get=>Value<string?>("displayName")!;set=>this["displayName"]=value;}
public string? LegalName {get=>Value<string?>("legalName")!;set=>this["legalName"]=value;}
public string? Credentials {get=>Value<string?>("credentials")!;set=>this["credentials"]=value;}
public string? Phone {get=>Value<string?>("phone")!;set=>this["phone"]=value;}
public TeamPrescriberUpdateParamsAddress? Address {get=>Value<TeamPrescriberUpdateParamsAddress?>("address")!;set=>this["address"]=value;}
public string? PracticeStatus {get=>Value<string?>("practiceStatus")!;set=>this["practiceStatus"]=value;}}

public sealed class TeamPrescriberUpdateParamsAddress:SDKParameters{public string City {get=>Value<string>("city")!;set=>this["city"]=value;}
public string Country {get=>Value<string>("country")!;set=>this["country"]=value;}
public string Line1 {get=>Value<string>("line1")!;set=>this["line1"]=value;}
public string? Line2 {get=>Value<string?>("line2")!;set=>this["line2"]=value;}
public string PostalCode {get=>Value<string>("postalCode")!;set=>this["postalCode"]=value;}
public string State {get=>Value<string>("state")!;set=>this["state"]=value;}}

public sealed class TeamPrescriberLicenseCreateParams:SDKParameters{public string State {get=>Value<string>("state")!;set=>this["state"]=value;}
public string LicenseNumber {get=>Value<string>("licenseNumber")!;set=>this["licenseNumber"]=value;}
public string? ExpiresAt {get=>Value<string?>("expiresAt")!;set=>this["expiresAt"]=value;}}

public sealed class TeamPrescriberLicenseUpdateParams:SDKParameters{public string? State {get=>Value<string?>("state")!;set=>this["state"]=value;}
public string? LicenseNumber {get=>Value<string?>("licenseNumber")!;set=>this["licenseNumber"]=value;}
public string? ExpiresAt {get=>Value<string?>("expiresAt")!;set=>this["expiresAt"]=value;}}

public sealed class PracticeListParams:SDKParameters{public string? Search {get=>Value<string?>("search")!;set=>this["search"]=value;}
public string? EndingBefore {get=>Value<string?>("endingBefore")!;set=>this["endingBefore"]=value;}
public int? Limit {get=>Value<int?>("limit")!;set=>this["limit"]=value;}
public string? StartingAfter {get=>Value<string?>("startingAfter")!;set=>this["startingAfter"]=value;}}

public sealed class PracticeCreateParams:SDKParameters{public bool? LiveEnabled {get=>Value<bool?>("liveEnabled")!;set=>this["liveEnabled"]=value;}
public PracticeCreateParamsAddress Address {get=>Value<PracticeCreateParamsAddress>("address")!;set=>this["address"]=value;}
public PracticeCreateParamsAttestations Attestations {get=>Value<PracticeCreateParamsAttestations>("attestations")!;set=>this["attestations"]=value;}
public PracticeCreateParamsComplianceContact? ComplianceContact {get=>Value<PracticeCreateParamsComplianceContact?>("complianceContact")!;set=>this["complianceContact"]=value;}
public string? ExternalId {get=>Value<string?>("externalId")!;set=>this["externalId"]=value;}
public string? LegalName {get=>Value<string?>("legalName")!;set=>this["legalName"]=value;}
public object? Metadata {get=>Value<object?>("metadata")!;set=>this["metadata"]=value;}
public string Name {get=>Value<string>("name")!;set=>this["name"]=value;}
public List<PracticeCreateParamsPrescribersItem>? Prescribers {get=>Value<List<PracticeCreateParamsPrescribersItem>?>("prescribers")!;set=>this["prescribers"]=value;}
public PracticeCreateParamsPrimaryContact? PrimaryContact {get=>Value<PracticeCreateParamsPrimaryContact?>("primaryContact")!;set=>this["primaryContact"]=value;}
public string? SupportEmail {get=>Value<string?>("supportEmail")!;set=>this["supportEmail"]=value;}
public string? SupportPhone {get=>Value<string?>("supportPhone")!;set=>this["supportPhone"]=value;}
public string? Timezone {get=>Value<string?>("timezone")!;set=>this["timezone"]=value;}}

public sealed class PracticeCreateParamsAddress:SDKParameters{public string City {get=>Value<string>("city")!;set=>this["city"]=value;}
public string? Country {get=>Value<string?>("country")!;set=>this["country"]=value;}
public string Line1 {get=>Value<string>("line1")!;set=>this["line1"]=value;}
public string? Line2 {get=>Value<string?>("line2")!;set=>this["line2"]=value;}
public string PostalCode {get=>Value<string>("postalCode")!;set=>this["postalCode"]=value;}
public string State {get=>Value<string>("state")!;set=>this["state"]=value;}}

public sealed class PracticeCreateParamsAttestations:SDKParameters{public bool AuthorizedPracticeRelationship {get=>Value<bool>("authorizedPracticeRelationship")!;set=>this["authorizedPracticeRelationship"]=value;}
public bool AuthorizedPhiTransfer {get=>Value<bool>("authorizedPhiTransfer")!;set=>this["authorizedPhiTransfer"]=value;}
public bool MinimumNecessaryPhi {get=>Value<bool>("minimumNecessaryPhi")!;set=>this["minimumNecessaryPhi"]=value;}
public bool ProviderDataAccuracy {get=>Value<bool>("providerDataAccuracy")!;set=>this["providerDataAccuracy"]=value;}}

public sealed class PracticeCreateParamsComplianceContact:SDKParameters{public string Email {get=>Value<string>("email")!;set=>this["email"]=value;}
public string Name {get=>Value<string>("name")!;set=>this["name"]=value;}
public string? Phone {get=>Value<string?>("phone")!;set=>this["phone"]=value;}}

public sealed class PracticeCreateParamsPrescribersItem:SDKParameters{public string? Credentials {get=>Value<string?>("credentials")!;set=>this["credentials"]=value;}
public List<string> LicenseStates {get=>Value<List<string>>("licenseStates")!;set=>this["licenseStates"]=value;}
public string Name {get=>Value<string>("name")!;set=>this["name"]=value;}
public string Npi {get=>Value<string>("npi")!;set=>this["npi"]=value;}}

public sealed class PracticeCreateParamsPrimaryContact:SDKParameters{public string Email {get=>Value<string>("email")!;set=>this["email"]=value;}
public string Name {get=>Value<string>("name")!;set=>this["name"]=value;}
public string? Phone {get=>Value<string?>("phone")!;set=>this["phone"]=value;}}

public sealed class PracticeUpdateParams:SDKParameters{public bool? LiveEnabled {get=>Value<bool?>("liveEnabled")!;set=>this["liveEnabled"]=value;}
public PracticeUpdateParamsAddress? Address {get=>Value<PracticeUpdateParamsAddress?>("address")!;set=>this["address"]=value;}
public PracticeUpdateParamsAttestations? Attestations {get=>Value<PracticeUpdateParamsAttestations?>("attestations")!;set=>this["attestations"]=value;}
public PracticeUpdateParamsComplianceContact? ComplianceContact {get=>Value<PracticeUpdateParamsComplianceContact?>("complianceContact")!;set=>this["complianceContact"]=value;}
public string? ExternalId {get=>Value<string?>("externalId")!;set=>this["externalId"]=value;}
public string? LegalName {get=>Value<string?>("legalName")!;set=>this["legalName"]=value;}
public object? Metadata {get=>Value<object?>("metadata")!;set=>this["metadata"]=value;}
public string? Name {get=>Value<string?>("name")!;set=>this["name"]=value;}
public List<PracticeUpdateParamsPrescribersItem>? Prescribers {get=>Value<List<PracticeUpdateParamsPrescribersItem>?>("prescribers")!;set=>this["prescribers"]=value;}
public PracticeUpdateParamsPrimaryContact? PrimaryContact {get=>Value<PracticeUpdateParamsPrimaryContact?>("primaryContact")!;set=>this["primaryContact"]=value;}
public string? SupportEmail {get=>Value<string?>("supportEmail")!;set=>this["supportEmail"]=value;}
public string? SupportPhone {get=>Value<string?>("supportPhone")!;set=>this["supportPhone"]=value;}
public string? Timezone {get=>Value<string?>("timezone")!;set=>this["timezone"]=value;}}

public sealed class PracticeUpdateParamsAddress:SDKParameters{public string City {get=>Value<string>("city")!;set=>this["city"]=value;}
public string? Country {get=>Value<string?>("country")!;set=>this["country"]=value;}
public string Line1 {get=>Value<string>("line1")!;set=>this["line1"]=value;}
public string? Line2 {get=>Value<string?>("line2")!;set=>this["line2"]=value;}
public string PostalCode {get=>Value<string>("postalCode")!;set=>this["postalCode"]=value;}
public string State {get=>Value<string>("state")!;set=>this["state"]=value;}}

public sealed class PracticeUpdateParamsAttestations:SDKParameters{public bool AuthorizedPracticeRelationship {get=>Value<bool>("authorizedPracticeRelationship")!;set=>this["authorizedPracticeRelationship"]=value;}
public bool AuthorizedPhiTransfer {get=>Value<bool>("authorizedPhiTransfer")!;set=>this["authorizedPhiTransfer"]=value;}
public bool MinimumNecessaryPhi {get=>Value<bool>("minimumNecessaryPhi")!;set=>this["minimumNecessaryPhi"]=value;}
public bool ProviderDataAccuracy {get=>Value<bool>("providerDataAccuracy")!;set=>this["providerDataAccuracy"]=value;}}

public sealed class PracticeUpdateParamsComplianceContact:SDKParameters{public string Email {get=>Value<string>("email")!;set=>this["email"]=value;}
public string Name {get=>Value<string>("name")!;set=>this["name"]=value;}
public string? Phone {get=>Value<string?>("phone")!;set=>this["phone"]=value;}}

public sealed class PracticeUpdateParamsPrescribersItem:SDKParameters{public string? Credentials {get=>Value<string?>("credentials")!;set=>this["credentials"]=value;}
public List<string> LicenseStates {get=>Value<List<string>>("licenseStates")!;set=>this["licenseStates"]=value;}
public string Name {get=>Value<string>("name")!;set=>this["name"]=value;}
public string Npi {get=>Value<string>("npi")!;set=>this["npi"]=value;}}

public sealed class PracticeUpdateParamsPrimaryContact:SDKParameters{public string Email {get=>Value<string>("email")!;set=>this["email"]=value;}
public string Name {get=>Value<string>("name")!;set=>this["name"]=value;}
public string? Phone {get=>Value<string?>("phone")!;set=>this["phone"]=value;}}

public sealed class PatientListParams:SDKParameters{public string? EndingBefore {get=>Value<string?>("endingBefore")!;set=>this["endingBefore"]=value;}
public string? ExternalId {get=>Value<string?>("externalId")!;set=>this["externalId"]=value;}
public string? ExternalIdentitySource {get=>Value<string?>("externalIdentitySource")!;set=>this["externalIdentitySource"]=value;}
public string? ExternalIdentityValue {get=>Value<string?>("externalIdentityValue")!;set=>this["externalIdentityValue"]=value;}
public string? Gender {get=>Value<string?>("gender")!;set=>this["gender"]=value;}
public string? LastOrderAfter {get=>Value<string?>("lastOrderAfter")!;set=>this["lastOrderAfter"]=value;}
public string? LastOrderBefore {get=>Value<string?>("lastOrderBefore")!;set=>this["lastOrderBefore"]=value;}
public int? Limit {get=>Value<int?>("limit")!;set=>this["limit"]=value;}
public string? Program {get=>Value<string?>("program")!;set=>this["program"]=value;}
public string? Query {get=>Value<string?>("query")!;set=>this["query"]=value;}
public string? Sort {get=>Value<string?>("sort")!;set=>this["sort"]=value;}
public string? StartingAfter {get=>Value<string?>("startingAfter")!;set=>this["startingAfter"]=value;}
public string? States {get=>Value<string?>("states")!;set=>this["states"]=value;}
public string? Status {get=>Value<string?>("status")!;set=>this["status"]=value;}}

public sealed class PatientCreateParams:SDKParameters{public PatientCreateParamsAddress? Address {get=>Value<PatientCreateParamsAddress?>("address")!;set=>this["address"]=value;}
public PatientCreateParamsClinicalProfile? ClinicalProfile {get=>Value<PatientCreateParamsClinicalProfile?>("clinicalProfile")!;set=>this["clinicalProfile"]=value;}
public string DateOfBirth {get=>Value<string>("dateOfBirth")!;set=>this["dateOfBirth"]=value;}
public string? Email {get=>Value<string?>("email")!;set=>this["email"]=value;}
public string? ExternalId {get=>Value<string?>("externalId")!;set=>this["externalId"]=value;}
public List<PatientCreateParamsExternalIdentitiesItem>? ExternalIdentities {get=>Value<List<PatientCreateParamsExternalIdentitiesItem>?>("externalIdentities")!;set=>this["externalIdentities"]=value;}
public List<PatientCreateParamsAddressesItem>? Addresses {get=>Value<List<PatientCreateParamsAddressesItem>?>("addresses")!;set=>this["addresses"]=value;}
public List<PatientCreateParamsEncountersItem>? Encounters {get=>Value<List<PatientCreateParamsEncountersItem>?>("encounters")!;set=>this["encounters"]=value;}
public string? Gender {get=>Value<string?>("gender")!;set=>this["gender"]=value;}
public string? LocationId {get=>Value<string?>("locationId")!;set=>this["locationId"]=value;}
public object? Metadata {get=>Value<object?>("metadata")!;set=>this["metadata"]=value;}
public string? MedicalRecordNumber {get=>Value<string?>("medicalRecordNumber")!;set=>this["medicalRecordNumber"]=value;}
public List<PatientCreateParamsMeasurementsItem>? Measurements {get=>Value<List<PatientCreateParamsMeasurementsItem>?>("measurements")!;set=>this["measurements"]=value;}
public PatientName Name {get=>Value<PatientName>("name")!;set=>this["name"]=value;}
public string? Phone {get=>Value<string?>("phone")!;set=>this["phone"]=value;}
public List<PatientCreateParamsProgramsItem>? Programs {get=>Value<List<PatientCreateParamsProgramsItem>?>("programs")!;set=>this["programs"]=value;}}

public sealed class PatientCreateParamsAddress:SDKParameters{public string City {get=>Value<string>("city")!;set=>this["city"]=value;}
public string Line1 {get=>Value<string>("line1")!;set=>this["line1"]=value;}
public string? Line2 {get=>Value<string?>("line2")!;set=>this["line2"]=value;}
public string PostalCode {get=>Value<string>("postalCode")!;set=>this["postalCode"]=value;}
public string State {get=>Value<string>("state")!;set=>this["state"]=value;}
public string? Country {get=>Value<string?>("country")!;set=>this["country"]=value;}}

public sealed class PatientCreateParamsClinicalProfile:SDKParameters{public List<string> CurrentMedications {get=>Value<List<string>>("currentMedications")!;set=>this["currentMedications"]=value;}
public object? HeightInches {get=>Value<object?>("heightInches")!;set=>this["heightInches"]=value;}
public string? ReviewedAt {get=>Value<string?>("reviewedAt")!;set=>this["reviewedAt"]=value;}
public object? WeightPounds {get=>Value<object?>("weightPounds")!;set=>this["weightPounds"]=value;}}

public sealed class PatientCreateParamsExternalIdentitiesItem:SDKParameters{public string Source {get=>Value<string>("source")!;set=>this["source"]=value;}
public string Value {get=>Value<string>("value")!;set=>this["value"]=value;}}

public sealed class PatientCreateParamsAddressesItem:SDKParameters{public string? Id {get=>Value<string?>("id")!;set=>this["id"]=value;}
public PatientCreateParamsAddressesItemAddress Address {get=>Value<PatientCreateParamsAddressesItemAddress>("address")!;set=>this["address"]=value;}
public string Label {get=>Value<string>("label")!;set=>this["label"]=value;}
public bool PreferredShipping {get=>Value<bool>("preferredShipping")!;set=>this["preferredShipping"]=value;}
public string? RecipientName {get=>Value<string?>("recipientName")!;set=>this["recipientName"]=value;}}

public sealed class PatientCreateParamsAddressesItemAddress:SDKParameters{public string City {get=>Value<string>("city")!;set=>this["city"]=value;}
public string? Country {get=>Value<string?>("country")!;set=>this["country"]=value;}
public string Line1 {get=>Value<string>("line1")!;set=>this["line1"]=value;}
public string? Line2 {get=>Value<string?>("line2")!;set=>this["line2"]=value;}
public string PostalCode {get=>Value<string>("postalCode")!;set=>this["postalCode"]=value;}
public string State {get=>Value<string>("state")!;set=>this["state"]=value;}}

public sealed class PatientCreateParamsEncountersItem:SDKParameters{public string? Notes {get=>Value<string?>("notes")!;set=>this["notes"]=value;}
public string OccurredAt {get=>Value<string>("occurredAt")!;set=>this["occurredAt"]=value;}
public string? ProviderName {get=>Value<string?>("providerName")!;set=>this["providerName"]=value;}
public string Type {get=>Value<string>("type")!;set=>this["type"]=value;}}

public sealed class PatientCreateParamsMeasurementsItem:SDKParameters{public object? HeightCentimeters {get=>Value<object?>("heightCentimeters")!;set=>this["heightCentimeters"]=value;}
public string RecordedAt {get=>Value<string>("recordedAt")!;set=>this["recordedAt"]=value;}
public string Source {get=>Value<string>("source")!;set=>this["source"]=value;}
public object? WeightKilograms {get=>Value<object?>("weightKilograms")!;set=>this["weightKilograms"]=value;}}

public sealed class PatientName:SDKParameters{public string First {get=>Value<string>("first")!;set=>this["first"]=value;}
public string Last {get=>Value<string>("last")!;set=>this["last"]=value;}
public string? Middle {get=>Value<string?>("middle")!;set=>this["middle"]=value;}
public string? Preferred {get=>Value<string?>("preferred")!;set=>this["preferred"]=value;}}

public sealed class PatientCreateParamsProgramsItem:SDKParameters{public string? EndedAt {get=>Value<string?>("endedAt")!;set=>this["endedAt"]=value;}
public string Name {get=>Value<string>("name")!;set=>this["name"]=value;}
public string StartedAt {get=>Value<string>("startedAt")!;set=>this["startedAt"]=value;}
public string Status {get=>Value<string>("status")!;set=>this["status"]=value;}}

public sealed class PatientUpdateParams:SDKParameters{public PatientUpdateParamsAddress? Address {get=>Value<PatientUpdateParamsAddress?>("address")!;set=>this["address"]=value;}
public PatientUpdateParamsClinicalProfile? ClinicalProfile {get=>Value<PatientUpdateParamsClinicalProfile?>("clinicalProfile")!;set=>this["clinicalProfile"]=value;}
public string? DateOfBirth {get=>Value<string?>("dateOfBirth")!;set=>this["dateOfBirth"]=value;}
public string? Email {get=>Value<string?>("email")!;set=>this["email"]=value;}
public string? ExternalId {get=>Value<string?>("externalId")!;set=>this["externalId"]=value;}
public List<PatientUpdateParamsExternalIdentitiesItem>? ExternalIdentities {get=>Value<List<PatientUpdateParamsExternalIdentitiesItem>?>("externalIdentities")!;set=>this["externalIdentities"]=value;}
public List<PatientUpdateParamsAddressesItem>? Addresses {get=>Value<List<PatientUpdateParamsAddressesItem>?>("addresses")!;set=>this["addresses"]=value;}
public List<PatientUpdateParamsEncountersItem>? Encounters {get=>Value<List<PatientUpdateParamsEncountersItem>?>("encounters")!;set=>this["encounters"]=value;}
public string? Gender {get=>Value<string?>("gender")!;set=>this["gender"]=value;}
public string? LocationId {get=>Value<string?>("locationId")!;set=>this["locationId"]=value;}
public object? Metadata {get=>Value<object?>("metadata")!;set=>this["metadata"]=value;}
public string? MedicalRecordNumber {get=>Value<string?>("medicalRecordNumber")!;set=>this["medicalRecordNumber"]=value;}
public List<PatientUpdateParamsMeasurementsItem>? Measurements {get=>Value<List<PatientUpdateParamsMeasurementsItem>?>("measurements")!;set=>this["measurements"]=value;}
public PatientUpdateParamsName? Name {get=>Value<PatientUpdateParamsName?>("name")!;set=>this["name"]=value;}
public List<PatientUpdateParamsProgramsItem>? Programs {get=>Value<List<PatientUpdateParamsProgramsItem>?>("programs")!;set=>this["programs"]=value;}
public string? Phone {get=>Value<string?>("phone")!;set=>this["phone"]=value;}
public string? Status {get=>Value<string?>("status")!;set=>this["status"]=value;}}

public sealed class PatientUpdateParamsAddress:SDKParameters{public string City {get=>Value<string>("city")!;set=>this["city"]=value;}
public string Line1 {get=>Value<string>("line1")!;set=>this["line1"]=value;}
public string? Line2 {get=>Value<string?>("line2")!;set=>this["line2"]=value;}
public string PostalCode {get=>Value<string>("postalCode")!;set=>this["postalCode"]=value;}
public string State {get=>Value<string>("state")!;set=>this["state"]=value;}
public string? Country {get=>Value<string?>("country")!;set=>this["country"]=value;}}

public sealed class PatientUpdateParamsClinicalProfile:SDKParameters{public List<string>? CurrentMedications {get=>Value<List<string>?>("currentMedications")!;set=>this["currentMedications"]=value;}
public object? HeightInches {get=>Value<object?>("heightInches")!;set=>this["heightInches"]=value;}
public string? ReviewedAt {get=>Value<string?>("reviewedAt")!;set=>this["reviewedAt"]=value;}
public object? WeightPounds {get=>Value<object?>("weightPounds")!;set=>this["weightPounds"]=value;}}

public sealed class PatientUpdateParamsExternalIdentitiesItem:SDKParameters{public string Source {get=>Value<string>("source")!;set=>this["source"]=value;}
public string Value {get=>Value<string>("value")!;set=>this["value"]=value;}}

public sealed class PatientUpdateParamsAddressesItem:SDKParameters{public string? Id {get=>Value<string?>("id")!;set=>this["id"]=value;}
public PatientUpdateParamsAddressesItemAddress Address {get=>Value<PatientUpdateParamsAddressesItemAddress>("address")!;set=>this["address"]=value;}
public string Label {get=>Value<string>("label")!;set=>this["label"]=value;}
public bool PreferredShipping {get=>Value<bool>("preferredShipping")!;set=>this["preferredShipping"]=value;}
public string? RecipientName {get=>Value<string?>("recipientName")!;set=>this["recipientName"]=value;}}

public sealed class PatientUpdateParamsAddressesItemAddress:SDKParameters{public string City {get=>Value<string>("city")!;set=>this["city"]=value;}
public string? Country {get=>Value<string?>("country")!;set=>this["country"]=value;}
public string Line1 {get=>Value<string>("line1")!;set=>this["line1"]=value;}
public string? Line2 {get=>Value<string?>("line2")!;set=>this["line2"]=value;}
public string PostalCode {get=>Value<string>("postalCode")!;set=>this["postalCode"]=value;}
public string State {get=>Value<string>("state")!;set=>this["state"]=value;}}

public sealed class PatientUpdateParamsEncountersItem:SDKParameters{public string? Notes {get=>Value<string?>("notes")!;set=>this["notes"]=value;}
public string OccurredAt {get=>Value<string>("occurredAt")!;set=>this["occurredAt"]=value;}
public string? ProviderName {get=>Value<string?>("providerName")!;set=>this["providerName"]=value;}
public string Type {get=>Value<string>("type")!;set=>this["type"]=value;}}

public sealed class PatientUpdateParamsMeasurementsItem:SDKParameters{public object? HeightCentimeters {get=>Value<object?>("heightCentimeters")!;set=>this["heightCentimeters"]=value;}
public string RecordedAt {get=>Value<string>("recordedAt")!;set=>this["recordedAt"]=value;}
public string Source {get=>Value<string>("source")!;set=>this["source"]=value;}
public object? WeightKilograms {get=>Value<object?>("weightKilograms")!;set=>this["weightKilograms"]=value;}}

public sealed class PatientUpdateParamsName:SDKParameters{public string? First {get=>Value<string?>("first")!;set=>this["first"]=value;}
public string? Last {get=>Value<string?>("last")!;set=>this["last"]=value;}
public string? Middle {get=>Value<string?>("middle")!;set=>this["middle"]=value;}
public string? Preferred {get=>Value<string?>("preferred")!;set=>this["preferred"]=value;}}

public sealed class PatientUpdateParamsProgramsItem:SDKParameters{public string? EndedAt {get=>Value<string?>("endedAt")!;set=>this["endedAt"]=value;}
public string Name {get=>Value<string>("name")!;set=>this["name"]=value;}
public string StartedAt {get=>Value<string>("startedAt")!;set=>this["startedAt"]=value;}
public string Status {get=>Value<string>("status")!;set=>this["status"]=value;}}

public sealed class PatientAllergyReplaceParams:SDKParameters{public List<PatientAllergyReplaceParamsAllergiesItem> Allergies {get=>Value<List<PatientAllergyReplaceParamsAllergiesItem>>("allergies")!;set=>this["allergies"]=value;}
public string ReviewStatus {get=>Value<string>("reviewStatus")!;set=>this["reviewStatus"]=value;}}

public sealed class PatientAllergyReplaceParamsAllergiesItem:SDKParameters{public string Category {get=>Value<string>("category")!;set=>this["category"]=value;}
public string? Code {get=>Value<string?>("code")!;set=>this["code"]=value;}
public string? CodeSystem {get=>Value<string?>("codeSystem")!;set=>this["codeSystem"]=value;}
public List<PatientAllergyReplaceParamsAllergiesItemReactionsItem> Reactions {get=>Value<List<PatientAllergyReplaceParamsAllergiesItemReactionsItem>>("reactions")!;set=>this["reactions"]=value;}
public string? Severity {get=>Value<string?>("severity")!;set=>this["severity"]=value;}
public string Source {get=>Value<string>("source")!;set=>this["source"]=value;}
public string Substance {get=>Value<string>("substance")!;set=>this["substance"]=value;}
public string? Type {get=>Value<string?>("type")!;set=>this["type"]=value;}
public string VerificationStatus {get=>Value<string>("verificationStatus")!;set=>this["verificationStatus"]=value;}}

public sealed class PatientAllergyReplaceParamsAllergiesItemReactionsItem:SDKParameters{public string? Code {get=>Value<string?>("code")!;set=>this["code"]=value;}
public string? CodeSystem {get=>Value<string?>("codeSystem")!;set=>this["codeSystem"]=value;}
public string Display {get=>Value<string>("display")!;set=>this["display"]=value;}}

public sealed class OrderPrescriptionAddParams:SDKParameters{public Dictionary<string,object>? Metadata {get=>Value<Dictionary<string,object>?>("metadata")!;set=>this["metadata"]=value;}
public string? ExpectedRevision {get=>Value<string?>("expectedRevision")!;set=>this["expectedRevision"]=value;}
public List<OrderPrescriptionAddParamsExpectedVersionsItem>? ExpectedVersions {get=>Value<List<OrderPrescriptionAddParamsExpectedVersionsItem>?>("expectedVersions")!;set=>this["expectedVersions"]=value;}
public OrderPrescriptionAddParamsPrescription Prescription {get=>Value<OrderPrescriptionAddParamsPrescription>("prescription")!;set=>this["prescription"]=value;}}

public sealed class OrderPrescriptionAddParamsExpectedVersionsItem:SDKParameters{public string PrescriptionId {get=>Value<string>("prescriptionId")!;set=>this["prescriptionId"]=value;}
public int Version {get=>Value<int>("version")!;set=>this["version"]=value;}}

public sealed class OrderPrescriptionAddParamsPrescription:SDKParameters{public string? ExternalPrescriptionId {get=>Value<string?>("externalPrescriptionId")!;set=>this["externalPrescriptionId"]=value;}
public OrderPrescriptionAddParamsPrescriptionClinical? Clinical {get=>Value<OrderPrescriptionAddParamsPrescriptionClinical?>("clinical")!;set=>this["clinical"]=value;}
public string? PharmacyId {get=>Value<string?>("pharmacyId")!;set=>this["pharmacyId"]=value;}
public int DaysSupply {get=>Value<int>("daysSupply")!;set=>this["daysSupply"]=value;}
public OrderPrescriptionAddParamsPrescriptionDispensing Dispensing {get=>Value<OrderPrescriptionAddParamsPrescriptionDispensing>("dispensing")!;set=>this["dispensing"]=value;}
public string Directions {get=>Value<string>("directions")!;set=>this["directions"]=value;}
public string MedicationId {get=>Value<string>("medicationId")!;set=>this["medicationId"]=value;}
public object Quantity {get=>Value<object>("quantity")!;set=>this["quantity"]=value;}
public string QuantityUnit {get=>Value<string>("quantityUnit")!;set=>this["quantityUnit"]=value;}
public int Refills {get=>Value<int>("refills")!;set=>this["refills"]=value;}
public OrderPrescriptionAddParamsPrescriptionStructuredSig? StructuredSig {get=>Value<OrderPrescriptionAddParamsPrescriptionStructuredSig?>("structuredSig")!;set=>this["structuredSig"]=value;}}

public sealed class OrderPrescriptionAddParamsPrescriptionClinical:SDKParameters{public OrderPrescriptionAddParamsPrescriptionClinicalCompoundingReason? CompoundingReason {get=>Value<OrderPrescriptionAddParamsPrescriptionClinicalCompoundingReason?>("compoundingReason")!;set=>this["compoundingReason"]=value;}
public string? MedicationReviewStatus {get=>Value<string?>("medicationReviewStatus")!;set=>this["medicationReviewStatus"]=value;}
public string? DiagnosisReviewStatus {get=>Value<string?>("diagnosisReviewStatus")!;set=>this["diagnosisReviewStatus"]=value;}
public List<string>? CurrentMedications {get=>Value<List<string>?>("currentMedications")!;set=>this["currentMedications"]=value;}
public List<OrderPrescriptionAddParamsPrescriptionClinicalDiagnosesItem>? Diagnoses {get=>Value<List<OrderPrescriptionAddParamsPrescriptionClinicalDiagnosesItem>?>("diagnoses")!;set=>this["diagnoses"]=value;}
public List<OrderPrescriptionAddParamsPrescriptionClinicalObservationsItem>? Observations {get=>Value<List<OrderPrescriptionAddParamsPrescriptionClinicalObservationsItem>?>("observations")!;set=>this["observations"]=value;}}

public sealed class OrderPrescriptionAddParamsPrescriptionClinicalCompoundingReason:SDKParameters{public string? Category {get=>Value<string?>("category")!;set=>this["category"]=value;}
public string? Context {get=>Value<string?>("context")!;set=>this["context"]=value;}}

public sealed class OrderPrescriptionAddParamsPrescriptionClinicalDiagnosesItem:SDKParameters{public string Code {get=>Value<string>("code")!;set=>this["code"]=value;}
public string Display {get=>Value<string>("display")!;set=>this["display"]=value;}}

public sealed class OrderPrescriptionAddParamsPrescriptionClinicalObservationsItem:SDKParameters{public string Display {get=>Value<string>("display")!;set=>this["display"]=value;}
public string Unit {get=>Value<string>("unit")!;set=>this["unit"]=value;}
public object Value {get=>Value<object>("value")!;set=>this["value"]=value;}}

public sealed class OrderPrescriptionAddParamsPrescriptionDispensing:SDKParameters{public bool? DispenseUponAcceptance {get=>Value<bool?>("dispenseUponAcceptance")!;set=>this["dispenseUponAcceptance"]=value;}
public string? ShippingOptionId {get=>Value<string?>("shippingOptionId")!;set=>this["shippingOptionId"]=value;}
public int? ShippingAmountCents {get=>Value<int?>("shippingAmountCents")!;set=>this["shippingAmountCents"]=value;}
public string? ShippingDestinationType {get=>Value<string?>("shippingDestinationType")!;set=>this["shippingDestinationType"]=value;}
public string? PharmacyNotes {get=>Value<string?>("pharmacyNotes")!;set=>this["pharmacyNotes"]=value;}
public string? RequestedFillDate {get=>Value<string?>("requestedFillDate")!;set=>this["requestedFillDate"]=value;}
public bool? SubstitutionPermitted {get=>Value<bool?>("substitutionPermitted")!;set=>this["substitutionPermitted"]=value;}}

public sealed class OrderPrescriptionAddParamsPrescriptionStructuredSig:SDKParameters{public string Dose {get=>Value<string>("dose")!;set=>this["dose"]=value;}
public string DoseUnit {get=>Value<string>("doseUnit")!;set=>this["doseUnit"]=value;}
public string? Duration {get=>Value<string?>("duration")!;set=>this["duration"]=value;}
public string Frequency {get=>Value<string>("frequency")!;set=>this["frequency"]=value;}
public string? Indication {get=>Value<string?>("indication")!;set=>this["indication"]=value;}
public string? MaxDailyUse {get=>Value<string?>("maxDailyUse")!;set=>this["maxDailyUse"]=value;}
public bool? Prn {get=>Value<bool?>("prn")!;set=>this["prn"]=value;}
public string Route {get=>Value<string>("route")!;set=>this["route"]=value;}
public string? TitrationSchedule {get=>Value<string?>("titrationSchedule")!;set=>this["titrationSchedule"]=value;}}

public sealed class OrderPrescriptionUpdateParams:SDKParameters{public Dictionary<string,object>? Metadata {get=>Value<Dictionary<string,object>?>("metadata")!;set=>this["metadata"]=value;}
public string? ExpectedRevision {get=>Value<string?>("expectedRevision")!;set=>this["expectedRevision"]=value;}
public List<OrderPrescriptionUpdateParamsExpectedVersionsItem>? ExpectedVersions {get=>Value<List<OrderPrescriptionUpdateParamsExpectedVersionsItem>?>("expectedVersions")!;set=>this["expectedVersions"]=value;}
public OrderPrescriptionUpdateParamsPrescription Prescription {get=>Value<OrderPrescriptionUpdateParamsPrescription>("prescription")!;set=>this["prescription"]=value;}}

public sealed class OrderPrescriptionUpdateParamsExpectedVersionsItem:SDKParameters{public string PrescriptionId {get=>Value<string>("prescriptionId")!;set=>this["prescriptionId"]=value;}
public int Version {get=>Value<int>("version")!;set=>this["version"]=value;}}

public sealed class OrderPrescriptionUpdateParamsPrescription:SDKParameters{public OrderPrescriptionUpdateParamsPrescriptionClinical? Clinical {get=>Value<OrderPrescriptionUpdateParamsPrescriptionClinical?>("clinical")!;set=>this["clinical"]=value;}
public string? PharmacyId {get=>Value<string?>("pharmacyId")!;set=>this["pharmacyId"]=value;}
public int DaysSupply {get=>Value<int>("daysSupply")!;set=>this["daysSupply"]=value;}
public OrderPrescriptionUpdateParamsPrescriptionDispensing Dispensing {get=>Value<OrderPrescriptionUpdateParamsPrescriptionDispensing>("dispensing")!;set=>this["dispensing"]=value;}
public string Directions {get=>Value<string>("directions")!;set=>this["directions"]=value;}
public string MedicationId {get=>Value<string>("medicationId")!;set=>this["medicationId"]=value;}
public object Quantity {get=>Value<object>("quantity")!;set=>this["quantity"]=value;}
public string QuantityUnit {get=>Value<string>("quantityUnit")!;set=>this["quantityUnit"]=value;}
public int Refills {get=>Value<int>("refills")!;set=>this["refills"]=value;}
public OrderPrescriptionUpdateParamsPrescriptionStructuredSig? StructuredSig {get=>Value<OrderPrescriptionUpdateParamsPrescriptionStructuredSig?>("structuredSig")!;set=>this["structuredSig"]=value;}}

public sealed class OrderPrescriptionUpdateParamsPrescriptionClinical:SDKParameters{public OrderPrescriptionUpdateParamsPrescriptionClinicalCompoundingReason? CompoundingReason {get=>Value<OrderPrescriptionUpdateParamsPrescriptionClinicalCompoundingReason?>("compoundingReason")!;set=>this["compoundingReason"]=value;}
public string? MedicationReviewStatus {get=>Value<string?>("medicationReviewStatus")!;set=>this["medicationReviewStatus"]=value;}
public string? DiagnosisReviewStatus {get=>Value<string?>("diagnosisReviewStatus")!;set=>this["diagnosisReviewStatus"]=value;}
public List<string>? CurrentMedications {get=>Value<List<string>?>("currentMedications")!;set=>this["currentMedications"]=value;}
public List<OrderPrescriptionUpdateParamsPrescriptionClinicalDiagnosesItem>? Diagnoses {get=>Value<List<OrderPrescriptionUpdateParamsPrescriptionClinicalDiagnosesItem>?>("diagnoses")!;set=>this["diagnoses"]=value;}
public List<OrderPrescriptionUpdateParamsPrescriptionClinicalObservationsItem>? Observations {get=>Value<List<OrderPrescriptionUpdateParamsPrescriptionClinicalObservationsItem>?>("observations")!;set=>this["observations"]=value;}}

public sealed class OrderPrescriptionUpdateParamsPrescriptionClinicalCompoundingReason:SDKParameters{public string? Category {get=>Value<string?>("category")!;set=>this["category"]=value;}
public string? Context {get=>Value<string?>("context")!;set=>this["context"]=value;}}

public sealed class OrderPrescriptionUpdateParamsPrescriptionClinicalDiagnosesItem:SDKParameters{public string Code {get=>Value<string>("code")!;set=>this["code"]=value;}
public string Display {get=>Value<string>("display")!;set=>this["display"]=value;}}

public sealed class OrderPrescriptionUpdateParamsPrescriptionClinicalObservationsItem:SDKParameters{public string Display {get=>Value<string>("display")!;set=>this["display"]=value;}
public string Unit {get=>Value<string>("unit")!;set=>this["unit"]=value;}
public object Value {get=>Value<object>("value")!;set=>this["value"]=value;}}

public sealed class OrderPrescriptionUpdateParamsPrescriptionDispensing:SDKParameters{public bool? DispenseUponAcceptance {get=>Value<bool?>("dispenseUponAcceptance")!;set=>this["dispenseUponAcceptance"]=value;}
public string? ShippingOptionId {get=>Value<string?>("shippingOptionId")!;set=>this["shippingOptionId"]=value;}
public int? ShippingAmountCents {get=>Value<int?>("shippingAmountCents")!;set=>this["shippingAmountCents"]=value;}
public string? ShippingDestinationType {get=>Value<string?>("shippingDestinationType")!;set=>this["shippingDestinationType"]=value;}
public string? PharmacyNotes {get=>Value<string?>("pharmacyNotes")!;set=>this["pharmacyNotes"]=value;}
public string? RequestedFillDate {get=>Value<string?>("requestedFillDate")!;set=>this["requestedFillDate"]=value;}
public bool? SubstitutionPermitted {get=>Value<bool?>("substitutionPermitted")!;set=>this["substitutionPermitted"]=value;}}

public sealed class OrderPrescriptionUpdateParamsPrescriptionStructuredSig:SDKParameters{public string Dose {get=>Value<string>("dose")!;set=>this["dose"]=value;}
public string DoseUnit {get=>Value<string>("doseUnit")!;set=>this["doseUnit"]=value;}
public string? Duration {get=>Value<string?>("duration")!;set=>this["duration"]=value;}
public string Frequency {get=>Value<string>("frequency")!;set=>this["frequency"]=value;}
public string? Indication {get=>Value<string?>("indication")!;set=>this["indication"]=value;}
public string? MaxDailyUse {get=>Value<string?>("maxDailyUse")!;set=>this["maxDailyUse"]=value;}
public bool? Prn {get=>Value<bool?>("prn")!;set=>this["prn"]=value;}
public string Route {get=>Value<string>("route")!;set=>this["route"]=value;}
public string? TitrationSchedule {get=>Value<string?>("titrationSchedule")!;set=>this["titrationSchedule"]=value;}}

public sealed class OrderBatchCreateParams:SDKParameters{public string? UserId {get=>Value<string?>("userId")!;set=>this["userId"]=value;}
public PrescriberSelector? Prescriber {get=>Value<PrescriberSelector?>("prescriber")!;set=>this["prescriber"]=value;}
public List<OrderBatchCreateParamsOrdersItem> Orders {get=>Value<List<OrderBatchCreateParamsOrdersItem>>("orders")!;set=>this["orders"]=value;}}

public sealed class OrderBatchCreateParamsOrdersItem:SDKParameters{public List<OrderBatchCreateParamsOrdersItemOtcItemsItem>? OtcItems {get=>Value<List<OrderBatchCreateParamsOrdersItemOtcItemsItem>?>("otcItems")!;set=>this["otcItems"]=value;}
public string? ExternalOrderId {get=>Value<string?>("externalOrderId")!;set=>this["externalOrderId"]=value;}
public Dictionary<string,object>? Metadata {get=>Value<Dictionary<string,object>?>("metadata")!;set=>this["metadata"]=value;}
public string? PatientId {get=>Value<string?>("patientId")!;set=>this["patientId"]=value;}
public OrderBatchCreateParamsOrdersItemPatient? Patient {get=>Value<OrderBatchCreateParamsOrdersItemPatient?>("patient")!;set=>this["patient"]=value;}
public string? ShippingAddressId {get=>Value<string?>("shippingAddressId")!;set=>this["shippingAddressId"]=value;}
public List<OrderBatchCreateParamsOrdersItemPrescriptionsItem> Prescriptions {get=>Value<List<OrderBatchCreateParamsOrdersItemPrescriptionsItem>>("prescriptions")!;set=>this["prescriptions"]=value;}}

public sealed class OrderBatchCreateParamsOrdersItemOtcItemsItem:SDKParameters{public string CatalogItemId {get=>Value<string>("catalogItemId")!;set=>this["catalogItemId"]=value;}
public int Quantity {get=>Value<int>("quantity")!;set=>this["quantity"]=value;}}

public sealed class OrderBatchCreateParamsOrdersItemPatient:SDKParameters{public OrderBatchCreateParamsOrdersItemPatientAddress? Address {get=>Value<OrderBatchCreateParamsOrdersItemPatientAddress?>("address")!;set=>this["address"]=value;}
public OrderBatchCreateParamsOrdersItemPatientClinicalProfile? ClinicalProfile {get=>Value<OrderBatchCreateParamsOrdersItemPatientClinicalProfile?>("clinicalProfile")!;set=>this["clinicalProfile"]=value;}
public string DateOfBirth {get=>Value<string>("dateOfBirth")!;set=>this["dateOfBirth"]=value;}
public string? Email {get=>Value<string?>("email")!;set=>this["email"]=value;}
public string? ExternalId {get=>Value<string?>("externalId")!;set=>this["externalId"]=value;}
public List<OrderBatchCreateParamsOrdersItemPatientExternalIdentitiesItem>? ExternalIdentities {get=>Value<List<OrderBatchCreateParamsOrdersItemPatientExternalIdentitiesItem>?>("externalIdentities")!;set=>this["externalIdentities"]=value;}
public List<OrderBatchCreateParamsOrdersItemPatientAddressesItem>? Addresses {get=>Value<List<OrderBatchCreateParamsOrdersItemPatientAddressesItem>?>("addresses")!;set=>this["addresses"]=value;}
public List<OrderBatchCreateParamsOrdersItemPatientEncountersItem>? Encounters {get=>Value<List<OrderBatchCreateParamsOrdersItemPatientEncountersItem>?>("encounters")!;set=>this["encounters"]=value;}
public string? Gender {get=>Value<string?>("gender")!;set=>this["gender"]=value;}
public string? LocationId {get=>Value<string?>("locationId")!;set=>this["locationId"]=value;}
public object? Metadata {get=>Value<object?>("metadata")!;set=>this["metadata"]=value;}
public string? MedicalRecordNumber {get=>Value<string?>("medicalRecordNumber")!;set=>this["medicalRecordNumber"]=value;}
public List<OrderBatchCreateParamsOrdersItemPatientMeasurementsItem>? Measurements {get=>Value<List<OrderBatchCreateParamsOrdersItemPatientMeasurementsItem>?>("measurements")!;set=>this["measurements"]=value;}
public OrderBatchCreateParamsOrdersItemPatientName Name {get=>Value<OrderBatchCreateParamsOrdersItemPatientName>("name")!;set=>this["name"]=value;}
public string? Phone {get=>Value<string?>("phone")!;set=>this["phone"]=value;}
public List<OrderBatchCreateParamsOrdersItemPatientProgramsItem>? Programs {get=>Value<List<OrderBatchCreateParamsOrdersItemPatientProgramsItem>?>("programs")!;set=>this["programs"]=value;}}

public sealed class OrderBatchCreateParamsOrdersItemPatientAddress:SDKParameters{public string City {get=>Value<string>("city")!;set=>this["city"]=value;}
public string Line1 {get=>Value<string>("line1")!;set=>this["line1"]=value;}
public string? Line2 {get=>Value<string?>("line2")!;set=>this["line2"]=value;}
public string PostalCode {get=>Value<string>("postalCode")!;set=>this["postalCode"]=value;}
public string State {get=>Value<string>("state")!;set=>this["state"]=value;}
public string? Country {get=>Value<string?>("country")!;set=>this["country"]=value;}}

public sealed class OrderBatchCreateParamsOrdersItemPatientClinicalProfile:SDKParameters{public List<string> CurrentMedications {get=>Value<List<string>>("currentMedications")!;set=>this["currentMedications"]=value;}
public object? HeightInches {get=>Value<object?>("heightInches")!;set=>this["heightInches"]=value;}
public string? ReviewedAt {get=>Value<string?>("reviewedAt")!;set=>this["reviewedAt"]=value;}
public object? WeightPounds {get=>Value<object?>("weightPounds")!;set=>this["weightPounds"]=value;}}

public sealed class OrderBatchCreateParamsOrdersItemPatientExternalIdentitiesItem:SDKParameters{public string Source {get=>Value<string>("source")!;set=>this["source"]=value;}
public string Value {get=>Value<string>("value")!;set=>this["value"]=value;}}

public sealed class OrderBatchCreateParamsOrdersItemPatientAddressesItem:SDKParameters{public string? Id {get=>Value<string?>("id")!;set=>this["id"]=value;}
public OrderBatchCreateParamsOrdersItemPatientAddressesItemAddress Address {get=>Value<OrderBatchCreateParamsOrdersItemPatientAddressesItemAddress>("address")!;set=>this["address"]=value;}
public string Label {get=>Value<string>("label")!;set=>this["label"]=value;}
public bool PreferredShipping {get=>Value<bool>("preferredShipping")!;set=>this["preferredShipping"]=value;}
public string? RecipientName {get=>Value<string?>("recipientName")!;set=>this["recipientName"]=value;}}

public sealed class OrderBatchCreateParamsOrdersItemPatientAddressesItemAddress:SDKParameters{public string City {get=>Value<string>("city")!;set=>this["city"]=value;}
public string? Country {get=>Value<string?>("country")!;set=>this["country"]=value;}
public string Line1 {get=>Value<string>("line1")!;set=>this["line1"]=value;}
public string? Line2 {get=>Value<string?>("line2")!;set=>this["line2"]=value;}
public string PostalCode {get=>Value<string>("postalCode")!;set=>this["postalCode"]=value;}
public string State {get=>Value<string>("state")!;set=>this["state"]=value;}}

public sealed class OrderBatchCreateParamsOrdersItemPatientEncountersItem:SDKParameters{public string? Notes {get=>Value<string?>("notes")!;set=>this["notes"]=value;}
public string OccurredAt {get=>Value<string>("occurredAt")!;set=>this["occurredAt"]=value;}
public string? ProviderName {get=>Value<string?>("providerName")!;set=>this["providerName"]=value;}
public string Type {get=>Value<string>("type")!;set=>this["type"]=value;}}

public sealed class OrderBatchCreateParamsOrdersItemPatientMeasurementsItem:SDKParameters{public object? HeightCentimeters {get=>Value<object?>("heightCentimeters")!;set=>this["heightCentimeters"]=value;}
public string RecordedAt {get=>Value<string>("recordedAt")!;set=>this["recordedAt"]=value;}
public string Source {get=>Value<string>("source")!;set=>this["source"]=value;}
public object? WeightKilograms {get=>Value<object?>("weightKilograms")!;set=>this["weightKilograms"]=value;}}

public sealed class OrderBatchCreateParamsOrdersItemPatientName:SDKParameters{public string First {get=>Value<string>("first")!;set=>this["first"]=value;}
public string Last {get=>Value<string>("last")!;set=>this["last"]=value;}
public string? Middle {get=>Value<string?>("middle")!;set=>this["middle"]=value;}
public string? Preferred {get=>Value<string?>("preferred")!;set=>this["preferred"]=value;}}

public sealed class OrderBatchCreateParamsOrdersItemPatientProgramsItem:SDKParameters{public string? EndedAt {get=>Value<string?>("endedAt")!;set=>this["endedAt"]=value;}
public string Name {get=>Value<string>("name")!;set=>this["name"]=value;}
public string StartedAt {get=>Value<string>("startedAt")!;set=>this["startedAt"]=value;}
public string Status {get=>Value<string>("status")!;set=>this["status"]=value;}}

public sealed class OrderBatchCreateParamsOrdersItemPrescriptionsItem:SDKParameters{public string? ExternalPrescriptionId {get=>Value<string?>("externalPrescriptionId")!;set=>this["externalPrescriptionId"]=value;}
public OrderBatchCreateParamsOrdersItemPrescriptionsItemClinical? Clinical {get=>Value<OrderBatchCreateParamsOrdersItemPrescriptionsItemClinical?>("clinical")!;set=>this["clinical"]=value;}
public string? PharmacyId {get=>Value<string?>("pharmacyId")!;set=>this["pharmacyId"]=value;}
public int DaysSupply {get=>Value<int>("daysSupply")!;set=>this["daysSupply"]=value;}
public OrderBatchCreateParamsOrdersItemPrescriptionsItemDispensing Dispensing {get=>Value<OrderBatchCreateParamsOrdersItemPrescriptionsItemDispensing>("dispensing")!;set=>this["dispensing"]=value;}
public string Directions {get=>Value<string>("directions")!;set=>this["directions"]=value;}
public string MedicationId {get=>Value<string>("medicationId")!;set=>this["medicationId"]=value;}
public object Quantity {get=>Value<object>("quantity")!;set=>this["quantity"]=value;}
public string QuantityUnit {get=>Value<string>("quantityUnit")!;set=>this["quantityUnit"]=value;}
public int Refills {get=>Value<int>("refills")!;set=>this["refills"]=value;}
public OrderBatchCreateParamsOrdersItemPrescriptionsItemStructuredSig? StructuredSig {get=>Value<OrderBatchCreateParamsOrdersItemPrescriptionsItemStructuredSig?>("structuredSig")!;set=>this["structuredSig"]=value;}}

public sealed class OrderBatchCreateParamsOrdersItemPrescriptionsItemClinical:SDKParameters{public OrderBatchCreateParamsOrdersItemPrescriptionsItemClinicalCompoundingReason? CompoundingReason {get=>Value<OrderBatchCreateParamsOrdersItemPrescriptionsItemClinicalCompoundingReason?>("compoundingReason")!;set=>this["compoundingReason"]=value;}
public string? MedicationReviewStatus {get=>Value<string?>("medicationReviewStatus")!;set=>this["medicationReviewStatus"]=value;}
public string? DiagnosisReviewStatus {get=>Value<string?>("diagnosisReviewStatus")!;set=>this["diagnosisReviewStatus"]=value;}
public List<string>? CurrentMedications {get=>Value<List<string>?>("currentMedications")!;set=>this["currentMedications"]=value;}
public List<OrderBatchCreateParamsOrdersItemPrescriptionsItemClinicalDiagnosesItem>? Diagnoses {get=>Value<List<OrderBatchCreateParamsOrdersItemPrescriptionsItemClinicalDiagnosesItem>?>("diagnoses")!;set=>this["diagnoses"]=value;}
public List<OrderBatchCreateParamsOrdersItemPrescriptionsItemClinicalObservationsItem>? Observations {get=>Value<List<OrderBatchCreateParamsOrdersItemPrescriptionsItemClinicalObservationsItem>?>("observations")!;set=>this["observations"]=value;}}

public sealed class OrderBatchCreateParamsOrdersItemPrescriptionsItemClinicalCompoundingReason:SDKParameters{public string? Category {get=>Value<string?>("category")!;set=>this["category"]=value;}
public string? Context {get=>Value<string?>("context")!;set=>this["context"]=value;}}

public sealed class OrderBatchCreateParamsOrdersItemPrescriptionsItemClinicalDiagnosesItem:SDKParameters{public string Code {get=>Value<string>("code")!;set=>this["code"]=value;}
public string Display {get=>Value<string>("display")!;set=>this["display"]=value;}}

public sealed class OrderBatchCreateParamsOrdersItemPrescriptionsItemClinicalObservationsItem:SDKParameters{public string Display {get=>Value<string>("display")!;set=>this["display"]=value;}
public string Unit {get=>Value<string>("unit")!;set=>this["unit"]=value;}
public object Value {get=>Value<object>("value")!;set=>this["value"]=value;}}

public sealed class OrderBatchCreateParamsOrdersItemPrescriptionsItemDispensing:SDKParameters{public bool? DispenseUponAcceptance {get=>Value<bool?>("dispenseUponAcceptance")!;set=>this["dispenseUponAcceptance"]=value;}
public string? ShippingOptionId {get=>Value<string?>("shippingOptionId")!;set=>this["shippingOptionId"]=value;}
public int? ShippingAmountCents {get=>Value<int?>("shippingAmountCents")!;set=>this["shippingAmountCents"]=value;}
public string? ShippingDestinationType {get=>Value<string?>("shippingDestinationType")!;set=>this["shippingDestinationType"]=value;}
public string? PharmacyNotes {get=>Value<string?>("pharmacyNotes")!;set=>this["pharmacyNotes"]=value;}
public string? RequestedFillDate {get=>Value<string?>("requestedFillDate")!;set=>this["requestedFillDate"]=value;}
public bool? SubstitutionPermitted {get=>Value<bool?>("substitutionPermitted")!;set=>this["substitutionPermitted"]=value;}}

public sealed class OrderBatchCreateParamsOrdersItemPrescriptionsItemStructuredSig:SDKParameters{public string Dose {get=>Value<string>("dose")!;set=>this["dose"]=value;}
public string DoseUnit {get=>Value<string>("doseUnit")!;set=>this["doseUnit"]=value;}
public string? Duration {get=>Value<string?>("duration")!;set=>this["duration"]=value;}
public string Frequency {get=>Value<string>("frequency")!;set=>this["frequency"]=value;}
public string? Indication {get=>Value<string?>("indication")!;set=>this["indication"]=value;}
public string? MaxDailyUse {get=>Value<string?>("maxDailyUse")!;set=>this["maxDailyUse"]=value;}
public bool? Prn {get=>Value<bool?>("prn")!;set=>this["prn"]=value;}
public string Route {get=>Value<string>("route")!;set=>this["route"]=value;}
public string? TitrationSchedule {get=>Value<string?>("titrationSchedule")!;set=>this["titrationSchedule"]=value;}}

public sealed class SellingPriceUpdateParams:SDKParameters{public int? AmountCents {get=>Value<int?>("amountCents")!;set=>this["amountCents"]=value;}
public int BaseVersion {get=>Value<int>("baseVersion")!;set=>this["baseVersion"]=value;}}

public sealed class WebhookGrantListParams:SDKParameters{public int? Limit {get=>Value<int?>("limit")!;set=>this["limit"]=value;}
public string? StartingAfter {get=>Value<string?>("startingAfter")!;set=>this["startingAfter"]=value;}
public string? EndingBefore {get=>Value<string?>("endingBefore")!;set=>this["endingBefore"]=value;}}

public sealed class WebhookGrantSaveParams:SDKParameters{public List<string> Scopes {get=>Value<List<string>>("scopes")!;set=>this["scopes"]=value;}}
internal static class SDKOperations{internal static readonly Dictionary<string,SDKOperation> All=JsonSerializer.Deserialize<Dictionary<string,SDKOperation>>("{\"listPracticeLocations\":{\"id\":\"listPracticeLocations\",\"group\":\"locations\",\"method\":\"list\",\"verb\":\"GET\",\"path\":\"/v1/practices/{practiceId}/locations\",\"ids\":[],\"paramsName\":\"LocationListParams\",\"hasParams\":true,\"paramsRequired\":false,\"response\":\"ListPracticeLocationsResponse\",\"paginated\":true,\"query\":[\"limit\",\"startingAfter\",\"endingBefore\",\"status\"],\"headers\":{},\"body\":false,\"practice\":\"path\",\"rootOnly\":false,\"idempotency\":\"none\"},\"createPracticeLocation\":{\"id\":\"createPracticeLocation\",\"group\":\"locations\",\"method\":\"create\",\"verb\":\"POST\",\"path\":\"/v1/practices/{practiceId}/locations\",\"ids\":[],\"paramsName\":\"LocationCreateParams\",\"hasParams\":true,\"paramsRequired\":true,\"response\":\"CreatePracticeLocationResponse\",\"paginated\":false,\"query\":[],\"headers\":{},\"body\":true,\"practice\":\"path\",\"rootOnly\":false,\"idempotency\":\"auto\"},\"getPracticeLocation\":{\"id\":\"getPracticeLocation\",\"group\":\"locations\",\"method\":\"get\",\"verb\":\"GET\",\"path\":\"/v1/practices/{practiceId}/locations/{locationId}\",\"ids\":[\"locationId\"],\"paramsName\":\"LocationGetParams\",\"hasParams\":false,\"paramsRequired\":false,\"response\":\"GetPracticeLocationResponse\",\"paginated\":false,\"query\":[],\"headers\":{},\"body\":false,\"practice\":\"path\",\"rootOnly\":false,\"idempotency\":\"none\"},\"updatePracticeLocation\":{\"id\":\"updatePracticeLocation\",\"group\":\"locations\",\"method\":\"update\",\"verb\":\"PATCH\",\"path\":\"/v1/practices/{practiceId}/locations/{locationId}\",\"ids\":[\"locationId\"],\"paramsName\":\"LocationUpdateParams\",\"hasParams\":true,\"paramsRequired\":false,\"response\":\"UpdatePracticeLocationResponse\",\"paginated\":false,\"query\":[],\"headers\":{},\"body\":true,\"practice\":\"path\",\"rootOnly\":false,\"idempotency\":\"auto\"},\"archivePracticeLocation\":{\"id\":\"archivePracticeLocation\",\"group\":\"locations\",\"method\":\"archive\",\"verb\":\"POST\",\"path\":\"/v1/practices/{practiceId}/locations/{locationId}/archive\",\"ids\":[\"locationId\"],\"paramsName\":\"LocationArchiveParams\",\"hasParams\":false,\"paramsRequired\":false,\"response\":\"ArchivePracticeLocationResponse\",\"paginated\":false,\"query\":[],\"headers\":{},\"body\":false,\"practice\":\"path\",\"rootOnly\":false,\"idempotency\":\"auto\"},\"createPlatformPracticeApiKey\":{\"id\":\"createPlatformPracticeApiKey\",\"group\":\"apiKeys\",\"method\":\"create\",\"verb\":\"POST\",\"path\":\"/v1/practices/{practiceId}/api-keys\",\"ids\":[],\"paramsName\":\"ApiKeyCreateParams\",\"hasParams\":true,\"paramsRequired\":true,\"response\":\"CreatePlatformPracticeApiKeyResponse\",\"paginated\":false,\"query\":[],\"headers\":{},\"body\":true,\"practice\":\"path\",\"rootOnly\":false,\"idempotency\":\"required\"},\"getAccount\":{\"id\":\"getAccount\",\"group\":\"account\",\"method\":\"get\",\"verb\":\"GET\",\"path\":\"/v1/account\",\"ids\":[],\"paramsName\":\"AccountGetParams\",\"hasParams\":true,\"paramsRequired\":false,\"response\":\"GetAccountResponse\",\"paginated\":false,\"query\":[\"orgId\"],\"headers\":{},\"body\":false,\"practice\":\"none\",\"rootOnly\":true,\"idempotency\":\"none\"},\"listCatalogItems\":{\"id\":\"listCatalogItems\",\"group\":\"catalog.items\",\"method\":\"list\",\"verb\":\"GET\",\"path\":\"/v1/catalog/items\",\"ids\":[],\"paramsName\":\"CatalogItemListParams\",\"hasParams\":true,\"paramsRequired\":false,\"response\":\"ListCatalogItemsResponse\",\"paginated\":true,\"query\":[\"view\",\"relatedToCatalogItemId\",\"catalogKind\",\"sort\",\"catalogItemId\",\"availability\",\"pharmacyIds\",\"dosageForms\",\"endingBefore\",\"hideControlledSubstances\",\"hideUnpriced\",\"limit\",\"orgId\",\"practiceId\",\"query\",\"requirement\",\"routes\",\"startingAfter\"],\"headers\":{},\"body\":false,\"practice\":\"query\",\"rootOnly\":false,\"idempotency\":\"none\"},\"listPharmacies\":{\"id\":\"listPharmacies\",\"group\":\"pharmacies\",\"method\":\"list\",\"verb\":\"GET\",\"path\":\"/v1/pharmacies\",\"ids\":[],\"paramsName\":\"PharmacyListParams\",\"hasParams\":true,\"paramsRequired\":false,\"response\":\"ListPharmaciesResponse\",\"paginated\":true,\"query\":[\"endingBefore\",\"limit\",\"orgId\",\"pharmacyId\",\"query\",\"shipsToState\",\"startingAfter\"],\"headers\":{},\"body\":false,\"practice\":\"none\",\"rootOnly\":false,\"idempotency\":\"none\"},\"listShippingOptions\":{\"id\":\"listShippingOptions\",\"group\":\"catalog.shippingOptions\",\"method\":\"list\",\"verb\":\"GET\",\"path\":\"/v1/catalog/items/{catalogItemId}/shipping-options\",\"ids\":[\"catalogItemId\"],\"paramsName\":\"ShippingOptionListParams\",\"hasParams\":true,\"paramsRequired\":true,\"response\":\"ListShippingOptionsResponse\",\"paginated\":false,\"query\":[\"destinationState\",\"destinationType\"],\"headers\":{},\"body\":false,\"practice\":\"none\",\"rootOnly\":false,\"idempotency\":\"none\"},\"listOrders\":{\"id\":\"listOrders\",\"group\":\"orders\",\"method\":\"list\",\"verb\":\"GET\",\"path\":\"/v1/orders\",\"ids\":[],\"paramsName\":\"OrderListParams\",\"hasParams\":true,\"paramsRequired\":false,\"response\":\"ListOrdersResponse\",\"paginated\":true,\"query\":[\"query\",\"externalOrderId\",\"createdAfter\",\"createdBefore\",\"endingBefore\",\"limit\",\"orderId\",\"patientId\",\"patientExternalId\",\"practiceId\",\"sort\",\"startingAfter\",\"status\"],\"headers\":{\"actorId\":\"Affinity-Actor-Id\",\"actorType\":\"Affinity-Actor-Type\"},\"body\":false,\"practice\":\"query\",\"rootOnly\":false,\"idempotency\":\"none\"},\"createOrder\":{\"id\":\"createOrder\",\"group\":\"orders\",\"method\":\"create\",\"verb\":\"POST\",\"path\":\"/v1/orders\",\"ids\":[],\"paramsName\":\"OrderCreateParams\",\"hasParams\":true,\"paramsRequired\":true,\"response\":\"CreateOrderResponse\",\"paginated\":false,\"query\":[],\"headers\":{\"actorId\":\"Affinity-Actor-Id\",\"actorType\":\"Affinity-Actor-Type\"},\"body\":true,\"practice\":\"body\",\"rootOnly\":false,\"idempotency\":\"required\"},\"getOrder\":{\"id\":\"getOrder\",\"group\":\"orders\",\"method\":\"get\",\"verb\":\"GET\",\"path\":\"/v1/orders/{orderId}\",\"ids\":[\"orderId\"],\"paramsName\":\"OrderGetParams\",\"hasParams\":false,\"paramsRequired\":false,\"response\":\"GetOrderResponse\",\"paginated\":false,\"query\":[],\"headers\":{\"actorId\":\"Affinity-Actor-Id\",\"actorType\":\"Affinity-Actor-Type\"},\"body\":false,\"practice\":\"order\",\"rootOnly\":false,\"idempotency\":\"none\"},\"cancelOrder\":{\"id\":\"cancelOrder\",\"group\":\"orders\",\"method\":\"cancel\",\"verb\":\"POST\",\"path\":\"/v1/orders/{orderId}/cancel\",\"ids\":[\"orderId\"],\"paramsName\":\"OrderCancelParams\",\"hasParams\":true,\"paramsRequired\":true,\"response\":\"CancelOrderResponse\",\"paginated\":false,\"query\":[],\"headers\":{\"actorId\":\"Affinity-Actor-Id\",\"actorType\":\"Affinity-Actor-Type\"},\"body\":true,\"practice\":\"order\",\"rootOnly\":false,\"idempotency\":\"required\"},\"actOnOrderException\":{\"id\":\"actOnOrderException\",\"group\":\"orders.exceptions\",\"method\":\"act\",\"verb\":\"POST\",\"path\":\"/v1/orders/{orderId}/exceptions/{exceptionId}/actions\",\"ids\":[\"orderId\",\"exceptionId\"],\"paramsName\":\"OrderExceptionActParams\",\"hasParams\":true,\"paramsRequired\":true,\"response\":\"ActOnOrderExceptionResponse\",\"paginated\":false,\"query\":[],\"headers\":{\"actorId\":\"Affinity-Actor-Id\",\"actorType\":\"Affinity-Actor-Type\"},\"body\":true,\"practice\":\"order\",\"rootOnly\":false,\"idempotency\":\"required\"},\"listOrderEvents\":{\"id\":\"listOrderEvents\",\"group\":\"orders.events\",\"method\":\"list\",\"verb\":\"GET\",\"path\":\"/v1/orders/{orderId}/events\",\"ids\":[\"orderId\"],\"paramsName\":\"OrderEventListParams\",\"hasParams\":true,\"paramsRequired\":false,\"response\":\"ListOrderEventsResponse\",\"paginated\":true,\"query\":[\"endingBefore\",\"limit\",\"startingAfter\"],\"headers\":{\"actorId\":\"Affinity-Actor-Id\",\"actorType\":\"Affinity-Actor-Type\"},\"body\":false,\"practice\":\"order\",\"rootOnly\":false,\"idempotency\":\"none\"},\"listWebhookEndpoints\":{\"id\":\"listWebhookEndpoints\",\"group\":\"webhooks.endpoints\",\"method\":\"list\",\"verb\":\"GET\",\"path\":\"/v1/webhook-endpoints\",\"ids\":[],\"paramsName\":\"WebhookEndpointListParams\",\"hasParams\":true,\"paramsRequired\":false,\"response\":\"ListWebhookEndpointsResponse\",\"paginated\":true,\"query\":[\"endingBefore\",\"limit\",\"startingAfter\"],\"headers\":{\"organizationId\":\"X-Affinity-Organization-Id\"},\"body\":false,\"practice\":\"none\",\"rootOnly\":true,\"idempotency\":\"none\"},\"createWebhookEndpoint\":{\"id\":\"createWebhookEndpoint\",\"group\":\"webhooks.endpoints\",\"method\":\"create\",\"verb\":\"POST\",\"path\":\"/v1/webhook-endpoints\",\"ids\":[],\"paramsName\":\"WebhookEndpointCreateParams\",\"hasParams\":true,\"paramsRequired\":true,\"response\":\"CreateWebhookEndpointResponse\",\"paginated\":false,\"query\":[],\"headers\":{\"organizationId\":\"X-Affinity-Organization-Id\"},\"body\":true,\"practice\":\"none\",\"rootOnly\":true,\"idempotency\":\"required\"},\"updateWebhookEndpoint\":{\"id\":\"updateWebhookEndpoint\",\"group\":\"webhooks.endpoints\",\"method\":\"update\",\"verb\":\"PATCH\",\"path\":\"/v1/webhook-endpoints/{endpointId}\",\"ids\":[\"endpointId\"],\"paramsName\":\"WebhookEndpointUpdateParams\",\"hasParams\":true,\"paramsRequired\":false,\"response\":\"UpdateWebhookEndpointResponse\",\"paginated\":false,\"query\":[],\"headers\":{\"organizationId\":\"X-Affinity-Organization-Id\"},\"body\":true,\"practice\":\"none\",\"rootOnly\":true,\"idempotency\":\"required\"},\"deleteWebhookEndpoint\":{\"id\":\"deleteWebhookEndpoint\",\"group\":\"webhooks.endpoints\",\"method\":\"delete\",\"verb\":\"DELETE\",\"path\":\"/v1/webhook-endpoints/{endpointId}\",\"ids\":[\"endpointId\"],\"paramsName\":\"WebhookEndpointDeleteParams\",\"hasParams\":false,\"paramsRequired\":false,\"response\":\"DeleteWebhookEndpointResponse\",\"paginated\":false,\"query\":[],\"headers\":{\"organizationId\":\"X-Affinity-Organization-Id\"},\"body\":false,\"practice\":\"none\",\"rootOnly\":true,\"idempotency\":\"required\"},\"rotateWebhookEndpointSecret\":{\"id\":\"rotateWebhookEndpointSecret\",\"group\":\"webhooks.endpoints\",\"method\":\"rotateSecret\",\"verb\":\"POST\",\"path\":\"/v1/webhook-endpoints/{endpointId}/rotate-secret\",\"ids\":[\"endpointId\"],\"paramsName\":\"WebhookEndpointRotateSecretParams\",\"hasParams\":false,\"paramsRequired\":false,\"response\":\"RotateWebhookEndpointSecretResponse\",\"paginated\":false,\"query\":[],\"headers\":{\"organizationId\":\"X-Affinity-Organization-Id\"},\"body\":false,\"practice\":\"none\",\"rootOnly\":true,\"idempotency\":\"required\"},\"testWebhookEndpoint\":{\"id\":\"testWebhookEndpoint\",\"group\":\"webhooks.endpoints\",\"method\":\"test\",\"verb\":\"POST\",\"path\":\"/v1/webhook-endpoints/{endpointId}/test\",\"ids\":[\"endpointId\"],\"paramsName\":\"WebhookEndpointTestParams\",\"hasParams\":false,\"paramsRequired\":false,\"response\":\"TestWebhookEndpointResponse\",\"paginated\":false,\"query\":[],\"headers\":{\"organizationId\":\"X-Affinity-Organization-Id\"},\"body\":false,\"practice\":\"none\",\"rootOnly\":true,\"idempotency\":\"required\"},\"listWebhookEvents\":{\"id\":\"listWebhookEvents\",\"group\":\"webhooks.events\",\"method\":\"list\",\"verb\":\"GET\",\"path\":\"/v1/webhook-events\",\"ids\":[],\"paramsName\":\"WebhookEventListParams\",\"hasParams\":true,\"paramsRequired\":false,\"response\":\"ListWebhookEventsResponse\",\"paginated\":true,\"query\":[\"endingBefore\",\"limit\",\"status\",\"startingAfter\"],\"headers\":{\"organizationId\":\"X-Affinity-Organization-Id\"},\"body\":false,\"practice\":\"none\",\"rootOnly\":true,\"idempotency\":\"none\"},\"getWebhookEvent\":{\"id\":\"getWebhookEvent\",\"group\":\"webhooks.events\",\"method\":\"get\",\"verb\":\"GET\",\"path\":\"/v1/webhook-events/{eventId}\",\"ids\":[\"eventId\"],\"paramsName\":\"WebhookEventGetParams\",\"hasParams\":false,\"paramsRequired\":false,\"response\":\"GetWebhookEventResponse\",\"paginated\":false,\"query\":[],\"headers\":{\"organizationId\":\"X-Affinity-Organization-Id\"},\"body\":false,\"practice\":\"none\",\"rootOnly\":true,\"idempotency\":\"none\"},\"replayWebhookEvent\":{\"id\":\"replayWebhookEvent\",\"group\":\"webhooks.events\",\"method\":\"replay\",\"verb\":\"POST\",\"path\":\"/v1/webhook-events/{eventId}/replay\",\"ids\":[\"eventId\"],\"paramsName\":\"WebhookEventReplayParams\",\"hasParams\":false,\"paramsRequired\":false,\"response\":\"ReplayWebhookEventResponse\",\"paginated\":false,\"query\":[],\"headers\":{\"organizationId\":\"X-Affinity-Organization-Id\"},\"body\":false,\"practice\":\"none\",\"rootOnly\":true,\"idempotency\":\"required\"},\"getOrderTestSimulation\":{\"id\":\"getOrderTestSimulation\",\"group\":\"orders.testSimulation\",\"method\":\"get\",\"verb\":\"GET\",\"path\":\"/v1/orders/{orderId}/test-simulation\",\"ids\":[\"orderId\"],\"paramsName\":\"OrderTestSimulationGetParams\",\"hasParams\":false,\"paramsRequired\":false,\"response\":\"GetOrderTestSimulationResponse\",\"paginated\":false,\"query\":[],\"headers\":{},\"body\":false,\"practice\":\"order\",\"rootOnly\":false,\"idempotency\":\"none\"},\"updateOrderTestSimulation\":{\"id\":\"updateOrderTestSimulation\",\"group\":\"orders.testSimulation\",\"method\":\"update\",\"verb\":\"PUT\",\"path\":\"/v1/orders/{orderId}/test-simulation\",\"ids\":[\"orderId\"],\"paramsName\":\"OrderTestSimulationUpdateParams\",\"hasParams\":true,\"paramsRequired\":true,\"response\":\"UpdateOrderTestSimulationResponse\",\"paginated\":false,\"query\":[],\"headers\":{},\"body\":true,\"practice\":\"order\",\"rootOnly\":false,\"idempotency\":\"required\"},\"retrievePrescribingOptions\":{\"id\":\"retrievePrescribingOptions\",\"group\":\"catalog.prescribingOptions\",\"method\":\"get\",\"verb\":\"GET\",\"path\":\"/v1/catalog/items/{catalogItemId}/prescribing-options\",\"ids\":[\"catalogItemId\"],\"paramsName\":\"PrescribingOptionGetParams\",\"hasParams\":false,\"paramsRequired\":false,\"response\":\"RetrievePrescribingOptionsResponse\",\"paginated\":false,\"query\":[\"practiceId\"],\"headers\":{},\"body\":false,\"practice\":\"query\",\"rootOnly\":false,\"idempotency\":\"none\"},\"previewOrder\":{\"id\":\"previewOrder\",\"group\":\"orders\",\"method\":\"preview\",\"verb\":\"POST\",\"path\":\"/v1/order-previews\",\"ids\":[],\"paramsName\":\"OrderPreviewParams\",\"hasParams\":true,\"paramsRequired\":true,\"response\":\"PreviewOrderResponse\",\"paginated\":false,\"query\":[],\"headers\":{},\"body\":true,\"practice\":\"body\",\"rootOnly\":false,\"idempotency\":\"none\"},\"signOrder\":{\"id\":\"signOrder\",\"group\":\"orders\",\"method\":\"sign\",\"verb\":\"POST\",\"path\":\"/v1/orders/{orderId}/sign\",\"ids\":[\"orderId\"],\"paramsName\":\"OrderSignParams\",\"hasParams\":true,\"paramsRequired\":true,\"response\":\"SignOrderResponse\",\"paginated\":false,\"query\":[],\"headers\":{},\"body\":true,\"practice\":\"body\",\"rootOnly\":false,\"idempotency\":\"required\"},\"signAndSubmitOrder\":{\"id\":\"signAndSubmitOrder\",\"group\":\"orders\",\"method\":\"signAndSubmit\",\"verb\":\"POST\",\"path\":\"/v1/orders/{orderId}/sign-and-submit\",\"ids\":[\"orderId\"],\"paramsName\":\"OrderSignAndSubmitParams\",\"hasParams\":true,\"paramsRequired\":true,\"response\":\"SignAndSubmitOrderResponse\",\"paginated\":false,\"query\":[],\"headers\":{},\"body\":true,\"practice\":\"body\",\"rootOnly\":false,\"idempotency\":\"required\"},\"submitOrder\":{\"id\":\"submitOrder\",\"group\":\"orders\",\"method\":\"submit\",\"verb\":\"POST\",\"path\":\"/v1/orders/{orderId}/submit\",\"ids\":[\"orderId\"],\"paramsName\":\"OrderSubmitParams\",\"hasParams\":false,\"paramsRequired\":false,\"response\":\"SubmitOrderResponse\",\"paginated\":false,\"query\":[],\"headers\":{},\"body\":true,\"practice\":\"body\",\"rootOnly\":false,\"idempotency\":\"required\"},\"rejectOrder\":{\"id\":\"rejectOrder\",\"group\":\"orders\",\"method\":\"reject\",\"verb\":\"POST\",\"path\":\"/v1/orders/{orderId}/rejection\",\"ids\":[\"orderId\"],\"paramsName\":\"OrderRejectParams\",\"hasParams\":true,\"paramsRequired\":true,\"response\":\"RejectOrderResponse\",\"paginated\":false,\"query\":[],\"headers\":{},\"body\":true,\"practice\":\"body\",\"rootOnly\":false,\"idempotency\":\"required\"},\"registerUser\":{\"id\":\"registerUser\",\"group\":\"team\",\"method\":\"register\",\"verb\":\"POST\",\"path\":\"/v1/practices/{practiceId}/users\",\"ids\":[],\"paramsName\":\"TeamRegisterParams\",\"hasParams\":true,\"paramsRequired\":true,\"response\":\"RegisterUserResponse\",\"paginated\":false,\"query\":[],\"headers\":{},\"body\":true,\"practice\":\"path\",\"rootOnly\":false,\"idempotency\":\"required\"},\"listPatientAddresses\":{\"id\":\"listPatientAddresses\",\"group\":\"patients.addresses\",\"method\":\"list\",\"verb\":\"GET\",\"path\":\"/v1/practices/{practiceId}/patients/{patientId}/addresses\",\"ids\":[\"patientId\"],\"paramsName\":\"PatientAddressListParams\",\"hasParams\":true,\"paramsRequired\":false,\"response\":\"ListPatientAddressesResponse\",\"paginated\":true,\"query\":[\"status\",\"startingAfter\",\"endingBefore\",\"limit\"],\"headers\":{\"actorId\":\"Affinity-Actor-Id\",\"actorType\":\"Affinity-Actor-Type\"},\"body\":false,\"practice\":\"path\",\"rootOnly\":false,\"idempotency\":\"none\"},\"createPatientAddress\":{\"id\":\"createPatientAddress\",\"group\":\"patients.addresses\",\"method\":\"create\",\"verb\":\"POST\",\"path\":\"/v1/practices/{practiceId}/patients/{patientId}/addresses\",\"ids\":[\"patientId\"],\"paramsName\":\"PatientAddressCreateParams\",\"hasParams\":true,\"paramsRequired\":true,\"response\":\"CreatePatientAddressResponse\",\"paginated\":false,\"query\":[],\"headers\":{\"actorId\":\"Affinity-Actor-Id\",\"actorType\":\"Affinity-Actor-Type\"},\"body\":true,\"practice\":\"path\",\"rootOnly\":false,\"idempotency\":\"auto\"},\"updatePatientAddress\":{\"id\":\"updatePatientAddress\",\"group\":\"patients.addresses\",\"method\":\"update\",\"verb\":\"PATCH\",\"path\":\"/v1/practices/{practiceId}/patients/{patientId}/addresses/{addressId}\",\"ids\":[\"patientId\",\"addressId\"],\"paramsName\":\"PatientAddressUpdateParams\",\"hasParams\":true,\"paramsRequired\":false,\"response\":\"UpdatePatientAddressResponse\",\"paginated\":false,\"query\":[],\"headers\":{\"actorId\":\"Affinity-Actor-Id\",\"actorType\":\"Affinity-Actor-Type\"},\"body\":true,\"practice\":\"path\",\"rootOnly\":false,\"idempotency\":\"auto\"},\"archivePatientAddress\":{\"id\":\"archivePatientAddress\",\"group\":\"patients.addresses\",\"method\":\"archive\",\"verb\":\"DELETE\",\"path\":\"/v1/practices/{practiceId}/patients/{patientId}/addresses/{addressId}\",\"ids\":[\"patientId\",\"addressId\"],\"paramsName\":\"PatientAddressArchiveParams\",\"hasParams\":false,\"paramsRequired\":false,\"response\":\"ArchivePatientAddressResponse\",\"paginated\":false,\"query\":[],\"headers\":{\"actorId\":\"Affinity-Actor-Id\",\"actorType\":\"Affinity-Actor-Type\"},\"body\":false,\"practice\":\"path\",\"rootOnly\":false,\"idempotency\":\"auto\"},\"setDefaultPatientAddress\":{\"id\":\"setDefaultPatientAddress\",\"group\":\"patients.addresses\",\"method\":\"setDefault\",\"verb\":\"PUT\",\"path\":\"/v1/practices/{practiceId}/patients/{patientId}/addresses/{addressId}/default\",\"ids\":[\"patientId\",\"addressId\"],\"paramsName\":\"PatientAddressSetDefaultParams\",\"hasParams\":false,\"paramsRequired\":false,\"response\":\"SetDefaultPatientAddressResponse\",\"paginated\":false,\"query\":[],\"headers\":{\"actorId\":\"Affinity-Actor-Id\",\"actorType\":\"Affinity-Actor-Type\"},\"body\":false,\"practice\":\"path\",\"rootOnly\":false,\"idempotency\":\"auto\"},\"invitePracticeTeamPerson\":{\"id\":\"invitePracticeTeamPerson\",\"group\":\"team.invitations\",\"method\":\"create\",\"verb\":\"POST\",\"path\":\"/v1/practices/{practiceId}/team/invitations\",\"ids\":[],\"paramsName\":\"TeamInvitationCreateParams\",\"hasParams\":true,\"paramsRequired\":true,\"response\":\"InvitePracticeTeamPersonResponse\",\"paginated\":false,\"query\":[],\"headers\":{},\"body\":true,\"practice\":\"path\",\"rootOnly\":false,\"idempotency\":\"required\"},\"listPracticeTeamInvitations\":{\"id\":\"listPracticeTeamInvitations\",\"group\":\"team.invitations\",\"method\":\"list\",\"verb\":\"GET\",\"path\":\"/v1/practices/{practiceId}/team/invitations\",\"ids\":[],\"paramsName\":\"TeamInvitationListParams\",\"hasParams\":true,\"paramsRequired\":false,\"response\":\"ListPracticeTeamInvitationsResponse\",\"paginated\":true,\"query\":[\"limit\",\"startingAfter\",\"endingBefore\",\"status\",\"email\",\"externalId\"],\"headers\":{},\"body\":false,\"practice\":\"path\",\"rootOnly\":false,\"idempotency\":\"none\"},\"getPracticeTeam\":{\"id\":\"getPracticeTeam\",\"group\":\"team\",\"method\":\"get\",\"verb\":\"GET\",\"path\":\"/v1/practices/{practiceId}/team\",\"ids\":[],\"paramsName\":\"TeamGetParams\",\"hasParams\":false,\"paramsRequired\":false,\"response\":\"GetPracticeTeamResponse\",\"paginated\":false,\"query\":[],\"headers\":{},\"body\":false,\"practice\":\"path\",\"rootOnly\":false,\"idempotency\":\"none\"},\"listPracticeTeamMembers\":{\"id\":\"listPracticeTeamMembers\",\"group\":\"team.members\",\"method\":\"list\",\"verb\":\"GET\",\"path\":\"/v1/practices/{practiceId}/team/members\",\"ids\":[],\"paramsName\":\"TeamMemberListParams\",\"hasParams\":true,\"paramsRequired\":false,\"response\":\"ListPracticeTeamMembersResponse\",\"paginated\":true,\"query\":[\"limit\",\"startingAfter\",\"endingBefore\",\"search\",\"role\",\"status\"],\"headers\":{},\"body\":false,\"practice\":\"path\",\"rootOnly\":false,\"idempotency\":\"none\"},\"listPracticeTeamPrescribers\":{\"id\":\"listPracticeTeamPrescribers\",\"group\":\"team.prescribers\",\"method\":\"list\",\"verb\":\"GET\",\"path\":\"/v1/practices/{practiceId}/team/prescribers\",\"ids\":[],\"paramsName\":\"TeamPrescriberListParams\",\"hasParams\":true,\"paramsRequired\":false,\"response\":\"ListPracticeTeamPrescribersResponse\",\"paginated\":true,\"query\":[\"limit\",\"startingAfter\",\"endingBefore\",\"search\",\"npi\",\"state\",\"status\"],\"headers\":{},\"body\":false,\"practice\":\"path\",\"rootOnly\":false,\"idempotency\":\"none\"},\"getPracticeTeamMember\":{\"id\":\"getPracticeTeamMember\",\"group\":\"team.members\",\"method\":\"get\",\"verb\":\"GET\",\"path\":\"/v1/practices/{practiceId}/team/members/{memberId}\",\"ids\":[\"memberId\"],\"paramsName\":\"TeamMemberGetParams\",\"hasParams\":false,\"paramsRequired\":false,\"response\":\"GetPracticeTeamMemberResponse\",\"paginated\":false,\"query\":[],\"headers\":{},\"body\":false,\"practice\":\"path\",\"rootOnly\":false,\"idempotency\":\"none\"},\"updatePracticeTeamMember\":{\"id\":\"updatePracticeTeamMember\",\"group\":\"team.members\",\"method\":\"update\",\"verb\":\"PATCH\",\"path\":\"/v1/practices/{practiceId}/team/members/{memberId}\",\"ids\":[\"memberId\"],\"paramsName\":\"TeamMemberUpdateParams\",\"hasParams\":true,\"paramsRequired\":false,\"response\":\"UpdatePracticeTeamMemberResponse\",\"paginated\":false,\"query\":[],\"headers\":{},\"body\":true,\"practice\":\"path\",\"rootOnly\":false,\"idempotency\":\"auto\"},\"getPracticeTeamPrescriber\":{\"id\":\"getPracticeTeamPrescriber\",\"group\":\"team.prescribers\",\"method\":\"get\",\"verb\":\"GET\",\"path\":\"/v1/practices/{practiceId}/team/prescribers/{prescriberId}\",\"ids\":[\"prescriberId\"],\"paramsName\":\"TeamPrescriberGetParams\",\"hasParams\":false,\"paramsRequired\":false,\"response\":\"GetPracticeTeamPrescriberResponse\",\"paginated\":false,\"query\":[],\"headers\":{},\"body\":false,\"practice\":\"path\",\"rootOnly\":false,\"idempotency\":\"none\"},\"updatePracticeTeamPrescriber\":{\"id\":\"updatePracticeTeamPrescriber\",\"group\":\"team.prescribers\",\"method\":\"update\",\"verb\":\"PATCH\",\"path\":\"/v1/practices/{practiceId}/team/prescribers/{prescriberId}\",\"ids\":[\"prescriberId\"],\"paramsName\":\"TeamPrescriberUpdateParams\",\"hasParams\":true,\"paramsRequired\":false,\"response\":\"UpdatePracticeTeamPrescriberResponse\",\"paginated\":false,\"query\":[],\"headers\":{},\"body\":true,\"practice\":\"path\",\"rootOnly\":false,\"idempotency\":\"auto\"},\"createPracticeTeamLicense\":{\"id\":\"createPracticeTeamLicense\",\"group\":\"team.prescribers.licenses\",\"method\":\"create\",\"verb\":\"POST\",\"path\":\"/v1/practices/{practiceId}/team/prescribers/{prescriberId}/licenses\",\"ids\":[\"prescriberId\"],\"paramsName\":\"TeamPrescriberLicenseCreateParams\",\"hasParams\":true,\"paramsRequired\":true,\"response\":\"CreatePracticeTeamLicenseResponse\",\"paginated\":false,\"query\":[],\"headers\":{},\"body\":true,\"practice\":\"path\",\"rootOnly\":false,\"idempotency\":\"auto\"},\"updatePracticeTeamLicense\":{\"id\":\"updatePracticeTeamLicense\",\"group\":\"team.prescribers.licenses\",\"method\":\"update\",\"verb\":\"PATCH\",\"path\":\"/v1/practices/{practiceId}/team/prescribers/{prescriberId}/licenses/{licenseId}\",\"ids\":[\"prescriberId\",\"licenseId\"],\"paramsName\":\"TeamPrescriberLicenseUpdateParams\",\"hasParams\":true,\"paramsRequired\":false,\"response\":\"UpdatePracticeTeamLicenseResponse\",\"paginated\":false,\"query\":[],\"headers\":{},\"body\":true,\"practice\":\"path\",\"rootOnly\":false,\"idempotency\":\"auto\"},\"getPracticeTeamInvitation\":{\"id\":\"getPracticeTeamInvitation\",\"group\":\"team.invitations\",\"method\":\"get\",\"verb\":\"GET\",\"path\":\"/v1/practices/{practiceId}/team/invitations/{invitationId}\",\"ids\":[\"invitationId\"],\"paramsName\":\"TeamInvitationGetParams\",\"hasParams\":false,\"paramsRequired\":false,\"response\":\"GetPracticeTeamInvitationResponse\",\"paginated\":false,\"query\":[],\"headers\":{},\"body\":false,\"practice\":\"path\",\"rootOnly\":false,\"idempotency\":\"none\"},\"revokePracticeTeamInvitation\":{\"id\":\"revokePracticeTeamInvitation\",\"group\":\"team.invitations\",\"method\":\"revoke\",\"verb\":\"DELETE\",\"path\":\"/v1/practices/{practiceId}/team/invitations/{invitationId}\",\"ids\":[\"invitationId\"],\"paramsName\":\"TeamInvitationRevokeParams\",\"hasParams\":false,\"paramsRequired\":false,\"response\":\"RevokePracticeTeamInvitationResponse\",\"paginated\":false,\"query\":[],\"headers\":{},\"body\":false,\"practice\":\"path\",\"rootOnly\":false,\"idempotency\":\"required\"},\"resendPracticeTeamInvitation\":{\"id\":\"resendPracticeTeamInvitation\",\"group\":\"team.invitations\",\"method\":\"resend\",\"verb\":\"POST\",\"path\":\"/v1/practices/{practiceId}/team/invitations/{invitationId}/resend\",\"ids\":[\"invitationId\"],\"paramsName\":\"TeamInvitationResendParams\",\"hasParams\":false,\"paramsRequired\":false,\"response\":\"ResendPracticeTeamInvitationResponse\",\"paginated\":false,\"query\":[],\"headers\":{},\"body\":false,\"practice\":\"path\",\"rootOnly\":false,\"idempotency\":\"required\"},\"getApiAccess\":{\"id\":\"getApiAccess\",\"group\":\"apiKeys\",\"method\":\"getAccess\",\"verb\":\"GET\",\"path\":\"/v1/auth/access\",\"ids\":[],\"paramsName\":\"ApiKeyGetAccessParams\",\"hasParams\":false,\"paramsRequired\":false,\"response\":\"GetApiAccessResponse\",\"paginated\":false,\"query\":[],\"headers\":{},\"body\":false,\"practice\":\"none\",\"rootOnly\":false,\"idempotency\":\"none\"},\"listPractices\":{\"id\":\"listPractices\",\"group\":\"practices\",\"method\":\"list\",\"verb\":\"GET\",\"path\":\"/v1/practices\",\"ids\":[],\"paramsName\":\"PracticeListParams\",\"hasParams\":true,\"paramsRequired\":false,\"response\":\"ListPracticesResponse\",\"paginated\":true,\"query\":[\"search\",\"endingBefore\",\"limit\",\"startingAfter\"],\"headers\":{},\"body\":false,\"practice\":\"none\",\"rootOnly\":true,\"idempotency\":\"none\"},\"createPractice\":{\"id\":\"createPractice\",\"group\":\"practices\",\"method\":\"create\",\"verb\":\"POST\",\"path\":\"/v1/practices\",\"ids\":[],\"paramsName\":\"PracticeCreateParams\",\"hasParams\":true,\"paramsRequired\":true,\"response\":\"CreatePracticeResponse\",\"paginated\":false,\"query\":[],\"headers\":{},\"body\":true,\"practice\":\"none\",\"rootOnly\":true,\"idempotency\":\"auto\"},\"getPractice\":{\"id\":\"getPractice\",\"group\":\"practices\",\"method\":\"get\",\"verb\":\"GET\",\"path\":\"/v1/practices/{practiceId}\",\"ids\":[\"practiceId\"],\"paramsName\":\"PracticeGetParams\",\"hasParams\":false,\"paramsRequired\":false,\"response\":\"GetPracticeResponse\",\"paginated\":false,\"query\":[],\"headers\":{},\"body\":false,\"practice\":\"none\",\"rootOnly\":true,\"idempotency\":\"none\"},\"updatePractice\":{\"id\":\"updatePractice\",\"group\":\"practices\",\"method\":\"update\",\"verb\":\"PATCH\",\"path\":\"/v1/practices/{practiceId}\",\"ids\":[\"practiceId\"],\"paramsName\":\"PracticeUpdateParams\",\"hasParams\":true,\"paramsRequired\":false,\"response\":\"UpdatePracticeResponse\",\"paginated\":false,\"query\":[],\"headers\":{},\"body\":true,\"practice\":\"none\",\"rootOnly\":true,\"idempotency\":\"auto\"},\"listPatients\":{\"id\":\"listPatients\",\"group\":\"patients\",\"method\":\"list\",\"verb\":\"GET\",\"path\":\"/v1/practices/{practiceId}/patients\",\"ids\":[],\"paramsName\":\"PatientListParams\",\"hasParams\":true,\"paramsRequired\":false,\"response\":\"ListPatientsResponse\",\"paginated\":true,\"query\":[\"endingBefore\",\"externalId\",\"externalIdentitySource\",\"externalIdentityValue\",\"gender\",\"lastOrderAfter\",\"lastOrderBefore\",\"limit\",\"program\",\"query\",\"sort\",\"startingAfter\",\"states\",\"status\"],\"headers\":{\"actorId\":\"Affinity-Actor-Id\",\"actorType\":\"Affinity-Actor-Type\"},\"body\":false,\"practice\":\"path\",\"rootOnly\":false,\"idempotency\":\"none\"},\"createPatient\":{\"id\":\"createPatient\",\"group\":\"patients\",\"method\":\"create\",\"verb\":\"POST\",\"path\":\"/v1/practices/{practiceId}/patients\",\"ids\":[],\"paramsName\":\"PatientCreateParams\",\"hasParams\":true,\"paramsRequired\":true,\"response\":\"CreatePatientResponse\",\"paginated\":false,\"query\":[],\"headers\":{\"actorId\":\"Affinity-Actor-Id\",\"actorType\":\"Affinity-Actor-Type\"},\"body\":true,\"practice\":\"path\",\"rootOnly\":false,\"idempotency\":\"auto\"},\"getPatient\":{\"id\":\"getPatient\",\"group\":\"patients\",\"method\":\"get\",\"verb\":\"GET\",\"path\":\"/v1/practices/{practiceId}/patients/{patientId}\",\"ids\":[\"patientId\"],\"paramsName\":\"PatientGetParams\",\"hasParams\":false,\"paramsRequired\":false,\"response\":\"GetPatientResponse\",\"paginated\":false,\"query\":[],\"headers\":{\"actorId\":\"Affinity-Actor-Id\",\"actorType\":\"Affinity-Actor-Type\"},\"body\":false,\"practice\":\"path\",\"rootOnly\":false,\"idempotency\":\"none\"},\"deletePatient\":{\"id\":\"deletePatient\",\"group\":\"patients\",\"method\":\"delete\",\"verb\":\"DELETE\",\"path\":\"/v1/practices/{practiceId}/patients/{patientId}\",\"ids\":[\"patientId\"],\"paramsName\":\"PatientDeleteParams\",\"hasParams\":false,\"paramsRequired\":false,\"response\":\"DeletePatientResponse\",\"paginated\":false,\"query\":[],\"headers\":{\"actorId\":\"Affinity-Actor-Id\",\"actorType\":\"Affinity-Actor-Type\"},\"body\":false,\"practice\":\"path\",\"rootOnly\":false,\"idempotency\":\"auto\"},\"updatePatient\":{\"id\":\"updatePatient\",\"group\":\"patients\",\"method\":\"update\",\"verb\":\"PATCH\",\"path\":\"/v1/practices/{practiceId}/patients/{patientId}\",\"ids\":[\"patientId\"],\"paramsName\":\"PatientUpdateParams\",\"hasParams\":true,\"paramsRequired\":false,\"response\":\"UpdatePatientResponse\",\"paginated\":false,\"query\":[],\"headers\":{\"actorId\":\"Affinity-Actor-Id\",\"actorType\":\"Affinity-Actor-Type\"},\"body\":true,\"practice\":\"path\",\"rootOnly\":false,\"idempotency\":\"auto\"},\"getPatientAllergies\":{\"id\":\"getPatientAllergies\",\"group\":\"patients.allergies\",\"method\":\"get\",\"verb\":\"GET\",\"path\":\"/v1/practices/{practiceId}/patients/{patientId}/allergies\",\"ids\":[\"patientId\"],\"paramsName\":\"PatientAllergyGetParams\",\"hasParams\":false,\"paramsRequired\":false,\"response\":\"GetPatientAllergiesResponse\",\"paginated\":false,\"query\":[],\"headers\":{\"actorId\":\"Affinity-Actor-Id\",\"actorType\":\"Affinity-Actor-Type\"},\"body\":false,\"practice\":\"path\",\"rootOnly\":false,\"idempotency\":\"none\"},\"replacePatientAllergies\":{\"id\":\"replacePatientAllergies\",\"group\":\"patients.allergies\",\"method\":\"replace\",\"verb\":\"PUT\",\"path\":\"/v1/practices/{practiceId}/patients/{patientId}/allergies\",\"ids\":[\"patientId\"],\"paramsName\":\"PatientAllergyReplaceParams\",\"hasParams\":true,\"paramsRequired\":true,\"response\":\"ReplacePatientAllergiesResponse\",\"paginated\":false,\"query\":[],\"headers\":{\"actorId\":\"Affinity-Actor-Id\",\"actorType\":\"Affinity-Actor-Type\"},\"body\":true,\"practice\":\"path\",\"rootOnly\":false,\"idempotency\":\"required\"},\"addOrderPrescription\":{\"id\":\"addOrderPrescription\",\"group\":\"orders.prescriptions\",\"method\":\"add\",\"verb\":\"POST\",\"path\":\"/v1/orders/{orderId}/prescriptions\",\"ids\":[\"orderId\"],\"paramsName\":\"OrderPrescriptionAddParams\",\"hasParams\":true,\"paramsRequired\":true,\"response\":\"AddOrderPrescriptionResponse\",\"paginated\":false,\"query\":[],\"headers\":{\"actorId\":\"Affinity-Actor-Id\",\"actorType\":\"Affinity-Actor-Type\"},\"body\":true,\"practice\":\"body\",\"rootOnly\":false,\"idempotency\":\"required\"},\"updateOrderPrescription\":{\"id\":\"updateOrderPrescription\",\"group\":\"orders.prescriptions\",\"method\":\"update\",\"verb\":\"PATCH\",\"path\":\"/v1/orders/{orderId}/prescriptions/{prescriptionId}\",\"ids\":[\"orderId\",\"prescriptionId\"],\"paramsName\":\"OrderPrescriptionUpdateParams\",\"hasParams\":true,\"paramsRequired\":true,\"response\":\"UpdateOrderPrescriptionResponse\",\"paginated\":false,\"query\":[],\"headers\":{\"actorId\":\"Affinity-Actor-Id\",\"actorType\":\"Affinity-Actor-Type\"},\"body\":true,\"practice\":\"body\",\"rootOnly\":false,\"idempotency\":\"required\"},\"createOrderBatch\":{\"id\":\"createOrderBatch\",\"group\":\"orders.batches\",\"method\":\"create\",\"verb\":\"POST\",\"path\":\"/v1/order-batches\",\"ids\":[],\"paramsName\":\"OrderBatchCreateParams\",\"hasParams\":true,\"paramsRequired\":true,\"response\":\"CreateOrderBatchResponse\",\"paginated\":false,\"query\":[],\"headers\":{\"actorId\":\"Affinity-Actor-Id\",\"actorType\":\"Affinity-Actor-Type\"},\"body\":true,\"practice\":\"body\",\"rootOnly\":false,\"idempotency\":\"required\"},\"platform.public-api.selling-prices.readSellingPrice\":{\"id\":\"platform.public-api.selling-prices.readSellingPrice\",\"group\":\"catalog.sellingPrices\",\"method\":\"get\",\"verb\":\"GET\",\"path\":\"/v1/catalog/items/{catalogItemId}/selling-price\",\"ids\":[\"catalogItemId\"],\"paramsName\":\"SellingPriceGetParams\",\"hasParams\":false,\"paramsRequired\":false,\"response\":\"PlatformPublicApiSellingPricesReadSellingPriceResponse\",\"paginated\":false,\"query\":[\"practiceId\"],\"headers\":{},\"body\":false,\"practice\":\"query\",\"rootOnly\":false,\"idempotency\":\"none\"},\"platform.public-api.selling-prices.updateSellingPrice\":{\"id\":\"platform.public-api.selling-prices.updateSellingPrice\",\"group\":\"catalog.sellingPrices\",\"method\":\"update\",\"verb\":\"PUT\",\"path\":\"/v1/catalog/items/{catalogItemId}/selling-price\",\"ids\":[\"catalogItemId\"],\"paramsName\":\"SellingPriceUpdateParams\",\"hasParams\":true,\"paramsRequired\":true,\"response\":\"PlatformPublicApiSellingPricesUpdateSellingPriceResponse\",\"paginated\":false,\"query\":[],\"headers\":{},\"body\":true,\"practice\":\"body\",\"rootOnly\":false,\"idempotency\":\"required\"},\"listWebhookGrants\":{\"id\":\"listWebhookGrants\",\"group\":\"webhooks.grants\",\"method\":\"list\",\"verb\":\"GET\",\"path\":\"/v1/webhook-grants\",\"ids\":[],\"paramsName\":\"WebhookGrantListParams\",\"hasParams\":true,\"paramsRequired\":false,\"response\":\"ListWebhookGrantsResponse\",\"paginated\":true,\"query\":[\"limit\",\"startingAfter\",\"endingBefore\"],\"headers\":{},\"body\":false,\"practice\":\"none\",\"rootOnly\":true,\"idempotency\":\"none\"},\"saveWebhookGrant\":{\"id\":\"saveWebhookGrant\",\"group\":\"webhooks.grants\",\"method\":\"save\",\"verb\":\"PUT\",\"path\":\"/v1/webhook-grants/{platformId}\",\"ids\":[\"platformId\"],\"paramsName\":\"WebhookGrantSaveParams\",\"hasParams\":true,\"paramsRequired\":true,\"response\":\"SaveWebhookGrantResponse\",\"paginated\":false,\"query\":[],\"headers\":{},\"body\":true,\"practice\":\"none\",\"rootOnly\":true,\"idempotency\":\"required\"},\"revokeWebhookGrant\":{\"id\":\"revokeWebhookGrant\",\"group\":\"webhooks.grants\",\"method\":\"revoke\",\"verb\":\"DELETE\",\"path\":\"/v1/webhook-grants/{platformId}\",\"ids\":[\"platformId\"],\"paramsName\":\"WebhookGrantRevokeParams\",\"hasParams\":false,\"paramsRequired\":false,\"response\":\"RevokeWebhookGrantResponse\",\"paginated\":false,\"query\":[],\"headers\":{},\"body\":false,\"practice\":\"none\",\"rootOnly\":true,\"idempotency\":\"required\"}}",new JsonSerializerOptions{PropertyNameCaseInsensitive=true})!;}
public sealed class AccountSDKResource{private readonly SDKContext context;internal AccountSDKResource(SDKContext context){this.context=context;}
public Task<GetAccountResponse> GetAsync(AccountGetParams parameters,RequestOptions? options=null,CancellationToken cancellationToken=default)=>context.Call<GetAccountResponse>("getAccount",[],parameters,options,cancellationToken);
}
public sealed class ApiKeysSDKResource{private readonly SDKContext context;internal ApiKeysSDKResource(SDKContext context){this.context=context;}
public Task<CreatePlatformPracticeApiKeyResponse> CreateAsync(ApiKeyCreateParams parameters,RequestOptions? options=null,CancellationToken cancellationToken=default)=>context.Call<CreatePlatformPracticeApiKeyResponse>("createPlatformPracticeApiKey",[],parameters,options,cancellationToken);
public Task<GetApiAccessResponse> GetAccessAsync(RequestOptions? options=null,CancellationToken cancellationToken=default)=>context.Call<GetApiAccessResponse>("getApiAccess",[],null,options,cancellationToken);
}
public sealed class CatalogSDKResource{private readonly SDKContext context;internal CatalogSDKResource(SDKContext context){this.context=context;}
public CatalogItemsSDKResource Items=>new(context);
public CatalogPrescribingOptionsSDKResource PrescribingOptions=>new(context);
public CatalogSellingPricesSDKResource SellingPrices=>new(context);
public CatalogShippingOptionsSDKResource ShippingOptions=>new(context);
}
public sealed class CatalogItemsSDKResource{private readonly SDKContext context;internal CatalogItemsSDKResource(SDKContext context){this.context=context;}
public Task<ListCatalogItemsResponse> ListAsync(CatalogItemListParams parameters,RequestOptions? options=null,CancellationToken cancellationToken=default)=>context.Call<ListCatalogItemsResponse>("listCatalogItems",[],parameters,options,cancellationToken);
public IAsyncEnumerable<ListCatalogItemsResponseDataItem> IterateAsync(CatalogItemListParams parameters,RequestOptions? options=null,CancellationToken cancellationToken=default)=>context.Iterate<ListCatalogItemsResponseDataItem>("listCatalogItems",[],parameters,options,cancellationToken);
}
public sealed class CatalogPrescribingOptionsSDKResource{private readonly SDKContext context;internal CatalogPrescribingOptionsSDKResource(SDKContext context){this.context=context;}
public Task<RetrievePrescribingOptionsResponse> GetAsync(string catalogItemId,RequestOptions? options=null,CancellationToken cancellationToken=default)=>context.Call<RetrievePrescribingOptionsResponse>("retrievePrescribingOptions",[catalogItemId],null,options,cancellationToken);
}
public sealed class CatalogSellingPricesSDKResource{private readonly SDKContext context;internal CatalogSellingPricesSDKResource(SDKContext context){this.context=context;}
public Task<PlatformPublicApiSellingPricesReadSellingPriceResponse> GetAsync(string catalogItemId,RequestOptions? options=null,CancellationToken cancellationToken=default)=>context.Call<PlatformPublicApiSellingPricesReadSellingPriceResponse>("platform.public-api.selling-prices.readSellingPrice",[catalogItemId],null,options,cancellationToken);
public Task<PlatformPublicApiSellingPricesUpdateSellingPriceResponse> UpdateAsync(string catalogItemId,SellingPriceUpdateParams parameters,RequestOptions? options=null,CancellationToken cancellationToken=default)=>context.Call<PlatformPublicApiSellingPricesUpdateSellingPriceResponse>("platform.public-api.selling-prices.updateSellingPrice",[catalogItemId],parameters,options,cancellationToken);
}
public sealed class CatalogShippingOptionsSDKResource{private readonly SDKContext context;internal CatalogShippingOptionsSDKResource(SDKContext context){this.context=context;}
public Task<IEnumerable<ListShippingOptionsResponseItem>> ListAsync(string catalogItemId,ShippingOptionListParams parameters,RequestOptions? options=null,CancellationToken cancellationToken=default)=>context.Call<IEnumerable<ListShippingOptionsResponseItem>>("listShippingOptions",[catalogItemId],parameters,options,cancellationToken);
}
public sealed class LocationsSDKResource{private readonly SDKContext context;internal LocationsSDKResource(SDKContext context){this.context=context;}
public Task<ListPracticeLocationsResponse> ListAsync(LocationListParams parameters,RequestOptions? options=null,CancellationToken cancellationToken=default)=>context.Call<ListPracticeLocationsResponse>("listPracticeLocations",[],parameters,options,cancellationToken);
public IAsyncEnumerable<ListPracticeLocationsResponseDataItem> IterateAsync(LocationListParams parameters,RequestOptions? options=null,CancellationToken cancellationToken=default)=>context.Iterate<ListPracticeLocationsResponseDataItem>("listPracticeLocations",[],parameters,options,cancellationToken);
public Task<CreatePracticeLocationResponse> CreateAsync(LocationCreateParams parameters,RequestOptions? options=null,CancellationToken cancellationToken=default)=>context.Call<CreatePracticeLocationResponse>("createPracticeLocation",[],parameters,options,cancellationToken);
public Task<GetPracticeLocationResponse> GetAsync(string locationId,RequestOptions? options=null,CancellationToken cancellationToken=default)=>context.Call<GetPracticeLocationResponse>("getPracticeLocation",[locationId],null,options,cancellationToken);
public Task<UpdatePracticeLocationResponse> UpdateAsync(string locationId,LocationUpdateParams parameters,RequestOptions? options=null,CancellationToken cancellationToken=default)=>context.Call<UpdatePracticeLocationResponse>("updatePracticeLocation",[locationId],parameters,options,cancellationToken);
public Task<ArchivePracticeLocationResponse> ArchiveAsync(string locationId,RequestOptions? options=null,CancellationToken cancellationToken=default)=>context.Call<ArchivePracticeLocationResponse>("archivePracticeLocation",[locationId],null,options,cancellationToken);
}
public sealed class OrdersSDKResource{private readonly SDKContext context;internal OrdersSDKResource(SDKContext context){this.context=context;}
public OrdersBatchesSDKResource Batches=>new(context);
public OrdersEventsSDKResource Events=>new(context);
public OrdersExceptionsSDKResource Exceptions=>new(context);
public OrdersPrescriptionsSDKResource Prescriptions=>new(context);
public OrdersTestSimulationSDKResource TestSimulation=>new(context);
public Task<ListOrdersResponse> ListAsync(OrderListParams parameters,RequestOptions? options=null,CancellationToken cancellationToken=default)=>context.Call<ListOrdersResponse>("listOrders",[],parameters,options,cancellationToken);
public IAsyncEnumerable<ListOrdersResponseDataItem> IterateAsync(OrderListParams parameters,RequestOptions? options=null,CancellationToken cancellationToken=default)=>context.Iterate<ListOrdersResponseDataItem>("listOrders",[],parameters,options,cancellationToken);
public Task<CreateOrderResponse> CreateAsync(OrderCreateParams parameters,RequestOptions? options=null,CancellationToken cancellationToken=default)=>context.Call<CreateOrderResponse>("createOrder",[],parameters,options,cancellationToken);
public Task<GetOrderResponse> GetAsync(string orderId,RequestOptions? options=null,CancellationToken cancellationToken=default)=>context.Call<GetOrderResponse>("getOrder",[orderId],null,options,cancellationToken);
public Task<CancelOrderResponse> CancelAsync(string orderId,OrderCancelParams parameters,RequestOptions? options=null,CancellationToken cancellationToken=default)=>context.Call<CancelOrderResponse>("cancelOrder",[orderId],parameters,options,cancellationToken);
public Task<PreviewOrderResponse> PreviewAsync(OrderPreviewParams parameters,RequestOptions? options=null,CancellationToken cancellationToken=default)=>context.Call<PreviewOrderResponse>("previewOrder",[],parameters,options,cancellationToken);
public Task<SignOrderResponse> SignAsync(string orderId,OrderSignParams parameters,RequestOptions? options=null,CancellationToken cancellationToken=default)=>context.Call<SignOrderResponse>("signOrder",[orderId],parameters,options,cancellationToken);
public Task<SignAndSubmitOrderResponse> SignAndSubmitAsync(string orderId,OrderSignAndSubmitParams parameters,RequestOptions? options=null,CancellationToken cancellationToken=default)=>context.Call<SignAndSubmitOrderResponse>("signAndSubmitOrder",[orderId],parameters,options,cancellationToken);
public Task<SubmitOrderResponse> SubmitAsync(string orderId,RequestOptions? options=null,CancellationToken cancellationToken=default)=>context.Call<SubmitOrderResponse>("submitOrder",[orderId],null,options,cancellationToken);
public Task<RejectOrderResponse> RejectAsync(string orderId,OrderRejectParams parameters,RequestOptions? options=null,CancellationToken cancellationToken=default)=>context.Call<RejectOrderResponse>("rejectOrder",[orderId],parameters,options,cancellationToken);
}
public sealed class OrdersBatchesSDKResource{private readonly SDKContext context;internal OrdersBatchesSDKResource(SDKContext context){this.context=context;}
public Task<CreateOrderBatchResponse> CreateAsync(OrderBatchCreateParams parameters,RequestOptions? options=null,CancellationToken cancellationToken=default)=>context.Call<CreateOrderBatchResponse>("createOrderBatch",[],parameters,options,cancellationToken);
}
public sealed class OrdersEventsSDKResource{private readonly SDKContext context;internal OrdersEventsSDKResource(SDKContext context){this.context=context;}
public Task<ListOrderEventsResponse> ListAsync(string orderId,OrderEventListParams parameters,RequestOptions? options=null,CancellationToken cancellationToken=default)=>context.Call<ListOrderEventsResponse>("listOrderEvents",[orderId],parameters,options,cancellationToken);
public IAsyncEnumerable<ListOrderEventsResponseDataItem> IterateAsync(string orderId,OrderEventListParams parameters,RequestOptions? options=null,CancellationToken cancellationToken=default)=>context.Iterate<ListOrderEventsResponseDataItem>("listOrderEvents",[orderId],parameters,options,cancellationToken);
}
public sealed class OrdersExceptionsSDKResource{private readonly SDKContext context;internal OrdersExceptionsSDKResource(SDKContext context){this.context=context;}
public Task<ActOnOrderExceptionResponse> ActAsync(string orderId,string exceptionId,OrderExceptionActParams parameters,RequestOptions? options=null,CancellationToken cancellationToken=default)=>context.Call<ActOnOrderExceptionResponse>("actOnOrderException",[orderId,exceptionId],parameters,options,cancellationToken);
}
public sealed class OrdersPrescriptionsSDKResource{private readonly SDKContext context;internal OrdersPrescriptionsSDKResource(SDKContext context){this.context=context;}
public Task<AddOrderPrescriptionResponse> AddAsync(string orderId,OrderPrescriptionAddParams parameters,RequestOptions? options=null,CancellationToken cancellationToken=default)=>context.Call<AddOrderPrescriptionResponse>("addOrderPrescription",[orderId],parameters,options,cancellationToken);
public Task<UpdateOrderPrescriptionResponse> UpdateAsync(string orderId,string prescriptionId,OrderPrescriptionUpdateParams parameters,RequestOptions? options=null,CancellationToken cancellationToken=default)=>context.Call<UpdateOrderPrescriptionResponse>("updateOrderPrescription",[orderId,prescriptionId],parameters,options,cancellationToken);
}
public sealed class OrdersTestSimulationSDKResource{private readonly SDKContext context;internal OrdersTestSimulationSDKResource(SDKContext context){this.context=context;}
public Task<GetOrderTestSimulationResponse> GetAsync(string orderId,RequestOptions? options=null,CancellationToken cancellationToken=default)=>context.Call<GetOrderTestSimulationResponse>("getOrderTestSimulation",[orderId],null,options,cancellationToken);
public Task<UpdateOrderTestSimulationResponse> UpdateAsync(string orderId,OrderTestSimulationUpdateParams parameters,RequestOptions? options=null,CancellationToken cancellationToken=default)=>context.Call<UpdateOrderTestSimulationResponse>("updateOrderTestSimulation",[orderId],parameters,options,cancellationToken);
}
public sealed class PatientsSDKResource{private readonly SDKContext context;internal PatientsSDKResource(SDKContext context){this.context=context;}
public PatientsAddressesSDKResource Addresses=>new(context);
public PatientsAllergiesSDKResource Allergies=>new(context);
public Task<ListPatientsResponse> ListAsync(PatientListParams parameters,RequestOptions? options=null,CancellationToken cancellationToken=default)=>context.Call<ListPatientsResponse>("listPatients",[],parameters,options,cancellationToken);
public IAsyncEnumerable<ListPatientsResponseDataItem> IterateAsync(PatientListParams parameters,RequestOptions? options=null,CancellationToken cancellationToken=default)=>context.Iterate<ListPatientsResponseDataItem>("listPatients",[],parameters,options,cancellationToken);
public Task<CreatePatientResponse> CreateAsync(PatientCreateParams parameters,RequestOptions? options=null,CancellationToken cancellationToken=default)=>context.Call<CreatePatientResponse>("createPatient",[],parameters,options,cancellationToken);
public Task<GetPatientResponse> GetAsync(string patientId,RequestOptions? options=null,CancellationToken cancellationToken=default)=>context.Call<GetPatientResponse>("getPatient",[patientId],null,options,cancellationToken);
public Task<DeletePatientResponse> DeleteAsync(string patientId,RequestOptions? options=null,CancellationToken cancellationToken=default)=>context.Call<DeletePatientResponse>("deletePatient",[patientId],null,options,cancellationToken);
public Task<UpdatePatientResponse> UpdateAsync(string patientId,PatientUpdateParams parameters,RequestOptions? options=null,CancellationToken cancellationToken=default)=>context.Call<UpdatePatientResponse>("updatePatient",[patientId],parameters,options,cancellationToken);
}
public sealed class PatientsAddressesSDKResource{private readonly SDKContext context;internal PatientsAddressesSDKResource(SDKContext context){this.context=context;}
public Task<ListPatientAddressesResponse> ListAsync(string patientId,PatientAddressListParams parameters,RequestOptions? options=null,CancellationToken cancellationToken=default)=>context.Call<ListPatientAddressesResponse>("listPatientAddresses",[patientId],parameters,options,cancellationToken);
public IAsyncEnumerable<ListPatientAddressesResponseDataItem> IterateAsync(string patientId,PatientAddressListParams parameters,RequestOptions? options=null,CancellationToken cancellationToken=default)=>context.Iterate<ListPatientAddressesResponseDataItem>("listPatientAddresses",[patientId],parameters,options,cancellationToken);
public Task<CreatePatientAddressResponse> CreateAsync(string patientId,PatientAddressCreateParams parameters,RequestOptions? options=null,CancellationToken cancellationToken=default)=>context.Call<CreatePatientAddressResponse>("createPatientAddress",[patientId],parameters,options,cancellationToken);
public Task<UpdatePatientAddressResponse> UpdateAsync(string patientId,string addressId,PatientAddressUpdateParams parameters,RequestOptions? options=null,CancellationToken cancellationToken=default)=>context.Call<UpdatePatientAddressResponse>("updatePatientAddress",[patientId,addressId],parameters,options,cancellationToken);
public Task<ArchivePatientAddressResponse> ArchiveAsync(string patientId,string addressId,RequestOptions? options=null,CancellationToken cancellationToken=default)=>context.Call<ArchivePatientAddressResponse>("archivePatientAddress",[patientId,addressId],null,options,cancellationToken);
public Task<SetDefaultPatientAddressResponse> SetDefaultAsync(string patientId,string addressId,RequestOptions? options=null,CancellationToken cancellationToken=default)=>context.Call<SetDefaultPatientAddressResponse>("setDefaultPatientAddress",[patientId,addressId],null,options,cancellationToken);
}
public sealed class PatientsAllergiesSDKResource{private readonly SDKContext context;internal PatientsAllergiesSDKResource(SDKContext context){this.context=context;}
public Task<GetPatientAllergiesResponse> GetAsync(string patientId,RequestOptions? options=null,CancellationToken cancellationToken=default)=>context.Call<GetPatientAllergiesResponse>("getPatientAllergies",[patientId],null,options,cancellationToken);
public Task<ReplacePatientAllergiesResponse> ReplaceAsync(string patientId,PatientAllergyReplaceParams parameters,RequestOptions? options=null,CancellationToken cancellationToken=default)=>context.Call<ReplacePatientAllergiesResponse>("replacePatientAllergies",[patientId],parameters,options,cancellationToken);
}
public sealed class PharmaciesSDKResource{private readonly SDKContext context;internal PharmaciesSDKResource(SDKContext context){this.context=context;}
public Task<ListPharmaciesResponse> ListAsync(PharmacyListParams parameters,RequestOptions? options=null,CancellationToken cancellationToken=default)=>context.Call<ListPharmaciesResponse>("listPharmacies",[],parameters,options,cancellationToken);
public IAsyncEnumerable<ListPharmaciesResponseDataItem> IterateAsync(PharmacyListParams parameters,RequestOptions? options=null,CancellationToken cancellationToken=default)=>context.Iterate<ListPharmaciesResponseDataItem>("listPharmacies",[],parameters,options,cancellationToken);
}
public sealed class PracticesSDKResource{private readonly SDKContext context;internal PracticesSDKResource(SDKContext context){this.context=context;}
public Task<ListPracticesResponse> ListAsync(PracticeListParams parameters,RequestOptions? options=null,CancellationToken cancellationToken=default)=>context.Call<ListPracticesResponse>("listPractices",[],parameters,options,cancellationToken);
public IAsyncEnumerable<ListPracticesResponseDataItem> IterateAsync(PracticeListParams parameters,RequestOptions? options=null,CancellationToken cancellationToken=default)=>context.Iterate<ListPracticesResponseDataItem>("listPractices",[],parameters,options,cancellationToken);
public Task<CreatePracticeResponse> CreateAsync(PracticeCreateParams parameters,RequestOptions? options=null,CancellationToken cancellationToken=default)=>context.Call<CreatePracticeResponse>("createPractice",[],parameters,options,cancellationToken);
public Task<GetPracticeResponse> GetAsync(string practiceId,RequestOptions? options=null,CancellationToken cancellationToken=default)=>context.Call<GetPracticeResponse>("getPractice",[practiceId],null,options,cancellationToken);
public Task<UpdatePracticeResponse> UpdateAsync(string practiceId,PracticeUpdateParams parameters,RequestOptions? options=null,CancellationToken cancellationToken=default)=>context.Call<UpdatePracticeResponse>("updatePractice",[practiceId],parameters,options,cancellationToken);
}
public sealed class TeamSDKResource{private readonly SDKContext context;internal TeamSDKResource(SDKContext context){this.context=context;}
public TeamInvitationsSDKResource Invitations=>new(context);
public TeamMembersSDKResource Members=>new(context);
public TeamPrescribersSDKResource Prescribers=>new(context);
public Task<RegisterUserResponse> RegisterAsync(TeamRegisterParams parameters,RequestOptions? options=null,CancellationToken cancellationToken=default)=>context.Call<RegisterUserResponse>("registerUser",[],parameters,options,cancellationToken);
public Task<GetPracticeTeamResponse> GetAsync(RequestOptions? options=null,CancellationToken cancellationToken=default)=>context.Call<GetPracticeTeamResponse>("getPracticeTeam",[],null,options,cancellationToken);
}
public sealed class TeamInvitationsSDKResource{private readonly SDKContext context;internal TeamInvitationsSDKResource(SDKContext context){this.context=context;}
public Task<InvitePracticeTeamPersonResponse> CreateAsync(TeamInvitationCreateParams parameters,RequestOptions? options=null,CancellationToken cancellationToken=default)=>context.Call<InvitePracticeTeamPersonResponse>("invitePracticeTeamPerson",[],parameters,options,cancellationToken);
public Task<ListPracticeTeamInvitationsResponse> ListAsync(TeamInvitationListParams parameters,RequestOptions? options=null,CancellationToken cancellationToken=default)=>context.Call<ListPracticeTeamInvitationsResponse>("listPracticeTeamInvitations",[],parameters,options,cancellationToken);
public IAsyncEnumerable<ListPracticeTeamInvitationsResponseDataItem> IterateAsync(TeamInvitationListParams parameters,RequestOptions? options=null,CancellationToken cancellationToken=default)=>context.Iterate<ListPracticeTeamInvitationsResponseDataItem>("listPracticeTeamInvitations",[],parameters,options,cancellationToken);
public Task<GetPracticeTeamInvitationResponse> GetAsync(string invitationId,RequestOptions? options=null,CancellationToken cancellationToken=default)=>context.Call<GetPracticeTeamInvitationResponse>("getPracticeTeamInvitation",[invitationId],null,options,cancellationToken);
public Task<RevokePracticeTeamInvitationResponse> RevokeAsync(string invitationId,RequestOptions? options=null,CancellationToken cancellationToken=default)=>context.Call<RevokePracticeTeamInvitationResponse>("revokePracticeTeamInvitation",[invitationId],null,options,cancellationToken);
public Task<ResendPracticeTeamInvitationResponse> ResendAsync(string invitationId,RequestOptions? options=null,CancellationToken cancellationToken=default)=>context.Call<ResendPracticeTeamInvitationResponse>("resendPracticeTeamInvitation",[invitationId],null,options,cancellationToken);
}
public sealed class TeamMembersSDKResource{private readonly SDKContext context;internal TeamMembersSDKResource(SDKContext context){this.context=context;}
public Task<ListPracticeTeamMembersResponse> ListAsync(TeamMemberListParams parameters,RequestOptions? options=null,CancellationToken cancellationToken=default)=>context.Call<ListPracticeTeamMembersResponse>("listPracticeTeamMembers",[],parameters,options,cancellationToken);
public IAsyncEnumerable<ListPracticeTeamMembersResponseDataItem> IterateAsync(TeamMemberListParams parameters,RequestOptions? options=null,CancellationToken cancellationToken=default)=>context.Iterate<ListPracticeTeamMembersResponseDataItem>("listPracticeTeamMembers",[],parameters,options,cancellationToken);
public Task<GetPracticeTeamMemberResponse> GetAsync(string memberId,RequestOptions? options=null,CancellationToken cancellationToken=default)=>context.Call<GetPracticeTeamMemberResponse>("getPracticeTeamMember",[memberId],null,options,cancellationToken);
public Task<UpdatePracticeTeamMemberResponse> UpdateAsync(string memberId,TeamMemberUpdateParams parameters,RequestOptions? options=null,CancellationToken cancellationToken=default)=>context.Call<UpdatePracticeTeamMemberResponse>("updatePracticeTeamMember",[memberId],parameters,options,cancellationToken);
}
public sealed class TeamPrescribersSDKResource{private readonly SDKContext context;internal TeamPrescribersSDKResource(SDKContext context){this.context=context;}
public TeamPrescribersLicensesSDKResource Licenses=>new(context);
public Task<ListPracticeTeamPrescribersResponse> ListAsync(TeamPrescriberListParams parameters,RequestOptions? options=null,CancellationToken cancellationToken=default)=>context.Call<ListPracticeTeamPrescribersResponse>("listPracticeTeamPrescribers",[],parameters,options,cancellationToken);
public IAsyncEnumerable<ListPracticeTeamPrescribersResponseDataItem> IterateAsync(TeamPrescriberListParams parameters,RequestOptions? options=null,CancellationToken cancellationToken=default)=>context.Iterate<ListPracticeTeamPrescribersResponseDataItem>("listPracticeTeamPrescribers",[],parameters,options,cancellationToken);
public Task<GetPracticeTeamPrescriberResponse> GetAsync(string prescriberId,RequestOptions? options=null,CancellationToken cancellationToken=default)=>context.Call<GetPracticeTeamPrescriberResponse>("getPracticeTeamPrescriber",[prescriberId],null,options,cancellationToken);
public Task<UpdatePracticeTeamPrescriberResponse> UpdateAsync(string prescriberId,TeamPrescriberUpdateParams parameters,RequestOptions? options=null,CancellationToken cancellationToken=default)=>context.Call<UpdatePracticeTeamPrescriberResponse>("updatePracticeTeamPrescriber",[prescriberId],parameters,options,cancellationToken);
}
public sealed class TeamPrescribersLicensesSDKResource{private readonly SDKContext context;internal TeamPrescribersLicensesSDKResource(SDKContext context){this.context=context;}
public Task<CreatePracticeTeamLicenseResponse> CreateAsync(string prescriberId,TeamPrescriberLicenseCreateParams parameters,RequestOptions? options=null,CancellationToken cancellationToken=default)=>context.Call<CreatePracticeTeamLicenseResponse>("createPracticeTeamLicense",[prescriberId],parameters,options,cancellationToken);
public Task<UpdatePracticeTeamLicenseResponse> UpdateAsync(string prescriberId,string licenseId,TeamPrescriberLicenseUpdateParams parameters,RequestOptions? options=null,CancellationToken cancellationToken=default)=>context.Call<UpdatePracticeTeamLicenseResponse>("updatePracticeTeamLicense",[prescriberId,licenseId],parameters,options,cancellationToken);
}
public sealed class WebhooksSDKResource{private readonly SDKContext context;internal WebhooksSDKResource(SDKContext context){this.context=context;}
public WebhooksEndpointsSDKResource Endpoints=>new(context);
public WebhooksEventsSDKResource Events=>new(context);
public WebhooksGrantsSDKResource Grants=>new(context);
}
public sealed class WebhooksEndpointsSDKResource{private readonly SDKContext context;internal WebhooksEndpointsSDKResource(SDKContext context){this.context=context;}
public Task<ListWebhookEndpointsResponse> ListAsync(WebhookEndpointListParams parameters,RequestOptions? options=null,CancellationToken cancellationToken=default)=>context.Call<ListWebhookEndpointsResponse>("listWebhookEndpoints",[],parameters,options,cancellationToken);
public IAsyncEnumerable<ListWebhookEndpointsResponseDataItem> IterateAsync(WebhookEndpointListParams parameters,RequestOptions? options=null,CancellationToken cancellationToken=default)=>context.Iterate<ListWebhookEndpointsResponseDataItem>("listWebhookEndpoints",[],parameters,options,cancellationToken);
public Task<CreateWebhookEndpointResponse> CreateAsync(WebhookEndpointCreateParams parameters,RequestOptions? options=null,CancellationToken cancellationToken=default)=>context.Call<CreateWebhookEndpointResponse>("createWebhookEndpoint",[],parameters,options,cancellationToken);
public Task<UpdateWebhookEndpointResponse> UpdateAsync(string endpointId,WebhookEndpointUpdateParams parameters,RequestOptions? options=null,CancellationToken cancellationToken=default)=>context.Call<UpdateWebhookEndpointResponse>("updateWebhookEndpoint",[endpointId],parameters,options,cancellationToken);
public Task<DeleteWebhookEndpointResponse> DeleteAsync(string endpointId,RequestOptions? options=null,CancellationToken cancellationToken=default)=>context.Call<DeleteWebhookEndpointResponse>("deleteWebhookEndpoint",[endpointId],null,options,cancellationToken);
public Task<RotateWebhookEndpointSecretResponse> RotateSecretAsync(string endpointId,RequestOptions? options=null,CancellationToken cancellationToken=default)=>context.Call<RotateWebhookEndpointSecretResponse>("rotateWebhookEndpointSecret",[endpointId],null,options,cancellationToken);
public Task<TestWebhookEndpointResponse> TestAsync(string endpointId,RequestOptions? options=null,CancellationToken cancellationToken=default)=>context.Call<TestWebhookEndpointResponse>("testWebhookEndpoint",[endpointId],null,options,cancellationToken);
}
public sealed class WebhooksEventsSDKResource{private readonly SDKContext context;internal WebhooksEventsSDKResource(SDKContext context){this.context=context;}
public Task<ListWebhookEventsResponse> ListAsync(WebhookEventListParams parameters,RequestOptions? options=null,CancellationToken cancellationToken=default)=>context.Call<ListWebhookEventsResponse>("listWebhookEvents",[],parameters,options,cancellationToken);
public IAsyncEnumerable<ListWebhookEventsResponseDataItem> IterateAsync(WebhookEventListParams parameters,RequestOptions? options=null,CancellationToken cancellationToken=default)=>context.Iterate<ListWebhookEventsResponseDataItem>("listWebhookEvents",[],parameters,options,cancellationToken);
public Task<GetWebhookEventResponse> GetAsync(string eventId,RequestOptions? options=null,CancellationToken cancellationToken=default)=>context.Call<GetWebhookEventResponse>("getWebhookEvent",[eventId],null,options,cancellationToken);
public Task<ReplayWebhookEventResponse> ReplayAsync(string eventId,RequestOptions? options=null,CancellationToken cancellationToken=default)=>context.Call<ReplayWebhookEventResponse>("replayWebhookEvent",[eventId],null,options,cancellationToken);
}
public sealed class WebhooksGrantsSDKResource{private readonly SDKContext context;internal WebhooksGrantsSDKResource(SDKContext context){this.context=context;}
public Task<ListWebhookGrantsResponse> ListAsync(WebhookGrantListParams parameters,RequestOptions? options=null,CancellationToken cancellationToken=default)=>context.Call<ListWebhookGrantsResponse>("listWebhookGrants",[],parameters,options,cancellationToken);
public IAsyncEnumerable<ListWebhookGrantsResponseDataItem> IterateAsync(WebhookGrantListParams parameters,RequestOptions? options=null,CancellationToken cancellationToken=default)=>context.Iterate<ListWebhookGrantsResponseDataItem>("listWebhookGrants",[],parameters,options,cancellationToken);
public Task<SaveWebhookGrantResponse> SaveAsync(string platformId,WebhookGrantSaveParams parameters,RequestOptions? options=null,CancellationToken cancellationToken=default)=>context.Call<SaveWebhookGrantResponse>("saveWebhookGrant",[platformId],parameters,options,cancellationToken);
public Task<RevokeWebhookGrantResponse> RevokeAsync(string platformId,RequestOptions? options=null,CancellationToken cancellationToken=default)=>context.Call<RevokeWebhookGrantResponse>("revokeWebhookGrant",[platformId],null,options,cancellationToken);
}
public sealed class AffinityClient{private readonly SDKContext context;public AffinityClient(string apiKey,ClientOptions? options=null){options??=new ClientOptions{HttpClient=new HttpClient(new HttpClientHandler{AllowAutoRedirect=false})};context=new(new SDKTransport(apiKey,options));}private AffinityClient(SDKContext context){this.context=context;}public AffinityClient ForPractice(string practiceId){if(string.IsNullOrWhiteSpace(practiceId))throw new ArgumentException("practiceId is required");if(context.PracticeId!=null&&context.PracticeId!=practiceId)throw new ArgumentException("Conflicting practice ID");return new(new SDKContext(context.Transport,practiceId));}public AccountSDKResource Account=>new(context);
public ApiKeysSDKResource ApiKeys=>new(context);
public CatalogSDKResource Catalog=>new(context);
public LocationsSDKResource Locations=>new(context);
public OrdersSDKResource Orders=>new(context);
public PatientsSDKResource Patients=>new(context);
public PharmaciesSDKResource Pharmacies=>new(context);
public PracticesSDKResource Practices=>new(context);
public TeamSDKResource Team=>new(context);
public WebhooksSDKResource Webhooks=>new(context);}
