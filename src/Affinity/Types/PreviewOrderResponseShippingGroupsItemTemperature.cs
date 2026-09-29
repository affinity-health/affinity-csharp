using Affinity.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Affinity;

[JsonConverter(
    typeof(PreviewOrderResponseShippingGroupsItemTemperature.PreviewOrderResponseShippingGroupsItemTemperatureSerializer)
)]
[Serializable]
public readonly record struct PreviewOrderResponseShippingGroupsItemTemperature : IStringEnum
{
    public static readonly PreviewOrderResponseShippingGroupsItemTemperature Ambient = new(
        Values.Ambient
    );

    public static readonly PreviewOrderResponseShippingGroupsItemTemperature Refrigerated = new(
        Values.Refrigerated
    );

    public PreviewOrderResponseShippingGroupsItemTemperature(string value)
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
    public static PreviewOrderResponseShippingGroupsItemTemperature FromCustom(string value)
    {
        return new PreviewOrderResponseShippingGroupsItemTemperature(value);
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
        PreviewOrderResponseShippingGroupsItemTemperature value1,
        string value2
    ) => value1.Value.Equals(value2);

    public static bool operator !=(
        PreviewOrderResponseShippingGroupsItemTemperature value1,
        string value2
    ) => !value1.Value.Equals(value2);

    public static explicit operator string(
        PreviewOrderResponseShippingGroupsItemTemperature value
    ) => value.Value;

    public static explicit operator PreviewOrderResponseShippingGroupsItemTemperature(
        string value
    ) => new(value);

    internal class PreviewOrderResponseShippingGroupsItemTemperatureSerializer
        : JsonConverter<PreviewOrderResponseShippingGroupsItemTemperature>
    {
        public override PreviewOrderResponseShippingGroupsItemTemperature Read(
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
            return new PreviewOrderResponseShippingGroupsItemTemperature(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            PreviewOrderResponseShippingGroupsItemTemperature value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override PreviewOrderResponseShippingGroupsItemTemperature ReadAsPropertyName(
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
            return new PreviewOrderResponseShippingGroupsItemTemperature(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            PreviewOrderResponseShippingGroupsItemTemperature value,
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
        public const string Ambient = "ambient";

        public const string Refrigerated = "refrigerated";
    }
}
