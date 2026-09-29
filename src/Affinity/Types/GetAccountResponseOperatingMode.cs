using Affinity.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Affinity;

[JsonConverter(typeof(GetAccountResponseOperatingMode.GetAccountResponseOperatingModeSerializer))]
[Serializable]
public readonly record struct GetAccountResponseOperatingMode : IStringEnum
{
    public static readonly GetAccountResponseOperatingMode Production = new(Values.Production);

    public static readonly GetAccountResponseOperatingMode ProductionPending = new(
        Values.ProductionPending
    );

    public static readonly GetAccountResponseOperatingMode Sandbox = new(Values.Sandbox);

    public static readonly GetAccountResponseOperatingMode Suspended = new(Values.Suspended);

    public GetAccountResponseOperatingMode(string value)
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
    public static GetAccountResponseOperatingMode FromCustom(string value)
    {
        return new GetAccountResponseOperatingMode(value);
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

    public static bool operator ==(GetAccountResponseOperatingMode value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(GetAccountResponseOperatingMode value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(GetAccountResponseOperatingMode value) => value.Value;

    public static explicit operator GetAccountResponseOperatingMode(string value) => new(value);

    internal class GetAccountResponseOperatingModeSerializer
        : JsonConverter<GetAccountResponseOperatingMode>
    {
        public override GetAccountResponseOperatingMode Read(
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
            return new GetAccountResponseOperatingMode(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            GetAccountResponseOperatingMode value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override GetAccountResponseOperatingMode ReadAsPropertyName(
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
            return new GetAccountResponseOperatingMode(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            GetAccountResponseOperatingMode value,
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
        public const string Production = "production";

        public const string ProductionPending = "production_pending";

        public const string Sandbox = "sandbox";

        public const string Suspended = "suspended";
    }
}
