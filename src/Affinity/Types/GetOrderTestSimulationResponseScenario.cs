using Affinity.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Affinity;

[JsonConverter(
    typeof(GetOrderTestSimulationResponseScenario.GetOrderTestSimulationResponseScenarioSerializer)
)]
[Serializable]
public readonly record struct GetOrderTestSimulationResponseScenario : IStringEnum
{
    public static readonly GetOrderTestSimulationResponseScenario Successful = new(
        Values.Successful
    );

    public static readonly GetOrderTestSimulationResponseScenario PharmacyRejection = new(
        Values.PharmacyRejection
    );

    public static readonly GetOrderTestSimulationResponseScenario CancellationDeclined = new(
        Values.CancellationDeclined
    );

    public GetOrderTestSimulationResponseScenario(string value)
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
    public static GetOrderTestSimulationResponseScenario FromCustom(string value)
    {
        return new GetOrderTestSimulationResponseScenario(value);
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

    public static bool operator ==(GetOrderTestSimulationResponseScenario value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(GetOrderTestSimulationResponseScenario value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(GetOrderTestSimulationResponseScenario value) =>
        value.Value;

    public static explicit operator GetOrderTestSimulationResponseScenario(string value) =>
        new(value);

    internal class GetOrderTestSimulationResponseScenarioSerializer
        : JsonConverter<GetOrderTestSimulationResponseScenario>
    {
        public override GetOrderTestSimulationResponseScenario Read(
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
            return new GetOrderTestSimulationResponseScenario(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            GetOrderTestSimulationResponseScenario value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override GetOrderTestSimulationResponseScenario ReadAsPropertyName(
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
            return new GetOrderTestSimulationResponseScenario(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            GetOrderTestSimulationResponseScenario value,
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
        public const string Successful = "successful";

        public const string PharmacyRejection = "pharmacy_rejection";

        public const string CancellationDeclined = "cancellation_declined";
    }
}
