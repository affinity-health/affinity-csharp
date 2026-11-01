using Affinity;
using Affinity.Test.Unit.MockServer;
using Affinity.Test.Utils;
using NUnit.Framework;

namespace Affinity.Test.Unit.MockServer.Orders;

[TestFixture]
[Parallelizable(ParallelScope.Self)]
public class CreateTest : BaseMockServerTest
{
    [NUnit.Framework.Test]
    public async Task MockServerTest_1()
    {
        const string requestJson = """
            {
              "patient": {
                "address": {
                  "line1": "line1",
                  "city": "city",
                  "state": "state",
                  "postalCode": "postalCode"
                },
                "allergies": [
                  {
                    "category": "drug",
                    "display": "x"
                  },
                  {
                    "category": "drug",
                    "display": "x"
                  }
                ],
                "dateOfBirth": "dateOfBirth",
                "email": "email",
                "firstName": "firstName",
                "sex": "female",
                "lastName": "lastName",
                "phone": "phone"
              },
              "prescriptions": [
                {
                  "directions": "directions",
                  "medicationId": "medicationId",
                  "quantity": 10000,
                  "refills": 99
                },
                {
                  "directions": "directions",
                  "medicationId": "medicationId",
                  "quantity": 10000,
                  "refills": 99
                }
              ],
              "shipping": {
                "optionId": "optionId"
              },
              "signatureAttestation": true
            }
            """;

        const string mockResponse = """
            {
              "cancelRequestedAt": "2024-01-15T09:30:00.000Z",
              "createdAt": "2024-01-15T09:30:00.000Z",
              "externalOrderId": "externalOrderId",
              "failureReason": "failureReason",
              "id": "id",
              "mode": "test",
              "patient": {
                "address": {
                  "line1": "line1",
                  "line2": "line2",
                  "city": "city",
                  "state": "state",
                  "postalCode": "postalCode"
                },
                "allergies": [
                  {
                    "category": "drug",
                    "display": "display"
                  },
                  {
                    "category": "drug",
                    "display": "display"
                  }
                ],
                "dateOfBirth": "2023-01-15",
                "email": "email",
                "firstName": "firstName",
                "sex": "female",
                "lastName": "lastName",
                "middleName": "middleName",
                "phone": "phone"
              },
              "patientId": "patientId",
              "practice": {
                "address": {
                  "line1": "line1",
                  "line2": "line2",
                  "city": "city",
                  "state": "state",
                  "postalCode": "postalCode"
                },
                "name": "name",
                "phone": "phone",
                "archivedAt": "2024-01-15T09:30:00.000Z"
              },
              "practiceId": "practiceId",
              "prescriber": {
                "firstName": "firstName",
                "lastName": "lastName",
                "npi": "npi",
                "phone": "phone",
                "address": {
                  "line1": "line1",
                  "line2": "line2",
                  "city": "city",
                  "state": "state",
                  "postalCode": "postalCode"
                }
              },
              "prescriptions": [
                {
                  "compoundingReason": "compoundingReason",
                  "directions": "directions",
                  "id": "id",
                  "pharmacy": {
                    "id": "id",
                    "name": "name"
                  },
                  "status": "awaiting_approval",
                  "failureReason": "failureReason",
                  "medication": {
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
                    "id": "id",
                    "name": "name",
                    "quantityUnit": "quantityUnit",
                    "strength": "strength"
                  },
                  "notes": "notes",
                  "price": 1,
                  "quantity": 1,
                  "refills": 1,
                  "substitutionPermitted": true
                },
                {
                  "compoundingReason": "compoundingReason",
                  "directions": "directions",
                  "id": "id",
                  "pharmacy": {
                    "id": "id",
                    "name": "name"
                  },
                  "status": "awaiting_approval",
                  "failureReason": "failureReason",
                  "medication": {
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
                    "id": "id",
                    "name": "name",
                    "quantityUnit": "quantityUnit",
                    "strength": "strength"
                  },
                  "notes": "notes",
                  "price": 1,
                  "quantity": 1,
                  "refills": 1,
                  "substitutionPermitted": true
                }
              ],
              "shipping": {
                "option": {
                  "id": "id",
                  "name": "name",
                  "price": 1
                },
                "destination": {
                  "type": "patient"
                }
              },
              "shipments": [
                {
                  "carrier": "carrier",
                  "trackingNumber": "trackingNumber",
                  "trackingUrl": "trackingUrl"
                },
                {
                  "carrier": "carrier",
                  "trackingNumber": "trackingNumber",
                  "trackingUrl": "trackingUrl"
                }
              ],
              "status": "awaiting_approval",
              "trackingUrl": "trackingUrl",
              "statusHistory": [
                {
                  "createdAt": "2024-01-15T09:30:00.000Z",
                  "status": "awaiting_approval"
                },
                {
                  "createdAt": "2024-01-15T09:30:00.000Z",
                  "status": "awaiting_approval"
                }
              ],
              "total": 1,
              "updatedAt": "2024-01-15T09:30:00.000Z"
            }
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/v1/orders")
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

        var response = await Client.Orders.CreateAsync(
            new OrderInput
            {
                IdempotencyKey = "idempotencyKey",
                ExternalOrderId = null,
                Patient = new PatientInput
                {
                    Address = new AddressInput
                    {
                        Line1 = "line1",
                        Line2 = null,
                        City = "city",
                        State = "state",
                        PostalCode = "postalCode",
                    },
                    Allergies = new List<PatientInputAllergiesItem>()
                    {
                        new PatientInputAllergiesItem
                        {
                            Category = PatientInputAllergiesItemCategory.Drug,
                            Display = "x",
                        },
                        new PatientInputAllergiesItem
                        {
                            Category = PatientInputAllergiesItemCategory.Drug,
                            Display = "x",
                        },
                    },
                    DateOfBirth = "dateOfBirth",
                    Email = "email",
                    FirstName = "firstName",
                    Sex = PatientInputSex.Female,
                    LastName = "lastName",
                    MiddleName = null,
                    Phone = "phone",
                    ExternalId = null,
                },
                PracticeId = null,
                Prescriber = null,
                Prescriptions = new List<PrescriptionInput>()
                {
                    new PrescriptionInput
                    {
                        CompoundingReason = null,
                        Directions = "directions",
                        MedicationId = "medicationId",
                        Notes = null,
                        Quantity = 10000,
                        Refills = 99,
                        SubstitutionPermitted = null,
                    },
                    new PrescriptionInput
                    {
                        CompoundingReason = null,
                        Directions = "directions",
                        MedicationId = "medicationId",
                        Notes = null,
                        Quantity = 10000,
                        Refills = 99,
                        SubstitutionPermitted = null,
                    },
                },
                Shipping = new OrderInputShipping { OptionId = "optionId", Destination = null },
                SignatureAttestation = true,
            }
        );
        JsonAssert.AreEqual(response, mockResponse);
    }

    [NUnit.Framework.Test]
    public async Task MockServerTest_2()
    {
        const string requestJson = """
            {
              "patient": {
                "address": {
                  "line1": "line1",
                  "city": "city",
                  "state": "state",
                  "postalCode": "postalCode"
                },
                "allergies": [
                  {
                    "category": "drug",
                    "display": "display"
                  }
                ],
                "dateOfBirth": "dateOfBirth",
                "email": "email",
                "firstName": "firstName",
                "sex": "female",
                "lastName": "lastName",
                "phone": "phone"
              },
              "prescriptions": [
                {
                  "directions": "directions",
                  "medicationId": "med_01j2y8m6jcc9tt24af5pw9x1bc",
                  "quantity": 1,
                  "refills": 1
                }
              ],
              "shipping": {
                "optionId": "shp_01j2y8m6jcc9tt24af5pw9x1bc"
              },
              "signatureAttestation": true
            }
            """;

        const string mockResponse = """
            {
              "cancelRequestedAt": "2024-01-15T09:30:00.000Z",
              "createdAt": "2024-01-15T09:30:00.000Z",
              "externalOrderId": "externalOrderId",
              "failureReason": "failureReason",
              "id": "ord_01j2y8m6jcc9tt24af5pw9x1bc",
              "mode": "test",
              "patient": {
                "address": {
                  "line1": "line1",
                  "line2": "line2",
                  "city": "city",
                  "state": "state",
                  "postalCode": "postalCode"
                },
                "allergies": [
                  {
                    "category": "drug",
                    "display": "display"
                  }
                ],
                "dateOfBirth": "2023-01-15",
                "email": "email",
                "firstName": "firstName",
                "sex": "female",
                "lastName": "lastName",
                "middleName": "middleName",
                "phone": "phone"
              },
              "patientId": "pat_01j2y8m6jcc9tt24af5pw9x1bc",
              "practice": {
                "address": {
                  "line1": "line1",
                  "line2": "line2",
                  "city": "city",
                  "state": "state",
                  "postalCode": "postalCode"
                },
                "name": "name",
                "phone": "phone",
                "archivedAt": "2024-01-15T09:30:00.000Z"
              },
              "practiceId": "prac_01j2y8m6jcc9tt24af5pw9x1bc",
              "prescriber": {
                "firstName": "firstName",
                "lastName": "lastName",
                "npi": "npi",
                "phone": "phone",
                "address": {
                  "line1": "line1",
                  "line2": "line2",
                  "city": "city",
                  "state": "state",
                  "postalCode": "postalCode"
                }
              },
              "prescriptions": [
                {
                  "compoundingReason": "compoundingReason",
                  "directions": "directions",
                  "id": "rx_01j2y8m6jcc9tt24af5pw9x1bc",
                  "pharmacy": {
                    "id": "pharm_01j2y8m6jcc9tt24af5pw9x1bc",
                    "name": "name"
                  },
                  "status": "awaiting_approval",
                  "failureReason": "failureReason",
                  "medication": {
                    "id": "med_01j2y8m6jcc9tt24af5pw9x1bc",
                    "name": "name"
                  },
                  "notes": "notes",
                  "price": 1,
                  "quantity": 1,
                  "refills": 1,
                  "substitutionPermitted": true
                }
              ],
              "shipping": {
                "option": {
                  "id": "shp_01j2y8m6jcc9tt24af5pw9x1bc",
                  "name": "name",
                  "price": 1
                },
                "destination": {
                  "type": "patient"
                }
              },
              "shipments": [
                {
                  "carrier": "carrier",
                  "trackingNumber": "trackingNumber",
                  "trackingUrl": "trackingUrl"
                }
              ],
              "status": "awaiting_approval",
              "trackingUrl": "trackingUrl",
              "statusHistory": [
                {
                  "createdAt": "2024-01-15T09:30:00.000Z",
                  "status": "awaiting_approval"
                }
              ],
              "total": 1,
              "updatedAt": "2024-01-15T09:30:00.000Z"
            }
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/v1/orders")
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

        var response = await Client.Orders.CreateAsync(
            new OrderInput
            {
                IdempotencyKey = "Idempotency-Key",
                Patient = new PatientInput
                {
                    Address = new AddressInput
                    {
                        Line1 = "line1",
                        City = "city",
                        State = "state",
                        PostalCode = "postalCode",
                    },
                    Allergies = new List<PatientInputAllergiesItem>()
                    {
                        new PatientInputAllergiesItem
                        {
                            Category = PatientInputAllergiesItemCategory.Drug,
                            Display = "display",
                        },
                    },
                    DateOfBirth = "dateOfBirth",
                    Email = "email",
                    FirstName = "firstName",
                    Sex = PatientInputSex.Female,
                    LastName = "lastName",
                    Phone = "phone",
                },
                Prescriptions = new List<PrescriptionInput>()
                {
                    new PrescriptionInput
                    {
                        Directions = "directions",
                        MedicationId = "med_01j2y8m6jcc9tt24af5pw9x1bc",
                        Quantity = 1,
                        Refills = 1,
                    },
                },
                Shipping = new OrderInputShipping { OptionId = "shp_01j2y8m6jcc9tt24af5pw9x1bc" },
                SignatureAttestation = true,
            }
        );
        JsonAssert.AreEqual(response, mockResponse);
    }
}
