using Components.Inputs.Models.Providers;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using System.Globalization;
using System.Linq.Expressions;

namespace Components.Inputs.Concrete
{
    public class CheckBoxBase : InputBase<bool>
    {
        /// <summary>
        /// Set the Type of Model being used along with the property 'For'
        /// in order to retrieve the value in the Models '[Display]' attribute
        /// </summary>
        [Parameter] public Type Model { get; set; } = default!;

        /// <summary>
        /// Set the Property being used in the input along with the property 'ModelType'
        /// in order to retrieve the value in the Models '[Display]' attribute
        /// </summary>
        [Parameter] public object For { get; set; } = default!;

        [Parameter] public bool UseLabel { get; set; }

        [Parameter] public bool ReadOnly { get; set; }

        /// <summary>
        /// Sets the Validation for the input element
        /// </summary>
        [Parameter] public Expression<Func<bool>> ValidationFor { get; set; } = default!;

        public string LabelValue { get; set; } = default!;        

        protected override Task OnInitializedAsync()
        {
            if (Model != null && For != null)
                LabelValue = LabelValueProvider.GetLabelValue($"{For}", Model);

            return Task.CompletedTask;
        }

        protected override bool TryParseValueFromString(string? value, out bool result, out string validationErrorMessage)
        {
            if (!string.IsNullOrEmpty(value))
            {
                if (typeof(bool) == typeof(string))
                {
                    result = (bool)(object)value;
                    validationErrorMessage = null!;
                    return true;
                }
                else if (typeof(bool) == typeof(int))
                {
                    int.TryParse(value, NumberStyles.Integer, CultureInfo.InvariantCulture, out var parsedValue);
                    result = (bool)(object)parsedValue;
                    validationErrorMessage = null!;

                    return true;
                }
                else if (typeof(bool) == typeof(Guid))
                {
                    _ = Guid.TryParse(value, out var parsedValue);
                    result = (bool)(object)parsedValue;
                    validationErrorMessage = null!;

                    return true;
                }
                else if (typeof(bool).IsEnum)
                {
                    try
                    {
                        result = (bool)Enum.Parse(typeof(bool), value);
                        validationErrorMessage = null!;

                        return true;
                    }
                    catch (ArgumentException)
                    {
                        result = default;
                        validationErrorMessage = $"The {FieldIdentifier.FieldName} field is not valid.";

                        return false;
                    }
                }

                throw new InvalidOperationException($"{GetType()} does not support the type '{typeof(bool)}'.");
            }

            throw new ArgumentNullException(value);
        }
    }
}
