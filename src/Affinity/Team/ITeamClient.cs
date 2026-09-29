using Affinity.Team;

namespace Affinity;

public partial interface ITeamClient
{
    public IInvitationsClient Invitations { get; }
    public IMembersClient Members { get; }
    public IPrescribersClient Prescribers { get; }

    /// <summary>
    /// Requires team:write and Idempotency-Key. Registers a practice member without an invitation. Test requires synthetic .test emails and Affinity Test NPIs. Live requires approved integration and practice access. Identity attestation records the integration's assertion; it does not verify login email or clinical credentials. Existing memberships and verified provider records are preserved. Use the returned user ID for orders and signing.
    /// </summary>
    WithRawResponseTask<RegisterUserResponse> RegisterAsync(
        RegisterUserRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Requires team:read. Returns counts of members, invitations, and prescribers. Use the paginated members, prescribers, and invitations collections for individual records. Team access and clinician credentials are shared between Test and Live.
    /// </summary>
    WithRawResponseTask<GetPracticeTeamResponse> GetAsync(
        GetTeamRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );
}
