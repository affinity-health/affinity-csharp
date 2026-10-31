using Affinity;
using Affinity.Test.Unit.MockServer;
using Affinity.Test.Utils;
using NUnit.Framework;

namespace Affinity.Test.Unit.MockServer.Feedback;

[TestFixture]
[Parallelizable(ParallelScope.Self)]
public class CreateTest : BaseMockServerTest
{
    [NUnit.Framework.Test]
    public async Task MockServerTest_1()
    {
        const string requestJson = """
            {
              "message": "message"
            }
            """;

        const string mockResponse = """
            {
              "id": "id"
            }
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/v1/feedback")
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

        var response = await Client.Feedback.CreateAsync(
            new CreateFeedbackRequest
            {
                IdempotencyKey = "idempotencyKey",
                Message = "message",
                PageUrl = null,
                RequestId = null,
            }
        );
        JsonAssert.AreEqual(response, mockResponse);
    }

    [NUnit.Framework.Test]
    public async Task MockServerTest_2()
    {
        const string requestJson = """
            {
              "message": "The error does not explain which field is invalid.",
              "pageUrl": "https://docs.affinityrx.com/errors/",
              "requestId": "6e562761-eff3-4626-a8b9-25ce7c670ccd"
            }
            """;

        const string mockResponse = """
            {
              "id": "fbk_01j2y8m6jcc9tt24af5pw9x1bc"
            }
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/v1/feedback")
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

        var response = await Client.Feedback.CreateAsync(
            new CreateFeedbackRequest
            {
                IdempotencyKey = "Idempotency-Key",
                Message = "The error does not explain which field is invalid.",
                PageUrl = "https://docs.affinityrx.com/errors/",
                RequestId = "6e562761-eff3-4626-a8b9-25ce7c670ccd",
            }
        );
        JsonAssert.AreEqual(response, mockResponse);
    }
}
