using Affinity;
using Affinity.Test.Unit.MockServer;
using Affinity.Test.Utils;
using NUnit.Framework;

namespace Affinity.Test.Unit.MockServer.Orders;

[TestFixture]
[Parallelizable(ParallelScope.Self)]
public class ListOrderEventsTest : BaseMockServerTest
{
    [NUnit.Framework.Test]
    public async Task MockServerTest_1()
    {
        const string mockResponse = """
            {
              "data": [
                {
                  "createdAt": "createdAt",
                  "eventType": "eventType",
                  "id": "id",
                  "message": "message",
                  "metadata": {
                    "metadata": {
                      "key": "value"
                    }
                  },
                  "object": "event"
                },
                {
                  "createdAt": "createdAt",
                  "eventType": "eventType",
                  "id": "id",
                  "message": "message",
                  "metadata": {
                    "metadata": {
                      "key": "value"
                    }
                  },
                  "object": "event"
                }
              ],
              "hasMore": true,
              "object": "list",
              "url": "url"
            }
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/v1/orders/orderId/events")
                    .UsingGet()
            )
            .RespondWith(
                WireMock
                    .ResponseBuilders.Response.Create()
                    .WithStatusCode(200)
                    .WithBody(mockResponse)
            );

        var response = await Client.Orders.ListOrderEventsAsync(
            new ListOrderEventsRequest { OrderId = "orderId" }
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
                  "createdAt": "createdAt",
                  "eventType": "eventType",
                  "id": "evt_01j2y8m6jcc9tt24af5pw9x1bc",
                  "message": "message",
                  "metadata": {
                    "key": "value"
                  },
                  "object": "event"
                }
              ],
              "hasMore": true,
              "object": "list",
              "url": "url"
            }
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/v1/orders/ord_01j2y8m6jcc9tt24af5pw9x1bc/events")
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

        var response = await Client.Orders.ListOrderEventsAsync(
            new ListOrderEventsRequest
            {
                OrderId = "ord_01j2y8m6jcc9tt24af5pw9x1bc",
                EndingBefore = "evt_01j2y8m6jcc9tt24af5pw9x1bc",
                StartingAfter = "evt_01j2y8m6jcc9tt24af5pw9x1bc",
            }
        );
        JsonAssert.AreEqual(response, mockResponse);
    }
}
