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
    public partial class RewardPoolsTotalChart : BaseChartComponent
    {
        private static readonly SKColor black = SKColors.Black;

        public RewardPoolsTotalChart()
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
                    Name = "Total number of Reward Pools",
                    NamePaint = new SolidColorPaint(Colors.SerieBlue),
                    LabelsPaint = new SolidColorPaint(Colors.SerieBlue),
                    TicksPaint = new SolidColorPaint(Colors.SerieBlue),
                    SubticksPaint = new SolidColorPaint(Colors.SerieBlue),
                },
                new Axis
                {
                    Name = "Total Reward Pools prizes [$]",
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
                    Name = "Total number of Reward Pools",
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
                        new DateTimePoint(new DateTime(2023,6,9),1),
                        new DateTimePoint(new DateTime(2023,6,11),14),
                        new DateTimePoint(new DateTime(2023,6,12),139),
                        new DateTimePoint(new DateTime(2023,6,13),230),
                        new DateTimePoint(new DateTime(2023,6,14),442),
                        new DateTimePoint(new DateTime(2023,6,15),672),
                        new DateTimePoint(new DateTime(2023,6,16),929),
                        new DateTimePoint(new DateTime(2023,6,17),1077),
                        new DateTimePoint(new DateTime(2023,6,18),1171),
                        new DateTimePoint(new DateTime(2023,6,19),1283),
                        new DateTimePoint(new DateTime(2023,6,20),1457),
                        new DateTimePoint(new DateTime(2023,6,21),1626),
                        new DateTimePoint(new DateTime(2023,6,22),1896),
                        new DateTimePoint(new DateTime(2023,6,23),2064),
                        new DateTimePoint(new DateTime(2023,6,24),2154),
                        new DateTimePoint(new DateTime(2023,6,25),2245),
                        new DateTimePoint(new DateTime(2023,6,26),2387),
                        new DateTimePoint(new DateTime(2023,6,27),2809),
                        new DateTimePoint(new DateTime(2023,6,28),2925),
                        new DateTimePoint(new DateTime(2023,6,29),3059),
                        new DateTimePoint(new DateTime(2023,6,30),3222),
                        new DateTimePoint(new DateTime(2023,7,1),3494),
                        new DateTimePoint(new DateTime(2023,7,2),3675),
                        new DateTimePoint(new DateTime(2023,7,3),3880),
                        new DateTimePoint(new DateTime(2023,7,4),4271),
                        new DateTimePoint(new DateTime(2023,7,5),4682),
                        new DateTimePoint(new DateTime(2023,7,6),5048),
                        new DateTimePoint(new DateTime(2023,7,7),5219),
                        new DateTimePoint(new DateTime(2023,7,8),5353),
                        new DateTimePoint(new DateTime(2023,7,9),5492),
                        new DateTimePoint(new DateTime(2023,7,10),5683),
                        new DateTimePoint(new DateTime(2023,7,11),5905),
                        new DateTimePoint(new DateTime(2023,7,12),6110),
                        new DateTimePoint(new DateTime(2023,7,13),6374),
                        new DateTimePoint(new DateTime(2023,7,14),6823),
                        new DateTimePoint(new DateTime(2023,7,15),7116),
                        new DateTimePoint(new DateTime(2023,7,16),7393),
                        new DateTimePoint(new DateTime(2023,7,17),7708),
                        new DateTimePoint(new DateTime(2023,7,18),8005),
                        new DateTimePoint(new DateTime(2023,7,19),8451),
                        new DateTimePoint(new DateTime(2023,7,20),9065),
                        new DateTimePoint(new DateTime(2023,7,21),9703),
                        new DateTimePoint(new DateTime(2023,7,22),10404),
                        new DateTimePoint(new DateTime(2023,7,23),11214),
                        new DateTimePoint(new DateTime(2023,7,24),12519),
                        new DateTimePoint(new DateTime(2023,7,25),13713),
                        new DateTimePoint(new DateTime(2023,7,26),15096),
                        new DateTimePoint(new DateTime(2023,7,27),16518),
                        new DateTimePoint(new DateTime(2023,7,28),17852),
                        new DateTimePoint(new DateTime(2023,7,29),18828),
                        new DateTimePoint(new DateTime(2023,7,30),19788),
                        new DateTimePoint(new DateTime(2023,7,31),20874),
                        new DateTimePoint(new DateTime(2023,8,1),22018),
                        new DateTimePoint(new DateTime(2023,8,2),23177),
                        new DateTimePoint(new DateTime(2023,8,3),24252),
                        new DateTimePoint(new DateTime(2023,8,4),25472),
                        new DateTimePoint(new DateTime(2023,8,5),26429),
                        new DateTimePoint(new DateTime(2023,8,6),27329),
                        new DateTimePoint(new DateTime(2023,8,7),28561),
                        new DateTimePoint(new DateTime(2023,8,8),29862),
                        new DateTimePoint(new DateTime(2023,8,9),31132),
                        new DateTimePoint(new DateTime(2023,8,10),32208),
                        new DateTimePoint(new DateTime(2023,8,11),33399),
                        new DateTimePoint(new DateTime(2023,8,12),34312),
                        new DateTimePoint(new DateTime(2023,8,13),35081),
                        new DateTimePoint(new DateTime(2023,8,14),36077),
                        new DateTimePoint(new DateTime(2023,8,15),36995),
                        new DateTimePoint(new DateTime(2023,8,16),37807),
                        new DateTimePoint(new DateTime(2023,8,17),38609),
                        new DateTimePoint(new DateTime(2023,8,18),39318),
                        new DateTimePoint(new DateTime(2023,8,19),40063),
                        new DateTimePoint(new DateTime(2023,8,20),40818),
                        new DateTimePoint(new DateTime(2023,8,21),41597),
                        new DateTimePoint(new DateTime(2023,8,22),42353),
                        new DateTimePoint(new DateTime(2023,8,23),43012),
                        new DateTimePoint(new DateTime(2023,8,24),43713),
                        new DateTimePoint(new DateTime(2023,8,25),44338),
                        new DateTimePoint(new DateTime(2023,8,26),44931),
                        new DateTimePoint(new DateTime(2023,8,27),45478),
                        new DateTimePoint(new DateTime(2023,8,28),46111),
                        new DateTimePoint(new DateTime(2023,8,29),46758),
                        new DateTimePoint(new DateTime(2023,8,30),47335),
                        new DateTimePoint(new DateTime(2023,8,31),47904),
                        new DateTimePoint(new DateTime(2023,9,1),48441),
                        new DateTimePoint(new DateTime(2023,9,2),48946),
                        new DateTimePoint(new DateTime(2023,9,3),49451),
                        new DateTimePoint(new DateTime(2023,9,4),50007),
                        new DateTimePoint(new DateTime(2023,9,5),50585),
                        new DateTimePoint(new DateTime(2023,9,6),51114),
                        new DateTimePoint(new DateTime(2023,9,7),51727),
                        new DateTimePoint(new DateTime(2023,9,8),52223),
                        new DateTimePoint(new DateTime(2023,9,9),52624),
                        new DateTimePoint(new DateTime(2023,9,10),53050),
                        new DateTimePoint(new DateTime(2023,9,11),53546),
                        new DateTimePoint(new DateTime(2023,9,12),54002),
                        new DateTimePoint(new DateTime(2023,9,13),54499),
                        new DateTimePoint(new DateTime(2023,9,14),55072),
                        new DateTimePoint(new DateTime(2023,9,15),56005),
                        new DateTimePoint(new DateTime(2023,9,16),56653),
                        new DateTimePoint(new DateTime(2023,9,17),57242),
                        new DateTimePoint(new DateTime(2023,9,18),58051),
                        new DateTimePoint(new DateTime(2023,9,19),58828),
                        new DateTimePoint(new DateTime(2023,9,20),59539),
                        new DateTimePoint(new DateTime(2023,9,21),60135),
                        new DateTimePoint(new DateTime(2023,9,22),60832),
                        new DateTimePoint(new DateTime(2023,9,23),61458),
                        new DateTimePoint(new DateTime(2023,9,24),61984),
                        new DateTimePoint(new DateTime(2023,9,25),62608),
                        new DateTimePoint(new DateTime(2023,9,26),63277),
                        new DateTimePoint(new DateTime(2023,9,27),64094),
                        new DateTimePoint(new DateTime(2023,9,28),64809),
                        new DateTimePoint(new DateTime(2023,9,29),65610),
                        new DateTimePoint(new DateTime(2023,9,30),66320),
                        new DateTimePoint(new DateTime(2023,10,1),67081),
                        new DateTimePoint(new DateTime(2023,10,2),67931),
                        new DateTimePoint(new DateTime(2023,10,3),68727),
                        new DateTimePoint(new DateTime(2023,10,4),69569),
                        new DateTimePoint(new DateTime(2023,10,5),70347),
                        new DateTimePoint(new DateTime(2023,10,6),71167),
                        new DateTimePoint(new DateTime(2023,10,7),71915),
                        new DateTimePoint(new DateTime(2023,10,8),72546),
                        new DateTimePoint(new DateTime(2023,10,9),73330),
                        new DateTimePoint(new DateTime(2023,10,10),74223),
                        new DateTimePoint(new DateTime(2023,10,11),75207),
                        new DateTimePoint(new DateTime(2023,10,12),76284),
                        new DateTimePoint(new DateTime(2023,10,13),77348),
                        new DateTimePoint(new DateTime(2023,10,14),78356),
                        new DateTimePoint(new DateTime(2023,10,15),79852),
                        new DateTimePoint(new DateTime(2023,10,16),81087),
                        new DateTimePoint(new DateTime(2023,10,17),82108),
                        new DateTimePoint(new DateTime(2023,10,18),83180),
                        new DateTimePoint(new DateTime(2023,10,19),84145),
                        new DateTimePoint(new DateTime(2023,10,20),85285),
                        new DateTimePoint(new DateTime(2023,10,21),86398),
                        new DateTimePoint(new DateTime(2023,10,22),87489),
                        new DateTimePoint(new DateTime(2023,10,23),88763),
                        new DateTimePoint(new DateTime(2023,10,24),90002),
                        new DateTimePoint(new DateTime(2023,10,25),91309),
                        new DateTimePoint(new DateTime(2023,10,26),92377),
                        new DateTimePoint(new DateTime(2023,10,27),93477),
                        new DateTimePoint(new DateTime(2023,10,28),94584),
                        new DateTimePoint(new DateTime(2023,10,29),95584),
                        new DateTimePoint(new DateTime(2023,10,30),96809),
                        new DateTimePoint(new DateTime(2023,10,31),97990),
                        new DateTimePoint(new DateTime(2023,11,1),99063),
                        new DateTimePoint(new DateTime(2023,11,2),100199),
                        new DateTimePoint(new DateTime(2023,11,3),101508),
                        new DateTimePoint(new DateTime(2023,11,4),102808),
                        new DateTimePoint(new DateTime(2023,11,5),104026),
                        new DateTimePoint(new DateTime(2023,11,6),105451),
                        new DateTimePoint(new DateTime(2023,11,7),106767),
                        new DateTimePoint(new DateTime(2023,11,8),108124),
                        new DateTimePoint(new DateTime(2023,11,9),109571),
                        new DateTimePoint(new DateTime(2023,11,10),111004),
                        new DateTimePoint(new DateTime(2023,11,11),112186),
                    }
                },
                new LineSeries<DateTimePoint>
                {
                    Name = "Total Reward Pools prizes [$]",
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
                        new DateTimePoint(new DateTime(2023,6,9),0),
                        new DateTimePoint(new DateTime(2023,6,11),2),
                        new DateTimePoint(new DateTime(2023,6,12),151),
                        new DateTimePoint(new DateTime(2023,6,13),692),
                        new DateTimePoint(new DateTime(2023,6,14),1454),
                        new DateTimePoint(new DateTime(2023,6,15),1643),
                        new DateTimePoint(new DateTime(2023,6,16),2102),
                        new DateTimePoint(new DateTime(2023,6,17),2374),
                        new DateTimePoint(new DateTime(2023,6,18),2571),
                        new DateTimePoint(new DateTime(2023,6,19),2917),
                        new DateTimePoint(new DateTime(2023,6,20),3464),
                        new DateTimePoint(new DateTime(2023,6,21),3849),
                        new DateTimePoint(new DateTime(2023,6,22),4293),
                        new DateTimePoint(new DateTime(2023,6,23),4451),
                        new DateTimePoint(new DateTime(2023,6,24),4565),
                        new DateTimePoint(new DateTime(2023,6,25),4640),
                        new DateTimePoint(new DateTime(2023,6,26),4956),
                        new DateTimePoint(new DateTime(2023,6,27),5163),
                        new DateTimePoint(new DateTime(2023,6,28),5233),
                        new DateTimePoint(new DateTime(2023,6,29),5311),
                        new DateTimePoint(new DateTime(2023,6,30),5872),
                        new DateTimePoint(new DateTime(2023,7,1),6546),
                        new DateTimePoint(new DateTime(2023,7,2),6877),
                        new DateTimePoint(new DateTime(2023,7,3),7367),
                        new DateTimePoint(new DateTime(2023,7,4),7567),
                        new DateTimePoint(new DateTime(2023,7,5),7946),
                        new DateTimePoint(new DateTime(2023,7,6),8327),
                        new DateTimePoint(new DateTime(2023,7,7),9656),
                        new DateTimePoint(new DateTime(2023,7,8),10058),
                        new DateTimePoint(new DateTime(2023,7,9),10376),
                        new DateTimePoint(new DateTime(2023,7,10),10909),
                        new DateTimePoint(new DateTime(2023,7,11),11290),
                        new DateTimePoint(new DateTime(2023,7,12),11775),
                        new DateTimePoint(new DateTime(2023,7,13),12736),
                        new DateTimePoint(new DateTime(2023,7,14),14949),
                        new DateTimePoint(new DateTime(2023,7,15),16415),
                        new DateTimePoint(new DateTime(2023,7,16),18388),
                        new DateTimePoint(new DateTime(2023,7,17),20695),
                        new DateTimePoint(new DateTime(2023,7,18),22149),
                        new DateTimePoint(new DateTime(2023,7,19),24771),
                        new DateTimePoint(new DateTime(2023,7,20),26796),
                        new DateTimePoint(new DateTime(2023,7,21),29320),
                        new DateTimePoint(new DateTime(2023,7,22),31102),
                        new DateTimePoint(new DateTime(2023,7,23),34082),
                        new DateTimePoint(new DateTime(2023,7,24),38342),
                        new DateTimePoint(new DateTime(2023,7,25),42061),
                        new DateTimePoint(new DateTime(2023,7,26),46656),
                        new DateTimePoint(new DateTime(2023,7,27),54151),
                        new DateTimePoint(new DateTime(2023,7,28),67137),
                        new DateTimePoint(new DateTime(2023,7,29),69997),
                        new DateTimePoint(new DateTime(2023,7,30),73245),
                        new DateTimePoint(new DateTime(2023,7,31),75226),
                        new DateTimePoint(new DateTime(2023,8,1),77713),
                        new DateTimePoint(new DateTime(2023,8,2),82596),
                        new DateTimePoint(new DateTime(2023,8,3),85304),
                        new DateTimePoint(new DateTime(2023,8,4),87903),
                        new DateTimePoint(new DateTime(2023,8,5),89557),
                        new DateTimePoint(new DateTime(2023,8,6),91310),
                        new DateTimePoint(new DateTime(2023,8,7),94453),
                        new DateTimePoint(new DateTime(2023,8,8),97402),
                        new DateTimePoint(new DateTime(2023,8,9),100426),
                        new DateTimePoint(new DateTime(2023,8,10),102429),
                        new DateTimePoint(new DateTime(2023,8,11),105089),
                        new DateTimePoint(new DateTime(2023,8,12),107186),
                        new DateTimePoint(new DateTime(2023,8,13),109425),
                        new DateTimePoint(new DateTime(2023,8,14),113474),
                        new DateTimePoint(new DateTime(2023,8,15),115364),
                        new DateTimePoint(new DateTime(2023,8,16),117982),
                        new DateTimePoint(new DateTime(2023,8,17),120494),
                        new DateTimePoint(new DateTime(2023,8,18),123123),
                        new DateTimePoint(new DateTime(2023,8,19),124985),
                        new DateTimePoint(new DateTime(2023,8,20),127627),
                        new DateTimePoint(new DateTime(2023,8,21),129478),
                        new DateTimePoint(new DateTime(2023,8,22),132021),
                        new DateTimePoint(new DateTime(2023,8,23),134227),
                        new DateTimePoint(new DateTime(2023,8,24),135995),
                        new DateTimePoint(new DateTime(2023,8,25),138089),
                        new DateTimePoint(new DateTime(2023,8,26),139470),
                        new DateTimePoint(new DateTime(2023,8,27),140793),
                        new DateTimePoint(new DateTime(2023,8,28),142712),
                        new DateTimePoint(new DateTime(2023,8,29),144542),
                        new DateTimePoint(new DateTime(2023,8,30),146385),
                        new DateTimePoint(new DateTime(2023,8,31),148032),
                        new DateTimePoint(new DateTime(2023,9,1),150674),
                        new DateTimePoint(new DateTime(2023,9,2),152282),
                        new DateTimePoint(new DateTime(2023,9,3),153548),
                        new DateTimePoint(new DateTime(2023,9,4),155003),
                        new DateTimePoint(new DateTime(2023,9,5),156425),
                        new DateTimePoint(new DateTime(2023,9,6),158011),
                        new DateTimePoint(new DateTime(2023,9,7),160162),
                        new DateTimePoint(new DateTime(2023,9,8),161819),
                        new DateTimePoint(new DateTime(2023,9,9),162769),
                        new DateTimePoint(new DateTime(2023,9,10),163834),
                        new DateTimePoint(new DateTime(2023,9,11),165058),
                        new DateTimePoint(new DateTime(2023,9,12),166471),
                        new DateTimePoint(new DateTime(2023,9,13),167716),
                        new DateTimePoint(new DateTime(2023,9,14),170490),
                        new DateTimePoint(new DateTime(2023,9,15),177075),
                        new DateTimePoint(new DateTime(2023,9,16),180380),
                        new DateTimePoint(new DateTime(2023,9,17),182806),
                        new DateTimePoint(new DateTime(2023,9,18),185267),
                        new DateTimePoint(new DateTime(2023,9,19),187353),
                        new DateTimePoint(new DateTime(2023,9,20),189592),
                        new DateTimePoint(new DateTime(2023,9,21),191364),
                        new DateTimePoint(new DateTime(2023,9,22),193221),
                        new DateTimePoint(new DateTime(2023,9,23),197258),
                        new DateTimePoint(new DateTime(2023,9,24),200173),
                        new DateTimePoint(new DateTime(2023,9,25),201932),
                        new DateTimePoint(new DateTime(2023,9,26),203685),
                        new DateTimePoint(new DateTime(2023,9,27),206638),
                        new DateTimePoint(new DateTime(2023,9,28),209032),
                        new DateTimePoint(new DateTime(2023,9,29),212314),
                        new DateTimePoint(new DateTime(2023,9,30),214708),
                        new DateTimePoint(new DateTime(2023,10,1),217567),
                        new DateTimePoint(new DateTime(2023,10,2),220909),
                        new DateTimePoint(new DateTime(2023,10,3),223921),
                        new DateTimePoint(new DateTime(2023,10,4),234392),
                        new DateTimePoint(new DateTime(2023,10,5),238896),
                        new DateTimePoint(new DateTime(2023,10,6),244190),
                        new DateTimePoint(new DateTime(2023,10,7),247738),
                        new DateTimePoint(new DateTime(2023,10,8),251793),
                        new DateTimePoint(new DateTime(2023,10,9),254674),
                        new DateTimePoint(new DateTime(2023,10,10),257946),
                        new DateTimePoint(new DateTime(2023,10,11),260527),
                        new DateTimePoint(new DateTime(2023,10,12),266483),
                        new DateTimePoint(new DateTime(2023,10,13),270358),
                        new DateTimePoint(new DateTime(2023,10,14),273114),
                        new DateTimePoint(new DateTime(2023,10,15),276566),
                        new DateTimePoint(new DateTime(2023,10,16),279118),
                        new DateTimePoint(new DateTime(2023,10,17),282023),
                        new DateTimePoint(new DateTime(2023,10,18),286464),
                        new DateTimePoint(new DateTime(2023,10,19),289909),
                        new DateTimePoint(new DateTime(2023,10,20),294726),
                        new DateTimePoint(new DateTime(2023,10,21),297565),
                        new DateTimePoint(new DateTime(2023,10,22),300600),
                        new DateTimePoint(new DateTime(2023,10,23),304059),
                        new DateTimePoint(new DateTime(2023,10,24),308169),
                        new DateTimePoint(new DateTime(2023,10,25),315545),
                        new DateTimePoint(new DateTime(2023,10,26),318550),
                        new DateTimePoint(new DateTime(2023,10,27),321734),
                        new DateTimePoint(new DateTime(2023,10,28),324529),
                        new DateTimePoint(new DateTime(2023,10,29),327189),
                        new DateTimePoint(new DateTime(2023,10,30),329968),
                        new DateTimePoint(new DateTime(2023,10,31),334475),
                        new DateTimePoint(new DateTime(2023,11,1),337116),
                        new DateTimePoint(new DateTime(2023,11,2),343245),
                        new DateTimePoint(new DateTime(2023,11,3),347295),
                        new DateTimePoint(new DateTime(2023,11,4),350238),
                        new DateTimePoint(new DateTime(2023,11,5),353787),
                        new DateTimePoint(new DateTime(2023,11,6),357563),
                        new DateTimePoint(new DateTime(2023,11,7),360503),
                        new DateTimePoint(new DateTime(2023,11,8),366940),
                        new DateTimePoint(new DateTime(2023,11,9),371227),
                        new DateTimePoint(new DateTime(2023,11,10),376102),
                        new DateTimePoint(new DateTime(2023,11,11),380641),
                    }
                }
            };
        }

        public override byte[] DownloadChartData()
        {
            var totalSerie = Series[0].As<LineSeries<DateTimePoint>>();
            var prizeSerie = Series[1].As<LineSeries<DateTimePoint>>();

            var totalSerieValues = totalSerie.Values.ToList();
            var prizeSerieValues = prizeSerie.Values.ToList();
            var records = new List<CsvData>();

            for (int i = 0; i < totalSerieValues.Count(); i++)
            {
                records.Add(new CsvData
                {
                    Date = totalSerieValues[i].DateTime,
                    TotaRewardPools = totalSerieValues[i].Value,
                    TotalRewardPoolPrizes = prizeSerieValues[i].Value,
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
            public double? TotalRewardPoolPrizes { get; set; }
            public double? TotaRewardPools { get; set; }
        }
    }
}
