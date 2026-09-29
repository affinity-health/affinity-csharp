using Affinity.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Affinity.Orders;

[JsonConverter(
    typeof(AddOrderPrescriptionRequestPrescriptionClinicalCompoundingReasonCategory.AddOrderPrescriptionRequestPrescriptionClinicalCompoundingReasonCategorySerializer)
)]
[Serializable]
public readonly record struct AddOrderPrescriptionRequestPrescriptionClinicalCompoundingReasonCategory
    : IStringEnum
{
    public static readonly AddOrderPrescriptionRequestPrescriptionClinicalCompoundingReasonCategory AlcoholFree =
        new(Values.AlcoholFree);

    public static readonly AddOrderPrescriptionRequestPrescriptionClinicalCompoundingReasonCategory DrugShortage =
        new(Values.DrugShortage);

    public static readonly AddOrderPrescriptionRequestPrescriptionClinicalCompoundingReasonCategory CommercialProductDiscontinued =
        new(Values.CommercialProductDiscontinued);

    public static readonly AddOrderPrescriptionRequestPrescriptionClinicalCompoundingReasonCategory ModifiedRelease =
        new(Values.ModifiedRelease);

    public static readonly AddOrderPrescriptionRequestPrescriptionClinicalCompoundingReasonCategory InactiveIngredientSensitivity =
        new(Values.InactiveIngredientSensitivity);

    public static readonly AddOrderPrescriptionRequestPrescriptionClinicalCompoundingReasonCategory InactiveIngredientToxicity =
        new(Values.InactiveIngredientToxicity);

    public static readonly AddOrderPrescriptionRequestPrescriptionClinicalCompoundingReasonCategory ConcentrationAdjustment =
        new(Values.ConcentrationAdjustment);

    public static readonly AddOrderPrescriptionRequestPrescriptionClinicalCompoundingReasonCategory AlternateRoute =
        new(Values.AlternateRoute);

    public static readonly AddOrderPrescriptionRequestPrescriptionClinicalCompoundingReasonCategory DosageFormUnavailable =
        new(Values.DosageFormUnavailable);

    public static readonly AddOrderPrescriptionRequestPrescriptionClinicalCompoundingReasonCategory FlavorAdjustment =
        new(Values.FlavorAdjustment);

    public static readonly AddOrderPrescriptionRequestPrescriptionClinicalCompoundingReasonCategory TabletBurden =
        new(Values.TabletBurden);

    public static readonly AddOrderPrescriptionRequestPrescriptionClinicalCompoundingReasonCategory PatientCannotUseCommercialProduct =
        new(Values.PatientCannotUseCommercialProduct);

    public static readonly AddOrderPrescriptionRequestPrescriptionClinicalCompoundingReasonCategory NoApprovedProductAvailable =
        new(Values.NoApprovedProductAvailable);

    public static readonly AddOrderPrescriptionRequestPrescriptionClinicalCompoundingReasonCategory NoRationaleRequired =
        new(Values.NoRationaleRequired);

    public static readonly AddOrderPrescriptionRequestPrescriptionClinicalCompoundingReasonCategory OtherPatientSpecificNeed =
        new(Values.OtherPatientSpecificNeed);

    public AddOrderPrescriptionRequestPrescriptionClinicalCompoundingReasonCategory(string value)
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
    public static AddOrderPrescriptionRequestPrescriptionClinicalCompoundingReasonCategory FromCustom(
        string value
    )
    {
        return new AddOrderPrescriptionRequestPrescriptionClinicalCompoundingReasonCategory(value);
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
        AddOrderPrescriptionRequestPrescriptionClinicalCompoundingReasonCategory value1,
        string value2
    ) => value1.Value.Equals(value2);

    public static bool operator !=(
        AddOrderPrescriptionRequestPrescriptionClinicalCompoundingReasonCategory value1,
        string value2
    ) => !value1.Value.Equals(value2);

    public static explicit operator string(
        AddOrderPrescriptionRequestPrescriptionClinicalCompoundingReasonCategory value
    ) => value.Value;

    public static explicit operator AddOrderPrescriptionRequestPrescriptionClinicalCompoundingReasonCategory(
        string value
    ) => new(value);

    internal class AddOrderPrescriptionRequestPrescriptionClinicalCompoundingReasonCategorySerializer
        : JsonConverter<AddOrderPrescriptionRequestPrescriptionClinicalCompoundingReasonCategory>
    {
        public override AddOrderPrescriptionRequestPrescriptionClinicalCompoundingReasonCategory Read(
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
            return new AddOrderPrescriptionRequestPrescriptionClinicalCompoundingReasonCategory(
                stringValue
            );
        }

        public override void Write(
            Utf8JsonWriter writer,
            AddOrderPrescriptionRequestPrescriptionClinicalCompoundingReasonCategory value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override AddOrderPrescriptionRequestPrescriptionClinicalCompoundingReasonCategory ReadAsPropertyName(
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
            return new AddOrderPrescriptionRequestPrescriptionClinicalCompoundingReasonCategory(
                stringValue
            );
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            AddOrderPrescriptionRequestPrescriptionClinicalCompoundingReasonCategory value,
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
