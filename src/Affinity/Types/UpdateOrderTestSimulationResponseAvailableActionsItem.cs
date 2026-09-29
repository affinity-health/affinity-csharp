using Affinity.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Affinity;

[JsonConverter(
    typeof(UpdateOrderTestSimulationResponseAvailableActionsItem.UpdateOrderTestSimulationResponseAvailableActionsItemSerializer)
)]
[Serializable]
public readonly record struct UpdateOrderTestSimulationResponseAvailableActionsItem : IStringEnum
{
    public static readonly UpdateOrderTestSimulationResponseAvailableActionsItem Accept = new(
        Values.Accept
    );

    public static readonly UpdateOrderTestSimulationResponseAvailableActionsItem Process = new(
        Values.Process
    );

    public static readonly UpdateOrderTestSimulationResponseAvailableActionsItem Ship = new(
        Values.Ship
    );

    public static readonly UpdateOrderTestSimulationResponseAvailableActionsItem Deliver = new(
        Values.Deliver
    );

    public static readonly UpdateOrderTestSimulationResponseAvailableActionsItem Reject = new(
        Values.Reject
    );

    public static readonly UpdateOrderTestSimulationResponseAvailableActionsItem ConfirmCancellation =
        new(Values.ConfirmCancellation);

    public static readonly UpdateOrderTestSimulationResponseAvailableActionsItem DeclineCancellation =
        new(Values.DeclineCancellation);

    public UpdateOrderTestSimulationResponseAvailableActionsItem(string value)
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
    public static UpdateOrderTestSimulationResponseAvailableActionsItem FromCustom(string value)
    {
        return new UpdateOrderTestSimulationResponseAvailableActionsItem(value);
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
        UpdateOrderTestSimulationResponseAvailableActionsItem value1,
        string value2
    ) => value1.Value.Equals(value2);

    public static bool operator !=(
        UpdateOrderTestSimulationResponseAvailableActionsItem value1,
        string value2
    ) => !value1.Value.Equals(value2);

    public static explicit operator string(
        UpdateOrderTestSimulationResponseAvailableActionsItem value
    ) => value.Value;

    public static explicit operator UpdateOrderTestSimulationResponseAvailableActionsItem(
        string value
    ) => new(value);

    internal class UpdateOrderTestSimulationResponseAvailableActionsItemSerializer
        : JsonConverter<UpdateOrderTestSimulationResponseAvailableActionsItem>
    {
        public override UpdateOrderTestSimulationResponseAvailableActionsItem Read(
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
            return new UpdateOrderTestSimulationResponseAvailableActionsItem(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            UpdateOrderTestSimulationResponseAvailableActionsItem value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override UpdateOrderTestSimulationResponseAvailableActionsItem ReadAsPropertyName(
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
            return new UpdateOrderTestSimulationResponseAvailableActionsItem(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            UpdateOrderTestSimulationResponseAvailableActionsItem value,
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
