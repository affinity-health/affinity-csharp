using Affinity.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Affinity;

[JsonConverter(
    typeof(ListOrdersResponseDataItemLifecycleEventsItemSource.ListOrdersResponseDataItemLifecycleEventsItemSourceSerializer)
)]
[Serializable]
public readonly record struct ListOrdersResponseDataItemLifecycleEventsItemSource : IStringEnum
{
    public static readonly ListOrdersResponseDataItemLifecycleEventsItemSource Cancellation = new(
        Values.Cancellation
    );

    public static readonly ListOrdersResponseDataItemLifecycleEventsItemSource Exception = new(
        Values.Exception
    );

    public static readonly ListOrdersResponseDataItemLifecycleEventsItemSource Fulfillment = new(
        Values.Fulfillment
    );

    public static readonly ListOrdersResponseDataItemLifecycleEventsItemSource Integration = new(
        Values.Integration
    );

    public static readonly ListOrdersResponseDataItemLifecycleEventsItemSource Shipment = new(
        Values.Shipment
    );

    public static readonly ListOrdersResponseDataItemLifecycleEventsItemSource Webhook = new(
        Values.Webhook
    );

    public ListOrdersResponseDataItemLifecycleEventsItemSource(string value)
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
    public static ListOrdersResponseDataItemLifecycleEventsItemSource FromCustom(string value)
    {
        return new ListOrdersResponseDataItemLifecycleEventsItemSource(value);
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
        ListOrdersResponseDataItemLifecycleEventsItemSource value1,
        string value2
    ) => value1.Value.Equals(value2);

    public static bool operator !=(
        ListOrdersResponseDataItemLifecycleEventsItemSource value1,
        string value2
    ) => !value1.Value.Equals(value2);

    public static explicit operator string(
        ListOrdersResponseDataItemLifecycleEventsItemSource value
    ) => value.Value;

    public static explicit operator ListOrdersResponseDataItemLifecycleEventsItemSource(
        string value
    ) => new(value);

    internal class ListOrdersResponseDataItemLifecycleEventsItemSourceSerializer
        : JsonConverter<ListOrdersResponseDataItemLifecycleEventsItemSource>
    {
        public override ListOrdersResponseDataItemLifecycleEventsItemSource Read(
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
            return new ListOrdersResponseDataItemLifecycleEventsItemSource(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            ListOrdersResponseDataItemLifecycleEventsItemSource value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override ListOrdersResponseDataItemLifecycleEventsItemSource ReadAsPropertyName(
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
            return new ListOrdersResponseDataItemLifecycleEventsItemSource(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            ListOrdersResponseDataItemLifecycleEventsItemSource value,
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
