namespace Affinity;

public partial interface ITeamClient
{
    /// <summary>
    /// Requires team:write and Idempotency-Key. Registers a practice member without an invitation. Test requires synthetic .test emails and Affinity Test NPIs. Live requires approved integration and practice access. Identity attestation records the integration's assertion; it does not verify login email or clinical credentials. Existing memberships and verified provider records are preserved. Use the returned user ID for orders and signing.
    /// </summary>
    WithRawResponseTask<RegisterUserResponse> RegisterUserAsync(
        RegisterUserRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Requires team:read. Lists practice invitations, including invitations sent in Clinic. Filter by pending, expired, accepted, declined, or revoked status, exact email, or your integration externalId. Only your integration and API key mode can see its external identity and onboarding state. Follow person.nextActions after invitation acceptance.
    /// </summary>
    WithRawResponseTask<ListPracticeTeamInvitationsResponse> ListPracticeTeamInvitationsAsync(
        ListPracticeTeamInvitationsRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Requires team:write on the practice key or its platform key. Use roles to combine administrator, prescriber, clinical_staff, billing, or developer presets. Ownership uses the protected owner designation. The singular role field remains available for single-role assignments. Creates a real organization invitation and optional prescriber setup. The recipient must accept with their Affinity account. Repeating the same external identity retries pending invitation delivery. Accepted invitations do not change existing access. Team membership is shared between Test and Live; the external identity is mode-scoped. Keys cannot accept invitations. Headless registration and signing use separate endpoints.
    /// </summary>
    WithRawResponseTask<InvitePracticeTeamPersonResponse> InvitePracticeTeamPersonAsync(
        InvitePracticeTeamPersonRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Requires team:read. Returns counts of members, invitations, and prescribers. Use the paginated members, prescribers, and invitations collections for individual records. Team access and clinician credentials are shared between Test and Live.
    /// </summary>
    WithRawResponseTask<GetPracticeTeamResponse> GetPracticeTeamAsync(
        GetPracticeTeamRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Requires team:read. Search the roster by name or email, and filter by role or membership status. Includes members invited in Clinic, location access, and account-specific prescriber connections. Memberships are shared between Test and Live.
    /// </summary>
    WithRawResponseTask<ListPracticeTeamMembersResponse> ListPracticeTeamMembersAsync(
        ListPracticeTeamMembersRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Requires team:read. Filter practice prescribers by name, NPI, state, and practice status. Records include submitted licenses and their IDs. Signing authority also requires an active account connection, Live practice access, and prescription eligibility.
    /// </summary>
    WithRawResponseTask<ListPracticeTeamPrescribersResponse> ListPracticeTeamPrescribersAsync(
        ListPracticeTeamPrescribersRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Requires team:read. Returns current account membership, roles, location access, and prescriber connection. The member ID identifies practice access; it is not the integration user ID used by orders.
    /// </summary>
    WithRawResponseTask<GetPracticeTeamMemberResponse> GetPracticeTeamMemberAsync(
        GetPracticeTeamMemberRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Requires team:write. Supply role, status, or locationIds; omitted values stay unchanged. A role replaces existing roles. Disable access with status disabled. An empty locationIds array grants all practice locations. Ownership changes require an active practice owner using a personal API key; service keys manage non-owner memberships. The final active owner cannot be removed. Changes apply to both Test and Live. Sign-in email and account security remain account settings.
    /// </summary>
    WithRawResponseTask<UpdatePracticeTeamMemberResponse> UpdatePracticeTeamMemberAsync(
        UpdatePracticeTeamMemberRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Requires team:read. Returns the clinical profile and submitted licenses, including license IDs. This is setup information, not a signing authorization.
    /// </summary>
    WithRawResponseTask<GetPracticeTeamPrescriberResponse> GetPracticeTeamPrescriberAsync(
        GetPracticeTeamPrescriberRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Requires team:write. Set practiceStatus to inactive to remove prescribing access in this practice, or active to restore an existing association. This does not create membership or signing authority. Practice status applies to Test and Live. Shared identity and license edits require Affinity support.
    /// </summary>
    WithRawResponseTask<UpdatePracticeTeamPrescriberResponse> UpdatePracticeTeamPrescriberAsync(
        UpdatePracticeTeamPrescriberRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Requires team:write and an active accepted prescriber account connection in this practice. Adds a license. Expiration is optional, but must be in the future when supplied. An exact repeat returns the existing license; update an existing license with PATCH and its license ID. Licenses are shared across practices and Test/Live. Other licenses stay unchanged.
    /// </summary>
    WithRawResponseTask<CreatePracticeTeamLicenseResponse> CreatePracticeTeamLicenseAsync(
        CreatePracticeTeamLicenseRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Requires team:write and an active accepted prescriber account connection in this practice. Correct the state or license number, or set or clear the optional expiresAt value. A supplied expiration must be in the future. Other licenses stay unchanged. Changes apply across practices and Test/Live.
    /// </summary>
    WithRawResponseTask<UpdatePracticeTeamLicenseResponse> UpdatePracticeTeamLicenseAsync(
        UpdatePracticeTeamLicenseRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Requires team:read. Returns invitation status and current onboarding state for your integration. An accepted invitation can still have disabled membership or pending clinical review. Invitation tokens are never returned.
    /// </summary>
    WithRawResponseTask<GetPracticeTeamInvitationResponse> GetPracticeTeamInvitationAsync(
        GetPracticeTeamInvitationRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Requires team:write. Revokes a pending or expired invitation and its pending prescriber account connection. Repeating the revoke returns the revoked invitation. Accepted invitations return 409; disable the member instead. Retains invitation history.
    /// </summary>
    WithRawResponseTask<RevokePracticeTeamInvitationResponse> RevokePracticeTeamInvitationAsync(
        RevokePracticeTeamInvitationRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Requires team:write. Resends a pending or expired invitation with the same ID, recipient, roles, and locations. The previous link stops working and the new link expires in seven days. Accepted and revoked invitations return 409. A 502 means the invitation was saved but email delivery could not be confirmed; retry this operation.
    /// </summary>
    WithRawResponseTask<ResendPracticeTeamInvitationResponse> ResendPracticeTeamInvitationAsync(
        ResendPracticeTeamInvitationRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );
}
