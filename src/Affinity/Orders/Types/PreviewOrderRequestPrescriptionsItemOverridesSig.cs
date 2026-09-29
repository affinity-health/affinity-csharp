// ReSharper disable NullableWarningSuppressionIsUsed
// ReSharper disable InconsistentNaming

using Affinity.Core;
using global::System.Text.Json;
using global::System.Text.Json.Nodes;
using global::System.Text.Json.Serialization;

namespace Affinity;

[JsonConverter(typeof(PreviewOrderRequestPrescriptionsItemOverridesSig.JsonConverter))]
[Serializable]
public record PreviewOrderRequestPrescriptionsItemOverridesSig
{
    internal PreviewOrderRequestPrescriptionsItemOverridesSig(string type, object? value)
    {
        Format = type;
        Value = value;
    }

    /// <summary>
    /// Create an instance of PreviewOrderRequestPrescriptionsItemOverridesSig with <see cref="PreviewOrderRequestPrescriptionsItemOverridesSig.Structured"/>.
    /// </summary>
    public PreviewOrderRequestPrescriptionsItemOverridesSig(
        PreviewOrderRequestPrescriptionsItemOverridesSig.Structured value
    )
    {
        Format = "structured";
        Value = value.Value;
    }

    /// <summary>
    /// Create an instance of PreviewOrderRequestPrescriptionsItemOverridesSig with <see cref="PreviewOrderRequestPrescriptionsItemOverridesSig.FreeText"/>.
    /// </summary>
    public PreviewOrderRequestPrescriptionsItemOverridesSig(
        PreviewOrderRequestPrescriptionsItemOverridesSig.FreeText value
    )
    {
        Format = "free_text";
        Value = value.Value;
    }

    /// <summary>
    /// Create an instance of PreviewOrderRequestPrescriptionsItemOverridesSig with <see cref="PreviewOrderRequestPrescriptionsItemOverridesSig.Template"/>.
    /// </summary>
    public PreviewOrderRequestPrescriptionsItemOverridesSig(
        PreviewOrderRequestPrescriptionsItemOverridesSig.Template value
    )
    {
        Format = "template";
        Value = value.Value;
    }

    /// <summary>
    /// Discriminant value
    /// </summary>
    [JsonPropertyName("format")]
    public string Format { get; internal set; }

    /// <summary>
    /// Discriminated union value
    /// </summary>
    public object? Value { get; internal set; }

    /// <summary>
    /// Returns true if <see cref="Format"/> is "structured"
    /// </summary>
    public bool IsStructured => Format == "structured";

    /// <summary>
    /// Returns true if <see cref="Format"/> is "free_text"
    /// </summary>
    public bool IsFreeText => Format == "free_text";

    /// <summary>
    /// Returns true if <see cref="Format"/> is "template"
    /// </summary>
    public bool IsTemplate => Format == "template";

    /// <summary>
    /// Returns the value as a <see cref="Affinity.PreviewOrderRequestPrescriptionsItemOverridesSigStructured"/> if <see cref="Format"/> is 'structured', otherwise throws an exception.
    /// </summary>
    /// <exception cref="Exception">Thrown when <see cref="Format"/> is not 'structured'.</exception>
    public Affinity.PreviewOrderRequestPrescriptionsItemOverridesSigStructured AsStructured() =>
        IsStructured
            ? (Affinity.PreviewOrderRequestPrescriptionsItemOverridesSigStructured)Value!
            : throw new global::System.Exception(
                "PreviewOrderRequestPrescriptionsItemOverridesSig.Format is not 'structured'"
            );

    /// <summary>
    /// Returns the value as a <see cref="Affinity.PreviewOrderRequestPrescriptionsItemOverridesSigFreeText"/> if <see cref="Format"/> is 'free_text', otherwise throws an exception.
    /// </summary>
    /// <exception cref="Exception">Thrown when <see cref="Format"/> is not 'free_text'.</exception>
    public Affinity.PreviewOrderRequestPrescriptionsItemOverridesSigFreeText AsFreeText() =>
        IsFreeText
            ? (Affinity.PreviewOrderRequestPrescriptionsItemOverridesSigFreeText)Value!
            : throw new global::System.Exception(
                "PreviewOrderRequestPrescriptionsItemOverridesSig.Format is not 'free_text'"
            );

    /// <summary>
    /// Returns the value as a <see cref="Affinity.PreviewOrderRequestPrescriptionsItemOverridesSigTemplate"/> if <see cref="Format"/> is 'template', otherwise throws an exception.
    /// </summary>
    /// <exception cref="Exception">Thrown when <see cref="Format"/> is not 'template'.</exception>
    public Affinity.PreviewOrderRequestPrescriptionsItemOverridesSigTemplate AsTemplate() =>
        IsTemplate
            ? (Affinity.PreviewOrderRequestPrescriptionsItemOverridesSigTemplate)Value!
            : throw new global::System.Exception(
                "PreviewOrderRequestPrescriptionsItemOverridesSig.Format is not 'template'"
            );

    public T Match<T>(
        Func<Affinity.PreviewOrderRequestPrescriptionsItemOverridesSigStructured, T> onStructured,
        Func<Affinity.PreviewOrderRequestPrescriptionsItemOverridesSigFreeText, T> onFreeText,
        Func<Affinity.PreviewOrderRequestPrescriptionsItemOverridesSigTemplate, T> onTemplate,
        Func<string, object?, T> onUnknown_
    )
    {
        return Format switch
        {
            "structured" => onStructured(AsStructured()),
            "free_text" => onFreeText(AsFreeText()),
            "template" => onTemplate(AsTemplate()),
            _ => onUnknown_(Format, Value),
        };
    }

    public void Visit(
        Action<Affinity.PreviewOrderRequestPrescriptionsItemOverridesSigStructured> onStructured,
        Action<Affinity.PreviewOrderRequestPrescriptionsItemOverridesSigFreeText> onFreeText,
        Action<Affinity.PreviewOrderRequestPrescriptionsItemOverridesSigTemplate> onTemplate,
        Action<string, object?> onUnknown_
    )
    {
        switch (Format)
        {
            case "structured":
                onStructured(AsStructured());
                break;
            case "free_text":
                onFreeText(AsFreeText());
                break;
            case "template":
                onTemplate(AsTemplate());
                break;
            default:
                onUnknown_(Format, Value);
                break;
        }
    }

    /// <summary>
    /// Attempts to cast the value to a <see cref="Affinity.PreviewOrderRequestPrescriptionsItemOverridesSigStructured"/> and returns true if successful.
    /// </summary>
    public bool TryAsStructured(
        out Affinity.PreviewOrderRequestPrescriptionsItemOverridesSigStructured? value
    )
    {
        if (Format == "structured")
        {
            value = (Affinity.PreviewOrderRequestPrescriptionsItemOverridesSigStructured)Value!;
            return true;
        }
        value = null;
        return false;
    }

    /// <summary>
    /// Attempts to cast the value to a <see cref="Affinity.PreviewOrderRequestPrescriptionsItemOverridesSigFreeText"/> and returns true if successful.
    /// </summary>
    public bool TryAsFreeText(
        out Affinity.PreviewOrderRequestPrescriptionsItemOverridesSigFreeText? value
    )
    {
        if (Format == "free_text")
        {
            value = (Affinity.PreviewOrderRequestPrescriptionsItemOverridesSigFreeText)Value!;
            return true;
        }
        value = null;
        return false;
    }

    /// <summary>
    /// Attempts to cast the value to a <see cref="Affinity.PreviewOrderRequestPrescriptionsItemOverridesSigTemplate"/> and returns true if successful.
    /// </summary>
    public bool TryAsTemplate(
        out Affinity.PreviewOrderRequestPrescriptionsItemOverridesSigTemplate? value
    )
    {
        if (Format == "template")
        {
            value = (Affinity.PreviewOrderRequestPrescriptionsItemOverridesSigTemplate)Value!;
            return true;
        }
        value = null;
        return false;
    }

    public override string ToString() => JsonUtils.Serialize(this);

    public static implicit operator PreviewOrderRequestPrescriptionsItemOverridesSig(
        PreviewOrderRequestPrescriptionsItemOverridesSig.Structured value
    ) => new(value);

    public static implicit operator PreviewOrderRequestPrescriptionsItemOverridesSig(
        PreviewOrderRequestPrescriptionsItemOverridesSig.FreeText value
    ) => new(value);

    public static implicit operator PreviewOrderRequestPrescriptionsItemOverridesSig(
        PreviewOrderRequestPrescriptionsItemOverridesSig.Template value
    ) => new(value);

    [Serializable]
    internal sealed class JsonConverter
        : JsonConverter<PreviewOrderRequestPrescriptionsItemOverridesSig>
    {
        public override bool CanConvert(global::System.Type typeToConvert) =>
            typeof(PreviewOrderRequestPrescriptionsItemOverridesSig).IsAssignableFrom(
                typeToConvert
            );

        public override PreviewOrderRequestPrescriptionsItemOverridesSig Read(
            ref Utf8JsonReader reader,
            global::System.Type typeToConvert,
            JsonSerializerOptions options
        )
        {
            var json = JsonElement.ParseValue(ref reader);
            if (!json.TryGetProperty("format", out var discriminatorElement))
            {
                throw new JsonException("Missing discriminator property 'format'");
            }
            if (discriminatorElement.ValueKind != JsonValueKind.String)
            {
                if (discriminatorElement.ValueKind == JsonValueKind.Null)
                {
                    throw new JsonException("Discriminator property 'format' is null");
                }

                throw new JsonException(
                    $"Discriminator property 'format' is not a string, instead is {discriminatorElement.ToString()}"
                );
            }

            var discriminator =
                discriminatorElement.GetString()
                ?? throw new JsonException("Discriminator property 'format' is null");

            // Strip the discriminant property to prevent it from leaking into AdditionalProperties
            var jsonObject = System.Text.Json.Nodes.JsonObject.Create(json);
            jsonObject?.Remove("format");
            var jsonWithoutDiscriminator =
                jsonObject != null ? JsonSerializer.SerializeToElement(jsonObject, options) : json;

            var value = discriminator switch
            {
                "structured" =>
                    jsonWithoutDiscriminator.Deserialize<Affinity.PreviewOrderRequestPrescriptionsItemOverridesSigStructured?>(
                        options
                    )
                        ?? throw new JsonException(
                            "Failed to deserialize Affinity.PreviewOrderRequestPrescriptionsItemOverridesSigStructured"
                        ),
                "free_text" =>
                    jsonWithoutDiscriminator.Deserialize<Affinity.PreviewOrderRequestPrescriptionsItemOverridesSigFreeText?>(
                        options
                    )
                        ?? throw new JsonException(
                            "Failed to deserialize Affinity.PreviewOrderRequestPrescriptionsItemOverridesSigFreeText"
                        ),
                "template" =>
                    jsonWithoutDiscriminator.Deserialize<Affinity.PreviewOrderRequestPrescriptionsItemOverridesSigTemplate?>(
                        options
                    )
                        ?? throw new JsonException(
                            "Failed to deserialize Affinity.PreviewOrderRequestPrescriptionsItemOverridesSigTemplate"
                        ),
                _ => json.Deserialize<object?>(options),
            };
            return new PreviewOrderRequestPrescriptionsItemOverridesSig(discriminator, value);
        }

        public override void Write(
            Utf8JsonWriter writer,
            PreviewOrderRequestPrescriptionsItemOverridesSig value,
            JsonSerializerOptions options
        )
        {
            JsonNode json =
                value.Format switch
                {
                    "structured" => JsonSerializer.SerializeToNode(value.Value, options),
                    "free_text" => JsonSerializer.SerializeToNode(value.Value, options),
                    "template" => JsonSerializer.SerializeToNode(value.Value, options),
                    _ => JsonSerializer.SerializeToNode(value.Value, options),
                } ?? new JsonObject();
            json["format"] = value.Format;
            json.WriteTo(writer, options);
        }

        public override PreviewOrderRequestPrescriptionsItemOverridesSig ReadAsPropertyName(
            ref Utf8JsonReader reader,
            global::System.Type typeToConvert,
            JsonSerializerOptions options
        )
        {
            var stringValue =
                reader.GetString()
                ?? throw new JsonException("The JSON property name could not be read as a string.");
            return new PreviewOrderRequestPrescriptionsItemOverridesSig(stringValue, stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            PreviewOrderRequestPrescriptionsItemOverridesSig value,
            JsonSerializerOptions options
        )
        {
            writer.WritePropertyName(value.Format);
        }
    }

    /// <summary>
    /// Discriminated union type for structured
    /// </summary>
    [Serializable]
    public struct Structured
    {
        public Structured(Affinity.PreviewOrderRequestPrescriptionsItemOverridesSigStructured value)
        {
            Value = value;
        }

        internal Affinity.PreviewOrderRequestPrescriptionsItemOverridesSigStructured Value { get; set; }

        public override string ToString() => Value.ToString() ?? "null";

        public static implicit operator PreviewOrderRequestPrescriptionsItemOverridesSig.Structured(
            Affinity.PreviewOrderRequestPrescriptionsItemOverridesSigStructured value
        ) => new(value);
    }

    /// <summary>
    /// Discriminated union type for free_text
    /// </summary>
    [Serializable]
    public struct FreeText
    {
        public FreeText(Affinity.PreviewOrderRequestPrescriptionsItemOverridesSigFreeText value)
        {
            Value = value;
        }

        internal Affinity.PreviewOrderRequestPrescriptionsItemOverridesSigFreeText Value { get; set; }

        public override string ToString() => Value.ToString() ?? "null";

        public static implicit operator PreviewOrderRequestPrescriptionsItemOverridesSig.FreeText(
            Affinity.PreviewOrderRequestPrescriptionsItemOverridesSigFreeText value
        ) => new(value);
    }

    /// <summary>
    /// Discriminated union type for template
    /// </summary>
    [Serializable]
    public struct Template
    {
        public Template(Affinity.PreviewOrderRequestPrescriptionsItemOverridesSigTemplate value)
        {
            Value = value;
        }

        internal Affinity.PreviewOrderRequestPrescriptionsItemOverridesSigTemplate Value { get; set; }

        public override string ToString() => Value.ToString() ?? "null";

        public static implicit operator PreviewOrderRequestPrescriptionsItemOverridesSig.Template(
            Affinity.PreviewOrderRequestPrescriptionsItemOverridesSigTemplate value
        ) => new(value);
    }
}
