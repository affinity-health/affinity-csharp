using Affinity;
using Affinity.Test.Unit.MockServer;
using Affinity.Test.Utils;
using NUnit.Framework;

namespace Affinity.Test.Unit.MockServer.Patients;

[TestFixture]
[Parallelizable(ParallelScope.Self)]
public class ReplacePatientAllergiesTest : BaseMockServerTest
{
    [NUnit.Framework.Test]
    public async Task MockServerTest_1()
    {
        const string requestJson = """
            {
              "allergies": [
                {
                  "category": "drug",
                  "reactions": [
                    {
                      "display": "display"
                    },
                    {
                      "display": "display"
                    }
                  ],
                  "source": "Doctor",
                  "substance": "substance",
                  "verificationStatus": "unconfirmed"
                },
                {
                  "category": "drug",
                  "reactions": [
                    {
                      "display": "display"
                    },
                    {
                      "display": "display"
                    }
                  ],
                  "source": "Doctor",
                  "substance": "substance",
                  "verificationStatus": "unconfirmed"
                }
              ],
              "reviewStatus": "not_reviewed"
            }
            """;

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
                    .WithHeader("Idempotency-Key", "idempotencyKey")
                    .WithHeader("Content-Type", "application/json")
                    .UsingPut()
                    .WithBodyAsJson(requestJson)
            )
            .RespondWith(
                WireMock
                    .ResponseBuilders.Response.Create()
                    .WithStatusCode(200)
                    .WithBody(mockResponse)
            );

        var response = await Client.Patients.ReplacePatientAllergiesAsync(
            new ReplacePatientAllergiesRequest
            {
                PracticeId = "practiceId",
                PatientId = "patientId",
                IdempotencyKey = "idempotencyKey",
                Allergies = new List<ReplacePatientAllergiesRequestAllergiesItem>()
                {
                    new ReplacePatientAllergiesRequestAllergiesItem
                    {
                        Category = ReplacePatientAllergiesRequestAllergiesItemCategory.Drug,
                        Code = null,
                        CodeSystem = null,
                        Reactions =
                            new List<ReplacePatientAllergiesRequestAllergiesItemReactionsItem>()
                            {
                                new ReplacePatientAllergiesRequestAllergiesItemReactionsItem
                                {
                                    Code = null,
                                    CodeSystem = null,
                                    Display = "display",
                                },
                                new ReplacePatientAllergiesRequestAllergiesItemReactionsItem
                                {
                                    Code = null,
                                    CodeSystem = null,
                                    Display = "display",
                                },
                            },
                        Severity = null,
                        Source = ReplacePatientAllergiesRequestAllergiesItemSource.Doctor,
                        Substance = "substance",
                        Type = null,
                        VerificationStatus =
                            ReplacePatientAllergiesRequestAllergiesItemVerificationStatus.Unconfirmed,
                    },
                    new ReplacePatientAllergiesRequestAllergiesItem
                    {
                        Category = ReplacePatientAllergiesRequestAllergiesItemCategory.Drug,
                        Code = null,
                        CodeSystem = null,
                        Reactions =
                            new List<ReplacePatientAllergiesRequestAllergiesItemReactionsItem>()
                            {
                                new ReplacePatientAllergiesRequestAllergiesItemReactionsItem
                                {
                                    Code = null,
                                    CodeSystem = null,
                                    Display = "display",
                                },
                                new ReplacePatientAllergiesRequestAllergiesItemReactionsItem
                                {
                                    Code = null,
                                    CodeSystem = null,
                                    Display = "display",
                                },
                            },
                        Severity = null,
                        Source = ReplacePatientAllergiesRequestAllergiesItemSource.Doctor,
                        Substance = "substance",
                        Type = null,
                        VerificationStatus =
                            ReplacePatientAllergiesRequestAllergiesItemVerificationStatus.Unconfirmed,
                    },
                },
                ReviewStatus = ReplacePatientAllergiesRequestReviewStatus.NotReviewed,
            }
        );
        JsonAssert.AreEqual(response, mockResponse);
    }

    [NUnit.Framework.Test]
    public async Task MockServerTest_2()
    {
        const string requestJson = """
            {
              "allergies": [
                {
                  "category": "drug",
                  "reactions": [
                    {
                      "display": "display"
                    }
                  ],
                  "source": "Doctor",
                  "substance": "substance",
                  "verificationStatus": "unconfirmed"
                }
              ],
              "reviewStatus": "not_reviewed"
            }
            """;

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
                    .WithHeader("Idempotency-Key", "Idempotency-Key")
                    .WithHeader("Content-Type", "application/json")
                    .UsingPut()
                    .WithBodyAsJson(requestJson)
            )
            .RespondWith(
                WireMock
                    .ResponseBuilders.Response.Create()
                    .WithStatusCode(200)
                    .WithBody(mockResponse)
            );

        var response = await Client.Patients.ReplacePatientAllergiesAsync(
            new ReplacePatientAllergiesRequest
            {
                PracticeId = "prac_01j2y8m6jcc9tt24af5pw9x1bc",
                PatientId = "pat_01j2y8m6jcc9tt24af5pw9x1bc",
                IdempotencyKey = "Idempotency-Key",
                Allergies = new List<ReplacePatientAllergiesRequestAllergiesItem>()
                {
                    new ReplacePatientAllergiesRequestAllergiesItem
                    {
                        Category = ReplacePatientAllergiesRequestAllergiesItemCategory.Drug,
                        Reactions =
                            new List<ReplacePatientAllergiesRequestAllergiesItemReactionsItem>()
                            {
                                new ReplacePatientAllergiesRequestAllergiesItemReactionsItem
                                {
                                    Display = "display",
                                },
                            },
                        Source = ReplacePatientAllergiesRequestAllergiesItemSource.Doctor,
                        Substance = "substance",
                        VerificationStatus =
                            ReplacePatientAllergiesRequestAllergiesItemVerificationStatus.Unconfirmed,
                    },
                },
                ReviewStatus = ReplacePatientAllergiesRequestReviewStatus.NotReviewed,
            }
        );
        JsonAssert.AreEqual(response, mockResponse);
    }
}
