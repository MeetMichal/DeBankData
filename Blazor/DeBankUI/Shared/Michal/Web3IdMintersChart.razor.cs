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
    public partial class Web3IdMintersChart : BaseChartComponent
    {
        private static readonly SKColor black = SKColors.Black;
        public List<DateTimePoint> MainSerieValues { get; set; }

        public Web3IdMintersChart()
        {
            MainSerieValues = MichalData.GetWeb3MintersAmountData();

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
                    Name = "Web3 ID minters",
                    Position = LiveChartsCore.Measure.AxisPosition.Start,
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
                    DataPadding = new LiveChartsCore.Drawing.LvcPoint(0,0),
                    Fill = null,
                    Stroke = new SolidColorPaint(Colors.SerieBlue,4),
                    GeometryStroke = null,
                    GeometrySize = 0,
                    LineSmoothness = 1,
                    ScalesXAt = 0,
                    ScalesYAt = 0, // it will be scaled at the Axis[0] instance 
                    Values = MainSerieValues
                }
            };
        }

        public override byte[] DownloadChartData()
        {
            var Web3IdSerie = Series[0].As<LineSeries<DateTimePoint>>();

            var Web3IdSerieValues = Web3IdSerie.Values.ToList();
            var records = new List<CsvData>();

            for (int i = 0; i < Web3IdSerieValues.Count(); i++)
            {
                var dateTime = Web3IdSerieValues[i].DateTime;
                records.Add(new CsvData
                {
                    Date = dateTime,
                    Web3Minters = Web3IdSerieValues[i].Value,
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
            public double? Web3Minters { get; set; }
        }
    }
}
