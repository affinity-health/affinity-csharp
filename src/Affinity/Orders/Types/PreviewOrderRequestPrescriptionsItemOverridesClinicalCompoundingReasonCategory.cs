using Affinity.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Affinity;

[JsonConverter(
    typeof(PreviewOrderRequestPrescriptionsItemOverridesClinicalCompoundingReasonCategory.PreviewOrderRequestPrescriptionsItemOverridesClinicalCompoundingReasonCategorySerializer)
)]
[Serializable]
public readonly record struct PreviewOrderRequestPrescriptionsItemOverridesClinicalCompoundingReasonCategory
    : IStringEnum
{
    public static readonly PreviewOrderRequestPrescriptionsItemOverridesClinicalCompoundingReasonCategory AlcoholFree =
        new(Values.AlcoholFree);

    public static readonly PreviewOrderRequestPrescriptionsItemOverridesClinicalCompoundingReasonCategory DrugShortage =
        new(Values.DrugShortage);

    public static readonly PreviewOrderRequestPrescriptionsItemOverridesClinicalCompoundingReasonCategory CommercialProductDiscontinued =
        new(Values.CommercialProductDiscontinued);

    public static readonly PreviewOrderRequestPrescriptionsItemOverridesClinicalCompoundingReasonCategory ModifiedRelease =
        new(Values.ModifiedRelease);

    public static readonly PreviewOrderRequestPrescriptionsItemOverridesClinicalCompoundingReasonCategory InactiveIngredientSensitivity =
        new(Values.InactiveIngredientSensitivity);

    public static readonly PreviewOrderRequestPrescriptionsItemOverridesClinicalCompoundingReasonCategory InactiveIngredientToxicity =
        new(Values.InactiveIngredientToxicity);

    public static readonly PreviewOrderRequestPrescriptionsItemOverridesClinicalCompoundingReasonCategory ConcentrationAdjustment =
        new(Values.ConcentrationAdjustment);

    public static readonly PreviewOrderRequestPrescriptionsItemOverridesClinicalCompoundingReasonCategory AlternateRoute =
        new(Values.AlternateRoute);

    public static readonly PreviewOrderRequestPrescriptionsItemOverridesClinicalCompoundingReasonCategory DosageFormUnavailable =
        new(Values.DosageFormUnavailable);

    public static readonly PreviewOrderRequestPrescriptionsItemOverridesClinicalCompoundingReasonCategory FlavorAdjustment =
        new(Values.FlavorAdjustment);

    public static readonly PreviewOrderRequestPrescriptionsItemOverridesClinicalCompoundingReasonCategory TabletBurden =
        new(Values.TabletBurden);

    public static readonly PreviewOrderRequestPrescriptionsItemOverridesClinicalCompoundingReasonCategory PatientCannotUseCommercialProduct =
        new(Values.PatientCannotUseCommercialProduct);

    public static readonly PreviewOrderRequestPrescriptionsItemOverridesClinicalCompoundingReasonCategory NoApprovedProductAvailable =
        new(Values.NoApprovedProductAvailable);

    public static readonly PreviewOrderRequestPrescriptionsItemOverridesClinicalCompoundingReasonCategory NoRationaleRequired =
        new(Values.NoRationaleRequired);

    public static readonly PreviewOrderRequestPrescriptionsItemOverridesClinicalCompoundingReasonCategory OtherPatientSpecificNeed =
        new(Values.OtherPatientSpecificNeed);

    public PreviewOrderRequestPrescriptionsItemOverridesClinicalCompoundingReasonCategory(
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
    public static PreviewOrderRequestPrescriptionsItemOverridesClinicalCompoundingReasonCategory FromCustom(
        string value
    )
    {
        return new PreviewOrderRequestPrescriptionsItemOverridesClinicalCompoundingReasonCategory(
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
        PreviewOrderRequestPrescriptionsItemOverridesClinicalCompoundingReasonCategory value1,
        string value2
    ) => value1.Value.Equals(value2);

    public static bool operator !=(
        PreviewOrderRequestPrescriptionsItemOverridesClinicalCompoundingReasonCategory value1,
        string value2
    ) => !value1.Value.Equals(value2);

    public static explicit operator string(
        PreviewOrderRequestPrescriptionsItemOverridesClinicalCompoundingReasonCategory value
    ) => value.Value;

    public static explicit operator PreviewOrderRequestPrescriptionsItemOverridesClinicalCompoundingReasonCategory(
        string value
    ) => new(value);

    internal class PreviewOrderRequestPrescriptionsItemOverridesClinicalCompoundingReasonCategorySerializer
        : JsonConverter<PreviewOrderRequestPrescriptionsItemOverridesClinicalCompoundingReasonCategory>
    {
        public override PreviewOrderRequestPrescriptionsItemOverridesClinicalCompoundingReasonCategory Read(
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
            return new PreviewOrderRequestPrescriptionsItemOverridesClinicalCompoundingReasonCategory(
                stringValue
            );
        }

        public override void Write(
            Utf8JsonWriter writer,
            PreviewOrderRequestPrescriptionsItemOverridesClinicalCompoundingReasonCategory value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override PreviewOrderRequestPrescriptionsItemOverridesClinicalCompoundingReasonCategory ReadAsPropertyName(
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
            return new PreviewOrderRequestPrescriptionsItemOverridesClinicalCompoundingReasonCategory(
                stringValue
            );
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            PreviewOrderRequestPrescriptionsItemOverridesClinicalCompoundingReasonCategory value,
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
