using Affinity;
using Affinity.Test.Unit.MockServer;
using Affinity.Test.Utils;
using NUnit.Framework;

namespace Affinity.Test.Unit.MockServer.Webhooks;

[TestFixture]
[Parallelizable(ParallelScope.Self)]
public class ListWebhookEventsTest : BaseMockServerTest
{
    [NUnit.Framework.Test]
    public async Task MockServerTest_1()
    {
        const string mockResponse = """
            {
              "data": [
                {
                  "apiVersion": "apiVersion",
                  "createdAt": "createdAt",
                  "eventType": "eventType",
                  "id": "id",
                  "livemode": true,
                  "object": "webhook_event",
                  "resourceId": "resourceId",
                  "resourceType": "resourceType",
                  "status": "delivered"
                },
                {
                  "apiVersion": "apiVersion",
                  "createdAt": "createdAt",
                  "eventType": "eventType",
                  "id": "id",
                  "livemode": true,
                  "object": "webhook_event",
                  "resourceId": "resourceId",
                  "resourceType": "resourceType",
                  "status": "delivered"
                }
              ],
              "hasMore": true,
              "object": "list",
              "url": "/v1/webhook-events"
            }
            """;

        Server
            .Given(
                WireMock.RequestBuilders.Request.Create().WithPath("/v1/webhook-events").UsingGet()
            )
            .RespondWith(
                WireMock
                    .ResponseBuilders.Response.Create()
                    .WithStatusCode(200)
                    .WithBody(mockResponse)
            );

        var response = await Client.Webhooks.ListWebhookEventsAsync(new ListWebhookEventsRequest());
        JsonAssert.AreEqual(response, mockResponse);
    }

    [NUnit.Framework.Test]
    public async Task MockServerTest_2()
    {
        const string mockResponse = """
            {
              "data": [
                {
                  "apiVersion": "apiVersion",
                  "createdAt": "createdAt",
                  "eventType": "eventType",
                  "id": "evt_01j2y8m6jcc9tt24af5pw9x1bc",
                  "livemode": true,
                  "object": "webhook_event",
                  "resourceId": "resourceId",
                  "resourceType": "resourceType",
                  "status": "delivered"
                }
              ],
              "hasMore": true,
              "object": "list",
              "url": "/v1/webhook-events"
            }
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/v1/webhook-events")
                    .WithParam("endingBefore", "evt_01j2y8m6jcc9tt24af5pw9x1bc")
                    .WithParam("startingAfter", "evt_01j2y8m6jcc9tt24af5pw9x1bc")
                    .UsingGet()
            )
            .RespondWith(
                WireMock
                    .ResponseBuilders.Response.Create()
                    .WithStatusCode(200)
                    .WithBody(mockResponse)
            );

        var response = await Client.Webhooks.ListWebhookEventsAsync(
            new ListWebhookEventsRequest
            {
                EndingBefore = "evt_01j2y8m6jcc9tt24af5pw9x1bc",
                StartingAfter = "evt_01j2y8m6jcc9tt24af5pw9x1bc",
            }
        );
        JsonAssert.AreEqual(response, mockResponse);
    }
}
