using Affinity.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Affinity;

[JsonConverter(
    typeof(GetOrderResponseLifecycleEventsItemSource.GetOrderResponseLifecycleEventsItemSourceSerializer)
)]
[Serializable]
public readonly record struct GetOrderResponseLifecycleEventsItemSource : IStringEnum
{
    public static readonly GetOrderResponseLifecycleEventsItemSource Cancellation = new(
        Values.Cancellation
    );

    public static readonly GetOrderResponseLifecycleEventsItemSource Exception = new(
        Values.Exception
    );

    public static readonly GetOrderResponseLifecycleEventsItemSource Fulfillment = new(
        Values.Fulfillment
    );

    public static readonly GetOrderResponseLifecycleEventsItemSource Integration = new(
        Values.Integration
    );

    public static readonly GetOrderResponseLifecycleEventsItemSource Shipment = new(
        Values.Shipment
    );

    public static readonly GetOrderResponseLifecycleEventsItemSource Webhook = new(Values.Webhook);

    public GetOrderResponseLifecycleEventsItemSource(string value)
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
    public static GetOrderResponseLifecycleEventsItemSource FromCustom(string value)
    {
        return new GetOrderResponseLifecycleEventsItemSource(value);
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
        GetOrderResponseLifecycleEventsItemSource value1,
        string value2
    ) => value1.Value.Equals(value2);

    public static bool operator !=(
        GetOrderResponseLifecycleEventsItemSource value1,
        string value2
    ) => !value1.Value.Equals(value2);

    public static explicit operator string(GetOrderResponseLifecycleEventsItemSource value) =>
        value.Value;

    public static explicit operator GetOrderResponseLifecycleEventsItemSource(string value) =>
        new(value);

    internal class GetOrderResponseLifecycleEventsItemSourceSerializer
        : JsonConverter<GetOrderResponseLifecycleEventsItemSource>
    {
        public override GetOrderResponseLifecycleEventsItemSource Read(
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
            return new GetOrderResponseLifecycleEventsItemSource(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            GetOrderResponseLifecycleEventsItemSource value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override GetOrderResponseLifecycleEventsItemSource ReadAsPropertyName(
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
            return new GetOrderResponseLifecycleEventsItemSource(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            GetOrderResponseLifecycleEventsItemSource value,
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
        public const string Cancellation = "cancellation";

        public const string Exception = "exception";

        public const string Fulfillment = "fulfillment";

        public const string Integration = "integration";

        public const string Shipment = "shipment";

        public const string Webhook = "webhook";
    }
}
