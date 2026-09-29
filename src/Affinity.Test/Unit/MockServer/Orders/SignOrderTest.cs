using Affinity;
using Affinity.Test.Unit.MockServer;
using Affinity.Test.Utils;
using NUnit.Framework;

namespace Affinity.Test.Unit.MockServer.Orders;

[TestFixture]
[Parallelizable(ParallelScope.Self)]
public class SignOrderTest : BaseMockServerTest
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
              "orderId": "orderId",
              "prescriptions": [
                "prescriptions",
                "prescriptions"
              ],
              "signedAt": "signedAt",
              "status": "ready"
            }
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/v1/orders/orderId/sign")
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

        var response = await Client.Orders.SignOrderAsync(
            new SignOrderRequest
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
              "orderId": "ord_01j2y8m6jcc9tt24af5pw9x1bc",
              "prescriptions": [
                "rx_01j2y8m6jcc9tt24af5pw9x1bc"
              ],
              "signedAt": "signedAt",
              "status": "ready"
            }
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/v1/orders/ord_01j2y8m6jcc9tt24af5pw9x1bc/sign")
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

        var response = await Client.Orders.SignOrderAsync(
            new SignOrderRequest
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
