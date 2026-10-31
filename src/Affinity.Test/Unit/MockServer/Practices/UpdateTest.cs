using Affinity;
using Affinity.Test.Unit.MockServer;
using Affinity.Test.Utils;
using NUnit.Framework;

namespace Affinity.Test.Unit.MockServer.Practices;

[TestFixture]
[Parallelizable(ParallelScope.Self)]
public class UpdateTest : BaseMockServerTest
{
    [NUnit.Framework.Test]
    public async Task MockServerTest_1()
    {
        const string requestJson = """
            {}
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
                    .WithPath("/v1/practices/practiceId")
                    .WithHeader("Idempotency-Key", "idempotencyKey")
                    .WithHeader("Content-Type", "application/json")
                    .UsingPatch()
                    .WithBodyAsJson(requestJson)
            )
            .RespondWith(
                WireMock
                    .ResponseBuilders.Response.Create()
                    .WithStatusCode(200)
                    .WithBody(mockResponse)
            );

        var response = await Client.Practices.UpdateAsync(
            new UpdatePracticesRequest
            {
                PracticeId = "practiceId",
                IdempotencyKey = "idempotencyKey",
                ExternalId = null,
                Address = null,
                LiveEnabled = null,
                Name = null,
                Phone = null,
            }
        );
        JsonAssert.AreEqual(response, mockResponse);
    }

    [NUnit.Framework.Test]
    public async Task MockServerTest_2()
    {
        const string requestJson = """
            {}
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
                    .WithPath("/v1/practices/prac_01j2y8m6jcc9tt24af5pw9x1bc")
                    .WithHeader("Idempotency-Key", "Idempotency-Key")
                    .WithHeader("Content-Type", "application/json")
                    .UsingPatch()
                    .WithBodyAsJson(requestJson)
            )
            .RespondWith(
                WireMock
                    .ResponseBuilders.Response.Create()
                    .WithStatusCode(200)
                    .WithBody(mockResponse)
            );

        var response = await Client.Practices.UpdateAsync(
            new UpdatePracticesRequest
            {
                PracticeId = "prac_01j2y8m6jcc9tt24af5pw9x1bc",
                IdempotencyKey = "Idempotency-Key",
            }
        );
        JsonAssert.AreEqual(response, mockResponse);
    }
}
