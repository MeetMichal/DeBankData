using DeBankUI.Components;
using DeBankUI.Utils;
using LiveChartsCore;
using LiveChartsCore.Defaults;
using LiveChartsCore.SkiaSharpView;
using LiveChartsCore.SkiaSharpView.Painting;
using SkiaSharp;

namespace DeBankUI.Shared.Michal
{
    public partial class LuckyDrawsHistogram : BaseChartComponent
    {
        private static readonly SKColor black = SKColors.Black;
        private DrawMarginFrame DrawMarginFrame => new()
        {
            Fill = new SolidColorPaint(Colors.ChartBackground),
            Stroke = new SolidColorPaint(Colors.ChartBorder, 2)
        };

        public ISeries[] Series { get; set; } =
        {
            new ColumnSeries<double>
            {
                Name = "Number of Lucky Draws",
                Values = new double[] { 3662, 23255, 13132, 7614, 5665, 1586 },
                DataPadding = new LiveChartsCore.Drawing.LvcPoint(0,0),
            },
        };

        public Axis[] YAxes { get; set; } =
        {
            new Axis { MinLimit = 0 }
        };

        public Axis[] XAxes { get; set; } =
        {
            new Axis
            {
                Labels = new string[] { "<$1", "$1-$2", "$2-$5", "$5-$10", "$10-$25", ">$25" },
                LabelsRotation = 0,
                SeparatorsAtCenter = false,
                ForceStepToMin = true,
            }
        };
    }
}
