using Affinity.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Affinity;

[JsonConverter(
    typeof(UpdateWebhookEndpointRequestSubscribedEventsItem.UpdateWebhookEndpointRequestSubscribedEventsItemSerializer)
)]
[Serializable]
public readonly record struct UpdateWebhookEndpointRequestSubscribedEventsItem : IStringEnum
{
    public static readonly UpdateWebhookEndpointRequestSubscribedEventsItem WebhookEndpointTest =
        new(Values.WebhookEndpointTest);

    public static readonly UpdateWebhookEndpointRequestSubscribedEventsItem CancellationRequested =
        new(Values.CancellationRequested);

    public static readonly UpdateWebhookEndpointRequestSubscribedEventsItem CancellationSent = new(
        Values.CancellationSent
    );

    public static readonly UpdateWebhookEndpointRequestSubscribedEventsItem CancellationConfirmed =
        new(Values.CancellationConfirmed);

    public static readonly UpdateWebhookEndpointRequestSubscribedEventsItem CancellationRejected =
        new(Values.CancellationRejected);

    public static readonly UpdateWebhookEndpointRequestSubscribedEventsItem CancellationFailed =
        new(Values.CancellationFailed);

    public static readonly UpdateWebhookEndpointRequestSubscribedEventsItem CancellationTooLate =
        new(Values.CancellationTooLate);

    public static readonly UpdateWebhookEndpointRequestSubscribedEventsItem OrderCreated = new(
        Values.OrderCreated
    );

    public static readonly UpdateWebhookEndpointRequestSubscribedEventsItem OrderUpdated = new(
        Values.OrderUpdated
    );

    public static readonly UpdateWebhookEndpointRequestSubscribedEventsItem OrderReviewRequested =
        new(Values.OrderReviewRequested);

    public static readonly UpdateWebhookEndpointRequestSubscribedEventsItem OrderChangesRequested =
        new(Values.OrderChangesRequested);

    public static readonly UpdateWebhookEndpointRequestSubscribedEventsItem OrderSigned = new(
        Values.OrderSigned
    );

    public static readonly UpdateWebhookEndpointRequestSubscribedEventsItem OrderRejected = new(
        Values.OrderRejected
    );

    public static readonly UpdateWebhookEndpointRequestSubscribedEventsItem OrderSubmitted = new(
        Values.OrderSubmitted
    );

    public static readonly UpdateWebhookEndpointRequestSubscribedEventsItem OrderAccepted = new(
        Values.OrderAccepted
    );

    public static readonly UpdateWebhookEndpointRequestSubscribedEventsItem OrderProcessing = new(
        Values.OrderProcessing
    );

    public static readonly UpdateWebhookEndpointRequestSubscribedEventsItem OrderShipped = new(
        Values.OrderShipped
    );

    public static readonly UpdateWebhookEndpointRequestSubscribedEventsItem OrderDelivered = new(
        Values.OrderDelivered
    );

    public static readonly UpdateWebhookEndpointRequestSubscribedEventsItem OrderBlocked = new(
        Values.OrderBlocked
    );

    public static readonly UpdateWebhookEndpointRequestSubscribedEventsItem OrderCancelled = new(
        Values.OrderCancelled
    );

    public UpdateWebhookEndpointRequestSubscribedEventsItem(string value)
    {
        Value = value;
    }

    /// <summary>
    /// The string value of the enum.
    /// </summary>
    public string Value { get; }

    /// <summary>
    /// Create a string enum with the given value.
    /// </summary>
    public static UpdateWebhookEndpointRequestSubscribedEventsItem FromCustom(string value)
    {
        return new UpdateWebhookEndpointRequestSubscribedEventsItem(value);
    }

    public bool Equals(string? other)
    {
        return Value.Equals(other);
    }

    /// <summary>
    /// Returns the string value of the enum.
    /// </summary>
    public override string ToString()
    {
        return Value;
    }

    public static bool operator ==(
        UpdateWebhookEndpointRequestSubscribedEventsItem value1,
        string value2
    ) => value1.Value.Equals(value2);

    public static bool operator !=(
        UpdateWebhookEndpointRequestSubscribedEventsItem value1,
        string value2
    ) => !value1.Value.Equals(value2);

    public static explicit operator string(
        UpdateWebhookEndpointRequestSubscribedEventsItem value
    ) => value.Value;

    public static explicit operator UpdateWebhookEndpointRequestSubscribedEventsItem(
        string value
    ) => new(value);

    internal class UpdateWebhookEndpointRequestSubscribedEventsItemSerializer
        : JsonConverter<UpdateWebhookEndpointRequestSubscribedEventsItem>
    {
        public override UpdateWebhookEndpointRequestSubscribedEventsItem Read(
            ref Utf8JsonReader reader,
            Type typeToConvert,
            JsonSerializerOptions options
        )
        {
            var stringValue =
                reader.GetString()
                ?? throw new global::System.Exception(
                    "The JSON value could not be read as a string."
                );
            return new UpdateWebhookEndpointRequestSubscribedEventsItem(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            UpdateWebhookEndpointRequestSubscribedEventsItem value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override UpdateWebhookEndpointRequestSubscribedEventsItem ReadAsPropertyName(
            ref Utf8JsonReader reader,
            Type typeToConvert,
            JsonSerializerOptions options
        )
        {
            var stringValue =
                reader.GetString()
                ?? throw new global::System.Exception(
                    "The JSON property name could not be read as a string."
                );
            return new UpdateWebhookEndpointRequestSubscribedEventsItem(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            UpdateWebhookEndpointRequestSubscribedEventsItem value,
            JsonSerializerOptions options
        )
        {
            writer.WritePropertyName(value.Value);
        }
    }

    /// <summary>
    /// Constant strings for enum values
    /// </summary>
    [Serializable]
    public static class Values
    {
        public const string WebhookEndpointTest = "webhook_endpoint.test";

        public const string CancellationRequested = "cancellation.requested";

        public const string CancellationSent = "cancellation.sent";

        public const string CancellationConfirmed = "cancellation.confirmed";

        public const string CancellationRejected = "cancellation.rejected";

        public const string CancellationFailed = "cancellation.failed";

        public const string CancellationTooLate = "cancellation.too_late";

        public const string OrderCreated = "order.created";

        public const string OrderUpdated = "order.updated";

        public const string OrderReviewRequested = "order.review_requested";

        public const string OrderChangesRequested = "order.changes_requested";

        public const string OrderSigned = "order.signed";

        public const string OrderRejected = "order.rejected";

        public const string OrderSubmitted = "order.submitted";

        public const string OrderAccepted = "order.accepted";

        public const string OrderProcessing = "order.processing";

        public const string OrderShipped = "order.shipped";

        public const string OrderDelivered = "order.delivered";

        public const string OrderBlocked = "order.blocked";

        public const string OrderCancelled = "order.cancelled";
    }
}
