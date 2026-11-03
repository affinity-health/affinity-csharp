using Affinity.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Affinity;

/// <summary>
/// The patient details that the pharmacy receives.
/// </summary>
[Serializable]
public record PatientInput : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    [JsonPropertyName("address")]
    public required AddressInput Address { get; set; }

    /// <summary>
    /// The reported allergies. Send `[]` when the patient reports no new allergies.
    /// </summary>
    [JsonPropertyName("allergies")]
    public IEnumerable<PatientInputAllergiesItem> Allergies { get; set; } =
        new List<PatientInputAllergiesItem>();

    /// <summary>
    /// A real calendar date in YYYY-MM-DD format, with a year from 1900 through 2099, today or earlier in UTC. Surrounding spaces are removed.
    /// </summary>
    [JsonPropertyName("dateOfBirth")]
    public required string DateOfBirth { get; set; }

    /// <summary>
    /// The patient's email address.
    /// </summary>
    [JsonPropertyName("email")]
    public required string Email { get; set; }

    /// <summary>
    /// The first name. N/A, TBD, unknown and none return 422.
    /// </summary>
    [JsonPropertyName("firstName")]
    public required string FirstName { get; set; }

    /// <summary>
    /// The patient's sex as sent to the pharmacy.
    /// </summary>
    [JsonPropertyName("sex")]
    public required PatientInputSex Sex { get; set; }

    /// <summary>
    /// The last name. N/A, TBD, unknown and none return 422.
    /// </summary>
    [JsonPropertyName("lastName")]
    public required string LastName { get; set; }

    /// <summary>
    /// The patient's middle name, or null when there is none. Empty text counts as null.
    /// </summary>
    [JsonPropertyName("middleName")]
    public string? MiddleName { get; set; }

    /// <summary>
    /// A US phone number: 10 digits, with or without +1 or 1 before them. Spaces, dashes, dots and parentheses are allowed, such as (512) 555-0100. Affinity stores and returns +15125550100.
    /// </summary>
    [JsonPropertyName("phone")]
    public required string Phone { get; set; }

    /// <summary>
    /// Your patient identifier within the practice and mode. Omit it and id to create a new patient for each order. With id, send the saved patient's externalId or omit it. If the saved patient has none, this value is added to it.
    /// </summary>
    [JsonPropertyName("externalId")]
    public string? ExternalId { get; set; }

    /// <summary>
    /// The pat_ ID of a saved patient of the order's practice, in the same Test or Live mode. The order reuses that patient and updates it from the sent fields. Send all other patient fields as usual. GET /v1/orders returns the patientId of each order. An unknown ID, or an ID of a different practice or mode, returns 404 not_found.
    /// </summary>
    [JsonPropertyName("id")]
    public string? Id { get; set; }

    [JsonIgnore]
    public ReadOnlyAdditionalProperties AdditionalProperties { get; private set; } = new();

    void IJsonOnDeserialized.OnDeserialized() =>
        AdditionalProperties.CopyFromExtensionData(_extensionData);

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
