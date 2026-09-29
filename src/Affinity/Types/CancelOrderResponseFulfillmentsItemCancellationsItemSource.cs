using Affinity.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Affinity;

[JsonConverter(
    typeof(CancelOrderResponseFulfillmentsItemCancellationsItemSource.CancelOrderResponseFulfillmentsItemCancellationsItemSourceSerializer)
)]
[Serializable]
public readonly record struct CancelOrderResponseFulfillmentsItemCancellationsItemSource
    : IStringEnum
{
    public static readonly CancelOrderResponseFulfillmentsItemCancellationsItemSource Provider =
        new(Values.Provider);

    public static readonly CancelOrderResponseFulfillmentsItemCancellationsItemSource Platform =
        new(Values.Platform);

    public static readonly CancelOrderResponseFulfillmentsItemCancellationsItemSource PublicApi =
        new(Values.PublicApi);

    public static readonly CancelOrderResponseFulfillmentsItemCancellationsItemSource Pharmacy =
        new(Values.Pharmacy);

    public static readonly CancelOrderResponseFulfillmentsItemCancellationsItemSource System = new(
        Values.System
    );

    public CancelOrderResponseFulfillmentsItemCancellationsItemSource(string value)
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
    public static CancelOrderResponseFulfillmentsItemCancellationsItemSource FromCustom(
        string value
    )
    {
        return new CancelOrderResponseFulfillmentsItemCancellationsItemSource(value);
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
        CancelOrderResponseFulfillmentsItemCancellationsItemSource value1,
        string value2
    ) => value1.Value.Equals(value2);

    public static bool operator !=(
        CancelOrderResponseFulfillmentsItemCancellationsItemSource value1,
        string value2
    ) => !value1.Value.Equals(value2);

    public static explicit operator string(
        CancelOrderResponseFulfillmentsItemCancellationsItemSource value
    ) => value.Value;

    public static explicit operator CancelOrderResponseFulfillmentsItemCancellationsItemSource(
        string value
    ) => new(value);

    internal class CancelOrderResponseFulfillmentsItemCancellationsItemSourceSerializer
        : JsonConverter<CancelOrderResponseFulfillmentsItemCancellationsItemSource>
    {
        public override CancelOrderResponseFulfillmentsItemCancellationsItemSource Read(
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
            return new CancelOrderResponseFulfillmentsItemCancellationsItemSource(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            CancelOrderResponseFulfillmentsItemCancellationsItemSource value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override CancelOrderResponseFulfillmentsItemCancellationsItemSource ReadAsPropertyName(
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
            return new CancelOrderResponseFulfillmentsItemCancellationsItemSource(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            CancelOrderResponseFulfillmentsItemCancellationsItemSource value,
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
