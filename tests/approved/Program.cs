using Affinity;
using System.Text.Json;
static void Check(bool condition,string message){if(!condition)throw new Exception(message);}
var baseUrl="http://127.0.0.1:5199/csharp-practice-retry";
using var http=new HttpClient(new HttpClientHandler{AllowAutoRedirect=false});await http.GetStringAsync(baseUrl+"/reset");
var api=new AffinityClient("test",new ClientOptions{BaseUrl=baseUrl,MaxRetries=1,HttpClient=http});
var patient=await api.Patients.CreateAsync(new PatientCreateParams{Name=new PatientName{First="Alex",Last="Example"},DateOfBirth="1990-01-01"});Check(patient.Id=="pat_a","patient");
await api.Patients.UpdateAsync(patient.Id,new PatientUpdateParams{Email=null});await api.Patients.DeleteAsync(patient.Id);
var ids=new List<string>();await foreach(var p in api.Patients.IterateAsync(new PatientListParams{Limit=1,Query="Alex"}))ids.Add(p.Id);Check(ids.SequenceEqual(new[]{"pat_a","pat_b"}),"pagination");
try{await api.Patients.GetAsync("pat_a",new RequestOptions{PracticeId="prac_b"});throw new Exception("mismatch accepted");}catch(ArgumentException){}
try{await api.Orders.SubmitAsync("ord_a");throw new Exception("missing key accepted");}catch(ArgumentException){}
await api.Orders.SignAsync("ord_a",new OrderSignParams{Prescriber=new PrescriberSelector{Id="prov_a"},ExpectedRevision="rev_reviewed",SignatureAttestation=true},new RequestOptions{IdempotencyKey="sign_job"});
await api.Orders.SubmitAsync("ord_a",new RequestOptions{IdempotencyKey="submit_job"});
try{await api.Patients.GetAsync("pat_error");throw new Exception("missing error");}catch(AffinityException e){Check(e.Status==429&&e.Code=="rate_limited"&&e.RequestId=="req_a"&&e.RetryAfter==0&&e.Retryable,"error fields");Check(!e.Message.Contains("private"),"private error");}
var trace=JsonSerializer.Deserialize<JsonElement>(await http.GetStringAsync(baseUrl+"/trace"));var access=0;var keys=new List<string>();foreach(var r in trace.EnumerateArray()){if(r.GetProperty("path").GetString()=="/v1/auth/access")access++;if(r.GetProperty("method").GetString()=="PATCH"){keys.Add(r.GetProperty("key").GetString()!);Check(r.GetProperty("body").GetProperty("email").ValueKind==JsonValueKind.Null,"explicit null");}}Check(access==1&&keys.Count==2&&keys[0]==keys[1],"identity cache and retry keys");
using var cancellation=new CancellationTokenSource();cancellation.Cancel();try{await api.Patients.GetAsync("pat_a",cancellationToken:cancellation.Token);throw new Exception("missing cancellation");}catch(OperationCanceledException){}
Console.WriteLine("C# approved interface passed");
