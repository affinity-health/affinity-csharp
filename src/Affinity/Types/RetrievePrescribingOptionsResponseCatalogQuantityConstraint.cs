// ReSharper disable NullableWarningSuppressionIsUsed
// ReSharper disable InconsistentNaming

using Affinity.Core;
using global::System.Text.Json;
using global::System.Text.Json.Nodes;
using global::System.Text.Json.Serialization;

namespace Affinity;

[JsonConverter(typeof(RetrievePrescribingOptionsResponseCatalogQuantityConstraint.JsonConverter))]
[Serializable]
public record RetrievePrescribingOptionsResponseCatalogQuantityConstraint
{
    internal RetrievePrescribingOptionsResponseCatalogQuantityConstraint(string type, object? value)
    {
        Kind = type;
        Value = value;
    }

    /// <summary>
    /// Create an instance of RetrievePrescribingOptionsResponseCatalogQuantityConstraint with <see cref="RetrievePrescribingOptionsResponseCatalogQuantityConstraint.Fixed"/>.
    /// </summary>
    public RetrievePrescribingOptionsResponseCatalogQuantityConstraint(
        RetrievePrescribingOptionsResponseCatalogQuantityConstraint.Fixed value
    )
    {
        Kind = "fixed";
        Value = value.Value;
    }

    /// <summary>
    /// Create an instance of RetrievePrescribingOptionsResponseCatalogQuantityConstraint with <see cref="RetrievePrescribingOptionsResponseCatalogQuantityConstraint.Choices"/>.
    /// </summary>
    public RetrievePrescribingOptionsResponseCatalogQuantityConstraint(
        RetrievePrescribingOptionsResponseCatalogQuantityConstraint.Choices value
    )
    {
        Kind = "choices";
        Value = value.Value;
    }

    /// <summary>
    /// Create an instance of RetrievePrescribingOptionsResponseCatalogQuantityConstraint with <see cref="RetrievePrescribingOptionsResponseCatalogQuantityConstraint.Range"/>.
    /// </summary>
    public RetrievePrescribingOptionsResponseCatalogQuantityConstraint(
        RetrievePrescribingOptionsResponseCatalogQuantityConstraint.Range value
    )
    {
        Kind = "range";
        Value = value.Value;
    }

    /// <summary>
    /// Create an instance of RetrievePrescribingOptionsResponseCatalogQuantityConstraint with <see cref="RetrievePrescribingOptionsResponseCatalogQuantityConstraint.Unresolved"/>.
    /// </summary>
    public RetrievePrescribingOptionsResponseCatalogQuantityConstraint(
        RetrievePrescribingOptionsResponseCatalogQuantityConstraint.Unresolved value
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
    /// Returns true if <see cref="Kind"/> is "fixed"
    /// </summary>
    public bool IsFixed => Kind == "fixed";

    /// <summary>
    /// Returns true if <see cref="Kind"/> is "choices"
    /// </summary>
    public bool IsChoices => Kind == "choices";

    /// <summary>
    /// Returns true if <see cref="Kind"/> is "range"
    /// </summary>
    public bool IsRange => Kind == "range";

    /// <summary>
    /// Returns true if <see cref="Kind"/> is "unresolved"
    /// </summary>
    public bool IsUnresolved => Kind == "unresolved";

    /// <summary>
    /// Returns the value as a <see cref="Affinity.RetrievePrescribingOptionsResponseCatalogQuantityConstraintFixed"/> if <see cref="Kind"/> is 'fixed', otherwise throws an exception.
    /// </summary>
    /// <exception cref="Exception">Thrown when <see cref="Kind"/> is not 'fixed'.</exception>
    public Affinity.RetrievePrescribingOptionsResponseCatalogQuantityConstraintFixed AsFixed() =>
        IsFixed
            ? (Affinity.RetrievePrescribingOptionsResponseCatalogQuantityConstraintFixed)Value!
            : throw new global::System.Exception(
                "RetrievePrescribingOptionsResponseCatalogQuantityConstraint.Kind is not 'fixed'"
            );

    /// <summary>
    /// Returns the value as a <see cref="Affinity.RetrievePrescribingOptionsResponseCatalogQuantityConstraintChoices"/> if <see cref="Kind"/> is 'choices', otherwise throws an exception.
    /// </summary>
    /// <exception cref="Exception">Thrown when <see cref="Kind"/> is not 'choices'.</exception>
    public Affinity.RetrievePrescribingOptionsResponseCatalogQuantityConstraintChoices AsChoices() =>
        IsChoices
            ? (Affinity.RetrievePrescribingOptionsResponseCatalogQuantityConstraintChoices)Value!
            : throw new global::System.Exception(
                "RetrievePrescribingOptionsResponseCatalogQuantityConstraint.Kind is not 'choices'"
            );

    /// <summary>
    /// Returns the value as a <see cref="Affinity.RetrievePrescribingOptionsResponseCatalogQuantityConstraintRange"/> if <see cref="Kind"/> is 'range', otherwise throws an exception.
    /// </summary>
    /// <exception cref="Exception">Thrown when <see cref="Kind"/> is not 'range'.</exception>
    public Affinity.RetrievePrescribingOptionsResponseCatalogQuantityConstraintRange AsRange() =>
        IsRange
            ? (Affinity.RetrievePrescribingOptionsResponseCatalogQuantityConstraintRange)Value!
            : throw new global::System.Exception(
                "RetrievePrescribingOptionsResponseCatalogQuantityConstraint.Kind is not 'range'"
            );

    /// <summary>
    /// Returns the value as a <see cref="Affinity.RetrievePrescribingOptionsResponseCatalogQuantityConstraintUnresolved"/> if <see cref="Kind"/> is 'unresolved', otherwise throws an exception.
    /// </summary>
    /// <exception cref="Exception">Thrown when <see cref="Kind"/> is not 'unresolved'.</exception>
    public Affinity.RetrievePrescribingOptionsResponseCatalogQuantityConstraintUnresolved AsUnresolved() =>
        IsUnresolved
            ? (Affinity.RetrievePrescribingOptionsResponseCatalogQuantityConstraintUnresolved)Value!
            : throw new global::System.Exception(
                "RetrievePrescribingOptionsResponseCatalogQuantityConstraint.Kind is not 'unresolved'"
            );

    public T Match<T>(
        Func<Affinity.RetrievePrescribingOptionsResponseCatalogQuantityConstraintFixed, T> onFixed,
        Func<
            Affinity.RetrievePrescribingOptionsResponseCatalogQuantityConstraintChoices,
            T
        > onChoices,
        Func<Affinity.RetrievePrescribingOptionsResponseCatalogQuantityConstraintRange, T> onRange,
        Func<
            Affinity.RetrievePrescribingOptionsResponseCatalogQuantityConstraintUnresolved,
            T
        > onUnresolved,
        Func<string, object?, T> onUnknown_
    )
    {
        return Kind switch
        {
            "fixed" => onFixed(AsFixed()),
            "choices" => onChoices(AsChoices()),
            "range" => onRange(AsRange()),
            "unresolved" => onUnresolved(AsUnresolved()),
            _ => onUnknown_(Kind, Value),
        };
    }

    public void Visit(
        Action<Affinity.RetrievePrescribingOptionsResponseCatalogQuantityConstraintFixed> onFixed,
        Action<Affinity.RetrievePrescribingOptionsResponseCatalogQuantityConstraintChoices> onChoices,
        Action<Affinity.RetrievePrescribingOptionsResponseCatalogQuantityConstraintRange> onRange,
        Action<Affinity.RetrievePrescribingOptionsResponseCatalogQuantityConstraintUnresolved> onUnresolved,
        Action<string, object?> onUnknown_
    )
    {
        switch (Kind)
        {
            case "fixed":
                onFixed(AsFixed());
                break;
            case "choices":
                onChoices(AsChoices());
                break;
            case "range":
                onRange(AsRange());
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
    /// Attempts to cast the value to a <see cref="Affinity.RetrievePrescribingOptionsResponseCatalogQuantityConstraintFixed"/> and returns true if successful.
    /// </summary>
    public bool TryAsFixed(
        out Affinity.RetrievePrescribingOptionsResponseCatalogQuantityConstraintFixed? value
    )
    {
        if (Kind == "fixed")
        {
            value = (Affinity.RetrievePrescribingOptionsResponseCatalogQuantityConstraintFixed)
                Value!;
            return true;
        }
        value = null;
        return false;
    }

    /// <summary>
    /// Attempts to cast the value to a <see cref="Affinity.RetrievePrescribingOptionsResponseCatalogQuantityConstraintChoices"/> and returns true if successful.
    /// </summary>
    public bool TryAsChoices(
        out Affinity.RetrievePrescribingOptionsResponseCatalogQuantityConstraintChoices? value
    )
    {
        if (Kind == "choices")
        {
            value = (Affinity.RetrievePrescribingOptionsResponseCatalogQuantityConstraintChoices)
                Value!;
            return true;
        }
        value = null;
        return false;
    }

    /// <summary>
    /// Attempts to cast the value to a <see cref="Affinity.RetrievePrescribingOptionsResponseCatalogQuantityConstraintRange"/> and returns true if successful.
    /// </summary>
    public bool TryAsRange(
        out Affinity.RetrievePrescribingOptionsResponseCatalogQuantityConstraintRange? value
    )
    {
        if (Kind == "range")
        {
            value = (Affinity.RetrievePrescribingOptionsResponseCatalogQuantityConstraintRange)
                Value!;
            return true;
        }
        value = null;
        return false;
    }

    /// <summary>
    /// Attempts to cast the value to a <see cref="Affinity.RetrievePrescribingOptionsResponseCatalogQuantityConstraintUnresolved"/> and returns true if successful.
    /// </summary>
    public bool TryAsUnresolved(
        out Affinity.RetrievePrescribingOptionsResponseCatalogQuantityConstraintUnresolved? value
    )
    {
        if (Kind == "unresolved")
        {
            value = (Affinity.RetrievePrescribingOptionsResponseCatalogQuantityConstraintUnresolved)
                Value!;
            return true;
        }
        value = null;
        return false;
    }

    public override string ToString() => JsonUtils.Serialize(this);

    public static implicit operator RetrievePrescribingOptionsResponseCatalogQuantityConstraint(
        RetrievePrescribingOptionsResponseCatalogQuantityConstraint.Fixed value
    ) => new(value);

    public static implicit operator RetrievePrescribingOptionsResponseCatalogQuantityConstraint(
        RetrievePrescribingOptionsResponseCatalogQuantityConstraint.Choices value
    ) => new(value);

    public static implicit operator RetrievePrescribingOptionsResponseCatalogQuantityConstraint(
        RetrievePrescribingOptionsResponseCatalogQuantityConstraint.Range value
    ) => new(value);

    public static implicit operator RetrievePrescribingOptionsResponseCatalogQuantityConstraint(
        RetrievePrescribingOptionsResponseCatalogQuantityConstraint.Unresolved value
    ) => new(value);

    [Serializable]
    internal sealed class JsonConverter
        : JsonConverter<RetrievePrescribingOptionsResponseCatalogQuantityConstraint>
    {
        public override bool CanConvert(global::System.Type typeToConvert) =>
            typeof(RetrievePrescribingOptionsResponseCatalogQuantityConstraint).IsAssignableFrom(
                typeToConvert
            );

        public override RetrievePrescribingOptionsResponseCatalogQuantityConstraint Read(
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
                "fixed" =>
                    jsonWithoutDiscriminator.Deserialize<Affinity.RetrievePrescribingOptionsResponseCatalogQuantityConstraintFixed?>(
                        options
                    )
                        ?? throw new JsonException(
                            "Failed to deserialize Affinity.RetrievePrescribingOptionsResponseCatalogQuantityConstraintFixed"
                        ),
                "choices" =>
                    jsonWithoutDiscriminator.Deserialize<Affinity.RetrievePrescribingOptionsResponseCatalogQuantityConstraintChoices?>(
                        options
                    )
                        ?? throw new JsonException(
                            "Failed to deserialize Affinity.RetrievePrescribingOptionsResponseCatalogQuantityConstraintChoices"
                        ),
                "range" =>
                    jsonWithoutDiscriminator.Deserialize<Affinity.RetrievePrescribingOptionsResponseCatalogQuantityConstraintRange?>(
                        options
                    )
                        ?? throw new JsonException(
                            "Failed to deserialize Affinity.RetrievePrescribingOptionsResponseCatalogQuantityConstraintRange"
                        ),
                "unresolved" =>
                    jsonWithoutDiscriminator.Deserialize<Affinity.RetrievePrescribingOptionsResponseCatalogQuantityConstraintUnresolved?>(
                        options
                    )
                        ?? throw new JsonException(
                            "Failed to deserialize Affinity.RetrievePrescribingOptionsResponseCatalogQuantityConstraintUnresolved"
                        ),
                _ => json.Deserialize<object?>(options),
            };
            return new RetrievePrescribingOptionsResponseCatalogQuantityConstraint(
                discriminator,
                value
            );
        }

        public override void Write(
            Utf8JsonWriter writer,
            RetrievePrescribingOptionsResponseCatalogQuantityConstraint value,
            JsonSerializerOptions options
        )
        {
            JsonNode json =
                value.Kind switch
                {
                    "fixed" => JsonSerializer.SerializeToNode(value.Value, options),
                    "choices" => JsonSerializer.SerializeToNode(value.Value, options),
                    "range" => JsonSerializer.SerializeToNode(value.Value, options),
                    "unresolved" => JsonSerializer.SerializeToNode(value.Value, options),
                    _ => JsonSerializer.SerializeToNode(value.Value, options),
                } ?? new JsonObject();
            json["kind"] = value.Kind;
            json.WriteTo(writer, options);
        }

        public override RetrievePrescribingOptionsResponseCatalogQuantityConstraint ReadAsPropertyName(
            ref Utf8JsonReader reader,
            global::System.Type typeToConvert,
            JsonSerializerOptions options
        )
        {
            var stringValue =
                reader.GetString()
                ?? throw new JsonException("The JSON property name could not be read as a string.");
            return new RetrievePrescribingOptionsResponseCatalogQuantityConstraint(
                stringValue,
                stringValue
            );
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            RetrievePrescribingOptionsResponseCatalogQuantityConstraint value,
            JsonSerializerOptions options
        )
        {
            writer.WritePropertyName(value.Kind);
        }
    }

    /// <summary>
    /// Discriminated union type for fixed
    /// </summary>
    [Serializable]
    public struct Fixed
    {
        public Fixed(
            Affinity.RetrievePrescribingOptionsResponseCatalogQuantityConstraintFixed value
        )
        {
            Value = value;
        }

        internal Affinity.RetrievePrescribingOptionsResponseCatalogQuantityConstraintFixed Value { get; set; }

        public override string ToString() => Value.ToString() ?? "null";

        public static implicit operator RetrievePrescribingOptionsResponseCatalogQuantityConstraint.Fixed(
            Affinity.RetrievePrescribingOptionsResponseCatalogQuantityConstraintFixed value
        ) => new(value);
    }

    /// <summary>
    /// Discriminated union type for choices
    /// </summary>
    [Serializable]
    public struct Choices
    {
        public Choices(
            Affinity.RetrievePrescribingOptionsResponseCatalogQuantityConstraintChoices value
        )
        {
            Value = value;
        }

        internal Affinity.RetrievePrescribingOptionsResponseCatalogQuantityConstraintChoices Value { get; set; }

        public override string ToString() => Value.ToString() ?? "null";

        public static implicit operator RetrievePrescribingOptionsResponseCatalogQuantityConstraint.Choices(
            Affinity.RetrievePrescribingOptionsResponseCatalogQuantityConstraintChoices value
        ) => new(value);
    }

    /// <summary>
    /// Discriminated union type for range
    /// </summary>
    [Serializable]
    public struct Range
    {
        public Range(
            Affinity.RetrievePrescribingOptionsResponseCatalogQuantityConstraintRange value
        )
        {
            Value = value;
        }

        internal Affinity.RetrievePrescribingOptionsResponseCatalogQuantityConstraintRange Value { get; set; }

        public override string ToString() => Value.ToString() ?? "null";

        public static implicit operator RetrievePrescribingOptionsResponseCatalogQuantityConstraint.Range(
            Affinity.RetrievePrescribingOptionsResponseCatalogQuantityConstraintRange value
        ) => new(value);
    }

    /// <summary>
    /// Discriminated union type for unresolved
    /// </summary>
    [Serializable]
    public struct Unresolved
    {
        public Unresolved(
            Affinity.RetrievePrescribingOptionsResponseCatalogQuantityConstraintUnresolved value
        )
        {
            Value = value;
        }

        internal Affinity.RetrievePrescribingOptionsResponseCatalogQuantityConstraintUnresolved Value { get; set; }

        public override string ToString() => Value.ToString() ?? "null";

        public static implicit operator RetrievePrescribingOptionsResponseCatalogQuantityConstraint.Unresolved(
            Affinity.RetrievePrescribingOptionsResponseCatalogQuantityConstraintUnresolved value
        ) => new(value);
    }
}
