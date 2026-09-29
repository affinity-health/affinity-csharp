using Affinity;

namespace Affinity.Team;

public partial interface IInvitationsClient
{
    /// <summary>
    /// Requires team:read. Lists practice invitations, including invitations sent in Clinic. Filter by pending, expired, accepted, declined, or revoked status, exact email, or your integration externalId. Only your integration and API key mode can see its external identity and onboarding state. Follow person.nextActions after invitation acceptance.
    /// </summary>
    WithRawResponseTask<ListPracticeTeamInvitationsResponse> ListAsync(
        ListInvitationsRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Requires team:write on the practice key or its platform key. Use roles to combine administrator, prescriber, clinical_staff, billing, or developer presets. Ownership uses the protected owner designation. The singular role field remains available for single-role assignments. Creates a real organization invitation and optional prescriber setup. The recipient must accept with their Affinity account. Repeating the same external identity retries pending invitation delivery. Accepted invitations do not change existing access. Team membership is shared between Test and Live; the external identity is mode-scoped. Keys cannot accept invitations. Headless registration and signing use separate endpoints.
    /// </summary>
    WithRawResponseTask<InvitePracticeTeamPersonResponse> CreateAsync(
        InvitePracticeTeamPersonRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Requires team:read. Returns invitation status and current onboarding state for your integration. An accepted invitation can still have disabled membership or pending clinical review. Invitation tokens are never returned.
    /// </summary>
    WithRawResponseTask<GetPracticeTeamInvitationResponse> GetAsync(
        GetInvitationsRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Requires team:write. Revokes a pending or expired invitation and its pending prescriber account connection. Repeating the revoke returns the revoked invitation. Accepted invitations return 409; disable the member instead. Retains invitation history.
    /// </summary>
    WithRawResponseTask<RevokePracticeTeamInvitationResponse> RevokeAsync(
        RevokeInvitationsRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Requires team:write. Resends a pending or expired invitation with the same ID, recipient, roles, and locations. The previous link stops working and the new link expires in seven days. Accepted and revoked invitations return 409. A 502 means the invitation was saved but email delivery could not be confirmed; retry this operation.
    /// </summary>
    WithRawResponseTask<ResendPracticeTeamInvitationResponse> ResendAsync(
        ResendInvitationsRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );
}
