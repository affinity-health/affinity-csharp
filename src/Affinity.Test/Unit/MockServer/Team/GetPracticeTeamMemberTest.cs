using Affinity;
using Affinity.Test.Unit.MockServer;
using Affinity.Test.Utils;
using NUnit.Framework;

namespace Affinity.Test.Unit.MockServer.Team;

[TestFixture]
[Parallelizable(ParallelScope.Self)]
public class GetPracticeTeamMemberTest : BaseMockServerTest
{
    [NUnit.Framework.Test]
    public async Task MockServerTest_1()
    {
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
                    .UsingGet()
            )
            .RespondWith(
                WireMock
                    .ResponseBuilders.Response.Create()
                    .WithStatusCode(200)
                    .WithBody(mockResponse)
            );

        var response = await Client.Team.GetPracticeTeamMemberAsync(
            new GetPracticeTeamMemberRequest { PracticeId = "practiceId", MemberId = "memberId" }
        );
        JsonAssert.AreEqual(response, mockResponse);
    }

    [NUnit.Framework.Test]
    public async Task MockServerTest_2()
    {
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
                    .UsingGet()
            )
            .RespondWith(
                WireMock
                    .ResponseBuilders.Response.Create()
                    .WithStatusCode(200)
                    .WithBody(mockResponse)
            );

        var response = await Client.Team.GetPracticeTeamMemberAsync(
            new GetPracticeTeamMemberRequest
            {
                PracticeId = "prac_01j2y8m6jcc9tt24af5pw9x1bc",
                MemberId = "mbr_01j2y8m6jcc9tt24af5pw9x1bc",
            }
        );
        JsonAssert.AreEqual(response, mockResponse);
    }
}
