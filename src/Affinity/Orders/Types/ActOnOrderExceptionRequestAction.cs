using Affinity.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Affinity;

[JsonConverter(typeof(ActOnOrderExceptionRequestAction.ActOnOrderExceptionRequestActionSerializer))]
[Serializable]
public readonly record struct ActOnOrderExceptionRequestAction : IStringEnum
{
    public static readonly ActOnOrderExceptionRequestAction Acknowledge = new(Values.Acknowledge);

    public static readonly ActOnOrderExceptionRequestAction AssignToMe = new(Values.AssignToMe);

    public static readonly ActOnOrderExceptionRequestAction ContactPharmacy = new(
        Values.ContactPharmacy
    );

    public static readonly ActOnOrderExceptionRequestAction RecordOutcome = new(
        Values.RecordOutcome
    );

    public static readonly ActOnOrderExceptionRequestAction Resolve = new(Values.Resolve);

    public static readonly ActOnOrderExceptionRequestAction Retry = new(Values.Retry);

    public ActOnOrderExceptionRequestAction(string value)
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
    public static ActOnOrderExceptionRequestAction FromCustom(string value)
    {
        return new ActOnOrderExceptionRequestAction(value);
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

    public static bool operator ==(ActOnOrderExceptionRequestAction value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(ActOnOrderExceptionRequestAction value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(ActOnOrderExceptionRequestAction value) => value.Value;

    public static explicit operator ActOnOrderExceptionRequestAction(string value) => new(value);

    internal class ActOnOrderExceptionRequestActionSerializer
        : JsonConverter<ActOnOrderExceptionRequestAction>
    {
        public override ActOnOrderExceptionRequestAction Read(
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
            return new ActOnOrderExceptionRequestAction(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            ActOnOrderExceptionRequestAction value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override ActOnOrderExceptionRequestAction ReadAsPropertyName(
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
            return new ActOnOrderExceptionRequestAction(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            ActOnOrderExceptionRequestAction value,
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
        public const string Acknowledge = "acknowledge";

        public const string AssignToMe = "assign_to_me";

        public const string ContactPharmacy = "contact_pharmacy";

        public const string RecordOutcome = "record_outcome";

        public const string Resolve = "resolve";

        public const string Retry = "retry";
    }
}
