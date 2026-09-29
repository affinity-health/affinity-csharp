using Affinity;

namespace Affinity.Patients;

public partial interface IAddressesClient
{
    WithRawResponseTask<ListPatientAddressesResponse> ListAsync(
        ListAddressesRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns the existing active address for a normalized duplicate. The first address becomes the default. API keys require Idempotency-Key.
    /// </summary>
    WithRawResponseTask<CreatePatientAddressResponse> CreateAsync(
        CreatePatientAddressRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Preserves the address ID and history. Archiving the default selects the oldest remaining active address. Existing orders remain unchanged.
    /// </summary>
    WithRawResponseTask<ArchivePatientAddressResponse> ArchiveAsync(
        ArchiveAddressesRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    WithRawResponseTask<UpdatePatientAddressResponse> UpdateAsync(
        UpdatePatientAddressRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Changes delivery selection for future drafts, without changing patient clinical location or existing signed orders.
    /// </summary>
    WithRawResponseTask<SetDefaultPatientAddressResponse> SetDefaultAsync(
        SetDefaultAddressesRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );
}
