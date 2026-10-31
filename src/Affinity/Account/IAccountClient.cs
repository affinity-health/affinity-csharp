namespace Affinity;

public partial interface IAccountClient
{
    /// <summary>
    /// Read the organization and Test or Live mode selected by the API key.
    /// </summary>
    WithRawResponseTask<Account> GetAsync(
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );
}
