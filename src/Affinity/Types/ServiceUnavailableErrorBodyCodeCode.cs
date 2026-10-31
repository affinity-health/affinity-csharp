using Affinity.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Affinity;

[JsonConverter(
    typeof(ServiceUnavailableErrorBodyCodeCode.ServiceUnavailableErrorBodyCodeCodeSerializer)
)]
[Serializable]
public readonly record struct ServiceUnavailableErrorBodyCodeCode : IStringEnum
{
    public static readonly ServiceUnavailableErrorBodyCodeCode ServiceUnavailable = new(
        Values.ServiceUnavailable
    );

    public ServiceUnavailableErrorBodyCodeCode(string value)
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
    public static ServiceUnavailableErrorBodyCodeCode FromCustom(string value)
    {
        return new ServiceUnavailableErrorBodyCodeCode(value);
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

    public static bool operator ==(ServiceUnavailableErrorBodyCodeCode value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(ServiceUnavailableErrorBodyCodeCode value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(ServiceUnavailableErrorBodyCodeCode value) =>
        value.Value;

    public static explicit operator ServiceUnavailableErrorBodyCodeCode(string value) => new(value);

    internal class ServiceUnavailableErrorBodyCodeCodeSerializer
        : JsonConverter<ServiceUnavailableErrorBodyCodeCode>
    {
        public override ServiceUnavailableErrorBodyCodeCode Read(
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
            return new ServiceUnavailableErrorBodyCodeCode(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            ServiceUnavailableErrorBodyCodeCode value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override ServiceUnavailableErrorBodyCodeCode ReadAsPropertyName(
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
            return new ServiceUnavailableErrorBodyCodeCode(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            ServiceUnavailableErrorBodyCodeCode value,
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
        public const string ServiceUnavailable = "service_unavailable";
    }
}
