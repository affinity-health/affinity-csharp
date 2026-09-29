using Affinity;
using Affinity.Test.Unit.MockServer;
using Affinity.Test.Utils;
using NUnit.Framework;

namespace Affinity.Test.Unit.MockServer.Webhooks;

[TestFixture]
[Parallelizable(ParallelScope.Self)]
public class ListWebhookEndpointsTest : BaseMockServerTest
{
    [NUnit.Framework.Test]
    public async Task MockServerTest_1()
    {
        const string mockResponse = """
            {
              "data": [
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
                  "url": "url"
                },
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
                  "url": "url"
                }
              ],
              "hasMore": true,
              "object": "list",
              "url": "/v1/webhook-endpoints"
            }
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/v1/webhook-endpoints")
                    .UsingGet()
            )
            .RespondWith(
                WireMock
                    .ResponseBuilders.Response.Create()
                    .WithStatusCode(200)
                    .WithBody(mockResponse)
            );

        var response = await Client.Webhooks.ListWebhookEndpointsAsync(
            new ListWebhookEndpointsRequest()
        );
        JsonAssert.AreEqual(response, mockResponse);
    }

    [NUnit.Framework.Test]
    public async Task MockServerTest_2()
    {
        const string mockResponse = """
            {
              "data": [
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
                  "url": "url"
                }
              ],
              "hasMore": true,
              "object": "list",
              "url": "/v1/webhook-endpoints"
            }
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/v1/webhook-endpoints")
                    .WithParam("endingBefore", "whe_01j2y8m6jcc9tt24af5pw9x1bc")
                    .WithParam("startingAfter", "whe_01j2y8m6jcc9tt24af5pw9x1bc")
                    .UsingGet()
            )
            .RespondWith(
                WireMock
                    .ResponseBuilders.Response.Create()
                    .WithStatusCode(200)
                    .WithBody(mockResponse)
            );

        var response = await Client.Webhooks.ListWebhookEndpointsAsync(
            new ListWebhookEndpointsRequest
            {
                EndingBefore = "whe_01j2y8m6jcc9tt24af5pw9x1bc",
                StartingAfter = "whe_01j2y8m6jcc9tt24af5pw9x1bc",
            }
        );
        JsonAssert.AreEqual(response, mockResponse);
    }
}
