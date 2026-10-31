// ReSharper disable NullableWarningSuppressionIsUsed
// ReSharper disable InconsistentNaming

using Affinity.Core;
using global::System.Text.Json;
using global::System.Text.Json.Nodes;
using global::System.Text.Json.Serialization;

namespace Affinity;

[JsonConverter(typeof(WebhookEvent.JsonConverter))]
[Serializable]
public record WebhookEvent
{
    internal WebhookEvent(string type, object? value)
    {
        Type = type;
        Value = value;
    }

    /// <summary>
    /// Create an instance of WebhookEvent with <see cref="WebhookEvent.OrderCancelled"/>.
    /// </summary>
    public WebhookEvent(WebhookEvent.OrderCancelled value)
    {
        Type = "order.cancelled";
        Value = value.Value;
    }

    /// <summary>
    /// Create an instance of WebhookEvent with <see cref="WebhookEvent.OrderDelivered"/>.
    /// </summary>
    public WebhookEvent(WebhookEvent.OrderDelivered value)
    {
        Type = "order.delivered";
        Value = value.Value;
    }

    /// <summary>
    /// Create an instance of WebhookEvent with <see cref="WebhookEvent.OrderFailed"/>.
    /// </summary>
    public WebhookEvent(WebhookEvent.OrderFailed value)
    {
        Type = "order.failed";
        Value = value.Value;
    }

    /// <summary>
    /// Create an instance of WebhookEvent with <see cref="WebhookEvent.OrderProcessing"/>.
    /// </summary>
    public WebhookEvent(WebhookEvent.OrderProcessing value)
    {
        Type = "order.processing";
        Value = value.Value;
    }

    /// <summary>
    /// Create an instance of WebhookEvent with <see cref="WebhookEvent.OrderShipped"/>.
    /// </summary>
    public WebhookEvent(WebhookEvent.OrderShipped value)
    {
        Type = "order.shipped";
        Value = value.Value;
    }

    /// <summary>
    /// Create an instance of WebhookEvent with <see cref="WebhookEvent.OrderSubmitted"/>.
    /// </summary>
    public WebhookEvent(WebhookEvent.OrderSubmitted value)
    {
        Type = "order.submitted";
        Value = value.Value;
    }

    /// <summary>
    /// Create an instance of WebhookEvent with <see cref="WebhookEvent.OrderUpdated"/>.
    /// </summary>
    public WebhookEvent(WebhookEvent.OrderUpdated value)
    {
        Type = "order.updated";
        Value = value.Value;
    }

    /// <summary>
    /// Create an instance of WebhookEvent with <see cref="WebhookEvent.PrescriptionFailed"/>.
    /// </summary>
    public WebhookEvent(WebhookEvent.PrescriptionFailed value)
    {
        Type = "prescription.failed";
        Value = value.Value;
    }

    /// <summary>
    /// Create an instance of WebhookEvent with <see cref="WebhookEvent.PrescriptionCancelled"/>.
    /// </summary>
    public WebhookEvent(WebhookEvent.PrescriptionCancelled value)
    {
        Type = "prescription.cancelled";
        Value = value.Value;
    }

    /// <summary>
    /// Create an instance of WebhookEvent with <see cref="WebhookEvent.WebhookEndpointTest"/>.
    /// </summary>
    public WebhookEvent(WebhookEvent.WebhookEndpointTest value)
    {
        Type = "webhook_endpoint.test";
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
    /// Returns true if <see cref="Type"/> is "order.cancelled"
    /// </summary>
    public bool IsOrderCancelled => Type == "order.cancelled";

    /// <summary>
    /// Returns true if <see cref="Type"/> is "order.delivered"
    /// </summary>
    public bool IsOrderDelivered => Type == "order.delivered";

    /// <summary>
    /// Returns true if <see cref="Type"/> is "order.failed"
    /// </summary>
    public bool IsOrderFailed => Type == "order.failed";

    /// <summary>
    /// Returns true if <see cref="Type"/> is "order.processing"
    /// </summary>
    public bool IsOrderProcessing => Type == "order.processing";

    /// <summary>
    /// Returns true if <see cref="Type"/> is "order.shipped"
    /// </summary>
    public bool IsOrderShipped => Type == "order.shipped";

    /// <summary>
    /// Returns true if <see cref="Type"/> is "order.submitted"
    /// </summary>
    public bool IsOrderSubmitted => Type == "order.submitted";

    /// <summary>
    /// Returns true if <see cref="Type"/> is "order.updated"
    /// </summary>
    public bool IsOrderUpdated => Type == "order.updated";

    /// <summary>
    /// Returns true if <see cref="Type"/> is "prescription.failed"
    /// </summary>
    public bool IsPrescriptionFailed => Type == "prescription.failed";

    /// <summary>
    /// Returns true if <see cref="Type"/> is "prescription.cancelled"
    /// </summary>
    public bool IsPrescriptionCancelled => Type == "prescription.cancelled";

    /// <summary>
    /// Returns true if <see cref="Type"/> is "webhook_endpoint.test"
    /// </summary>
    public bool IsWebhookEndpointTest => Type == "webhook_endpoint.test";

    /// <summary>
    /// Returns the value as a <see cref="Affinity.OrderEvent"/> if <see cref="Type"/> is 'order.cancelled', otherwise throws an exception.
    /// </summary>
    /// <exception cref="Exception">Thrown when <see cref="Type"/> is not 'order.cancelled'.</exception>
    public Affinity.OrderEvent AsOrderCancelled() =>
        IsOrderCancelled
            ? (Affinity.OrderEvent)Value!
            : throw new global::System.Exception("WebhookEvent.Type is not 'order.cancelled'");

    /// <summary>
    /// Returns the value as a <see cref="Affinity.OrderEvent"/> if <see cref="Type"/> is 'order.delivered', otherwise throws an exception.
    /// </summary>
    /// <exception cref="Exception">Thrown when <see cref="Type"/> is not 'order.delivered'.</exception>
    public Affinity.OrderEvent AsOrderDelivered() =>
        IsOrderDelivered
            ? (Affinity.OrderEvent)Value!
            : throw new global::System.Exception("WebhookEvent.Type is not 'order.delivered'");

    /// <summary>
    /// Returns the value as a <see cref="Affinity.OrderEvent"/> if <see cref="Type"/> is 'order.failed', otherwise throws an exception.
    /// </summary>
    /// <exception cref="Exception">Thrown when <see cref="Type"/> is not 'order.failed'.</exception>
    public Affinity.OrderEvent AsOrderFailed() =>
        IsOrderFailed
            ? (Affinity.OrderEvent)Value!
            : throw new global::System.Exception("WebhookEvent.Type is not 'order.failed'");

    /// <summary>
    /// Returns the value as a <see cref="Affinity.OrderEvent"/> if <see cref="Type"/> is 'order.processing', otherwise throws an exception.
    /// </summary>
    /// <exception cref="Exception">Thrown when <see cref="Type"/> is not 'order.processing'.</exception>
    public Affinity.OrderEvent AsOrderProcessing() =>
        IsOrderProcessing
            ? (Affinity.OrderEvent)Value!
            : throw new global::System.Exception("WebhookEvent.Type is not 'order.processing'");

    /// <summary>
    /// Returns the value as a <see cref="Affinity.OrderEvent"/> if <see cref="Type"/> is 'order.shipped', otherwise throws an exception.
    /// </summary>
    /// <exception cref="Exception">Thrown when <see cref="Type"/> is not 'order.shipped'.</exception>
    public Affinity.OrderEvent AsOrderShipped() =>
        IsOrderShipped
            ? (Affinity.OrderEvent)Value!
            : throw new global::System.Exception("WebhookEvent.Type is not 'order.shipped'");

    /// <summary>
    /// Returns the value as a <see cref="Affinity.OrderEvent"/> if <see cref="Type"/> is 'order.submitted', otherwise throws an exception.
    /// </summary>
    /// <exception cref="Exception">Thrown when <see cref="Type"/> is not 'order.submitted'.</exception>
    public Affinity.OrderEvent AsOrderSubmitted() =>
        IsOrderSubmitted
            ? (Affinity.OrderEvent)Value!
            : throw new global::System.Exception("WebhookEvent.Type is not 'order.submitted'");

    /// <summary>
    /// Returns the value as a <see cref="Affinity.OrderEvent"/> if <see cref="Type"/> is 'order.updated', otherwise throws an exception.
    /// </summary>
    /// <exception cref="Exception">Thrown when <see cref="Type"/> is not 'order.updated'.</exception>
    public Affinity.OrderEvent AsOrderUpdated() =>
        IsOrderUpdated
            ? (Affinity.OrderEvent)Value!
            : throw new global::System.Exception("WebhookEvent.Type is not 'order.updated'");

    /// <summary>
    /// Returns the value as a <see cref="Affinity.PrescriptionEvent"/> if <see cref="Type"/> is 'prescription.failed', otherwise throws an exception.
    /// </summary>
    /// <exception cref="Exception">Thrown when <see cref="Type"/> is not 'prescription.failed'.</exception>
    public Affinity.PrescriptionEvent AsPrescriptionFailed() =>
        IsPrescriptionFailed
            ? (Affinity.PrescriptionEvent)Value!
            : throw new global::System.Exception("WebhookEvent.Type is not 'prescription.failed'");

    /// <summary>
    /// Returns the value as a <see cref="Affinity.PrescriptionEvent"/> if <see cref="Type"/> is 'prescription.cancelled', otherwise throws an exception.
    /// </summary>
    /// <exception cref="Exception">Thrown when <see cref="Type"/> is not 'prescription.cancelled'.</exception>
    public Affinity.PrescriptionEvent AsPrescriptionCancelled() =>
        IsPrescriptionCancelled
            ? (Affinity.PrescriptionEvent)Value!
            : throw new global::System.Exception(
                "WebhookEvent.Type is not 'prescription.cancelled'"
            );

    /// <summary>
    /// Returns the value as a <see cref="Affinity.WebhookEndpointTestEvent"/> if <see cref="Type"/> is 'webhook_endpoint.test', otherwise throws an exception.
    /// </summary>
    /// <exception cref="Exception">Thrown when <see cref="Type"/> is not 'webhook_endpoint.test'.</exception>
    public Affinity.WebhookEndpointTestEvent AsWebhookEndpointTest() =>
        IsWebhookEndpointTest
            ? (Affinity.WebhookEndpointTestEvent)Value!
            : throw new global::System.Exception(
                "WebhookEvent.Type is not 'webhook_endpoint.test'"
            );

    public T Match<T>(
        Func<Affinity.OrderEvent, T> onOrderCancelled,
        Func<Affinity.OrderEvent, T> onOrderDelivered,
        Func<Affinity.OrderEvent, T> onOrderFailed,
        Func<Affinity.OrderEvent, T> onOrderProcessing,
        Func<Affinity.OrderEvent, T> onOrderShipped,
        Func<Affinity.OrderEvent, T> onOrderSubmitted,
        Func<Affinity.OrderEvent, T> onOrderUpdated,
        Func<Affinity.PrescriptionEvent, T> onPrescriptionFailed,
        Func<Affinity.PrescriptionEvent, T> onPrescriptionCancelled,
        Func<Affinity.WebhookEndpointTestEvent, T> onWebhookEndpointTest,
        Func<string, object?, T> onUnknown_
    )
    {
        return Type switch
        {
            "order.cancelled" => onOrderCancelled(AsOrderCancelled()),
            "order.delivered" => onOrderDelivered(AsOrderDelivered()),
            "order.failed" => onOrderFailed(AsOrderFailed()),
            "order.processing" => onOrderProcessing(AsOrderProcessing()),
            "order.shipped" => onOrderShipped(AsOrderShipped()),
            "order.submitted" => onOrderSubmitted(AsOrderSubmitted()),
            "order.updated" => onOrderUpdated(AsOrderUpdated()),
            "prescription.failed" => onPrescriptionFailed(AsPrescriptionFailed()),
            "prescription.cancelled" => onPrescriptionCancelled(AsPrescriptionCancelled()),
            "webhook_endpoint.test" => onWebhookEndpointTest(AsWebhookEndpointTest()),
            _ => onUnknown_(Type, Value),
        };
    }

    public void Visit(
        Action<Affinity.OrderEvent> onOrderCancelled,
        Action<Affinity.OrderEvent> onOrderDelivered,
        Action<Affinity.OrderEvent> onOrderFailed,
        Action<Affinity.OrderEvent> onOrderProcessing,
        Action<Affinity.OrderEvent> onOrderShipped,
        Action<Affinity.OrderEvent> onOrderSubmitted,
        Action<Affinity.OrderEvent> onOrderUpdated,
        Action<Affinity.PrescriptionEvent> onPrescriptionFailed,
        Action<Affinity.PrescriptionEvent> onPrescriptionCancelled,
        Action<Affinity.WebhookEndpointTestEvent> onWebhookEndpointTest,
        Action<string, object?> onUnknown_
    )
    {
        switch (Type)
        {
            case "order.cancelled":
                onOrderCancelled(AsOrderCancelled());
                break;
            case "order.delivered":
                onOrderDelivered(AsOrderDelivered());
                break;
            case "order.failed":
                onOrderFailed(AsOrderFailed());
                break;
            case "order.processing":
                onOrderProcessing(AsOrderProcessing());
                break;
            case "order.shipped":
                onOrderShipped(AsOrderShipped());
                break;
            case "order.submitted":
                onOrderSubmitted(AsOrderSubmitted());
                break;
            case "order.updated":
                onOrderUpdated(AsOrderUpdated());
                break;
            case "prescription.failed":
                onPrescriptionFailed(AsPrescriptionFailed());
                break;
            case "prescription.cancelled":
                onPrescriptionCancelled(AsPrescriptionCancelled());
                break;
            case "webhook_endpoint.test":
                onWebhookEndpointTest(AsWebhookEndpointTest());
                break;
            default:
                onUnknown_(Type, Value);
                break;
        }
    }

    /// <summary>
    /// Attempts to cast the value to a <see cref="Affinity.OrderEvent"/> and returns true if successful.
    /// </summary>
    public bool TryAsOrderCancelled(out Affinity.OrderEvent? value)
    {
        if (Type == "order.cancelled")
        {
            value = (Affinity.OrderEvent)Value!;
            return true;
        }
        value = null;
        return false;
    }

    /// <summary>
    /// Attempts to cast the value to a <see cref="Affinity.OrderEvent"/> and returns true if successful.
    /// </summary>
    public bool TryAsOrderDelivered(out Affinity.OrderEvent? value)
    {
        if (Type == "order.delivered")
        {
            value = (Affinity.OrderEvent)Value!;
            return true;
        }
        value = null;
        return false;
    }

    /// <summary>
    /// Attempts to cast the value to a <see cref="Affinity.OrderEvent"/> and returns true if successful.
    /// </summary>
    public bool TryAsOrderFailed(out Affinity.OrderEvent? value)
    {
        if (Type == "order.failed")
        {
            value = (Affinity.OrderEvent)Value!;
            return true;
        }
        value = null;
        return false;
    }

    /// <summary>
    /// Attempts to cast the value to a <see cref="Affinity.OrderEvent"/> and returns true if successful.
    /// </summary>
    public bool TryAsOrderProcessing(out Affinity.OrderEvent? value)
    {
        if (Type == "order.processing")
        {
            value = (Affinity.OrderEvent)Value!;
            return true;
        }
        value = null;
        return false;
    }

    /// <summary>
    /// Attempts to cast the value to a <see cref="Affinity.OrderEvent"/> and returns true if successful.
    /// </summary>
    public bool TryAsOrderShipped(out Affinity.OrderEvent? value)
    {
        if (Type == "order.shipped")
        {
            value = (Affinity.OrderEvent)Value!;
            return true;
        }
        value = null;
        return false;
    }

    /// <summary>
    /// Attempts to cast the value to a <see cref="Affinity.OrderEvent"/> and returns true if successful.
    /// </summary>
    public bool TryAsOrderSubmitted(out Affinity.OrderEvent? value)
    {
        if (Type == "order.submitted")
        {
            value = (Affinity.OrderEvent)Value!;
            return true;
        }
        value = null;
        return false;
    }

    /// <summary>
    /// Attempts to cast the value to a <see cref="Affinity.OrderEvent"/> and returns true if successful.
    /// </summary>
    public bool TryAsOrderUpdated(out Affinity.OrderEvent? value)
    {
        if (Type == "order.updated")
        {
            value = (Affinity.OrderEvent)Value!;
            return true;
        }
        value = null;
        return false;
    }

    /// <summary>
    /// Attempts to cast the value to a <see cref="Affinity.PrescriptionEvent"/> and returns true if successful.
    /// </summary>
    public bool TryAsPrescriptionFailed(out Affinity.PrescriptionEvent? value)
    {
        if (Type == "prescription.failed")
        {
            value = (Affinity.PrescriptionEvent)Value!;
            return true;
        }
        value = null;
        return false;
    }

    /// <summary>
    /// Attempts to cast the value to a <see cref="Affinity.PrescriptionEvent"/> and returns true if successful.
    /// </summary>
    public bool TryAsPrescriptionCancelled(out Affinity.PrescriptionEvent? value)
    {
        if (Type == "prescription.cancelled")
        {
            value = (Affinity.PrescriptionEvent)Value!;
            return true;
        }
        value = null;
        return false;
    }

    /// <summary>
    /// Attempts to cast the value to a <see cref="Affinity.WebhookEndpointTestEvent"/> and returns true if successful.
    /// </summary>
    public bool TryAsWebhookEndpointTest(out Affinity.WebhookEndpointTestEvent? value)
    {
        if (Type == "webhook_endpoint.test")
        {
            value = (Affinity.WebhookEndpointTestEvent)Value!;
            return true;
        }
        value = null;
        return false;
    }

    public override string ToString() => JsonUtils.Serialize(this);

    public static implicit operator WebhookEvent(WebhookEvent.OrderCancelled value) => new(value);

    public static implicit operator WebhookEvent(WebhookEvent.OrderDelivered value) => new(value);

    public static implicit operator WebhookEvent(WebhookEvent.OrderFailed value) => new(value);

    public static implicit operator WebhookEvent(WebhookEvent.OrderProcessing value) => new(value);

    public static implicit operator WebhookEvent(WebhookEvent.OrderShipped value) => new(value);

    public static implicit operator WebhookEvent(WebhookEvent.OrderSubmitted value) => new(value);

    public static implicit operator WebhookEvent(WebhookEvent.OrderUpdated value) => new(value);

    public static implicit operator WebhookEvent(WebhookEvent.PrescriptionFailed value) =>
        new(value);

    public static implicit operator WebhookEvent(WebhookEvent.PrescriptionCancelled value) =>
        new(value);

    public static implicit operator WebhookEvent(WebhookEvent.WebhookEndpointTest value) =>
        new(value);

    [Serializable]
    internal sealed class JsonConverter : JsonConverter<WebhookEvent>
    {
        public override bool CanConvert(global::System.Type typeToConvert) =>
            typeof(WebhookEvent).IsAssignableFrom(typeToConvert);

        public override WebhookEvent Read(
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
                "order.cancelled" => jsonWithoutDiscriminator.Deserialize<Affinity.OrderEvent?>(
                    options
                ) ?? throw new JsonException("Failed to deserialize Affinity.OrderEvent"),
                "order.delivered" => jsonWithoutDiscriminator.Deserialize<Affinity.OrderEvent?>(
                    options
                ) ?? throw new JsonException("Failed to deserialize Affinity.OrderEvent"),
                "order.failed" => jsonWithoutDiscriminator.Deserialize<Affinity.OrderEvent?>(
                    options
                ) ?? throw new JsonException("Failed to deserialize Affinity.OrderEvent"),
                "order.processing" => jsonWithoutDiscriminator.Deserialize<Affinity.OrderEvent?>(
                    options
                ) ?? throw new JsonException("Failed to deserialize Affinity.OrderEvent"),
                "order.shipped" => jsonWithoutDiscriminator.Deserialize<Affinity.OrderEvent?>(
                    options
                ) ?? throw new JsonException("Failed to deserialize Affinity.OrderEvent"),
                "order.submitted" => jsonWithoutDiscriminator.Deserialize<Affinity.OrderEvent?>(
                    options
                ) ?? throw new JsonException("Failed to deserialize Affinity.OrderEvent"),
                "order.updated" => jsonWithoutDiscriminator.Deserialize<Affinity.OrderEvent?>(
                    options
                ) ?? throw new JsonException("Failed to deserialize Affinity.OrderEvent"),
                "prescription.failed" =>
                    jsonWithoutDiscriminator.Deserialize<Affinity.PrescriptionEvent?>(options)
                        ?? throw new JsonException(
                            "Failed to deserialize Affinity.PrescriptionEvent"
                        ),
                "prescription.cancelled" =>
                    jsonWithoutDiscriminator.Deserialize<Affinity.PrescriptionEvent?>(options)
                        ?? throw new JsonException(
                            "Failed to deserialize Affinity.PrescriptionEvent"
                        ),
                "webhook_endpoint.test" =>
                    jsonWithoutDiscriminator.Deserialize<Affinity.WebhookEndpointTestEvent?>(
                        options
                    )
                        ?? throw new JsonException(
                            "Failed to deserialize Affinity.WebhookEndpointTestEvent"
                        ),
                _ => json.Deserialize<object?>(options),
            };
            return new WebhookEvent(discriminator, value);
        }

        public override void Write(
            Utf8JsonWriter writer,
            WebhookEvent value,
            JsonSerializerOptions options
        )
        {
            JsonNode json =
                value.Type switch
                {
                    "order.cancelled" => JsonSerializer.SerializeToNode(value.Value, options),
                    "order.delivered" => JsonSerializer.SerializeToNode(value.Value, options),
                    "order.failed" => JsonSerializer.SerializeToNode(value.Value, options),
                    "order.processing" => JsonSerializer.SerializeToNode(value.Value, options),
                    "order.shipped" => JsonSerializer.SerializeToNode(value.Value, options),
                    "order.submitted" => JsonSerializer.SerializeToNode(value.Value, options),
                    "order.updated" => JsonSerializer.SerializeToNode(value.Value, options),
                    "prescription.failed" => JsonSerializer.SerializeToNode(value.Value, options),
                    "prescription.cancelled" => JsonSerializer.SerializeToNode(
                        value.Value,
                        options
                    ),
                    "webhook_endpoint.test" => JsonSerializer.SerializeToNode(value.Value, options),
                    _ => JsonSerializer.SerializeToNode(value.Value, options),
                } ?? new JsonObject();
            json["type"] = value.Type;
            json.WriteTo(writer, options);
        }

        public override WebhookEvent ReadAsPropertyName(
            ref Utf8JsonReader reader,
            global::System.Type typeToConvert,
            JsonSerializerOptions options
        )
        {
            var stringValue =
                reader.GetString()
                ?? throw new JsonException("The JSON property name could not be read as a string.");
            return new WebhookEvent(stringValue, stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            WebhookEvent value,
            JsonSerializerOptions options
        )
        {
            writer.WritePropertyName(value.Type);
        }
    }

    /// <summary>
    /// Discriminated union type for order.cancelled
    /// </summary>
    [Serializable]
    public struct OrderCancelled
    {
        public OrderCancelled(Affinity.OrderEvent value)
        {
            Value = value;
        }

        internal Affinity.OrderEvent Value { get; set; }

        public override string ToString() => Value.ToString() ?? "null";

        public static implicit operator WebhookEvent.OrderCancelled(Affinity.OrderEvent value) =>
            new(value);
    }

    /// <summary>
    /// Discriminated union type for order.delivered
    /// </summary>
    [Serializable]
    public struct OrderDelivered
    {
        public OrderDelivered(Affinity.OrderEvent value)
        {
            Value = value;
        }

        internal Affinity.OrderEvent Value { get; set; }

        public override string ToString() => Value.ToString() ?? "null";

        public static implicit operator WebhookEvent.OrderDelivered(Affinity.OrderEvent value) =>
            new(value);
    }

    /// <summary>
    /// Discriminated union type for order.failed
    /// </summary>
    [Serializable]
    public struct OrderFailed
    {
        public OrderFailed(Affinity.OrderEvent value)
        {
            Value = value;
        }

        internal Affinity.OrderEvent Value { get; set; }

        public override string ToString() => Value.ToString() ?? "null";

        public static implicit operator WebhookEvent.OrderFailed(Affinity.OrderEvent value) =>
            new(value);
    }

    /// <summary>
    /// Discriminated union type for order.processing
    /// </summary>
    [Serializable]
    public struct OrderProcessing
    {
        public OrderProcessing(Affinity.OrderEvent value)
        {
            Value = value;
        }

        internal Affinity.OrderEvent Value { get; set; }

        public override string ToString() => Value.ToString() ?? "null";

        public static implicit operator WebhookEvent.OrderProcessing(Affinity.OrderEvent value) =>
            new(value);
    }

    /// <summary>
    /// Discriminated union type for order.shipped
    /// </summary>
    [Serializable]
    public struct OrderShipped
    {
        public OrderShipped(Affinity.OrderEvent value)
        {
            Value = value;
        }

        internal Affinity.OrderEvent Value { get; set; }

        public override string ToString() => Value.ToString() ?? "null";

        public static implicit operator WebhookEvent.OrderShipped(Affinity.OrderEvent value) =>
            new(value);
    }

    /// <summary>
    /// Discriminated union type for order.submitted
    /// </summary>
    [Serializable]
    public struct OrderSubmitted
    {
        public OrderSubmitted(Affinity.OrderEvent value)
        {
            Value = value;
        }

        internal Affinity.OrderEvent Value { get; set; }

        public override string ToString() => Value.ToString() ?? "null";

        public static implicit operator WebhookEvent.OrderSubmitted(Affinity.OrderEvent value) =>
            new(value);
    }

    /// <summary>
    /// Discriminated union type for order.updated
    /// </summary>
    [Serializable]
    public struct OrderUpdated
    {
        public OrderUpdated(Affinity.OrderEvent value)
        {
            Value = value;
        }

        internal Affinity.OrderEvent Value { get; set; }

        public override string ToString() => Value.ToString() ?? "null";

        public static implicit operator WebhookEvent.OrderUpdated(Affinity.OrderEvent value) =>
            new(value);
    }

    /// <summary>
    /// Discriminated union type for prescription.failed
    /// </summary>
    [Serializable]
    public struct PrescriptionFailed
    {
        public PrescriptionFailed(Affinity.PrescriptionEvent value)
        {
            Value = value;
        }

        internal Affinity.PrescriptionEvent Value { get; set; }

        public override string ToString() => Value.ToString() ?? "null";

        public static implicit operator WebhookEvent.PrescriptionFailed(
            Affinity.PrescriptionEvent value
        ) => new(value);
    }

    /// <summary>
    /// Discriminated union type for prescription.cancelled
    /// </summary>
    [Serializable]
    public struct PrescriptionCancelled
    {
        public PrescriptionCancelled(Affinity.PrescriptionEvent value)
        {
            Value = value;
        }

        internal Affinity.PrescriptionEvent Value { get; set; }

        public override string ToString() => Value.ToString() ?? "null";

        public static implicit operator WebhookEvent.PrescriptionCancelled(
            Affinity.PrescriptionEvent value
        ) => new(value);
    }

    /// <summary>
    /// Discriminated union type for webhook_endpoint.test
    /// </summary>
    [Serializable]
    public struct WebhookEndpointTest
    {
        public WebhookEndpointTest(Affinity.WebhookEndpointTestEvent value)
        {
            Value = value;
        }

        internal Affinity.WebhookEndpointTestEvent Value { get; set; }

        public override string ToString() => Value.ToString() ?? "null";

        public static implicit operator WebhookEvent.WebhookEndpointTest(
            Affinity.WebhookEndpointTestEvent value
        ) => new(value);
    }
}
