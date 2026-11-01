// ReSharper disable NullableWarningSuppressionIsUsed
// ReSharper disable InconsistentNaming

using Affinity.Core;
using global::System.Text.Json;
using global::System.Text.Json.Nodes;
using global::System.Text.Json.Serialization;

namespace Affinity;

/// <summary>
/// Defaults to the patient's address. State restrictions and pharmacy coverage use the destination's state.
/// </summary>
[JsonConverter(typeof(ShippingDestinationInput.JsonConverter))]
[Serializable]
public record ShippingDestinationInput
{
    internal ShippingDestinationInput(string type, object? value)
    {
        Type = type;
        Value = value;
    }

    /// <summary>
    /// Create an instance of ShippingDestinationInput with <see cref="ShippingDestinationInput.Patient"/>.
    /// </summary>
    public ShippingDestinationInput(ShippingDestinationInput.Patient value)
    {
        Type = "patient";
        Value = value.Value;
    }

    /// <summary>
    /// Create an instance of ShippingDestinationInput with <see cref="ShippingDestinationInput.Practice"/>.
    /// </summary>
    public ShippingDestinationInput(ShippingDestinationInput.Practice value)
    {
        Type = "practice";
        Value = value.Value;
    }

    /// <summary>
    /// Create an instance of ShippingDestinationInput with <see cref="ShippingDestinationInput.Address"/>.
    /// </summary>
    public ShippingDestinationInput(ShippingDestinationInput.Address value)
    {
        Type = "address";
        Value = value.Value;
    }

    /// <summary>
    /// Discriminant value
    /// </summary>
    [JsonPropertyName("type")]
    public string Type { get; internal set; }

    /// <summary>
    /// Discriminated union value
    /// </summary>
    public object? Value { get; internal set; }

    /// <summary>
    /// Returns true if <see cref="Type"/> is "patient"
    /// </summary>
    public bool IsPatient => Type == "patient";

    /// <summary>
    /// Returns true if <see cref="Type"/> is "practice"
    /// </summary>
    public bool IsPractice => Type == "practice";

    /// <summary>
    /// Returns true if <see cref="Type"/> is "address"
    /// </summary>
    public bool IsAddress => Type == "address";

    /// <summary>
    /// Returns the value as a <see cref="Affinity.ShippingDestinationPatientInput"/> if <see cref="Type"/> is 'patient', otherwise throws an exception.
    /// </summary>
    /// <exception cref="Exception">Thrown when <see cref="Type"/> is not 'patient'.</exception>
    public Affinity.ShippingDestinationPatientInput AsPatient() =>
        IsPatient
            ? (Affinity.ShippingDestinationPatientInput)Value!
            : throw new global::System.Exception("ShippingDestinationInput.Type is not 'patient'");

    /// <summary>
    /// Returns the value as a <see cref="Affinity.ShippingDestinationPracticeInput"/> if <see cref="Type"/> is 'practice', otherwise throws an exception.
    /// </summary>
    /// <exception cref="Exception">Thrown when <see cref="Type"/> is not 'practice'.</exception>
    public Affinity.ShippingDestinationPracticeInput AsPractice() =>
        IsPractice
            ? (Affinity.ShippingDestinationPracticeInput)Value!
            : throw new global::System.Exception("ShippingDestinationInput.Type is not 'practice'");

    /// <summary>
    /// Returns the value as a <see cref="Affinity.ShippingDestinationAddressInput"/> if <see cref="Type"/> is 'address', otherwise throws an exception.
    /// </summary>
    /// <exception cref="Exception">Thrown when <see cref="Type"/> is not 'address'.</exception>
    public Affinity.ShippingDestinationAddressInput AsAddress() =>
        IsAddress
            ? (Affinity.ShippingDestinationAddressInput)Value!
            : throw new global::System.Exception("ShippingDestinationInput.Type is not 'address'");

    public T Match<T>(
        Func<Affinity.ShippingDestinationPatientInput, T> onPatient,
        Func<Affinity.ShippingDestinationPracticeInput, T> onPractice,
        Func<Affinity.ShippingDestinationAddressInput, T> onAddress,
        Func<string, object?, T> onUnknown_
    )
    {
        return Type switch
        {
            "patient" => onPatient(AsPatient()),
            "practice" => onPractice(AsPractice()),
            "address" => onAddress(AsAddress()),
            _ => onUnknown_(Type, Value),
        };
    }

    public void Visit(
        Action<Affinity.ShippingDestinationPatientInput> onPatient,
        Action<Affinity.ShippingDestinationPracticeInput> onPractice,
        Action<Affinity.ShippingDestinationAddressInput> onAddress,
        Action<string, object?> onUnknown_
    )
    {
        switch (Type)
        {
            case "patient":
                onPatient(AsPatient());
                break;
            case "practice":
                onPractice(AsPractice());
                break;
            case "address":
                onAddress(AsAddress());
                break;
            default:
                onUnknown_(Type, Value);
                break;
        }
    }

    /// <summary>
    /// Attempts to cast the value to a <see cref="Affinity.ShippingDestinationPatientInput"/> and returns true if successful.
    /// </summary>
    public bool TryAsPatient(out Affinity.ShippingDestinationPatientInput? value)
    {
        if (Type == "patient")
        {
            value = (Affinity.ShippingDestinationPatientInput)Value!;
            return true;
        }
        value = null;
        return false;
    }

    /// <summary>
    /// Attempts to cast the value to a <see cref="Affinity.ShippingDestinationPracticeInput"/> and returns true if successful.
    /// </summary>
    public bool TryAsPractice(out Affinity.ShippingDestinationPracticeInput? value)
    {
        if (Type == "practice")
        {
            value = (Affinity.ShippingDestinationPracticeInput)Value!;
            return true;
        }
        value = null;
        return false;
    }

    /// <summary>
    /// Attempts to cast the value to a <see cref="Affinity.ShippingDestinationAddressInput"/> and returns true if successful.
    /// </summary>
    public bool TryAsAddress(out Affinity.ShippingDestinationAddressInput? value)
    {
        if (Type == "address")
        {
            value = (Affinity.ShippingDestinationAddressInput)Value!;
            return true;
        }
        value = null;
        return false;
    }

    public override string ToString() => JsonUtils.Serialize(this);

    public static implicit operator ShippingDestinationInput(
        ShippingDestinationInput.Patient value
    ) => new(value);

    public static implicit operator ShippingDestinationInput(
        ShippingDestinationInput.Practice value
    ) => new(value);

    public static implicit operator ShippingDestinationInput(
        ShippingDestinationInput.Address value
    ) => new(value);

    [Serializable]
    internal sealed class JsonConverter : JsonConverter<ShippingDestinationInput>
    {
        public override bool CanConvert(global::System.Type typeToConvert) =>
            typeof(ShippingDestinationInput).IsAssignableFrom(typeToConvert);

        public override ShippingDestinationInput Read(
            ref Utf8JsonReader reader,
            global::System.Type typeToConvert,
            JsonSerializerOptions options
        )
        {
            var json = JsonElement.ParseValue(ref reader);
            if (!json.TryGetProperty("type", out var discriminatorElement))
            {
                throw new JsonException("Missing discriminator property 'type'");
            }
            if (discriminatorElement.ValueKind != JsonValueKind.String)
            {
                if (discriminatorElement.ValueKind == JsonValueKind.Null)
                {
                    throw new JsonException("Discriminator property 'type' is null");
                }

                throw new JsonException(
                    $"Discriminator property 'type' is not a string, instead is {discriminatorElement.ToString()}"
                );
            }

            var discriminator =
                discriminatorElement.GetString()
                ?? throw new JsonException("Discriminator property 'type' is null");

            // Strip the discriminant property to prevent it from leaking into AdditionalProperties
            var jsonObject = System.Text.Json.Nodes.JsonObject.Create(json);
            jsonObject?.Remove("type");
            var jsonWithoutDiscriminator =
                jsonObject != null ? JsonSerializer.SerializeToElement(jsonObject, options) : json;

            var value = discriminator switch
            {
                "patient" =>
                    jsonWithoutDiscriminator.Deserialize<Affinity.ShippingDestinationPatientInput?>(
                        options
                    )
                        ?? throw new JsonException(
                            "Failed to deserialize Affinity.ShippingDestinationPatientInput"
                        ),
                "practice" =>
                    jsonWithoutDiscriminator.Deserialize<Affinity.ShippingDestinationPracticeInput?>(
                        options
                    )
                        ?? throw new JsonException(
                            "Failed to deserialize Affinity.ShippingDestinationPracticeInput"
                        ),
                "address" =>
                    jsonWithoutDiscriminator.Deserialize<Affinity.ShippingDestinationAddressInput?>(
                        options
                    )
                        ?? throw new JsonException(
                            "Failed to deserialize Affinity.ShippingDestinationAddressInput"
                        ),
                _ => json.Deserialize<object?>(options),
            };
            return new ShippingDestinationInput(discriminator, value);
        }

        public override void Write(
            Utf8JsonWriter writer,
            ShippingDestinationInput value,
            JsonSerializerOptions options
        )
        {
            JsonNode json =
                value.Type switch
                {
                    "patient" => JsonSerializer.SerializeToNode(value.Value, options),
                    "practice" => JsonSerializer.SerializeToNode(value.Value, options),
                    "address" => JsonSerializer.SerializeToNode(value.Value, options),
                    _ => JsonSerializer.SerializeToNode(value.Value, options),
                } ?? new JsonObject();
            json["type"] = value.Type;
            json.WriteTo(writer, options);
        }

        public override ShippingDestinationInput ReadAsPropertyName(
            ref Utf8JsonReader reader,
            global::System.Type typeToConvert,
            JsonSerializerOptions options
        )
        {
            var stringValue =
                reader.GetString()
                ?? throw new JsonException("The JSON property name could not be read as a string.");
            return new ShippingDestinationInput(stringValue, stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            ShippingDestinationInput value,
            JsonSerializerOptions options
        )
        {
            writer.WritePropertyName(value.Type);
        }
    }

    /// <summary>
    /// Discriminated union type for patient
    /// </summary>
    [Serializable]
    public struct Patient
    {
        public Patient(Affinity.ShippingDestinationPatientInput value)
        {
            Value = value;
        }

        internal Affinity.ShippingDestinationPatientInput Value { get; set; }

        public override string ToString() => Value.ToString() ?? "null";

        public static implicit operator ShippingDestinationInput.Patient(
            Affinity.ShippingDestinationPatientInput value
        ) => new(value);
    }

    /// <summary>
    /// Discriminated union type for practice
    /// </summary>
    [Serializable]
    public struct Practice
    {
        public Practice(Affinity.ShippingDestinationPracticeInput value)
        {
            Value = value;
        }

        internal Affinity.ShippingDestinationPracticeInput Value { get; set; }

        public override string ToString() => Value.ToString() ?? "null";

        public static implicit operator ShippingDestinationInput.Practice(
            Affinity.ShippingDestinationPracticeInput value
        ) => new(value);
    }

    /// <summary>
    /// Discriminated union type for address
    /// </summary>
    [Serializable]
    public struct Address
    {
        public Address(Affinity.ShippingDestinationAddressInput value)
        {
            Value = value;
        }

        internal Affinity.ShippingDestinationAddressInput Value { get; set; }

        public override string ToString() => Value.ToString() ?? "null";

        public static implicit operator ShippingDestinationInput.Address(
            Affinity.ShippingDestinationAddressInput value
        ) => new(value);
    }
}
