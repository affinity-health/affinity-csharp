using Affinity.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Affinity;

[JsonConverter(
    typeof(CreatePlatformPracticeApiKeyRequestScopesItem.CreatePlatformPracticeApiKeyRequestScopesItemSerializer)
)]
[Serializable]
public readonly record struct CreatePlatformPracticeApiKeyRequestScopesItem : IStringEnum
{
    public static readonly CreatePlatformPracticeApiKeyRequestScopesItem CatalogRead = new(
        Values.CatalogRead
    );

    public static readonly CreatePlatformPracticeApiKeyRequestScopesItem SellingPricesRead = new(
        Values.SellingPricesRead
    );

    public static readonly CreatePlatformPracticeApiKeyRequestScopesItem SellingPricesWrite = new(
        Values.SellingPricesWrite
    );

    public static readonly CreatePlatformPracticeApiKeyRequestScopesItem CatalogPricingRead = new(
        Values.CatalogPricingRead
    );

    public static readonly CreatePlatformPracticeApiKeyRequestScopesItem CatalogPricingWrite = new(
        Values.CatalogPricingWrite
    );

    public static readonly CreatePlatformPracticeApiKeyRequestScopesItem FormulationDefaultsRead =
        new(Values.FormulationDefaultsRead);

    public static readonly CreatePlatformPracticeApiKeyRequestScopesItem FormulationDefaultsWrite =
        new(Values.FormulationDefaultsWrite);

    public static readonly CreatePlatformPracticeApiKeyRequestScopesItem PracticesRead = new(
        Values.PracticesRead
    );

    public static readonly CreatePlatformPracticeApiKeyRequestScopesItem PracticesWrite = new(
        Values.PracticesWrite
    );

    public static readonly CreatePlatformPracticeApiKeyRequestScopesItem ServiceKeysWrite = new(
        Values.ServiceKeysWrite
    );

    public static readonly CreatePlatformPracticeApiKeyRequestScopesItem LocationsRead = new(
        Values.LocationsRead
    );

    public static readonly CreatePlatformPracticeApiKeyRequestScopesItem LocationsWrite = new(
        Values.LocationsWrite
    );

    public static readonly CreatePlatformPracticeApiKeyRequestScopesItem OrdersRead = new(
        Values.OrdersRead
    );

    public static readonly CreatePlatformPracticeApiKeyRequestScopesItem OrdersWrite = new(
        Values.OrdersWrite
    );

    public static readonly CreatePlatformPracticeApiKeyRequestScopesItem OrdersSign = new(
        Values.OrdersSign
    );

    public static readonly CreatePlatformPracticeApiKeyRequestScopesItem PatientsRead = new(
        Values.PatientsRead
    );

    public static readonly CreatePlatformPracticeApiKeyRequestScopesItem PatientsWrite = new(
        Values.PatientsWrite
    );

    public static readonly CreatePlatformPracticeApiKeyRequestScopesItem TeamRead = new(
        Values.TeamRead
    );

    public static readonly CreatePlatformPracticeApiKeyRequestScopesItem TeamWrite = new(
        Values.TeamWrite
    );

    public static readonly CreatePlatformPracticeApiKeyRequestScopesItem HostedSessionsWrite = new(
        Values.HostedSessionsWrite
    );

    public static readonly CreatePlatformPracticeApiKeyRequestScopesItem WebhooksRead = new(
        Values.WebhooksRead
    );

    public static readonly CreatePlatformPracticeApiKeyRequestScopesItem WebhooksWrite = new(
        Values.WebhooksWrite
    );

    public CreatePlatformPracticeApiKeyRequestScopesItem(string value)
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
    public static CreatePlatformPracticeApiKeyRequestScopesItem FromCustom(string value)
    {
        return new CreatePlatformPracticeApiKeyRequestScopesItem(value);
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
        CreatePlatformPracticeApiKeyRequestScopesItem value1,
        string value2
    ) => value1.Value.Equals(value2);

    public static bool operator !=(
        CreatePlatformPracticeApiKeyRequestScopesItem value1,
        string value2
    ) => !value1.Value.Equals(value2);

    public static explicit operator string(CreatePlatformPracticeApiKeyRequestScopesItem value) =>
        value.Value;

    public static explicit operator CreatePlatformPracticeApiKeyRequestScopesItem(string value) =>
        new(value);

    internal class CreatePlatformPracticeApiKeyRequestScopesItemSerializer
        : JsonConverter<CreatePlatformPracticeApiKeyRequestScopesItem>
    {
        public override CreatePlatformPracticeApiKeyRequestScopesItem Read(
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
            return new CreatePlatformPracticeApiKeyRequestScopesItem(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            CreatePlatformPracticeApiKeyRequestScopesItem value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override CreatePlatformPracticeApiKeyRequestScopesItem ReadAsPropertyName(
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
            return new CreatePlatformPracticeApiKeyRequestScopesItem(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            CreatePlatformPracticeApiKeyRequestScopesItem value,
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
        public const string CatalogRead = "catalog:read";

        public const string SellingPricesRead = "selling_prices:read";

        public const string SellingPricesWrite = "selling_prices:write";

        public const string CatalogPricingRead = "catalog_pricing:read";

        public const string CatalogPricingWrite = "catalog_pricing:write";

        public const string FormulationDefaultsRead = "formulation_defaults:read";

        public const string FormulationDefaultsWrite = "formulation_defaults:write";

        public const string PracticesRead = "practices:read";

        public const string PracticesWrite = "practices:write";

        public const string ServiceKeysWrite = "service_keys:write";

        public const string LocationsRead = "locations:read";

        public const string LocationsWrite = "locations:write";

        public const string OrdersRead = "orders:read";

        public const string OrdersWrite = "orders:write";

        public const string OrdersSign = "orders:sign";

        public const string PatientsRead = "patients:read";

        public const string PatientsWrite = "patients:write";

        public const string TeamRead = "team:read";

        public const string TeamWrite = "team:write";

        public const string HostedSessionsWrite = "hosted_sessions:write";

        public const string WebhooksRead = "webhooks:read";

        public const string WebhooksWrite = "webhooks:write";
    }
}
