using Components.Charts.Models.Abstract;
using Radzen.Blazor;

namespace Components.Charts.Models
{
    public sealed class BarChartData : ChartBase<BarDataItem>
    {
        public BarChartData(string title, LineType lineType, IEnumerable<BarDataItem> data, IList<string> colors = default!)
            : base(title, lineType, data)
        {
            Colors = colors;
        }

        public IList<string> Colors { get; } = new List<string>();
    }
}
