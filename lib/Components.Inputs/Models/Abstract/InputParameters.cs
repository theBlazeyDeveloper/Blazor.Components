using System.Linq.Expressions;

namespace Components.Inputs.Models.Abstract
{
    public abstract class InputParameters<T>
    {
        /// <summary>
        /// Set the Property being used in the input along with the property 'ModelType'
        /// in order to retrieve the value in the Models '[Display]' attribute
        /// </summary>
        public virtual object For { get; } = default!;

        /// <summary>
        /// Set the Type of Model being used along with the property 'For'
        /// in order to retrieve the value in the Models '[Display]' attribute
        /// </summary>
        public virtual Type ModelType { get; } = default!;

        /// <summary>
        /// Sets the 'title' attribute of the input element
        /// </summary>
        public virtual string Title { get; set; } = default!;

        /// <summary>
        /// Sets the Validation for the input element
        /// </summary>
        public virtual Expression<Func<T>> ValidationFor { get; set; } = default!;

        /// <summary>
        /// Sets the 'disabled' attribute of the input element. Default is false
        /// </summary>
        public virtual bool Disabled { get; set; }

        /// <summary>
        /// Prepends the label to the begining of the input element. Default is true
        /// </summary>
        public virtual bool PrependLabel { get; set; } = true;

        /// <summary>
        /// Css class for the input element. Default is 'form-control'
        /// </summary>
        public virtual string ClassCss { get; set; } = default!;

        /// <summary>
        /// Css class for the input element
        /// </summary>
        public virtual string IconCss { get; set; } = default!;

        /// <summary>
        /// Type of input.
        /// </summary>
        public virtual InputTypes InputType { get; set; } = default!;

        public string LabelValue { get; protected set; } = default!;

        protected string DisabledValue { get => Disabled ? "disabled" : ""; }

        public InputParameters(object For, Type ModelType)
        {
            this.For = For;
            this.ModelType = ModelType;
        }
    }
}
