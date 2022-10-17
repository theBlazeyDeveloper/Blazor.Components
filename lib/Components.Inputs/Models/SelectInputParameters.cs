using Components.Inputs.Models.Abstract;
using Components.Inputs.Models.Providers;

namespace Components.Inputs.Models
{
    public class SelectInputParameters<T> : InputParameters<T>
    {
        /// <summary>
        /// Will add colors to correspond to value property of the select list item. 
        /// The value in the value property must be a color value, such as, hexadecimal or color word
        /// </summary>
        public virtual bool ColoredItems { get; set; }

        /// <summary>
        /// List of Items to be added to Select List
        /// </summary>
        public virtual IEnumerable<SelectListItem> Items { get; set; } = Enumerable.Empty<SelectListItem>();

        public SelectInputParameters(object For, Type ModelType) : base(For, ModelType)
        {
            if (ModelType != null && For != null)
                LabelValue = LabelValueProvider.GetLabelValue($"{For}", ModelType);
        }
    }
}
