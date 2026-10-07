// ReSharper disable NullableWarningSuppressionIsUsed
// ReSharper disable InconsistentNaming

using Affinity.Core;
using global::System.Text.Json;
using global::System.Text.Json.Nodes;
using global::System.Text.Json.Serialization;

namespace Affinity;

[JsonConverter(
    typeof(PlatformPublicApiSellingPricesReadPresentationPriceResponseAffinityBasis.JsonConverter)
)]
[Serializable]
public record PlatformPublicApiSellingPricesReadPresentationPriceResponseAffinityBasis
{
    internal PlatformPublicApiSellingPricesReadPresentationPriceResponseAffinityBasis(
        string type,
        object? value
    )
    {
        Kind = type;
        Value = value;
    }

    /// <summary>
    /// Create an instance of PlatformPublicApiSellingPricesReadPresentationPriceResponseAffinityBasis with <see cref="PlatformPublicApiSellingPricesReadPresentationPriceResponseAffinityBasis.Item"/>.
    /// </summary>
    public PlatformPublicApiSellingPricesReadPresentationPriceResponseAffinityBasis(
        PlatformPublicApiSellingPricesReadPresentationPriceResponseAffinityBasis.Item value
    )
    {
        Kind = "item";
        Value = value.Value;
    }

    /// <summary>
    /// Create an instance of PlatformPublicApiSellingPricesReadPresentationPriceResponseAffinityBasis with <see cref="PlatformPublicApiSellingPricesReadPresentationPriceResponseAffinityBasis.Package"/>.
    /// </summary>
    public PlatformPublicApiSellingPricesReadPresentationPriceResponseAffinityBasis(
        PlatformPublicApiSellingPricesReadPresentationPriceResponseAffinityBasis.Package value
    )
    {
        Kind = "package";
        Value = value.Value;
    }

    /// <summary>
    /// Create an instance of PlatformPublicApiSellingPricesReadPresentationPriceResponseAffinityBasis with <see cref="PlatformPublicApiSellingPricesReadPresentationPriceResponseAffinityBasis.Unit"/>.
    /// </summary>
    public PlatformPublicApiSellingPricesReadPresentationPriceResponseAffinityBasis(
        PlatformPublicApiSellingPricesReadPresentationPriceResponseAffinityBasis.Unit value
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
    /// Returns the value as a <see cref="Affinity.PlatformPublicApiSellingPricesReadPresentationPriceResponseAffinityBasisItem"/> if <see cref="Kind"/> is 'item', otherwise throws an exception.
    /// </summary>
    /// <exception cref="Exception">Thrown when <see cref="Kind"/> is not 'item'.</exception>
    public Affinity.PlatformPublicApiSellingPricesReadPresentationPriceResponseAffinityBasisItem AsItem() =>
        IsItem
            ? (Affinity.PlatformPublicApiSellingPricesReadPresentationPriceResponseAffinityBasisItem)
                Value!
            : throw new global::System.Exception(
                "PlatformPublicApiSellingPricesReadPresentationPriceResponseAffinityBasis.Kind is not 'item'"
            );

    /// <summary>
    /// Returns the value as a <see cref="Affinity.PlatformPublicApiSellingPricesReadPresentationPriceResponseAffinityBasisPackage"/> if <see cref="Kind"/> is 'package', otherwise throws an exception.
    /// </summary>
    /// <exception cref="Exception">Thrown when <see cref="Kind"/> is not 'package'.</exception>
    public Affinity.PlatformPublicApiSellingPricesReadPresentationPriceResponseAffinityBasisPackage AsPackage() =>
        IsPackage
            ? (Affinity.PlatformPublicApiSellingPricesReadPresentationPriceResponseAffinityBasisPackage)
                Value!
            : throw new global::System.Exception(
                "PlatformPublicApiSellingPricesReadPresentationPriceResponseAffinityBasis.Kind is not 'package'"
            );

    /// <summary>
    /// Returns the value as a <see cref="Affinity.PlatformPublicApiSellingPricesReadPresentationPriceResponseAffinityBasisUnit"/> if <see cref="Kind"/> is 'unit', otherwise throws an exception.
    /// </summary>
    /// <exception cref="Exception">Thrown when <see cref="Kind"/> is not 'unit'.</exception>
    public Affinity.PlatformPublicApiSellingPricesReadPresentationPriceResponseAffinityBasisUnit AsUnit() =>
        IsUnit
            ? (Affinity.PlatformPublicApiSellingPricesReadPresentationPriceResponseAffinityBasisUnit)
                Value!
            : throw new global::System.Exception(
                "PlatformPublicApiSellingPricesReadPresentationPriceResponseAffinityBasis.Kind is not 'unit'"
            );

    public T Match<T>(
        Func<
            Affinity.PlatformPublicApiSellingPricesReadPresentationPriceResponseAffinityBasisItem,
            T
        > onItem,
        Func<
            Affinity.PlatformPublicApiSellingPricesReadPresentationPriceResponseAffinityBasisPackage,
            T
        > onPackage,
        Func<
            Affinity.PlatformPublicApiSellingPricesReadPresentationPriceResponseAffinityBasisUnit,
            T
        > onUnit,
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
        Action<Affinity.PlatformPublicApiSellingPricesReadPresentationPriceResponseAffinityBasisItem> onItem,
        Action<Affinity.PlatformPublicApiSellingPricesReadPresentationPriceResponseAffinityBasisPackage> onPackage,
        Action<Affinity.PlatformPublicApiSellingPricesReadPresentationPriceResponseAffinityBasisUnit> onUnit,
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
    /// Attempts to cast the value to a <see cref="Affinity.PlatformPublicApiSellingPricesReadPresentationPriceResponseAffinityBasisItem"/> and returns true if successful.
    /// </summary>
    public bool TryAsItem(
        out Affinity.PlatformPublicApiSellingPricesReadPresentationPriceResponseAffinityBasisItem? value
    )
    {
        if (Kind == "item")
        {
            value =
                (Affinity.PlatformPublicApiSellingPricesReadPresentationPriceResponseAffinityBasisItem)
                    Value!;
            return true;
        }
        value = null;
        return false;
    }

    /// <summary>
    /// Attempts to cast the value to a <see cref="Affinity.PlatformPublicApiSellingPricesReadPresentationPriceResponseAffinityBasisPackage"/> and returns true if successful.
    /// </summary>
    public bool TryAsPackage(
        out Affinity.PlatformPublicApiSellingPricesReadPresentationPriceResponseAffinityBasisPackage? value
    )
    {
        if (Kind == "package")
        {
            value =
                (Affinity.PlatformPublicApiSellingPricesReadPresentationPriceResponseAffinityBasisPackage)
                    Value!;
            return true;
        }
        value = null;
        return false;
    }

    /// <summary>
    /// Attempts to cast the value to a <see cref="Affinity.PlatformPublicApiSellingPricesReadPresentationPriceResponseAffinityBasisUnit"/> and returns true if successful.
    /// </summary>
    public bool TryAsUnit(
        out Affinity.PlatformPublicApiSellingPricesReadPresentationPriceResponseAffinityBasisUnit? value
    )
    {
        if (Kind == "unit")
        {
            value =
                (Affinity.PlatformPublicApiSellingPricesReadPresentationPriceResponseAffinityBasisUnit)
                    Value!;
            return true;
        }
        value = null;
        return false;
    }

    public override string ToString() => JsonUtils.Serialize(this);

    public static implicit operator PlatformPublicApiSellingPricesReadPresentationPriceResponseAffinityBasis(
        PlatformPublicApiSellingPricesReadPresentationPriceResponseAffinityBasis.Item value
    ) => new(value);

    public static implicit operator PlatformPublicApiSellingPricesReadPresentationPriceResponseAffinityBasis(
        PlatformPublicApiSellingPricesReadPresentationPriceResponseAffinityBasis.Package value
    ) => new(value);

    public static implicit operator PlatformPublicApiSellingPricesReadPresentationPriceResponseAffinityBasis(
        PlatformPublicApiSellingPricesReadPresentationPriceResponseAffinityBasis.Unit value
    ) => new(value);

    [Serializable]
    internal sealed class JsonConverter
        : JsonConverter<PlatformPublicApiSellingPricesReadPresentationPriceResponseAffinityBasis>
    {
        public override bool CanConvert(global::System.Type typeToConvert) =>
            typeof(PlatformPublicApiSellingPricesReadPresentationPriceResponseAffinityBasis).IsAssignableFrom(
                typeToConvert
            );

        public override PlatformPublicApiSellingPricesReadPresentationPriceResponseAffinityBasis Read(
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
                    jsonWithoutDiscriminator.Deserialize<Affinity.PlatformPublicApiSellingPricesReadPresentationPriceResponseAffinityBasisItem?>(
                        options
                    )
                        ?? throw new JsonException(
                            "Failed to deserialize Affinity.PlatformPublicApiSellingPricesReadPresentationPriceResponseAffinityBasisItem"
                        ),
                "package" =>
                    jsonWithoutDiscriminator.Deserialize<Affinity.PlatformPublicApiSellingPricesReadPresentationPriceResponseAffinityBasisPackage?>(
                        options
                    )
                        ?? throw new JsonException(
                            "Failed to deserialize Affinity.PlatformPublicApiSellingPricesReadPresentationPriceResponseAffinityBasisPackage"
                        ),
                "unit" =>
                    jsonWithoutDiscriminator.Deserialize<Affinity.PlatformPublicApiSellingPricesReadPresentationPriceResponseAffinityBasisUnit?>(
                        options
                    )
                        ?? throw new JsonException(
                            "Failed to deserialize Affinity.PlatformPublicApiSellingPricesReadPresentationPriceResponseAffinityBasisUnit"
                        ),
                _ => json.Deserialize<object?>(options),
            };
            return new PlatformPublicApiSellingPricesReadPresentationPriceResponseAffinityBasis(
                discriminator,
                value
            );
        }

        public override void Write(
            Utf8JsonWriter writer,
            PlatformPublicApiSellingPricesReadPresentationPriceResponseAffinityBasis value,
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

        public override PlatformPublicApiSellingPricesReadPresentationPriceResponseAffinityBasis ReadAsPropertyName(
            ref Utf8JsonReader reader,
            global::System.Type typeToConvert,
            JsonSerializerOptions options
        )
        {
            var stringValue =
                reader.GetString()
                ?? throw new JsonException("The JSON property name could not be read as a string.");
            return new PlatformPublicApiSellingPricesReadPresentationPriceResponseAffinityBasis(
                stringValue,
                stringValue
            );
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            PlatformPublicApiSellingPricesReadPresentationPriceResponseAffinityBasis value,
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
        public Item(
            Affinity.PlatformPublicApiSellingPricesReadPresentationPriceResponseAffinityBasisItem value
        )
        {
            Value = value;
        }

        internal Affinity.PlatformPublicApiSellingPricesReadPresentationPriceResponseAffinityBasisItem Value { get; set; }

        public override string ToString() => Value.ToString() ?? "null";

        public static implicit operator PlatformPublicApiSellingPricesReadPresentationPriceResponseAffinityBasis.Item(
            Affinity.PlatformPublicApiSellingPricesReadPresentationPriceResponseAffinityBasisItem value
        ) => new(value);
    }

    /// <summary>
    /// Discriminated union type for package
    /// </summary>
    [Serializable]
    public struct Package
    {
        public Package(
            Affinity.PlatformPublicApiSellingPricesReadPresentationPriceResponseAffinityBasisPackage value
        )
        {
            Value = value;
        }

        internal Affinity.PlatformPublicApiSellingPricesReadPresentationPriceResponseAffinityBasisPackage Value { get; set; }

        public override string ToString() => Value.ToString() ?? "null";

        public static implicit operator PlatformPublicApiSellingPricesReadPresentationPriceResponseAffinityBasis.Package(
            Affinity.PlatformPublicApiSellingPricesReadPresentationPriceResponseAffinityBasisPackage value
        ) => new(value);
    }

    /// <summary>
    /// Discriminated union type for unit
    /// </summary>
    [Serializable]
    public struct Unit
    {
        public Unit(
            Affinity.PlatformPublicApiSellingPricesReadPresentationPriceResponseAffinityBasisUnit value
        )
        {
            Value = value;
        }

        internal Affinity.PlatformPublicApiSellingPricesReadPresentationPriceResponseAffinityBasisUnit Value { get; set; }

        public override string ToString() => Value.ToString() ?? "null";

        public static implicit operator PlatformPublicApiSellingPricesReadPresentationPriceResponseAffinityBasis.Unit(
            Affinity.PlatformPublicApiSellingPricesReadPresentationPriceResponseAffinityBasisUnit value
        ) => new(value);
    }
}
