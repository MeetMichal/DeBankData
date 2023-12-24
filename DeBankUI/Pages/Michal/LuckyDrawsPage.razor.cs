using LiveChartsCore.Defaults;
using LiveChartsCore.SkiaSharpView;
using LiveChartsCore;
using LiveChartsCore.Kernel.Sketches;
using LiveChartsCore.SkiaSharpView.Painting;
using static MudBlazor.Colors;
using SkiaSharp;
using DeBankUI.Utils;
using DeBankUI.Components;
using Microsoft.AspNetCore.Components;
using DeBankUI.Shared.Michal;
using BlazorDownloadFile;

namespace DeBankUI.Pages.Michal
{
    public partial class LuckyDrawsPage
    {
        [Inject]
        public IBlazorDownloadFileService BlazorDownloadFileService { get; set; }

        private LuckyDrawsTotalChart luckyDrawsTotalChart;
        private LuckyDrawsDailyChart luckyDrawsDailyChart;
        private LuckyDrawsHistogram luckyDrawsHistogram;
        private LuckyDrawsWinnersHistogram luckyDrawsWinnersHistogram;

        public async Task DownloadChartData(BaseChartComponent baseComponent, string title)
        {
            var data = baseComponent.DownloadChartData();
            await BlazorDownloadFileService.DownloadFile(title, data, "application/octet-stream");
        }
    }
}
