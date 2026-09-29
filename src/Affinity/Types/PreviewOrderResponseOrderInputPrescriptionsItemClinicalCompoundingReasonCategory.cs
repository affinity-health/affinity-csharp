using Affinity.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Affinity;

[JsonConverter(
    typeof(PreviewOrderResponseOrderInputPrescriptionsItemClinicalCompoundingReasonCategory.PreviewOrderResponseOrderInputPrescriptionsItemClinicalCompoundingReasonCategorySerializer)
)]
[Serializable]
public readonly record struct PreviewOrderResponseOrderInputPrescriptionsItemClinicalCompoundingReasonCategory
    : IStringEnum
{
    public static readonly PreviewOrderResponseOrderInputPrescriptionsItemClinicalCompoundingReasonCategory AlcoholFree =
        new(Values.AlcoholFree);

    public static readonly PreviewOrderResponseOrderInputPrescriptionsItemClinicalCompoundingReasonCategory DrugShortage =
        new(Values.DrugShortage);

    public static readonly PreviewOrderResponseOrderInputPrescriptionsItemClinicalCompoundingReasonCategory CommercialProductDiscontinued =
        new(Values.CommercialProductDiscontinued);

    public static readonly PreviewOrderResponseOrderInputPrescriptionsItemClinicalCompoundingReasonCategory ModifiedRelease =
        new(Values.ModifiedRelease);

    public static readonly PreviewOrderResponseOrderInputPrescriptionsItemClinicalCompoundingReasonCategory InactiveIngredientSensitivity =
        new(Values.InactiveIngredientSensitivity);

    public static readonly PreviewOrderResponseOrderInputPrescriptionsItemClinicalCompoundingReasonCategory InactiveIngredientToxicity =
        new(Values.InactiveIngredientToxicity);

    public static readonly PreviewOrderResponseOrderInputPrescriptionsItemClinicalCompoundingReasonCategory ConcentrationAdjustment =
        new(Values.ConcentrationAdjustment);

    public static readonly PreviewOrderResponseOrderInputPrescriptionsItemClinicalCompoundingReasonCategory AlternateRoute =
        new(Values.AlternateRoute);

    public static readonly PreviewOrderResponseOrderInputPrescriptionsItemClinicalCompoundingReasonCategory DosageFormUnavailable =
        new(Values.DosageFormUnavailable);

    public static readonly PreviewOrderResponseOrderInputPrescriptionsItemClinicalCompoundingReasonCategory FlavorAdjustment =
        new(Values.FlavorAdjustment);

    public static readonly PreviewOrderResponseOrderInputPrescriptionsItemClinicalCompoundingReasonCategory TabletBurden =
        new(Values.TabletBurden);

    public static readonly PreviewOrderResponseOrderInputPrescriptionsItemClinicalCompoundingReasonCategory PatientCannotUseCommercialProduct =
        new(Values.PatientCannotUseCommercialProduct);

    public static readonly PreviewOrderResponseOrderInputPrescriptionsItemClinicalCompoundingReasonCategory NoApprovedProductAvailable =
        new(Values.NoApprovedProductAvailable);

    public static readonly PreviewOrderResponseOrderInputPrescriptionsItemClinicalCompoundingReasonCategory NoRationaleRequired =
        new(Values.NoRationaleRequired);

    public static readonly PreviewOrderResponseOrderInputPrescriptionsItemClinicalCompoundingReasonCategory OtherPatientSpecificNeed =
        new(Values.OtherPatientSpecificNeed);

    public PreviewOrderResponseOrderInputPrescriptionsItemClinicalCompoundingReasonCategory(
        string value
    )
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
    public static PreviewOrderResponseOrderInputPrescriptionsItemClinicalCompoundingReasonCategory FromCustom(
        string value
    )
    {
        return new PreviewOrderResponseOrderInputPrescriptionsItemClinicalCompoundingReasonCategory(
            value
        );
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
        PreviewOrderResponseOrderInputPrescriptionsItemClinicalCompoundingReasonCategory value1,
        string value2
    ) => value1.Value.Equals(value2);

    public static bool operator !=(
        PreviewOrderResponseOrderInputPrescriptionsItemClinicalCompoundingReasonCategory value1,
        string value2
    ) => !value1.Value.Equals(value2);

    public static explicit operator string(
        PreviewOrderResponseOrderInputPrescriptionsItemClinicalCompoundingReasonCategory value
    ) => value.Value;

    public static explicit operator PreviewOrderResponseOrderInputPrescriptionsItemClinicalCompoundingReasonCategory(
        string value
    ) => new(value);

    internal class PreviewOrderResponseOrderInputPrescriptionsItemClinicalCompoundingReasonCategorySerializer
        : JsonConverter<PreviewOrderResponseOrderInputPrescriptionsItemClinicalCompoundingReasonCategory>
    {
        public override PreviewOrderResponseOrderInputPrescriptionsItemClinicalCompoundingReasonCategory Read(
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
            return new PreviewOrderResponseOrderInputPrescriptionsItemClinicalCompoundingReasonCategory(
                stringValue
            );
        }

        public override void Write(
            Utf8JsonWriter writer,
            PreviewOrderResponseOrderInputPrescriptionsItemClinicalCompoundingReasonCategory value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override PreviewOrderResponseOrderInputPrescriptionsItemClinicalCompoundingReasonCategory ReadAsPropertyName(
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
            return new PreviewOrderResponseOrderInputPrescriptionsItemClinicalCompoundingReasonCategory(
                stringValue
            );
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            PreviewOrderResponseOrderInputPrescriptionsItemClinicalCompoundingReasonCategory value,
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
