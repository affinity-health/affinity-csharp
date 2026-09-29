using Affinity.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Affinity;

[JsonConverter(
    typeof(GetOrderTestSimulationResponseMode.GetOrderTestSimulationResponseModeSerializer)
)]
[Serializable]
public readonly record struct GetOrderTestSimulationResponseMode : IStringEnum
{
    public static readonly GetOrderTestSimulationResponseMode Automatic = new(Values.Automatic);

    public static readonly GetOrderTestSimulationResponseMode Manual = new(Values.Manual);

    public GetOrderTestSimulationResponseMode(string value)
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
    public static GetOrderTestSimulationResponseMode FromCustom(string value)
    {
        return new GetOrderTestSimulationResponseMode(value);
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

    public static bool operator ==(GetOrderTestSimulationResponseMode value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(GetOrderTestSimulationResponseMode value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(GetOrderTestSimulationResponseMode value) => value.Value;

    public static explicit operator GetOrderTestSimulationResponseMode(string value) => new(value);

    internal class GetOrderTestSimulationResponseModeSerializer
        : JsonConverter<GetOrderTestSimulationResponseMode>
    {
        public override GetOrderTestSimulationResponseMode Read(
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
            return new GetOrderTestSimulationResponseMode(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            GetOrderTestSimulationResponseMode value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override GetOrderTestSimulationResponseMode ReadAsPropertyName(
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
            return new GetOrderTestSimulationResponseMode(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            GetOrderTestSimulationResponseMode value,
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
        public const string Automatic = "automatic";

        public const string Manual = "manual";
    }
}
