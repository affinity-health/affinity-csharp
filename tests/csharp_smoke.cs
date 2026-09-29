using Affinity;
using System.Net;
using System.Text;
using System.Text.Json;

var handler = new MockTransport();
var client = new AffinityClient(apiKey: "synthetic-key", affinityVersion: "2026-09-28", clientOptions: new ClientOptions { BaseUrl = "https://sdk-test.invalid", HttpClient = new HttpClient(handler), MaxRetries = 0 });
var page = await client.Orders.ListOrdersAsync(new ListOrdersRequest { Limit = 2, StartingAfter = "ord_cursor" });
if (page.Data.Any() || page.HasMore) throw new Exception("response");
bool failed = false;
try { await client.Orders.CreateOrderAsync(new CreateOrderRequest { IdempotencyKey = "stable-synthetic-key", PracticeId = "prac_synthetic", PatientId = "pat_synthetic", Prescriptions = [] }); }
catch (Exception e) when (e.GetType().Namespace?.StartsWith("Affinity") == true) { failed = true; }
if (!failed || handler.Count != 2) throw new Exception("error handling or retries");
Console.WriteLine("C# transport and decoding checks passed");
class MockTransport : HttpMessageHandler {
    public int Count;
    protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken) {
        Count++;
        if (request.Headers.GetValues("x-affinity-api-key").Single() != "synthetic-key") throw new Exception("auth");
        if (request.Headers.GetValues("Affinity-Version").Single() != "2026-09-28") throw new Exception("version");
        if (request.RequestUri!.AbsolutePath != "/v1/orders") throw new Exception("path");
        if (request.Method == HttpMethod.Get) {
            if (!request.RequestUri.Query.Contains("limit=2") || !request.RequestUri.Query.Contains("startingAfter=ord_cursor")) throw new Exception("query");
            return new HttpResponseMessage(HttpStatusCode.OK) { Content = new StringContent("{\"object\":\"list\",\"data\":[],\"hasMore\":false,\"url\":\"/v1/orders\"}", Encoding.UTF8, "application/json") };
        }
        if (request.Headers.GetValues("Idempotency-Key").Single() != "stable-synthetic-key") throw new Exception("idempotency");
        var body = JsonDocument.Parse(await request.Content!.ReadAsStringAsync(cancellationToken));
        if (body.RootElement.GetProperty("practiceId").GetString() != "prac_synthetic") throw new Exception("body");
        return new HttpResponseMessage(HttpStatusCode.UnprocessableEntity) { Content = new StringContent("{\"title\":\"Synthetic failure\",\"status\":422}", Encoding.UTF8, "application/json") };
    }
}
