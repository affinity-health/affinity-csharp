using Affinity;
using Affinity.Test.Unit.MockServer;
using Affinity.Test.Utils;
using NUnit.Framework;

namespace Affinity.Test.Unit.MockServer.Catalog;

[TestFixture]
[Parallelizable(ParallelScope.Self)]
public class ListShippingOptionsTest : BaseMockServerTest
{
    [NUnit.Framework.Test]
    public async Task MockServerTest_1()
    {
        const string mockResponse = """
            [
              {
                "amountCents": 1,
                "carrier": "carrier",
                "currency": "USD",
                "estimatedDaysMax": 1,
                "estimatedDaysMin": 1,
                "id": "id",
                "label": "label",
                "serviceLevel": "serviceLevel",
                "temperature": "ambient"
              },
              {
                "amountCents": 1,
                "carrier": "carrier",
                "currency": "USD",
                "estimatedDaysMax": 1,
                "estimatedDaysMin": 1,
                "id": "id",
                "label": "label",
                "serviceLevel": "serviceLevel",
                "temperature": "ambient"
              }
            ]
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/v1/catalog/items/catalogItemId/shipping-options")
                    .WithParam("destinationState", "destinationState")
                    .UsingGet()
            )
            .RespondWith(
                WireMock
                    .ResponseBuilders.Response.Create()
                    .WithStatusCode(200)
                    .WithBody(mockResponse)
            );

        var response = await Client.Catalog.ListShippingOptionsAsync(
            new ListShippingOptionsRequest
            {
                CatalogItemId = "catalogItemId",
                DestinationState = "destinationState",
            }
        );
        JsonAssert.AreEqual(response, mockResponse);
    }

    [NUnit.Framework.Test]
    public async Task MockServerTest_2()
    {
        const string mockResponse = """
            [
              {
                "amountCents": 1,
                "carrier": "carrier",
                "currency": "USD",
                "estimatedDaysMax": 1,
                "estimatedDaysMin": 1,
                "id": "id",
                "label": "label",
                "serviceLevel": "serviceLevel",
                "temperature": "ambient"
              }
            ]
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/v1/catalog/items/cat_01j2y8m6jcc9tt24af5pw9x1bc/shipping-options")
                    .WithParam("destinationState", "destinationState")
                    .UsingGet()
            )
            .RespondWith(
                WireMock
                    .ResponseBuilders.Response.Create()
                    .WithStatusCode(200)
                    .WithBody(mockResponse)
            );

        var response = await Client.Catalog.ListShippingOptionsAsync(
            new ListShippingOptionsRequest
            {
                CatalogItemId = "cat_01j2y8m6jcc9tt24af5pw9x1bc",
                DestinationState = "destinationState",
            }
        );
        JsonAssert.AreEqual(response, mockResponse);
    }
}
