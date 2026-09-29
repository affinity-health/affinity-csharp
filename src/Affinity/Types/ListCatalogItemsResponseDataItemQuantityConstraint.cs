// ReSharper disable NullableWarningSuppressionIsUsed
// ReSharper disable InconsistentNaming

using Affinity.Core;
using global::System.Text.Json;
using global::System.Text.Json.Nodes;
using global::System.Text.Json.Serialization;

namespace Affinity;

[JsonConverter(typeof(ListCatalogItemsResponseDataItemQuantityConstraint.JsonConverter))]
[Serializable]
public record ListCatalogItemsResponseDataItemQuantityConstraint
{
    internal ListCatalogItemsResponseDataItemQuantityConstraint(string type, object? value)
    {
        Kind = type;
        Value = value;
    }

    /// <summary>
    /// Create an instance of ListCatalogItemsResponseDataItemQuantityConstraint with <see cref="ListCatalogItemsResponseDataItemQuantityConstraint.Fixed"/>.
    /// </summary>
    public ListCatalogItemsResponseDataItemQuantityConstraint(
        ListCatalogItemsResponseDataItemQuantityConstraint.Fixed value
    )
    {
        Kind = "fixed";
        Value = value.Value;
    }

    /// <summary>
    /// Create an instance of ListCatalogItemsResponseDataItemQuantityConstraint with <see cref="ListCatalogItemsResponseDataItemQuantityConstraint.Choices"/>.
    /// </summary>
    public ListCatalogItemsResponseDataItemQuantityConstraint(
        ListCatalogItemsResponseDataItemQuantityConstraint.Choices value
    )
    {
        Kind = "choices";
        Value = value.Value;
    }

    /// <summary>
    /// Create an instance of ListCatalogItemsResponseDataItemQuantityConstraint with <see cref="ListCatalogItemsResponseDataItemQuantityConstraint.Range"/>.
    /// </summary>
    public ListCatalogItemsResponseDataItemQuantityConstraint(
        ListCatalogItemsResponseDataItemQuantityConstraint.Range value
    )
    {
        Kind = "range";
        Value = value.Value;
    }

    /// <summary>
    /// Create an instance of ListCatalogItemsResponseDataItemQuantityConstraint with <see cref="ListCatalogItemsResponseDataItemQuantityConstraint.Unresolved"/>.
    /// </summary>
    public ListCatalogItemsResponseDataItemQuantityConstraint(
        ListCatalogItemsResponseDataItemQuantityConstraint.Unresolved value
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
    /// Returns the value as a <see cref="Affinity.ListCatalogItemsResponseDataItemQuantityConstraintFixed"/> if <see cref="Kind"/> is 'fixed', otherwise throws an exception.
    /// </summary>
    /// <exception cref="Exception">Thrown when <see cref="Kind"/> is not 'fixed'.</exception>
    public Affinity.ListCatalogItemsResponseDataItemQuantityConstraintFixed AsFixed() =>
        IsFixed
            ? (Affinity.ListCatalogItemsResponseDataItemQuantityConstraintFixed)Value!
            : throw new global::System.Exception(
                "ListCatalogItemsResponseDataItemQuantityConstraint.Kind is not 'fixed'"
            );

    /// <summary>
    /// Returns the value as a <see cref="Affinity.ListCatalogItemsResponseDataItemQuantityConstraintChoices"/> if <see cref="Kind"/> is 'choices', otherwise throws an exception.
    /// </summary>
    /// <exception cref="Exception">Thrown when <see cref="Kind"/> is not 'choices'.</exception>
    public Affinity.ListCatalogItemsResponseDataItemQuantityConstraintChoices AsChoices() =>
        IsChoices
            ? (Affinity.ListCatalogItemsResponseDataItemQuantityConstraintChoices)Value!
            : throw new global::System.Exception(
                "ListCatalogItemsResponseDataItemQuantityConstraint.Kind is not 'choices'"
            );

    /// <summary>
    /// Returns the value as a <see cref="Affinity.ListCatalogItemsResponseDataItemQuantityConstraintRange"/> if <see cref="Kind"/> is 'range', otherwise throws an exception.
    /// </summary>
    /// <exception cref="Exception">Thrown when <see cref="Kind"/> is not 'range'.</exception>
    public Affinity.ListCatalogItemsResponseDataItemQuantityConstraintRange AsRange() =>
        IsRange
            ? (Affinity.ListCatalogItemsResponseDataItemQuantityConstraintRange)Value!
            : throw new global::System.Exception(
                "ListCatalogItemsResponseDataItemQuantityConstraint.Kind is not 'range'"
            );

    /// <summary>
    /// Returns the value as a <see cref="Affinity.ListCatalogItemsResponseDataItemQuantityConstraintUnresolved"/> if <see cref="Kind"/> is 'unresolved', otherwise throws an exception.
    /// </summary>
    /// <exception cref="Exception">Thrown when <see cref="Kind"/> is not 'unresolved'.</exception>
    public Affinity.ListCatalogItemsResponseDataItemQuantityConstraintUnresolved AsUnresolved() =>
        IsUnresolved
            ? (Affinity.ListCatalogItemsResponseDataItemQuantityConstraintUnresolved)Value!
            : throw new global::System.Exception(
                "ListCatalogItemsResponseDataItemQuantityConstraint.Kind is not 'unresolved'"
            );

    public T Match<T>(
        Func<Affinity.ListCatalogItemsResponseDataItemQuantityConstraintFixed, T> onFixed,
        Func<Affinity.ListCatalogItemsResponseDataItemQuantityConstraintChoices, T> onChoices,
        Func<Affinity.ListCatalogItemsResponseDataItemQuantityConstraintRange, T> onRange,
        Func<Affinity.ListCatalogItemsResponseDataItemQuantityConstraintUnresolved, T> onUnresolved,
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
        Action<Affinity.ListCatalogItemsResponseDataItemQuantityConstraintFixed> onFixed,
        Action<Affinity.ListCatalogItemsResponseDataItemQuantityConstraintChoices> onChoices,
        Action<Affinity.ListCatalogItemsResponseDataItemQuantityConstraintRange> onRange,
        Action<Affinity.ListCatalogItemsResponseDataItemQuantityConstraintUnresolved> onUnresolved,
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
    /// Attempts to cast the value to a <see cref="Affinity.ListCatalogItemsResponseDataItemQuantityConstraintFixed"/> and returns true if successful.
    /// </summary>
    public bool TryAsFixed(
        out Affinity.ListCatalogItemsResponseDataItemQuantityConstraintFixed? value
    )
    {
        if (Kind == "fixed")
        {
            value = (Affinity.ListCatalogItemsResponseDataItemQuantityConstraintFixed)Value!;
            return true;
        }
        value = null;
        return false;
    }

    /// <summary>
    /// Attempts to cast the value to a <see cref="Affinity.ListCatalogItemsResponseDataItemQuantityConstraintChoices"/> and returns true if successful.
    /// </summary>
    public bool TryAsChoices(
        out Affinity.ListCatalogItemsResponseDataItemQuantityConstraintChoices? value
    )
    {
        if (Kind == "choices")
        {
            value = (Affinity.ListCatalogItemsResponseDataItemQuantityConstraintChoices)Value!;
            return true;
        }
        value = null;
        return false;
    }

    /// <summary>
    /// Attempts to cast the value to a <see cref="Affinity.ListCatalogItemsResponseDataItemQuantityConstraintRange"/> and returns true if successful.
    /// </summary>
    public bool TryAsRange(
        out Affinity.ListCatalogItemsResponseDataItemQuantityConstraintRange? value
    )
    {
        if (Kind == "range")
        {
            value = (Affinity.ListCatalogItemsResponseDataItemQuantityConstraintRange)Value!;
            return true;
        }
        value = null;
        return false;
    }

    /// <summary>
    /// Attempts to cast the value to a <see cref="Affinity.ListCatalogItemsResponseDataItemQuantityConstraintUnresolved"/> and returns true if successful.
    /// </summary>
    public bool TryAsUnresolved(
        out Affinity.ListCatalogItemsResponseDataItemQuantityConstraintUnresolved? value
    )
    {
        if (Kind == "unresolved")
        {
            value = (Affinity.ListCatalogItemsResponseDataItemQuantityConstraintUnresolved)Value!;
            return true;
        }
        value = null;
        return false;
    }

    public override string ToString() => JsonUtils.Serialize(this);

    public static implicit operator ListCatalogItemsResponseDataItemQuantityConstraint(
        ListCatalogItemsResponseDataItemQuantityConstraint.Fixed value
    ) => new(value);

    public static implicit operator ListCatalogItemsResponseDataItemQuantityConstraint(
        ListCatalogItemsResponseDataItemQuantityConstraint.Choices value
    ) => new(value);

    public static implicit operator ListCatalogItemsResponseDataItemQuantityConstraint(
        ListCatalogItemsResponseDataItemQuantityConstraint.Range value
    ) => new(value);

    public static implicit operator ListCatalogItemsResponseDataItemQuantityConstraint(
        ListCatalogItemsResponseDataItemQuantityConstraint.Unresolved value
    ) => new(value);

    [Serializable]
    internal sealed class JsonConverter
        : JsonConverter<ListCatalogItemsResponseDataItemQuantityConstraint>
    {
        public override bool CanConvert(global::System.Type typeToConvert) =>
            typeof(ListCatalogItemsResponseDataItemQuantityConstraint).IsAssignableFrom(
                typeToConvert
            );

        public override ListCatalogItemsResponseDataItemQuantityConstraint Read(
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
                    jsonWithoutDiscriminator.Deserialize<Affinity.ListCatalogItemsResponseDataItemQuantityConstraintFixed?>(
                        options
                    )
                        ?? throw new JsonException(
                            "Failed to deserialize Affinity.ListCatalogItemsResponseDataItemQuantityConstraintFixed"
                        ),
                "choices" =>
                    jsonWithoutDiscriminator.Deserialize<Affinity.ListCatalogItemsResponseDataItemQuantityConstraintChoices?>(
                        options
                    )
                        ?? throw new JsonException(
                            "Failed to deserialize Affinity.ListCatalogItemsResponseDataItemQuantityConstraintChoices"
                        ),
                "range" =>
                    jsonWithoutDiscriminator.Deserialize<Affinity.ListCatalogItemsResponseDataItemQuantityConstraintRange?>(
                        options
                    )
                        ?? throw new JsonException(
                            "Failed to deserialize Affinity.ListCatalogItemsResponseDataItemQuantityConstraintRange"
                        ),
                "unresolved" =>
                    jsonWithoutDiscriminator.Deserialize<Affinity.ListCatalogItemsResponseDataItemQuantityConstraintUnresolved?>(
                        options
                    )
                        ?? throw new JsonException(
                            "Failed to deserialize Affinity.ListCatalogItemsResponseDataItemQuantityConstraintUnresolved"
                        ),
                _ => json.Deserialize<object?>(options),
            };
            return new ListCatalogItemsResponseDataItemQuantityConstraint(discriminator, value);
        }

        public override void Write(
            Utf8JsonWriter writer,
            ListCatalogItemsResponseDataItemQuantityConstraint value,
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

        public override ListCatalogItemsResponseDataItemQuantityConstraint ReadAsPropertyName(
            ref Utf8JsonReader reader,
            global::System.Type typeToConvert,
            JsonSerializerOptions options
        )
        {
            var stringValue =
                reader.GetString()
                ?? throw new JsonException("The JSON property name could not be read as a string.");
            return new ListCatalogItemsResponseDataItemQuantityConstraint(stringValue, stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            ListCatalogItemsResponseDataItemQuantityConstraint value,
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
        public Fixed(Affinity.ListCatalogItemsResponseDataItemQuantityConstraintFixed value)
        {
            Value = value;
        }

        internal Affinity.ListCatalogItemsResponseDataItemQuantityConstraintFixed Value { get; set; }

        public override string ToString() => Value.ToString() ?? "null";

        public static implicit operator ListCatalogItemsResponseDataItemQuantityConstraint.Fixed(
            Affinity.ListCatalogItemsResponseDataItemQuantityConstraintFixed value
        ) => new(value);
    }

    /// <summary>
    /// Discriminated union type for choices
    /// </summary>
    [Serializable]
    public struct Choices
    {
        public Choices(Affinity.ListCatalogItemsResponseDataItemQuantityConstraintChoices value)
        {
            Value = value;
        }

        internal Affinity.ListCatalogItemsResponseDataItemQuantityConstraintChoices Value { get; set; }

        public override string ToString() => Value.ToString() ?? "null";

        public static implicit operator ListCatalogItemsResponseDataItemQuantityConstraint.Choices(
            Affinity.ListCatalogItemsResponseDataItemQuantityConstraintChoices value
        ) => new(value);
    }

    /// <summary>
    /// Discriminated union type for range
    /// </summary>
    [Serializable]
    public struct Range
    {
        public Range(Affinity.ListCatalogItemsResponseDataItemQuantityConstraintRange value)
        {
            Value = value;
        }

        internal Affinity.ListCatalogItemsResponseDataItemQuantityConstraintRange Value { get; set; }

        public override string ToString() => Value.ToString() ?? "null";

        public static implicit operator ListCatalogItemsResponseDataItemQuantityConstraint.Range(
            Affinity.ListCatalogItemsResponseDataItemQuantityConstraintRange value
        ) => new(value);
    }

    /// <summary>
    /// Discriminated union type for unresolved
    /// </summary>
    [Serializable]
    public struct Unresolved
    {
        public Unresolved(
            Affinity.ListCatalogItemsResponseDataItemQuantityConstraintUnresolved value
        )
        {
            Value = value;
        }

        internal Affinity.ListCatalogItemsResponseDataItemQuantityConstraintUnresolved Value { get; set; }

        public override string ToString() => Value.ToString() ?? "null";

        public static implicit operator ListCatalogItemsResponseDataItemQuantityConstraint.Unresolved(
            Affinity.ListCatalogItemsResponseDataItemQuantityConstraintUnresolved value
        ) => new(value);
    }
}
