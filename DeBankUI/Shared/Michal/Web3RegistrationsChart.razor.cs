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
    public partial class Web3RegistrationsChart : BaseChartComponent
    {
        private static readonly SKColor black = SKColors.Black;

        public Web3RegistrationsChart()
        {
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
                    Name = "L2 Registrations",
                    NamePaint = new SolidColorPaint(Colors.SerieBlue),
                    LabelsPaint = new SolidColorPaint(Colors.SerieBlue),
                    TicksPaint = new SolidColorPaint(Colors.SerieBlue),
                    SubticksPaint = new SolidColorPaint(Colors.SerieBlue),
                },
                new Axis
                {
                    Name = "Web3 ID minters",
                    ShowSeparatorLines = false,
                    Position = LiveChartsCore.Measure.AxisPosition.End,
                    NamePaint = new SolidColorPaint(Colors.SerieRed),
                    LabelsPaint = new SolidColorPaint(Colors.SerieRed),
                    TicksPaint = new SolidColorPaint(Colors.SerieRed),
                    SubticksPaint = new SolidColorPaint(Colors.SerieRed),
                },
            };

            Series = new[]
            {
                new LineSeries<DateTimePoint>
                {
                    DataPadding = new LiveChartsCore.Drawing.LvcPoint(0,0),
                    Stroke = new SolidColorPaint(Colors.SerieBlue,4),
                    GeometryStroke = null,
                    GeometrySize = 0,
                    Fill = null,
                    LineSmoothness = 1,
                    ScalesYAt = 0, // it will be scaled at the Axis[0] instance
                    ScalesXAt = 0,
                    Values = new List<DateTimePoint>
                    {
                        new DateTimePoint(new DateTime(2022,10,24), 539),
                        new DateTimePoint(new DateTime(2022,10,31), 20672),
                        new DateTimePoint(new DateTime(2022,11,07), 28876),
                        new DateTimePoint(new DateTime(2022,11,14), 31521),
                        new DateTimePoint(new DateTime(2022,11,21), 34705),
                        new DateTimePoint(new DateTime(2022,11,28), 39110),
                        new DateTimePoint(new DateTime(2022,12,05), 41159),
                        new DateTimePoint(new DateTime(2022,12,12), 42203),
                        new DateTimePoint(new DateTime(2022,12,19), 43229),
                        new DateTimePoint(new DateTime(2022,12,26), 44208),
                        new DateTimePoint(new DateTime(2023,01,02), 44936),
                        new DateTimePoint(new DateTime(2023,01,09), 45310),
                        new DateTimePoint(new DateTime(2023,01,16), 45657),
                        new DateTimePoint(new DateTime(2023,01,23), 45958),
                        new DateTimePoint(new DateTime(2023,01,30), 46276),
                        new DateTimePoint(new DateTime(2023,02,06), 46653),
                        new DateTimePoint(new DateTime(2023,02,13), 46939),
                        new DateTimePoint(new DateTime(2023,02,20), 47380),
                        new DateTimePoint(new DateTime(2023,02,27), 47784),
                        new DateTimePoint(new DateTime(2023,03,06), 48112),
                        new DateTimePoint(new DateTime(2023,03,13), 48380),
                        new DateTimePoint(new DateTime(2023,03,20), 48895),
                        new DateTimePoint(new DateTime(2023,03,27), 50845),
                        new DateTimePoint(new DateTime(2023,04,03), 51649),
                        new DateTimePoint(new DateTime(2023,04,10), 52317),
                        new DateTimePoint(new DateTime(2023,04,17), 52862),
                        new DateTimePoint(new DateTime(2023,04,24), 53177),
                        new DateTimePoint(new DateTime(2023,05,01), 53854),
                        new DateTimePoint(new DateTime(2023,05,08), 54070),
                        new DateTimePoint(new DateTime(2023,05,15), 54409),
                        new DateTimePoint(new DateTime(2023,05,22), 54824),
                        new DateTimePoint(new DateTime(2023,05,29), 56322),
                        new DateTimePoint(new DateTime(2023,06,02), 58116),
                        new DateTimePoint(new DateTime(2023,06,09), 69334),
                        new DateTimePoint(new DateTime(2023,06,16), 75824),
                        new DateTimePoint(new DateTime(2023,06,23), 87330),
                        new DateTimePoint(new DateTime(2023,06,30), 104738),
                        new DateTimePoint(new DateTime(2023,07,01), 106024),
                        new DateTimePoint(new DateTime(2023,07,02), 107307),
                        new DateTimePoint(new DateTime(2023,07,09), 114977),
                        new DateTimePoint(new DateTime(2023,07,16), 126114),
                        new DateTimePoint(new DateTime(2023,07,23), 141826),
                        new DateTimePoint(new DateTime(2023,07,27), 165175),
                        new DateTimePoint(new DateTime(2023,08,03), 187732),
                        new DateTimePoint(new DateTime(2023,08,06), 196115),
                        new DateTimePoint(new DateTime(2023,08,13), 218884),
                        new DateTimePoint(new DateTime(2023,08,20), 234723),
                        new DateTimePoint(new DateTime(2023,08,27), 245133),
                        new DateTimePoint(new DateTime(2023,09,02), 250159),
                        new DateTimePoint(new DateTime(2023,09,10), 255539),
                        new DateTimePoint(new DateTime(2023,09,17), 259327),
                        new DateTimePoint(new DateTime(2023,09,24), 265032),
                        new DateTimePoint(new DateTime(2023,10,01), 267819),
                        new DateTimePoint(new DateTime(2023,10,08), 271499),
                        new DateTimePoint(new DateTime(2023,10,15), 274182),
                        new DateTimePoint(new DateTime(2023,10,22), 279303),
                        new DateTimePoint(new DateTime(2023,10,29), 281531),
                        new DateTimePoint(new DateTime(2023,11,05), 284974),
                        new DateTimePoint(new DateTime(2023,11,12), 288020),
                    }
                },
                new LineSeries<DateTimePoint>
                {
                    DataPadding = new LiveChartsCore.Drawing.LvcPoint(0,0),
                    Fill = null,
                    Stroke = new SolidColorPaint(Colors.SerieRed,4),
                    GeometryStroke = null,
                    GeometrySize = 0,
                    LineSmoothness = 1,
                    ScalesXAt = 0,
                    ScalesYAt = 1, // it will be scaled at the Axis[0] instance 
                    Values = new List<DateTimePoint>
                    {
                        new DateTimePoint(new DateTime(2023,06,02), 23000),
                        new DateTimePoint(new DateTime(2023,07,02), 25000),
                        new DateTimePoint(new DateTime(2023,07,27), 29500),
                        new DateTimePoint(new DateTime(2023,08,06), 32500),
                        new DateTimePoint(new DateTime(2023,08,13), 35000),
                        new DateTimePoint(new DateTime(2023,08,20), 37700),
                        new DateTimePoint(new DateTime(2023,08,27), 39000),
                        new DateTimePoint(new DateTime(2023,09,02), 39750),
                        new DateTimePoint(new DateTime(2023,09,10), 40600),
                        new DateTimePoint(new DateTime(2023,09,17), 41045),
                        new DateTimePoint(new DateTime(2023,09,24), 41501),
                        new DateTimePoint(new DateTime(2023,10,01), 41817),
                        new DateTimePoint(new DateTime(2023,10,08), 42110),
                        new DateTimePoint(new DateTime(2023,10,15), 42376),
                        new DateTimePoint(new DateTime(2023,10,29), 43244),
                        new DateTimePoint(new DateTime(2023,11,05), 43774),
                        new DateTimePoint(new DateTime(2023,11,12), 44272),
                    }
                }
            };
        }

        public override byte[] DownloadChartData()
        {
            var l2Serie = Series[0].As<LineSeries<DateTimePoint>>();
            var Web3IdSerie = Series[1].As<LineSeries<DateTimePoint>>();

            var l2SerieValues = l2Serie.Values.ToList();
            var Web3IdSerieValues = Web3IdSerie.Values.ToList();
            var records = new List<CsvData>();

            for (int i = 0; i < l2SerieValues.Count(); i++)
            {
                var dateTime = l2SerieValues[i].DateTime;
                records.Add(new CsvData
                {
                    Date = dateTime,
                    L2Users = l2SerieValues[i].Value,
                    Web3Minters = Web3IdSerieValues.FirstOrDefault(dt => dt.DateTime == dateTime)?.Value,
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
            public double? L2Users { get; set; }
            public double? Web3Minters { get; set; }
        }
    }
}
