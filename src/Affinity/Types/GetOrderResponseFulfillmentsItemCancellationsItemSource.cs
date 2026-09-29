using Affinity.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Affinity;

[JsonConverter(
    typeof(GetOrderResponseFulfillmentsItemCancellationsItemSource.GetOrderResponseFulfillmentsItemCancellationsItemSourceSerializer)
)]
[Serializable]
public readonly record struct GetOrderResponseFulfillmentsItemCancellationsItemSource : IStringEnum
{
    public static readonly GetOrderResponseFulfillmentsItemCancellationsItemSource Provider = new(
        Values.Provider
    );

    public static readonly GetOrderResponseFulfillmentsItemCancellationsItemSource Platform = new(
        Values.Platform
    );

    public static readonly GetOrderResponseFulfillmentsItemCancellationsItemSource PublicApi = new(
        Values.PublicApi
    );

    public static readonly GetOrderResponseFulfillmentsItemCancellationsItemSource Pharmacy = new(
        Values.Pharmacy
    );

    public static readonly GetOrderResponseFulfillmentsItemCancellationsItemSource System = new(
        Values.System
    );

    public GetOrderResponseFulfillmentsItemCancellationsItemSource(string value)
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
    public static GetOrderResponseFulfillmentsItemCancellationsItemSource FromCustom(string value)
    {
        return new GetOrderResponseFulfillmentsItemCancellationsItemSource(value);
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
        GetOrderResponseFulfillmentsItemCancellationsItemSource value1,
        string value2
    ) => value1.Value.Equals(value2);

    public static bool operator !=(
        GetOrderResponseFulfillmentsItemCancellationsItemSource value1,
        string value2
    ) => !value1.Value.Equals(value2);

    public static explicit operator string(
        GetOrderResponseFulfillmentsItemCancellationsItemSource value
    ) => value.Value;

    public static explicit operator GetOrderResponseFulfillmentsItemCancellationsItemSource(
        string value
    ) => new(value);

    internal class GetOrderResponseFulfillmentsItemCancellationsItemSourceSerializer
        : JsonConverter<GetOrderResponseFulfillmentsItemCancellationsItemSource>
    {
        public override GetOrderResponseFulfillmentsItemCancellationsItemSource Read(
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
            return new GetOrderResponseFulfillmentsItemCancellationsItemSource(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            GetOrderResponseFulfillmentsItemCancellationsItemSource value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override GetOrderResponseFulfillmentsItemCancellationsItemSource ReadAsPropertyName(
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
            return new GetOrderResponseFulfillmentsItemCancellationsItemSource(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            GetOrderResponseFulfillmentsItemCancellationsItemSource value,
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
        public const string Provider = "provider";

        public const string Platform = "platform";

        public const string PublicApi = "public_api";

        public const string Pharmacy = "pharmacy";

        public const string System = "system";
    }
}
