using Affinity.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Affinity.Orders;

[JsonConverter(
    typeof(UpdateOrderTestSimulationRequestMode.UpdateOrderTestSimulationRequestModeSerializer)
)]
[Serializable]
public readonly record struct UpdateOrderTestSimulationRequestMode : IStringEnum
{
    public static readonly UpdateOrderTestSimulationRequestMode Automatic = new(Values.Automatic);

    public static readonly UpdateOrderTestSimulationRequestMode Manual = new(Values.Manual);

    public UpdateOrderTestSimulationRequestMode(string value)
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
    public static UpdateOrderTestSimulationRequestMode FromCustom(string value)
    {
        return new UpdateOrderTestSimulationRequestMode(value);
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

    public static bool operator ==(UpdateOrderTestSimulationRequestMode value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(UpdateOrderTestSimulationRequestMode value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(UpdateOrderTestSimulationRequestMode value) =>
        value.Value;

    public static explicit operator UpdateOrderTestSimulationRequestMode(string value) =>
        new(value);

    internal class UpdateOrderTestSimulationRequestModeSerializer
        : JsonConverter<UpdateOrderTestSimulationRequestMode>
    {
        public override UpdateOrderTestSimulationRequestMode Read(
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
            return new UpdateOrderTestSimulationRequestMode(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            UpdateOrderTestSimulationRequestMode value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override UpdateOrderTestSimulationRequestMode ReadAsPropertyName(
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
            return new UpdateOrderTestSimulationRequestMode(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            UpdateOrderTestSimulationRequestMode value,
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
