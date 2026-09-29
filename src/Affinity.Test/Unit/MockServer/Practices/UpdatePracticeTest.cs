using Affinity;
using Affinity.Test.Unit.MockServer;
using Affinity.Test.Utils;
using NUnit.Framework;

namespace Affinity.Test.Unit.MockServer.Practices;

[TestFixture]
[Parallelizable(ParallelScope.Self)]
public class UpdatePracticeTest : BaseMockServerTest
{
    [NUnit.Framework.Test]
    public async Task MockServerTest_1()
    {
        const string requestJson = """
            {}
            """;

        const string mockResponse = """
            {
              "address": {
                "city": "city",
                "country": "country",
                "line1": "line1",
                "line2": "line2",
                "postalCode": "postalCode",
                "state": "state"
              },
              "contacts": {
                "compliance": {
                  "email": "email",
                  "name": "name",
                  "phone": "phone"
                },
                "primary": {
                  "email": "email",
                  "name": "name",
                  "phone": "phone"
                }
              },
              "createdAt": "createdAt",
              "externalId": "externalId",
              "id": "id",
              "legalName": "legalName",
              "livemode": true,
              "metadata": {
                "metadata": {
                  "key": "value"
                }
              },
              "name": "name",
              "object": "practice",
              "prescribers": [
                {
                  "credentials": "credentials",
                  "licenseStates": [
                    "licenseStates",
                    "licenseStates"
                  ],
                  "name": "name",
                  "npi": "npi"
                },
                {
                  "credentials": "credentials",
                  "licenseStates": [
                    "licenseStates",
                    "licenseStates"
                  ],
                  "name": "name",
                  "npi": "npi"
                }
              ],
              "liveEnabled": true,
              "supportEmail": "supportEmail",
              "supportPhone": "supportPhone",
              "timezone": "timezone"
            }
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/v1/practices/practiceId")
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

        var response = await Client.Practices.UpdatePracticeAsync(
            new UpdatePracticeRequest
            {
                PracticeId = "practiceId",
                LiveEnabled = null,
                Address = null,
                Attestations = null,
                ComplianceContact = null,
                ExternalId = null,
                LegalName = null,
                Metadata = null,
                Name = null,
                Prescribers = null,
                PrimaryContact = null,
                SupportEmail = null,
                SupportPhone = null,
                Timezone = null,
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
              "address": {
                "city": "city",
                "country": "country",
                "line1": "line1",
                "line2": "line2",
                "postalCode": "postalCode",
                "state": "state"
              },
              "contacts": {
                "compliance": {
                  "email": "email",
                  "name": "name",
                  "phone": "phone"
                },
                "primary": {
                  "email": "email",
                  "name": "name",
                  "phone": "phone"
                }
              },
              "createdAt": "createdAt",
              "externalId": "externalId",
              "id": "prac_01j2y8m6jcc9tt24af5pw9x1bc",
              "legalName": "legalName",
              "livemode": true,
              "metadata": {
                "key": "value"
              },
              "name": "name",
              "object": "practice",
              "prescribers": [
                {
                  "credentials": "credentials",
                  "licenseStates": [
                    "licenseStates"
                  ],
                  "name": "name",
                  "npi": "npi"
                }
              ],
              "liveEnabled": true,
              "supportEmail": "supportEmail",
              "supportPhone": "supportPhone",
              "timezone": "timezone"
            }
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/v1/practices/prac_01j2y8m6jcc9tt24af5pw9x1bc")
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

        var response = await Client.Practices.UpdatePracticeAsync(
            new UpdatePracticeRequest { PracticeId = "prac_01j2y8m6jcc9tt24af5pw9x1bc" }
        );
        JsonAssert.AreEqual(response, mockResponse);
    }
}
