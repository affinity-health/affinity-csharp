// ReSharper disable NullableWarningSuppressionIsUsed
// ReSharper disable InconsistentNaming

using Affinity.Core;
using global::System.Text.Json;
using global::System.Text.Json.Nodes;
using global::System.Text.Json.Serialization;

namespace Affinity;

[JsonConverter(typeof(PlatformPublicApiSellingPricesReadSellingPriceResponseBasis.JsonConverter))]
[Serializable]
public record PlatformPublicApiSellingPricesReadSellingPriceResponseBasis
{
    internal PlatformPublicApiSellingPricesReadSellingPriceResponseBasis(string type, object? value)
    {
        Kind = type;
        Value = value;
    }

    /// <summary>
    /// Create an instance of PlatformPublicApiSellingPricesReadSellingPriceResponseBasis with <see cref="PlatformPublicApiSellingPricesReadSellingPriceResponseBasis.Item"/>.
    /// </summary>
    public PlatformPublicApiSellingPricesReadSellingPriceResponseBasis(
        PlatformPublicApiSellingPricesReadSellingPriceResponseBasis.Item value
    )
    {
        Kind = "item";
        Value = value.Value;
    }

    /// <summary>
    /// Create an instance of PlatformPublicApiSellingPricesReadSellingPriceResponseBasis with <see cref="PlatformPublicApiSellingPricesReadSellingPriceResponseBasis.Package"/>.
    /// </summary>
    public PlatformPublicApiSellingPricesReadSellingPriceResponseBasis(
        PlatformPublicApiSellingPricesReadSellingPriceResponseBasis.Package value
    )
    {
        Kind = "package";
        Value = value.Value;
    }

    /// <summary>
    /// Create an instance of PlatformPublicApiSellingPricesReadSellingPriceResponseBasis with <see cref="PlatformPublicApiSellingPricesReadSellingPriceResponseBasis.Unit"/>.
    /// </summary>
    public PlatformPublicApiSellingPricesReadSellingPriceResponseBasis(
        PlatformPublicApiSellingPricesReadSellingPriceResponseBasis.Unit value
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
    /// Returns the value as a <see cref="Affinity.PlatformPublicApiSellingPricesReadSellingPriceResponseBasisItem"/> if <see cref="Kind"/> is 'item', otherwise throws an exception.
    /// </summary>
    /// <exception cref="Exception">Thrown when <see cref="Kind"/> is not 'item'.</exception>
    public Affinity.PlatformPublicApiSellingPricesReadSellingPriceResponseBasisItem AsItem() =>
        IsItem
            ? (Affinity.PlatformPublicApiSellingPricesReadSellingPriceResponseBasisItem)Value!
            : throw new global::System.Exception(
                "PlatformPublicApiSellingPricesReadSellingPriceResponseBasis.Kind is not 'item'"
            );

    /// <summary>
    /// Returns the value as a <see cref="Affinity.PlatformPublicApiSellingPricesReadSellingPriceResponseBasisPackage"/> if <see cref="Kind"/> is 'package', otherwise throws an exception.
    /// </summary>
    /// <exception cref="Exception">Thrown when <see cref="Kind"/> is not 'package'.</exception>
    public Affinity.PlatformPublicApiSellingPricesReadSellingPriceResponseBasisPackage AsPackage() =>
        IsPackage
            ? (Affinity.PlatformPublicApiSellingPricesReadSellingPriceResponseBasisPackage)Value!
            : throw new global::System.Exception(
                "PlatformPublicApiSellingPricesReadSellingPriceResponseBasis.Kind is not 'package'"
            );

    /// <summary>
    /// Returns the value as a <see cref="Affinity.PlatformPublicApiSellingPricesReadSellingPriceResponseBasisUnit"/> if <see cref="Kind"/> is 'unit', otherwise throws an exception.
    /// </summary>
    /// <exception cref="Exception">Thrown when <see cref="Kind"/> is not 'unit'.</exception>
    public Affinity.PlatformPublicApiSellingPricesReadSellingPriceResponseBasisUnit AsUnit() =>
        IsUnit
            ? (Affinity.PlatformPublicApiSellingPricesReadSellingPriceResponseBasisUnit)Value!
            : throw new global::System.Exception(
                "PlatformPublicApiSellingPricesReadSellingPriceResponseBasis.Kind is not 'unit'"
            );

    public T Match<T>(
        Func<Affinity.PlatformPublicApiSellingPricesReadSellingPriceResponseBasisItem, T> onItem,
        Func<
            Affinity.PlatformPublicApiSellingPricesReadSellingPriceResponseBasisPackage,
            T
        > onPackage,
        Func<Affinity.PlatformPublicApiSellingPricesReadSellingPriceResponseBasisUnit, T> onUnit,
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
        Action<Affinity.PlatformPublicApiSellingPricesReadSellingPriceResponseBasisItem> onItem,
        Action<Affinity.PlatformPublicApiSellingPricesReadSellingPriceResponseBasisPackage> onPackage,
        Action<Affinity.PlatformPublicApiSellingPricesReadSellingPriceResponseBasisUnit> onUnit,
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
    /// Attempts to cast the value to a <see cref="Affinity.PlatformPublicApiSellingPricesReadSellingPriceResponseBasisItem"/> and returns true if successful.
    /// </summary>
    public bool TryAsItem(
        out Affinity.PlatformPublicApiSellingPricesReadSellingPriceResponseBasisItem? value
    )
    {
        if (Kind == "item")
        {
            value = (Affinity.PlatformPublicApiSellingPricesReadSellingPriceResponseBasisItem)
                Value!;
            return true;
        }
        value = null;
        return false;
    }

    /// <summary>
    /// Attempts to cast the value to a <see cref="Affinity.PlatformPublicApiSellingPricesReadSellingPriceResponseBasisPackage"/> and returns true if successful.
    /// </summary>
    public bool TryAsPackage(
        out Affinity.PlatformPublicApiSellingPricesReadSellingPriceResponseBasisPackage? value
    )
    {
        if (Kind == "package")
        {
            value = (Affinity.PlatformPublicApiSellingPricesReadSellingPriceResponseBasisPackage)
                Value!;
            return true;
        }
        value = null;
        return false;
    }

    /// <summary>
    /// Attempts to cast the value to a <see cref="Affinity.PlatformPublicApiSellingPricesReadSellingPriceResponseBasisUnit"/> and returns true if successful.
    /// </summary>
    public bool TryAsUnit(
        out Affinity.PlatformPublicApiSellingPricesReadSellingPriceResponseBasisUnit? value
    )
    {
        if (Kind == "unit")
        {
            value = (Affinity.PlatformPublicApiSellingPricesReadSellingPriceResponseBasisUnit)
                Value!;
            return true;
        }
        value = null;
        return false;
    }

    public override string ToString() => JsonUtils.Serialize(this);

    public static implicit operator PlatformPublicApiSellingPricesReadSellingPriceResponseBasis(
        PlatformPublicApiSellingPricesReadSellingPriceResponseBasis.Item value
    ) => new(value);

    public static implicit operator PlatformPublicApiSellingPricesReadSellingPriceResponseBasis(
        PlatformPublicApiSellingPricesReadSellingPriceResponseBasis.Package value
    ) => new(value);

    public static implicit operator PlatformPublicApiSellingPricesReadSellingPriceResponseBasis(
        PlatformPublicApiSellingPricesReadSellingPriceResponseBasis.Unit value
    ) => new(value);

    [Serializable]
    internal sealed class JsonConverter
        : JsonConverter<PlatformPublicApiSellingPricesReadSellingPriceResponseBasis>
    {
        public override bool CanConvert(global::System.Type typeToConvert) =>
            typeof(PlatformPublicApiSellingPricesReadSellingPriceResponseBasis).IsAssignableFrom(
                typeToConvert
            );

        public override PlatformPublicApiSellingPricesReadSellingPriceResponseBasis Read(
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
                    jsonWithoutDiscriminator.Deserialize<Affinity.PlatformPublicApiSellingPricesReadSellingPriceResponseBasisItem?>(
                        options
                    )
                        ?? throw new JsonException(
                            "Failed to deserialize Affinity.PlatformPublicApiSellingPricesReadSellingPriceResponseBasisItem"
                        ),
                "package" =>
                    jsonWithoutDiscriminator.Deserialize<Affinity.PlatformPublicApiSellingPricesReadSellingPriceResponseBasisPackage?>(
                        options
                    )
                        ?? throw new JsonException(
                            "Failed to deserialize Affinity.PlatformPublicApiSellingPricesReadSellingPriceResponseBasisPackage"
                        ),
                "unit" =>
                    jsonWithoutDiscriminator.Deserialize<Affinity.PlatformPublicApiSellingPricesReadSellingPriceResponseBasisUnit?>(
                        options
                    )
                        ?? throw new JsonException(
                            "Failed to deserialize Affinity.PlatformPublicApiSellingPricesReadSellingPriceResponseBasisUnit"
                        ),
                _ => json.Deserialize<object?>(options),
            };
            return new PlatformPublicApiSellingPricesReadSellingPriceResponseBasis(
                discriminator,
                value
            );
        }

        public override void Write(
            Utf8JsonWriter writer,
            PlatformPublicApiSellingPricesReadSellingPriceResponseBasis value,
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

        public override PlatformPublicApiSellingPricesReadSellingPriceResponseBasis ReadAsPropertyName(
            ref Utf8JsonReader reader,
            global::System.Type typeToConvert,
            JsonSerializerOptions options
        )
        {
            var stringValue =
                reader.GetString()
                ?? throw new JsonException("The JSON property name could not be read as a string.");
            return new PlatformPublicApiSellingPricesReadSellingPriceResponseBasis(
                stringValue,
                stringValue
            );
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            PlatformPublicApiSellingPricesReadSellingPriceResponseBasis value,
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
        public Item(Affinity.PlatformPublicApiSellingPricesReadSellingPriceResponseBasisItem value)
        {
            Value = value;
        }

        internal Affinity.PlatformPublicApiSellingPricesReadSellingPriceResponseBasisItem Value { get; set; }

        public override string ToString() => Value.ToString() ?? "null";

        public static implicit operator PlatformPublicApiSellingPricesReadSellingPriceResponseBasis.Item(
            Affinity.PlatformPublicApiSellingPricesReadSellingPriceResponseBasisItem value
        ) => new(value);
    }

    /// <summary>
    /// Discriminated union type for package
    /// </summary>
    [Serializable]
    public struct Package
    {
        public Package(
            Affinity.PlatformPublicApiSellingPricesReadSellingPriceResponseBasisPackage value
        )
        {
            Value = value;
        }

        internal Affinity.PlatformPublicApiSellingPricesReadSellingPriceResponseBasisPackage Value { get; set; }

        public override string ToString() => Value.ToString() ?? "null";

        public static implicit operator PlatformPublicApiSellingPricesReadSellingPriceResponseBasis.Package(
            Affinity.PlatformPublicApiSellingPricesReadSellingPriceResponseBasisPackage value
        ) => new(value);
    }

    /// <summary>
    /// Discriminated union type for unit
    /// </summary>
    [Serializable]
    public struct Unit
    {
        public Unit(Affinity.PlatformPublicApiSellingPricesReadSellingPriceResponseBasisUnit value)
        {
            Value = value;
        }

        internal Affinity.PlatformPublicApiSellingPricesReadSellingPriceResponseBasisUnit Value { get; set; }

        public override string ToString() => Value.ToString() ?? "null";

        public static implicit operator PlatformPublicApiSellingPricesReadSellingPriceResponseBasis.Unit(
            Affinity.PlatformPublicApiSellingPricesReadSellingPriceResponseBasisUnit value
        ) => new(value);
    }
}
