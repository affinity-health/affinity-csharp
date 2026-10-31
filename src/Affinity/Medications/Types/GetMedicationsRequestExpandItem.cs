using Affinity.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Affinity;

[JsonConverter(typeof(GetMedicationsRequestExpandItem.GetMedicationsRequestExpandItemSerializer))]
[Serializable]
public readonly record struct GetMedicationsRequestExpandItem : IStringEnum
{
    public static readonly GetMedicationsRequestExpandItem Variants = new(Values.Variants);

    public GetMedicationsRequestExpandItem(string value)
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
    public static GetMedicationsRequestExpandItem FromCustom(string value)
    {
        return new GetMedicationsRequestExpandItem(value);
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

    public static bool operator ==(GetMedicationsRequestExpandItem value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(GetMedicationsRequestExpandItem value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(GetMedicationsRequestExpandItem value) => value.Value;

    public static explicit operator GetMedicationsRequestExpandItem(string value) => new(value);

    internal class GetMedicationsRequestExpandItemSerializer
        : JsonConverter<GetMedicationsRequestExpandItem>
    {
        public override GetMedicationsRequestExpandItem Read(
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
            return new GetMedicationsRequestExpandItem(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            GetMedicationsRequestExpandItem value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override GetMedicationsRequestExpandItem ReadAsPropertyName(
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
            return new GetMedicationsRequestExpandItem(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            GetMedicationsRequestExpandItem value,
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
        public const string Variants = "variants";
    }
}
