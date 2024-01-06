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
    public partial class CombinedDataChart : BaseChartComponent
    {
        private static readonly SKColor black = SKColors.Black;
        public List<DateTimePoint> L2SerieValues { get; set; }
        public List<DateTimePoint> Web3IdSerieValues { get; set; }
        public List<DateTimePoint> OfficialProfiesValues { get; set; }

        public void L2SerieVisibilityChanged(bool val)
        {
            Series[0].IsVisible = val;
        }

        public void Web3SerieVisibilityChanged(bool val)
        {
            Series[1].IsVisible = val;
        }

        public void OfficialProfiesSerieVisibilityChanged(bool val)
        {
            Series[2].IsVisible = val;
        }

        public CombinedDataChart()
        {
            L2SerieValues = MichalData.GetL2RegistrationsData();
            Web3IdSerieValues = MichalData.GetWeb3MintersAmountData();
            OfficialProfiesValues = MichalData.GetOfficialProfilesAmountData();

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
                    NamePaint = new SolidColorPaint(Colors.SerieBlue),
                    TicksPaint = new SolidColorPaint(black),
                    LabelsPaint = new SolidColorPaint(black),
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
                    Values = L2SerieValues,
                },
                new LineSeries<DateTimePoint>
                {
                    DataPadding = new LiveChartsCore.Drawing.LvcPoint(0,0),
                    Stroke = new SolidColorPaint(Colors.SerieRed,4),
                    GeometryStroke = null,
                    GeometrySize = 0,
                    Fill = null,
                    LineSmoothness = 1,
                    ScalesYAt = 0, // it will be scaled at the Axis[0] instance
                    ScalesXAt = 0,
                    Values = Web3IdSerieValues
                },
                new LineSeries<DateTimePoint>
                {
                    DataPadding = new LiveChartsCore.Drawing.LvcPoint(0,0),
                    Stroke = new SolidColorPaint(Colors.SerieGreen,4),
                    GeometryStroke = null,
                    GeometrySize = 0,
                    Fill = null,
                    LineSmoothness = 1,
                    ScalesYAt = 0, // it will be scaled at the Axis[0] instance
                    ScalesXAt = 0,
                    Values = OfficialProfiesValues
                },
            };
        }

        public override byte[] DownloadChartData()
        {
            var l2Serie = Series[0].As<LineSeries<DateTimePoint>>();

            var l2SerieValues = l2Serie.Values.ToList();
            var records = new List<CsvData>();

            for (int i = 0; i < l2SerieValues.Count(); i++)
            {
                var dateTime = l2SerieValues[i].DateTime;
                records.Add(new CsvData
                {
                    Date = dateTime,
                    L2Users = l2SerieValues[i].Value,
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
        }
    }
}
