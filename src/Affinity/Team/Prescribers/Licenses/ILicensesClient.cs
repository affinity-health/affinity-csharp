using Affinity;

namespace Affinity.Team.Prescribers;

public partial interface ILicensesClient
{
    /// <summary>
    /// Requires team:write and an active accepted prescriber account connection in this practice. Adds a license. Expiration is optional, but must be in the future when supplied. An exact repeat returns the existing license; update an existing license with PATCH and its license ID. Licenses are shared across practices and Test/Live. Other licenses stay unchanged.
    /// </summary>
    WithRawResponseTask<CreatePracticeTeamLicenseResponse> CreateAsync(
        CreatePracticeTeamLicenseRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Requires team:write and an active accepted prescriber account connection in this practice. Correct the state or license number, or set or clear the optional expiresAt value. A supplied expiration must be in the future. Other licenses stay unchanged. Changes apply across practices and Test/Live.
    /// </summary>
    WithRawResponseTask<UpdatePracticeTeamLicenseResponse> UpdateAsync(
        UpdatePracticeTeamLicenseRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );
}
