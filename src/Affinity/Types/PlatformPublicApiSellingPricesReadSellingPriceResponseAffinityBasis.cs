// ReSharper disable NullableWarningSuppressionIsUsed
// ReSharper disable InconsistentNaming

using Affinity.Core;
using global::System.Text.Json;
using global::System.Text.Json.Nodes;
using global::System.Text.Json.Serialization;

namespace Affinity;

[JsonConverter(
    typeof(PlatformPublicApiSellingPricesReadSellingPriceResponseAffinityBasis.JsonConverter)
)]
[Serializable]
public record PlatformPublicApiSellingPricesReadSellingPriceResponseAffinityBasis
{
    internal PlatformPublicApiSellingPricesReadSellingPriceResponseAffinityBasis(
        string type,
        object? value
    )
    {
        Kind = type;
        Value = value;
    }

    /// <summary>
    /// Create an instance of PlatformPublicApiSellingPricesReadSellingPriceResponseAffinityBasis with <see cref="PlatformPublicApiSellingPricesReadSellingPriceResponseAffinityBasis.Item"/>.
    /// </summary>
    public PlatformPublicApiSellingPricesReadSellingPriceResponseAffinityBasis(
        PlatformPublicApiSellingPricesReadSellingPriceResponseAffinityBasis.Item value
    )
    {
        Kind = "item";
        Value = value.Value;
    }

    /// <summary>
    /// Create an instance of PlatformPublicApiSellingPricesReadSellingPriceResponseAffinityBasis with <see cref="PlatformPublicApiSellingPricesReadSellingPriceResponseAffinityBasis.Package"/>.
    /// </summary>
    public PlatformPublicApiSellingPricesReadSellingPriceResponseAffinityBasis(
        PlatformPublicApiSellingPricesReadSellingPriceResponseAffinityBasis.Package value
    )
    {
        Kind = "package";
        Value = value.Value;
    }

    /// <summary>
    /// Create an instance of PlatformPublicApiSellingPricesReadSellingPriceResponseAffinityBasis with <see cref="PlatformPublicApiSellingPricesReadSellingPriceResponseAffinityBasis.Unit"/>.
    /// </summary>
    public PlatformPublicApiSellingPricesReadSellingPriceResponseAffinityBasis(
        PlatformPublicApiSellingPricesReadSellingPriceResponseAffinityBasis.Unit value
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
    /// Returns the value as a <see cref="Affinity.PlatformPublicApiSellingPricesReadSellingPriceResponseAffinityBasisItem"/> if <see cref="Kind"/> is 'item', otherwise throws an exception.
    /// </summary>
    /// <exception cref="Exception">Thrown when <see cref="Kind"/> is not 'item'.</exception>
    public Affinity.PlatformPublicApiSellingPricesReadSellingPriceResponseAffinityBasisItem AsItem() =>
        IsItem
            ? (Affinity.PlatformPublicApiSellingPricesReadSellingPriceResponseAffinityBasisItem)
                Value!
            : throw new global::System.Exception(
                "PlatformPublicApiSellingPricesReadSellingPriceResponseAffinityBasis.Kind is not 'item'"
            );

    /// <summary>
    /// Returns the value as a <see cref="Affinity.PlatformPublicApiSellingPricesReadSellingPriceResponseAffinityBasisPackage"/> if <see cref="Kind"/> is 'package', otherwise throws an exception.
    /// </summary>
    /// <exception cref="Exception">Thrown when <see cref="Kind"/> is not 'package'.</exception>
    public Affinity.PlatformPublicApiSellingPricesReadSellingPriceResponseAffinityBasisPackage AsPackage() =>
        IsPackage
            ? (Affinity.PlatformPublicApiSellingPricesReadSellingPriceResponseAffinityBasisPackage)
                Value!
            : throw new global::System.Exception(
                "PlatformPublicApiSellingPricesReadSellingPriceResponseAffinityBasis.Kind is not 'package'"
            );

    /// <summary>
    /// Returns the value as a <see cref="Affinity.PlatformPublicApiSellingPricesReadSellingPriceResponseAffinityBasisUnit"/> if <see cref="Kind"/> is 'unit', otherwise throws an exception.
    /// </summary>
    /// <exception cref="Exception">Thrown when <see cref="Kind"/> is not 'unit'.</exception>
    public Affinity.PlatformPublicApiSellingPricesReadSellingPriceResponseAffinityBasisUnit AsUnit() =>
        IsUnit
            ? (Affinity.PlatformPublicApiSellingPricesReadSellingPriceResponseAffinityBasisUnit)
                Value!
            : throw new global::System.Exception(
                "PlatformPublicApiSellingPricesReadSellingPriceResponseAffinityBasis.Kind is not 'unit'"
            );

    public T Match<T>(
        Func<
            Affinity.PlatformPublicApiSellingPricesReadSellingPriceResponseAffinityBasisItem,
            T
        > onItem,
        Func<
            Affinity.PlatformPublicApiSellingPricesReadSellingPriceResponseAffinityBasisPackage,
            T
        > onPackage,
        Func<
            Affinity.PlatformPublicApiSellingPricesReadSellingPriceResponseAffinityBasisUnit,
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
        Action<Affinity.PlatformPublicApiSellingPricesReadSellingPriceResponseAffinityBasisItem> onItem,
        Action<Affinity.PlatformPublicApiSellingPricesReadSellingPriceResponseAffinityBasisPackage> onPackage,
        Action<Affinity.PlatformPublicApiSellingPricesReadSellingPriceResponseAffinityBasisUnit> onUnit,
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
    /// Attempts to cast the value to a <see cref="Affinity.PlatformPublicApiSellingPricesReadSellingPriceResponseAffinityBasisItem"/> and returns true if successful.
    /// </summary>
    public bool TryAsItem(
        out Affinity.PlatformPublicApiSellingPricesReadSellingPriceResponseAffinityBasisItem? value
    )
    {
        if (Kind == "item")
        {
            value =
                (Affinity.PlatformPublicApiSellingPricesReadSellingPriceResponseAffinityBasisItem)
                    Value!;
            return true;
        }
        value = null;
        return false;
    }

    /// <summary>
    /// Attempts to cast the value to a <see cref="Affinity.PlatformPublicApiSellingPricesReadSellingPriceResponseAffinityBasisPackage"/> and returns true if successful.
    /// </summary>
    public bool TryAsPackage(
        out Affinity.PlatformPublicApiSellingPricesReadSellingPriceResponseAffinityBasisPackage? value
    )
    {
        if (Kind == "package")
        {
            value =
                (Affinity.PlatformPublicApiSellingPricesReadSellingPriceResponseAffinityBasisPackage)
                    Value!;
            return true;
        }
        value = null;
        return false;
    }

    /// <summary>
    /// Attempts to cast the value to a <see cref="Affinity.PlatformPublicApiSellingPricesReadSellingPriceResponseAffinityBasisUnit"/> and returns true if successful.
    /// </summary>
    public bool TryAsUnit(
        out Affinity.PlatformPublicApiSellingPricesReadSellingPriceResponseAffinityBasisUnit? value
    )
    {
        if (Kind == "unit")
        {
            value =
                (Affinity.PlatformPublicApiSellingPricesReadSellingPriceResponseAffinityBasisUnit)
                    Value!;
            return true;
        }
        value = null;
        return false;
    }

    public override string ToString() => JsonUtils.Serialize(this);

    public static implicit operator PlatformPublicApiSellingPricesReadSellingPriceResponseAffinityBasis(
        PlatformPublicApiSellingPricesReadSellingPriceResponseAffinityBasis.Item value
    ) => new(value);

    public static implicit operator PlatformPublicApiSellingPricesReadSellingPriceResponseAffinityBasis(
        PlatformPublicApiSellingPricesReadSellingPriceResponseAffinityBasis.Package value
    ) => new(value);

    public static implicit operator PlatformPublicApiSellingPricesReadSellingPriceResponseAffinityBasis(
        PlatformPublicApiSellingPricesReadSellingPriceResponseAffinityBasis.Unit value
    ) => new(value);

    [Serializable]
    internal sealed class JsonConverter
        : JsonConverter<PlatformPublicApiSellingPricesReadSellingPriceResponseAffinityBasis>
    {
        public override bool CanConvert(global::System.Type typeToConvert) =>
            typeof(PlatformPublicApiSellingPricesReadSellingPriceResponseAffinityBasis).IsAssignableFrom(
                typeToConvert
            );

        public override PlatformPublicApiSellingPricesReadSellingPriceResponseAffinityBasis Read(
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
                    jsonWithoutDiscriminator.Deserialize<Affinity.PlatformPublicApiSellingPricesReadSellingPriceResponseAffinityBasisItem?>(
                        options
                    )
                        ?? throw new JsonException(
                            "Failed to deserialize Affinity.PlatformPublicApiSellingPricesReadSellingPriceResponseAffinityBasisItem"
                        ),
                "package" =>
                    jsonWithoutDiscriminator.Deserialize<Affinity.PlatformPublicApiSellingPricesReadSellingPriceResponseAffinityBasisPackage?>(
                        options
                    )
                        ?? throw new JsonException(
                            "Failed to deserialize Affinity.PlatformPublicApiSellingPricesReadSellingPriceResponseAffinityBasisPackage"
                        ),
                "unit" =>
                    jsonWithoutDiscriminator.Deserialize<Affinity.PlatformPublicApiSellingPricesReadSellingPriceResponseAffinityBasisUnit?>(
                        options
                    )
                        ?? throw new JsonException(
                            "Failed to deserialize Affinity.PlatformPublicApiSellingPricesReadSellingPriceResponseAffinityBasisUnit"
                        ),
                _ => json.Deserialize<object?>(options),
            };
            return new PlatformPublicApiSellingPricesReadSellingPriceResponseAffinityBasis(
                discriminator,
                value
            );
        }

        public override void Write(
            Utf8JsonWriter writer,
            PlatformPublicApiSellingPricesReadSellingPriceResponseAffinityBasis value,
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

        public override PlatformPublicApiSellingPricesReadSellingPriceResponseAffinityBasis ReadAsPropertyName(
            ref Utf8JsonReader reader,
            global::System.Type typeToConvert,
            JsonSerializerOptions options
        )
        {
            var stringValue =
                reader.GetString()
                ?? throw new JsonException("The JSON property name could not be read as a string.");
            return new PlatformPublicApiSellingPricesReadSellingPriceResponseAffinityBasis(
                stringValue,
                stringValue
            );
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            PlatformPublicApiSellingPricesReadSellingPriceResponseAffinityBasis value,
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
            Affinity.PlatformPublicApiSellingPricesReadSellingPriceResponseAffinityBasisItem value
        )
        {
            Value = value;
        }

        internal Affinity.PlatformPublicApiSellingPricesReadSellingPriceResponseAffinityBasisItem Value { get; set; }

        public override string ToString() => Value.ToString() ?? "null";

        public static implicit operator PlatformPublicApiSellingPricesReadSellingPriceResponseAffinityBasis.Item(
            Affinity.PlatformPublicApiSellingPricesReadSellingPriceResponseAffinityBasisItem value
        ) => new(value);
    }

    /// <summary>
    /// Discriminated union type for package
    /// </summary>
    [Serializable]
    public struct Package
    {
        public Package(
            Affinity.PlatformPublicApiSellingPricesReadSellingPriceResponseAffinityBasisPackage value
        )
        {
            Value = value;
        }

        internal Affinity.PlatformPublicApiSellingPricesReadSellingPriceResponseAffinityBasisPackage Value { get; set; }

        public override string ToString() => Value.ToString() ?? "null";

        public static implicit operator PlatformPublicApiSellingPricesReadSellingPriceResponseAffinityBasis.Package(
            Affinity.PlatformPublicApiSellingPricesReadSellingPriceResponseAffinityBasisPackage value
        ) => new(value);
    }

    /// <summary>
    /// Discriminated union type for unit
    /// </summary>
    [Serializable]
    public struct Unit
    {
        public Unit(
            Affinity.PlatformPublicApiSellingPricesReadSellingPriceResponseAffinityBasisUnit value
        )
        {
            Value = value;
        }

        internal Affinity.PlatformPublicApiSellingPricesReadSellingPriceResponseAffinityBasisUnit Value { get; set; }

        public override string ToString() => Value.ToString() ?? "null";

        public static implicit operator PlatformPublicApiSellingPricesReadSellingPriceResponseAffinityBasis.Unit(
            Affinity.PlatformPublicApiSellingPricesReadSellingPriceResponseAffinityBasisUnit value
        ) => new(value);
    }
}
