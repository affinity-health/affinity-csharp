using Affinity;
using Affinity.Test.Unit.MockServer;
using Affinity.Test.Utils;
using NUnit.Framework;

namespace Affinity.Test.Unit.MockServer.Webhooks;

[TestFixture]
[Parallelizable(ParallelScope.Self)]
public class RevokeWebhookGrantTest : BaseMockServerTest
{
    [NUnit.Framework.Test]
    public async Task MockServerTest_1()
    {
        const string mockResponse = """
            {
              "object": "webhook_grant",
              "organizationId": "organizationId",
              "platformId": "platformId",
              "revoked": true
            }
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/v1/webhook-grants/platformId")
                    .WithHeader("Idempotency-Key", "idempotencyKey")
                    .UsingDelete()
            )
            .RespondWith(
                WireMock
                    .ResponseBuilders.Response.Create()
                    .WithStatusCode(200)
                    .WithBody(mockResponse)
            );

        var response = await Client.Webhooks.RevokeWebhookGrantAsync(
            new RevokeWebhookGrantRequest
            {
                PlatformId = "platformId",
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
              "object": "webhook_grant",
              "organizationId": "acct_01j2y8m6jcc9tt24af5pw9x1bc",
              "platformId": "acct_01j2y8m6jcc9tt24af5pw9x1bc",
              "revoked": true
            }
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/v1/webhook-grants/acct_01j2y8m6jcc9tt24af5pw9x1bc")
                    .WithHeader("Idempotency-Key", "Idempotency-Key")
                    .UsingDelete()
            )
            .RespondWith(
                WireMock
                    .ResponseBuilders.Response.Create()
                    .WithStatusCode(200)
                    .WithBody(mockResponse)
            );

        var response = await Client.Webhooks.RevokeWebhookGrantAsync(
            new RevokeWebhookGrantRequest
            {
                PlatformId = "acct_01j2y8m6jcc9tt24af5pw9x1bc",
                IdempotencyKey = "Idempotency-Key",
            }
        );
        JsonAssert.AreEqual(response, mockResponse);
    }
}
