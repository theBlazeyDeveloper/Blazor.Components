using Components.Inputs.Models.Abstract;
using Components.Inputs.Models.Providers;

namespace Components.Inputs.Models
{
    public class TextInputParameters<T> : InputParameters<T>
    {
        /// <summary>
        /// Enable or Disable Auto-Complete feature of input. Default is false
        /// </summary>
        public bool AutoComplete { get; set; } = default!;

        /// <summary>
        /// Sets the 'placeholder' attribute of the input element
        /// </summary>
        public string PlaceHolder { get; set; } = default!;

        /// <summary>
        /// Sets the 'readonly' attribute of the input element. Default is false
        /// </summary>
        public bool ReadOnly { get; set; } = default!;

        /// <summary>
        /// Type of input. Default value is InputType.Text
        /// </summary>
        public override InputTypes InputType { get; set; } = InputTypes.Text;

        protected string ReadOnlyValue { get => ReadOnly ? "readonly" : ""; }
        protected string AutoCompleteValue { get => AutoComplete ? "on" : "off"; }

        public TextInputParameters(object For, Type ModelType) : base(For, ModelType)
        {
            if (ModelType != null && For != null)
                LabelValue = LabelValueProvider.GetLabelValue($"{For}", ModelType);
        }
    }
}
