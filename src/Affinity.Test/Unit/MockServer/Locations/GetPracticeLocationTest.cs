using Affinity;
using Affinity.Test.Unit.MockServer;
using Affinity.Test.Utils;
using NUnit.Framework;

namespace Affinity.Test.Unit.MockServer.Locations;

[TestFixture]
[Parallelizable(ParallelScope.Self)]
public class GetPracticeLocationTest : BaseMockServerTest
{
    [NUnit.Framework.Test]
    public async Task MockServerTest_1()
    {
        const string mockResponse = """
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
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/v1/practices/practiceId/locations/locationId")
                    .UsingGet()
            )
            .RespondWith(
                WireMock
                    .ResponseBuilders.Response.Create()
                    .WithStatusCode(200)
                    .WithBody(mockResponse)
            );

        var response = await Client.Locations.GetPracticeLocationAsync(
            new GetPracticeLocationRequest { PracticeId = "practiceId", LocationId = "locationId" }
        );
        JsonAssert.AreEqual(response, mockResponse);
    }

    [NUnit.Framework.Test]
    public async Task MockServerTest_2()
    {
        const string mockResponse = """
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
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath(
                        "/v1/practices/prac_01j2y8m6jcc9tt24af5pw9x1bc/locations/loc_01j2y8m6jcc9tt24af5pw9x1bc"
                    )
                    .UsingGet()
            )
            .RespondWith(
                WireMock
                    .ResponseBuilders.Response.Create()
                    .WithStatusCode(200)
                    .WithBody(mockResponse)
            );

        var response = await Client.Locations.GetPracticeLocationAsync(
            new GetPracticeLocationRequest
            {
                PracticeId = "prac_01j2y8m6jcc9tt24af5pw9x1bc",
                LocationId = "loc_01j2y8m6jcc9tt24af5pw9x1bc",
            }
        );
        JsonAssert.AreEqual(response, mockResponse);
    }
}
