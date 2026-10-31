using Affinity;
using Affinity.Test.Unit.MockServer;
using NUnit.Framework;

namespace Affinity.Test.Unit.MockServer.Practices;

[TestFixture]
[Parallelizable(ParallelScope.Self)]
public class ListTest : BaseMockServerTest
{
    [NUnit.Framework.Test]
    public async Task MockServerTest_1()
    {
        const string mockResponse = """
            {
              "data": [
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
                  "externalId": "externalId"
                },
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
                  "externalId": "externalId"
                }
              ],
              "hasMore": true,
              "nextCursor": "nextCursor",
              "object": "list",
              "url": "url"
            }
            """;

        Server
            .Given(WireMock.RequestBuilders.Request.Create().WithPath("/v1/practices").UsingGet())
            .RespondWith(
                WireMock
                    .ResponseBuilders.Response.Create()
                    .WithStatusCode(200)
                    .WithBody(mockResponse)
            );

        var items = await Client.Practices.ListAsync(new ListPracticesRequest());
        await foreach (var item in items)
        {
            Assert.That(item, Is.Not.Null);
            break; // Only check the first item
        }
    }

    [NUnit.Framework.Test]
    public async Task MockServerTest_2()
    {
        const string mockResponse = """
            {
              "data": [
                {
                  "id": "prac_01j2y8m6jcc9tt24af5pw9x1bc",
                  "name": "name",
                  "phone": "phone",
                  "address": {
                    "line1": "line1",
                    "city": "city",
                    "state": "state",
                    "postalCode": "postalCode"
                  },
                  "liveEnabled": true,
                  "createdAt": "2024-01-15T09:30:00.000Z",
                  "externalId": "externalId"
                }
              ],
              "hasMore": true,
              "nextCursor": "nextCursor",
              "object": "list",
              "url": "url"
            }
            """;

        Server
            .Given(WireMock.RequestBuilders.Request.Create().WithPath("/v1/practices").UsingGet())
            .RespondWith(
                WireMock
                    .ResponseBuilders.Response.Create()
                    .WithStatusCode(200)
                    .WithBody(mockResponse)
            );

        var items = await Client.Practices.ListAsync(new ListPracticesRequest());
        await foreach (var item in items)
        {
            Assert.That(item, Is.Not.Null);
            break; // Only check the first item
        }
    }
}
