using Affinity;
using Affinity.Test.Unit.MockServer;
using Affinity.Test.Utils;
using NUnit.Framework;

namespace Affinity.Test.Unit.MockServer.Webhooks;

[TestFixture]
[Parallelizable(ParallelScope.Self)]
public class TestWebhookEndpointTest : BaseMockServerTest
{
    [NUnit.Framework.Test]
    public async Task MockServerTest_1()
    {
        const string mockResponse = """
            {
              "eventId": "eventId"
            }
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/v1/webhook-endpoints/endpointId/test")
                    .WithHeader("Idempotency-Key", "idempotencyKey")
                    .UsingPost()
            )
            .RespondWith(
                WireMock
                    .ResponseBuilders.Response.Create()
                    .WithStatusCode(200)
                    .WithBody(mockResponse)
            );

        var response = await Client.Webhooks.TestWebhookEndpointAsync(
            new TestWebhookEndpointRequest
            {
                EndpointId = "endpointId",
                IdempotencyKey = "idempotencyKey",
            }
        );
        JsonAssert.AreEqual(response, mockResponse);
    }

    [NUnit.Framework.Test]
    public async Task MockServerTest_2()
    {
        const string mockResponse = """
            {
              "eventId": "eventId"
            }
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/v1/webhook-endpoints/whe_01j2y8m6jcc9tt24af5pw9x1bc/test")
                    .WithHeader("Idempotency-Key", "Idempotency-Key")
                    .UsingPost()
            )
            .RespondWith(
                WireMock
                    .ResponseBuilders.Response.Create()
                    .WithStatusCode(200)
                    .WithBody(mockResponse)
            );

        var response = await Client.Webhooks.TestWebhookEndpointAsync(
            new TestWebhookEndpointRequest
            {
                EndpointId = "whe_01j2y8m6jcc9tt24af5pw9x1bc",
                IdempotencyKey = "Idempotency-Key",
            }
        );
        JsonAssert.AreEqual(response, mockResponse);
    }
}
