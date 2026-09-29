namespace Affinity;

public partial interface IPatientsClient
{
    WithRawResponseTask<ListPatientAddressesResponse> ListPatientAddressesAsync(
        ListPatientAddressesRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns the existing active address for a normalized duplicate. The first address becomes the default. API keys require Idempotency-Key.
    /// </summary>
    WithRawResponseTask<CreatePatientAddressResponse> CreatePatientAddressAsync(
        CreatePatientAddressRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Preserves the address ID and history. Archiving the default selects the oldest remaining active address. Existing orders remain unchanged.
    /// </summary>
    WithRawResponseTask<ArchivePatientAddressResponse> ArchivePatientAddressAsync(
        ArchivePatientAddressRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    WithRawResponseTask<UpdatePatientAddressResponse> UpdatePatientAddressAsync(
        UpdatePatientAddressRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Changes delivery selection for future drafts, without changing patient clinical location or existing signed orders.
    /// </summary>
    WithRawResponseTask<SetDefaultPatientAddressResponse> SetDefaultPatientAddressAsync(
        SetDefaultPatientAddressRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Lists patients in one practice and mode. Use externalId for an exact match in the calling integration's namespace. Use externalIdentitySource with externalIdentityValue to search an explicit alias. Identity matching is case-sensitive after trimming whitespace. Other filters also apply.
    /// </summary>
    WithRawResponseTask<ListPatientsResponse> ListPatientsAsync(
        ListPatientsRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Creates a patient or resolves a matching externalId or external identity within this practice and mode. externalId belongs to the calling integration; externalIdentities holds aliases from other systems. Resolution preserves existing demographics; use PATCH to update them. Conflicting identifiers return 409. Email never merges patients. API keys require Idempotency-Key.
    /// </summary>
    WithRawResponseTask<CreatePatientResponse> CreatePatientAsync(
        CreatePatientRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns one patient in the authorized practice and mode.
    /// </summary>
    WithRawResponseTask<GetPatientResponse> GetPatientAsync(
        GetPatientRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Requires patients:write and Idempotency-Key for API keys. Permanently deletes a patient with no order history. Any order history returns 409; use Update patient with status archived instead. Available to practice keys and authorized platform keys. Reusing the same idempotency key returns the original deletion result.
    /// </summary>
    WithRawResponseTask<DeletePatientResponse> DeletePatientAsync(
        DeletePatientRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Updates a patient in the current practice and mode. Omitted fields remain unchanged; null clears an optional field. externalId updates the calling integration's identifier. externalIdentities replaces its explicit aliases. Identifiers cannot be reassigned from another patient. API keys require Idempotency-Key.
    /// </summary>
    WithRawResponseTask<UpdatePatientResponse> UpdatePatientAsync(
        UpdatePatientRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns the patient's structured allergy entries and review status. A not_reviewed status is not a no-known-allergies assertion and blocks clinical review and signing.
    /// </summary>
    WithRawResponseTask<GetPatientAllergiesResponse> GetPatientAllergiesAsync(
        GetPatientAllergiesRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Replaces the patient's structured allergy record. Sending no_known is the explicit no-known-allergies acknowledgement; recorded requires at least one entry. Idempotency-Key is required.
    /// </summary>
    WithRawResponseTask<ReplacePatientAllergiesResponse> ReplacePatientAllergiesAsync(
        ReplacePatientAllergiesRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );
}
