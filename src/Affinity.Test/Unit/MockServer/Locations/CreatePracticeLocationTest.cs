using Affinity;
using Affinity.Test.Unit.MockServer;
using Affinity.Test.Utils;
using NUnit.Framework;

namespace Affinity.Test.Unit.MockServer.Locations;

[TestFixture]
[Parallelizable(ParallelScope.Self)]
public class CreatePracticeLocationTest : BaseMockServerTest
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
                    .WithPath("/v1/practices/practiceId/locations")
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

        var response = await Client.Locations.CreatePracticeLocationAsync(
            new CreatePracticeLocationRequest
            {
                PracticeId = "practiceId",
                IdempotencyKey = "idempotencyKey",
                City = null,
                Country = null,
                Line1 = null,
                Line2 = null,
                Name = "name",
                Phone = null,
                PostalCode = null,
                State = null,
                Timezone = null,
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
                    .WithPath("/v1/practices/prac_01j2y8m6jcc9tt24af5pw9x1bc/locations")
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

        var response = await Client.Locations.CreatePracticeLocationAsync(
            new CreatePracticeLocationRequest
            {
                PracticeId = "prac_01j2y8m6jcc9tt24af5pw9x1bc",
                IdempotencyKey = "Idempotency-Key",
                Name = "name",
            }
        );
        JsonAssert.AreEqual(response, mockResponse);
    }
}
