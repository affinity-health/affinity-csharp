// ReSharper disable NullableWarningSuppressionIsUsed
// ReSharper disable InconsistentNaming

using Affinity.Core;
using global::System.Text.Json;
using global::System.Text.Json.Nodes;
using global::System.Text.Json.Serialization;

namespace Affinity;

[JsonConverter(typeof(PlatformPublicApiSellingPricesUpdateSellingPriceResponseBasis.JsonConverter))]
[Serializable]
public record PlatformPublicApiSellingPricesUpdateSellingPriceResponseBasis
{
    internal PlatformPublicApiSellingPricesUpdateSellingPriceResponseBasis(
        string type,
        object? value
    )
    {
        Kind = type;
        Value = value;
    }

    /// <summary>
    /// Create an instance of PlatformPublicApiSellingPricesUpdateSellingPriceResponseBasis with <see cref="PlatformPublicApiSellingPricesUpdateSellingPriceResponseBasis.Item"/>.
    /// </summary>
    public PlatformPublicApiSellingPricesUpdateSellingPriceResponseBasis(
        PlatformPublicApiSellingPricesUpdateSellingPriceResponseBasis.Item value
    )
    {
        Kind = "item";
        Value = value.Value;
    }

    /// <summary>
    /// Create an instance of PlatformPublicApiSellingPricesUpdateSellingPriceResponseBasis with <see cref="PlatformPublicApiSellingPricesUpdateSellingPriceResponseBasis.Package"/>.
    /// </summary>
    public PlatformPublicApiSellingPricesUpdateSellingPriceResponseBasis(
        PlatformPublicApiSellingPricesUpdateSellingPriceResponseBasis.Package value
    )
    {
        Kind = "package";
        Value = value.Value;
    }

    /// <summary>
    /// Create an instance of PlatformPublicApiSellingPricesUpdateSellingPriceResponseBasis with <see cref="PlatformPublicApiSellingPricesUpdateSellingPriceResponseBasis.Unit"/>.
    /// </summary>
    public PlatformPublicApiSellingPricesUpdateSellingPriceResponseBasis(
        PlatformPublicApiSellingPricesUpdateSellingPriceResponseBasis.Unit value
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
    /// Returns the value as a <see cref="Affinity.PlatformPublicApiSellingPricesUpdateSellingPriceResponseBasisItem"/> if <see cref="Kind"/> is 'item', otherwise throws an exception.
    /// </summary>
    /// <exception cref="Exception">Thrown when <see cref="Kind"/> is not 'item'.</exception>
    public Affinity.PlatformPublicApiSellingPricesUpdateSellingPriceResponseBasisItem AsItem() =>
        IsItem
            ? (Affinity.PlatformPublicApiSellingPricesUpdateSellingPriceResponseBasisItem)Value!
            : throw new global::System.Exception(
                "PlatformPublicApiSellingPricesUpdateSellingPriceResponseBasis.Kind is not 'item'"
            );

    /// <summary>
    /// Returns the value as a <see cref="Affinity.PlatformPublicApiSellingPricesUpdateSellingPriceResponseBasisPackage"/> if <see cref="Kind"/> is 'package', otherwise throws an exception.
    /// </summary>
    /// <exception cref="Exception">Thrown when <see cref="Kind"/> is not 'package'.</exception>
    public Affinity.PlatformPublicApiSellingPricesUpdateSellingPriceResponseBasisPackage AsPackage() =>
        IsPackage
            ? (Affinity.PlatformPublicApiSellingPricesUpdateSellingPriceResponseBasisPackage)Value!
            : throw new global::System.Exception(
                "PlatformPublicApiSellingPricesUpdateSellingPriceResponseBasis.Kind is not 'package'"
            );

    /// <summary>
    /// Returns the value as a <see cref="Affinity.PlatformPublicApiSellingPricesUpdateSellingPriceResponseBasisUnit"/> if <see cref="Kind"/> is 'unit', otherwise throws an exception.
    /// </summary>
    /// <exception cref="Exception">Thrown when <see cref="Kind"/> is not 'unit'.</exception>
    public Affinity.PlatformPublicApiSellingPricesUpdateSellingPriceResponseBasisUnit AsUnit() =>
        IsUnit
            ? (Affinity.PlatformPublicApiSellingPricesUpdateSellingPriceResponseBasisUnit)Value!
            : throw new global::System.Exception(
                "PlatformPublicApiSellingPricesUpdateSellingPriceResponseBasis.Kind is not 'unit'"
            );

    public T Match<T>(
        Func<Affinity.PlatformPublicApiSellingPricesUpdateSellingPriceResponseBasisItem, T> onItem,
        Func<
            Affinity.PlatformPublicApiSellingPricesUpdateSellingPriceResponseBasisPackage,
            T
        > onPackage,
        Func<Affinity.PlatformPublicApiSellingPricesUpdateSellingPriceResponseBasisUnit, T> onUnit,
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
        Action<Affinity.PlatformPublicApiSellingPricesUpdateSellingPriceResponseBasisItem> onItem,
        Action<Affinity.PlatformPublicApiSellingPricesUpdateSellingPriceResponseBasisPackage> onPackage,
        Action<Affinity.PlatformPublicApiSellingPricesUpdateSellingPriceResponseBasisUnit> onUnit,
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
    /// Attempts to cast the value to a <see cref="Affinity.PlatformPublicApiSellingPricesUpdateSellingPriceResponseBasisItem"/> and returns true if successful.
    /// </summary>
    public bool TryAsItem(
        out Affinity.PlatformPublicApiSellingPricesUpdateSellingPriceResponseBasisItem? value
    )
    {
        if (Kind == "item")
        {
            value = (Affinity.PlatformPublicApiSellingPricesUpdateSellingPriceResponseBasisItem)
                Value!;
            return true;
        }
        value = null;
        return false;
    }

    /// <summary>
    /// Attempts to cast the value to a <see cref="Affinity.PlatformPublicApiSellingPricesUpdateSellingPriceResponseBasisPackage"/> and returns true if successful.
    /// </summary>
    public bool TryAsPackage(
        out Affinity.PlatformPublicApiSellingPricesUpdateSellingPriceResponseBasisPackage? value
    )
    {
        if (Kind == "package")
        {
            value = (Affinity.PlatformPublicApiSellingPricesUpdateSellingPriceResponseBasisPackage)
                Value!;
            return true;
        }
        value = null;
        return false;
    }

    /// <summary>
    /// Attempts to cast the value to a <see cref="Affinity.PlatformPublicApiSellingPricesUpdateSellingPriceResponseBasisUnit"/> and returns true if successful.
    /// </summary>
    public bool TryAsUnit(
        out Affinity.PlatformPublicApiSellingPricesUpdateSellingPriceResponseBasisUnit? value
    )
    {
        if (Kind == "unit")
        {
            value = (Affinity.PlatformPublicApiSellingPricesUpdateSellingPriceResponseBasisUnit)
                Value!;
            return true;
        }
        value = null;
        return false;
    }

    public override string ToString() => JsonUtils.Serialize(this);

    public static implicit operator PlatformPublicApiSellingPricesUpdateSellingPriceResponseBasis(
        PlatformPublicApiSellingPricesUpdateSellingPriceResponseBasis.Item value
    ) => new(value);

    public static implicit operator PlatformPublicApiSellingPricesUpdateSellingPriceResponseBasis(
        PlatformPublicApiSellingPricesUpdateSellingPriceResponseBasis.Package value
    ) => new(value);

    public static implicit operator PlatformPublicApiSellingPricesUpdateSellingPriceResponseBasis(
        PlatformPublicApiSellingPricesUpdateSellingPriceResponseBasis.Unit value
    ) => new(value);

    [Serializable]
    internal sealed class JsonConverter
        : JsonConverter<PlatformPublicApiSellingPricesUpdateSellingPriceResponseBasis>
    {
        public override bool CanConvert(global::System.Type typeToConvert) =>
            typeof(PlatformPublicApiSellingPricesUpdateSellingPriceResponseBasis).IsAssignableFrom(
                typeToConvert
            );

        public override PlatformPublicApiSellingPricesUpdateSellingPriceResponseBasis Read(
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
                    jsonWithoutDiscriminator.Deserialize<Affinity.PlatformPublicApiSellingPricesUpdateSellingPriceResponseBasisItem?>(
                        options
                    )
                        ?? throw new JsonException(
                            "Failed to deserialize Affinity.PlatformPublicApiSellingPricesUpdateSellingPriceResponseBasisItem"
                        ),
                "package" =>
                    jsonWithoutDiscriminator.Deserialize<Affinity.PlatformPublicApiSellingPricesUpdateSellingPriceResponseBasisPackage?>(
                        options
                    )
                        ?? throw new JsonException(
                            "Failed to deserialize Affinity.PlatformPublicApiSellingPricesUpdateSellingPriceResponseBasisPackage"
                        ),
                "unit" =>
                    jsonWithoutDiscriminator.Deserialize<Affinity.PlatformPublicApiSellingPricesUpdateSellingPriceResponseBasisUnit?>(
                        options
                    )
                        ?? throw new JsonException(
                            "Failed to deserialize Affinity.PlatformPublicApiSellingPricesUpdateSellingPriceResponseBasisUnit"
                        ),
                _ => json.Deserialize<object?>(options),
            };
            return new PlatformPublicApiSellingPricesUpdateSellingPriceResponseBasis(
                discriminator,
                value
            );
        }

        public override void Write(
            Utf8JsonWriter writer,
            PlatformPublicApiSellingPricesUpdateSellingPriceResponseBasis value,
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

        public override PlatformPublicApiSellingPricesUpdateSellingPriceResponseBasis ReadAsPropertyName(
            ref Utf8JsonReader reader,
            global::System.Type typeToConvert,
            JsonSerializerOptions options
        )
        {
            var stringValue =
                reader.GetString()
                ?? throw new JsonException("The JSON property name could not be read as a string.");
            return new PlatformPublicApiSellingPricesUpdateSellingPriceResponseBasis(
                stringValue,
                stringValue
            );
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            PlatformPublicApiSellingPricesUpdateSellingPriceResponseBasis value,
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
            Affinity.PlatformPublicApiSellingPricesUpdateSellingPriceResponseBasisItem value
        )
        {
            Value = value;
        }

        internal Affinity.PlatformPublicApiSellingPricesUpdateSellingPriceResponseBasisItem Value { get; set; }

        public override string ToString() => Value.ToString() ?? "null";

        public static implicit operator PlatformPublicApiSellingPricesUpdateSellingPriceResponseBasis.Item(
            Affinity.PlatformPublicApiSellingPricesUpdateSellingPriceResponseBasisItem value
        ) => new(value);
    }

    /// <summary>
    /// Discriminated union type for package
    /// </summary>
    [Serializable]
    public struct Package
    {
        public Package(
            Affinity.PlatformPublicApiSellingPricesUpdateSellingPriceResponseBasisPackage value
        )
        {
            Value = value;
        }

        internal Affinity.PlatformPublicApiSellingPricesUpdateSellingPriceResponseBasisPackage Value { get; set; }

        public override string ToString() => Value.ToString() ?? "null";

        public static implicit operator PlatformPublicApiSellingPricesUpdateSellingPriceResponseBasis.Package(
            Affinity.PlatformPublicApiSellingPricesUpdateSellingPriceResponseBasisPackage value
        ) => new(value);
    }

    /// <summary>
    /// Discriminated union type for unit
    /// </summary>
    [Serializable]
    public struct Unit
    {
        public Unit(
            Affinity.PlatformPublicApiSellingPricesUpdateSellingPriceResponseBasisUnit value
        )
        {
            Value = value;
        }

        internal Affinity.PlatformPublicApiSellingPricesUpdateSellingPriceResponseBasisUnit Value { get; set; }

        public override string ToString() => Value.ToString() ?? "null";

        public static implicit operator PlatformPublicApiSellingPricesUpdateSellingPriceResponseBasis.Unit(
            Affinity.PlatformPublicApiSellingPricesUpdateSellingPriceResponseBasisUnit value
        ) => new(value);
    }
}
