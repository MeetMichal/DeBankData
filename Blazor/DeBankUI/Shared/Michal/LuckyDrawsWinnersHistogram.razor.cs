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
    public partial class LuckyDrawsWinnersHistogram : BaseChartComponent
    {
        private static readonly SKColor black = SKColors.Black;

        public LuckyDrawsWinnersHistogram()
        {
            YAxes = new[]
            {
                new Axis
                {
                    Name = "Number of unique winners",
                    MinLimit = 0,
                }
            };

            XAxes = new[]
            {
                new Axis
                {
                    Name = "Number of wins",
                    Labels = new string[] { "1", "2", "3-5", "5-10", "10-25", "25-50", ">50" },
                    LabelsRotation = 0,
                    SeparatorsAtCenter = false,
                    ForceStepToMin = true,
                }
            };

            Series = new[]
            {
                new ColumnSeries<int>
                {
                    Name = "Number of Lucky Draws winners",
                    Values = new int[] { 15354, 3461, 3012, 2786, 2228, 586, 363},
                    DataPadding = new LiveChartsCore.Drawing.LvcPoint(0,0),
                },
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
                    NumberOfWinners = columnSerieValues[i],
                    NumberOfWins = columnSerieCategories[i],
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
            public string? NumberOfWins { get; set; }
            public int? NumberOfWinners { get; set; }
        }
    }
}
