using Affinity.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Affinity;

[JsonConverter(
    typeof(RetrievePrescribingOptionsResponseCompoundingReasonCategoryDefault.RetrievePrescribingOptionsResponseCompoundingReasonCategoryDefaultSerializer)
)]
[Serializable]
public readonly record struct RetrievePrescribingOptionsResponseCompoundingReasonCategoryDefault
    : IStringEnum
{
    public static readonly RetrievePrescribingOptionsResponseCompoundingReasonCategoryDefault AlcoholFree =
        new(Values.AlcoholFree);

    public static readonly RetrievePrescribingOptionsResponseCompoundingReasonCategoryDefault DrugShortage =
        new(Values.DrugShortage);

    public static readonly RetrievePrescribingOptionsResponseCompoundingReasonCategoryDefault CommercialProductDiscontinued =
        new(Values.CommercialProductDiscontinued);

    public static readonly RetrievePrescribingOptionsResponseCompoundingReasonCategoryDefault ModifiedRelease =
        new(Values.ModifiedRelease);

    public static readonly RetrievePrescribingOptionsResponseCompoundingReasonCategoryDefault InactiveIngredientSensitivity =
        new(Values.InactiveIngredientSensitivity);

    public static readonly RetrievePrescribingOptionsResponseCompoundingReasonCategoryDefault InactiveIngredientToxicity =
        new(Values.InactiveIngredientToxicity);

    public static readonly RetrievePrescribingOptionsResponseCompoundingReasonCategoryDefault ConcentrationAdjustment =
        new(Values.ConcentrationAdjustment);

    public static readonly RetrievePrescribingOptionsResponseCompoundingReasonCategoryDefault AlternateRoute =
        new(Values.AlternateRoute);

    public static readonly RetrievePrescribingOptionsResponseCompoundingReasonCategoryDefault DosageFormUnavailable =
        new(Values.DosageFormUnavailable);

    public static readonly RetrievePrescribingOptionsResponseCompoundingReasonCategoryDefault FlavorAdjustment =
        new(Values.FlavorAdjustment);

    public static readonly RetrievePrescribingOptionsResponseCompoundingReasonCategoryDefault TabletBurden =
        new(Values.TabletBurden);

    public static readonly RetrievePrescribingOptionsResponseCompoundingReasonCategoryDefault PatientCannotUseCommercialProduct =
        new(Values.PatientCannotUseCommercialProduct);

    public static readonly RetrievePrescribingOptionsResponseCompoundingReasonCategoryDefault NoApprovedProductAvailable =
        new(Values.NoApprovedProductAvailable);

    public static readonly RetrievePrescribingOptionsResponseCompoundingReasonCategoryDefault NoRationaleRequired =
        new(Values.NoRationaleRequired);

    public static readonly RetrievePrescribingOptionsResponseCompoundingReasonCategoryDefault OtherPatientSpecificNeed =
        new(Values.OtherPatientSpecificNeed);

    public RetrievePrescribingOptionsResponseCompoundingReasonCategoryDefault(string value)
    {
        Value = value;
    }

    /// <summary>
    /// The string value of the enum.
    /// </summary>
    public string Value { get; }

    /// <summary>
    /// Create a string enum with the given value.
    /// </summary>
    public static RetrievePrescribingOptionsResponseCompoundingReasonCategoryDefault FromCustom(
        string value
    )
    {
        return new RetrievePrescribingOptionsResponseCompoundingReasonCategoryDefault(value);
    }

    public bool Equals(string? other)
    {
        return Value.Equals(other);
    }

    /// <summary>
    /// Returns the string value of the enum.
    /// </summary>
    public override string ToString()
    {
        return Value;
    }

    public static bool operator ==(
        RetrievePrescribingOptionsResponseCompoundingReasonCategoryDefault value1,
        string value2
    ) => value1.Value.Equals(value2);

    public static bool operator !=(
        RetrievePrescribingOptionsResponseCompoundingReasonCategoryDefault value1,
        string value2
    ) => !value1.Value.Equals(value2);

    public static explicit operator string(
        RetrievePrescribingOptionsResponseCompoundingReasonCategoryDefault value
    ) => value.Value;

    public static explicit operator RetrievePrescribingOptionsResponseCompoundingReasonCategoryDefault(
        string value
    ) => new(value);

    internal class RetrievePrescribingOptionsResponseCompoundingReasonCategoryDefaultSerializer
        : JsonConverter<RetrievePrescribingOptionsResponseCompoundingReasonCategoryDefault>
    {
        public override RetrievePrescribingOptionsResponseCompoundingReasonCategoryDefault Read(
            ref Utf8JsonReader reader,
            Type typeToConvert,
            JsonSerializerOptions options
        )
        {
            var stringValue =
                reader.GetString()
                ?? throw new global::System.Exception(
                    "The JSON value could not be read as a string."
                );
            return new RetrievePrescribingOptionsResponseCompoundingReasonCategoryDefault(
                stringValue
            );
        }

        public override void Write(
            Utf8JsonWriter writer,
            RetrievePrescribingOptionsResponseCompoundingReasonCategoryDefault value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override RetrievePrescribingOptionsResponseCompoundingReasonCategoryDefault ReadAsPropertyName(
            ref Utf8JsonReader reader,
            Type typeToConvert,
            JsonSerializerOptions options
        )
        {
            var stringValue =
                reader.GetString()
                ?? throw new global::System.Exception(
                    "The JSON property name could not be read as a string."
                );
            return new RetrievePrescribingOptionsResponseCompoundingReasonCategoryDefault(
                stringValue
            );
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            RetrievePrescribingOptionsResponseCompoundingReasonCategoryDefault value,
            JsonSerializerOptions options
        )
        {
            writer.WritePropertyName(value.Value);
        }
    }

    /// <summary>
    /// Constant strings for enum values
    /// </summary>
    [Serializable]
    public static class Values
    {
        public const string AlcoholFree = "alcohol_free";

        public const string DrugShortage = "drug_shortage";

        public const string CommercialProductDiscontinued = "commercial_product_discontinued";

        public const string ModifiedRelease = "modified_release";

        public const string InactiveIngredientSensitivity = "inactive_ingredient_sensitivity";

        public const string InactiveIngredientToxicity = "inactive_ingredient_toxicity";

        public const string ConcentrationAdjustment = "concentration_adjustment";

        public const string AlternateRoute = "alternate_route";

        public const string DosageFormUnavailable = "dosage_form_unavailable";

        public const string FlavorAdjustment = "flavor_adjustment";

        public const string TabletBurden = "tablet_burden";

        public const string PatientCannotUseCommercialProduct =
            "patient_cannot_use_commercial_product";

        public const string NoApprovedProductAvailable = "no_approved_product_available";

        public const string NoRationaleRequired = "no_rationale_required";

        public const string OtherPatientSpecificNeed = "other_patient_specific_need";
    }
}
