using DeBankUI.Components;
using DeBankUI.Utils;
using LiveChartsCore;
using LiveChartsCore.Defaults;
using LiveChartsCore.SkiaSharpView;
using LiveChartsCore.SkiaSharpView.Painting;
using SkiaSharp;

namespace DeBankUI.Shared.Michal
{
    public partial class RewardPoolsEarnersHistogram : BaseChartComponent
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
                Name = "Number of Earners",
                Values = new double[] { 13639, 108150, 161958, 154018, 79738, 30521, 16534, 14622, 4105, 1564 },
                DataPadding = new LiveChartsCore.Drawing.LvcPoint(0,0),
            },
        };

        public Axis[] YAxes { get; set; } =
        {
            new Axis
            {
                Name = "Number of Earners",
                MinLimit = 0,
            }
        };

        public Axis[] XAxes { get; set; } =
        {
        new Axis
        {
            Name = "Earnings from Rewar Pool",
            Labels = new string[] { "$0.01", "$0.02", "$0.02-$0.05", "$0.05-$0.15", "$0.15-$0.5", "$0.5-$1", "$1-$2", "$2-$5", "$5-$10", ">$10" },
            LabelsRotation = 30,
            SeparatorsAtCenter = false,
            ForceStepToMin = true,
        }
    };
    }
}
