using Affinity;
using Affinity.Test.Unit.MockServer;
using NUnit.Framework;

namespace Affinity.Test.Unit.MockServer.Orders;

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
                      "status": "submitted",
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
                      "status": "submitted",
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
                  "status": "submitted",
                  "trackingUrl": "trackingUrl",
                  "statusHistory": [
                    {
                      "createdAt": "2024-01-15T09:30:00.000Z",
                      "status": "submitted"
                    },
                    {
                      "createdAt": "2024-01-15T09:30:00.000Z",
                      "status": "submitted"
                    }
                  ],
                  "total": 1,
                  "updatedAt": "2024-01-15T09:30:00.000Z"
                },
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
                      "status": "submitted",
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
                      "status": "submitted",
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
                  "status": "submitted",
                  "trackingUrl": "trackingUrl",
                  "statusHistory": [
                    {
                      "createdAt": "2024-01-15T09:30:00.000Z",
                      "status": "submitted"
                    },
                    {
                      "createdAt": "2024-01-15T09:30:00.000Z",
                      "status": "submitted"
                    }
                  ],
                  "total": 1,
                  "updatedAt": "2024-01-15T09:30:00.000Z"
                }
              ],
              "hasMore": true,
              "nextCursor": "nextCursor",
              "object": "list",
              "url": "url"
            }
            """;

        Server
            .Given(WireMock.RequestBuilders.Request.Create().WithPath("/v1/orders").UsingGet())
            .RespondWith(
                WireMock
                    .ResponseBuilders.Response.Create()
                    .WithStatusCode(200)
                    .WithBody(mockResponse)
            );

        var items = await Client.Orders.ListAsync(new ListOrdersRequest());
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
                  "cancelRequestedAt": "2024-01-15T09:30:00.000Z",
                  "createdAt": "2024-01-15T09:30:00.000Z",
                  "externalOrderId": "externalOrderId",
                  "failureReason": "failureReason",
                  "id": "ord_01j2y8m6jcc9tt24af5pw9x1bc",
                  "mode": "test",
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
                    "dateOfBirth": "2023-01-15",
                    "email": "email",
                    "firstName": "firstName",
                    "sex": "female",
                    "lastName": "lastName",
                    "phone": "phone"
                  },
                  "patientId": "pat_01j2y8m6jcc9tt24af5pw9x1bc",
                  "practice": {
                    "address": {
                      "line1": "line1",
                      "city": "city",
                      "state": "state",
                      "postalCode": "postalCode"
                    },
                    "name": "name",
                    "phone": "phone"
                  },
                  "practiceId": "prac_01j2y8m6jcc9tt24af5pw9x1bc",
                  "prescriber": {
                    "firstName": "firstName",
                    "lastName": "lastName",
                    "npi": "npi"
                  },
                  "prescriptions": [
                    {
                      "directions": "directions",
                      "id": "rx_01j2y8m6jcc9tt24af5pw9x1bc",
                      "pharmacy": {
                        "id": "pharm_01j2y8m6jcc9tt24af5pw9x1bc",
                        "name": "name"
                      },
                      "status": "submitted",
                      "medication": {
                        "id": "med_01j2y8m6jcc9tt24af5pw9x1bc",
                        "name": "name"
                      },
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
                      "trackingNumber": "trackingNumber"
                    }
                  ],
                  "status": "submitted",
                  "trackingUrl": "trackingUrl",
                  "statusHistory": [
                    {
                      "createdAt": "2024-01-15T09:30:00.000Z",
                      "status": "submitted"
                    }
                  ],
                  "total": 1,
                  "updatedAt": "2024-01-15T09:30:00.000Z"
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
                    .WithPath("/v1/orders")
                    .WithParam("patientId", "pat_01j2y8m6jcc9tt24af5pw9x1bc")
                    .WithParam("practiceId", "prac_01j2y8m6jcc9tt24af5pw9x1bc")
                    .UsingGet()
            )
            .RespondWith(
                WireMock
                    .ResponseBuilders.Response.Create()
                    .WithStatusCode(200)
                    .WithBody(mockResponse)
            );

        var items = await Client.Orders.ListAsync(
            new ListOrdersRequest
            {
                PatientId = "pat_01j2y8m6jcc9tt24af5pw9x1bc",
                PracticeId = "prac_01j2y8m6jcc9tt24af5pw9x1bc",
            }
        );
        await foreach (var item in items)
        {
            Assert.That(item, Is.Not.Null);
            break; // Only check the first item
        }
    }
}
