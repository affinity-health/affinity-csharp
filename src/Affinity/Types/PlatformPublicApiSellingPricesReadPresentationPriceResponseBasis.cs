// ReSharper disable NullableWarningSuppressionIsUsed
// ReSharper disable InconsistentNaming

using Affinity.Core;
using global::System.Text.Json;
using global::System.Text.Json.Nodes;
using global::System.Text.Json.Serialization;

namespace Affinity;

[JsonConverter(
    typeof(PlatformPublicApiSellingPricesReadPresentationPriceResponseBasis.JsonConverter)
)]
[Serializable]
public record PlatformPublicApiSellingPricesReadPresentationPriceResponseBasis
{
    internal PlatformPublicApiSellingPricesReadPresentationPriceResponseBasis(
        string type,
        object? value
    )
    {
        Kind = type;
        Value = value;
    }

    /// <summary>
    /// Create an instance of PlatformPublicApiSellingPricesReadPresentationPriceResponseBasis with <see cref="PlatformPublicApiSellingPricesReadPresentationPriceResponseBasis.Item"/>.
    /// </summary>
    public PlatformPublicApiSellingPricesReadPresentationPriceResponseBasis(
        PlatformPublicApiSellingPricesReadPresentationPriceResponseBasis.Item value
    )
    {
        Kind = "item";
        Value = value.Value;
    }

    /// <summary>
    /// Create an instance of PlatformPublicApiSellingPricesReadPresentationPriceResponseBasis with <see cref="PlatformPublicApiSellingPricesReadPresentationPriceResponseBasis.Package"/>.
    /// </summary>
    public PlatformPublicApiSellingPricesReadPresentationPriceResponseBasis(
        PlatformPublicApiSellingPricesReadPresentationPriceResponseBasis.Package value
    )
    {
        Kind = "package";
        Value = value.Value;
    }

    /// <summary>
    /// Create an instance of PlatformPublicApiSellingPricesReadPresentationPriceResponseBasis with <see cref="PlatformPublicApiSellingPricesReadPresentationPriceResponseBasis.Unit"/>.
    /// </summary>
    public PlatformPublicApiSellingPricesReadPresentationPriceResponseBasis(
        PlatformPublicApiSellingPricesReadPresentationPriceResponseBasis.Unit value
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
    /// Returns the value as a <see cref="Affinity.PlatformPublicApiSellingPricesReadPresentationPriceResponseBasisItem"/> if <see cref="Kind"/> is 'item', otherwise throws an exception.
    /// </summary>
    /// <exception cref="Exception">Thrown when <see cref="Kind"/> is not 'item'.</exception>
    public Affinity.PlatformPublicApiSellingPricesReadPresentationPriceResponseBasisItem AsItem() =>
        IsItem
            ? (Affinity.PlatformPublicApiSellingPricesReadPresentationPriceResponseBasisItem)Value!
            : throw new global::System.Exception(
                "PlatformPublicApiSellingPricesReadPresentationPriceResponseBasis.Kind is not 'item'"
            );

    /// <summary>
    /// Returns the value as a <see cref="Affinity.PlatformPublicApiSellingPricesReadPresentationPriceResponseBasisPackage"/> if <see cref="Kind"/> is 'package', otherwise throws an exception.
    /// </summary>
    /// <exception cref="Exception">Thrown when <see cref="Kind"/> is not 'package'.</exception>
    public Affinity.PlatformPublicApiSellingPricesReadPresentationPriceResponseBasisPackage AsPackage() =>
        IsPackage
            ? (Affinity.PlatformPublicApiSellingPricesReadPresentationPriceResponseBasisPackage)
                Value!
            : throw new global::System.Exception(
                "PlatformPublicApiSellingPricesReadPresentationPriceResponseBasis.Kind is not 'package'"
            );

    /// <summary>
    /// Returns the value as a <see cref="Affinity.PlatformPublicApiSellingPricesReadPresentationPriceResponseBasisUnit"/> if <see cref="Kind"/> is 'unit', otherwise throws an exception.
    /// </summary>
    /// <exception cref="Exception">Thrown when <see cref="Kind"/> is not 'unit'.</exception>
    public Affinity.PlatformPublicApiSellingPricesReadPresentationPriceResponseBasisUnit AsUnit() =>
        IsUnit
            ? (Affinity.PlatformPublicApiSellingPricesReadPresentationPriceResponseBasisUnit)Value!
            : throw new global::System.Exception(
                "PlatformPublicApiSellingPricesReadPresentationPriceResponseBasis.Kind is not 'unit'"
            );

    public T Match<T>(
        Func<
            Affinity.PlatformPublicApiSellingPricesReadPresentationPriceResponseBasisItem,
            T
        > onItem,
        Func<
            Affinity.PlatformPublicApiSellingPricesReadPresentationPriceResponseBasisPackage,
            T
        > onPackage,
        Func<
            Affinity.PlatformPublicApiSellingPricesReadPresentationPriceResponseBasisUnit,
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
        Action<Affinity.PlatformPublicApiSellingPricesReadPresentationPriceResponseBasisItem> onItem,
        Action<Affinity.PlatformPublicApiSellingPricesReadPresentationPriceResponseBasisPackage> onPackage,
        Action<Affinity.PlatformPublicApiSellingPricesReadPresentationPriceResponseBasisUnit> onUnit,
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
    /// Attempts to cast the value to a <see cref="Affinity.PlatformPublicApiSellingPricesReadPresentationPriceResponseBasisItem"/> and returns true if successful.
    /// </summary>
    public bool TryAsItem(
        out Affinity.PlatformPublicApiSellingPricesReadPresentationPriceResponseBasisItem? value
    )
    {
        if (Kind == "item")
        {
            value = (Affinity.PlatformPublicApiSellingPricesReadPresentationPriceResponseBasisItem)
                Value!;
            return true;
        }
        value = null;
        return false;
    }

    /// <summary>
    /// Attempts to cast the value to a <see cref="Affinity.PlatformPublicApiSellingPricesReadPresentationPriceResponseBasisPackage"/> and returns true if successful.
    /// </summary>
    public bool TryAsPackage(
        out Affinity.PlatformPublicApiSellingPricesReadPresentationPriceResponseBasisPackage? value
    )
    {
        if (Kind == "package")
        {
            value =
                (Affinity.PlatformPublicApiSellingPricesReadPresentationPriceResponseBasisPackage)
                    Value!;
            return true;
        }
        value = null;
        return false;
    }

    /// <summary>
    /// Attempts to cast the value to a <see cref="Affinity.PlatformPublicApiSellingPricesReadPresentationPriceResponseBasisUnit"/> and returns true if successful.
    /// </summary>
    public bool TryAsUnit(
        out Affinity.PlatformPublicApiSellingPricesReadPresentationPriceResponseBasisUnit? value
    )
    {
        if (Kind == "unit")
        {
            value = (Affinity.PlatformPublicApiSellingPricesReadPresentationPriceResponseBasisUnit)
                Value!;
            return true;
        }
        value = null;
        return false;
    }

    public override string ToString() => JsonUtils.Serialize(this);

    public static implicit operator PlatformPublicApiSellingPricesReadPresentationPriceResponseBasis(
        PlatformPublicApiSellingPricesReadPresentationPriceResponseBasis.Item value
    ) => new(value);

    public static implicit operator PlatformPublicApiSellingPricesReadPresentationPriceResponseBasis(
        PlatformPublicApiSellingPricesReadPresentationPriceResponseBasis.Package value
    ) => new(value);

    public static implicit operator PlatformPublicApiSellingPricesReadPresentationPriceResponseBasis(
        PlatformPublicApiSellingPricesReadPresentationPriceResponseBasis.Unit value
    ) => new(value);

    [Serializable]
    internal sealed class JsonConverter
        : JsonConverter<PlatformPublicApiSellingPricesReadPresentationPriceResponseBasis>
    {
        public override bool CanConvert(global::System.Type typeToConvert) =>
            typeof(PlatformPublicApiSellingPricesReadPresentationPriceResponseBasis).IsAssignableFrom(
                typeToConvert
            );

        public override PlatformPublicApiSellingPricesReadPresentationPriceResponseBasis Read(
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
                    jsonWithoutDiscriminator.Deserialize<Affinity.PlatformPublicApiSellingPricesReadPresentationPriceResponseBasisItem?>(
                        options
                    )
                        ?? throw new JsonException(
                            "Failed to deserialize Affinity.PlatformPublicApiSellingPricesReadPresentationPriceResponseBasisItem"
                        ),
                "package" =>
                    jsonWithoutDiscriminator.Deserialize<Affinity.PlatformPublicApiSellingPricesReadPresentationPriceResponseBasisPackage?>(
                        options
                    )
                        ?? throw new JsonException(
                            "Failed to deserialize Affinity.PlatformPublicApiSellingPricesReadPresentationPriceResponseBasisPackage"
                        ),
                "unit" =>
                    jsonWithoutDiscriminator.Deserialize<Affinity.PlatformPublicApiSellingPricesReadPresentationPriceResponseBasisUnit?>(
                        options
                    )
                        ?? throw new JsonException(
                            "Failed to deserialize Affinity.PlatformPublicApiSellingPricesReadPresentationPriceResponseBasisUnit"
                        ),
                _ => json.Deserialize<object?>(options),
            };
            return new PlatformPublicApiSellingPricesReadPresentationPriceResponseBasis(
                discriminator,
                value
            );
        }

        public override void Write(
            Utf8JsonWriter writer,
            PlatformPublicApiSellingPricesReadPresentationPriceResponseBasis value,
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

        public override PlatformPublicApiSellingPricesReadPresentationPriceResponseBasis ReadAsPropertyName(
            ref Utf8JsonReader reader,
            global::System.Type typeToConvert,
            JsonSerializerOptions options
        )
        {
            var stringValue =
                reader.GetString()
                ?? throw new JsonException("The JSON property name could not be read as a string.");
            return new PlatformPublicApiSellingPricesReadPresentationPriceResponseBasis(
                stringValue,
                stringValue
            );
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            PlatformPublicApiSellingPricesReadPresentationPriceResponseBasis value,
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
            Affinity.PlatformPublicApiSellingPricesReadPresentationPriceResponseBasisItem value
        )
        {
            Value = value;
        }

        internal Affinity.PlatformPublicApiSellingPricesReadPresentationPriceResponseBasisItem Value { get; set; }

        public override string ToString() => Value.ToString() ?? "null";

        public static implicit operator PlatformPublicApiSellingPricesReadPresentationPriceResponseBasis.Item(
            Affinity.PlatformPublicApiSellingPricesReadPresentationPriceResponseBasisItem value
        ) => new(value);
    }

    /// <summary>
    /// Discriminated union type for package
    /// </summary>
    [Serializable]
    public struct Package
    {
        public Package(
            Affinity.PlatformPublicApiSellingPricesReadPresentationPriceResponseBasisPackage value
        )
        {
            Value = value;
        }

        internal Affinity.PlatformPublicApiSellingPricesReadPresentationPriceResponseBasisPackage Value { get; set; }

        public override string ToString() => Value.ToString() ?? "null";

        public static implicit operator PlatformPublicApiSellingPricesReadPresentationPriceResponseBasis.Package(
            Affinity.PlatformPublicApiSellingPricesReadPresentationPriceResponseBasisPackage value
        ) => new(value);
    }

    /// <summary>
    /// Discriminated union type for unit
    /// </summary>
    [Serializable]
    public struct Unit
    {
        public Unit(
            Affinity.PlatformPublicApiSellingPricesReadPresentationPriceResponseBasisUnit value
        )
        {
            Value = value;
        }

        internal Affinity.PlatformPublicApiSellingPricesReadPresentationPriceResponseBasisUnit Value { get; set; }

        public override string ToString() => Value.ToString() ?? "null";

        public static implicit operator PlatformPublicApiSellingPricesReadPresentationPriceResponseBasis.Unit(
            Affinity.PlatformPublicApiSellingPricesReadPresentationPriceResponseBasisUnit value
        ) => new(value);
    }
}
