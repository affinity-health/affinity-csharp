namespace Affinity;

public partial interface ILocationsClient
{
    /// <summary>
    /// Requires locations:read on a practice key or an authorized platform key. Lists active and archived locations by name, with cursor pagination. Use status to filter. Location records are shared between Test and Live for the same practice.
    /// </summary>
    WithRawResponseTask<ListPracticeLocationsResponse> ListAsync(
        ListLocationsRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Requires locations:write and Idempotency-Key for API keys. Creates an active location with a unique name in this practice. Locations are shared between Test and Live. Use the returned ID for Team location access.
    /// </summary>
    WithRawResponseTask<CreatePracticeLocationResponse> CreateAsync(
        CreatePracticeLocationRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Requires locations:read. Returns one active or archived location in the authorized practice.
    /// </summary>
    WithRawResponseTask<GetPracticeLocationResponse> GetAsync(
        GetLocationsRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Requires locations:write and Idempotency-Key for API keys. Updates only supplied fields; null clears optional contact and address fields. Archived locations cannot be updated. Changes apply to both Test and Live.
    /// </summary>
    WithRawResponseTask<UpdatePracticeLocationResponse> UpdateAsync(
        UpdatePracticeLocationRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Requires locations:write and Idempotency-Key for API keys. Retains the location and historical associations. Archived locations cannot receive new Team assignments. Repeating archive returns the archived location. Changes apply to both Test and Live.
    /// </summary>
    WithRawResponseTask<ArchivePracticeLocationResponse> ArchiveAsync(
        ArchiveLocationsRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );
}
