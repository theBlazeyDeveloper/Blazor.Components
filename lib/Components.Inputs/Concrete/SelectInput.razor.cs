using Components.Inputs.Models;
using Components.Inputs.Models.Providers;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using System.Globalization;
using System.Linq.Expressions;

namespace Components.Inputs.Concrete
{
    public class SelectInputBase<T> : InputSelect<T>
    {
        /// <summary>
        /// Set the Property being used in the input along with the property 'ModelType'
        /// in order to retrieve the value in the Models '[Display]' attribute
        /// </summary>
        [Parameter] public object For { get; set; } = default!;

        /// <summary>
        /// Set the Type of Model being used along with the property 'For'
        /// in order to retrieve the value in the Models '[Display]' attribute
        /// </summary>
        [Parameter] public Type ModelType { get; set; } = default!;

        /// <summary>
        /// Css class for the input element. Default value is 'form-control'
        /// </summary>
        [Parameter] public virtual string ClassCss { get; set; } = "form-control";

        /// <summary>
        /// Sets the 'disabled' attribute of the input element
        /// </summary>
        [Parameter] public virtual bool Disabled { get; set; }

        /// <summary>
        /// If the selectable items have a color value for the 'Value' property.
        /// </summary>
        [Parameter] public bool ColoredItems { get; set; }

        /// <summary>
        /// Sets the 'title' attribute of the input element
        /// </summary>
        [Parameter] public string Title { get; set; } = default!;

        /// <summary>
        /// Prepends the label to the begining of the input element. Default is true
        /// </summary>
        [Parameter] public virtual bool PrependLabel { get; set; } = true;

        /// <summary>
        /// Add label from this component. Default is true
        /// </summary>
        [Parameter] public virtual bool UseLabel { get; init; } = true;

        [Parameter] public SelectInputParameters<T> Parameters { get; init; } = default!;

        [Parameter] public IEnumerable<SelectListItem> Items { get; set; } = Enumerable.Empty<SelectListItem>();

        /// <summary>
        /// Sets the Validation for the input element
        /// </summary>
        [Parameter] public Expression<Func<T>> ValidationFor { get; set; } = default!;

        protected string LabelValue { get; set; } = default!;

        protected override Task OnParametersSetAsync()
        {
            if (ModelType != null && For != null)
                LabelValue = LabelValueProvider.GetLabelValue($"{For}", ModelType);

            if (Parameters != null)
                SetParameters(Parameters);

            //Console.BackgroundColor = ConsoleColor.DarkGray;
            //Console.WriteLine($"Select Input Value Type: {typeof(T).Name}");

            return Task.CompletedTask;
        }

        private void SetParameters(SelectInputParameters<T> p)
        {
            For = p.For;
            ModelType = p.ModelType;

            if (!string.IsNullOrEmpty(p.Title))
                Title = p.Title;

            if (p.ValidationFor != null)
                ValidationFor = p.ValidationFor;

            Disabled = p.Disabled;
            PrependLabel = p.PrependLabel;

            if (!string.IsNullOrEmpty(p.ClassCss))
                ClassCss = p.ClassCss;

            ColoredItems = p.ColoredItems;

            if (p.Items.Any())
                Items = p.Items;

            LabelValue = LabelValueProvider.GetLabelValue($"{For}", ModelType);
        }

        protected override bool TryParseValueFromString(string? value, out T result, out string validationErrorMessage)
        {
            if (typeof(T) == typeof(string))
            {
                if (!string.IsNullOrEmpty(value))
                {
                    result = (T)(object)value;
                    validationErrorMessage = null!;
                    return true;
                }
            }
            else if (typeof(T) == typeof(int))
            {
                int.TryParse(value, NumberStyles.Integer, CultureInfo.InvariantCulture, out var parsedValue);
                result = (T)(object)parsedValue;
                validationErrorMessage = null!;

                return true;
            }
            else if (typeof(T) == typeof(Guid))
            {
                _ = Guid.TryParse(value, out var parsedValue);
                result = (T)(object)parsedValue;
                validationErrorMessage = null!;

                return true;
            }
            else if (typeof(T).IsEnum)
            {
                try
                {
                    result = (T)Enum.Parse(typeof(T), value);
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

            throw new InvalidOperationException($"{GetType()} does not support the type '{typeof(T)}'.");
        }
    }
}