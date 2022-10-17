using Components.Charts.Models.Abstract;

namespace Components.Charts.Models
{
    public sealed class LineChartDataItem : DataItemBase
    {        
        public string? Month { get; init; }
        public int Year { get; init; }
    }
}
