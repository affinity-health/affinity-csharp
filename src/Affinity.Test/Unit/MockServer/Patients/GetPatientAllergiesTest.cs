using Affinity;
using Affinity.Test.Unit.MockServer;
using Affinity.Test.Utils;
using NUnit.Framework;

namespace Affinity.Test.Unit.MockServer.Patients;

[TestFixture]
[Parallelizable(ParallelScope.Self)]
public class GetPatientAllergiesTest : BaseMockServerTest
{
    [NUnit.Framework.Test]
    public async Task MockServerTest_1()
    {
        const string mockResponse = """
            {
              "allergies": [
                {
                  "category": "drug",
                  "code": "code",
                  "codeSystem": "rxnorm",
                  "id": "id",
                  "reactions": [
                    {
                      "code": "code",
                      "codeSystem": "snomed-ct",
                      "display": "display"
                    },
                    {
                      "code": "code",
                      "codeSystem": "snomed-ct",
                      "display": "display"
                    }
                  ],
                  "severity": "mild",
                  "source": "Doctor",
                  "substance": "substance",
                  "type": "allergy",
                  "verificationStatus": "unconfirmed"
                },
                {
                  "category": "drug",
                  "code": "code",
                  "codeSystem": "rxnorm",
                  "id": "id",
                  "reactions": [
                    {
                      "code": "code",
                      "codeSystem": "snomed-ct",
                      "display": "display"
                    },
                    {
                      "code": "code",
                      "codeSystem": "snomed-ct",
                      "display": "display"
                    }
                  ],
                  "severity": "mild",
                  "source": "Doctor",
                  "substance": "substance",
                  "type": "allergy",
                  "verificationStatus": "unconfirmed"
                }
              ],
              "reviewStatus": "not_reviewed"
            }
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/v1/practices/practiceId/patients/patientId/allergies")
                    .UsingGet()
            )
            .RespondWith(
                WireMock
                    .ResponseBuilders.Response.Create()
                    .WithStatusCode(200)
                    .WithBody(mockResponse)
            );

        var response = await Client.Patients.GetPatientAllergiesAsync(
            new GetPatientAllergiesRequest { PracticeId = "practiceId", PatientId = "patientId" }
        );
        JsonAssert.AreEqual(response, mockResponse);
    }

    [NUnit.Framework.Test]
    public async Task MockServerTest_2()
    {
        const string mockResponse = """
            {
              "allergies": [
                {
                  "category": "drug",
                  "code": "code",
                  "codeSystem": "rxnorm",
                  "id": "id",
                  "reactions": [
                    {
                      "display": "display"
                    }
                  ],
                  "severity": "mild",
                  "source": "Doctor",
                  "substance": "substance",
                  "type": "allergy",
                  "verificationStatus": "unconfirmed"
                }
              ],
              "reviewStatus": "not_reviewed"
            }
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath(
                        "/v1/practices/prac_01j2y8m6jcc9tt24af5pw9x1bc/patients/pat_01j2y8m6jcc9tt24af5pw9x1bc/allergies"
                    )
                    .UsingGet()
            )
            .RespondWith(
                WireMock
                    .ResponseBuilders.Response.Create()
                    .WithStatusCode(200)
                    .WithBody(mockResponse)
            );

        var response = await Client.Patients.GetPatientAllergiesAsync(
            new GetPatientAllergiesRequest
            {
                PracticeId = "prac_01j2y8m6jcc9tt24af5pw9x1bc",
                PatientId = "pat_01j2y8m6jcc9tt24af5pw9x1bc",
            }
        );
        JsonAssert.AreEqual(response, mockResponse);
    }
}
