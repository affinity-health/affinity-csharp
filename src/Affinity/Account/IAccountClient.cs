namespace Affinity;

public partial interface IAccountClient
{
    /// <summary>
    /// Returns the platform organization, request livemode, and effective access. API keys report scopes and the service_key role; dashboard sessions report membership permissions. operatingMode describes organization Live access, not the credential's Test/Live mode.
    /// </summary>
    WithRawResponseTask<GetAccountResponse> GetAccountAsync(
        GetAccountRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );
}
