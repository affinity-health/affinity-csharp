using Affinity;
using Affinity.Test.Unit.MockServer;
using Affinity.Test.Utils;
using NUnit.Framework;

namespace Affinity.Test.Unit.MockServer.Team;

[TestFixture]
[Parallelizable(ParallelScope.Self)]
public class ResendPracticeTeamInvitationTest : BaseMockServerTest
{
    [NUnit.Framework.Test]
    public async Task MockServerTest_1()
    {
        const string mockResponse = """
            {
              "invitation": {
                "id": "id",
                "object": "team_invitation",
                "email": "email",
                "name": "name",
                "status": "accepted",
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
                "locationIds": [
                  "locationIds",
                  "locationIds"
                ],
                "createdAt": "createdAt",
                "expiresAt": "expiresAt",
                "acceptedAt": "acceptedAt",
                "userId": "userId",
                "externalId": "externalId",
                "memberId": "memberId",
                "prescriberId": "prescriberId",
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
                        "npi": "npi",
                        "practiceStatus": "practiceStatus",
                        "licenses": []
                      }
                    }
                  },
                  "nextActions": [
                    "nextActions",
                    "nextActions"
                  ]
                }
              },
              "delivery": "sent"
            }
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/v1/practices/practiceId/team/invitations/invitationId/resend")
                    .WithHeader("Idempotency-Key", "idempotencyKey")
                    .UsingPost()
            )
            .RespondWith(
                WireMock
                    .ResponseBuilders.Response.Create()
                    .WithStatusCode(200)
                    .WithBody(mockResponse)
            );

        var response = await Client.Team.ResendPracticeTeamInvitationAsync(
            new ResendPracticeTeamInvitationRequest
            {
                PracticeId = "practiceId",
                InvitationId = "invitationId",
                IdempotencyKey = "idempotencyKey",
            }
        );
        JsonAssert.AreEqual(response, mockResponse);
    }

    [NUnit.Framework.Test]
    public async Task MockServerTest_2()
    {
        const string mockResponse = """
            {
              "invitation": {
                "id": "id",
                "object": "team_invitation",
                "email": "email",
                "name": "name",
                "status": "accepted",
                "roles": [
                  {
                    "id": "id",
                    "name": "name"
                  }
                ],
                "locationIds": [
                  "locationIds"
                ],
                "createdAt": "createdAt",
                "expiresAt": "expiresAt",
                "acceptedAt": "acceptedAt",
                "userId": "userId",
                "externalId": "externalId",
                "memberId": "memberId",
                "prescriberId": "prescriberId",
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
                    ]
                  },
                  "nextActions": [
                    "nextActions"
                  ]
                }
              },
              "delivery": "sent"
            }
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath(
                        "/v1/practices/prac_01j2y8m6jcc9tt24af5pw9x1bc/team/invitations/invite_01j2y8m6jcc9tt24af5pw9x1bc/resend"
                    )
                    .WithHeader("Idempotency-Key", "Idempotency-Key")
                    .UsingPost()
            )
            .RespondWith(
                WireMock
                    .ResponseBuilders.Response.Create()
                    .WithStatusCode(200)
                    .WithBody(mockResponse)
            );

        var response = await Client.Team.ResendPracticeTeamInvitationAsync(
            new ResendPracticeTeamInvitationRequest
            {
                PracticeId = "prac_01j2y8m6jcc9tt24af5pw9x1bc",
                InvitationId = "invite_01j2y8m6jcc9tt24af5pw9x1bc",
                IdempotencyKey = "Idempotency-Key",
            }
        );
        JsonAssert.AreEqual(response, mockResponse);
    }
}
