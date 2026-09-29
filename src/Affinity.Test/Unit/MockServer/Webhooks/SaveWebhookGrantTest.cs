using Affinity;
using Affinity.Test.Unit.MockServer;
using Affinity.Test.Utils;
using NUnit.Framework;

namespace Affinity.Test.Unit.MockServer.Webhooks;

[TestFixture]
[Parallelizable(ParallelScope.Self)]
public class SaveWebhookGrantTest : BaseMockServerTest
{
    [NUnit.Framework.Test]
    public async Task MockServerTest_1()
    {
        const string requestJson = """
            {
              "scopes": [
                "webhooks:read",
                "webhooks:read"
              ]
            }
            """;

        const string mockResponse = """
            {
              "id": "id",
              "object": "webhook_grant",
              "organizationId": "organizationId",
              "platformId": "platformId",
              "livemode": true,
              "scopes": [
                "webhooks:read",
                "webhooks:read"
              ],
              "createdAt": "createdAt",
              "updatedAt": "updatedAt"
            }
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/v1/webhook-grants/platformId")
                    .WithHeader("Idempotency-Key", "idempotencyKey")
                    .WithHeader("Content-Type", "application/json")
                    .UsingPut()
                    .WithBodyAsJson(requestJson)
            )
            .RespondWith(
                WireMock
                    .ResponseBuilders.Response.Create()
                    .WithStatusCode(200)
                    .WithBody(mockResponse)
            );

        var response = await Client.Webhooks.SaveWebhookGrantAsync(
            new SaveWebhookGrantRequest
            {
                PlatformId = "platformId",
                IdempotencyKey = "idempotencyKey",
                Scopes = new List<SaveWebhookGrantRequestScopesItem>()
                {
                    SaveWebhookGrantRequestScopesItem.WebhooksRead,
                    SaveWebhookGrantRequestScopesItem.WebhooksRead,
                },
            }
        );
        JsonAssert.AreEqual(response, mockResponse);
    }

    [NUnit.Framework.Test]
    public async Task MockServerTest_2()
    {
        const string requestJson = """
            {
              "scopes": [
                "webhooks:read"
              ]
            }
            """;

        const string mockResponse = """
            {
              "id": "acct_01j2y8m6jcc9tt24af5pw9x1bc",
              "object": "webhook_grant",
              "organizationId": "acct_01j2y8m6jcc9tt24af5pw9x1bc",
              "platformId": "acct_01j2y8m6jcc9tt24af5pw9x1bc",
              "livemode": true,
              "scopes": [
                "webhooks:read"
              ],
              "createdAt": "createdAt",
              "updatedAt": "updatedAt"
            }
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/v1/webhook-grants/acct_01j2y8m6jcc9tt24af5pw9x1bc")
                    .WithHeader("Idempotency-Key", "Idempotency-Key")
                    .WithHeader("Content-Type", "application/json")
                    .UsingPut()
                    .WithBodyAsJson(requestJson)
            )
            .RespondWith(
                WireMock
                    .ResponseBuilders.Response.Create()
                    .WithStatusCode(200)
                    .WithBody(mockResponse)
            );

        var response = await Client.Webhooks.SaveWebhookGrantAsync(
            new SaveWebhookGrantRequest
            {
                PlatformId = "acct_01j2y8m6jcc9tt24af5pw9x1bc",
                IdempotencyKey = "Idempotency-Key",
                Scopes = new List<SaveWebhookGrantRequestScopesItem>()
                {
                    SaveWebhookGrantRequestScopesItem.WebhooksRead,
                },
            }
        );
        JsonAssert.AreEqual(response, mockResponse);
    }
}
