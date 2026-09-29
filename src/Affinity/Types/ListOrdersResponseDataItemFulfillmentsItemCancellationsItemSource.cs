using Affinity.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Affinity;

[JsonConverter(
    typeof(ListOrdersResponseDataItemFulfillmentsItemCancellationsItemSource.ListOrdersResponseDataItemFulfillmentsItemCancellationsItemSourceSerializer)
)]
[Serializable]
public readonly record struct ListOrdersResponseDataItemFulfillmentsItemCancellationsItemSource
    : IStringEnum
{
    public static readonly ListOrdersResponseDataItemFulfillmentsItemCancellationsItemSource Provider =
        new(Values.Provider);

    public static readonly ListOrdersResponseDataItemFulfillmentsItemCancellationsItemSource Platform =
        new(Values.Platform);

    public static readonly ListOrdersResponseDataItemFulfillmentsItemCancellationsItemSource PublicApi =
        new(Values.PublicApi);

    public static readonly ListOrdersResponseDataItemFulfillmentsItemCancellationsItemSource Pharmacy =
        new(Values.Pharmacy);

    public static readonly ListOrdersResponseDataItemFulfillmentsItemCancellationsItemSource System =
        new(Values.System);

    public ListOrdersResponseDataItemFulfillmentsItemCancellationsItemSource(string value)
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
    public static ListOrdersResponseDataItemFulfillmentsItemCancellationsItemSource FromCustom(
        string value
    )
    {
        return new ListOrdersResponseDataItemFulfillmentsItemCancellationsItemSource(value);
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
        ListOrdersResponseDataItemFulfillmentsItemCancellationsItemSource value1,
        string value2
    ) => value1.Value.Equals(value2);

    public static bool operator !=(
        ListOrdersResponseDataItemFulfillmentsItemCancellationsItemSource value1,
        string value2
    ) => !value1.Value.Equals(value2);

    public static explicit operator string(
        ListOrdersResponseDataItemFulfillmentsItemCancellationsItemSource value
    ) => value.Value;

    public static explicit operator ListOrdersResponseDataItemFulfillmentsItemCancellationsItemSource(
        string value
    ) => new(value);

    internal class ListOrdersResponseDataItemFulfillmentsItemCancellationsItemSourceSerializer
        : JsonConverter<ListOrdersResponseDataItemFulfillmentsItemCancellationsItemSource>
    {
        public override ListOrdersResponseDataItemFulfillmentsItemCancellationsItemSource Read(
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
            return new ListOrdersResponseDataItemFulfillmentsItemCancellationsItemSource(
                stringValue
            );
        }

        public override void Write(
            Utf8JsonWriter writer,
            ListOrdersResponseDataItemFulfillmentsItemCancellationsItemSource value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override ListOrdersResponseDataItemFulfillmentsItemCancellationsItemSource ReadAsPropertyName(
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
            return new ListOrdersResponseDataItemFulfillmentsItemCancellationsItemSource(
                stringValue
            );
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            ListOrdersResponseDataItemFulfillmentsItemCancellationsItemSource value,
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
