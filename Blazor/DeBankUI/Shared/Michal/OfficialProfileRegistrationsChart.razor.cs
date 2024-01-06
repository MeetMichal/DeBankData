using CsvHelper;
using DeBankUI.Components;
using DeBankUI.Data;
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
    public partial class OfficialProfileRegistrationsChart : BaseChartComponent
    {
        private static readonly SKColor black = SKColors.Black;
        public List<DateTimePoint> MainSerieValues { get; set; }


        public OfficialProfileRegistrationsChart()
        {
            MainSerieValues = MichalData.GetOfficialProfilesAmountData();

            XAxes = new[]
            {
                new DateTimeAxis(TimeSpan.FromDays(1), date => date.ToString("yyyy-MM-dd"))
                {
                    LabelsRotation = 30,
                    TicksPaint = new SolidColorPaint(black),
                    NamePaint = new SolidColorPaint(black),
                    LabelsPaint = new SolidColorPaint(black),
                }
            };

            YAxes = new[]
            {
                new Axis
                {
                    Name = "Number of Official Profiles",
                    NamePaint = new SolidColorPaint(Colors.SerieBlue),
                    LabelsPaint = new SolidColorPaint(Colors.SerieBlue),
                    TicksPaint = new SolidColorPaint(Colors.SerieBlue),
                    SubticksPaint = new SolidColorPaint(Colors.SerieBlue),
                    MaxLimit = MainSerieValues.MaxBy(v => v.Value.Value).Value.Value * 1.05
                },
            };

            Series = new[]
            {
                new LineSeries<DateTimePoint>
                {
                    Name = "Official profiles",
                    DataPadding = new LiveChartsCore.Drawing.LvcPoint(0,0),
                    Stroke = new SolidColorPaint(Colors.SerieBlue,4),
                    GeometryStroke = null,
                    GeometrySize = 0,
                    Fill = null,
                    LineSmoothness = 1,
                    ScalesXAt = 0,
                    Values = MainSerieValues
                },
            };
        }

        public override byte[] DownloadChartData()
        {
            var totalSerie = Series[0].As<LineSeries<DateTimePoint>>();
            var totalSerieValues = totalSerie.Values.ToList();
            var records = new List<CsvData>();

            for (int i = 0; i < totalSerie.Values.Count(); i++)
            {
                records.Add(new CsvData
                {
                    Date = totalSerieValues[i].DateTime,
                    OfficialProfiles = totalSerieValues[i].Value,
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
            public DateTime Date { get; set; }
            public double? OfficialProfiles { get; set; }
        }
    }
}
