using Affinity;
using Affinity.Test.Unit.MockServer;
using Affinity.Test.Utils;
using NUnit.Framework;

namespace Affinity.Test.Unit.MockServer.Team;

[TestFixture]
[Parallelizable(ParallelScope.Self)]
public class RegisterUserTest : BaseMockServerTest
{
    [NUnit.Framework.Test]
    public async Task MockServerTest_1()
    {
        const string requestJson = """
            {
              "externalId": "externalId",
              "email": "email",
              "name": "name",
              "role": "administrator",
              "identityAttestation": true
            }
            """;

        const string mockResponse = """
            {
              "object": "registered_user",
              "id": "id",
              "practiceId": "practiceId",
              "memberId": "memberId",
              "prescriberId": "prescriberId",
              "externalId": "externalId",
              "livemode": true
            }
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/v1/practices/practiceId/users")
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

        var response = await Client.Team.RegisterUserAsync(
            new RegisterUserRequest
            {
                PracticeId = "practiceId",
                IdempotencyKey = "idempotencyKey",
                ExternalId = "externalId",
                Email = "email",
                Name = "name",
                Role = RegisterUserRequestRole.Administrator,
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
                IdentityAttestation = true,
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
              "name": "name",
              "role": "administrator",
              "identityAttestation": true
            }
            """;

        const string mockResponse = """
            {
              "object": "registered_user",
              "id": "user_01j2y8m6jcc9tt24af5pw9x1bc",
              "practiceId": "prac_01j2y8m6jcc9tt24af5pw9x1bc",
              "memberId": "mbr_01j2y8m6jcc9tt24af5pw9x1bc",
              "prescriberId": "prov_01j2y8m6jcc9tt24af5pw9x1bc",
              "externalId": "externalId",
              "livemode": true
            }
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/v1/practices/prac_01j2y8m6jcc9tt24af5pw9x1bc/users")
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

        var response = await Client.Team.RegisterUserAsync(
            new RegisterUserRequest
            {
                PracticeId = "prac_01j2y8m6jcc9tt24af5pw9x1bc",
                IdempotencyKey = "Idempotency-Key",
                ExternalId = "externalId",
                Email = "email",
                Name = "name",
                Role = RegisterUserRequestRole.Administrator,
                IdentityAttestation = true,
            }
        );
        JsonAssert.AreEqual(response, mockResponse);
    }
}
