using Affinity;
using Affinity.Test.Unit.MockServer;
using Affinity.Test.Utils;
using NUnit.Framework;

namespace Affinity.Test.Unit.MockServer.Catalog;

[TestFixture]
[Parallelizable(ParallelScope.Self)]
public class RetrievePrescribingOptionsTest : BaseMockServerTest
{
    [NUnit.Framework.Test]
    public async Task MockServerTest_1()
    {
        const string mockResponse = """
            {
              "compoundingReason": {
                "required": true,
                "categoryRequired": true,
                "context": "not_supported",
                "contextPrompt": "contextPrompt",
                "choices": [
                  {
                    "category": "alcohol_free",
                    "label": "label",
                    "contextRequired": true,
                    "contextPrompt": "contextPrompt"
                  },
                  {
                    "category": "alcohol_free",
                    "label": "label",
                    "contextRequired": true,
                    "contextPrompt": "contextPrompt"
                  }
                ]
              },
              "compoundingReasonCategoryDefault": "alcohol_free",
              "compoundingReasonDefault": "compoundingReasonDefault",
              "default": {
                "directions": "directions",
                "format": "free_text",
                "source": "affinity",
                "structuredSig": {
                  "dose": "dose",
                  "doseUnit": "doseUnit",
                  "duration": "duration",
                  "frequency": "frequency",
                  "maxDailyUse": "maxDailyUse",
                  "prn": true,
                  "route": "route",
                  "titrationSchedule": "titrationSchedule"
                }
              },
              "formulationDefault": {
                "directions": "directions",
                "format": "free_text",
                "structuredSig": {
                  "dose": "dose",
                  "doseUnit": "doseUnit",
                  "duration": "duration",
                  "frequency": "frequency",
                  "maxDailyUse": "maxDailyUse",
                  "prn": true,
                  "route": "route",
                  "titrationSchedule": "titrationSchedule"
                }
              },
              "initial": {
                "dose": "dose",
                "doseUnit": "doseUnit",
                "duration": "duration",
                "frequency": "frequency",
                "maxDailyUse": "maxDailyUse",
                "prn": true,
                "route": "route",
                "titrationSchedule": "titrationSchedule"
              },
              "medication": {
                "name": "name",
                "rxnorm": {
                  "code": "code",
                  "display": "display",
                  "doseForm": "doseForm",
                  "route": "route",
                  "system": "rxnorm"
                }
              },
              "options": {
                "doseUnits": [
                  {
                    "label": "label",
                    "source": "catalog",
                    "value": "value"
                  },
                  {
                    "label": "label",
                    "source": "catalog",
                    "value": "value"
                  }
                ],
                "doses": [
                  {
                    "label": "label",
                    "source": "catalog",
                    "value": "value"
                  },
                  {
                    "label": "label",
                    "source": "catalog",
                    "value": "value"
                  }
                ],
                "frequencies": [
                  {
                    "label": "label",
                    "source": "catalog",
                    "value": "value"
                  },
                  {
                    "label": "label",
                    "source": "catalog",
                    "value": "value"
                  }
                ],
                "routes": [
                  {
                    "label": "label",
                    "source": "catalog",
                    "value": "value"
                  },
                  {
                    "label": "label",
                    "source": "catalog",
                    "value": "value"
                  }
                ]
              },
              "pharmacyDirections": [
                {
                  "directions": "directions",
                  "format": "free_text",
                  "structuredSig": {
                    "dose": "dose",
                    "doseUnit": "doseUnit",
                    "duration": "duration",
                    "frequency": "frequency",
                    "maxDailyUse": "maxDailyUse",
                    "prn": true,
                    "route": "route",
                    "titrationSchedule": "titrationSchedule"
                  }
                },
                {
                  "directions": "directions",
                  "format": "free_text",
                  "structuredSig": {
                    "dose": "dose",
                    "doseUnit": "doseUnit",
                    "duration": "duration",
                    "frequency": "frequency",
                    "maxDailyUse": "maxDailyUse",
                    "prn": true,
                    "route": "route",
                    "titrationSchedule": "titrationSchedule"
                  }
                }
              ],
              "templates": [
                {
                  "id": "id",
                  "initial": {
                    "dose": "dose",
                    "doseUnit": "doseUnit",
                    "duration": "duration",
                    "frequency": "frequency",
                    "maxDailyUse": "maxDailyUse",
                    "prn": true,
                    "route": "route"
                  },
                  "label": "label",
                  "preview": "preview",
                  "revision": "revision"
                },
                {
                  "id": "id",
                  "initial": {
                    "dose": "dose",
                    "doseUnit": "doseUnit",
                    "duration": "duration",
                    "frequency": "frequency",
                    "maxDailyUse": "maxDailyUse",
                    "prn": true,
                    "route": "route"
                  },
                  "label": "label",
                  "preview": "preview",
                  "revision": "revision"
                }
              ],
              "object": "prescribing_options",
              "catalogItemId": "catalogItemId",
              "practiceId": "practiceId",
              "livemode": true,
              "revision": "revision",
              "catalog": {
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
              "defaultPresetId": "defaultPresetId",
              "presets": [
                {
                  "id": "id",
                  "revision": "revision",
                  "source": "affinity",
                  "directions": "directions",
                  "format": "structured",
                  "structuredSig": {
                    "dose": "dose",
                    "doseUnit": "doseUnit",
                    "frequency": "frequency",
                    "route": "route",
                    "prn": true,
                    "duration": "duration",
                    "indication": "indication",
                    "maxDailyUse": "maxDailyUse",
                    "titrationSchedule": "titrationSchedule"
                  },
                  "quantity": {
                    "value": 1.1,
                    "unit": "unit"
                  },
                  "daysSupply": 1,
                  "refills": 1
                },
                {
                  "id": "id",
                  "revision": "revision",
                  "source": "affinity",
                  "directions": "directions",
                  "format": "structured",
                  "structuredSig": {
                    "dose": "dose",
                    "doseUnit": "doseUnit",
                    "frequency": "frequency",
                    "route": "route",
                    "prn": true,
                    "duration": "duration",
                    "indication": "indication",
                    "maxDailyUse": "maxDailyUse",
                    "titrationSchedule": "titrationSchedule"
                  },
                  "quantity": {
                    "value": 1.1,
                    "unit": "unit"
                  },
                  "daysSupply": 1,
                  "refills": 1
                }
              ]
            }
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/v1/catalog/items/catalogItemId/prescribing-options")
                    .WithParam("practiceId", "practiceId")
                    .UsingGet()
            )
            .RespondWith(
                WireMock
                    .ResponseBuilders.Response.Create()
                    .WithStatusCode(200)
                    .WithBody(mockResponse)
            );

        var response = await Client.Catalog.RetrievePrescribingOptionsAsync(
            new RetrievePrescribingOptionsRequest
            {
                CatalogItemId = "catalogItemId",
                PracticeId = "practiceId",
            }
        );
        JsonAssert.AreEqual(response, mockResponse);
    }

    [NUnit.Framework.Test]
    public async Task MockServerTest_2()
    {
        const string mockResponse = """
            {
              "compoundingReason": {
                "required": true,
                "categoryRequired": true,
                "context": "not_supported",
                "contextPrompt": "contextPrompt",
                "choices": [
                  {
                    "category": "alcohol_free",
                    "label": "label",
                    "contextRequired": true
                  }
                ]
              },
              "compoundingReasonCategoryDefault": "alcohol_free",
              "compoundingReasonDefault": "compoundingReasonDefault",
              "default": {
                "directions": "directions",
                "format": "free_text",
                "source": "affinity",
                "structuredSig": {
                  "dose": "dose",
                  "doseUnit": "doseUnit",
                  "duration": "duration",
                  "frequency": "frequency",
                  "maxDailyUse": "maxDailyUse",
                  "prn": true,
                  "route": "route",
                  "titrationSchedule": "titrationSchedule"
                }
              },
              "formulationDefault": {
                "directions": "directions",
                "format": "free_text",
                "structuredSig": {
                  "dose": "dose",
                  "doseUnit": "doseUnit",
                  "duration": "duration",
                  "frequency": "frequency",
                  "maxDailyUse": "maxDailyUse",
                  "prn": true,
                  "route": "route",
                  "titrationSchedule": "titrationSchedule"
                }
              },
              "initial": {
                "dose": "dose",
                "doseUnit": "doseUnit",
                "duration": "duration",
                "frequency": "frequency",
                "maxDailyUse": "maxDailyUse",
                "prn": true,
                "route": "route",
                "titrationSchedule": "titrationSchedule"
              },
              "medication": {
                "name": "name",
                "rxnorm": {
                  "code": "code",
                  "display": "display",
                  "doseForm": "doseForm",
                  "route": "route",
                  "system": "rxnorm"
                }
              },
              "options": {
                "doseUnits": [
                  {
                    "label": "label",
                    "source": "catalog",
                    "value": "value"
                  }
                ],
                "doses": [
                  {
                    "label": "label",
                    "source": "catalog",
                    "value": "value"
                  }
                ],
                "frequencies": [
                  {
                    "label": "label",
                    "source": "catalog",
                    "value": "value"
                  }
                ],
                "routes": [
                  {
                    "label": "label",
                    "source": "catalog",
                    "value": "value"
                  }
                ]
              },
              "pharmacyDirections": [
                {
                  "directions": "directions",
                  "format": "free_text",
                  "structuredSig": {
                    "dose": "dose",
                    "doseUnit": "doseUnit",
                    "frequency": "frequency",
                    "prn": true,
                    "route": "route"
                  }
                }
              ],
              "templates": [
                {
                  "id": "id",
                  "initial": {},
                  "label": "label",
                  "preview": "preview",
                  "revision": "revision"
                }
              ],
              "object": "prescribing_options",
              "catalogItemId": "cat_01j2y8m6jcc9tt24af5pw9x1bc",
              "practiceId": "prac_01j2y8m6jcc9tt24af5pw9x1bc",
              "livemode": true,
              "revision": "revision",
              "catalog": {
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
                  "allowedDaysSupply": [
                    1
                  ],
                  "allowedQuantities": [
                    {
                      "label": "label",
                      "unit": "unit",
                      "value": "Infinity"
                    }
                  ],
                  "allowedReasonCategories": [
                    "alcohol_free"
                  ],
                  "compoundingReason": "not_required",
                  "compoundingReasonContext": "not_supported",
                  "controlledSchedule": "II",
                  "defaultDaysSupply": 1,
                  "defaultQuantity": {
                    "unit": "unit",
                    "value": "Infinity"
                  },
                  "quantityIncrement": {
                    "unit": "unit",
                    "value": "Infinity"
                  },
                  "defaultSigs": [
                    "defaultSigs"
                  ],
                  "diagnosis": "not_required",
                  "medicationReview": "optional",
                  "diagnosisReview": "optional",
                  "maxRefills": 1,
                  "notes": [
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
              },
              "defaultPresetId": "defaultPresetId",
              "presets": [
                {
                  "id": "id",
                  "revision": "revision",
                  "source": "affinity",
                  "directions": "directions",
                  "format": "structured",
                  "structuredSig": {
                    "dose": "dose",
                    "doseUnit": "doseUnit",
                    "frequency": "frequency",
                    "route": "route",
                    "prn": true
                  },
                  "quantity": {
                    "value": 1.1,
                    "unit": "unit"
                  },
                  "daysSupply": 1,
                  "refills": 1
                }
              ]
            }
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath(
                        "/v1/catalog/items/cat_01j2y8m6jcc9tt24af5pw9x1bc/prescribing-options"
                    )
                    .WithParam("practiceId", "prac_01j2y8m6jcc9tt24af5pw9x1bc")
                    .UsingGet()
            )
            .RespondWith(
                WireMock
                    .ResponseBuilders.Response.Create()
                    .WithStatusCode(200)
                    .WithBody(mockResponse)
            );

        var response = await Client.Catalog.RetrievePrescribingOptionsAsync(
            new RetrievePrescribingOptionsRequest
            {
                CatalogItemId = "cat_01j2y8m6jcc9tt24af5pw9x1bc",
                PracticeId = "prac_01j2y8m6jcc9tt24af5pw9x1bc",
            }
        );
        JsonAssert.AreEqual(response, mockResponse);
    }
}
