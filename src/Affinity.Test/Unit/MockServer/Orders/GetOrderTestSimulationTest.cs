using Affinity;
using Affinity.Test.Unit.MockServer;
using Affinity.Test.Utils;
using NUnit.Framework;

namespace Affinity.Test.Unit.MockServer.Orders;

[TestFixture]
[Parallelizable(ParallelScope.Self)]
public class GetOrderTestSimulationTest : BaseMockServerTest
{
    [NUnit.Framework.Test]
    public async Task MockServerTest_1()
    {
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
                    .UsingGet()
            )
            .RespondWith(
                WireMock
                    .ResponseBuilders.Response.Create()
                    .WithStatusCode(200)
                    .WithBody(mockResponse)
            );

        var response = await Client.Orders.GetOrderTestSimulationAsync(
            new GetOrderTestSimulationRequest { OrderId = "orderId" }
        );
        JsonAssert.AreEqual(response, mockResponse);
    }

    [NUnit.Framework.Test]
    public async Task MockServerTest_2()
    {
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
                    .UsingGet()
            )
            .RespondWith(
                WireMock
                    .ResponseBuilders.Response.Create()
                    .WithStatusCode(200)
                    .WithBody(mockResponse)
            );

        var response = await Client.Orders.GetOrderTestSimulationAsync(
            new GetOrderTestSimulationRequest { OrderId = "ord_01j2y8m6jcc9tt24af5pw9x1bc" }
        );
        JsonAssert.AreEqual(response, mockResponse);
    }
}
