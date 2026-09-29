using Affinity;
using Affinity.Test.Unit.MockServer;
using Affinity.Test.Utils;
using NUnit.Framework;

namespace Affinity.Test.Unit.MockServer.Patients;

[TestFixture]
[Parallelizable(ParallelScope.Self)]
public class ListPatientsTest : BaseMockServerTest
{
    [NUnit.Framework.Test]
    public async Task MockServerTest_1()
    {
        const string mockResponse = """
            {
              "data": [
                {
                  "address": {
                    "city": "city",
                    "country": "country",
                    "line1": "line1",
                    "line2": "line2",
                    "postalCode": "postalCode",
                    "state": "state"
                  },
                  "defaultShippingAddressId": "defaultShippingAddressId",
                  "shippingAddress": {
                    "city": "city",
                    "country": "country",
                    "line1": "line1",
                    "line2": "line2",
                    "postalCode": "postalCode",
                    "state": "state"
                  },
                  "allergyReviewStatus": "not_reviewed",
                  "allergySummary": [
                    {
                      "reaction": "reaction",
                      "substance": "substance"
                    },
                    {
                      "reaction": "reaction",
                      "substance": "substance"
                    }
                  ],
                  "createdAt": "createdAt",
                  "clinicalProfile": {
                    "currentMedications": [
                      "currentMedications",
                      "currentMedications"
                    ],
                    "heightInches": "Infinity",
                    "reviewedAt": "reviewedAt",
                    "weightPounds": "Infinity"
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
                  "addresses": [
                    {
                      "id": "id",
                      "address": {
                        "city": "city",
                        "country": "country",
                        "line1": "line1",
                        "line2": "line2",
                        "postalCode": "postalCode",
                        "state": "state"
                      },
                      "label": "label",
                      "preferredShipping": true,
                      "recipientName": "recipientName",
                      "archivedAt": "archivedAt"
                    },
                    {
                      "id": "id",
                      "address": {
                        "city": "city",
                        "country": "country",
                        "line1": "line1",
                        "line2": "line2",
                        "postalCode": "postalCode",
                        "state": "state"
                      },
                      "label": "label",
                      "preferredShipping": true,
                      "recipientName": "recipientName",
                      "archivedAt": "archivedAt"
                    }
                  ],
                  "encounters": [
                    {
                      "notes": "notes",
                      "occurredAt": "occurredAt",
                      "providerName": "providerName",
                      "type": "type"
                    },
                    {
                      "notes": "notes",
                      "occurredAt": "occurredAt",
                      "providerName": "providerName",
                      "type": "type"
                    }
                  ],
                  "gender": "f",
                  "id": "id",
                  "livemode": true,
                  "location": {
                    "id": "id",
                    "name": "name",
                    "state": "state",
                    "status": "active"
                  },
                  "locationId": "locationId",
                  "metadata": {
                    "metadata": {
                      "key": "value"
                    }
                  },
                  "medicalRecordNumber": "medicalRecordNumber",
                  "measurements": [
                    {
                      "heightCentimeters": "Infinity",
                      "recordedAt": "recordedAt",
                      "source": "source",
                      "weightKilograms": "Infinity"
                    },
                    {
                      "heightCentimeters": "Infinity",
                      "recordedAt": "recordedAt",
                      "source": "source",
                      "weightKilograms": "Infinity"
                    }
                  ],
                  "name": {
                    "first": "first",
                    "last": "last",
                    "middle": "middle",
                    "preferred": "preferred"
                  },
                  "object": "patient",
                  "phone": "phone",
                  "programs": [
                    {
                      "endedAt": "endedAt",
                      "name": "name",
                      "startedAt": "startedAt",
                      "status": "active"
                    },
                    {
                      "endedAt": "endedAt",
                      "name": "name",
                      "startedAt": "startedAt",
                      "status": "active"
                    }
                  ],
                  "practiceId": "practiceId",
                  "status": "active",
                  "updatedAt": "updatedAt"
                },
                {
                  "address": {
                    "city": "city",
                    "country": "country",
                    "line1": "line1",
                    "line2": "line2",
                    "postalCode": "postalCode",
                    "state": "state"
                  },
                  "defaultShippingAddressId": "defaultShippingAddressId",
                  "shippingAddress": {
                    "city": "city",
                    "country": "country",
                    "line1": "line1",
                    "line2": "line2",
                    "postalCode": "postalCode",
                    "state": "state"
                  },
                  "allergyReviewStatus": "not_reviewed",
                  "allergySummary": [
                    {
                      "reaction": "reaction",
                      "substance": "substance"
                    },
                    {
                      "reaction": "reaction",
                      "substance": "substance"
                    }
                  ],
                  "createdAt": "createdAt",
                  "clinicalProfile": {
                    "currentMedications": [
                      "currentMedications",
                      "currentMedications"
                    ],
                    "heightInches": "Infinity",
                    "reviewedAt": "reviewedAt",
                    "weightPounds": "Infinity"
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
                  "addresses": [
                    {
                      "id": "id",
                      "address": {
                        "city": "city",
                        "country": "country",
                        "line1": "line1",
                        "line2": "line2",
                        "postalCode": "postalCode",
                        "state": "state"
                      },
                      "label": "label",
                      "preferredShipping": true,
                      "recipientName": "recipientName",
                      "archivedAt": "archivedAt"
                    },
                    {
                      "id": "id",
                      "address": {
                        "city": "city",
                        "country": "country",
                        "line1": "line1",
                        "line2": "line2",
                        "postalCode": "postalCode",
                        "state": "state"
                      },
                      "label": "label",
                      "preferredShipping": true,
                      "recipientName": "recipientName",
                      "archivedAt": "archivedAt"
                    }
                  ],
                  "encounters": [
                    {
                      "notes": "notes",
                      "occurredAt": "occurredAt",
                      "providerName": "providerName",
                      "type": "type"
                    },
                    {
                      "notes": "notes",
                      "occurredAt": "occurredAt",
                      "providerName": "providerName",
                      "type": "type"
                    }
                  ],
                  "gender": "f",
                  "id": "id",
                  "livemode": true,
                  "location": {
                    "id": "id",
                    "name": "name",
                    "state": "state",
                    "status": "active"
                  },
                  "locationId": "locationId",
                  "metadata": {
                    "metadata": {
                      "key": "value"
                    }
                  },
                  "medicalRecordNumber": "medicalRecordNumber",
                  "measurements": [
                    {
                      "heightCentimeters": "Infinity",
                      "recordedAt": "recordedAt",
                      "source": "source",
                      "weightKilograms": "Infinity"
                    },
                    {
                      "heightCentimeters": "Infinity",
                      "recordedAt": "recordedAt",
                      "source": "source",
                      "weightKilograms": "Infinity"
                    }
                  ],
                  "name": {
                    "first": "first",
                    "last": "last",
                    "middle": "middle",
                    "preferred": "preferred"
                  },
                  "object": "patient",
                  "phone": "phone",
                  "programs": [
                    {
                      "endedAt": "endedAt",
                      "name": "name",
                      "startedAt": "startedAt",
                      "status": "active"
                    },
                    {
                      "endedAt": "endedAt",
                      "name": "name",
                      "startedAt": "startedAt",
                      "status": "active"
                    }
                  ],
                  "practiceId": "practiceId",
                  "status": "active",
                  "updatedAt": "updatedAt"
                }
              ],
              "hasMore": true,
              "object": "list",
              "url": "url"
            }
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/v1/practices/practiceId/patients")
                    .UsingGet()
            )
            .RespondWith(
                WireMock
                    .ResponseBuilders.Response.Create()
                    .WithStatusCode(200)
                    .WithBody(mockResponse)
            );

        var response = await Client.Patients.ListPatientsAsync(
            new ListPatientsRequest { PracticeId = "practiceId" }
        );
        JsonAssert.AreEqual(response, mockResponse);
    }

    [NUnit.Framework.Test]
    public async Task MockServerTest_2()
    {
        const string mockResponse = """
            {
              "data": [
                {
                  "address": {
                    "city": "city",
                    "line1": "line1",
                    "postalCode": "postalCode",
                    "state": "state"
                  },
                  "defaultShippingAddressId": "defaultShippingAddressId",
                  "shippingAddress": {
                    "city": "city",
                    "line1": "line1",
                    "postalCode": "postalCode",
                    "state": "state"
                  },
                  "allergyReviewStatus": "not_reviewed",
                  "allergySummary": [
                    {
                      "substance": "substance"
                    }
                  ],
                  "createdAt": "createdAt",
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
                      "id": "id",
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
                  "id": "pat_01j2y8m6jcc9tt24af5pw9x1bc",
                  "livemode": true,
                  "location": {
                    "id": "id",
                    "name": "name",
                    "status": "active"
                  },
                  "locationId": "loc_01j2y8m6jcc9tt24af5pw9x1bc",
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
                  "object": "patient",
                  "phone": "phone",
                  "programs": [
                    {
                      "name": "name",
                      "startedAt": "startedAt",
                      "status": "active"
                    }
                  ],
                  "practiceId": "prac_01j2y8m6jcc9tt24af5pw9x1bc",
                  "status": "active",
                  "updatedAt": "updatedAt"
                }
              ],
              "hasMore": true,
              "object": "list",
              "url": "url"
            }
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/v1/practices/prac_01j2y8m6jcc9tt24af5pw9x1bc/patients")
                    .WithParam("endingBefore", "pat_01j2y8m6jcc9tt24af5pw9x1bc")
                    .WithParam("startingAfter", "pat_01j2y8m6jcc9tt24af5pw9x1bc")
                    .UsingGet()
            )
            .RespondWith(
                WireMock
                    .ResponseBuilders.Response.Create()
                    .WithStatusCode(200)
                    .WithBody(mockResponse)
            );

        var response = await Client.Patients.ListPatientsAsync(
            new ListPatientsRequest
            {
                PracticeId = "prac_01j2y8m6jcc9tt24af5pw9x1bc",
                EndingBefore = "pat_01j2y8m6jcc9tt24af5pw9x1bc",
                StartingAfter = "pat_01j2y8m6jcc9tt24af5pw9x1bc",
            }
        );
        JsonAssert.AreEqual(response, mockResponse);
    }
}
