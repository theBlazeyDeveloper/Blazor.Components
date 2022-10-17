using Components.Charts.Models.Abstract;
using Radzen.Blazor;

namespace Components.Charts.Models
{
    public sealed class LineChartData : ChartBase<LineChartDataItem>
    {
        public LineChartData(int year, string title, LineType lineType, MarkerType markerType, IEnumerable<LineChartDataItem> data)
            : base(title, lineType, data)
        {
            Year = year;
            MarkerType = markerType;
        }

        public int Year { get; }

        public MarkerType MarkerType { get; } = MarkerType.Circle;
    }
}
