using Affinity;

namespace Affinity.Team;

public partial interface IMembersClient
{
    /// <summary>
    /// Requires team:read. Search the roster by name or email, and filter by role or membership status. Includes members invited in Clinic, location access, and account-specific prescriber connections. Memberships are shared between Test and Live.
    /// </summary>
    WithRawResponseTask<ListPracticeTeamMembersResponse> ListAsync(
        ListMembersRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Requires team:read. Returns current account membership, roles, location access, and prescriber connection. The member ID identifies practice access; it is not the integration user ID used by orders.
    /// </summary>
    WithRawResponseTask<GetPracticeTeamMemberResponse> GetAsync(
        GetMembersRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Requires team:write. Supply role, status, or locationIds; omitted values stay unchanged. A role replaces existing roles. Disable access with status disabled. An empty locationIds array grants all practice locations. Ownership changes require an active practice owner using a personal API key; service keys manage non-owner memberships. The final active owner cannot be removed. Changes apply to both Test and Live. Sign-in email and account security remain account settings.
    /// </summary>
    WithRawResponseTask<UpdatePracticeTeamMemberResponse> UpdateAsync(
        UpdatePracticeTeamMemberRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );
}
