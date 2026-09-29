using Affinity;
using Affinity.Test.Unit.MockServer;
using Affinity.Test.Utils;
using NUnit.Framework;

namespace Affinity.Test.Unit.MockServer.Team;

[TestFixture]
[Parallelizable(ParallelScope.Self)]
public class UpdatePracticeTeamPrescriberTest : BaseMockServerTest
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

        var response = await Client.Team.UpdatePracticeTeamPrescriberAsync(
            new UpdatePracticeTeamPrescriberRequest
            {
                PracticeId = "practiceId",
                PrescriberId = "prescriberId",
                IdempotencyKey = "idempotencyKey",
                DisplayName = null,
                LegalName = null,
                Credentials = null,
                Phone = null,
                Address = null,
                PracticeStatus = null,
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

        var response = await Client.Team.UpdatePracticeTeamPrescriberAsync(
            new UpdatePracticeTeamPrescriberRequest
            {
                PracticeId = "prac_01j2y8m6jcc9tt24af5pw9x1bc",
                PrescriberId = "prov_01j2y8m6jcc9tt24af5pw9x1bc",
                IdempotencyKey = "Idempotency-Key",
            }
        );
        JsonAssert.AreEqual(response, mockResponse);
    }
}
