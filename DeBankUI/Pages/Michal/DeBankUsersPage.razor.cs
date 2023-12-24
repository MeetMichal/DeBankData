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
    public partial class DeBankUsersPage
    {
        [Inject]
        public IBlazorDownloadFileService BlazorDownloadFileService { get; set; }

        private Web3IdMintersChart web3RegistrationsChart;
        private L2RegistrationsChart l2RegistrationsChart;
        private OfficialProfileRegistrationsChart officialProfileRegistrationsChart;

        public async Task DownloadChartData(BaseChartComponent baseComponent, string title)
        {
            byte[] data = baseComponent.DownloadChartData();
            await BlazorDownloadFileService.DownloadFile(title, data, "application/octet-stream");
        }
    }
}
