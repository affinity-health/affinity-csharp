using Affinity.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Affinity;

/// <summary>
/// The patient details saved when the order was signed.
/// </summary>
[Serializable]
public record Patient : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    [JsonPropertyName("address")]
    public required Address Address { get; set; }

    /// <summary>
    /// The reported allergies; an empty list means no new allergies reported.
    /// </summary>
    [JsonPropertyName("allergies")]
    public IEnumerable<Allergy> Allergies { get; set; } = new List<Allergy>();

    /// <summary>
    /// The patient's birth date in YYYY-MM-DD format.
    /// </summary>
    [JsonPropertyName("dateOfBirth")]
    public required DateOnly DateOfBirth { get; set; }

    /// <summary>
    /// The patient's email address.
    /// </summary>
    [JsonPropertyName("email")]
    public required string Email { get; set; }

    /// <summary>
    /// The first name.
    /// </summary>
    [JsonPropertyName("firstName")]
    public required string FirstName { get; set; }

    /// <summary>
    /// The patient's sex as sent to the pharmacy.
    /// </summary>
    [JsonPropertyName("sex")]
    public required PatientSex Sex { get; set; }

    /// <summary>
    /// The last name.
    /// </summary>
    [JsonPropertyName("lastName")]
    public required string LastName { get; set; }

    /// <summary>
    /// The patient's middle name, or null when there is none.
    /// </summary>
    [JsonPropertyName("middleName")]
    public string? MiddleName { get; set; }

    /// <summary>
    /// The contact phone number.
    /// </summary>
    [JsonPropertyName("phone")]
    public required string Phone { get; set; }

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
