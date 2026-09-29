using Affinity;
using Affinity.Test.Unit.MockServer;
using Affinity.Test.Utils;
using NUnit.Framework;

namespace Affinity.Test.Unit.MockServer.Patients;

[TestFixture]
[Parallelizable(ParallelScope.Self)]
public class ListPatientAddressesTest : BaseMockServerTest
{
    [NUnit.Framework.Test]
    public async Task MockServerTest_1()
    {
        const string mockResponse = """
            {
              "data": [
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
                },
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
                    .WithPath("/v1/practices/practiceId/patients/patientId/addresses")
                    .UsingGet()
            )
            .RespondWith(
                WireMock
                    .ResponseBuilders.Response.Create()
                    .WithStatusCode(200)
                    .WithBody(mockResponse)
            );

        var response = await Client.Patients.ListPatientAddressesAsync(
            new ListPatientAddressesRequest { PracticeId = "practiceId", PatientId = "patientId" }
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
                  "id": "id",
                  "address": {
                    "city": "city",
                    "line1": "line1",
                    "postalCode": "postalCode",
                    "state": "state"
                  },
                  "label": "label",
                  "preferredShipping": true,
                  "recipientName": "recipientName",
                  "archivedAt": "archivedAt"
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
                    .WithPath(
                        "/v1/practices/prac_01j2y8m6jcc9tt24af5pw9x1bc/patients/pat_01j2y8m6jcc9tt24af5pw9x1bc/addresses"
                    )
                    .WithParam("startingAfter", "addr_01j2y8m6jcc9tt24af5pw9x1bc")
                    .WithParam("endingBefore", "addr_01j2y8m6jcc9tt24af5pw9x1bc")
                    .UsingGet()
            )
            .RespondWith(
                WireMock
                    .ResponseBuilders.Response.Create()
                    .WithStatusCode(200)
                    .WithBody(mockResponse)
            );

        var response = await Client.Patients.ListPatientAddressesAsync(
            new ListPatientAddressesRequest
            {
                PracticeId = "prac_01j2y8m6jcc9tt24af5pw9x1bc",
                PatientId = "pat_01j2y8m6jcc9tt24af5pw9x1bc",
                StartingAfter = "addr_01j2y8m6jcc9tt24af5pw9x1bc",
                EndingBefore = "addr_01j2y8m6jcc9tt24af5pw9x1bc",
            }
        );
        JsonAssert.AreEqual(response, mockResponse);
    }
}
