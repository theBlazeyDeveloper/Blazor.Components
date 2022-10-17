using Components.Inputs.Models.Abstract;
using Components.Inputs.Models.Providers;

namespace Components.Inputs.Models
{
    public class NumberInputParameters<T> : InputParameters<T>
    {
        /// <summary>
        /// Enable or Disable Auto-Complete feature of input. Default is false
        /// </summary>
        public virtual bool AutoComplete { get; set; }

        /// <summary>
        /// Sets the 'placeholder' attribute of the input element
        /// </summary>
        public virtual string PlaceHolder { get; set; } = default!;

        /// <summary>
        /// Sets the 'readonly' attribute of the input element. Default is false
        /// </summary>
        public virtual bool ReadOnly { get; set; }

        /// <summary>
        /// Type of input. Default value is InputType.Text
        /// </summary>
        public override InputTypes InputType { get; set; } = InputTypes.Number;

        protected string ReadOnlyValue { get => ReadOnly ? "readonly" : ""; }
        protected string AutoCompleteValue { get => AutoComplete ? "on" : "off"; }

        public NumberInputParameters(object For, Type ModelType) : base(For, ModelType)
        {
            if (ModelType != null && For != null)
                LabelValue = LabelValueProvider.GetLabelValue($"{For}", ModelType);
        }
    }
}
