using Affinity;
using Affinity.Test.Unit.MockServer;
using Affinity.Test.Utils;
using NUnit.Framework;

namespace Affinity.Test.Unit.MockServer.Orders;

[TestFixture]
[Parallelizable(ParallelScope.Self)]
public class ActOnOrderExceptionTest : BaseMockServerTest
{
    [NUnit.Framework.Test]
    public async Task MockServerTest_1()
    {
        const string requestJson = """
            {
              "action": "acknowledge"
            }
            """;

        const string mockResponse = """
            {
              "action": "action",
              "exceptionId": "exceptionId",
              "status": "open"
            }
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/v1/orders/orderId/exceptions/exceptionId/actions")
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

        var response = await Client.Orders.ActOnOrderExceptionAsync(
            new ActOnOrderExceptionRequest
            {
                OrderId = "orderId",
                ExceptionId = "exceptionId",
                IdempotencyKey = "idempotencyKey",
                Action = ActOnOrderExceptionRequestAction.Acknowledge,
                Note = null,
            }
        );
        JsonAssert.AreEqual(response, mockResponse);
    }

    [NUnit.Framework.Test]
    public async Task MockServerTest_2()
    {
        const string requestJson = """
            {
              "action": "acknowledge"
            }
            """;

        const string mockResponse = """
            {
              "action": "action",
              "exceptionId": "fex_01j2y8m6jcc9tt24af5pw9x1bc",
              "status": "open"
            }
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath(
                        "/v1/orders/ord_01j2y8m6jcc9tt24af5pw9x1bc/exceptions/fex_01j2y8m6jcc9tt24af5pw9x1bc/actions"
                    )
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

        var response = await Client.Orders.ActOnOrderExceptionAsync(
            new ActOnOrderExceptionRequest
            {
                OrderId = "ord_01j2y8m6jcc9tt24af5pw9x1bc",
                ExceptionId = "fex_01j2y8m6jcc9tt24af5pw9x1bc",
                IdempotencyKey = "Idempotency-Key",
                Action = ActOnOrderExceptionRequestAction.Acknowledge,
            }
        );
        JsonAssert.AreEqual(response, mockResponse);
    }
}
