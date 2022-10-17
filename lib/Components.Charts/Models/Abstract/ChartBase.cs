using Radzen.Blazor;

namespace Components.Charts.Models.Abstract
{
    public abstract class ChartBase
    {
        protected ChartBase(string title, LineType lineType)
        {
            Title = title;
            LineType = lineType;
        }
        /// <summary>
        /// Line Style. Default is LineType.Solid
        /// </summary>
        public LineType LineType { get; } = LineType.Solid;

        /// <summary>
        /// Title of the overall chart. Default value is "Default Chart Title"
        /// </summary>
        public string? Title { get; } = "Default Chart Title";
    }

    public abstract class ChartBase<T> : ChartBase where T : DataItemBase
    {
        readonly IList<T> _dataItems = new List<T>();

        protected ChartBase(string title, LineType lineType, IEnumerable<T> dataItems) : base(title, lineType)
        {
            _dataItems = dataItems.ToList();
        }        

        /// <summary>
        /// Data items that will be plotted
        /// </summary>
        public IEnumerable<T> DataItems { get => _dataItems; }
    }
}
