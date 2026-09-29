// ReSharper disable NullableWarningSuppressionIsUsed
// ReSharper disable InconsistentNaming

using Affinity.Core;
using global::System.Text.Json;
using global::System.Text.Json.Nodes;
using global::System.Text.Json.Serialization;

namespace Affinity;

[JsonConverter(typeof(ListCatalogItemsResponseDataItemPricingBasis.JsonConverter))]
[Serializable]
public record ListCatalogItemsResponseDataItemPricingBasis
{
    internal ListCatalogItemsResponseDataItemPricingBasis(string type, object? value)
    {
        Kind = type;
        Value = value;
    }

    /// <summary>
    /// Create an instance of ListCatalogItemsResponseDataItemPricingBasis with <see cref="ListCatalogItemsResponseDataItemPricingBasis.Item"/>.
    /// </summary>
    public ListCatalogItemsResponseDataItemPricingBasis(
        ListCatalogItemsResponseDataItemPricingBasis.Item value
    )
    {
        Kind = "item";
        Value = value.Value;
    }

    /// <summary>
    /// Create an instance of ListCatalogItemsResponseDataItemPricingBasis with <see cref="ListCatalogItemsResponseDataItemPricingBasis.Package"/>.
    /// </summary>
    public ListCatalogItemsResponseDataItemPricingBasis(
        ListCatalogItemsResponseDataItemPricingBasis.Package value
    )
    {
        Kind = "package";
        Value = value.Value;
    }

    /// <summary>
    /// Create an instance of ListCatalogItemsResponseDataItemPricingBasis with <see cref="ListCatalogItemsResponseDataItemPricingBasis.Unit"/>.
    /// </summary>
    public ListCatalogItemsResponseDataItemPricingBasis(
        ListCatalogItemsResponseDataItemPricingBasis.Unit value
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
    /// Returns the value as a <see cref="Affinity.ListCatalogItemsResponseDataItemPricingBasisItem"/> if <see cref="Kind"/> is 'item', otherwise throws an exception.
    /// </summary>
    /// <exception cref="Exception">Thrown when <see cref="Kind"/> is not 'item'.</exception>
    public Affinity.ListCatalogItemsResponseDataItemPricingBasisItem AsItem() =>
        IsItem
            ? (Affinity.ListCatalogItemsResponseDataItemPricingBasisItem)Value!
            : throw new global::System.Exception(
                "ListCatalogItemsResponseDataItemPricingBasis.Kind is not 'item'"
            );

    /// <summary>
    /// Returns the value as a <see cref="Affinity.ListCatalogItemsResponseDataItemPricingBasisPackage"/> if <see cref="Kind"/> is 'package', otherwise throws an exception.
    /// </summary>
    /// <exception cref="Exception">Thrown when <see cref="Kind"/> is not 'package'.</exception>
    public Affinity.ListCatalogItemsResponseDataItemPricingBasisPackage AsPackage() =>
        IsPackage
            ? (Affinity.ListCatalogItemsResponseDataItemPricingBasisPackage)Value!
            : throw new global::System.Exception(
                "ListCatalogItemsResponseDataItemPricingBasis.Kind is not 'package'"
            );

    /// <summary>
    /// Returns the value as a <see cref="Affinity.ListCatalogItemsResponseDataItemPricingBasisUnit"/> if <see cref="Kind"/> is 'unit', otherwise throws an exception.
    /// </summary>
    /// <exception cref="Exception">Thrown when <see cref="Kind"/> is not 'unit'.</exception>
    public Affinity.ListCatalogItemsResponseDataItemPricingBasisUnit AsUnit() =>
        IsUnit
            ? (Affinity.ListCatalogItemsResponseDataItemPricingBasisUnit)Value!
            : throw new global::System.Exception(
                "ListCatalogItemsResponseDataItemPricingBasis.Kind is not 'unit'"
            );

    public T Match<T>(
        Func<Affinity.ListCatalogItemsResponseDataItemPricingBasisItem, T> onItem,
        Func<Affinity.ListCatalogItemsResponseDataItemPricingBasisPackage, T> onPackage,
        Func<Affinity.ListCatalogItemsResponseDataItemPricingBasisUnit, T> onUnit,
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
        Action<Affinity.ListCatalogItemsResponseDataItemPricingBasisItem> onItem,
        Action<Affinity.ListCatalogItemsResponseDataItemPricingBasisPackage> onPackage,
        Action<Affinity.ListCatalogItemsResponseDataItemPricingBasisUnit> onUnit,
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
    /// Attempts to cast the value to a <see cref="Affinity.ListCatalogItemsResponseDataItemPricingBasisItem"/> and returns true if successful.
    /// </summary>
    public bool TryAsItem(out Affinity.ListCatalogItemsResponseDataItemPricingBasisItem? value)
    {
        if (Kind == "item")
        {
            value = (Affinity.ListCatalogItemsResponseDataItemPricingBasisItem)Value!;
            return true;
        }
        value = null;
        return false;
    }

    /// <summary>
    /// Attempts to cast the value to a <see cref="Affinity.ListCatalogItemsResponseDataItemPricingBasisPackage"/> and returns true if successful.
    /// </summary>
    public bool TryAsPackage(
        out Affinity.ListCatalogItemsResponseDataItemPricingBasisPackage? value
    )
    {
        if (Kind == "package")
        {
            value = (Affinity.ListCatalogItemsResponseDataItemPricingBasisPackage)Value!;
            return true;
        }
        value = null;
        return false;
    }

    /// <summary>
    /// Attempts to cast the value to a <see cref="Affinity.ListCatalogItemsResponseDataItemPricingBasisUnit"/> and returns true if successful.
    /// </summary>
    public bool TryAsUnit(out Affinity.ListCatalogItemsResponseDataItemPricingBasisUnit? value)
    {
        if (Kind == "unit")
        {
            value = (Affinity.ListCatalogItemsResponseDataItemPricingBasisUnit)Value!;
            return true;
        }
        value = null;
        return false;
    }

    public override string ToString() => JsonUtils.Serialize(this);

    public static implicit operator ListCatalogItemsResponseDataItemPricingBasis(
        ListCatalogItemsResponseDataItemPricingBasis.Item value
    ) => new(value);

    public static implicit operator ListCatalogItemsResponseDataItemPricingBasis(
        ListCatalogItemsResponseDataItemPricingBasis.Package value
    ) => new(value);

    public static implicit operator ListCatalogItemsResponseDataItemPricingBasis(
        ListCatalogItemsResponseDataItemPricingBasis.Unit value
    ) => new(value);

    [Serializable]
    internal sealed class JsonConverter
        : JsonConverter<ListCatalogItemsResponseDataItemPricingBasis>
    {
        public override bool CanConvert(global::System.Type typeToConvert) =>
            typeof(ListCatalogItemsResponseDataItemPricingBasis).IsAssignableFrom(typeToConvert);

        public override ListCatalogItemsResponseDataItemPricingBasis Read(
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
                    jsonWithoutDiscriminator.Deserialize<Affinity.ListCatalogItemsResponseDataItemPricingBasisItem?>(
                        options
                    )
                        ?? throw new JsonException(
                            "Failed to deserialize Affinity.ListCatalogItemsResponseDataItemPricingBasisItem"
                        ),
                "package" =>
                    jsonWithoutDiscriminator.Deserialize<Affinity.ListCatalogItemsResponseDataItemPricingBasisPackage?>(
                        options
                    )
                        ?? throw new JsonException(
                            "Failed to deserialize Affinity.ListCatalogItemsResponseDataItemPricingBasisPackage"
                        ),
                "unit" =>
                    jsonWithoutDiscriminator.Deserialize<Affinity.ListCatalogItemsResponseDataItemPricingBasisUnit?>(
                        options
                    )
                        ?? throw new JsonException(
                            "Failed to deserialize Affinity.ListCatalogItemsResponseDataItemPricingBasisUnit"
                        ),
                _ => json.Deserialize<object?>(options),
            };
            return new ListCatalogItemsResponseDataItemPricingBasis(discriminator, value);
        }

        public override void Write(
            Utf8JsonWriter writer,
            ListCatalogItemsResponseDataItemPricingBasis value,
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

        public override ListCatalogItemsResponseDataItemPricingBasis ReadAsPropertyName(
            ref Utf8JsonReader reader,
            global::System.Type typeToConvert,
            JsonSerializerOptions options
        )
        {
            var stringValue =
                reader.GetString()
                ?? throw new JsonException("The JSON property name could not be read as a string.");
            return new ListCatalogItemsResponseDataItemPricingBasis(stringValue, stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            ListCatalogItemsResponseDataItemPricingBasis value,
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
        public Item(Affinity.ListCatalogItemsResponseDataItemPricingBasisItem value)
        {
            Value = value;
        }

        internal Affinity.ListCatalogItemsResponseDataItemPricingBasisItem Value { get; set; }

        public override string ToString() => Value.ToString() ?? "null";

        public static implicit operator ListCatalogItemsResponseDataItemPricingBasis.Item(
            Affinity.ListCatalogItemsResponseDataItemPricingBasisItem value
        ) => new(value);
    }

    /// <summary>
    /// Discriminated union type for package
    /// </summary>
    [Serializable]
    public struct Package
    {
        public Package(Affinity.ListCatalogItemsResponseDataItemPricingBasisPackage value)
        {
            Value = value;
        }

        internal Affinity.ListCatalogItemsResponseDataItemPricingBasisPackage Value { get; set; }

        public override string ToString() => Value.ToString() ?? "null";

        public static implicit operator ListCatalogItemsResponseDataItemPricingBasis.Package(
            Affinity.ListCatalogItemsResponseDataItemPricingBasisPackage value
        ) => new(value);
    }

    /// <summary>
    /// Discriminated union type for unit
    /// </summary>
    [Serializable]
    public struct Unit
    {
        public Unit(Affinity.ListCatalogItemsResponseDataItemPricingBasisUnit value)
        {
            Value = value;
        }

        internal Affinity.ListCatalogItemsResponseDataItemPricingBasisUnit Value { get; set; }

        public override string ToString() => Value.ToString() ?? "null";

        public static implicit operator ListCatalogItemsResponseDataItemPricingBasis.Unit(
            Affinity.ListCatalogItemsResponseDataItemPricingBasisUnit value
        ) => new(value);
    }
}
