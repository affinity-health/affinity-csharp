using Affinity.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Affinity;

[JsonConverter(
    typeof(CreateWebhookEndpointRequestSubscribedEventsItem.CreateWebhookEndpointRequestSubscribedEventsItemSerializer)
)]
[Serializable]
public readonly record struct CreateWebhookEndpointRequestSubscribedEventsItem : IStringEnum
{
    public static readonly CreateWebhookEndpointRequestSubscribedEventsItem WebhookEndpointTest =
        new(Values.WebhookEndpointTest);

    public static readonly CreateWebhookEndpointRequestSubscribedEventsItem CancellationRequested =
        new(Values.CancellationRequested);

    public static readonly CreateWebhookEndpointRequestSubscribedEventsItem CancellationSent = new(
        Values.CancellationSent
    );

    public static readonly CreateWebhookEndpointRequestSubscribedEventsItem CancellationConfirmed =
        new(Values.CancellationConfirmed);

    public static readonly CreateWebhookEndpointRequestSubscribedEventsItem CancellationRejected =
        new(Values.CancellationRejected);

    public static readonly CreateWebhookEndpointRequestSubscribedEventsItem CancellationFailed =
        new(Values.CancellationFailed);

    public static readonly CreateWebhookEndpointRequestSubscribedEventsItem CancellationTooLate =
        new(Values.CancellationTooLate);

    public static readonly CreateWebhookEndpointRequestSubscribedEventsItem OrderCreated = new(
        Values.OrderCreated
    );

    public static readonly CreateWebhookEndpointRequestSubscribedEventsItem OrderUpdated = new(
        Values.OrderUpdated
    );

    public static readonly CreateWebhookEndpointRequestSubscribedEventsItem OrderReviewRequested =
        new(Values.OrderReviewRequested);

    public static readonly CreateWebhookEndpointRequestSubscribedEventsItem OrderChangesRequested =
        new(Values.OrderChangesRequested);

    public static readonly CreateWebhookEndpointRequestSubscribedEventsItem OrderSigned = new(
        Values.OrderSigned
    );

    public static readonly CreateWebhookEndpointRequestSubscribedEventsItem OrderRejected = new(
        Values.OrderRejected
    );

    public static readonly CreateWebhookEndpointRequestSubscribedEventsItem OrderSubmitted = new(
        Values.OrderSubmitted
    );

    public static readonly CreateWebhookEndpointRequestSubscribedEventsItem OrderAccepted = new(
        Values.OrderAccepted
    );

    public static readonly CreateWebhookEndpointRequestSubscribedEventsItem OrderProcessing = new(
        Values.OrderProcessing
    );

    public static readonly CreateWebhookEndpointRequestSubscribedEventsItem OrderShipped = new(
        Values.OrderShipped
    );

    public static readonly CreateWebhookEndpointRequestSubscribedEventsItem OrderDelivered = new(
        Values.OrderDelivered
    );

    public static readonly CreateWebhookEndpointRequestSubscribedEventsItem OrderBlocked = new(
        Values.OrderBlocked
    );

    public static readonly CreateWebhookEndpointRequestSubscribedEventsItem OrderCancelled = new(
        Values.OrderCancelled
    );

    public CreateWebhookEndpointRequestSubscribedEventsItem(string value)
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
    public static CreateWebhookEndpointRequestSubscribedEventsItem FromCustom(string value)
    {
        return new CreateWebhookEndpointRequestSubscribedEventsItem(value);
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
        CreateWebhookEndpointRequestSubscribedEventsItem value1,
        string value2
    ) => value1.Value.Equals(value2);

    public static bool operator !=(
        CreateWebhookEndpointRequestSubscribedEventsItem value1,
        string value2
    ) => !value1.Value.Equals(value2);

    public static explicit operator string(
        CreateWebhookEndpointRequestSubscribedEventsItem value
    ) => value.Value;

    public static explicit operator CreateWebhookEndpointRequestSubscribedEventsItem(
        string value
    ) => new(value);

    internal class CreateWebhookEndpointRequestSubscribedEventsItemSerializer
        : JsonConverter<CreateWebhookEndpointRequestSubscribedEventsItem>
    {
        public override CreateWebhookEndpointRequestSubscribedEventsItem Read(
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
            return new CreateWebhookEndpointRequestSubscribedEventsItem(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            CreateWebhookEndpointRequestSubscribedEventsItem value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override CreateWebhookEndpointRequestSubscribedEventsItem ReadAsPropertyName(
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
            return new CreateWebhookEndpointRequestSubscribedEventsItem(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            CreateWebhookEndpointRequestSubscribedEventsItem value,
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
