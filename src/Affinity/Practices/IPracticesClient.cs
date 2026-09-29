namespace Affinity;

public partial interface IPracticesClient
{
    /// <summary>
    /// Returns the practices that belong to the platform. The default Affinity-Version is 2026-09-28.
    /// </summary>
    WithRawResponseTask<ListPracticesResponse> ListAsync(
        ListPracticesRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Creates a practice owned by the platform. Set liveEnabled to true to enable Live access at creation with an approved platform and a Live request. Defaults to false. Requires practices:write. Send Idempotency-Key when you retry the same request.
    /// </summary>
    WithRawResponseTask<CreatePracticeResponse> CreateAsync(
        CreatePracticeRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns one practice that belongs to the platform.
    /// </summary>
    WithRawResponseTask<GetPracticeResponse> GetAsync(
        GetPracticesRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Updates one practice owned by the platform. Set liveEnabled to true or false to control Live access with an approved platform and a Live request. Affinity Admin decisions take precedence. Requires practices:write. Send Idempotency-Key when you retry the same request.
    /// </summary>
    WithRawResponseTask<UpdatePracticeResponse> UpdateAsync(
        UpdatePracticeRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );
}
