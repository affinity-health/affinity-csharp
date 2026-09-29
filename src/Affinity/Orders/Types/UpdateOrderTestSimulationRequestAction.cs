using Affinity.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Affinity;

[JsonConverter(
    typeof(UpdateOrderTestSimulationRequestAction.UpdateOrderTestSimulationRequestActionSerializer)
)]
[Serializable]
public readonly record struct UpdateOrderTestSimulationRequestAction : IStringEnum
{
    public static readonly UpdateOrderTestSimulationRequestAction Accept = new(Values.Accept);

    public static readonly UpdateOrderTestSimulationRequestAction Process = new(Values.Process);

    public static readonly UpdateOrderTestSimulationRequestAction Ship = new(Values.Ship);

    public static readonly UpdateOrderTestSimulationRequestAction Deliver = new(Values.Deliver);

    public static readonly UpdateOrderTestSimulationRequestAction Reject = new(Values.Reject);

    public static readonly UpdateOrderTestSimulationRequestAction ConfirmCancellation = new(
        Values.ConfirmCancellation
    );

    public static readonly UpdateOrderTestSimulationRequestAction DeclineCancellation = new(
        Values.DeclineCancellation
    );

    public UpdateOrderTestSimulationRequestAction(string value)
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
    public static UpdateOrderTestSimulationRequestAction FromCustom(string value)
    {
        return new UpdateOrderTestSimulationRequestAction(value);
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

    public static bool operator ==(UpdateOrderTestSimulationRequestAction value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(UpdateOrderTestSimulationRequestAction value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(UpdateOrderTestSimulationRequestAction value) =>
        value.Value;

    public static explicit operator UpdateOrderTestSimulationRequestAction(string value) =>
        new(value);

    internal class UpdateOrderTestSimulationRequestActionSerializer
        : JsonConverter<UpdateOrderTestSimulationRequestAction>
    {
        public override UpdateOrderTestSimulationRequestAction Read(
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
            return new UpdateOrderTestSimulationRequestAction(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            UpdateOrderTestSimulationRequestAction value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override UpdateOrderTestSimulationRequestAction ReadAsPropertyName(
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
            return new UpdateOrderTestSimulationRequestAction(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            UpdateOrderTestSimulationRequestAction value,
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
        public const string Accept = "accept";

        public const string Process = "process";

        public const string Ship = "ship";

        public const string Deliver = "deliver";

        public const string Reject = "reject";

        public const string ConfirmCancellation = "confirm_cancellation";

        public const string DeclineCancellation = "decline_cancellation";
    }
}
