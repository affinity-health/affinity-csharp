using Affinity;
using Affinity.Test.Unit.MockServer;
using Affinity.Test.Utils;
using NUnit.Framework;

namespace Affinity.Test.Unit.MockServer.Orders;

[TestFixture]
[Parallelizable(ParallelScope.Self)]
public class PreviewOrderTest : BaseMockServerTest
{
    [NUnit.Framework.Test]
    public async Task MockServerTest_1()
    {
        const string requestJson = """
            {
              "practiceId": "practiceId",
              "prescriptions": [
                {
                  "medicationId": "medicationId"
                },
                {
                  "medicationId": "medicationId"
                }
              ]
            }
            """;

        const string mockResponse = """
            {
              "clinicalRequirementsSatisfied": true,
              "clinicalIssues": [
                {
                  "code": "code",
                  "path": "path",
                  "message": "message"
                },
                {
                  "code": "code",
                  "path": "path",
                  "message": "message"
                }
              ],
              "clinicalRequirements": [
                {
                  "field": "field",
                  "label": "label",
                  "type": "allergy_review",
                  "required": true,
                  "status": "missing"
                },
                {
                  "field": "field",
                  "label": "label",
                  "type": "allergy_review",
                  "required": true,
                  "status": "missing"
                }
              ],
              "otcItems": [
                {
                  "catalogItemId": "catalogItemId",
                  "name": "name",
                  "quantity": 1,
                  "unitPriceCents": 1,
                  "subtotalCents": 1
                },
                {
                  "catalogItemId": "catalogItemId",
                  "name": "name",
                  "quantity": 1,
                  "unitPriceCents": 1,
                  "subtotalCents": 1
                }
              ],
              "shippingGroups": [
                {
                  "key": "key",
                  "pharmacy": "pharmacy",
                  "label": "label",
                  "temperature": "ambient",
                  "amountCents": 1,
                  "itemCount": 1,
                  "prescriptionIndexes": [
                    1,
                    1
                  ]
                },
                {
                  "key": "key",
                  "pharmacy": "pharmacy",
                  "label": "label",
                  "temperature": "ambient",
                  "amountCents": 1,
                  "itemCount": 1,
                  "prescriptionIndexes": [
                    1,
                    1
                  ]
                }
              ],
              "totals": {
                "currency": "USD",
                "medicationSubtotalCents": 1,
                "supplySubtotalCents": 1,
                "shippingTotalCents": 1,
                "estimatedTotalCents": 1
              },
              "object": "order_preview",
              "livemode": true,
              "prescriptions": [
                {
                  "medicationId": "medicationId",
                  "revision": "revision",
                  "directions": "directions",
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
                  "format": "structured",
                  "quantity": {
                    "value": 1.1,
                    "unit": "unit"
                  },
                  "daysSupply": 1,
                  "daysSupplySource": "manual",
                  "refills": 1,
                  "shippingOptions": [
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
                  ],
                  "shippingOptionId": "shippingOptionId",
                  "medicationSubtotalCents": 1,
                  "shippingAmountCents": 1
                },
                {
                  "medicationId": "medicationId",
                  "revision": "revision",
                  "directions": "directions",
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
                  "format": "structured",
                  "quantity": {
                    "value": 1.1,
                    "unit": "unit"
                  },
                  "daysSupply": 1,
                  "daysSupplySource": "manual",
                  "refills": 1,
                  "shippingOptions": [
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
                  ],
                  "shippingOptionId": "shippingOptionId",
                  "medicationSubtotalCents": 1,
                  "shippingAmountCents": 1
                }
              ],
              "issues": [
                {
                  "code": "code",
                  "path": "path",
                  "message": "message"
                },
                {
                  "code": "code",
                  "path": "path",
                  "message": "message"
                }
              ],
              "status": "complete",
              "orderInput": {
                "otcItems": [
                  {
                    "catalogItemId": "catalogItemId",
                    "quantity": 1
                  },
                  {
                    "catalogItemId": "catalogItemId",
                    "quantity": 1
                  }
                ],
                "practiceId": "practiceId",
                "userId": "userId",
                "prescriber": {
                  "id": "id",
                  "npi": "npi",
                  "externalId": "externalId",
                  "profile": {}
                },
                "shippingAddressId": "shippingAddressId",
                "externalOrderId": "externalOrderId",
                "prescriptions": [
                  {
                    "externalPrescriptionId": "externalPrescriptionId",
                    "clinical": {
                      "compoundingReason": {},
                      "medicationReviewStatus": "not_reviewed",
                      "diagnosisReviewStatus": "not_reviewed",
                      "currentMedications": [],
                      "diagnoses": [],
                      "observations": []
                    },
                    "pharmacyId": "pharmacyId",
                    "daysSupply": 365,
                    "dispensing": {
                      "dispenseUponAcceptance": true,
                      "shippingOptionId": "shippingOptionId",
                      "shippingAmountCents": 1,
                      "shippingDestinationType": "patient",
                      "pharmacyNotes": "pharmacyNotes",
                      "requestedFillDate": "requestedFillDate",
                      "substitutionPermitted": true
                    },
                    "directions": "directions",
                    "medicationId": "medicationId",
                    "quantity": 1.1,
                    "quantityUnit": "quantityUnit",
                    "refills": 99,
                    "structuredSig": {
                      "dose": "dose",
                      "doseUnit": "doseUnit",
                      "duration": "duration",
                      "frequency": "frequency",
                      "indication": "indication",
                      "maxDailyUse": "maxDailyUse",
                      "prn": true,
                      "route": "route",
                      "titrationSchedule": "titrationSchedule"
                    }
                  },
                  {
                    "externalPrescriptionId": "externalPrescriptionId",
                    "clinical": {
                      "compoundingReason": {},
                      "medicationReviewStatus": "not_reviewed",
                      "diagnosisReviewStatus": "not_reviewed",
                      "currentMedications": [],
                      "diagnoses": [],
                      "observations": []
                    },
                    "pharmacyId": "pharmacyId",
                    "daysSupply": 365,
                    "dispensing": {
                      "dispenseUponAcceptance": true,
                      "shippingOptionId": "shippingOptionId",
                      "shippingAmountCents": 1,
                      "shippingDestinationType": "patient",
                      "pharmacyNotes": "pharmacyNotes",
                      "requestedFillDate": "requestedFillDate",
                      "substitutionPermitted": true
                    },
                    "directions": "directions",
                    "medicationId": "medicationId",
                    "quantity": 1.1,
                    "quantityUnit": "quantityUnit",
                    "refills": 99,
                    "structuredSig": {
                      "dose": "dose",
                      "doseUnit": "doseUnit",
                      "duration": "duration",
                      "frequency": "frequency",
                      "indication": "indication",
                      "maxDailyUse": "maxDailyUse",
                      "prn": true,
                      "route": "route",
                      "titrationSchedule": "titrationSchedule"
                    }
                  }
                ],
                "patientId": "patientId",
                "patient": {
                  "address": {
                    "city": "city",
                    "line1": "line1",
                    "postalCode": "postalCode",
                    "state": "state"
                  },
                  "clinicalProfile": {
                    "currentMedications": [
                      "currentMedications",
                      "currentMedications"
                    ]
                  },
                  "dateOfBirth": "dateOfBirth",
                  "email": "email",
                  "externalId": "externalId",
                  "externalIdentities": [
                    {
                      "source": "source",
                      "value": "value"
                    },
                    {
                      "source": "source",
                      "value": "value"
                    }
                  ],
                  "addresses": [],
                  "encounters": [
                    {
                      "occurredAt": "occurredAt",
                      "type": "type"
                    },
                    {
                      "occurredAt": "occurredAt",
                      "type": "type"
                    }
                  ],
                  "gender": "f",
                  "locationId": "locationId",
                  "metadata": {
                    "metadata": {
                      "key": "value"
                    }
                  },
                  "medicalRecordNumber": "medicalRecordNumber",
                  "measurements": [
                    {
                      "recordedAt": "recordedAt",
                      "source": "source"
                    },
                    {
                      "recordedAt": "recordedAt",
                      "source": "source"
                    }
                  ],
                  "name": {
                    "first": "first",
                    "last": "last",
                    "middle": "middle",
                    "preferred": "preferred"
                  },
                  "phone": "phone",
                  "programs": [
                    {
                      "name": "name",
                      "startedAt": "startedAt",
                      "status": "active"
                    },
                    {
                      "name": "name",
                      "startedAt": "startedAt",
                      "status": "active"
                    }
                  ]
                }
              }
            }
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/v1/order-previews")
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

        var response = await Client.Orders.PreviewOrderAsync(
            new PreviewOrderRequest
            {
                OtcItems = null,
                PracticeId = "practiceId",
                PatientId = null,
                PatientExternalId = null,
                Patient = null,
                UserId = null,
                Prescriber = null,
                ShippingAddressId = null,
                ExternalOrderId = null,
                Prescriptions = new List<PreviewOrderRequestPrescriptionsItem>()
                {
                    new PreviewOrderRequestPrescriptionsItem
                    {
                        MedicationId = "medicationId",
                        ExternalPrescriptionId = null,
                        Preset = null,
                        ExpectedRevision = null,
                        Overrides = null,
                    },
                    new PreviewOrderRequestPrescriptionsItem
                    {
                        MedicationId = "medicationId",
                        ExternalPrescriptionId = null,
                        Preset = null,
                        ExpectedRevision = null,
                        Overrides = null,
                    },
                },
                Shipping = null,
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
              "prescriptions": [
                {
                  "medicationId": "cat_01j2y8m6jcc9tt24af5pw9x1bc"
                }
              ]
            }
            """;

        const string mockResponse = """
            {
              "clinicalRequirementsSatisfied": true,
              "clinicalIssues": [
                {
                  "code": "code",
                  "path": "path",
                  "message": "message"
                }
              ],
              "clinicalRequirements": [
                {
                  "field": "field",
                  "label": "label",
                  "type": "allergy_review",
                  "required": true,
                  "status": "missing"
                }
              ],
              "otcItems": [
                {
                  "catalogItemId": "cat_01j2y8m6jcc9tt24af5pw9x1bc",
                  "name": "name",
                  "quantity": 1,
                  "unitPriceCents": 1,
                  "subtotalCents": 1
                }
              ],
              "shippingGroups": [
                {
                  "key": "key",
                  "pharmacy": "pharmacy",
                  "label": "label",
                  "temperature": "ambient",
                  "amountCents": 1,
                  "itemCount": 1,
                  "prescriptionIndexes": [
                    1
                  ]
                }
              ],
              "totals": {
                "currency": "USD",
                "medicationSubtotalCents": 1,
                "supplySubtotalCents": 1,
                "shippingTotalCents": 1,
                "estimatedTotalCents": 1
              },
              "object": "order_preview",
              "livemode": true,
              "prescriptions": [
                {
                  "medicationId": "cat_01j2y8m6jcc9tt24af5pw9x1bc",
                  "revision": "revision",
                  "directions": "directions",
                  "structuredSig": {
                    "dose": "dose",
                    "doseUnit": "doseUnit",
                    "frequency": "frequency",
                    "route": "route",
                    "prn": true
                  },
                  "format": "structured",
                  "quantity": {
                    "value": 1.1,
                    "unit": "unit"
                  },
                  "daysSupply": 1,
                  "daysSupplySource": "manual",
                  "refills": 1,
                  "shippingOptions": [
                    {
                      "amountCents": 1,
                      "currency": "USD",
                      "id": "id",
                      "label": "label",
                      "serviceLevel": "serviceLevel",
                      "temperature": "ambient"
                    }
                  ],
                  "shippingOptionId": "shp_01j2y8m6jcc9tt24af5pw9x1bc",
                  "medicationSubtotalCents": 1,
                  "shippingAmountCents": 1
                }
              ],
              "issues": [
                {
                  "code": "code",
                  "path": "path",
                  "message": "message"
                }
              ],
              "status": "complete",
              "orderInput": {
                "otcItems": [
                  {
                    "catalogItemId": "catalogItemId",
                    "quantity": 1
                  }
                ],
                "practiceId": "prac_01j2y8m6jcc9tt24af5pw9x1bc",
                "userId": "userId",
                "prescriber": {
                  "id": "id",
                  "npi": "npi",
                  "externalId": "externalId"
                },
                "shippingAddressId": "shippingAddressId",
                "externalOrderId": "externalOrderId",
                "prescriptions": [
                  {
                    "daysSupply": 1,
                    "dispensing": {
                      "shippingOptionId": "shp_01j2y8m6jcc9tt24af5pw9x1bc"
                    },
                    "directions": "directions",
                    "medicationId": "cat_01j2y8m6jcc9tt24af5pw9x1bc",
                    "quantity": 1.1,
                    "quantityUnit": "quantityUnit",
                    "refills": 1
                  }
                ],
                "patientId": "pat_01j2y8m6jcc9tt24af5pw9x1bc",
                "patient": {
                  "address": {
                    "city": "city",
                    "line1": "line1",
                    "postalCode": "postalCode",
                    "state": "state"
                  },
                  "clinicalProfile": {
                    "currentMedications": [
                      "currentMedications"
                    ]
                  },
                  "dateOfBirth": "dateOfBirth",
                  "email": "email",
                  "externalId": "externalId",
                  "externalIdentities": [
                    {
                      "source": "source",
                      "value": "value"
                    }
                  ],
                  "addresses": [
                    {
                      "address": {
                        "city": "city",
                        "line1": "line1",
                        "postalCode": "postalCode",
                        "state": "state"
                      },
                      "label": "label",
                      "preferredShipping": true
                    }
                  ],
                  "encounters": [
                    {
                      "occurredAt": "occurredAt",
                      "type": "type"
                    }
                  ],
                  "gender": "f",
                  "locationId": "locationId",
                  "metadata": {
                    "key": "value"
                  },
                  "medicalRecordNumber": "medicalRecordNumber",
                  "measurements": [
                    {
                      "recordedAt": "recordedAt",
                      "source": "source"
                    }
                  ],
                  "name": {
                    "first": "first",
                    "last": "last"
                  },
                  "phone": "phone",
                  "programs": [
                    {
                      "name": "name",
                      "startedAt": "startedAt",
                      "status": "active"
                    }
                  ]
                }
              }
            }
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/v1/order-previews")
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

        var response = await Client.Orders.PreviewOrderAsync(
            new PreviewOrderRequest
            {
                PracticeId = "prac_01j2y8m6jcc9tt24af5pw9x1bc",
                Prescriptions = new List<PreviewOrderRequestPrescriptionsItem>()
                {
                    new PreviewOrderRequestPrescriptionsItem
                    {
                        MedicationId = "cat_01j2y8m6jcc9tt24af5pw9x1bc",
                    },
                },
            }
        );
        JsonAssert.AreEqual(response, mockResponse);
    }
}
