using Affinity;
using Affinity.Test.Unit.MockServer;
using Affinity.Test.Utils;
using NUnit.Framework;

namespace Affinity.Test.Unit.MockServer.Team;

[TestFixture]
[Parallelizable(ParallelScope.Self)]
public class InvitePracticeTeamPersonTest : BaseMockServerTest
{
    [NUnit.Framework.Test]
    public async Task MockServerTest_1()
    {
        const string requestJson = """
            {
              "externalId": "externalId",
              "email": "email",
              "name": "name"
            }
            """;

        const string mockResponse = """
            {
              "person": {
                "id": "id",
                "object": "team_person",
                "externalId": "externalId",
                "email": "email",
                "name": "name",
                "status": "status",
                "invitation": {
                  "id": "id",
                  "status": "accepted",
                  "expiresAt": "expiresAt",
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
                  ]
                },
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
              "delivery": "sent"
            }
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/v1/practices/practiceId/team/invitations")
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

        var response = await Client.Team.InvitePracticeTeamPersonAsync(
            new InvitePracticeTeamPersonRequest
            {
                PracticeId = "practiceId",
                IdempotencyKey = "idempotencyKey",
                ExternalId = "externalId",
                Email = "email",
                Name = "name",
                Role = null,
                Roles = null,
                ProfileDetails = null,
                Npi = null,
                Licenses = null,
                LegalName = null,
                DisplayName = null,
                Credentials = null,
                Address = null,
                Phone = null,
                LocationIds = null,
            }
        );
        JsonAssert.AreEqual(response, mockResponse);
    }

    [NUnit.Framework.Test]
    public async Task MockServerTest_2()
    {
        const string requestJson = """
            {
              "externalId": "externalId",
              "email": "email",
              "name": "name"
            }
            """;

        const string mockResponse = """
            {
              "person": {
                "id": "id",
                "object": "team_person",
                "externalId": "externalId",
                "email": "email",
                "name": "name",
                "status": "status",
                "invitation": {
                  "id": "id",
                  "status": "accepted",
                  "expiresAt": "expiresAt",
                  "roles": [
                    {
                      "id": "id",
                      "name": "name"
                    }
                  ]
                },
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
                  ],
                  "prescriberConnection": {
                    "status": "status",
                    "provider": {
                      "id": "id",
                      "name": "name",
                      "legalName": "legalName",
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
                  }
                },
                "nextActions": [
                  "nextActions"
                ]
              },
              "delivery": "sent"
            }
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/v1/practices/prac_01j2y8m6jcc9tt24af5pw9x1bc/team/invitations")
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

        var response = await Client.Team.InvitePracticeTeamPersonAsync(
            new InvitePracticeTeamPersonRequest
            {
                PracticeId = "prac_01j2y8m6jcc9tt24af5pw9x1bc",
                IdempotencyKey = "Idempotency-Key",
                ExternalId = "externalId",
                Email = "email",
                Name = "name",
            }
        );
        JsonAssert.AreEqual(response, mockResponse);
    }
}
