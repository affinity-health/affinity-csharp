using Affinity.Test.Unit.MockServer;
using Affinity.Test.Utils;
using NUnit.Framework;

namespace Affinity.Test.Unit.MockServer.Account;

[TestFixture]
[Parallelizable(ParallelScope.Self)]
public class GetTest : BaseMockServerTest
{
    [NUnit.Framework.Test]
    public async Task MockServerTest_1()
    {
        const string mockResponse = """
            {
              "id": "id",
              "name": "name",
              "phone": "phone",
              "address": {
                "line1": "line1",
                "line2": "line2",
                "city": "city",
                "state": "state",
                "postalCode": "postalCode"
              },
              "liveEnabled": true,
              "createdAt": "2024-01-15T09:30:00.000Z",
              "mode": "test",
              "type": "platform"
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

        var response = await Client.Account.GetAsync();
        JsonAssert.AreEqual(response, mockResponse);
    }

    [NUnit.Framework.Test]
    public async Task MockServerTest_2()
    {
        const string mockResponse = """
            {
              "id": "prac_01j2y8m6jcc9tt24af5pw9x1bc",
              "name": "name",
              "phone": "phone",
              "address": {
                "line1": "line1",
                "line2": "line2",
                "city": "city",
                "state": "state",
                "postalCode": "postalCode"
              },
              "liveEnabled": true,
              "createdAt": "2024-01-15T09:30:00.000Z",
              "mode": "test",
              "type": "platform"
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

        var response = await Client.Account.GetAsync();
        JsonAssert.AreEqual(response, mockResponse);
    }
}
