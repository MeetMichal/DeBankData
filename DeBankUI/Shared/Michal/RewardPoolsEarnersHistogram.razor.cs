using CsvHelper;
using DeBankUI.Components;
using DeBankUI.Utils;
using LiveChartsCore;
using LiveChartsCore.Defaults;
using LiveChartsCore.SkiaSharpView;
using LiveChartsCore.SkiaSharpView.Painting;
using MudBlazor.Extensions;
using SkiaSharp;
using System.Globalization;

namespace DeBankUI.Shared.Michal
{
    public partial class RewardPoolsEarnersHistogram : BaseChartComponent
    {
        private static readonly SKColor black = SKColors.Black;

        public RewardPoolsEarnersHistogram()
        {
            Series = new[]
            {
                new ColumnSeries<int>
                {
                    Name = "Number of Earners",
                    Values = new int[] { 13639, 108150, 161958, 154018, 79738, 30521, 16534, 14622, 4105, 1564 },
                    DataPadding = new LiveChartsCore.Drawing.LvcPoint(0,0),
                },
            };

            YAxes = new[]
            {
                new Axis
                {
                    Name = "Number of Earners",
                    MinLimit = 0,
                }
            };

            XAxes = new[]
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

        public override byte[] DownloadChartData()
        {
            var columnSerie = Series[0].As<ColumnSeries<int>>();
            var columnSerieValues = columnSerie.Values.ToList();
            var columnSerieCategories = XAxes[0].Labels.ToList();
            var records = new List<CsvData>();

            for (int i = 0; i < columnSerie.Values.Count(); i++)
            {
                records.Add(new CsvData
                {
                    NumberOfEarners = columnSerieValues[i],
                    Earnings = columnSerieCategories[i],
                });
            }

            using (var stream = new MemoryStream())
            using (var writer = new StreamWriter(stream))
            using (var csv = new CsvWriter(writer, CultureInfo.InvariantCulture))
            {
                csv.WriteRecords(records);
                writer.Flush();
                return stream.ToArray();
            }
        }

        private class CsvData
        {
            public string? Earnings { get; set; }
            public int? NumberOfEarners { get; set; }
        }
    }
}
