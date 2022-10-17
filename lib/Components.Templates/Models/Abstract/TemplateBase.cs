using Microsoft.AspNetCore.Components;

namespace Components.Templates.Models.Abstract
{
    public abstract partial class TemplateBase : ComponentBase
    {
        /// <summary>
        /// Bool value indicating something is loading
        /// </summary>
        [Parameter] public bool IsLoading { get; set; }

        /// <summary>
        /// Bool value indicating that an error occured
        /// </summary>
        [Parameter] public bool IsFaulted { get; set; }

        /// <summary>
        /// Content to display when loading. Using a loader component as an example
        /// </summary>
        [Parameter] public virtual RenderFragment? LoadingContent { get; set; }

        /// <summary>
        /// Content that is displayed if there is an error
        /// </summary>
        [Parameter] public virtual RenderFragment? FaultedContent { get; set; }

        /// <summary>
        /// Error messages to display if any
        /// </summary>
        public IList<string> ErrorMessages { get; set; } = new List<string>();
    }

    public abstract partial class TemplateBase<T> : TemplateBase
    {
        [Parameter] public T Model { get; set; } = default!;
    }
}
