// ReSharper disable NullableWarningSuppressionIsUsed
// ReSharper disable InconsistentNaming

using Affinity.Core;
using global::System.Text.Json;
using global::System.Text.Json.Nodes;
using global::System.Text.Json.Serialization;

namespace Affinity;

[JsonConverter(
    typeof(ListCatalogItemsResponseDataItemCompositionIngredientsItemStrength.JsonConverter)
)]
[Serializable]
public record ListCatalogItemsResponseDataItemCompositionIngredientsItemStrength
{
    internal ListCatalogItemsResponseDataItemCompositionIngredientsItemStrength(
        string type,
        object? value
    )
    {
        Kind = type;
        Value = value;
    }

    /// <summary>
    /// Create an instance of ListCatalogItemsResponseDataItemCompositionIngredientsItemStrength with <see cref="ListCatalogItemsResponseDataItemCompositionIngredientsItemStrength.Amount"/>.
    /// </summary>
    public ListCatalogItemsResponseDataItemCompositionIngredientsItemStrength(
        ListCatalogItemsResponseDataItemCompositionIngredientsItemStrength.Amount value
    )
    {
        Kind = "amount";
        Value = value.Value;
    }

    /// <summary>
    /// Create an instance of ListCatalogItemsResponseDataItemCompositionIngredientsItemStrength with <see cref="ListCatalogItemsResponseDataItemCompositionIngredientsItemStrength.Ratio"/>.
    /// </summary>
    public ListCatalogItemsResponseDataItemCompositionIngredientsItemStrength(
        ListCatalogItemsResponseDataItemCompositionIngredientsItemStrength.Ratio value
    )
    {
        Kind = "ratio";
        Value = value.Value;
    }

    /// <summary>
    /// Create an instance of ListCatalogItemsResponseDataItemCompositionIngredientsItemStrength with <see cref="ListCatalogItemsResponseDataItemCompositionIngredientsItemStrength.Unresolved"/>.
    /// </summary>
    public ListCatalogItemsResponseDataItemCompositionIngredientsItemStrength(
        ListCatalogItemsResponseDataItemCompositionIngredientsItemStrength.Unresolved value
    )
    {
        Kind = "unresolved";
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
    /// Returns true if <see cref="Kind"/> is "amount"
    /// </summary>
    public bool IsAmount => Kind == "amount";

    /// <summary>
    /// Returns true if <see cref="Kind"/> is "ratio"
    /// </summary>
    public bool IsRatio => Kind == "ratio";

    /// <summary>
    /// Returns true if <see cref="Kind"/> is "unresolved"
    /// </summary>
    public bool IsUnresolved => Kind == "unresolved";

    /// <summary>
    /// Returns the value as a <see cref="Affinity.ListCatalogItemsResponseDataItemCompositionIngredientsItemStrengthAmount"/> if <see cref="Kind"/> is 'amount', otherwise throws an exception.
    /// </summary>
    /// <exception cref="Exception">Thrown when <see cref="Kind"/> is not 'amount'.</exception>
    public Affinity.ListCatalogItemsResponseDataItemCompositionIngredientsItemStrengthAmount AsAmount() =>
        IsAmount
            ? (Affinity.ListCatalogItemsResponseDataItemCompositionIngredientsItemStrengthAmount)
                Value!
            : throw new global::System.Exception(
                "ListCatalogItemsResponseDataItemCompositionIngredientsItemStrength.Kind is not 'amount'"
            );

    /// <summary>
    /// Returns the value as a <see cref="Affinity.ListCatalogItemsResponseDataItemCompositionIngredientsItemStrengthRatio"/> if <see cref="Kind"/> is 'ratio', otherwise throws an exception.
    /// </summary>
    /// <exception cref="Exception">Thrown when <see cref="Kind"/> is not 'ratio'.</exception>
    public Affinity.ListCatalogItemsResponseDataItemCompositionIngredientsItemStrengthRatio AsRatio() =>
        IsRatio
            ? (Affinity.ListCatalogItemsResponseDataItemCompositionIngredientsItemStrengthRatio)
                Value!
            : throw new global::System.Exception(
                "ListCatalogItemsResponseDataItemCompositionIngredientsItemStrength.Kind is not 'ratio'"
            );

    /// <summary>
    /// Returns the value as a <see cref="Affinity.ListCatalogItemsResponseDataItemCompositionIngredientsItemStrengthUnresolved"/> if <see cref="Kind"/> is 'unresolved', otherwise throws an exception.
    /// </summary>
    /// <exception cref="Exception">Thrown when <see cref="Kind"/> is not 'unresolved'.</exception>
    public Affinity.ListCatalogItemsResponseDataItemCompositionIngredientsItemStrengthUnresolved AsUnresolved() =>
        IsUnresolved
            ? (Affinity.ListCatalogItemsResponseDataItemCompositionIngredientsItemStrengthUnresolved)
                Value!
            : throw new global::System.Exception(
                "ListCatalogItemsResponseDataItemCompositionIngredientsItemStrength.Kind is not 'unresolved'"
            );

    public T Match<T>(
        Func<
            Affinity.ListCatalogItemsResponseDataItemCompositionIngredientsItemStrengthAmount,
            T
        > onAmount,
        Func<
            Affinity.ListCatalogItemsResponseDataItemCompositionIngredientsItemStrengthRatio,
            T
        > onRatio,
        Func<
            Affinity.ListCatalogItemsResponseDataItemCompositionIngredientsItemStrengthUnresolved,
            T
        > onUnresolved,
        Func<string, object?, T> onUnknown_
    )
    {
        return Kind switch
        {
            "amount" => onAmount(AsAmount()),
            "ratio" => onRatio(AsRatio()),
            "unresolved" => onUnresolved(AsUnresolved()),
            _ => onUnknown_(Kind, Value),
        };
    }

    public void Visit(
        Action<Affinity.ListCatalogItemsResponseDataItemCompositionIngredientsItemStrengthAmount> onAmount,
        Action<Affinity.ListCatalogItemsResponseDataItemCompositionIngredientsItemStrengthRatio> onRatio,
        Action<Affinity.ListCatalogItemsResponseDataItemCompositionIngredientsItemStrengthUnresolved> onUnresolved,
        Action<string, object?> onUnknown_
    )
    {
        switch (Kind)
        {
            case "amount":
                onAmount(AsAmount());
                break;
            case "ratio":
                onRatio(AsRatio());
                break;
            case "unresolved":
                onUnresolved(AsUnresolved());
                break;
            default:
                onUnknown_(Kind, Value);
                break;
        }
    }

    /// <summary>
    /// Attempts to cast the value to a <see cref="Affinity.ListCatalogItemsResponseDataItemCompositionIngredientsItemStrengthAmount"/> and returns true if successful.
    /// </summary>
    public bool TryAsAmount(
        out Affinity.ListCatalogItemsResponseDataItemCompositionIngredientsItemStrengthAmount? value
    )
    {
        if (Kind == "amount")
        {
            value =
                (Affinity.ListCatalogItemsResponseDataItemCompositionIngredientsItemStrengthAmount)
                    Value!;
            return true;
        }
        value = null;
        return false;
    }

    /// <summary>
    /// Attempts to cast the value to a <see cref="Affinity.ListCatalogItemsResponseDataItemCompositionIngredientsItemStrengthRatio"/> and returns true if successful.
    /// </summary>
    public bool TryAsRatio(
        out Affinity.ListCatalogItemsResponseDataItemCompositionIngredientsItemStrengthRatio? value
    )
    {
        if (Kind == "ratio")
        {
            value =
                (Affinity.ListCatalogItemsResponseDataItemCompositionIngredientsItemStrengthRatio)
                    Value!;
            return true;
        }
        value = null;
        return false;
    }

    /// <summary>
    /// Attempts to cast the value to a <see cref="Affinity.ListCatalogItemsResponseDataItemCompositionIngredientsItemStrengthUnresolved"/> and returns true if successful.
    /// </summary>
    public bool TryAsUnresolved(
        out Affinity.ListCatalogItemsResponseDataItemCompositionIngredientsItemStrengthUnresolved? value
    )
    {
        if (Kind == "unresolved")
        {
            value =
                (Affinity.ListCatalogItemsResponseDataItemCompositionIngredientsItemStrengthUnresolved)
                    Value!;
            return true;
        }
        value = null;
        return false;
    }

    public override string ToString() => JsonUtils.Serialize(this);

    public static implicit operator ListCatalogItemsResponseDataItemCompositionIngredientsItemStrength(
        ListCatalogItemsResponseDataItemCompositionIngredientsItemStrength.Amount value
    ) => new(value);

    public static implicit operator ListCatalogItemsResponseDataItemCompositionIngredientsItemStrength(
        ListCatalogItemsResponseDataItemCompositionIngredientsItemStrength.Ratio value
    ) => new(value);

    public static implicit operator ListCatalogItemsResponseDataItemCompositionIngredientsItemStrength(
        ListCatalogItemsResponseDataItemCompositionIngredientsItemStrength.Unresolved value
    ) => new(value);

    [Serializable]
    internal sealed class JsonConverter
        : JsonConverter<ListCatalogItemsResponseDataItemCompositionIngredientsItemStrength>
    {
        public override bool CanConvert(global::System.Type typeToConvert) =>
            typeof(ListCatalogItemsResponseDataItemCompositionIngredientsItemStrength).IsAssignableFrom(
                typeToConvert
            );

        public override ListCatalogItemsResponseDataItemCompositionIngredientsItemStrength Read(
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
                "amount" =>
                    jsonWithoutDiscriminator.Deserialize<Affinity.ListCatalogItemsResponseDataItemCompositionIngredientsItemStrengthAmount?>(
                        options
                    )
                        ?? throw new JsonException(
                            "Failed to deserialize Affinity.ListCatalogItemsResponseDataItemCompositionIngredientsItemStrengthAmount"
                        ),
                "ratio" =>
                    jsonWithoutDiscriminator.Deserialize<Affinity.ListCatalogItemsResponseDataItemCompositionIngredientsItemStrengthRatio?>(
                        options
                    )
                        ?? throw new JsonException(
                            "Failed to deserialize Affinity.ListCatalogItemsResponseDataItemCompositionIngredientsItemStrengthRatio"
                        ),
                "unresolved" =>
                    jsonWithoutDiscriminator.Deserialize<Affinity.ListCatalogItemsResponseDataItemCompositionIngredientsItemStrengthUnresolved?>(
                        options
                    )
                        ?? throw new JsonException(
                            "Failed to deserialize Affinity.ListCatalogItemsResponseDataItemCompositionIngredientsItemStrengthUnresolved"
                        ),
                _ => json.Deserialize<object?>(options),
            };
            return new ListCatalogItemsResponseDataItemCompositionIngredientsItemStrength(
                discriminator,
                value
            );
        }

        public override void Write(
            Utf8JsonWriter writer,
            ListCatalogItemsResponseDataItemCompositionIngredientsItemStrength value,
            JsonSerializerOptions options
        )
        {
            JsonNode json =
                value.Kind switch
                {
                    "amount" => JsonSerializer.SerializeToNode(value.Value, options),
                    "ratio" => JsonSerializer.SerializeToNode(value.Value, options),
                    "unresolved" => JsonSerializer.SerializeToNode(value.Value, options),
                    _ => JsonSerializer.SerializeToNode(value.Value, options),
                } ?? new JsonObject();
            json["kind"] = value.Kind;
            json.WriteTo(writer, options);
        }

        public override ListCatalogItemsResponseDataItemCompositionIngredientsItemStrength ReadAsPropertyName(
            ref Utf8JsonReader reader,
            global::System.Type typeToConvert,
            JsonSerializerOptions options
        )
        {
            var stringValue =
                reader.GetString()
                ?? throw new JsonException("The JSON property name could not be read as a string.");
            return new ListCatalogItemsResponseDataItemCompositionIngredientsItemStrength(
                stringValue,
                stringValue
            );
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            ListCatalogItemsResponseDataItemCompositionIngredientsItemStrength value,
            JsonSerializerOptions options
        )
        {
            writer.WritePropertyName(value.Kind);
        }
    }

    /// <summary>
    /// Discriminated union type for amount
    /// </summary>
    [Serializable]
    public struct Amount
    {
        public Amount(
            Affinity.ListCatalogItemsResponseDataItemCompositionIngredientsItemStrengthAmount value
        )
        {
            Value = value;
        }

        internal Affinity.ListCatalogItemsResponseDataItemCompositionIngredientsItemStrengthAmount Value { get; set; }

        public override string ToString() => Value.ToString() ?? "null";

        public static implicit operator ListCatalogItemsResponseDataItemCompositionIngredientsItemStrength.Amount(
            Affinity.ListCatalogItemsResponseDataItemCompositionIngredientsItemStrengthAmount value
        ) => new(value);
    }

    /// <summary>
    /// Discriminated union type for ratio
    /// </summary>
    [Serializable]
    public struct Ratio
    {
        public Ratio(
            Affinity.ListCatalogItemsResponseDataItemCompositionIngredientsItemStrengthRatio value
        )
        {
            Value = value;
        }

        internal Affinity.ListCatalogItemsResponseDataItemCompositionIngredientsItemStrengthRatio Value { get; set; }

        public override string ToString() => Value.ToString() ?? "null";

        public static implicit operator ListCatalogItemsResponseDataItemCompositionIngredientsItemStrength.Ratio(
            Affinity.ListCatalogItemsResponseDataItemCompositionIngredientsItemStrengthRatio value
        ) => new(value);
    }

    /// <summary>
    /// Discriminated union type for unresolved
    /// </summary>
    [Serializable]
    public struct Unresolved
    {
        public Unresolved(
            Affinity.ListCatalogItemsResponseDataItemCompositionIngredientsItemStrengthUnresolved value
        )
        {
            Value = value;
        }

        internal Affinity.ListCatalogItemsResponseDataItemCompositionIngredientsItemStrengthUnresolved Value { get; set; }

        public override string ToString() => Value.ToString() ?? "null";

        public static implicit operator ListCatalogItemsResponseDataItemCompositionIngredientsItemStrength.Unresolved(
            Affinity.ListCatalogItemsResponseDataItemCompositionIngredientsItemStrengthUnresolved value
        ) => new(value);
    }
}
