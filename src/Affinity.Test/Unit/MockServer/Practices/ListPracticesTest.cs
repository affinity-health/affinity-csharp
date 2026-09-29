using Affinity;
using Affinity.Test.Unit.MockServer;
using Affinity.Test.Utils;
using NUnit.Framework;

namespace Affinity.Test.Unit.MockServer.Practices;

[TestFixture]
[Parallelizable(ParallelScope.Self)]
public class ListPracticesTest : BaseMockServerTest
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
                  "contacts": {
                    "compliance": {
                      "email": "email",
                      "name": "name",
                      "phone": "phone"
                    },
                    "primary": {
                      "email": "email",
                      "name": "name",
                      "phone": "phone"
                    }
                  },
                  "createdAt": "createdAt",
                  "externalId": "externalId",
                  "id": "id",
                  "legalName": "legalName",
                  "livemode": true,
                  "metadata": {
                    "metadata": {
                      "key": "value"
                    }
                  },
                  "name": "name",
                  "object": "practice",
                  "prescribers": [
                    {
                      "credentials": "credentials",
                      "licenseStates": [
                        "licenseStates",
                        "licenseStates"
                      ],
                      "name": "name",
                      "npi": "npi"
                    },
                    {
                      "credentials": "credentials",
                      "licenseStates": [
                        "licenseStates",
                        "licenseStates"
                      ],
                      "name": "name",
                      "npi": "npi"
                    }
                  ],
                  "liveEnabled": true,
                  "supportEmail": "supportEmail",
                  "supportPhone": "supportPhone",
                  "timezone": "timezone"
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
                  "contacts": {
                    "compliance": {
                      "email": "email",
                      "name": "name",
                      "phone": "phone"
                    },
                    "primary": {
                      "email": "email",
                      "name": "name",
                      "phone": "phone"
                    }
                  },
                  "createdAt": "createdAt",
                  "externalId": "externalId",
                  "id": "id",
                  "legalName": "legalName",
                  "livemode": true,
                  "metadata": {
                    "metadata": {
                      "key": "value"
                    }
                  },
                  "name": "name",
                  "object": "practice",
                  "prescribers": [
                    {
                      "credentials": "credentials",
                      "licenseStates": [
                        "licenseStates",
                        "licenseStates"
                      ],
                      "name": "name",
                      "npi": "npi"
                    },
                    {
                      "credentials": "credentials",
                      "licenseStates": [
                        "licenseStates",
                        "licenseStates"
                      ],
                      "name": "name",
                      "npi": "npi"
                    }
                  ],
                  "liveEnabled": true,
                  "supportEmail": "supportEmail",
                  "supportPhone": "supportPhone",
                  "timezone": "timezone"
                }
              ],
              "hasMore": true,
              "object": "list",
              "url": "/v1/practices"
            }
            """;

        Server
            .Given(WireMock.RequestBuilders.Request.Create().WithPath("/v1/practices").UsingGet())
            .RespondWith(
                WireMock
                    .ResponseBuilders.Response.Create()
                    .WithStatusCode(200)
                    .WithBody(mockResponse)
            );

        var response = await Client.Practices.ListPracticesAsync(new ListPracticesRequest());
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
                  "contacts": {},
                  "createdAt": "createdAt",
                  "externalId": "externalId",
                  "id": "prac_01j2y8m6jcc9tt24af5pw9x1bc",
                  "legalName": "legalName",
                  "livemode": true,
                  "metadata": {
                    "key": "value"
                  },
                  "name": "name",
                  "object": "practice",
                  "prescribers": [
                    {
                      "licenseStates": [
                        "licenseStates"
                      ],
                      "name": "name",
                      "npi": "npi"
                    }
                  ],
                  "liveEnabled": true,
                  "supportEmail": "supportEmail",
                  "supportPhone": "supportPhone",
                  "timezone": "timezone"
                }
              ],
              "hasMore": true,
              "object": "list",
              "url": "/v1/practices"
            }
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/v1/practices")
                    .WithParam("endingBefore", "prac_01j2y8m6jcc9tt24af5pw9x1bc")
                    .WithParam("startingAfter", "prac_01j2y8m6jcc9tt24af5pw9x1bc")
                    .UsingGet()
            )
            .RespondWith(
                WireMock
                    .ResponseBuilders.Response.Create()
                    .WithStatusCode(200)
                    .WithBody(mockResponse)
            );

        var response = await Client.Practices.ListPracticesAsync(
            new ListPracticesRequest
            {
                EndingBefore = "prac_01j2y8m6jcc9tt24af5pw9x1bc",
                StartingAfter = "prac_01j2y8m6jcc9tt24af5pw9x1bc",
            }
        );
        JsonAssert.AreEqual(response, mockResponse);
    }
}
