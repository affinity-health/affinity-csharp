using Affinity;
using Affinity.Test.Unit.MockServer;
using Affinity.Test.Utils;
using NUnit.Framework;

namespace Affinity.Test.Unit.MockServer.Team;

[TestFixture]
[Parallelizable(ParallelScope.Self)]
public class GetPracticeTeamPrescriberTest : BaseMockServerTest
{
    [NUnit.Framework.Test]
    public async Task MockServerTest_1()
    {
        const string mockResponse = """
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
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/v1/practices/practiceId/team/prescribers/prescriberId")
                    .UsingGet()
            )
            .RespondWith(
                WireMock
                    .ResponseBuilders.Response.Create()
                    .WithStatusCode(200)
                    .WithBody(mockResponse)
            );

        var response = await Client.Team.GetPracticeTeamPrescriberAsync(
            new GetPracticeTeamPrescriberRequest
            {
                PracticeId = "practiceId",
                PrescriberId = "prescriberId",
            }
        );
        JsonAssert.AreEqual(response, mockResponse);
    }

    [NUnit.Framework.Test]
    public async Task MockServerTest_2()
    {
        const string mockResponse = """
            {
              "id": "prov_01j2y8m6jcc9tt24af5pw9x1bc",
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
                }
              ]
            }
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath(
                        "/v1/practices/prac_01j2y8m6jcc9tt24af5pw9x1bc/team/prescribers/prov_01j2y8m6jcc9tt24af5pw9x1bc"
                    )
                    .UsingGet()
            )
            .RespondWith(
                WireMock
                    .ResponseBuilders.Response.Create()
                    .WithStatusCode(200)
                    .WithBody(mockResponse)
            );

        var response = await Client.Team.GetPracticeTeamPrescriberAsync(
            new GetPracticeTeamPrescriberRequest
            {
                PracticeId = "prac_01j2y8m6jcc9tt24af5pw9x1bc",
                PrescriberId = "prov_01j2y8m6jcc9tt24af5pw9x1bc",
            }
        );
        JsonAssert.AreEqual(response, mockResponse);
    }
}
