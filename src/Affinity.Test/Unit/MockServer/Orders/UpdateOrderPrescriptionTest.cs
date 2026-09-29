using Affinity;
using Affinity.Test.Unit.MockServer;
using Affinity.Test.Utils;
using NUnit.Framework;

namespace Affinity.Test.Unit.MockServer.Orders;

[TestFixture]
[Parallelizable(ParallelScope.Self)]
public class UpdateOrderPrescriptionTest : BaseMockServerTest
{
    [NUnit.Framework.Test]
    public async Task MockServerTest_1()
    {
        const string requestJson = """
            {
              "practiceId": "practiceId",
              "prescription": {
                "daysSupply": 365,
                "dispensing": {},
                "directions": "directions",
                "medicationId": "medicationId",
                "quantity": "Infinity",
                "quantityUnit": "quantityUnit",
                "refills": 99
              }
            }
            """;

        const string mockResponse = """
            {
              "revision": "revision",
              "object": "order_draft_update",
              "externalOrderId": "x",
              "metadata": {},
              "orderId": "orderId",
              "prescriptionId": "prescriptionId",
              "prescriptions": [
                {
                  "id": "id",
                  "externalPrescriptionId": "externalPrescriptionId",
                  "version": 1
                },
                {
                  "id": "id",
                  "externalPrescriptionId": "externalPrescriptionId",
                  "version": 1
                }
              ]
            }
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/v1/orders/orderId/prescriptions/prescriptionId")
                    .WithHeader("Idempotency-Key", "idempotencyKey")
                    .WithHeader("Content-Type", "application/json")
                    .UsingPatch()
                    .WithBodyAsJson(requestJson)
            )
            .RespondWith(
                WireMock
                    .ResponseBuilders.Response.Create()
                    .WithStatusCode(200)
                    .WithBody(mockResponse)
            );

        var response = await Client.Orders.UpdateOrderPrescriptionAsync(
            new UpdateOrderPrescriptionRequest
            {
                OrderId = "orderId",
                PrescriptionId = "prescriptionId",
                IdempotencyKey = "idempotencyKey",
                Metadata = null,
                PracticeId = "practiceId",
                ExpectedRevision = null,
                ExpectedVersions = null,
                Prescription = new UpdateOrderPrescriptionRequestPrescription
                {
                    Clinical = null,
                    PharmacyId = null,
                    DaysSupply = 365,
                    Dispensing = new UpdateOrderPrescriptionRequestPrescriptionDispensing
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
                    Quantity = UpdateOrderPrescriptionRequestPrescriptionQuantityOne.Infinity,
                    QuantityUnit = "quantityUnit",
                    Refills = 99,
                    StructuredSig = null,
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
              "prescription": {
                "daysSupply": 1,
                "dispensing": {},
                "directions": "directions",
                "medicationId": "cat_01j2y8m6jcc9tt24af5pw9x1bc",
                "quantity": "Infinity",
                "quantityUnit": "quantityUnit",
                "refills": 1
              }
            }
            """;

        const string mockResponse = """
            {
              "revision": "revision",
              "object": "order_draft_update",
              "externalOrderId": "externalOrderId",
              "metadata": {},
              "orderId": "ord_01j2y8m6jcc9tt24af5pw9x1bc",
              "prescriptionId": "rx_01j2y8m6jcc9tt24af5pw9x1bc",
              "prescriptions": [
                {
                  "id": "id",
                  "externalPrescriptionId": "externalPrescriptionId",
                  "version": 1
                }
              ]
            }
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath(
                        "/v1/orders/ord_01j2y8m6jcc9tt24af5pw9x1bc/prescriptions/rx_01j2y8m6jcc9tt24af5pw9x1bc"
                    )
                    .WithHeader("Idempotency-Key", "Idempotency-Key")
                    .WithHeader("Content-Type", "application/json")
                    .UsingPatch()
                    .WithBodyAsJson(requestJson)
            )
            .RespondWith(
                WireMock
                    .ResponseBuilders.Response.Create()
                    .WithStatusCode(200)
                    .WithBody(mockResponse)
            );

        var response = await Client.Orders.UpdateOrderPrescriptionAsync(
            new UpdateOrderPrescriptionRequest
            {
                OrderId = "ord_01j2y8m6jcc9tt24af5pw9x1bc",
                PrescriptionId = "rx_01j2y8m6jcc9tt24af5pw9x1bc",
                IdempotencyKey = "Idempotency-Key",
                PracticeId = "prac_01j2y8m6jcc9tt24af5pw9x1bc",
                Prescription = new UpdateOrderPrescriptionRequestPrescription
                {
                    DaysSupply = 1,
                    Dispensing = new UpdateOrderPrescriptionRequestPrescriptionDispensing(),
                    Directions = "directions",
                    MedicationId = "cat_01j2y8m6jcc9tt24af5pw9x1bc",
                    Quantity = UpdateOrderPrescriptionRequestPrescriptionQuantityOne.Infinity,
                    QuantityUnit = "quantityUnit",
                    Refills = 1,
                },
            }
        );
        JsonAssert.AreEqual(response, mockResponse);
    }
}
