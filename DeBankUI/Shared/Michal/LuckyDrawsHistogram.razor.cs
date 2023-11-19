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
    public partial class LuckyDrawsHistogram : BaseChartComponent
    {
        private static readonly SKColor black = SKColors.Black;

        public LuckyDrawsHistogram()
        {
            Series = new []
            {
                new ColumnSeries<int>
                {
                    Name = "Number of Lucky Draws",
                    Values = new int[] { 3662, 23255, 13132, 7614, 5665, 1586 },
                    DataPadding = new LiveChartsCore.Drawing.LvcPoint(0, 0),
                },
            };

            YAxes = new []
            {
                new Axis { MinLimit = 0 }
            };

            XAxes = new[]
            {
                new Axis
                {
                    Labels = new string[] { "<$1", "$1-$2", "$2-$5", "$5-$10", "$10-$25", ">$25" },
                    LabelsRotation = 0,
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
                    DrawNumbers = columnSerieValues[i],
                    Prize = columnSerieCategories[i],
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
            public string? Prize { get; set; }
            public int? DrawNumbers { get; set; }
        }
    }
}
