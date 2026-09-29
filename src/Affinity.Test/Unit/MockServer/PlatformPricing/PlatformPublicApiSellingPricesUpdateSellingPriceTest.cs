using Affinity;
using Affinity.Test.Unit.MockServer;
using Affinity.Test.Utils;
using NUnit.Framework;

namespace Affinity.Test.Unit.MockServer.PlatformPricing;

[TestFixture]
[Parallelizable(ParallelScope.Self)]
public class PlatformPublicApiSellingPricesUpdateSellingPriceTest : BaseMockServerTest
{
    [NUnit.Framework.Test]
    public async Task MockServerTest_1()
    {
        const string requestJson = """
            {
              "baseVersion": 1
            }
            """;

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

        var response =
            await Client.PlatformPricing.PlatformPublicApiSellingPricesUpdateSellingPriceAsync(
                new PlatformPublicApiSellingPricesUpdateSellingPriceRequest
                {
                    CatalogItemId = "catalogItemId",
                    IdempotencyKey = "idempotencyKey",
                    PracticeId = null,
                    AmountCents = null,
                    BaseVersion = 1,
                }
            );
        JsonAssert.AreEqual(response, mockResponse);
    }

    [NUnit.Framework.Test]
    public async Task MockServerTest_2()
    {
        const string requestJson = """
            {
              "baseVersion": 1
            }
            """;

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

        var response =
            await Client.PlatformPricing.PlatformPublicApiSellingPricesUpdateSellingPriceAsync(
                new PlatformPublicApiSellingPricesUpdateSellingPriceRequest
                {
                    CatalogItemId = "cat_01j2y8m6jcc9tt24af5pw9x1bc",
                    IdempotencyKey = "Idempotency-Key",
                    BaseVersion = 1,
                }
            );
        JsonAssert.AreEqual(response, mockResponse);
    }
}
