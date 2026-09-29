using Affinity;
using Affinity.Test.Unit.MockServer;
using Affinity.Test.Utils;
using NUnit.Framework;

namespace Affinity.Test.Unit.MockServer.ApiKeys;

[TestFixture]
[Parallelizable(ParallelScope.Self)]
public class CreatePlatformPracticeApiKeyTest : BaseMockServerTest
{
    [NUnit.Framework.Test]
    public async Task MockServerTest_1()
    {
        const string requestJson = """
            {
              "name": "name"
            }
            """;

        const string mockResponse = """
            {
              "apiKey": {
                "allowedIps": [
                  "allowedIps",
                  "allowedIps"
                ],
                "createdAt": "createdAt",
                "expiresAt": "expiresAt",
                "id": "id",
                "keyPrefix": "keyPrefix",
                "lastUsedAt": "lastUsedAt",
                "mode": "live",
                "name": "name",
                "revokedAt": "revokedAt",
                "scopes": [
                  "catalog:read",
                  "catalog:read"
                ],
                "status": "active"
              },
              "secret": "secret",
              "serviceAccount": {
                "apiVersion": "2026-09-28",
                "displayName": "displayName",
                "id": "id",
                "maxScopes": [
                  "catalog:read",
                  "catalog:read"
                ],
                "organizationId": "organizationId",
                "status": "active",
                "subjectId": "subjectId",
                "subjectType": "practice"
              }
            }
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/v1/practices/practiceId/api-keys")
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

        var response = await Client.ApiKeys.CreatePlatformPracticeApiKeyAsync(
            new CreatePlatformPracticeApiKeyRequest
            {
                PracticeId = "practiceId",
                IdempotencyKey = "idempotencyKey",
                AllowedIps = null,
                ExpiresAt = null,
                Name = "name",
                Scopes = null,
            }
        );
        JsonAssert.AreEqual(response, mockResponse);
    }

    [NUnit.Framework.Test]
    public async Task MockServerTest_2()
    {
        const string requestJson = """
            {
              "name": "name"
            }
            """;

        const string mockResponse = """
            {
              "apiKey": {
                "allowedIps": [
                  "allowedIps"
                ],
                "createdAt": "createdAt",
                "expiresAt": "expiresAt",
                "id": "id",
                "keyPrefix": "keyPrefix",
                "lastUsedAt": "lastUsedAt",
                "mode": "live",
                "name": "name",
                "revokedAt": "revokedAt",
                "scopes": [
                  "catalog:read"
                ],
                "status": "active"
              },
              "secret": "secret",
              "serviceAccount": {
                "apiVersion": "2026-09-28",
                "displayName": "displayName",
                "id": "id",
                "maxScopes": [
                  "catalog:read"
                ],
                "organizationId": "organizationId",
                "status": "active",
                "subjectId": "subjectId",
                "subjectType": "practice"
              }
            }
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/v1/practices/practiceId/api-keys")
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

        var response = await Client.ApiKeys.CreatePlatformPracticeApiKeyAsync(
            new CreatePlatformPracticeApiKeyRequest
            {
                PracticeId = "practiceId",
                IdempotencyKey = "Idempotency-Key",
                Name = "name",
            }
        );
        JsonAssert.AreEqual(response, mockResponse);
    }
}
