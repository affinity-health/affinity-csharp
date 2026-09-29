using Affinity;
using Affinity.Test.Unit.MockServer;
using Affinity.Test.Utils;
using NUnit.Framework;

namespace Affinity.Test.Unit.MockServer.Webhooks;

[TestFixture]
[Parallelizable(ParallelScope.Self)]
public class ListWebhookGrantsTest : BaseMockServerTest
{
    [NUnit.Framework.Test]
    public async Task MockServerTest_1()
    {
        const string mockResponse = """
            {
              "object": "list",
              "data": [
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
                },
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
              ],
              "hasMore": true,
              "url": "/v1/webhook-grants"
            }
            """;

        Server
            .Given(
                WireMock.RequestBuilders.Request.Create().WithPath("/v1/webhook-grants").UsingGet()
            )
            .RespondWith(
                WireMock
                    .ResponseBuilders.Response.Create()
                    .WithStatusCode(200)
                    .WithBody(mockResponse)
            );

        var response = await Client.Webhooks.ListWebhookGrantsAsync(new ListWebhookGrantsRequest());
        JsonAssert.AreEqual(response, mockResponse);
    }

    [NUnit.Framework.Test]
    public async Task MockServerTest_2()
    {
        const string mockResponse = """
            {
              "object": "list",
              "data": [
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
              ],
              "hasMore": true,
              "url": "/v1/webhook-grants"
            }
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/v1/webhook-grants")
                    .WithParam("startingAfter", "acct_01j2y8m6jcc9tt24af5pw9x1bc")
                    .WithParam("endingBefore", "acct_01j2y8m6jcc9tt24af5pw9x1bc")
                    .UsingGet()
            )
            .RespondWith(
                WireMock
                    .ResponseBuilders.Response.Create()
                    .WithStatusCode(200)
                    .WithBody(mockResponse)
            );

        var response = await Client.Webhooks.ListWebhookGrantsAsync(
            new ListWebhookGrantsRequest
            {
                StartingAfter = "acct_01j2y8m6jcc9tt24af5pw9x1bc",
                EndingBefore = "acct_01j2y8m6jcc9tt24af5pw9x1bc",
            }
        );
        JsonAssert.AreEqual(response, mockResponse);
    }
}
