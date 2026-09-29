using Affinity;
using Affinity.Team.Prescribers;

namespace Affinity.Team;

public partial interface IPrescribersClient
{
    public ILicensesClient Licenses { get; }

    /// <summary>
    /// Requires team:read. Filter practice prescribers by name, NPI, state, and practice status. Records include submitted licenses and their IDs. Signing authority also requires an active account connection, Live practice access, and prescription eligibility.
    /// </summary>
    WithRawResponseTask<ListPracticeTeamPrescribersResponse> ListAsync(
        ListPrescribersRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Requires team:read. Returns the clinical profile and submitted licenses, including license IDs. This is setup information, not a signing authorization.
    /// </summary>
    WithRawResponseTask<GetPracticeTeamPrescriberResponse> GetAsync(
        GetPrescribersRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Requires team:write. Set practiceStatus to inactive to remove prescribing access in this practice, or active to restore an existing association. This does not create membership or signing authority. Practice status applies to Test and Live. Shared identity and license edits require Affinity support.
    /// </summary>
    WithRawResponseTask<UpdatePracticeTeamPrescriberResponse> UpdateAsync(
        UpdatePracticeTeamPrescriberRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );
}
