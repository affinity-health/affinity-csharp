using Affinity;
using Affinity.Test.Unit.MockServer;
using Affinity.Test.Utils;
using NUnit.Framework;

namespace Affinity.Test.Unit.MockServer.Webhooks;

[TestFixture]
[Parallelizable(ParallelScope.Self)]
public class GetWebhookEventTest : BaseMockServerTest
{
    [NUnit.Framework.Test]
    public async Task MockServerTest_1()
    {
        const string mockResponse = """
            {
              "apiVersion": "apiVersion",
              "createdAt": "createdAt",
              "eventType": "eventType",
              "id": "id",
              "livemode": true,
              "object": "webhook_event",
              "resourceId": "resourceId",
              "resourceType": "resourceType",
              "status": "delivered",
              "attempts": [
                {
                  "deliveryId": "deliveryId",
                  "endpointId": "endpointId",
                  "attemptNumber": 1,
                  "completedAt": "completedAt",
                  "durationMs": "Infinity",
                  "errorCode": "errorCode",
                  "errorMessage": "errorMessage",
                  "id": "id",
                  "requestedAt": "requestedAt",
                  "responseStatus": "Infinity",
                  "trigger": "automatic"
                },
                {
                  "deliveryId": "deliveryId",
                  "endpointId": "endpointId",
                  "attemptNumber": 1,
                  "completedAt": "completedAt",
                  "durationMs": "Infinity",
                  "errorCode": "errorCode",
                  "errorMessage": "errorMessage",
                  "id": "id",
                  "requestedAt": "requestedAt",
                  "responseStatus": "Infinity",
                  "trigger": "automatic"
                }
              ],
              "deliveries": [
                {
                  "automaticAttemptCount": "Infinity",
                  "endpointId": "endpointId",
                  "id": "id",
                  "lastErrorCode": "lastErrorCode",
                  "lastErrorMessage": "lastErrorMessage",
                  "nextAttemptAt": "nextAttemptAt",
                  "status": "delivered"
                },
                {
                  "automaticAttemptCount": "Infinity",
                  "endpointId": "endpointId",
                  "id": "id",
                  "lastErrorCode": "lastErrorCode",
                  "lastErrorMessage": "lastErrorMessage",
                  "nextAttemptAt": "nextAttemptAt",
                  "status": "delivered"
                }
              ],
              "payload": {
                "payload": {
                  "key": "value"
                }
              }
            }
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/v1/webhook-events/eventId")
                    .UsingGet()
            )
            .RespondWith(
                WireMock
                    .ResponseBuilders.Response.Create()
                    .WithStatusCode(200)
                    .WithBody(mockResponse)
            );

        var response = await Client.Webhooks.GetWebhookEventAsync(
            new GetWebhookEventRequest { EventId = "eventId" }
        );
        JsonAssert.AreEqual(response, mockResponse);
    }

    [NUnit.Framework.Test]
    public async Task MockServerTest_2()
    {
        const string mockResponse = """
            {
              "apiVersion": "apiVersion",
              "createdAt": "createdAt",
              "eventType": "eventType",
              "id": "evt_01j2y8m6jcc9tt24af5pw9x1bc",
              "livemode": true,
              "object": "webhook_event",
              "resourceId": "resourceId",
              "resourceType": "resourceType",
              "status": "delivered",
              "attempts": [
                {
                  "deliveryId": "deliveryId",
                  "endpointId": "endpointId",
                  "attemptNumber": 1,
                  "completedAt": "completedAt",
                  "durationMs": "Infinity",
                  "errorCode": "errorCode",
                  "errorMessage": "errorMessage",
                  "id": "id",
                  "requestedAt": "requestedAt",
                  "responseStatus": "Infinity",
                  "trigger": "automatic"
                }
              ],
              "deliveries": [
                {
                  "automaticAttemptCount": "Infinity",
                  "endpointId": "endpointId",
                  "id": "id",
                  "lastErrorCode": "lastErrorCode",
                  "lastErrorMessage": "lastErrorMessage",
                  "nextAttemptAt": "nextAttemptAt",
                  "status": "delivered"
                }
              ],
              "payload": {
                "key": "value"
              }
            }
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/v1/webhook-events/evt_01j2y8m6jcc9tt24af5pw9x1bc")
                    .UsingGet()
            )
            .RespondWith(
                WireMock
                    .ResponseBuilders.Response.Create()
                    .WithStatusCode(200)
                    .WithBody(mockResponse)
            );

        var response = await Client.Webhooks.GetWebhookEventAsync(
            new GetWebhookEventRequest { EventId = "evt_01j2y8m6jcc9tt24af5pw9x1bc" }
        );
        JsonAssert.AreEqual(response, mockResponse);
    }
}
