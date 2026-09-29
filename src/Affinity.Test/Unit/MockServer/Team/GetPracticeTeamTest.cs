using Affinity;
using Affinity.Test.Unit.MockServer;
using Affinity.Test.Utils;
using NUnit.Framework;

namespace Affinity.Test.Unit.MockServer.Team;

[TestFixture]
[Parallelizable(ParallelScope.Self)]
public class GetPracticeTeamTest : BaseMockServerTest
{
    [NUnit.Framework.Test]
    public async Task MockServerTest_1()
    {
        const string mockResponse = """
            {
              "object": "team",
              "practiceId": "practiceId",
              "members": {
                "total": "Infinity",
                "active": "Infinity",
                "disabled": "Infinity"
              },
              "invitations": {
                "pending": "Infinity",
                "expired": "Infinity"
              },
              "prescribers": {
                "total": "Infinity",
                "active": "Infinity"
              }
            }
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/v1/practices/practiceId/team")
                    .UsingGet()
            )
            .RespondWith(
                WireMock
                    .ResponseBuilders.Response.Create()
                    .WithStatusCode(200)
                    .WithBody(mockResponse)
            );

        var response = await Client.Team.GetPracticeTeamAsync(
            new GetPracticeTeamRequest { PracticeId = "practiceId" }
        );
        JsonAssert.AreEqual(response, mockResponse);
    }

    [NUnit.Framework.Test]
    public async Task MockServerTest_2()
    {
        const string mockResponse = """
            {
              "object": "team",
              "practiceId": "prac_01j2y8m6jcc9tt24af5pw9x1bc",
              "members": {
                "total": "Infinity",
                "active": "Infinity",
                "disabled": "Infinity"
              },
              "invitations": {
                "pending": "Infinity",
                "expired": "Infinity"
              },
              "prescribers": {
                "total": "Infinity",
                "active": "Infinity"
              }
            }
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/v1/practices/prac_01j2y8m6jcc9tt24af5pw9x1bc/team")
                    .UsingGet()
            )
            .RespondWith(
                WireMock
                    .ResponseBuilders.Response.Create()
                    .WithStatusCode(200)
                    .WithBody(mockResponse)
            );

        var response = await Client.Team.GetPracticeTeamAsync(
            new GetPracticeTeamRequest { PracticeId = "prac_01j2y8m6jcc9tt24af5pw9x1bc" }
        );
        JsonAssert.AreEqual(response, mockResponse);
    }
}
