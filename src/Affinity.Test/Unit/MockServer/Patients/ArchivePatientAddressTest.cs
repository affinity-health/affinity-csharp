using Affinity;
using Affinity.Test.Unit.MockServer;
using Affinity.Test.Utils;
using NUnit.Framework;

namespace Affinity.Test.Unit.MockServer.Patients;

[TestFixture]
[Parallelizable(ParallelScope.Self)]
public class ArchivePatientAddressTest : BaseMockServerTest
{
    [NUnit.Framework.Test]
    public async Task MockServerTest_1()
    {
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
                    .WithPath("/v1/practices/practiceId/patients/patientId/addresses/addressId")
                    .WithHeader("Idempotency-Key", "idempotencyKey")
                    .UsingDelete()
            )
            .RespondWith(
                WireMock
                    .ResponseBuilders.Response.Create()
                    .WithStatusCode(200)
                    .WithBody(mockResponse)
            );

        var response = await Client.Patients.ArchivePatientAddressAsync(
            new ArchivePatientAddressRequest
            {
                PracticeId = "practiceId",
                PatientId = "patientId",
                AddressId = "addressId",
                IdempotencyKey = "idempotencyKey",
            }
        );
        JsonAssert.AreEqual(response, mockResponse);
    }

    [NUnit.Framework.Test]
    public async Task MockServerTest_2()
    {
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
                        "/v1/practices/prac_01j2y8m6jcc9tt24af5pw9x1bc/patients/pat_01j2y8m6jcc9tt24af5pw9x1bc/addresses/addr_01j2y8m6jcc9tt24af5pw9x1bc"
                    )
                    .WithHeader("Idempotency-Key", "Idempotency-Key")
                    .UsingDelete()
            )
            .RespondWith(
                WireMock
                    .ResponseBuilders.Response.Create()
                    .WithStatusCode(200)
                    .WithBody(mockResponse)
            );

        var response = await Client.Patients.ArchivePatientAddressAsync(
            new ArchivePatientAddressRequest
            {
                PracticeId = "prac_01j2y8m6jcc9tt24af5pw9x1bc",
                PatientId = "pat_01j2y8m6jcc9tt24af5pw9x1bc",
                AddressId = "addr_01j2y8m6jcc9tt24af5pw9x1bc",
                IdempotencyKey = "Idempotency-Key",
            }
        );
        JsonAssert.AreEqual(response, mockResponse);
    }
}
