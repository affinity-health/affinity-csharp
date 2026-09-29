using Affinity;
using Affinity.Test.Unit.MockServer;
using Affinity.Test.Utils;
using NUnit.Framework;

namespace Affinity.Test.Unit.MockServer.Catalog;

[TestFixture]
[Parallelizable(ParallelScope.Self)]
public class ListCatalogItemsTest : BaseMockServerTest
{
    [NUnit.Framework.Test]
    public async Task MockServerTest_1()
    {
        const string mockResponse = """
            {
              "data": [
                {
                  "catalogDetails": {
                    "attributes": {
                      "attributes": "attributes"
                    },
                    "directions": [
                      {
                        "kind": "suggested",
                        "text": "text"
                      },
                      {
                        "kind": "suggested",
                        "text": "text"
                      }
                    ]
                  },
                  "composition": {
                    "status": "complete",
                    "ingredients": [
                      {
                        "name": "name",
                        "role": "active",
                        "basisOfStrengthSubstance": {
                          "name": "name"
                        },
                        "strength": {
                          "kind": "amount",
                          "amount": {
                            "value": "value",
                            "unit": "unit"
                          }
                        }
                      },
                      {
                        "name": "name",
                        "role": "active",
                        "basisOfStrengthSubstance": {
                          "name": "name"
                        },
                        "strength": {
                          "kind": "amount",
                          "amount": {
                            "value": "value",
                            "unit": "unit"
                          }
                        }
                      }
                    ]
                  },
                  "allowedStates": [
                    "allowedStates",
                    "allowedStates"
                  ],
                  "availability": "available",
                  "catalogKind": "catalogKind",
                  "fulfillmentInclusions": [
                    {
                      "amountCents": 1,
                      "kind": "cold_chain",
                      "label": "label",
                      "priceComponent": "shipping"
                    },
                    {
                      "amountCents": 1,
                      "kind": "cold_chain",
                      "label": "label",
                      "priceComponent": "shipping"
                    }
                  ],
                  "ordering": {
                    "requiresPrescription": true,
                    "requiresAccompanyingPrescription": true,
                    "shipping": "prescription"
                  },
                  "category": "category",
                  "coldShip": true,
                  "pharmacyId": "pharmacyId",
                  "pharmacyName": "pharmacyName",
                  "description": "description",
                  "dosageForm": "dosageForm",
                  "facilityType": "facilityType",
                  "id": "id",
                  "imageUrl": "imageUrl",
                  "imageUrls": [
                    "imageUrls",
                    "imageUrls"
                  ],
                  "medicationGroup": {
                    "offerCount": "Infinity",
                    "pharmacyCount": "Infinity",
                    "strengths": [
                      "strengths",
                      "strengths"
                    ]
                  },
                  "isOrderable": true,
                  "livemode": true,
                  "name": "name",
                  "object": "catalog_item",
                  "patientSpecificRequired": true,
                  "quantityConstraint": {
                    "kind": "fixed",
                    "quantity": {
                      "value": "value",
                      "unit": "unit"
                    }
                  },
                  "prescriptionRequirements": {
                    "allowedDaysSupply": [
                      1,
                      1
                    ],
                    "allowedQuantities": [
                      {
                        "daysSupply": 1,
                        "label": "label",
                        "unit": "unit",
                        "value": "Infinity"
                      },
                      {
                        "daysSupply": 1,
                        "label": "label",
                        "unit": "unit",
                        "value": "Infinity"
                      }
                    ],
                    "allowedReasonCategories": [
                      "alcohol_free",
                      "alcohol_free"
                    ],
                    "reasonCategoryLabels": {
                      "reasonCategoryLabels": "reasonCategoryLabels"
                    },
                    "compoundingReason": "not_required",
                    "compoundingReasonContext": "not_supported",
                    "controlledSchedule": "II",
                    "defaultDaysSupply": 1,
                    "defaultQuantity": {
                      "unit": "unit",
                      "value": "Infinity"
                    },
                    "quantityIncrement": {
                      "max": "Infinity",
                      "min": "Infinity",
                      "unit": "unit",
                      "value": "Infinity"
                    },
                    "defaultSigs": [
                      "defaultSigs",
                      "defaultSigs"
                    ],
                    "diagnosis": "not_required",
                    "medicationReview": "optional",
                    "diagnosisReview": "optional",
                    "maxRefills": 1,
                    "notes": [
                      "notes",
                      "notes"
                    ],
                    "pharmacyNotes": "not_supported",
                    "refills": "not_supported",
                    "substitution": "not_supported"
                  },
                  "pricing": {
                    "amountCents": 1,
                    "basis": {
                      "kind": "item",
                      "quantity": "1",
                      "unit": "unit"
                    },
                    "currency": "USD",
                    "medicationSubtotalCents": 1
                  },
                  "restrictedStates": [
                    "restrictedStates",
                    "restrictedStates"
                  ],
                  "route": "route",
                  "shippingOptions": [
                    {
                      "amountCents": 1,
                      "carrier": "carrier",
                      "currency": "USD",
                      "destinationTypes": [
                        "patient",
                        "patient"
                      ],
                      "estimatedDaysMax": 1,
                      "estimatedDaysMin": 1,
                      "id": "id",
                      "label": "label",
                      "serviceLevel": "serviceLevel",
                      "temperatures": [
                        "ambient",
                        "ambient"
                      ]
                    },
                    {
                      "amountCents": 1,
                      "carrier": "carrier",
                      "currency": "USD",
                      "destinationTypes": [
                        "patient",
                        "patient"
                      ],
                      "estimatedDaysMax": 1,
                      "estimatedDaysMin": 1,
                      "id": "id",
                      "label": "label",
                      "serviceLevel": "serviceLevel",
                      "temperatures": [
                        "ambient",
                        "ambient"
                      ]
                    }
                  ],
                  "strength": "strength",
                  "unit": "unit"
                },
                {
                  "catalogDetails": {
                    "attributes": {
                      "attributes": "attributes"
                    },
                    "directions": [
                      {
                        "kind": "suggested",
                        "text": "text"
                      },
                      {
                        "kind": "suggested",
                        "text": "text"
                      }
                    ]
                  },
                  "composition": {
                    "status": "complete",
                    "ingredients": [
                      {
                        "name": "name",
                        "role": "active",
                        "basisOfStrengthSubstance": {
                          "name": "name"
                        },
                        "strength": {
                          "kind": "amount",
                          "amount": {
                            "value": "value",
                            "unit": "unit"
                          }
                        }
                      },
                      {
                        "name": "name",
                        "role": "active",
                        "basisOfStrengthSubstance": {
                          "name": "name"
                        },
                        "strength": {
                          "kind": "amount",
                          "amount": {
                            "value": "value",
                            "unit": "unit"
                          }
                        }
                      }
                    ]
                  },
                  "allowedStates": [
                    "allowedStates",
                    "allowedStates"
                  ],
                  "availability": "available",
                  "catalogKind": "catalogKind",
                  "fulfillmentInclusions": [
                    {
                      "amountCents": 1,
                      "kind": "cold_chain",
                      "label": "label",
                      "priceComponent": "shipping"
                    },
                    {
                      "amountCents": 1,
                      "kind": "cold_chain",
                      "label": "label",
                      "priceComponent": "shipping"
                    }
                  ],
                  "ordering": {
                    "requiresPrescription": true,
                    "requiresAccompanyingPrescription": true,
                    "shipping": "prescription"
                  },
                  "category": "category",
                  "coldShip": true,
                  "pharmacyId": "pharmacyId",
                  "pharmacyName": "pharmacyName",
                  "description": "description",
                  "dosageForm": "dosageForm",
                  "facilityType": "facilityType",
                  "id": "id",
                  "imageUrl": "imageUrl",
                  "imageUrls": [
                    "imageUrls",
                    "imageUrls"
                  ],
                  "medicationGroup": {
                    "offerCount": "Infinity",
                    "pharmacyCount": "Infinity",
                    "strengths": [
                      "strengths",
                      "strengths"
                    ]
                  },
                  "isOrderable": true,
                  "livemode": true,
                  "name": "name",
                  "object": "catalog_item",
                  "patientSpecificRequired": true,
                  "quantityConstraint": {
                    "kind": "fixed",
                    "quantity": {
                      "value": "value",
                      "unit": "unit"
                    }
                  },
                  "prescriptionRequirements": {
                    "allowedDaysSupply": [
                      1,
                      1
                    ],
                    "allowedQuantities": [
                      {
                        "daysSupply": 1,
                        "label": "label",
                        "unit": "unit",
                        "value": "Infinity"
                      },
                      {
                        "daysSupply": 1,
                        "label": "label",
                        "unit": "unit",
                        "value": "Infinity"
                      }
                    ],
                    "allowedReasonCategories": [
                      "alcohol_free",
                      "alcohol_free"
                    ],
                    "reasonCategoryLabels": {
                      "reasonCategoryLabels": "reasonCategoryLabels"
                    },
                    "compoundingReason": "not_required",
                    "compoundingReasonContext": "not_supported",
                    "controlledSchedule": "II",
                    "defaultDaysSupply": 1,
                    "defaultQuantity": {
                      "unit": "unit",
                      "value": "Infinity"
                    },
                    "quantityIncrement": {
                      "max": "Infinity",
                      "min": "Infinity",
                      "unit": "unit",
                      "value": "Infinity"
                    },
                    "defaultSigs": [
                      "defaultSigs",
                      "defaultSigs"
                    ],
                    "diagnosis": "not_required",
                    "medicationReview": "optional",
                    "diagnosisReview": "optional",
                    "maxRefills": 1,
                    "notes": [
                      "notes",
                      "notes"
                    ],
                    "pharmacyNotes": "not_supported",
                    "refills": "not_supported",
                    "substitution": "not_supported"
                  },
                  "pricing": {
                    "amountCents": 1,
                    "basis": {
                      "kind": "item",
                      "quantity": "1",
                      "unit": "unit"
                    },
                    "currency": "USD",
                    "medicationSubtotalCents": 1
                  },
                  "restrictedStates": [
                    "restrictedStates",
                    "restrictedStates"
                  ],
                  "route": "route",
                  "shippingOptions": [
                    {
                      "amountCents": 1,
                      "carrier": "carrier",
                      "currency": "USD",
                      "destinationTypes": [
                        "patient",
                        "patient"
                      ],
                      "estimatedDaysMax": 1,
                      "estimatedDaysMin": 1,
                      "id": "id",
                      "label": "label",
                      "serviceLevel": "serviceLevel",
                      "temperatures": [
                        "ambient",
                        "ambient"
                      ]
                    },
                    {
                      "amountCents": 1,
                      "carrier": "carrier",
                      "currency": "USD",
                      "destinationTypes": [
                        "patient",
                        "patient"
                      ],
                      "estimatedDaysMax": 1,
                      "estimatedDaysMin": 1,
                      "id": "id",
                      "label": "label",
                      "serviceLevel": "serviceLevel",
                      "temperatures": [
                        "ambient",
                        "ambient"
                      ]
                    }
                  ],
                  "strength": "strength",
                  "unit": "unit"
                }
              ],
              "hasMore": true,
              "object": "list",
              "updatedAt": "updatedAt",
              "url": "/v1/catalog/items"
            }
            """;

        Server
            .Given(
                WireMock.RequestBuilders.Request.Create().WithPath("/v1/catalog/items").UsingGet()
            )
            .RespondWith(
                WireMock
                    .ResponseBuilders.Response.Create()
                    .WithStatusCode(200)
                    .WithBody(mockResponse)
            );

        var response = await Client.Catalog.ListCatalogItemsAsync(new ListCatalogItemsRequest());
        JsonAssert.AreEqual(response, mockResponse);
    }

    [NUnit.Framework.Test]
    public async Task MockServerTest_2()
    {
        const string mockResponse = """
            {
              "data": [
                {
                  "catalogDetails": {
                    "attributes": {
                      "key": "value"
                    },
                    "directions": [
                      {
                        "kind": "suggested",
                        "text": "text"
                      }
                    ]
                  },
                  "composition": {
                    "status": "complete",
                    "ingredients": [
                      {
                        "name": "name",
                        "role": "active",
                        "strength": {
                          "kind": "amount",
                          "amount": {
                            "value": "value",
                            "unit": "unit"
                          }
                        }
                      }
                    ]
                  },
                  "allowedStates": [
                    "allowedStates"
                  ],
                  "availability": "available",
                  "catalogKind": "catalogKind",
                  "fulfillmentInclusions": [
                    {
                      "amountCents": 1,
                      "kind": "cold_chain",
                      "label": "label",
                      "priceComponent": "shipping"
                    }
                  ],
                  "ordering": {
                    "requiresPrescription": true,
                    "requiresAccompanyingPrescription": true,
                    "shipping": "prescription"
                  },
                  "category": "category",
                  "coldShip": true,
                  "pharmacyId": "pharmacyId",
                  "pharmacyName": "pharmacyName",
                  "description": "description",
                  "dosageForm": "dosageForm",
                  "facilityType": "facilityType",
                  "id": "id",
                  "imageUrl": "imageUrl",
                  "imageUrls": [
                    "imageUrls"
                  ],
                  "medicationGroup": {
                    "offerCount": "Infinity",
                    "pharmacyCount": "Infinity",
                    "strengths": [
                      "strengths"
                    ]
                  },
                  "isOrderable": true,
                  "livemode": true,
                  "name": "name",
                  "object": "catalog_item",
                  "patientSpecificRequired": true,
                  "quantityConstraint": {
                    "kind": "fixed",
                    "quantity": {
                      "value": "value",
                      "unit": "unit"
                    }
                  },
                  "prescriptionRequirements": {
                    "compoundingReason": "not_required",
                    "diagnosis": "not_required",
                    "pharmacyNotes": "not_supported",
                    "refills": "not_supported",
                    "substitution": "not_supported"
                  },
                  "pricing": {
                    "amountCents": 1,
                    "basis": {
                      "kind": "item",
                      "quantity": "1",
                      "unit": "unit"
                    },
                    "currency": "USD",
                    "medicationSubtotalCents": 1
                  },
                  "restrictedStates": [
                    "restrictedStates"
                  ],
                  "route": "route",
                  "shippingOptions": [
                    {
                      "amountCents": 1,
                      "currency": "USD",
                      "destinationTypes": [
                        "patient"
                      ],
                      "id": "id",
                      "label": "label",
                      "serviceLevel": "serviceLevel",
                      "temperatures": [
                        "ambient"
                      ]
                    }
                  ],
                  "strength": "strength",
                  "unit": "unit"
                }
              ],
              "hasMore": true,
              "object": "list",
              "updatedAt": "updatedAt",
              "url": "/v1/catalog/items"
            }
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/v1/catalog/items")
                    .WithParam("relatedToCatalogItemId", "cat_01j2y8m6jcc9tt24af5pw9x1bc")
                    .WithParam("catalogItemId", "cat_01j2y8m6jcc9tt24af5pw9x1bc")
                    .WithParam("pharmacyIds", "pharm_01j2y8m6jcc9tt24af5pw9x1bc")
                    .WithParam("endingBefore", "cat_01j2y8m6jcc9tt24af5pw9x1bc")
                    .WithParam("orgId", "acct_01j2y8m6jcc9tt24af5pw9x1bc")
                    .WithParam("practiceId", "prac_01j2y8m6jcc9tt24af5pw9x1bc")
                    .WithParam("startingAfter", "cat_01j2y8m6jcc9tt24af5pw9x1bc")
                    .UsingGet()
            )
            .RespondWith(
                WireMock
                    .ResponseBuilders.Response.Create()
                    .WithStatusCode(200)
                    .WithBody(mockResponse)
            );

        var response = await Client.Catalog.ListCatalogItemsAsync(
            new ListCatalogItemsRequest
            {
                RelatedToCatalogItemId = "cat_01j2y8m6jcc9tt24af5pw9x1bc",
                CatalogItemId = "cat_01j2y8m6jcc9tt24af5pw9x1bc",
                PharmacyIds = "pharm_01j2y8m6jcc9tt24af5pw9x1bc",
                EndingBefore = "cat_01j2y8m6jcc9tt24af5pw9x1bc",
                OrgId = "acct_01j2y8m6jcc9tt24af5pw9x1bc",
                PracticeId = "prac_01j2y8m6jcc9tt24af5pw9x1bc",
                StartingAfter = "cat_01j2y8m6jcc9tt24af5pw9x1bc",
            }
        );
        JsonAssert.AreEqual(response, mockResponse);
    }
}
