using Affinity;
using Affinity.Test.Unit.MockServer;
using Affinity.Test.Utils;
using NUnit.Framework;

namespace Affinity.Test.Unit.MockServer.Account;

[TestFixture]
[Parallelizable(ParallelScope.Self)]
public class GetAccountTest : BaseMockServerTest
{
    [NUnit.Framework.Test]
    public async Task MockServerTest_1()
    {
        const string mockResponse = """
            {
              "account": {
                "allowedReturnUrls": [
                  "allowedReturnUrls",
                  "allowedReturnUrls"
                ],
                "displayName": "displayName",
                "id": "id",
                "object": "account",
                "slug": "slug",
                "status": "active",
                "supportEmail": "supportEmail",
                "websiteUrl": "websiteUrl"
              },
              "livemode": true,
              "scopes": [
                "scopes",
                "scopes"
              ],
              "membership": {
                "permissions": [
                  "permissions",
                  "permissions"
                ],
                "role": "administrator",
                "roleName": "roleName",
                "status": "active"
              },
              "operatingMode": "production",
              "user": {
                "email": "email",
                "emailVerified": true,
                "image": "image",
                "name": "name",
                "twoFactorEnabled": true,
                "userId": "userId"
              }
            }
            """;

        Server
            .Given(WireMock.RequestBuilders.Request.Create().WithPath("/v1/account").UsingGet())
            .RespondWith(
                WireMock
                    .ResponseBuilders.Response.Create()
                    .WithStatusCode(200)
                    .WithBody(mockResponse)
            );

        var response = await Client.Account.GetAccountAsync(new GetAccountRequest());
        JsonAssert.AreEqual(response, mockResponse);
    }

    [NUnit.Framework.Test]
    public async Task MockServerTest_2()
    {
        const string mockResponse = """
            {
              "account": {
                "allowedReturnUrls": [
                  "allowedReturnUrls"
                ],
                "displayName": "displayName",
                "id": "acct_01j2y8m6jcc9tt24af5pw9x1bc",
                "object": "account",
                "slug": "slug",
                "status": "active",
                "supportEmail": "supportEmail",
                "websiteUrl": "websiteUrl"
              },
              "livemode": true,
              "scopes": [
                "scopes"
              ],
              "membership": {
                "permissions": [
                  "permissions"
                ],
                "role": "administrator",
                "roleName": "roleName",
                "status": "active"
              },
              "operatingMode": "production",
              "user": {
                "email": "email",
                "emailVerified": true,
                "image": "image",
                "name": "name",
                "twoFactorEnabled": true,
                "userId": "userId"
              }
            }
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/v1/account")
                    .WithParam("orgId", "acct_01j2y8m6jcc9tt24af5pw9x1bc")
                    .UsingGet()
            )
            .RespondWith(
                WireMock
                    .ResponseBuilders.Response.Create()
                    .WithStatusCode(200)
                    .WithBody(mockResponse)
            );

        var response = await Client.Account.GetAccountAsync(
            new GetAccountRequest { OrgId = "acct_01j2y8m6jcc9tt24af5pw9x1bc" }
        );
        JsonAssert.AreEqual(response, mockResponse);
    }
}
