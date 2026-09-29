// ReSharper disable NullableWarningSuppressionIsUsed
// ReSharper disable InconsistentNaming

using Affinity.Core;
using global::System.Text.Json;
using global::System.Text.Json.Nodes;
using global::System.Text.Json.Serialization;

namespace Affinity;

[JsonConverter(typeof(RetrievePrescribingOptionsResponseCatalogPricingBasis.JsonConverter))]
[Serializable]
public record RetrievePrescribingOptionsResponseCatalogPricingBasis
{
    internal RetrievePrescribingOptionsResponseCatalogPricingBasis(string type, object? value)
    {
        Kind = type;
        Value = value;
    }

    /// <summary>
    /// Create an instance of RetrievePrescribingOptionsResponseCatalogPricingBasis with <see cref="RetrievePrescribingOptionsResponseCatalogPricingBasis.Item"/>.
    /// </summary>
    public RetrievePrescribingOptionsResponseCatalogPricingBasis(
        RetrievePrescribingOptionsResponseCatalogPricingBasis.Item value
    )
    {
        Kind = "item";
        Value = value.Value;
    }

    /// <summary>
    /// Create an instance of RetrievePrescribingOptionsResponseCatalogPricingBasis with <see cref="RetrievePrescribingOptionsResponseCatalogPricingBasis.Package"/>.
    /// </summary>
    public RetrievePrescribingOptionsResponseCatalogPricingBasis(
        RetrievePrescribingOptionsResponseCatalogPricingBasis.Package value
    )
    {
        Kind = "package";
        Value = value.Value;
    }

    /// <summary>
    /// Create an instance of RetrievePrescribingOptionsResponseCatalogPricingBasis with <see cref="RetrievePrescribingOptionsResponseCatalogPricingBasis.Unit"/>.
    /// </summary>
    public RetrievePrescribingOptionsResponseCatalogPricingBasis(
        RetrievePrescribingOptionsResponseCatalogPricingBasis.Unit value
    )
    {
        Kind = "unit";
        Value = value.Value;
    }

    /// <summary>
    /// Discriminant value
    /// </summary>
    [JsonPropertyName("kind")]
    public string Kind { get; internal set; }

    /// <summary>
    /// Discriminated union value
    /// </summary>
    public object? Value { get; internal set; }

    /// <summary>
    /// Returns true if <see cref="Kind"/> is "item"
    /// </summary>
    public bool IsItem => Kind == "item";

    /// <summary>
    /// Returns true if <see cref="Kind"/> is "package"
    /// </summary>
    public bool IsPackage => Kind == "package";

    /// <summary>
    /// Returns true if <see cref="Kind"/> is "unit"
    /// </summary>
    public bool IsUnit => Kind == "unit";

    /// <summary>
    /// Returns the value as a <see cref="Affinity.RetrievePrescribingOptionsResponseCatalogPricingBasisItem"/> if <see cref="Kind"/> is 'item', otherwise throws an exception.
    /// </summary>
    /// <exception cref="Exception">Thrown when <see cref="Kind"/> is not 'item'.</exception>
    public Affinity.RetrievePrescribingOptionsResponseCatalogPricingBasisItem AsItem() =>
        IsItem
            ? (Affinity.RetrievePrescribingOptionsResponseCatalogPricingBasisItem)Value!
            : throw new global::System.Exception(
                "RetrievePrescribingOptionsResponseCatalogPricingBasis.Kind is not 'item'"
            );

    /// <summary>
    /// Returns the value as a <see cref="Affinity.RetrievePrescribingOptionsResponseCatalogPricingBasisPackage"/> if <see cref="Kind"/> is 'package', otherwise throws an exception.
    /// </summary>
    /// <exception cref="Exception">Thrown when <see cref="Kind"/> is not 'package'.</exception>
    public Affinity.RetrievePrescribingOptionsResponseCatalogPricingBasisPackage AsPackage() =>
        IsPackage
            ? (Affinity.RetrievePrescribingOptionsResponseCatalogPricingBasisPackage)Value!
            : throw new global::System.Exception(
                "RetrievePrescribingOptionsResponseCatalogPricingBasis.Kind is not 'package'"
            );

    /// <summary>
    /// Returns the value as a <see cref="Affinity.RetrievePrescribingOptionsResponseCatalogPricingBasisUnit"/> if <see cref="Kind"/> is 'unit', otherwise throws an exception.
    /// </summary>
    /// <exception cref="Exception">Thrown when <see cref="Kind"/> is not 'unit'.</exception>
    public Affinity.RetrievePrescribingOptionsResponseCatalogPricingBasisUnit AsUnit() =>
        IsUnit
            ? (Affinity.RetrievePrescribingOptionsResponseCatalogPricingBasisUnit)Value!
            : throw new global::System.Exception(
                "RetrievePrescribingOptionsResponseCatalogPricingBasis.Kind is not 'unit'"
            );

    public T Match<T>(
        Func<Affinity.RetrievePrescribingOptionsResponseCatalogPricingBasisItem, T> onItem,
        Func<Affinity.RetrievePrescribingOptionsResponseCatalogPricingBasisPackage, T> onPackage,
        Func<Affinity.RetrievePrescribingOptionsResponseCatalogPricingBasisUnit, T> onUnit,
        Func<string, object?, T> onUnknown_
    )
    {
        return Kind switch
        {
            "item" => onItem(AsItem()),
            "package" => onPackage(AsPackage()),
            "unit" => onUnit(AsUnit()),
            _ => onUnknown_(Kind, Value),
        };
    }

    public void Visit(
        Action<Affinity.RetrievePrescribingOptionsResponseCatalogPricingBasisItem> onItem,
        Action<Affinity.RetrievePrescribingOptionsResponseCatalogPricingBasisPackage> onPackage,
        Action<Affinity.RetrievePrescribingOptionsResponseCatalogPricingBasisUnit> onUnit,
        Action<string, object?> onUnknown_
    )
    {
        switch (Kind)
        {
            case "item":
                onItem(AsItem());
                break;
            case "package":
                onPackage(AsPackage());
                break;
            case "unit":
                onUnit(AsUnit());
                break;
            default:
                onUnknown_(Kind, Value);
                break;
        }
    }

    /// <summary>
    /// Attempts to cast the value to a <see cref="Affinity.RetrievePrescribingOptionsResponseCatalogPricingBasisItem"/> and returns true if successful.
    /// </summary>
    public bool TryAsItem(
        out Affinity.RetrievePrescribingOptionsResponseCatalogPricingBasisItem? value
    )
    {
        if (Kind == "item")
        {
            value = (Affinity.RetrievePrescribingOptionsResponseCatalogPricingBasisItem)Value!;
            return true;
        }
        value = null;
        return false;
    }

    /// <summary>
    /// Attempts to cast the value to a <see cref="Affinity.RetrievePrescribingOptionsResponseCatalogPricingBasisPackage"/> and returns true if successful.
    /// </summary>
    public bool TryAsPackage(
        out Affinity.RetrievePrescribingOptionsResponseCatalogPricingBasisPackage? value
    )
    {
        if (Kind == "package")
        {
            value = (Affinity.RetrievePrescribingOptionsResponseCatalogPricingBasisPackage)Value!;
            return true;
        }
        value = null;
        return false;
    }

    /// <summary>
    /// Attempts to cast the value to a <see cref="Affinity.RetrievePrescribingOptionsResponseCatalogPricingBasisUnit"/> and returns true if successful.
    /// </summary>
    public bool TryAsUnit(
        out Affinity.RetrievePrescribingOptionsResponseCatalogPricingBasisUnit? value
    )
    {
        if (Kind == "unit")
        {
            value = (Affinity.RetrievePrescribingOptionsResponseCatalogPricingBasisUnit)Value!;
            return true;
        }
        value = null;
        return false;
    }

    public override string ToString() => JsonUtils.Serialize(this);

    public static implicit operator RetrievePrescribingOptionsResponseCatalogPricingBasis(
        RetrievePrescribingOptionsResponseCatalogPricingBasis.Item value
    ) => new(value);

    public static implicit operator RetrievePrescribingOptionsResponseCatalogPricingBasis(
        RetrievePrescribingOptionsResponseCatalogPricingBasis.Package value
    ) => new(value);

    public static implicit operator RetrievePrescribingOptionsResponseCatalogPricingBasis(
        RetrievePrescribingOptionsResponseCatalogPricingBasis.Unit value
    ) => new(value);

    [Serializable]
    internal sealed class JsonConverter
        : JsonConverter<RetrievePrescribingOptionsResponseCatalogPricingBasis>
    {
        public override bool CanConvert(global::System.Type typeToConvert) =>
            typeof(RetrievePrescribingOptionsResponseCatalogPricingBasis).IsAssignableFrom(
                typeToConvert
            );

        public override RetrievePrescribingOptionsResponseCatalogPricingBasis Read(
            ref Utf8JsonReader reader,
            global::System.Type typeToConvert,
            JsonSerializerOptions options
        )
        {
            var json = JsonElement.ParseValue(ref reader);
            if (!json.TryGetProperty("kind", out var discriminatorElement))
            {
                throw new JsonException("Missing discriminator property 'kind'");
            }
            if (discriminatorElement.ValueKind != JsonValueKind.String)
            {
                if (discriminatorElement.ValueKind == JsonValueKind.Null)
                {
                    throw new JsonException("Discriminator property 'kind' is null");
                }

                throw new JsonException(
                    $"Discriminator property 'kind' is not a string, instead is {discriminatorElement.ToString()}"
                );
            }

            var discriminator =
                discriminatorElement.GetString()
                ?? throw new JsonException("Discriminator property 'kind' is null");

            // Strip the discriminant property to prevent it from leaking into AdditionalProperties
            var jsonObject = System.Text.Json.Nodes.JsonObject.Create(json);
            jsonObject?.Remove("kind");
            var jsonWithoutDiscriminator =
                jsonObject != null ? JsonSerializer.SerializeToElement(jsonObject, options) : json;

            var value = discriminator switch
            {
                "item" =>
                    jsonWithoutDiscriminator.Deserialize<Affinity.RetrievePrescribingOptionsResponseCatalogPricingBasisItem?>(
                        options
                    )
                        ?? throw new JsonException(
                            "Failed to deserialize Affinity.RetrievePrescribingOptionsResponseCatalogPricingBasisItem"
                        ),
                "package" =>
                    jsonWithoutDiscriminator.Deserialize<Affinity.RetrievePrescribingOptionsResponseCatalogPricingBasisPackage?>(
                        options
                    )
                        ?? throw new JsonException(
                            "Failed to deserialize Affinity.RetrievePrescribingOptionsResponseCatalogPricingBasisPackage"
                        ),
                "unit" =>
                    jsonWithoutDiscriminator.Deserialize<Affinity.RetrievePrescribingOptionsResponseCatalogPricingBasisUnit?>(
                        options
                    )
                        ?? throw new JsonException(
                            "Failed to deserialize Affinity.RetrievePrescribingOptionsResponseCatalogPricingBasisUnit"
                        ),
                _ => json.Deserialize<object?>(options),
            };
            return new RetrievePrescribingOptionsResponseCatalogPricingBasis(discriminator, value);
        }

        public override void Write(
            Utf8JsonWriter writer,
            RetrievePrescribingOptionsResponseCatalogPricingBasis value,
            JsonSerializerOptions options
        )
        {
            JsonNode json =
                value.Kind switch
                {
                    "item" => JsonSerializer.SerializeToNode(value.Value, options),
                    "package" => JsonSerializer.SerializeToNode(value.Value, options),
                    "unit" => JsonSerializer.SerializeToNode(value.Value, options),
                    _ => JsonSerializer.SerializeToNode(value.Value, options),
                } ?? new JsonObject();
            json["kind"] = value.Kind;
            json.WriteTo(writer, options);
        }

        public override RetrievePrescribingOptionsResponseCatalogPricingBasis ReadAsPropertyName(
            ref Utf8JsonReader reader,
            global::System.Type typeToConvert,
            JsonSerializerOptions options
        )
        {
            var stringValue =
                reader.GetString()
                ?? throw new JsonException("The JSON property name could not be read as a string.");
            return new RetrievePrescribingOptionsResponseCatalogPricingBasis(
                stringValue,
                stringValue
            );
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            RetrievePrescribingOptionsResponseCatalogPricingBasis value,
            JsonSerializerOptions options
        )
        {
            writer.WritePropertyName(value.Kind);
        }
    }

    /// <summary>
    /// Discriminated union type for item
    /// </summary>
    [Serializable]
    public struct Item
    {
        public Item(Affinity.RetrievePrescribingOptionsResponseCatalogPricingBasisItem value)
        {
            Value = value;
        }

        internal Affinity.RetrievePrescribingOptionsResponseCatalogPricingBasisItem Value { get; set; }

        public override string ToString() => Value.ToString() ?? "null";

        public static implicit operator RetrievePrescribingOptionsResponseCatalogPricingBasis.Item(
            Affinity.RetrievePrescribingOptionsResponseCatalogPricingBasisItem value
        ) => new(value);
    }

    /// <summary>
    /// Discriminated union type for package
    /// </summary>
    [Serializable]
    public struct Package
    {
        public Package(Affinity.RetrievePrescribingOptionsResponseCatalogPricingBasisPackage value)
        {
            Value = value;
        }

        internal Affinity.RetrievePrescribingOptionsResponseCatalogPricingBasisPackage Value { get; set; }

        public override string ToString() => Value.ToString() ?? "null";

        public static implicit operator RetrievePrescribingOptionsResponseCatalogPricingBasis.Package(
            Affinity.RetrievePrescribingOptionsResponseCatalogPricingBasisPackage value
        ) => new(value);
    }

    /// <summary>
    /// Discriminated union type for unit
    /// </summary>
    [Serializable]
    public struct Unit
    {
        public Unit(Affinity.RetrievePrescribingOptionsResponseCatalogPricingBasisUnit value)
        {
            Value = value;
        }

        internal Affinity.RetrievePrescribingOptionsResponseCatalogPricingBasisUnit Value { get; set; }

        public override string ToString() => Value.ToString() ?? "null";

        public static implicit operator RetrievePrescribingOptionsResponseCatalogPricingBasis.Unit(
            Affinity.RetrievePrescribingOptionsResponseCatalogPricingBasisUnit value
        ) => new(value);
    }
}
