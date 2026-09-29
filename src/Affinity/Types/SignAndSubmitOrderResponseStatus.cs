using Affinity.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Affinity;

[JsonConverter(typeof(SignAndSubmitOrderResponseStatus.SignAndSubmitOrderResponseStatusSerializer))]
[Serializable]
public readonly record struct SignAndSubmitOrderResponseStatus : IStringEnum
{
    public static readonly SignAndSubmitOrderResponseStatus Submitted = new(Values.Submitted);

    public static readonly SignAndSubmitOrderResponseStatus PartiallySubmitted = new(
        Values.PartiallySubmitted
    );

    public static readonly SignAndSubmitOrderResponseStatus NotSubmitted = new(Values.NotSubmitted);

    public SignAndSubmitOrderResponseStatus(string value)
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
    public static SignAndSubmitOrderResponseStatus FromCustom(string value)
    {
        return new SignAndSubmitOrderResponseStatus(value);
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

    public static bool operator ==(SignAndSubmitOrderResponseStatus value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(SignAndSubmitOrderResponseStatus value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(SignAndSubmitOrderResponseStatus value) => value.Value;

    public static explicit operator SignAndSubmitOrderResponseStatus(string value) => new(value);

    internal class SignAndSubmitOrderResponseStatusSerializer
        : JsonConverter<SignAndSubmitOrderResponseStatus>
    {
        public override SignAndSubmitOrderResponseStatus Read(
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
            return new SignAndSubmitOrderResponseStatus(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            SignAndSubmitOrderResponseStatus value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override SignAndSubmitOrderResponseStatus ReadAsPropertyName(
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
            return new SignAndSubmitOrderResponseStatus(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            SignAndSubmitOrderResponseStatus value,
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
        public const string Submitted = "submitted";

        public const string PartiallySubmitted = "partially_submitted";

        public const string NotSubmitted = "not_submitted";
    }
}
