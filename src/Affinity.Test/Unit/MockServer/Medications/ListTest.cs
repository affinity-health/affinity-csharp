using Affinity;
using Affinity.Test.Unit.MockServer;
using NUnit.Framework;

namespace Affinity.Test.Unit.MockServer.Medications;

[TestFixture]
[Parallelizable(ParallelScope.Self)]
public class ListTest : BaseMockServerTest
{
    [NUnit.Framework.Test]
    public async Task MockServerTest_1()
    {
        const string mockResponse = """
            {
              "data": [
                {
                  "category": "weight_loss",
                  "coldChainRequired": true,
                  "compoundingReasons": [
                    "compoundingReasons",
                    "compoundingReasons"
                  ],
                  "defaultDirections": "defaultDirections",
                  "fill": {
                    "amount": 1,
                    "container": "container",
                    "ingredients": [
                      {
                        "amount": 1.1,
                        "name": "name",
                        "unit": "unit"
                      },
                      {
                        "amount": 1.1,
                        "name": "name",
                        "unit": "unit"
                      }
                    ],
                    "unit": "unit",
                    "volume": {
                      "amount": 1.1,
                      "unit": "unit"
                    }
                  },
                  "form": "form",
                  "fullName": "fullName",
                  "id": "id",
                  "name": "name",
                  "pharmacy": {
                    "id": "id",
                    "name": "name"
                  },
                  "price": 1,
                  "quantities": [
                    1,
                    1
                  ],
                  "quantityUnit": "quantityUnit",
                  "requirements": [
                    "requirements",
                    "requirements"
                  ],
                  "restrictedStates": [
                    "restrictedStates",
                    "restrictedStates"
                  ],
                  "shippingOptions": [
                    {
                      "id": "id",
                      "name": "name",
                      "price": 1
                    },
                    {
                      "id": "id",
                      "name": "name",
                      "price": 1
                    }
                  ],
                  "shippingSuppliesPrice": 1,
                  "strength": "strength"
                },
                {
                  "category": "weight_loss",
                  "coldChainRequired": true,
                  "compoundingReasons": [
                    "compoundingReasons",
                    "compoundingReasons"
                  ],
                  "defaultDirections": "defaultDirections",
                  "fill": {
                    "amount": 1,
                    "container": "container",
                    "ingredients": [
                      {
                        "amount": 1.1,
                        "name": "name",
                        "unit": "unit"
                      },
                      {
                        "amount": 1.1,
                        "name": "name",
                        "unit": "unit"
                      }
                    ],
                    "unit": "unit",
                    "volume": {
                      "amount": 1.1,
                      "unit": "unit"
                    }
                  },
                  "form": "form",
                  "fullName": "fullName",
                  "id": "id",
                  "name": "name",
                  "pharmacy": {
                    "id": "id",
                    "name": "name"
                  },
                  "price": 1,
                  "quantities": [
                    1,
                    1
                  ],
                  "quantityUnit": "quantityUnit",
                  "requirements": [
                    "requirements",
                    "requirements"
                  ],
                  "restrictedStates": [
                    "restrictedStates",
                    "restrictedStates"
                  ],
                  "shippingOptions": [
                    {
                      "id": "id",
                      "name": "name",
                      "price": 1
                    },
                    {
                      "id": "id",
                      "name": "name",
                      "price": 1
                    }
                  ],
                  "shippingSuppliesPrice": 1,
                  "strength": "strength"
                }
              ],
              "hasMore": true,
              "nextCursor": "nextCursor",
              "object": "list",
              "url": "url"
            }
            """;

        Server
            .Given(WireMock.RequestBuilders.Request.Create().WithPath("/v1/medications").UsingGet())
            .RespondWith(
                WireMock
                    .ResponseBuilders.Response.Create()
                    .WithStatusCode(200)
                    .WithBody(mockResponse)
            );

        var items = await Client.Medications.ListAsync(new ListMedicationsRequest());
        await foreach (var item in items)
        {
            Assert.That(item, Is.Not.Null);
            break; // Only check the first item
        }
    }

    [NUnit.Framework.Test]
    public async Task MockServerTest_2()
    {
        const string mockResponse = """
            {
              "data": [
                {
                  "category": "weight_loss",
                  "coldChainRequired": true,
                  "compoundingReasons": [
                    "compoundingReasons"
                  ],
                  "defaultDirections": "defaultDirections",
                  "fill": {
                    "amount": 1,
                    "ingredients": [
                      {
                        "amount": 1.1,
                        "name": "name",
                        "unit": "unit"
                      }
                    ],
                    "unit": "unit"
                  },
                  "form": "form",
                  "fullName": "fullName",
                  "id": "med_01j2y8m6jcc9tt24af5pw9x1bc",
                  "name": "name",
                  "pharmacy": {
                    "id": "pharm_01j2y8m6jcc9tt24af5pw9x1bc",
                    "name": "name"
                  },
                  "price": 1,
                  "quantities": [
                    1
                  ],
                  "quantityUnit": "quantityUnit",
                  "requirements": [
                    "requirements"
                  ],
                  "restrictedStates": [
                    "restrictedStates"
                  ],
                  "shippingOptions": [
                    {
                      "id": "shp_01j2y8m6jcc9tt24af5pw9x1bc",
                      "name": "name",
                      "price": 1
                    }
                  ],
                  "shippingSuppliesPrice": 1,
                  "strength": "strength"
                }
              ],
              "hasMore": true,
              "nextCursor": "nextCursor",
              "object": "list",
              "url": "url"
            }
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/v1/medications")
                    .WithParam("practiceId", "prac_01j2y8m6jcc9tt24af5pw9x1bc")
                    .UsingGet()
            )
            .RespondWith(
                WireMock
                    .ResponseBuilders.Response.Create()
                    .WithStatusCode(200)
                    .WithBody(mockResponse)
            );

        var items = await Client.Medications.ListAsync(
            new ListMedicationsRequest { PracticeId = "prac_01j2y8m6jcc9tt24af5pw9x1bc" }
        );
        await foreach (var item in items)
        {
            Assert.That(item, Is.Not.Null);
            break; // Only check the first item
        }
    }
}
