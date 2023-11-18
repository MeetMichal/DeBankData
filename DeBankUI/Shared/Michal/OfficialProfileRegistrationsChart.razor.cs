using DeBankUI.Components;
using DeBankUI.Utils;
using LiveChartsCore;
using LiveChartsCore.Defaults;
using LiveChartsCore.SkiaSharpView;
using LiveChartsCore.SkiaSharpView.Painting;
using SkiaSharp;

namespace DeBankUI.Shared.Michal
{
    public partial class OfficialProfileRegistrationsChart : BaseChartComponent
    {
        private static readonly SKColor black = SKColors.Black;
        private DrawMarginFrame DrawMarginFrame => new()
        {
            Fill = new SolidColorPaint(Colors.ChartBackground),
            Stroke = new SolidColorPaint(Colors.ChartBorder, 2)
        };

        private Axis[] XAxes { get; set; } =
        {
            new DateTimeAxis(TimeSpan.FromDays(1), date => date.ToString("yyyy-MM-dd"))
            {
                LabelsRotation = 30,
                TicksPaint = new SolidColorPaint(black),
                NamePaint = new SolidColorPaint(black),
                LabelsPaint = new SolidColorPaint(black),
            }
        };

        private Axis[] YAxes { get; set; } =
        {
            new Axis
            {
                Name = "Number of Official Profiles",
                NamePaint = new SolidColorPaint(Colors.SerieBlue),
                LabelsPaint = new SolidColorPaint(Colors.SerieBlue),
                TicksPaint = new SolidColorPaint(Colors.SerieBlue),
                SubticksPaint = new SolidColorPaint(Colors.SerieBlue),
            },
        };


        private ISeries[] Series { get; set; } =
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
                Values = new List<DateTimePoint>
                {
                    new DateTimePoint(new DateTime(2023,2,9),3),
                    new DateTimePoint(new DateTime(2023,2,22),4),
                    new DateTimePoint(new DateTime(2023,2,24),5),
                    new DateTimePoint(new DateTime(2023,2,28),6),
                    new DateTimePoint(new DateTime(2023,3,6),8),
                    new DateTimePoint(new DateTime(2023,3,14),9),
                    new DateTimePoint(new DateTime(2023,3,17),10),
                    new DateTimePoint(new DateTime(2023,3,22),11),
                    new DateTimePoint(new DateTime(2023,3,23),12),
                    new DateTimePoint(new DateTime(2023,3,26),13),
                    new DateTimePoint(new DateTime(2023,3,27),14),
                    new DateTimePoint(new DateTime(2023,3,29),15),
                    new DateTimePoint(new DateTime(2023,4,14),17),
                    new DateTimePoint(new DateTime(2023,4,17),18),
                    new DateTimePoint(new DateTime(2023,4,27),19),
                    new DateTimePoint(new DateTime(2023,4,29),20),
                    new DateTimePoint(new DateTime(2023,5,6),21),
                    new DateTimePoint(new DateTime(2023,5,8),22),
                    new DateTimePoint(new DateTime(2023,5,13),23),
                    new DateTimePoint(new DateTime(2023,5,18),24),
                    new DateTimePoint(new DateTime(2023,5,21),25),
                    new DateTimePoint(new DateTime(2023,5,23),27),
                    new DateTimePoint(new DateTime(2023,5,25),28),
                    new DateTimePoint(new DateTime(2023,5,26),31),
                    new DateTimePoint(new DateTime(2023,5,27),32),
                    new DateTimePoint(new DateTime(2023,5,29),34),
                    new DateTimePoint(new DateTime(2023,5,30),35),
                    new DateTimePoint(new DateTime(2023,5,31),37),
                    new DateTimePoint(new DateTime(2023,6,2),39),
                    new DateTimePoint(new DateTime(2023,6,3),40),
                    new DateTimePoint(new DateTime(2023,6,4),41),
                    new DateTimePoint(new DateTime(2023,6,6),42),
                    new DateTimePoint(new DateTime(2023,6,8),43),
                    new DateTimePoint(new DateTime(2023,6,9),44),
                    new DateTimePoint(new DateTime(2023,6,15),45),
                    new DateTimePoint(new DateTime(2023,6,18),46),
                    new DateTimePoint(new DateTime(2023,6,19),48),
                    new DateTimePoint(new DateTime(2023,6,20),49),
                    new DateTimePoint(new DateTime(2023,6,23),51),
                    new DateTimePoint(new DateTime(2023,6,24),52),
                    new DateTimePoint(new DateTime(2023,6,26),53),
                    new DateTimePoint(new DateTime(2023,6,27),55),
                    new DateTimePoint(new DateTime(2023,6,28),57),
                    new DateTimePoint(new DateTime(2023,6,30),58),
                    new DateTimePoint(new DateTime(2023,7,2),59),
                    new DateTimePoint(new DateTime(2023,7,5),60),
                    new DateTimePoint(new DateTime(2023,7,6),62),
                    new DateTimePoint(new DateTime(2023,7,7),63),
                    new DateTimePoint(new DateTime(2023,7,10),64),
                    new DateTimePoint(new DateTime(2023,7,12),65),
                    new DateTimePoint(new DateTime(2023,7,13),66),
                    new DateTimePoint(new DateTime(2023,7,16),67),
                    new DateTimePoint(new DateTime(2023,7,17),69),
                    new DateTimePoint(new DateTime(2023,7,18),71),
                    new DateTimePoint(new DateTime(2023,7,20),73),
                    new DateTimePoint(new DateTime(2023,7,22),74),
                    new DateTimePoint(new DateTime(2023,7,23),76),
                    new DateTimePoint(new DateTime(2023,7,24),79),
                    new DateTimePoint(new DateTime(2023,7,25),83),
                    new DateTimePoint(new DateTime(2023,7,26),84),
                    new DateTimePoint(new DateTime(2023,7,27),88),
                    new DateTimePoint(new DateTime(2023,7,30),91),
                    new DateTimePoint(new DateTime(2023,7,31),93),
                    new DateTimePoint(new DateTime(2023,8,1),94),
                    new DateTimePoint(new DateTime(2023,8,2),101),
                    new DateTimePoint(new DateTime(2023,8,3),104),
                    new DateTimePoint(new DateTime(2023,8,4),105),
                    new DateTimePoint(new DateTime(2023,8,5),106),
                    new DateTimePoint(new DateTime(2023,8,6),107),
                    new DateTimePoint(new DateTime(2023,8,9),113),
                    new DateTimePoint(new DateTime(2023,8,10),115),
                    new DateTimePoint(new DateTime(2023,8,11),117),
                    new DateTimePoint(new DateTime(2023,8,12),118),
                    new DateTimePoint(new DateTime(2023,8,13),120),
                    new DateTimePoint(new DateTime(2023,8,14),122),
                    new DateTimePoint(new DateTime(2023,8,15),123),
                    new DateTimePoint(new DateTime(2023,8,16),126),
                    new DateTimePoint(new DateTime(2023,8,17),128),
                    new DateTimePoint(new DateTime(2023,8,18),131),
                    new DateTimePoint(new DateTime(2023,8,19),132),
                    new DateTimePoint(new DateTime(2023,8,21),137),
                    new DateTimePoint(new DateTime(2023,8,22),138),
                    new DateTimePoint(new DateTime(2023,8,23),141),
                    new DateTimePoint(new DateTime(2023,8,24),142),
                    new DateTimePoint(new DateTime(2023,8,25),143),
                    new DateTimePoint(new DateTime(2023,8,26),144),
                    new DateTimePoint(new DateTime(2023,8,27),145),
                    new DateTimePoint(new DateTime(2023,8,28),147),
                    new DateTimePoint(new DateTime(2023,8,29),150),
                    new DateTimePoint(new DateTime(2023,8,30),151),
                    new DateTimePoint(new DateTime(2023,8,31),154),
                    new DateTimePoint(new DateTime(2023,9,1),156),
                    new DateTimePoint(new DateTime(2023,9,4),157),
                    new DateTimePoint(new DateTime(2023,9,5),160),
                    new DateTimePoint(new DateTime(2023,9,6),162),
                    new DateTimePoint(new DateTime(2023,9,7),165),
                    new DateTimePoint(new DateTime(2023,9,8),169),
                    new DateTimePoint(new DateTime(2023,9,11),172),
                    new DateTimePoint(new DateTime(2023,9,13),175),
                    new DateTimePoint(new DateTime(2023,9,15),176),
                    new DateTimePoint(new DateTime(2023,9,16),177),
                    new DateTimePoint(new DateTime(2023,9,17),178),
                    new DateTimePoint(new DateTime(2023,9,18),179),
                    new DateTimePoint(new DateTime(2023,9,19),180),
                    new DateTimePoint(new DateTime(2023,9,20),183),
                    new DateTimePoint(new DateTime(2023,9,21),185),
                    new DateTimePoint(new DateTime(2023,9,22),186),
                    new DateTimePoint(new DateTime(2023,9,23),187),
                    new DateTimePoint(new DateTime(2023,9,25),189),
                    new DateTimePoint(new DateTime(2023,9,27),191),
                    new DateTimePoint(new DateTime(2023,9,28),192),
                    new DateTimePoint(new DateTime(2023,10,2),195),
                    new DateTimePoint(new DateTime(2023,10,3),196),
                    new DateTimePoint(new DateTime(2023,10,4),198),
                    new DateTimePoint(new DateTime(2023,10,6),199),
                    new DateTimePoint(new DateTime(2023,10,7),200),
                    new DateTimePoint(new DateTime(2023,10,8),201),
                    new DateTimePoint(new DateTime(2023,10,10),204),
                    new DateTimePoint(new DateTime(2023,10,11),207),
                    new DateTimePoint(new DateTime(2023,10,13),208),
                    new DateTimePoint(new DateTime(2023,10,14),209),
                    new DateTimePoint(new DateTime(2023,10,15),210),
                    new DateTimePoint(new DateTime(2023,10,16),213),
                    new DateTimePoint(new DateTime(2023,10,17),217),
                    new DateTimePoint(new DateTime(2023,10,18),221),
                    new DateTimePoint(new DateTime(2023,10,19),225),
                    new DateTimePoint(new DateTime(2023,10,20),227),
                    new DateTimePoint(new DateTime(2023,10,22),228),
                    new DateTimePoint(new DateTime(2023,10,23),230),
                    new DateTimePoint(new DateTime(2023,10,24),235),
                    new DateTimePoint(new DateTime(2023,10,25),240),
                    new DateTimePoint(new DateTime(2023,10,26),246),
                    new DateTimePoint(new DateTime(2023,10,27),248),
                    new DateTimePoint(new DateTime(2023,10,28),250),
                    new DateTimePoint(new DateTime(2023,10,30),254),
                    new DateTimePoint(new DateTime(2023,10,31),256),
                    new DateTimePoint(new DateTime(2023,11,1),257),
                    new DateTimePoint(new DateTime(2023,11,3),258),
                    new DateTimePoint(new DateTime(2023,11,6),259),
                    new DateTimePoint(new DateTime(2023,11,7),262),
                    new DateTimePoint(new DateTime(2023,11,8),264),
                    new DateTimePoint(new DateTime(2023,11,10),268),
                    new DateTimePoint(new DateTime(2023,11,13),270),
                    new DateTimePoint(new DateTime(2023,11,15),271),
                    new DateTimePoint(new DateTime(2023,11,16),274),
                }
            },
        };
    }
}
