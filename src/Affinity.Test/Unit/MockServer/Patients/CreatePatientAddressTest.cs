using Affinity;
using Affinity.Test.Unit.MockServer;
using Affinity.Test.Utils;
using NUnit.Framework;

namespace Affinity.Test.Unit.MockServer.Patients;

[TestFixture]
[Parallelizable(ParallelScope.Self)]
public class CreatePatientAddressTest : BaseMockServerTest
{
    [NUnit.Framework.Test]
    public async Task MockServerTest_1()
    {
        const string requestJson = """
            {
              "address": {
                "city": "city",
                "line1": "line1",
                "postalCode": "postalCode",
                "state": "state"
              }
            }
            """;

        const string mockResponse = """
            {
              "id": "id",
              "address": {
                "city": "city",
                "country": "country",
                "line1": "line1",
                "line2": "line2",
                "postalCode": "postalCode",
                "state": "state"
              },
              "label": "label",
              "preferredShipping": true,
              "recipientName": "recipientName",
              "archivedAt": "archivedAt"
            }
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/v1/practices/practiceId/patients/patientId/addresses")
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

        var response = await Client.Patients.CreatePatientAddressAsync(
            new CreatePatientAddressRequest
            {
                PracticeId = "practiceId",
                PatientId = "patientId",
                IdempotencyKey = "idempotencyKey",
                Address = new CreatePatientAddressRequestAddress
                {
                    City = "city",
                    Country = null,
                    Line1 = "line1",
                    Line2 = null,
                    PostalCode = "postalCode",
                    State = "state",
                },
                Label = null,
                PreferredShipping = null,
                RecipientName = null,
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
                "city": "city",
                "line1": "line1",
                "postalCode": "postalCode",
                "state": "state"
              }
            }
            """;

        const string mockResponse = """
            {
              "id": "addr_01j2y8m6jcc9tt24af5pw9x1bc",
              "address": {
                "city": "city",
                "country": "country",
                "line1": "line1",
                "line2": "line2",
                "postalCode": "postalCode",
                "state": "state"
              },
              "label": "label",
              "preferredShipping": true,
              "recipientName": "recipientName",
              "archivedAt": "archivedAt"
            }
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath(
                        "/v1/practices/prac_01j2y8m6jcc9tt24af5pw9x1bc/patients/pat_01j2y8m6jcc9tt24af5pw9x1bc/addresses"
                    )
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

        var response = await Client.Patients.CreatePatientAddressAsync(
            new CreatePatientAddressRequest
            {
                PracticeId = "prac_01j2y8m6jcc9tt24af5pw9x1bc",
                PatientId = "pat_01j2y8m6jcc9tt24af5pw9x1bc",
                IdempotencyKey = "Idempotency-Key",
                Address = new CreatePatientAddressRequestAddress
                {
                    City = "city",
                    Line1 = "line1",
                    PostalCode = "postalCode",
                    State = "state",
                },
            }
        );
        JsonAssert.AreEqual(response, mockResponse);
    }
}
