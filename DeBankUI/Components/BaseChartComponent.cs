using LiveChartsCore.SkiaSharpView;
using LiveChartsCore;
using Microsoft.AspNetCore.Components;
using LiveChartsCore.SkiaSharpView.Painting;
using DeBankUI.Utils;

namespace DeBankUI.Components
{
    public abstract class BaseChartComponent : ComponentBase
    {
        public ISeries[] Series { get; set; } 
        public Axis[] YAxes { get; set; } 
        public Axis[] XAxes { get; set; }

        public DrawMarginFrame DrawMarginFrame => new()
        {
            Fill = new SolidColorPaint(Colors.ChartBackground),
            Stroke = new SolidColorPaint(Colors.ChartBorder, 2)
        };

        public abstract byte[] DownloadChartData();
    }
}
