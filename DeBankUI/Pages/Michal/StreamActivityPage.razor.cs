using LiveChartsCore.Defaults;
using LiveChartsCore.SkiaSharpView;
using LiveChartsCore;
using LiveChartsCore.Kernel.Sketches;
using LiveChartsCore.SkiaSharpView.Painting;
using static MudBlazor.Colors;
using SkiaSharp;
using DeBankUI.Utils;
using DeBankUI.Components;
using Blazor.DownloadFileFast.Interfaces;
using Microsoft.AspNetCore.Components;
using DeBankUI.Shared.Michal;

namespace DeBankUI.Pages.Michal
{
    public partial class StreamActivityPage
    {
        [Inject]
        public IBlazorDownloadFileService BlazorDownloadFileService { get; set; }
        private StreamActivityTotalChart streamActivityTotalChart;
        private StreamActivityDailyChart streamActivityDailyChart;
        private StreamActivityHistogram streamActivityHistogram;

        public async Task DownloadChartData(BaseChartComponent baseComponent, string title)
        {
            var data = baseComponent.DownloadChartData();
            await BlazorDownloadFileService.DownloadFileAsync(title, data);
        }
    }
}
