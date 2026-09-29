using Affinity;
using Affinity.Test.Unit.MockServer;
using Affinity.Test.Utils;
using NUnit.Framework;

namespace Affinity.Test.Unit.MockServer.Orders;

[TestFixture]
[Parallelizable(ParallelScope.Self)]
public class RejectOrderTest : BaseMockServerTest
{
    [NUnit.Framework.Test]
    public async Task MockServerTest_1()
    {
        const string requestJson = """
            {
              "practiceId": "practiceId",
              "reason": "reason"
            }
            """;

        const string mockResponse = """
            {
              "orderId": "orderId",
              "rejectedAt": "rejectedAt",
              "reason": "reason",
              "status": "rejected"
            }
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/v1/orders/orderId/rejection")
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

        var response = await Client.Orders.RejectOrderAsync(
            new RejectOrderRequest
            {
                OrderId = "orderId",
                IdempotencyKey = "idempotencyKey",
                PracticeId = "practiceId",
                UserId = null,
                Prescriber = null,
                Reason = "reason",
                ExpectedRevision = null,
                ExpectedVersions = null,
            }
        );
        JsonAssert.AreEqual(response, mockResponse);
    }

    [NUnit.Framework.Test]
    public async Task MockServerTest_2()
    {
        const string requestJson = """
            {
              "practiceId": "prac_01j2y8m6jcc9tt24af5pw9x1bc",
              "reason": "reason"
            }
            """;

        const string mockResponse = """
            {
              "orderId": "ord_01j2y8m6jcc9tt24af5pw9x1bc",
              "rejectedAt": "rejectedAt",
              "reason": "reason",
              "status": "rejected"
            }
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/v1/orders/ord_01j2y8m6jcc9tt24af5pw9x1bc/rejection")
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

        var response = await Client.Orders.RejectOrderAsync(
            new RejectOrderRequest
            {
                OrderId = "ord_01j2y8m6jcc9tt24af5pw9x1bc",
                IdempotencyKey = "Idempotency-Key",
                PracticeId = "prac_01j2y8m6jcc9tt24af5pw9x1bc",
                Reason = "reason",
            }
        );
        JsonAssert.AreEqual(response, mockResponse);
    }
}
