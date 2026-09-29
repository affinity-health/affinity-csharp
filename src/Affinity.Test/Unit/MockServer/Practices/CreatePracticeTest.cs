using Affinity;
using Affinity.Test.Unit.MockServer;
using Affinity.Test.Utils;
using NUnit.Framework;

namespace Affinity.Test.Unit.MockServer.Practices;

[TestFixture]
[Parallelizable(ParallelScope.Self)]
public class CreatePracticeTest : BaseMockServerTest
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
              },
              "attestations": {
                "authorizedPracticeRelationship": true,
                "authorizedPhiTransfer": true,
                "minimumNecessaryPhi": true,
                "providerDataAccuracy": true
              },
              "name": "name"
            }
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
                    .WithPath("/v1/practices")
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

        var response = await Client.Practices.CreatePracticeAsync(
            new CreatePracticeRequest
            {
                LiveEnabled = null,
                Address = new CreatePracticeRequestAddress
                {
                    City = "city",
                    Country = null,
                    Line1 = "line1",
                    Line2 = null,
                    PostalCode = "postalCode",
                    State = "state",
                },
                Attestations = new CreatePracticeRequestAttestations
                {
                    AuthorizedPracticeRelationship = true,
                    AuthorizedPhiTransfer = true,
                    MinimumNecessaryPhi = true,
                    ProviderDataAccuracy = true,
                },
                ComplianceContact = null,
                ExternalId = null,
                LegalName = null,
                Metadata = null,
                Name = "name",
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
            {
              "address": {
                "city": "Los Angeles",
                "country": "US",
                "line1": "100 Practice Way",
                "postalCode": "90001",
                "state": "CA"
              },
              "attestations": {
                "authorizedPracticeRelationship": true,
                "authorizedPhiTransfer": true,
                "minimumNecessaryPhi": true,
                "providerDataAccuracy": true
              },
              "externalId": "practice_123",
              "legalName": "Example Medical Group PLLC",
              "metadata": {
                "key": "value"
              },
              "name": "Example Medical Group",
              "prescribers": [
                {
                  "credentials": "MD",
                  "licenseStates": [
                    "CA"
                  ],
                  "name": "Alex Morgan",
                  "npi": "1234567893"
                }
              ],
              "primaryContact": {
                "email": "operations@example-practice.com",
                "name": "Jordan Lee"
              },
              "supportEmail": "support@example-practice.com"
            }
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
                    .WithPath("/v1/practices")
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

        var response = await Client.Practices.CreatePracticeAsync(
            new CreatePracticeRequest
            {
                Address = new CreatePracticeRequestAddress
                {
                    City = "Los Angeles",
                    Country = "US",
                    Line1 = "100 Practice Way",
                    PostalCode = "90001",
                    State = "CA",
                },
                Attestations = new CreatePracticeRequestAttestations
                {
                    AuthorizedPracticeRelationship = true,
                    AuthorizedPhiTransfer = true,
                    MinimumNecessaryPhi = true,
                    ProviderDataAccuracy = true,
                },
                ExternalId = "practice_123",
                LegalName = "Example Medical Group PLLC",
                Metadata = new Dictionary<string, object?>() { { "key", "value" } },
                Name = "Example Medical Group",
                Prescribers = new List<CreatePracticeRequestPrescribersItem>()
                {
                    new CreatePracticeRequestPrescribersItem
                    {
                        Credentials = "MD",
                        LicenseStates = new List<string>() { "CA" },
                        Name = "Alex Morgan",
                        Npi = "1234567893",
                    },
                },
                PrimaryContact = new CreatePracticeRequestPrimaryContact
                {
                    Email = "operations@example-practice.com",
                    Name = "Jordan Lee",
                },
                SupportEmail = "support@example-practice.com",
            }
        );
        JsonAssert.AreEqual(response, mockResponse);
    }
}
