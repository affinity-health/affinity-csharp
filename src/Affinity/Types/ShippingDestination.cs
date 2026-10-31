// ReSharper disable NullableWarningSuppressionIsUsed
// ReSharper disable InconsistentNaming

using Affinity.Core;
using global::System.Text.Json;
using global::System.Text.Json.Nodes;
using global::System.Text.Json.Serialization;

namespace Affinity;

/// <summary>
/// The shipping destination; defaults to the patient's address when omitted.
/// </summary>
[JsonConverter(typeof(ShippingDestination.JsonConverter))]
[Serializable]
public record ShippingDestination
{
    internal ShippingDestination(string type, object? value)
    {
        Type = type;
        Value = value;
    }

    /// <summary>
    /// Create an instance of ShippingDestination with <see cref="ShippingDestination.Patient"/>.
    /// </summary>
    public ShippingDestination(ShippingDestination.Patient value)
    {
        Type = "patient";
        Value = value.Value;
    }

    /// <summary>
    /// Create an instance of ShippingDestination with <see cref="ShippingDestination.Practice"/>.
    /// </summary>
    public ShippingDestination(ShippingDestination.Practice value)
    {
        Type = "practice";
        Value = value.Value;
    }

    /// <summary>
    /// Create an instance of ShippingDestination with <see cref="ShippingDestination.Address"/>.
    /// </summary>
    public ShippingDestination(ShippingDestination.Address value)
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
    /// Returns the value as a <see cref="Affinity.ShippingDestinationPatient"/> if <see cref="Type"/> is 'patient', otherwise throws an exception.
    /// </summary>
    /// <exception cref="Exception">Thrown when <see cref="Type"/> is not 'patient'.</exception>
    public Affinity.ShippingDestinationPatient AsPatient() =>
        IsPatient
            ? (Affinity.ShippingDestinationPatient)Value!
            : throw new global::System.Exception("ShippingDestination.Type is not 'patient'");

    /// <summary>
    /// Returns the value as a <see cref="Affinity.ShippingDestinationPractice"/> if <see cref="Type"/> is 'practice', otherwise throws an exception.
    /// </summary>
    /// <exception cref="Exception">Thrown when <see cref="Type"/> is not 'practice'.</exception>
    public Affinity.ShippingDestinationPractice AsPractice() =>
        IsPractice
            ? (Affinity.ShippingDestinationPractice)Value!
            : throw new global::System.Exception("ShippingDestination.Type is not 'practice'");

    /// <summary>
    /// Returns the value as a <see cref="Affinity.ShippingDestinationAddress"/> if <see cref="Type"/> is 'address', otherwise throws an exception.
    /// </summary>
    /// <exception cref="Exception">Thrown when <see cref="Type"/> is not 'address'.</exception>
    public Affinity.ShippingDestinationAddress AsAddress() =>
        IsAddress
            ? (Affinity.ShippingDestinationAddress)Value!
            : throw new global::System.Exception("ShippingDestination.Type is not 'address'");

    public T Match<T>(
        Func<Affinity.ShippingDestinationPatient, T> onPatient,
        Func<Affinity.ShippingDestinationPractice, T> onPractice,
        Func<Affinity.ShippingDestinationAddress, T> onAddress,
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
        Action<Affinity.ShippingDestinationPatient> onPatient,
        Action<Affinity.ShippingDestinationPractice> onPractice,
        Action<Affinity.ShippingDestinationAddress> onAddress,
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
    /// Attempts to cast the value to a <see cref="Affinity.ShippingDestinationPatient"/> and returns true if successful.
    /// </summary>
    public bool TryAsPatient(out Affinity.ShippingDestinationPatient? value)
    {
        if (Type == "patient")
        {
            value = (Affinity.ShippingDestinationPatient)Value!;
            return true;
        }
        value = null;
        return false;
    }

    /// <summary>
    /// Attempts to cast the value to a <see cref="Affinity.ShippingDestinationPractice"/> and returns true if successful.
    /// </summary>
    public bool TryAsPractice(out Affinity.ShippingDestinationPractice? value)
    {
        if (Type == "practice")
        {
            value = (Affinity.ShippingDestinationPractice)Value!;
            return true;
        }
        value = null;
        return false;
    }

    /// <summary>
    /// Attempts to cast the value to a <see cref="Affinity.ShippingDestinationAddress"/> and returns true if successful.
    /// </summary>
    public bool TryAsAddress(out Affinity.ShippingDestinationAddress? value)
    {
        if (Type == "address")
        {
            value = (Affinity.ShippingDestinationAddress)Value!;
            return true;
        }
        value = null;
        return false;
    }

    public override string ToString() => JsonUtils.Serialize(this);

    public static implicit operator ShippingDestination(ShippingDestination.Patient value) =>
        new(value);

    public static implicit operator ShippingDestination(ShippingDestination.Practice value) =>
        new(value);

    public static implicit operator ShippingDestination(ShippingDestination.Address value) =>
        new(value);

    [Serializable]
    internal sealed class JsonConverter : JsonConverter<ShippingDestination>
    {
        public override bool CanConvert(global::System.Type typeToConvert) =>
            typeof(ShippingDestination).IsAssignableFrom(typeToConvert);

        public override ShippingDestination Read(
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
                    jsonWithoutDiscriminator.Deserialize<Affinity.ShippingDestinationPatient?>(
                        options
                    )
                        ?? throw new JsonException(
                            "Failed to deserialize Affinity.ShippingDestinationPatient"
                        ),
                "practice" =>
                    jsonWithoutDiscriminator.Deserialize<Affinity.ShippingDestinationPractice?>(
                        options
                    )
                        ?? throw new JsonException(
                            "Failed to deserialize Affinity.ShippingDestinationPractice"
                        ),
                "address" =>
                    jsonWithoutDiscriminator.Deserialize<Affinity.ShippingDestinationAddress?>(
                        options
                    )
                        ?? throw new JsonException(
                            "Failed to deserialize Affinity.ShippingDestinationAddress"
                        ),
                _ => json.Deserialize<object?>(options),
            };
            return new ShippingDestination(discriminator, value);
        }

        public override void Write(
            Utf8JsonWriter writer,
            ShippingDestination value,
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

        public override ShippingDestination ReadAsPropertyName(
            ref Utf8JsonReader reader,
            global::System.Type typeToConvert,
            JsonSerializerOptions options
        )
        {
            var stringValue =
                reader.GetString()
                ?? throw new JsonException("The JSON property name could not be read as a string.");
            return new ShippingDestination(stringValue, stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            ShippingDestination value,
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
        public Patient(Affinity.ShippingDestinationPatient value)
        {
            Value = value;
        }

        internal Affinity.ShippingDestinationPatient Value { get; set; }

        public override string ToString() => Value.ToString() ?? "null";

        public static implicit operator ShippingDestination.Patient(
            Affinity.ShippingDestinationPatient value
        ) => new(value);
    }

    /// <summary>
    /// Discriminated union type for practice
    /// </summary>
    [Serializable]
    public struct Practice
    {
        public Practice(Affinity.ShippingDestinationPractice value)
        {
            Value = value;
        }

        internal Affinity.ShippingDestinationPractice Value { get; set; }

        public override string ToString() => Value.ToString() ?? "null";

        public static implicit operator ShippingDestination.Practice(
            Affinity.ShippingDestinationPractice value
        ) => new(value);
    }

    /// <summary>
    /// Discriminated union type for address
    /// </summary>
    [Serializable]
    public struct Address
    {
        public Address(Affinity.ShippingDestinationAddress value)
        {
            Value = value;
        }

        internal Affinity.ShippingDestinationAddress Value { get; set; }

        public override string ToString() => Value.ToString() ?? "null";

        public static implicit operator ShippingDestination.Address(
            Affinity.ShippingDestinationAddress value
        ) => new(value);
    }
}
