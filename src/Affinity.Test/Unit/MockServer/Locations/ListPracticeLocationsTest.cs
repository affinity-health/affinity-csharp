using Affinity;
using Affinity.Test.Unit.MockServer;
using Affinity.Test.Utils;
using NUnit.Framework;

namespace Affinity.Test.Unit.MockServer.Locations;

[TestFixture]
[Parallelizable(ParallelScope.Self)]
public class ListPracticeLocationsTest : BaseMockServerTest
{
    [NUnit.Framework.Test]
    public async Task MockServerTest_1()
    {
        const string mockResponse = """
            {
              "data": [
                {
                  "id": "id",
                  "object": "location",
                  "practiceId": "practiceId",
                  "name": "name",
                  "timezone": "timezone",
                  "city": "city",
                  "country": "country",
                  "line1": "line1",
                  "line2": "line2",
                  "phone": "phone",
                  "postalCode": "postalCode",
                  "state": "state",
                  "status": "active",
                  "createdAt": "createdAt",
                  "updatedAt": "updatedAt"
                },
                {
                  "id": "id",
                  "object": "location",
                  "practiceId": "practiceId",
                  "name": "name",
                  "timezone": "timezone",
                  "city": "city",
                  "country": "country",
                  "line1": "line1",
                  "line2": "line2",
                  "phone": "phone",
                  "postalCode": "postalCode",
                  "state": "state",
                  "status": "active",
                  "createdAt": "createdAt",
                  "updatedAt": "updatedAt"
                }
              ],
              "object": "list",
              "hasMore": true,
              "url": "url"
            }
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/v1/practices/practiceId/locations")
                    .UsingGet()
            )
            .RespondWith(
                WireMock
                    .ResponseBuilders.Response.Create()
                    .WithStatusCode(200)
                    .WithBody(mockResponse)
            );

        var response = await Client.Locations.ListPracticeLocationsAsync(
            new ListPracticeLocationsRequest { PracticeId = "practiceId" }
        );
        JsonAssert.AreEqual(response, mockResponse);
    }

    [NUnit.Framework.Test]
    public async Task MockServerTest_2()
    {
        const string mockResponse = """
            {
              "data": [
                {
                  "id": "loc_01j2y8m6jcc9tt24af5pw9x1bc",
                  "object": "location",
                  "practiceId": "prac_01j2y8m6jcc9tt24af5pw9x1bc",
                  "name": "name",
                  "timezone": "timezone",
                  "city": "city",
                  "country": "country",
                  "line1": "line1",
                  "line2": "line2",
                  "phone": "phone",
                  "postalCode": "postalCode",
                  "state": "state",
                  "status": "active",
                  "createdAt": "createdAt",
                  "updatedAt": "updatedAt"
                }
              ],
              "object": "list",
              "hasMore": true,
              "url": "url"
            }
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/v1/practices/prac_01j2y8m6jcc9tt24af5pw9x1bc/locations")
                    .WithParam("startingAfter", "loc_01j2y8m6jcc9tt24af5pw9x1bc")
                    .WithParam("endingBefore", "loc_01j2y8m6jcc9tt24af5pw9x1bc")
                    .UsingGet()
            )
            .RespondWith(
                WireMock
                    .ResponseBuilders.Response.Create()
                    .WithStatusCode(200)
                    .WithBody(mockResponse)
            );

        var response = await Client.Locations.ListPracticeLocationsAsync(
            new ListPracticeLocationsRequest
            {
                PracticeId = "prac_01j2y8m6jcc9tt24af5pw9x1bc",
                StartingAfter = "loc_01j2y8m6jcc9tt24af5pw9x1bc",
                EndingBefore = "loc_01j2y8m6jcc9tt24af5pw9x1bc",
            }
        );
        JsonAssert.AreEqual(response, mockResponse);
    }
}
