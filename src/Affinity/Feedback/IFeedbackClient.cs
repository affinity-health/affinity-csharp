namespace Affinity;

public partial interface IFeedbackClient
{
    /// <summary>
    /// Send feedback without credentials, or with an API key to include its organization and mode. Do not include patient information. API-key callers are limited to 10 submissions per hour per key. Anonymous callers are limited to 10 submissions per hour per IP address. A 429 response includes Retry-After in seconds.
    /// </summary>
    WithRawResponseTask<CreateFeedbackResponse> CreateAsync(
        CreateFeedbackRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );
}
