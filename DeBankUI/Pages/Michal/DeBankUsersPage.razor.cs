﻿using LiveChartsCore.Defaults;
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
    public partial class DeBankUsersPage
    {
        [Inject]
        public IBlazorDownloadFileService BlazorDownloadFileService { get; set; }

        private Web3IdMintersChart web3RegistrationsChart;
        private L2RegistrationsChart l2RegistrationsChart;
        private OfficialProfileRegistrationsChart officialProfileRegistrationsChart;

        public async Task DownloadChartData(BaseChartComponent baseComponent, string title)
        {
            var data = baseComponent.DownloadChartData();
            await BlazorDownloadFileService.DownloadFileAsync(title, data);
        }
    }
}