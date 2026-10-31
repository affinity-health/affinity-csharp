using Affinity;
using Affinity.Test.Unit.MockServer;
using Affinity.Test.Utils;
using NUnit.Framework;

namespace Affinity.Test.Unit.MockServer.Practices;

[TestFixture]
[Parallelizable(ParallelScope.Self)]
public class CreateTest : BaseMockServerTest
{
    [NUnit.Framework.Test]
    public async Task MockServerTest_1()
    {
        const string requestJson = """
            {
              "address": {
                "line1": "line1",
                "city": "city",
                "state": "state",
                "postalCode": "postalCode"
              },
              "name": "name",
              "phone": "phone"
            }
            """;

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
              "externalId": "externalId"
            }
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/v1/practices")
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

        var response = await Client.Practices.CreateAsync(
            new CreatePracticesRequest
            {
                IdempotencyKey = "idempotencyKey",
                ExternalId = null,
                Address = new AddressInput
                {
                    Line1 = "line1",
                    Line2 = null,
                    City = "city",
                    State = "state",
                    PostalCode = "postalCode",
                },
                LiveEnabled = null,
                Name = "name",
                Phone = "phone",
            }
        );
        JsonAssert.AreEqual(response, mockResponse);
    }

    [NUnit.Framework.Test]
    public async Task MockServerTest_2()
    {
        const string requestJson = """
            {
              "address": {
                "line1": "line1",
                "city": "city",
                "state": "state",
                "postalCode": "postalCode"
              },
              "name": "name",
              "phone": "phone"
            }
            """;

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
              "externalId": "externalId"
            }
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/v1/practices")
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

        var response = await Client.Practices.CreateAsync(
            new CreatePracticesRequest
            {
                IdempotencyKey = "Idempotency-Key",
                Address = new AddressInput
                {
                    Line1 = "line1",
                    City = "city",
                    State = "state",
                    PostalCode = "postalCode",
                },
                Name = "name",
                Phone = "phone",
            }
        );
        JsonAssert.AreEqual(response, mockResponse);
    }
}
