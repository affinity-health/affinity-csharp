using Affinity;
using Affinity.Test.Unit.MockServer;
using Affinity.Test.Utils;
using NUnit.Framework;

namespace Affinity.Test.Unit.MockServer.Medications;

[TestFixture]
[Parallelizable(ParallelScope.Self)]
public class GetTest : BaseMockServerTest
{
    [NUnit.Framework.Test]
    public async Task MockServerTest_1()
    {
        const string mockResponse = """
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
              "strength": "strength",
              "variants": [
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
              ]
            }
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/v1/medications/medicationId")
                    .UsingGet()
            )
            .RespondWith(
                WireMock
                    .ResponseBuilders.Response.Create()
                    .WithStatusCode(200)
                    .WithBody(mockResponse)
            );

        var response = await Client.Medications.GetAsync(
            new GetMedicationsRequest { MedicationId = "medicationId" }
        );
        JsonAssert.AreEqual(response, mockResponse);
    }

    [NUnit.Framework.Test]
    public async Task MockServerTest_2()
    {
        const string mockResponse = """
            {
              "category": "weight_loss",
              "coldChainRequired": true,
              "compoundingReasons": [
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
              "strength": "strength",
              "variants": [
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
              ]
            }
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/v1/medications/med_01j2y8m6jcc9tt24af5pw9x1bc")
                    .WithParam("practiceId", "prac_01j2y8m6jcc9tt24af5pw9x1bc")
                    .UsingGet()
            )
            .RespondWith(
                WireMock
                    .ResponseBuilders.Response.Create()
                    .WithStatusCode(200)
                    .WithBody(mockResponse)
            );

        var response = await Client.Medications.GetAsync(
            new GetMedicationsRequest
            {
                MedicationId = "med_01j2y8m6jcc9tt24af5pw9x1bc",
                PracticeId = "prac_01j2y8m6jcc9tt24af5pw9x1bc",
            }
        );
        JsonAssert.AreEqual(response, mockResponse);
    }
}
