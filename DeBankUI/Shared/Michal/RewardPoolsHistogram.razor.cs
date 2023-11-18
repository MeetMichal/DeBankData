using DeBankUI.Components;
using DeBankUI.Utils;
using LiveChartsCore;
using LiveChartsCore.Defaults;
using LiveChartsCore.SkiaSharpView;
using LiveChartsCore.SkiaSharpView.Painting;
using SkiaSharp;

namespace DeBankUI.Shared.Michal
{
    public partial class RewardPoolsHistogram : BaseChartComponent
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
                Name = "Number of Reward Pools",
                Values = new double[] { 23887, 34654, 21373, 15555, 8726, 6490, 1754 },
                DataPadding = new LiveChartsCore.Drawing.LvcPoint(0,0),
            },
        };

        public Axis[] YAxes { get; set; } =
        {
            new Axis
            {
                Name = "Number of Reward Pools",
                MinLimit = 0,
            }
        };

        public Axis[] XAxes { get; set; } =
        {
            new Axis
            {
                Name = "Prize in Reward Pool",
                Labels = new string[] { "<$0.1", "$0.1-$1", "$1-$2", "$2-$5", "$5-$10", "$10-$25", ">$25" },
                LabelsRotation = 0,
                SeparatorsAtCenter = false,
                ForceStepToMin = true,
            }
        };
    }
}