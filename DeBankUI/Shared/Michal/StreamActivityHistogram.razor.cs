using DeBankUI.Components;
using DeBankUI.Utils;
using LiveChartsCore;
using LiveChartsCore.Defaults;
using LiveChartsCore.SkiaSharpView;
using LiveChartsCore.SkiaSharpView.Painting;
using SkiaSharp;

namespace DeBankUI.Shared.Michal
{
    public partial class StreamActivityHistogram : BaseChartComponent
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
                Name = "Number of authors",
                Values = new double[] { 100029, 26428, 15535, 7102 },
                DataPadding = new LiveChartsCore.Drawing.LvcPoint(0,0),
            },
        };

        public Axis[] YAxes { get; set; } =
        {
            new Axis 
            {
                Name = "Number of authors",
                MinLimit = 0,
            }
        };

        public Axis[] XAxes { get; set; } =
        {
            new Axis
            {
                Name = "Total number of posts by the author",
                Labels = new string[] { "1", "2-5", "5-25", ">25" },
                LabelsRotation = 0,
                SeparatorsAtCenter = false,
                ForceStepToMin = true,
            }
        };
    }
}