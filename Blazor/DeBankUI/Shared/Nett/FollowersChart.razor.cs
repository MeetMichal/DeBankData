using CsvHelper;
using DeBankUI.Components;
using DeBankUI.Data;
using DeBankUI.Model;
using DeBankUI.Utils;
using LiveChartsCore;
using LiveChartsCore.Defaults;
using LiveChartsCore.SkiaSharpView;
using LiveChartsCore.SkiaSharpView.Extensions;
using LiveChartsCore.SkiaSharpView.Painting;
using LiveChartsCore.SkiaSharpView.VisualElements;
using Microsoft.AspNetCore.Components;
using MudBlazor.Extensions;
using SkiaSharp;
using System.Globalization;

namespace DeBankUI.Shared.Nett
{
    public partial class FollowersChart : BaseChartComponent
    {
        public LabelVisual Title { get; set; }

        [Parameter]
        public List<UserRank> UserRanks { get; set; } = new List<UserRank>();


        protected override void OnParametersSet()
        {
            var byBalance = UserRanks.OrderByDescending(u => u.Followers).ToList();
            int index = 0;

            Series = byBalance.Take(10).Select(u => u.Followers).AsPieSeries((value, series) =>
            {
                series.Name = byBalance[index++].Web3Id;
                series.DataLabelsPosition = LiveChartsCore.Measure.PolarLabelsPosition.Outer; // mark
                series.DataLabelsSize = 15;
                series.DataLabelsFormatter = point => point.Coordinate.PrimaryValue.ToString();
                series.ToolTipLabelFormatter = point => point.Coordinate.PrimaryValue.ToString();
                series.IsVisibleAtLegend = true;
                series.MiniatureShapeSize = 1;
            }).ToArray();

            base.OnParametersSet();
        }

        public override byte[] DownloadChartData()
        {
            throw new NotImplementedException();
        }
    }
}
