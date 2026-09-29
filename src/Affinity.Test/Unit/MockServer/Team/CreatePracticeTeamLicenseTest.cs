using Affinity;
using Affinity.Test.Unit.MockServer;
using Affinity.Test.Utils;
using NUnit.Framework;

namespace Affinity.Test.Unit.MockServer.Team;

[TestFixture]
[Parallelizable(ParallelScope.Self)]
public class CreatePracticeTeamLicenseTest : BaseMockServerTest
{
    [NUnit.Framework.Test]
    public async Task MockServerTest_1()
    {
        const string requestJson = """
            {
              "state": "state",
              "licenseNumber": "licenseNumber"
            }
            """;

        const string mockResponse = """
            {
              "id": "id",
              "state": "state",
              "licenseNumber": "licenseNumber",
              "expiresAt": "expiresAt"
            }
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/v1/practices/practiceId/team/prescribers/prescriberId/licenses")
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

        var response = await Client.Team.CreatePracticeTeamLicenseAsync(
            new CreatePracticeTeamLicenseRequest
            {
                PracticeId = "practiceId",
                PrescriberId = "prescriberId",
                IdempotencyKey = "idempotencyKey",
                State = "state",
                LicenseNumber = "licenseNumber",
                ExpiresAt = null,
            }
        );
        JsonAssert.AreEqual(response, mockResponse);
    }

    [NUnit.Framework.Test]
    public async Task MockServerTest_2()
    {
        const string requestJson = """
            {
              "state": "state",
              "licenseNumber": "licenseNumber"
            }
            """;

        const string mockResponse = """
            {
              "id": "lic_01j2y8m6jcc9tt24af5pw9x1bc",
              "state": "state",
              "licenseNumber": "licenseNumber",
              "expiresAt": "expiresAt"
            }
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath(
                        "/v1/practices/prac_01j2y8m6jcc9tt24af5pw9x1bc/team/prescribers/prov_01j2y8m6jcc9tt24af5pw9x1bc/licenses"
                    )
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

        var response = await Client.Team.CreatePracticeTeamLicenseAsync(
            new CreatePracticeTeamLicenseRequest
            {
                PracticeId = "prac_01j2y8m6jcc9tt24af5pw9x1bc",
                PrescriberId = "prov_01j2y8m6jcc9tt24af5pw9x1bc",
                IdempotencyKey = "Idempotency-Key",
                State = "state",
                LicenseNumber = "licenseNumber",
            }
        );
        JsonAssert.AreEqual(response, mockResponse);
    }
}
