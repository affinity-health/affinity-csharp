using Affinity;
using Affinity.Test.Unit.MockServer;
using Affinity.Test.Utils;
using NUnit.Framework;

namespace Affinity.Test.Unit.MockServer.Patients;

[TestFixture]
[Parallelizable(ParallelScope.Self)]
public class DeletePatientTest : BaseMockServerTest
{
    [NUnit.Framework.Test]
    public async Task MockServerTest_1()
    {
        const string mockResponse = """
            {
              "deleted": true,
              "id": "id",
              "object": "patient"
            }
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/v1/practices/practiceId/patients/patientId")
                    .WithHeader("Idempotency-Key", "idempotencyKey")
                    .UsingDelete()
            )
            .RespondWith(
                WireMock
                    .ResponseBuilders.Response.Create()
                    .WithStatusCode(200)
                    .WithBody(mockResponse)
            );

        var response = await Client.Patients.DeletePatientAsync(
            new DeletePatientRequest
            {
                PracticeId = "practiceId",
                PatientId = "patientId",
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
              "deleted": true,
              "id": "pat_01j2y8m6jcc9tt24af5pw9x1bc",
              "object": "patient"
            }
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath(
                        "/v1/practices/prac_01j2y8m6jcc9tt24af5pw9x1bc/patients/pat_01j2y8m6jcc9tt24af5pw9x1bc"
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

        var response = await Client.Patients.DeletePatientAsync(
            new DeletePatientRequest
            {
                PracticeId = "prac_01j2y8m6jcc9tt24af5pw9x1bc",
                PatientId = "pat_01j2y8m6jcc9tt24af5pw9x1bc",
                IdempotencyKey = "Idempotency-Key",
            }
        );
        JsonAssert.AreEqual(response, mockResponse);
    }
}
