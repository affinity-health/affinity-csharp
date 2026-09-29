using Affinity.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Affinity;

[JsonConverter(typeof(GetOrderResponseObject.GetOrderResponseObjectSerializer))]
[Serializable]
public readonly record struct GetOrderResponseObject : IStringEnum
{
    public static readonly GetOrderResponseObject Order = new(Values.Order);

    public GetOrderResponseObject(string value)
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
    public static GetOrderResponseObject FromCustom(string value)
    {
        return new GetOrderResponseObject(value);
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

    public static bool operator ==(GetOrderResponseObject value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(GetOrderResponseObject value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(GetOrderResponseObject value) => value.Value;

    public static explicit operator GetOrderResponseObject(string value) => new(value);

    internal class GetOrderResponseObjectSerializer : JsonConverter<GetOrderResponseObject>
    {
        public override GetOrderResponseObject Read(
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
            return new GetOrderResponseObject(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            GetOrderResponseObject value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override GetOrderResponseObject ReadAsPropertyName(
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
            return new GetOrderResponseObject(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            GetOrderResponseObject value,
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
        public const string Order = "order";
    }
}
