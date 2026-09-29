using Affinity.Test.Unit.MockServer;
using Affinity.Test.Utils;
using NUnit.Framework;

namespace Affinity.Test.Unit.MockServer.ApiKeys;

[TestFixture]
[Parallelizable(ParallelScope.Self)]
public class GetApiAccessTest : BaseMockServerTest
{
    [NUnit.Framework.Test]
    public async Task MockServerTest_1()
    {
        const string mockResponse = """
            {
              "apiKey": {
                "id": "id",
                "keyPrefix": "keyPrefix",
                "object": "api_key"
              },
              "livemode": true,
              "object": "api_access",
              "scopes": [
                "scopes",
                "scopes"
              ],
              "serviceAccount": {
                "apiVersion": "2026-09-28",
                "id": "id",
                "object": "service_account",
                "subjectId": "subjectId",
                "subjectType": "subjectType"
              }
            }
            """;

        Server
            .Given(WireMock.RequestBuilders.Request.Create().WithPath("/v1/auth/access").UsingGet())
            .RespondWith(
                WireMock
                    .ResponseBuilders.Response.Create()
                    .WithStatusCode(200)
                    .WithBody(mockResponse)
            );

        var response = await Client.ApiKeys.GetApiAccessAsync();
        JsonAssert.AreEqual(response, mockResponse);
    }

    [NUnit.Framework.Test]
    public async Task MockServerTest_2()
    {
        const string mockResponse = """
            {
              "apiKey": {
                "id": "key_01j2y8m6jcc9tt24af5pw9x1bc",
                "keyPrefix": "keyPrefix",
                "object": "api_key"
              },
              "livemode": true,
              "object": "api_access",
              "scopes": [
                "scopes"
              ],
              "serviceAccount": {
                "apiVersion": "2026-09-28",
                "id": "sa_01j2y8m6jcc9tt24af5pw9x1bc",
                "object": "service_account",
                "subjectId": "subjectId",
                "subjectType": "subjectType"
              }
            }
            """;

        Server
            .Given(WireMock.RequestBuilders.Request.Create().WithPath("/v1/auth/access").UsingGet())
            .RespondWith(
                WireMock
                    .ResponseBuilders.Response.Create()
                    .WithStatusCode(200)
                    .WithBody(mockResponse)
            );

        var response = await Client.ApiKeys.GetApiAccessAsync();
        JsonAssert.AreEqual(response, mockResponse);
    }
}
