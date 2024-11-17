using OxyPlot.Series;

namespace CASINO.Pages
{
    internal class ColumnSeries
    {
        public ColumnSeries()
        {
        }

        public string Title { get; internal set; }
        public LabelPlacement LabelPlacement { get; internal set; }
        public string LabelFormatString { get; internal set; }
        public object Item { get; internal set; }
    }
}