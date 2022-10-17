using Microsoft.AspNetCore.Components;

namespace Components.Charts.Models.Abstract
{
    public abstract class ChartComponentBase<T> : ComponentBase where T : ChartBase
    {
        /// <summary>
        /// Used for displaying multiple graphs
        /// </summary>
        [Parameter] public IEnumerable<T> Charts { get; set; } = Enumerable.Empty<T>();

        /// <summary>
        /// Title of the Overall Chart. Default value is "Default Chart Title"
        /// </summary>
        [Parameter] public string? Title { get; set; } = "Default Chart Title";

        /// <summary>
        /// Label for Y axis. Default is "Y Axis"
        /// </summary>
        [Parameter] public string? YAxisLabel { get; set; } = "Y Axis";

        /// <summary>
        /// Label for X axis. Default is "X Axis"
        /// </summary>
        [Parameter] public string? XAxisLabel { get; set; } = "X Axis";
    }
}
