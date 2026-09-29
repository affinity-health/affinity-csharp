using Affinity;
using Affinity.Test.Unit.MockServer;
using Affinity.Test.Utils;
using NUnit.Framework;

namespace Affinity.Test.Unit.MockServer.Team;

[TestFixture]
[Parallelizable(ParallelScope.Self)]
public class UpdatePracticeTeamMemberTest : BaseMockServerTest
{
    [NUnit.Framework.Test]
    public async Task MockServerTest_1()
    {
        const string requestJson = """
            {}
            """;

        const string mockResponse = """
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
                }
              },
              "nextActions": [
                "nextActions",
                "nextActions"
              ]
            }
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/v1/practices/practiceId/team/members/memberId")
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

        var response = await Client.Team.UpdatePracticeTeamMemberAsync(
            new UpdatePracticeTeamMemberRequest
            {
                PracticeId = "practiceId",
                MemberId = "memberId",
                IdempotencyKey = "idempotencyKey",
                Role = null,
                Roles = null,
                Status = null,
                LocationIds = null,
            }
        );
        JsonAssert.AreEqual(response, mockResponse);
    }

    [NUnit.Framework.Test]
    public async Task MockServerTest_2()
    {
        const string requestJson = """
            {}
            """;

        const string mockResponse = """
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
            }
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath(
                        "/v1/practices/prac_01j2y8m6jcc9tt24af5pw9x1bc/team/members/mbr_01j2y8m6jcc9tt24af5pw9x1bc"
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

        var response = await Client.Team.UpdatePracticeTeamMemberAsync(
            new UpdatePracticeTeamMemberRequest
            {
                PracticeId = "prac_01j2y8m6jcc9tt24af5pw9x1bc",
                MemberId = "mbr_01j2y8m6jcc9tt24af5pw9x1bc",
                IdempotencyKey = "Idempotency-Key",
            }
        );
        JsonAssert.AreEqual(response, mockResponse);
    }
}
