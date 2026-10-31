using Affinity.Core;

namespace Affinity;

public partial interface IPracticesClient
{
    /// <summary>
    /// List the platform's practices, newest first. Available to platforms only. `sort` takes `name` or `location` (A to Z, practices without a location last), `mode` (Test before Live) or `created` (oldest first); a leading `-` reverses.
    /// </summary>
    Task<Pager<Practice>> ListAsync(
        ListPracticesRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Platforms only. Name, phone and address are required. The practice starts in Test; `liveEnabled: true` also allows new Live orders, which needs a platform with Live access and a Live caller: a Live key, or a session in Live mode. Turning Live off later preserves access to existing records. A retry with the same key and body returns the stored first response, even if the practice has changed. Use GET /v1/practices/{practiceId} to read the current practice.
    /// </summary>
    WithRawResponseTask<Practice> CreateAsync(
        CreatePracticesRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Read one practice accessible to the API key. A platform can read its own practices.
    /// </summary>
    WithRawResponseTask<Practice> GetAsync(
        GetPracticesRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// `liveEnabled` allows or refuses new Live orders. Existing records, cancellation, webhooks and billing keep working. Only its platform changes it; enabling requires platform Live access, and either change needs a Live caller: a Live key (403 live_key_required otherwise) or a session in Live mode (403 live_mode_required otherwise). Live orders send `name`, `phone` and `address` to the pharmacy, so a practice with Live access changes them only with a Live key (403 live_mode_required otherwise). A retry with the same key and body returns the stored first response, even if the practice has changed. Use GET /v1/practices/{practiceId} to read the current practice.
    /// </summary>
    WithRawResponseTask<Practice> UpdateAsync(
        UpdatePracticesRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );
}
