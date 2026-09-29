using Affinity.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Affinity.Orders;

[JsonConverter(
    typeof(UpdateOrderTestSimulationRequestScenario.UpdateOrderTestSimulationRequestScenarioSerializer)
)]
[Serializable]
public readonly record struct UpdateOrderTestSimulationRequestScenario : IStringEnum
{
    public static readonly UpdateOrderTestSimulationRequestScenario Successful = new(
        Values.Successful
    );

    public static readonly UpdateOrderTestSimulationRequestScenario PharmacyRejection = new(
        Values.PharmacyRejection
    );

    public static readonly UpdateOrderTestSimulationRequestScenario CancellationDeclined = new(
        Values.CancellationDeclined
    );

    public UpdateOrderTestSimulationRequestScenario(string value)
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
    public static UpdateOrderTestSimulationRequestScenario FromCustom(string value)
    {
        return new UpdateOrderTestSimulationRequestScenario(value);
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
        UpdateOrderTestSimulationRequestScenario value1,
        string value2
    ) => value1.Value.Equals(value2);

    public static bool operator !=(
        UpdateOrderTestSimulationRequestScenario value1,
        string value2
    ) => !value1.Value.Equals(value2);

    public static explicit operator string(UpdateOrderTestSimulationRequestScenario value) =>
        value.Value;

    public static explicit operator UpdateOrderTestSimulationRequestScenario(string value) =>
        new(value);

    internal class UpdateOrderTestSimulationRequestScenarioSerializer
        : JsonConverter<UpdateOrderTestSimulationRequestScenario>
    {
        public override UpdateOrderTestSimulationRequestScenario Read(
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
            return new UpdateOrderTestSimulationRequestScenario(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            UpdateOrderTestSimulationRequestScenario value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override UpdateOrderTestSimulationRequestScenario ReadAsPropertyName(
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
            return new UpdateOrderTestSimulationRequestScenario(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            UpdateOrderTestSimulationRequestScenario value,
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
