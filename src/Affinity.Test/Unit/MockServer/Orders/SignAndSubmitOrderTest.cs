using Affinity;
using Affinity.Test.Unit.MockServer;
using Affinity.Test.Utils;
using NUnit.Framework;

namespace Affinity.Test.Unit.MockServer.Orders;

[TestFixture]
[Parallelizable(ParallelScope.Self)]
public class SignAndSubmitOrderTest : BaseMockServerTest
{
    [NUnit.Framework.Test]
    public async Task MockServerTest_1()
    {
        const string requestJson = """
            {
              "practiceId": "practiceId",
              "signatureAttestation": true
            }
            """;

        const string mockResponse = """
            {
              "object": "order_sign_and_submission",
              "orderId": "orderId",
              "signedAt": "signedAt",
              "status": "submitted",
              "prescriptions": [
                {
                  "prescriptionId": "prescriptionId",
                  "status": "submitted",
                  "fulfillmentOrderId": "fulfillmentOrderId",
                  "error": {
                    "code": "code",
                    "detail": "detail",
                    "status": "Infinity"
                  }
                },
                {
                  "prescriptionId": "prescriptionId",
                  "status": "submitted",
                  "fulfillmentOrderId": "fulfillmentOrderId",
                  "error": {
                    "code": "code",
                    "detail": "detail",
                    "status": "Infinity"
                  }
                }
              ]
            }
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/v1/orders/orderId/sign-and-submit")
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

        var response = await Client.Orders.SignAndSubmitOrderAsync(
            new SignAndSubmitOrderRequest
            {
                OrderId = "orderId",
                IdempotencyKey = "idempotencyKey",
                PracticeId = "practiceId",
                UserId = null,
                Prescriber = null,
                SignatureAttestation = true,
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
              "signatureAttestation": true
            }
            """;

        const string mockResponse = """
            {
              "object": "order_sign_and_submission",
              "orderId": "ord_01j2y8m6jcc9tt24af5pw9x1bc",
              "signedAt": "signedAt",
              "status": "submitted",
              "prescriptions": [
                {
                  "prescriptionId": "rx_01j2y8m6jcc9tt24af5pw9x1bc",
                  "status": "submitted",
                  "fulfillmentOrderId": "ord_01j2y8m6jcc9tt24af5pw9x1bc",
                  "error": {
                    "code": "code",
                    "detail": "detail",
                    "status": "Infinity"
                  }
                }
              ]
            }
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/v1/orders/ord_01j2y8m6jcc9tt24af5pw9x1bc/sign-and-submit")
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

        var response = await Client.Orders.SignAndSubmitOrderAsync(
            new SignAndSubmitOrderRequest
            {
                OrderId = "ord_01j2y8m6jcc9tt24af5pw9x1bc",
                IdempotencyKey = "Idempotency-Key",
                PracticeId = "prac_01j2y8m6jcc9tt24af5pw9x1bc",
                SignatureAttestation = true,
            }
        );
        JsonAssert.AreEqual(response, mockResponse);
    }
}
