using Affinity.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Affinity;

[JsonConverter(typeof(SignAndSubmitOrderResponseObject.SignAndSubmitOrderResponseObjectSerializer))]
[Serializable]
public readonly record struct SignAndSubmitOrderResponseObject : IStringEnum
{
    public static readonly SignAndSubmitOrderResponseObject OrderSignAndSubmission = new(
        Values.OrderSignAndSubmission
    );

    public SignAndSubmitOrderResponseObject(string value)
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
    public static SignAndSubmitOrderResponseObject FromCustom(string value)
    {
        return new SignAndSubmitOrderResponseObject(value);
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

    public static bool operator ==(SignAndSubmitOrderResponseObject value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(SignAndSubmitOrderResponseObject value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(SignAndSubmitOrderResponseObject value) => value.Value;

    public static explicit operator SignAndSubmitOrderResponseObject(string value) => new(value);

    internal class SignAndSubmitOrderResponseObjectSerializer
        : JsonConverter<SignAndSubmitOrderResponseObject>
    {
        public override SignAndSubmitOrderResponseObject Read(
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
            return new SignAndSubmitOrderResponseObject(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            SignAndSubmitOrderResponseObject value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override SignAndSubmitOrderResponseObject ReadAsPropertyName(
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
            return new SignAndSubmitOrderResponseObject(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            SignAndSubmitOrderResponseObject value,
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
        public const string OrderSignAndSubmission = "order_sign_and_submission";
    }
}
