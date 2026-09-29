using Affinity;
using Affinity.Test.Unit.MockServer;
using Affinity.Test.Utils;
using NUnit.Framework;

namespace Affinity.Test.Unit.MockServer.PlatformPricing;

[TestFixture]
[Parallelizable(ParallelScope.Self)]
public class PlatformPublicApiSellingPricesReadSellingPriceTest : BaseMockServerTest
{
    [NUnit.Framework.Test]
    public async Task MockServerTest_1()
    {
        const string mockResponse = """
            {
              "amountCents": 1,
              "version": 1,
              "currency": "USD",
              "basis": {
                "kind": "item",
                "quantity": "1",
                "unit": "unit"
              },
              "purchaseAmountCents": 1,
              "requiresReview": true
            }
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/v1/catalog/items/catalogItemId/selling-price")
                    .UsingGet()
            )
            .RespondWith(
                WireMock
                    .ResponseBuilders.Response.Create()
                    .WithStatusCode(200)
                    .WithBody(mockResponse)
            );

        var response =
            await Client.PlatformPricing.PlatformPublicApiSellingPricesReadSellingPriceAsync(
                new PlatformPublicApiSellingPricesReadSellingPriceRequest
                {
                    CatalogItemId = "catalogItemId",
                }
            );
        JsonAssert.AreEqual(response, mockResponse);
    }

    [NUnit.Framework.Test]
    public async Task MockServerTest_2()
    {
        const string mockResponse = """
            {
              "amountCents": 1,
              "version": 1,
              "currency": "USD",
              "basis": {
                "kind": "item",
                "quantity": "1",
                "unit": "unit"
              },
              "purchaseAmountCents": 1,
              "requiresReview": true
            }
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/v1/catalog/items/cat_01j2y8m6jcc9tt24af5pw9x1bc/selling-price")
                    .WithParam("practiceId", "prac_01j2y8m6jcc9tt24af5pw9x1bc")
                    .UsingGet()
            )
            .RespondWith(
                WireMock
                    .ResponseBuilders.Response.Create()
                    .WithStatusCode(200)
                    .WithBody(mockResponse)
            );

        var response =
            await Client.PlatformPricing.PlatformPublicApiSellingPricesReadSellingPriceAsync(
                new PlatformPublicApiSellingPricesReadSellingPriceRequest
                {
                    CatalogItemId = "cat_01j2y8m6jcc9tt24af5pw9x1bc",
                    PracticeId = "prac_01j2y8m6jcc9tt24af5pw9x1bc",
                }
            );
        JsonAssert.AreEqual(response, mockResponse);
    }
}
