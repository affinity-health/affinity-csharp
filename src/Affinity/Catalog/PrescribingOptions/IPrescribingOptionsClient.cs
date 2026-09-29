using Affinity;

namespace Affinity.Catalog;

public partial interface IPrescribingOptionsClient
{
    /// <summary>
    /// Requires catalog:read. Returns reviewed SIG presets, guided patterns, quantity constraints and product requirements for a practice and mode. Revisions identify changed defaults. No patient-specific rationale or diagnosis is inferred.
    /// </summary>
    WithRawResponseTask<RetrievePrescribingOptionsResponse> GetAsync(
        GetPrescribingOptionsRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );
}
