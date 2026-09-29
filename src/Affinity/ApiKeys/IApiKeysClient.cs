namespace Affinity;

public partial interface IApiKeysClient
{
    /// <summary>
    /// Creates a practice API key for a connected practice. Requires a platform key with service_keys:write and every requested scope. The practice key uses the platform key's Test or Live mode and cannot outlive it. Requires Idempotency-Key for safe retries; the secret is returned in the encrypted replay response for 24 hours.
    /// </summary>
    WithRawResponseTask<CreatePlatformPracticeApiKeyResponse> CreatePlatformPracticeApiKeyAsync(
        CreatePlatformPracticeApiKeyRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns the subject, mode, and scopes for the API key.
    /// </summary>
    WithRawResponseTask<GetApiAccessResponse> GetApiAccessAsync(
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );
}
