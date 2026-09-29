using Affinity;
using Affinity.Test.Unit.MockServer;
using Affinity.Test.Utils;
using NUnit.Framework;

namespace Affinity.Test.Unit.MockServer.Orders;

[TestFixture]
[Parallelizable(ParallelScope.Self)]
public class CreateOrderBatchTest : BaseMockServerTest
{
    [NUnit.Framework.Test]
    public async Task MockServerTest_1()
    {
        const string requestJson = """
            {
              "practiceId": "practiceId",
              "orders": [
                {
                  "prescriptions": [
                    {
                      "daysSupply": 365,
                      "dispensing": {},
                      "directions": "directions",
                      "medicationId": "medicationId",
                      "quantity": "Infinity",
                      "quantityUnit": "quantityUnit",
                      "refills": 99
                    },
                    {
                      "daysSupply": 365,
                      "dispensing": {},
                      "directions": "directions",
                      "medicationId": "medicationId",
                      "quantity": "Infinity",
                      "quantityUnit": "quantityUnit",
                      "refills": 99
                    }
                  ]
                },
                {
                  "prescriptions": [
                    {
                      "daysSupply": 365,
                      "dispensing": {},
                      "directions": "directions",
                      "medicationId": "medicationId",
                      "quantity": "Infinity",
                      "quantityUnit": "quantityUnit",
                      "refills": 99
                    },
                    {
                      "daysSupply": 365,
                      "dispensing": {},
                      "directions": "directions",
                      "medicationId": "medicationId",
                      "quantity": "Infinity",
                      "quantityUnit": "quantityUnit",
                      "refills": 99
                    }
                  ]
                }
              ]
            }
            """;

        const string mockResponse = """
            {
              "object": "order_batch",
              "practiceId": "practiceId",
              "userId": "userId",
              "livemode": true,
              "orders": [
                {
                  "revision": "revision",
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
                  "externalOrderId": "x",
                  "metadata": {},
                  "createdAt": "createdAt",
                  "id": "id",
                  "livemode": true,
                  "object": "order",
                  "patientId": "patientId",
                  "practiceId": "practiceId",
                  "prescriptions": [
                    {
                      "pharmacyId": "pharmacyId",
                      "externalPrescriptionId": "externalPrescriptionId",
                      "createdAt": "createdAt",
                      "directions": "directions",
                      "version": 1,
                      "id": "id",
                      "medicationId": "medicationId",
                      "medicationName": "medicationName",
                      "object": "prescription",
                      "quantity": "Infinity",
                      "quantityUnit": "quantityUnit",
                      "refills": 1,
                      "status": "requires_provider_signature"
                    },
                    {
                      "pharmacyId": "pharmacyId",
                      "externalPrescriptionId": "externalPrescriptionId",
                      "createdAt": "createdAt",
                      "directions": "directions",
                      "version": 1,
                      "id": "id",
                      "medicationId": "medicationId",
                      "medicationName": "medicationName",
                      "object": "prescription",
                      "quantity": "Infinity",
                      "quantityUnit": "quantityUnit",
                      "refills": 1,
                      "status": "requires_provider_signature"
                    }
                  ],
                  "userId": "userId",
                  "status": "requires_provider_signature"
                },
                {
                  "revision": "revision",
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
                  "externalOrderId": "x",
                  "metadata": {},
                  "createdAt": "createdAt",
                  "id": "id",
                  "livemode": true,
                  "object": "order",
                  "patientId": "patientId",
                  "practiceId": "practiceId",
                  "prescriptions": [
                    {
                      "pharmacyId": "pharmacyId",
                      "externalPrescriptionId": "externalPrescriptionId",
                      "createdAt": "createdAt",
                      "directions": "directions",
                      "version": 1,
                      "id": "id",
                      "medicationId": "medicationId",
                      "medicationName": "medicationName",
                      "object": "prescription",
                      "quantity": "Infinity",
                      "quantityUnit": "quantityUnit",
                      "refills": 1,
                      "status": "requires_provider_signature"
                    },
                    {
                      "pharmacyId": "pharmacyId",
                      "externalPrescriptionId": "externalPrescriptionId",
                      "createdAt": "createdAt",
                      "directions": "directions",
                      "version": 1,
                      "id": "id",
                      "medicationId": "medicationId",
                      "medicationName": "medicationName",
                      "object": "prescription",
                      "quantity": "Infinity",
                      "quantityUnit": "quantityUnit",
                      "refills": 1,
                      "status": "requires_provider_signature"
                    }
                  ],
                  "userId": "userId",
                  "status": "requires_provider_signature"
                }
              ]
            }
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/v1/order-batches")
                    .WithHeader("Idempotency-Key", "idempotencyKey")
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

        var response = await Client.Orders.CreateOrderBatchAsync(
            new CreateOrderBatchRequest
            {
                IdempotencyKey = "idempotencyKey",
                PracticeId = "practiceId",
                UserId = null,
                Prescriber = null,
                Orders = new List<CreateOrderBatchRequestOrdersItem>()
                {
                    new CreateOrderBatchRequestOrdersItem
                    {
                        OtcItems = null,
                        ExternalOrderId = null,
                        Metadata = null,
                        PatientId = null,
                        Patient = null,
                        ShippingAddressId = null,
                        Prescriptions =
                            new List<CreateOrderBatchRequestOrdersItemPrescriptionsItem>()
                            {
                                new CreateOrderBatchRequestOrdersItemPrescriptionsItem
                                {
                                    ExternalPrescriptionId = null,
                                    Clinical = null,
                                    PharmacyId = null,
                                    DaysSupply = 365,
                                    Dispensing =
                                        new CreateOrderBatchRequestOrdersItemPrescriptionsItemDispensing
                                        {
                                            DispenseUponAcceptance = null,
                                            ShippingOptionId = null,
                                            ShippingAmountCents = null,
                                            ShippingDestinationType = null,
                                            PharmacyNotes = null,
                                            RequestedFillDate = null,
                                            SubstitutionPermitted = null,
                                        },
                                    Directions = "directions",
                                    MedicationId = "medicationId",
                                    Quantity =
                                        CreateOrderBatchRequestOrdersItemPrescriptionsItemQuantityOne.Infinity,
                                    QuantityUnit = "quantityUnit",
                                    Refills = 99,
                                    StructuredSig = null,
                                },
                                new CreateOrderBatchRequestOrdersItemPrescriptionsItem
                                {
                                    ExternalPrescriptionId = null,
                                    Clinical = null,
                                    PharmacyId = null,
                                    DaysSupply = 365,
                                    Dispensing =
                                        new CreateOrderBatchRequestOrdersItemPrescriptionsItemDispensing
                                        {
                                            DispenseUponAcceptance = null,
                                            ShippingOptionId = null,
                                            ShippingAmountCents = null,
                                            ShippingDestinationType = null,
                                            PharmacyNotes = null,
                                            RequestedFillDate = null,
                                            SubstitutionPermitted = null,
                                        },
                                    Directions = "directions",
                                    MedicationId = "medicationId",
                                    Quantity =
                                        CreateOrderBatchRequestOrdersItemPrescriptionsItemQuantityOne.Infinity,
                                    QuantityUnit = "quantityUnit",
                                    Refills = 99,
                                    StructuredSig = null,
                                },
                            },
                    },
                    new CreateOrderBatchRequestOrdersItem
                    {
                        OtcItems = null,
                        ExternalOrderId = null,
                        Metadata = null,
                        PatientId = null,
                        Patient = null,
                        ShippingAddressId = null,
                        Prescriptions =
                            new List<CreateOrderBatchRequestOrdersItemPrescriptionsItem>()
                            {
                                new CreateOrderBatchRequestOrdersItemPrescriptionsItem
                                {
                                    ExternalPrescriptionId = null,
                                    Clinical = null,
                                    PharmacyId = null,
                                    DaysSupply = 365,
                                    Dispensing =
                                        new CreateOrderBatchRequestOrdersItemPrescriptionsItemDispensing
                                        {
                                            DispenseUponAcceptance = null,
                                            ShippingOptionId = null,
                                            ShippingAmountCents = null,
                                            ShippingDestinationType = null,
                                            PharmacyNotes = null,
                                            RequestedFillDate = null,
                                            SubstitutionPermitted = null,
                                        },
                                    Directions = "directions",
                                    MedicationId = "medicationId",
                                    Quantity =
                                        CreateOrderBatchRequestOrdersItemPrescriptionsItemQuantityOne.Infinity,
                                    QuantityUnit = "quantityUnit",
                                    Refills = 99,
                                    StructuredSig = null,
                                },
                                new CreateOrderBatchRequestOrdersItemPrescriptionsItem
                                {
                                    ExternalPrescriptionId = null,
                                    Clinical = null,
                                    PharmacyId = null,
                                    DaysSupply = 365,
                                    Dispensing =
                                        new CreateOrderBatchRequestOrdersItemPrescriptionsItemDispensing
                                        {
                                            DispenseUponAcceptance = null,
                                            ShippingOptionId = null,
                                            ShippingAmountCents = null,
                                            ShippingDestinationType = null,
                                            PharmacyNotes = null,
                                            RequestedFillDate = null,
                                            SubstitutionPermitted = null,
                                        },
                                    Directions = "directions",
                                    MedicationId = "medicationId",
                                    Quantity =
                                        CreateOrderBatchRequestOrdersItemPrescriptionsItemQuantityOne.Infinity,
                                    QuantityUnit = "quantityUnit",
                                    Refills = 99,
                                    StructuredSig = null,
                                },
                            },
                    },
                },
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
              "orders": [
                {
                  "prescriptions": [
                    {
                      "daysSupply": 1,
                      "dispensing": {},
                      "directions": "directions",
                      "medicationId": "cat_01j2y8m6jcc9tt24af5pw9x1bc",
                      "quantity": "Infinity",
                      "quantityUnit": "quantityUnit",
                      "refills": 1
                    }
                  ]
                }
              ]
            }
            """;

        const string mockResponse = """
            {
              "object": "order_batch",
              "practiceId": "prac_01j2y8m6jcc9tt24af5pw9x1bc",
              "userId": "user_01j2y8m6jcc9tt24af5pw9x1bc",
              "livemode": true,
              "orders": [
                {
                  "revision": "revision",
                  "otcItems": [
                    {
                      "catalogItemId": "catalogItemId",
                      "name": "name",
                      "quantity": 1,
                      "unitPriceCents": 1,
                      "subtotalCents": 1
                    }
                  ],
                  "externalOrderId": "externalOrderId",
                  "metadata": {},
                  "createdAt": "createdAt",
                  "id": "ord_01j2y8m6jcc9tt24af5pw9x1bc",
                  "livemode": true,
                  "object": "order",
                  "patientId": "pat_01j2y8m6jcc9tt24af5pw9x1bc",
                  "practiceId": "prac_01j2y8m6jcc9tt24af5pw9x1bc",
                  "prescriptions": [
                    {
                      "pharmacyId": "pharmacyId",
                      "createdAt": "createdAt",
                      "directions": "directions",
                      "version": 1,
                      "id": "id",
                      "medicationName": "medicationName",
                      "object": "prescription",
                      "quantity": "Infinity",
                      "quantityUnit": "quantityUnit",
                      "refills": 1,
                      "status": "requires_provider_signature"
                    }
                  ],
                  "userId": "user_01j2y8m6jcc9tt24af5pw9x1bc",
                  "status": "requires_provider_signature"
                }
              ]
            }
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/v1/order-batches")
                    .WithHeader("Idempotency-Key", "Idempotency-Key")
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

        var response = await Client.Orders.CreateOrderBatchAsync(
            new CreateOrderBatchRequest
            {
                IdempotencyKey = "Idempotency-Key",
                PracticeId = "prac_01j2y8m6jcc9tt24af5pw9x1bc",
                Orders = new List<CreateOrderBatchRequestOrdersItem>()
                {
                    new CreateOrderBatchRequestOrdersItem
                    {
                        Prescriptions =
                            new List<CreateOrderBatchRequestOrdersItemPrescriptionsItem>()
                            {
                                new CreateOrderBatchRequestOrdersItemPrescriptionsItem
                                {
                                    DaysSupply = 1,
                                    Dispensing =
                                        new CreateOrderBatchRequestOrdersItemPrescriptionsItemDispensing(),
                                    Directions = "directions",
                                    MedicationId = "cat_01j2y8m6jcc9tt24af5pw9x1bc",
                                    Quantity =
                                        CreateOrderBatchRequestOrdersItemPrescriptionsItemQuantityOne.Infinity,
                                    QuantityUnit = "quantityUnit",
                                    Refills = 1,
                                },
                            },
                    },
                },
            }
        );
        JsonAssert.AreEqual(response, mockResponse);
    }
}
