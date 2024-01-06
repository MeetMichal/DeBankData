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
    public partial class RewardPoolsDailyChart : BaseChartComponent
    {
        private static readonly SKColor black = SKColors.Black;
        public List<DateTimePoint> AmountSerieValues { get; set; }
        public List<DateTimePoint> PrizesSerieValues { get; set; }

        public RewardPoolsDailyChart()
        {
            AmountSerieValues = MichalData.GetDailyRewardPoolsAmountData();
            PrizesSerieValues = MichalData.GetDailyRewardPoolsPrizesData();

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
                    Name = "Daily number of Reward Pools",
                    NamePaint = new SolidColorPaint(Colors.SerieBlue),
                    LabelsPaint = new SolidColorPaint(Colors.SerieBlue),
                    TicksPaint = new SolidColorPaint(Colors.SerieBlue),
                    SubticksPaint = new SolidColorPaint(Colors.SerieBlue),
                    MaxLimit = AmountSerieValues.MaxBy(v => v.Value.Value).Value.Value * 1.05
                },
                new Axis
                {
                    Name = "Daily Reward Pools prizes [$]",
                    ShowSeparatorLines = false,
                    Position = LiveChartsCore.Measure.AxisPosition.End,
                    NamePaint = new SolidColorPaint(Colors.SerieRed),
                    LabelsPaint = new SolidColorPaint(Colors.SerieRed),
                    TicksPaint = new SolidColorPaint(Colors.SerieRed),
                    SubticksPaint = new SolidColorPaint(Colors.SerieRed),
                    MaxLimit = PrizesSerieValues.MaxBy(v => v.Value.Value).Value.Value * 1.05
                },
            };

            Series = new[]
            {
                new LineSeries<DateTimePoint>
                {
                    Name="Daily number of Reward Pools",
                    DataPadding = new LiveChartsCore.Drawing.LvcPoint(0,0),
                    Stroke = new SolidColorPaint(Colors.SerieBlue,4),
                    GeometryStroke = null,
                    GeometrySize = 0,
                    Fill = null,
                    LineSmoothness = 1,
                    ScalesYAt = 0, // it will be scaled at the Axis[0] instance
                    ScalesXAt = 0,
                    Values = AmountSerieValues
                },
                new LineSeries<DateTimePoint>
                {
                    Name = "Daily Reward Pools prizes [$]",
                    DataPadding = new LiveChartsCore.Drawing.LvcPoint(0,0),
                    Fill = null,
                    Stroke = new SolidColorPaint(Colors.SerieRed,4),
                    GeometryStroke = null,
                    GeometrySize = 0,
                    LineSmoothness = 1,
                    ScalesXAt = 0,
                    ScalesYAt = 1, // it will be scaled at the Axis[0] instance 
                    Values = PrizesSerieValues
                }
            };
        }

        public override byte[] DownloadChartData()
        {
            var dailySerie = Series[0].As<LineSeries<DateTimePoint>>();
            var prizeSerie = Series[1].As<LineSeries<DateTimePoint>>();

            var dailySerieValues = dailySerie.Values.ToList();
            var prizeSerieValues = prizeSerie.Values.ToList();
            var records = new List<CsvData>();

            for (int i = 0; i < dailySerieValues.Count(); i++)
            {
                records.Add(new CsvData
                {
                    Date = dailySerieValues[i].DateTime,
                    DailyRewardPools = dailySerieValues[i].Value,
                    DailyRewardPoolPrizes = prizeSerieValues[i].Value,
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
            public double? DailyRewardPoolPrizes { get; set; }
            public double? DailyRewardPools { get; set; }
        }
    }
}
