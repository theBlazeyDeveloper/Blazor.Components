using Components.Inputs.Models;
using Components.Inputs.Models.Providers;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using System.Globalization;
using System.Linq.Expressions;

namespace Components.Inputs.Concrete
{
    public class TextInputBase<T> : InputBase<T>
    {
        /// <summary>
        /// Set the Property being used in the input along with the property 'ModelType'
        /// in order to retrieve the value in the Models '[Display]' attribute
        /// </summary>
        [Parameter] public virtual object For { get; set; } = default!;
        /// <summary>
        /// Set the Type of Model being used along with the property 'For'
        /// in order to retrieve the value in the Models '[Display]' attribute
        /// </summary>
        [Parameter] public virtual Type ModelType { get; set; } = default!;
        /// <summary>
        /// Enable or Disable Auto-Complete feature of input. Default is false
        /// </summary>
        [Parameter] public virtual bool AutoComplete { get; set; }
        /// <summary>
        /// Sets the 'title' attribute of the input element
        /// </summary>
        [Parameter] public virtual string Title { get; set; } = default!;
        /// <summary>
        /// Sets the 'placeholder' attribute of the input element
        /// </summary>
        [Parameter] public virtual string PlaceHolder { get; set; } = " ";
        /// <summary>
        /// Sets the Validation for the input element
        /// </summary>
        [Parameter] public virtual Expression<Func<T>> ValidationFor { get; set; } = default!;
        /// <summary>
        /// Sets the 'readonly' attribute of the input element
        /// </summary>
        [Parameter] public virtual bool ReadOnly { get; set; }
        /// <summary>
        /// Sets the 'disabled' attribute of the input element
        /// </summary>
        [Parameter] public virtual bool Disabled { get; set; }
        /// <summary>
        /// Prepends the label to the begining of the input element. Default is true
        /// </summary>
        [Parameter] public virtual bool PrependLabel { get; set; } = true;
        /// <summary>
        /// Css class for the input element. Default value is 'form-control'
        /// </summary>
        [Parameter] public virtual string ClassCss { get; set; } = "form-control";
        /// <summary>
        /// Css class for the input element
        /// </summary>
        [Parameter] public virtual string IconCss { get; set; } = default!;

        [Parameter] public TextInputParameters<T> Parameters { get; set; } = default!;

        protected string LabelValue { get; set; } = default!;
        protected string DisabledValue { get => Disabled ? "disabled" : ""; }
        protected string ReadOnlyValue { get => ReadOnly ? "readonly" : ""; }
        protected string AutoCompleteValue { get => AutoComplete ? "autocomplete" : ""; }

        protected override void OnParametersSet()
        {
            if (ModelType != null && For != null)
                LabelValue = ModelType.GetDisplayValue($"{For}");
                ///LabelValue = LabelValueProvider.GetLabelValue($"{For}", ModelType);

            if (Parameters != null)
                SetParameters(Parameters);
        }

        private void SetParameters(TextInputParameters<T> p)
        {
            For = p.For;
            ModelType = p.ModelType;
            AutoComplete = p.AutoComplete;

            if (!string.IsNullOrEmpty(p.Title))
                Title = p.Title;

            if (!string.IsNullOrEmpty(p.PlaceHolder))
                PlaceHolder = p.PlaceHolder;

            if (p.ValidationFor != null)
                ValidationFor = p.ValidationFor;

            ReadOnly = p.ReadOnly;
            Disabled = p.Disabled;
            PrependLabel = p.PrependLabel;

            if (!string.IsNullOrEmpty(p.ClassCss))
                ClassCss = p.ClassCss;

            if (!string.IsNullOrEmpty(p.IconCss))
                IconCss = p.IconCss;

            LabelValue = LabelValueProvider.GetLabelValue($"{For}", ModelType);
        }

        protected override bool TryParseValueFromString(string? value, out T result, out string validationErrorMessage)
        {
            if (typeof(string) == typeof(string))
            {
                if (!string.IsNullOrWhiteSpace(value))
                {
                    result = (T)(object)value;
                    validationErrorMessage = null!;
                    return true;
                }                
            }
            else if (typeof(string) == typeof(int))
            {
                int.TryParse(value, NumberStyles.Integer, CultureInfo.InvariantCulture, out var parsedValue);
                result = (T)(object)parsedValue;
                validationErrorMessage = null!;

                return true;
            }
            else if (typeof(string) == typeof(Guid))
            {
                _ = Guid.TryParse(value, out var parsedValue);
                result = (T)(object)parsedValue;
                validationErrorMessage = null!;

                return true;
            }
            else if (typeof(string).IsEnum)
            {
                try
                {
                    result = (T)Enum.Parse(typeof(string), value);
                    validationErrorMessage = null!;

                    return true;
                }
                catch (ArgumentException)
                {
                    result = default!;
                    validationErrorMessage = $"The {FieldIdentifier.FieldName} field is not valid.";

                    return false;
                }
            }

            throw new InvalidOperationException($"{GetType()} does not support the type '{typeof(string)}'.");
        }
    }
}