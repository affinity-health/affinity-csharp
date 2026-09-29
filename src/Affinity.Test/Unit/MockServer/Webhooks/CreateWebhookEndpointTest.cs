using Affinity;
using Affinity.Test.Unit.MockServer;
using Affinity.Test.Utils;
using NUnit.Framework;

namespace Affinity.Test.Unit.MockServer.Webhooks;

[TestFixture]
[Parallelizable(ParallelScope.Self)]
public class CreateWebhookEndpointTest : BaseMockServerTest
{
    [NUnit.Framework.Test]
    public async Task MockServerTest_1()
    {
        const string requestJson = """
            {
              "url": "url"
            }
            """;

        const string mockResponse = """
            {
              "organizationId": "organizationId",
              "practiceIds": [
                "practiceIds",
                "practiceIds"
              ],
              "apiVersion": "apiVersion",
              "consecutiveFailures": 1,
              "createdAt": "createdAt",
              "description": "description",
              "id": "id",
              "livemode": true,
              "object": "webhook_endpoint",
              "payloadStyle": "thin",
              "status": "active",
              "subscribedEvents": [
                "subscribedEvents",
                "subscribedEvents"
              ],
              "updatedAt": "updatedAt",
              "url": "url",
              "signingSecret": "signingSecret"
            }
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/v1/webhook-endpoints")
                    .WithHeader("Idempotency-Key", "idempotencyKey")
                    .WithHeader("Content-Type", "application/json")
                    .UsingPost()
                    .WithBodyAsJson(requestJson)
            )
            .RespondWith(
                WireMock
                    .ResponseBuilders.Response.Create()
                    .WithStatusCode(200)
                    .WithBody(mockResponse)
            );

        var response = await Client.Webhooks.CreateWebhookEndpointAsync(
            new CreateWebhookEndpointRequest
            {
                IdempotencyKey = "idempotencyKey",
                PracticeIds = null,
                Description = null,
                PayloadStyle = null,
                SubscribedEvents = null,
                Url = "url",
            }
        );
        JsonAssert.AreEqual(response, mockResponse);
    }

    [NUnit.Framework.Test]
    public async Task MockServerTest_2()
    {
        const string requestJson = """
            {
              "url": "url"
            }
            """;

        const string mockResponse = """
            {
              "organizationId": "acct_01j2y8m6jcc9tt24af5pw9x1bc",
              "practiceIds": [
                "practiceIds"
              ],
              "apiVersion": "apiVersion",
              "consecutiveFailures": 1,
              "createdAt": "createdAt",
              "description": "description",
              "id": "whe_01j2y8m6jcc9tt24af5pw9x1bc",
              "livemode": true,
              "object": "webhook_endpoint",
              "payloadStyle": "thin",
              "status": "active",
              "subscribedEvents": [
                "subscribedEvents"
              ],
              "updatedAt": "updatedAt",
              "url": "url",
              "signingSecret": "signingSecret"
            }
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/v1/webhook-endpoints")
                    .WithHeader("Idempotency-Key", "Idempotency-Key")
                    .WithHeader("Content-Type", "application/json")
                    .UsingPost()
                    .WithBodyAsJson(requestJson)
            )
            .RespondWith(
                WireMock
                    .ResponseBuilders.Response.Create()
                    .WithStatusCode(200)
                    .WithBody(mockResponse)
            );

        var response = await Client.Webhooks.CreateWebhookEndpointAsync(
            new CreateWebhookEndpointRequest { IdempotencyKey = "Idempotency-Key", Url = "url" }
        );
        JsonAssert.AreEqual(response, mockResponse);
    }
}
