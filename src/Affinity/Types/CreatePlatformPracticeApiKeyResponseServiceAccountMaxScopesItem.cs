using Affinity.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Affinity;

[JsonConverter(
    typeof(CreatePlatformPracticeApiKeyResponseServiceAccountMaxScopesItem.CreatePlatformPracticeApiKeyResponseServiceAccountMaxScopesItemSerializer)
)]
[Serializable]
public readonly record struct CreatePlatformPracticeApiKeyResponseServiceAccountMaxScopesItem
    : IStringEnum
{
    public static readonly CreatePlatformPracticeApiKeyResponseServiceAccountMaxScopesItem CatalogRead =
        new(Values.CatalogRead);

    public static readonly CreatePlatformPracticeApiKeyResponseServiceAccountMaxScopesItem SellingPricesRead =
        new(Values.SellingPricesRead);

    public static readonly CreatePlatformPracticeApiKeyResponseServiceAccountMaxScopesItem SellingPricesWrite =
        new(Values.SellingPricesWrite);

    public static readonly CreatePlatformPracticeApiKeyResponseServiceAccountMaxScopesItem CatalogPricingRead =
        new(Values.CatalogPricingRead);

    public static readonly CreatePlatformPracticeApiKeyResponseServiceAccountMaxScopesItem CatalogPricingWrite =
        new(Values.CatalogPricingWrite);

    public static readonly CreatePlatformPracticeApiKeyResponseServiceAccountMaxScopesItem FormulationDefaultsRead =
        new(Values.FormulationDefaultsRead);

    public static readonly CreatePlatformPracticeApiKeyResponseServiceAccountMaxScopesItem FormulationDefaultsWrite =
        new(Values.FormulationDefaultsWrite);

    public static readonly CreatePlatformPracticeApiKeyResponseServiceAccountMaxScopesItem PracticesRead =
        new(Values.PracticesRead);

    public static readonly CreatePlatformPracticeApiKeyResponseServiceAccountMaxScopesItem PracticesWrite =
        new(Values.PracticesWrite);

    public static readonly CreatePlatformPracticeApiKeyResponseServiceAccountMaxScopesItem ServiceKeysWrite =
        new(Values.ServiceKeysWrite);

    public static readonly CreatePlatformPracticeApiKeyResponseServiceAccountMaxScopesItem LocationsRead =
        new(Values.LocationsRead);

    public static readonly CreatePlatformPracticeApiKeyResponseServiceAccountMaxScopesItem LocationsWrite =
        new(Values.LocationsWrite);

    public static readonly CreatePlatformPracticeApiKeyResponseServiceAccountMaxScopesItem OrdersRead =
        new(Values.OrdersRead);

    public static readonly CreatePlatformPracticeApiKeyResponseServiceAccountMaxScopesItem OrdersWrite =
        new(Values.OrdersWrite);

    public static readonly CreatePlatformPracticeApiKeyResponseServiceAccountMaxScopesItem OrdersSign =
        new(Values.OrdersSign);

    public static readonly CreatePlatformPracticeApiKeyResponseServiceAccountMaxScopesItem PatientsRead =
        new(Values.PatientsRead);

    public static readonly CreatePlatformPracticeApiKeyResponseServiceAccountMaxScopesItem PatientsWrite =
        new(Values.PatientsWrite);

    public static readonly CreatePlatformPracticeApiKeyResponseServiceAccountMaxScopesItem TeamRead =
        new(Values.TeamRead);

    public static readonly CreatePlatformPracticeApiKeyResponseServiceAccountMaxScopesItem TeamWrite =
        new(Values.TeamWrite);

    public static readonly CreatePlatformPracticeApiKeyResponseServiceAccountMaxScopesItem HostedSessionsWrite =
        new(Values.HostedSessionsWrite);

    public static readonly CreatePlatformPracticeApiKeyResponseServiceAccountMaxScopesItem WebhooksRead =
        new(Values.WebhooksRead);

    public static readonly CreatePlatformPracticeApiKeyResponseServiceAccountMaxScopesItem WebhooksWrite =
        new(Values.WebhooksWrite);

    public CreatePlatformPracticeApiKeyResponseServiceAccountMaxScopesItem(string value)
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
    public static CreatePlatformPracticeApiKeyResponseServiceAccountMaxScopesItem FromCustom(
        string value
    )
    {
        return new CreatePlatformPracticeApiKeyResponseServiceAccountMaxScopesItem(value);
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
        CreatePlatformPracticeApiKeyResponseServiceAccountMaxScopesItem value1,
        string value2
    ) => value1.Value.Equals(value2);

    public static bool operator !=(
        CreatePlatformPracticeApiKeyResponseServiceAccountMaxScopesItem value1,
        string value2
    ) => !value1.Value.Equals(value2);

    public static explicit operator string(
        CreatePlatformPracticeApiKeyResponseServiceAccountMaxScopesItem value
    ) => value.Value;

    public static explicit operator CreatePlatformPracticeApiKeyResponseServiceAccountMaxScopesItem(
        string value
    ) => new(value);

    internal class CreatePlatformPracticeApiKeyResponseServiceAccountMaxScopesItemSerializer
        : JsonConverter<CreatePlatformPracticeApiKeyResponseServiceAccountMaxScopesItem>
    {
        public override CreatePlatformPracticeApiKeyResponseServiceAccountMaxScopesItem Read(
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
            return new CreatePlatformPracticeApiKeyResponseServiceAccountMaxScopesItem(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            CreatePlatformPracticeApiKeyResponseServiceAccountMaxScopesItem value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override CreatePlatformPracticeApiKeyResponseServiceAccountMaxScopesItem ReadAsPropertyName(
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
            return new CreatePlatformPracticeApiKeyResponseServiceAccountMaxScopesItem(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            CreatePlatformPracticeApiKeyResponseServiceAccountMaxScopesItem value,
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
