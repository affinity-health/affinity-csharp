using Affinity;
using Affinity.Test.Unit.MockServer;
using Affinity.Test.Utils;
using NUnit.Framework;

namespace Affinity.Test.Unit.MockServer.Orders;

[TestFixture]
[Parallelizable(ParallelScope.Self)]
public class UpdateOrderTestSimulationTest : BaseMockServerTest
{
    [NUnit.Framework.Test]
    public async Task MockServerTest_1()
    {
        const string requestJson = """
            {
              "mode": "automatic",
              "scenario": "successful"
            }
            """;

        const string mockResponse = """
            {
              "mode": "automatic",
              "scenario": "successful",
              "pendingAction": "pendingAction",
              "lastError": "lastError",
              "availableActions": [
                "accept",
                "accept"
              ],
              "scenarioEditable": true
            }
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/v1/orders/orderId/test-simulation")
                    .WithHeader("Idempotency-Key", "idempotencyKey")
                    .WithHeader("Content-Type", "application/json")
                    .UsingPut()
                    .WithBodyAsJson(requestJson)
            )
            .RespondWith(
                WireMock
                    .ResponseBuilders.Response.Create()
                    .WithStatusCode(200)
                    .WithBody(mockResponse)
            );

        var response = await Client.Orders.UpdateOrderTestSimulationAsync(
            new UpdateOrderTestSimulationRequest
            {
                OrderId = "orderId",
                IdempotencyKey = "idempotencyKey",
                Mode = UpdateOrderTestSimulationRequestMode.Automatic,
                Scenario = UpdateOrderTestSimulationRequestScenario.Successful,
                Action = null,
            }
        );
        JsonAssert.AreEqual(response, mockResponse);
    }

    [NUnit.Framework.Test]
    public async Task MockServerTest_2()
    {
        const string requestJson = """
            {
              "mode": "automatic",
              "scenario": "successful"
            }
            """;

        const string mockResponse = """
            {
              "mode": "automatic",
              "scenario": "successful",
              "pendingAction": "pendingAction",
              "lastError": "lastError",
              "availableActions": [
                "accept"
              ],
              "scenarioEditable": true
            }
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/v1/orders/ord_01j2y8m6jcc9tt24af5pw9x1bc/test-simulation")
                    .WithHeader("Idempotency-Key", "Idempotency-Key")
                    .WithHeader("Content-Type", "application/json")
                    .UsingPut()
                    .WithBodyAsJson(requestJson)
            )
            .RespondWith(
                WireMock
                    .ResponseBuilders.Response.Create()
                    .WithStatusCode(200)
                    .WithBody(mockResponse)
            );

        var response = await Client.Orders.UpdateOrderTestSimulationAsync(
            new UpdateOrderTestSimulationRequest
            {
                OrderId = "ord_01j2y8m6jcc9tt24af5pw9x1bc",
                IdempotencyKey = "Idempotency-Key",
                Mode = UpdateOrderTestSimulationRequestMode.Automatic,
                Scenario = UpdateOrderTestSimulationRequestScenario.Successful,
            }
        );
        JsonAssert.AreEqual(response, mockResponse);
    }
}
