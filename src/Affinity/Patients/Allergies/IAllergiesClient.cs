using Affinity;

namespace Affinity.Patients;

public partial interface IAllergiesClient
{
    /// <summary>
    /// Returns the patient's structured allergy entries and review status. A not_reviewed status is not a no-known-allergies assertion and blocks clinical review and signing.
    /// </summary>
    WithRawResponseTask<GetPatientAllergiesResponse> GetAsync(
        GetAllergiesRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Replaces the patient's structured allergy record. Sending no_known is the explicit no-known-allergies acknowledgement; recorded requires at least one entry. Idempotency-Key is required.
    /// </summary>
    WithRawResponseTask<ReplacePatientAllergiesResponse> ReplaceAsync(
        ReplacePatientAllergiesRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );
}
