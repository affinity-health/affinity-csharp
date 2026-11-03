using Affinity.Core;

namespace Affinity;

public partial interface IOrdersClient
{
    /// <summary>
    /// List accessible orders in the current mode, newest first. `externalOrderId` matches exactly, including case. `updatedAfter` accepts an ISO 8601 timestamp with a timezone and returns strictly later updates. Keep filters fixed while paging. `sort` takes `patient` (lowercase firstName + space + lastName A to Z, then order ID) or `created` (oldest first); a `_desc` suffix reverses. Creation time or patient name and the order ID determine cursor order, even when updatedAt changes.
    /// </summary>
    Task<Pager<Order>> ListAsync(
        ListOrdersRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// One request creates the order, signs it and sends it to the pharmacy. Platforms must send practiceId; practice callers can omit it to use their own practice. With an API key, name the prescriber and send signatureAttestation. Optional prescriber phone and address each default to the practice; no account is looked up by NPI. In the app, the signed-in member signs with the NPI in their settings, or names the prescriber with the same attestation. With patient.id (a pat_ ID) or patient.externalId, the order reuses that patient of the practice and mode and updates the saved record; without them, each order creates a new patient. If id and externalId identify different patients, the request returns 422 invalid_order. When the pharmacy already holds the patient's name, a different firstName or lastName returns 422 invalid_order. Live orders require Live access on the practice and its platform. No payment method is required.
    /// </summary>
    WithRawResponseTask<Order> CreateAsync(
        OrderInput request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Read one order and its prescriptions in the API key's organization and mode.
    /// </summary>
    WithRawResponseTask<Order> GetAsync(
        GetOrdersRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// 200 with status cancelled when the cancel is confirmed. 202 with cancelRequestedAt when the pharmacy has not confirmed yet: you get order.cancelled when it confirms, or, when it refuses, cancelRequestedAt becomes null and you get order.updated. If an earlier ask may have reached the pharmacy, a refusal keeps cancelRequestedAt and sends no event until the pharmacy ends the order (order.cancelled or order.shipped). 409 cannot_cancel when the order is shipped, delivered or failed. 409 cancel_refused when the pharmacy refused the cancel, or when Affinity could not reach the pharmacy; only the second says to retry with a new Idempotency-Key.
    /// </summary>
    WithRawResponseTask<Order> CancelAsync(
        CancelOrdersRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );
}
