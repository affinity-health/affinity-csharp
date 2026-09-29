// ReSharper disable NullableWarningSuppressionIsUsed
// ReSharper disable InconsistentNaming

using Affinity.Core;
using global::System.Text.Json;
using global::System.Text.Json.Nodes;
using global::System.Text.Json.Serialization;

namespace Affinity;

[JsonConverter(
    typeof(RetrievePrescribingOptionsResponseCatalogCompositionIngredientsItemStrength.JsonConverter)
)]
[Serializable]
public record RetrievePrescribingOptionsResponseCatalogCompositionIngredientsItemStrength
{
    internal RetrievePrescribingOptionsResponseCatalogCompositionIngredientsItemStrength(
        string type,
        object? value
    )
    {
        Kind = type;
        Value = value;
    }

    /// <summary>
    /// Create an instance of RetrievePrescribingOptionsResponseCatalogCompositionIngredientsItemStrength with <see cref="RetrievePrescribingOptionsResponseCatalogCompositionIngredientsItemStrength.Amount"/>.
    /// </summary>
    public RetrievePrescribingOptionsResponseCatalogCompositionIngredientsItemStrength(
        RetrievePrescribingOptionsResponseCatalogCompositionIngredientsItemStrength.Amount value
    )
    {
        Kind = "amount";
        Value = value.Value;
    }

    /// <summary>
    /// Create an instance of RetrievePrescribingOptionsResponseCatalogCompositionIngredientsItemStrength with <see cref="RetrievePrescribingOptionsResponseCatalogCompositionIngredientsItemStrength.Ratio"/>.
    /// </summary>
    public RetrievePrescribingOptionsResponseCatalogCompositionIngredientsItemStrength(
        RetrievePrescribingOptionsResponseCatalogCompositionIngredientsItemStrength.Ratio value
    )
    {
        Kind = "ratio";
        Value = value.Value;
    }

    /// <summary>
    /// Create an instance of RetrievePrescribingOptionsResponseCatalogCompositionIngredientsItemStrength with <see cref="RetrievePrescribingOptionsResponseCatalogCompositionIngredientsItemStrength.Unresolved"/>.
    /// </summary>
    public RetrievePrescribingOptionsResponseCatalogCompositionIngredientsItemStrength(
        RetrievePrescribingOptionsResponseCatalogCompositionIngredientsItemStrength.Unresolved value
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
    /// Returns the value as a <see cref="Affinity.RetrievePrescribingOptionsResponseCatalogCompositionIngredientsItemStrengthAmount"/> if <see cref="Kind"/> is 'amount', otherwise throws an exception.
    /// </summary>
    /// <exception cref="Exception">Thrown when <see cref="Kind"/> is not 'amount'.</exception>
    public Affinity.RetrievePrescribingOptionsResponseCatalogCompositionIngredientsItemStrengthAmount AsAmount() =>
        IsAmount
            ? (Affinity.RetrievePrescribingOptionsResponseCatalogCompositionIngredientsItemStrengthAmount)
                Value!
            : throw new global::System.Exception(
                "RetrievePrescribingOptionsResponseCatalogCompositionIngredientsItemStrength.Kind is not 'amount'"
            );

    /// <summary>
    /// Returns the value as a <see cref="Affinity.RetrievePrescribingOptionsResponseCatalogCompositionIngredientsItemStrengthRatio"/> if <see cref="Kind"/> is 'ratio', otherwise throws an exception.
    /// </summary>
    /// <exception cref="Exception">Thrown when <see cref="Kind"/> is not 'ratio'.</exception>
    public Affinity.RetrievePrescribingOptionsResponseCatalogCompositionIngredientsItemStrengthRatio AsRatio() =>
        IsRatio
            ? (Affinity.RetrievePrescribingOptionsResponseCatalogCompositionIngredientsItemStrengthRatio)
                Value!
            : throw new global::System.Exception(
                "RetrievePrescribingOptionsResponseCatalogCompositionIngredientsItemStrength.Kind is not 'ratio'"
            );

    /// <summary>
    /// Returns the value as a <see cref="Affinity.RetrievePrescribingOptionsResponseCatalogCompositionIngredientsItemStrengthUnresolved"/> if <see cref="Kind"/> is 'unresolved', otherwise throws an exception.
    /// </summary>
    /// <exception cref="Exception">Thrown when <see cref="Kind"/> is not 'unresolved'.</exception>
    public Affinity.RetrievePrescribingOptionsResponseCatalogCompositionIngredientsItemStrengthUnresolved AsUnresolved() =>
        IsUnresolved
            ? (Affinity.RetrievePrescribingOptionsResponseCatalogCompositionIngredientsItemStrengthUnresolved)
                Value!
            : throw new global::System.Exception(
                "RetrievePrescribingOptionsResponseCatalogCompositionIngredientsItemStrength.Kind is not 'unresolved'"
            );

    public T Match<T>(
        Func<
            Affinity.RetrievePrescribingOptionsResponseCatalogCompositionIngredientsItemStrengthAmount,
            T
        > onAmount,
        Func<
            Affinity.RetrievePrescribingOptionsResponseCatalogCompositionIngredientsItemStrengthRatio,
            T
        > onRatio,
        Func<
            Affinity.RetrievePrescribingOptionsResponseCatalogCompositionIngredientsItemStrengthUnresolved,
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
        Action<Affinity.RetrievePrescribingOptionsResponseCatalogCompositionIngredientsItemStrengthAmount> onAmount,
        Action<Affinity.RetrievePrescribingOptionsResponseCatalogCompositionIngredientsItemStrengthRatio> onRatio,
        Action<Affinity.RetrievePrescribingOptionsResponseCatalogCompositionIngredientsItemStrengthUnresolved> onUnresolved,
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
    /// Attempts to cast the value to a <see cref="Affinity.RetrievePrescribingOptionsResponseCatalogCompositionIngredientsItemStrengthAmount"/> and returns true if successful.
    /// </summary>
    public bool TryAsAmount(
        out Affinity.RetrievePrescribingOptionsResponseCatalogCompositionIngredientsItemStrengthAmount? value
    )
    {
        if (Kind == "amount")
        {
            value =
                (Affinity.RetrievePrescribingOptionsResponseCatalogCompositionIngredientsItemStrengthAmount)
                    Value!;
            return true;
        }
        value = null;
        return false;
    }

    /// <summary>
    /// Attempts to cast the value to a <see cref="Affinity.RetrievePrescribingOptionsResponseCatalogCompositionIngredientsItemStrengthRatio"/> and returns true if successful.
    /// </summary>
    public bool TryAsRatio(
        out Affinity.RetrievePrescribingOptionsResponseCatalogCompositionIngredientsItemStrengthRatio? value
    )
    {
        if (Kind == "ratio")
        {
            value =
                (Affinity.RetrievePrescribingOptionsResponseCatalogCompositionIngredientsItemStrengthRatio)
                    Value!;
            return true;
        }
        value = null;
        return false;
    }

    /// <summary>
    /// Attempts to cast the value to a <see cref="Affinity.RetrievePrescribingOptionsResponseCatalogCompositionIngredientsItemStrengthUnresolved"/> and returns true if successful.
    /// </summary>
    public bool TryAsUnresolved(
        out Affinity.RetrievePrescribingOptionsResponseCatalogCompositionIngredientsItemStrengthUnresolved? value
    )
    {
        if (Kind == "unresolved")
        {
            value =
                (Affinity.RetrievePrescribingOptionsResponseCatalogCompositionIngredientsItemStrengthUnresolved)
                    Value!;
            return true;
        }
        value = null;
        return false;
    }

    public override string ToString() => JsonUtils.Serialize(this);

    public static implicit operator RetrievePrescribingOptionsResponseCatalogCompositionIngredientsItemStrength(
        RetrievePrescribingOptionsResponseCatalogCompositionIngredientsItemStrength.Amount value
    ) => new(value);

    public static implicit operator RetrievePrescribingOptionsResponseCatalogCompositionIngredientsItemStrength(
        RetrievePrescribingOptionsResponseCatalogCompositionIngredientsItemStrength.Ratio value
    ) => new(value);

    public static implicit operator RetrievePrescribingOptionsResponseCatalogCompositionIngredientsItemStrength(
        RetrievePrescribingOptionsResponseCatalogCompositionIngredientsItemStrength.Unresolved value
    ) => new(value);

    [Serializable]
    internal sealed class JsonConverter
        : JsonConverter<RetrievePrescribingOptionsResponseCatalogCompositionIngredientsItemStrength>
    {
        public override bool CanConvert(global::System.Type typeToConvert) =>
            typeof(RetrievePrescribingOptionsResponseCatalogCompositionIngredientsItemStrength).IsAssignableFrom(
                typeToConvert
            );

        public override RetrievePrescribingOptionsResponseCatalogCompositionIngredientsItemStrength Read(
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
                    jsonWithoutDiscriminator.Deserialize<Affinity.RetrievePrescribingOptionsResponseCatalogCompositionIngredientsItemStrengthAmount?>(
                        options
                    )
                        ?? throw new JsonException(
                            "Failed to deserialize Affinity.RetrievePrescribingOptionsResponseCatalogCompositionIngredientsItemStrengthAmount"
                        ),
                "ratio" =>
                    jsonWithoutDiscriminator.Deserialize<Affinity.RetrievePrescribingOptionsResponseCatalogCompositionIngredientsItemStrengthRatio?>(
                        options
                    )
                        ?? throw new JsonException(
                            "Failed to deserialize Affinity.RetrievePrescribingOptionsResponseCatalogCompositionIngredientsItemStrengthRatio"
                        ),
                "unresolved" =>
                    jsonWithoutDiscriminator.Deserialize<Affinity.RetrievePrescribingOptionsResponseCatalogCompositionIngredientsItemStrengthUnresolved?>(
                        options
                    )
                        ?? throw new JsonException(
                            "Failed to deserialize Affinity.RetrievePrescribingOptionsResponseCatalogCompositionIngredientsItemStrengthUnresolved"
                        ),
                _ => json.Deserialize<object?>(options),
            };
            return new RetrievePrescribingOptionsResponseCatalogCompositionIngredientsItemStrength(
                discriminator,
                value
            );
        }

        public override void Write(
            Utf8JsonWriter writer,
            RetrievePrescribingOptionsResponseCatalogCompositionIngredientsItemStrength value,
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

        public override RetrievePrescribingOptionsResponseCatalogCompositionIngredientsItemStrength ReadAsPropertyName(
            ref Utf8JsonReader reader,
            global::System.Type typeToConvert,
            JsonSerializerOptions options
        )
        {
            var stringValue =
                reader.GetString()
                ?? throw new JsonException("The JSON property name could not be read as a string.");
            return new RetrievePrescribingOptionsResponseCatalogCompositionIngredientsItemStrength(
                stringValue,
                stringValue
            );
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            RetrievePrescribingOptionsResponseCatalogCompositionIngredientsItemStrength value,
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
            Affinity.RetrievePrescribingOptionsResponseCatalogCompositionIngredientsItemStrengthAmount value
        )
        {
            Value = value;
        }

        internal Affinity.RetrievePrescribingOptionsResponseCatalogCompositionIngredientsItemStrengthAmount Value { get; set; }

        public override string ToString() => Value.ToString() ?? "null";

        public static implicit operator RetrievePrescribingOptionsResponseCatalogCompositionIngredientsItemStrength.Amount(
            Affinity.RetrievePrescribingOptionsResponseCatalogCompositionIngredientsItemStrengthAmount value
        ) => new(value);
    }

    /// <summary>
    /// Discriminated union type for ratio
    /// </summary>
    [Serializable]
    public struct Ratio
    {
        public Ratio(
            Affinity.RetrievePrescribingOptionsResponseCatalogCompositionIngredientsItemStrengthRatio value
        )
        {
            Value = value;
        }

        internal Affinity.RetrievePrescribingOptionsResponseCatalogCompositionIngredientsItemStrengthRatio Value { get; set; }

        public override string ToString() => Value.ToString() ?? "null";

        public static implicit operator RetrievePrescribingOptionsResponseCatalogCompositionIngredientsItemStrength.Ratio(
            Affinity.RetrievePrescribingOptionsResponseCatalogCompositionIngredientsItemStrengthRatio value
        ) => new(value);
    }

    /// <summary>
    /// Discriminated union type for unresolved
    /// </summary>
    [Serializable]
    public struct Unresolved
    {
        public Unresolved(
            Affinity.RetrievePrescribingOptionsResponseCatalogCompositionIngredientsItemStrengthUnresolved value
        )
        {
            Value = value;
        }

        internal Affinity.RetrievePrescribingOptionsResponseCatalogCompositionIngredientsItemStrengthUnresolved Value { get; set; }

        public override string ToString() => Value.ToString() ?? "null";

        public static implicit operator RetrievePrescribingOptionsResponseCatalogCompositionIngredientsItemStrength.Unresolved(
            Affinity.RetrievePrescribingOptionsResponseCatalogCompositionIngredientsItemStrengthUnresolved value
        ) => new(value);
    }
}
