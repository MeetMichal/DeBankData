using DeBankUI.Components;
using DeBankUI.Utils;
using LiveChartsCore;
using LiveChartsCore.Defaults;
using LiveChartsCore.SkiaSharpView;
using LiveChartsCore.SkiaSharpView.Painting;
using SkiaSharp;

namespace DeBankUI.Shared.Michal
{
    public partial class LuckyDrawsWinnersHistogram : BaseChartComponent
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
                Name = "Number of Lucky Draws winners",
                Values = new double[] { 15354, 3461, 3012, 2786, 2228, 586, 363},
                DataPadding = new LiveChartsCore.Drawing.LvcPoint(0,0),
            },
        };

        public Axis[] YAxes { get; set; } =
        {
            new Axis
            {
                Name = "Number of unique winners",
                MinLimit = 0,
            }
        };

        public Axis[] XAxes { get; set; } =
        {
            new Axis
            {
                Name = "Number of wins",
                Labels = new string[] { "1", "2", "3-5", "5-10", "10-25", "25-50", ">50" },
                LabelsRotation = 0,
                SeparatorsAtCenter = false,
                ForceStepToMin = true,
            }
        };
    }
}
