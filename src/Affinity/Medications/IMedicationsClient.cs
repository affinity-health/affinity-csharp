using Affinity.Core;

namespace Affinity;

public partial interface IMedicationsClient
{
    /// <summary>
    /// Every medication you can order in the current mode, A to Z by name, then by ID. The list has no text search: read every page and choose by name, strength, form and pharmacy. Send practiceId to list what that practice can order, at its prices; without it, the caller's organization is used. Prices are in cents. `requirements` names the optional prescription fields this pharmacy requires; `compoundingReasons` and `quantities` list the accepted values when the pharmacy limits them, counted in `quantityUnit`. With a `fill`, `price` is per fill and each quantity counts `quantityUnit`, not fills: it is a whole number of fills in units. For a fill of 30 tablets, quantity 60 is two fills. For vials, quantity 1 is one vial and quantity 2 is two vials. A 2 mL vial lists quantities 1–10; its volume is separate from its quantity.
    /// </summary>
    Task<Pager<Medication>> ListAsync(
        ListMedicationsRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Read one available medication, its pricing, and pharmacy details for the current organization and mode. Pass expand=variants to include its other strengths, forms and pharmacies.
    /// </summary>
    WithRawResponseTask<GetMedicationsResponse> GetAsync(
        GetMedicationsRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );
}
