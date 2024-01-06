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
    public partial class StreamActivityHistogram : BaseChartComponent
    {
        private static readonly SKColor black = SKColors.Black;

        public StreamActivityHistogram()
        {
            Series = new[]
            {
                new ColumnSeries<int>
                {
                    Name = "Number of authors",
                    Values = new int[] { 100029, 26428, 15535, 7102 },
                    DataPadding = new LiveChartsCore.Drawing.LvcPoint(0,0),
                },
            };

            YAxes = new[]
            {
                new Axis
                {
                    Name = "Number of authors",
                    MinLimit = 0,
                }
            };

            XAxes = new[]
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
                    NumberOfAuthors = columnSerieValues[i],
                    NumberOfPostsByAuthor = columnSerieCategories[i],
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
            public string? NumberOfPostsByAuthor { get; set; }
            public int? NumberOfAuthors { get; set; }
        }
    }
}