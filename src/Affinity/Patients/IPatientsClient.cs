using Affinity.Patients;

namespace Affinity;

public partial interface IPatientsClient
{
    public IAddressesClient Addresses { get; }
    public IAllergiesClient Allergies { get; }

    /// <summary>
    /// Lists patients in one practice and mode. Use externalId for an exact match in the calling integration's namespace. Use externalIdentitySource with externalIdentityValue to search an explicit alias. Identity matching is case-sensitive after trimming whitespace. Other filters also apply.
    /// </summary>
    WithRawResponseTask<ListPatientsResponse> ListAsync(
        ListPatientsRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Creates a patient or resolves a matching externalId or external identity within this practice and mode. externalId belongs to the calling integration; externalIdentities holds aliases from other systems. Resolution preserves existing demographics; use PATCH to update them. Conflicting identifiers return 409. Email never merges patients. API keys require Idempotency-Key.
    /// </summary>
    WithRawResponseTask<CreatePatientResponse> CreateAsync(
        CreatePatientRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns one patient in the authorized practice and mode.
    /// </summary>
    WithRawResponseTask<GetPatientResponse> GetAsync(
        GetPatientsRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Requires patients:write and Idempotency-Key for API keys. Permanently deletes a patient with no order history. Any order history returns 409; use Update patient with status archived instead. Available to practice keys and authorized platform keys. Reusing the same idempotency key returns the original deletion result.
    /// </summary>
    WithRawResponseTask<DeletePatientResponse> DeleteAsync(
        DeletePatientsRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Updates a patient in the current practice and mode. Omitted fields remain unchanged; null clears an optional field. externalId updates the calling integration's identifier. externalIdentities replaces its explicit aliases. Identifiers cannot be reassigned from another patient. API keys require Idempotency-Key.
    /// </summary>
    WithRawResponseTask<UpdatePatientResponse> UpdateAsync(
        UpdatePatientRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );
}
