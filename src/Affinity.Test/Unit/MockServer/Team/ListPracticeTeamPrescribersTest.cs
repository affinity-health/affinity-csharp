using Affinity;
using Affinity.Test.Unit.MockServer;
using Affinity.Test.Utils;
using NUnit.Framework;

namespace Affinity.Test.Unit.MockServer.Team;

[TestFixture]
[Parallelizable(ParallelScope.Self)]
public class ListPracticeTeamPrescribersTest : BaseMockServerTest
{
    [NUnit.Framework.Test]
    public async Task MockServerTest_1()
    {
        const string mockResponse = """
            {
              "data": [
                {
                  "id": "id",
                  "name": "name",
                  "legalName": "legalName",
                  "credentials": "credentials",
                  "phone": "phone",
                  "address": {
                    "line1": "line1",
                    "line2": "line2",
                    "city": "city",
                    "state": "state",
                    "postalCode": "postalCode",
                    "country": "country"
                  },
                  "npi": "npi",
                  "practiceStatus": "practiceStatus",
                  "licenses": [
                    {
                      "id": "id",
                      "state": "state",
                      "licenseNumber": "licenseNumber",
                      "expiresAt": "expiresAt"
                    },
                    {
                      "id": "id",
                      "state": "state",
                      "licenseNumber": "licenseNumber",
                      "expiresAt": "expiresAt"
                    }
                  ]
                },
                {
                  "id": "id",
                  "name": "name",
                  "legalName": "legalName",
                  "credentials": "credentials",
                  "phone": "phone",
                  "address": {
                    "line1": "line1",
                    "line2": "line2",
                    "city": "city",
                    "state": "state",
                    "postalCode": "postalCode",
                    "country": "country"
                  },
                  "npi": "npi",
                  "practiceStatus": "practiceStatus",
                  "licenses": [
                    {
                      "id": "id",
                      "state": "state",
                      "licenseNumber": "licenseNumber",
                      "expiresAt": "expiresAt"
                    },
                    {
                      "id": "id",
                      "state": "state",
                      "licenseNumber": "licenseNumber",
                      "expiresAt": "expiresAt"
                    }
                  ]
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
                    .WithPath("/v1/practices/practiceId/team/prescribers")
                    .UsingGet()
            )
            .RespondWith(
                WireMock
                    .ResponseBuilders.Response.Create()
                    .WithStatusCode(200)
                    .WithBody(mockResponse)
            );

        var response = await Client.Team.ListPracticeTeamPrescribersAsync(
            new ListPracticeTeamPrescribersRequest { PracticeId = "practiceId" }
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
                  "id": "id",
                  "name": "name",
                  "legalName": "legalName",
                  "credentials": "credentials",
                  "phone": "phone",
                  "address": {
                    "line1": "line1",
                    "city": "city",
                    "state": "state",
                    "postalCode": "postalCode",
                    "country": "country"
                  },
                  "npi": "npi",
                  "practiceStatus": "practiceStatus",
                  "licenses": [
                    {
                      "id": "id",
                      "state": "state",
                      "licenseNumber": "licenseNumber"
                    }
                  ]
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
                    .WithPath("/v1/practices/prac_01j2y8m6jcc9tt24af5pw9x1bc/team/prescribers")
                    .WithParam("startingAfter", "prov_01j2y8m6jcc9tt24af5pw9x1bc")
                    .WithParam("endingBefore", "prov_01j2y8m6jcc9tt24af5pw9x1bc")
                    .UsingGet()
            )
            .RespondWith(
                WireMock
                    .ResponseBuilders.Response.Create()
                    .WithStatusCode(200)
                    .WithBody(mockResponse)
            );

        var response = await Client.Team.ListPracticeTeamPrescribersAsync(
            new ListPracticeTeamPrescribersRequest
            {
                PracticeId = "prac_01j2y8m6jcc9tt24af5pw9x1bc",
                StartingAfter = "prov_01j2y8m6jcc9tt24af5pw9x1bc",
                EndingBefore = "prov_01j2y8m6jcc9tt24af5pw9x1bc",
            }
        );
        JsonAssert.AreEqual(response, mockResponse);
    }
}
