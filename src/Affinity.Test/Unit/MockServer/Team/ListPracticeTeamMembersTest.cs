using Affinity;
using Affinity.Test.Unit.MockServer;
using Affinity.Test.Utils;
using NUnit.Framework;

namespace Affinity.Test.Unit.MockServer.Team;

[TestFixture]
[Parallelizable(ParallelScope.Self)]
public class ListPracticeTeamMembersTest : BaseMockServerTest
{
    [NUnit.Framework.Test]
    public async Task MockServerTest_1()
    {
        const string mockResponse = """
            {
              "data": [
                {
                  "id": "id",
                  "externalId": "externalId",
                  "name": "name",
                  "email": "email",
                  "locationIds": [
                    "locationIds",
                    "locationIds"
                  ],
                  "account": {
                    "accountId": "accountId",
                    "emailVerified": true,
                    "membershipId": "membershipId",
                    "membershipStatus": "membershipStatus",
                    "roles": [
                      {
                        "id": "id",
                        "name": "name",
                        "key": "key"
                      },
                      {
                        "id": "id",
                        "name": "name",
                        "key": "key"
                      }
                    ],
                    "prescriberConnection": {
                      "status": "status",
                      "provider": {
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
                    }
                  },
                  "nextActions": [
                    "nextActions",
                    "nextActions"
                  ]
                },
                {
                  "id": "id",
                  "externalId": "externalId",
                  "name": "name",
                  "email": "email",
                  "locationIds": [
                    "locationIds",
                    "locationIds"
                  ],
                  "account": {
                    "accountId": "accountId",
                    "emailVerified": true,
                    "membershipId": "membershipId",
                    "membershipStatus": "membershipStatus",
                    "roles": [
                      {
                        "id": "id",
                        "name": "name",
                        "key": "key"
                      },
                      {
                        "id": "id",
                        "name": "name",
                        "key": "key"
                      }
                    ],
                    "prescriberConnection": {
                      "status": "status",
                      "provider": {
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
                    }
                  },
                  "nextActions": [
                    "nextActions",
                    "nextActions"
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
                    .WithPath("/v1/practices/practiceId/team/members")
                    .UsingGet()
            )
            .RespondWith(
                WireMock
                    .ResponseBuilders.Response.Create()
                    .WithStatusCode(200)
                    .WithBody(mockResponse)
            );

        var response = await Client.Team.ListPracticeTeamMembersAsync(
            new ListPracticeTeamMembersRequest { PracticeId = "practiceId" }
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
                  "id": "mbr_01j2y8m6jcc9tt24af5pw9x1bc",
                  "externalId": "externalId",
                  "name": "name",
                  "email": "email",
                  "locationIds": [
                    "locationIds"
                  ],
                  "account": {
                    "accountId": "accountId",
                    "emailVerified": true,
                    "membershipId": "membershipId",
                    "membershipStatus": "membershipStatus",
                    "roles": [
                      {
                        "id": "id",
                        "name": "name"
                      }
                    ]
                  },
                  "nextActions": [
                    "nextActions"
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
                    .WithPath("/v1/practices/prac_01j2y8m6jcc9tt24af5pw9x1bc/team/members")
                    .WithParam("startingAfter", "mbr_01j2y8m6jcc9tt24af5pw9x1bc")
                    .WithParam("endingBefore", "mbr_01j2y8m6jcc9tt24af5pw9x1bc")
                    .UsingGet()
            )
            .RespondWith(
                WireMock
                    .ResponseBuilders.Response.Create()
                    .WithStatusCode(200)
                    .WithBody(mockResponse)
            );

        var response = await Client.Team.ListPracticeTeamMembersAsync(
            new ListPracticeTeamMembersRequest
            {
                PracticeId = "prac_01j2y8m6jcc9tt24af5pw9x1bc",
                StartingAfter = "mbr_01j2y8m6jcc9tt24af5pw9x1bc",
                EndingBefore = "mbr_01j2y8m6jcc9tt24af5pw9x1bc",
            }
        );
        JsonAssert.AreEqual(response, mockResponse);
    }
}
