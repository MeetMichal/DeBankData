using LiveChartsCore.Defaults;
using LiveChartsCore.SkiaSharpView;
using LiveChartsCore;
using LiveChartsCore.Kernel.Sketches;
using LiveChartsCore.SkiaSharpView.Painting;
using static MudBlazor.Colors;
using SkiaSharp;
using DeBankUI.Utils;
using DeBankUI.Components;
using Blazor.DownloadFileFast.Interfaces;
using Microsoft.AspNetCore.Components;
using DeBankUI.Shared.Michal;

namespace DeBankUI.Pages.Michal
{
    public partial class TopDepositsPage
    {
        string[] headings = {"", "Address", "Total deposit", "Min deposited", "Max deposited", "Average deposit", "Number of deposits" };
        string[] rewardPoolsTop10Total = {
            @"1 110118	26180	100	7010	1454,44	18",
            @"2 0xbdb7819a671b83e04800a98e00294a67d7d2ec7a	13913,19	0,2	3100	66,25	210",
            @"3 0xbdcd88b1967b6e0e47df420e5882286776e74afb	8706,15	0,1	1000	20,78	419",
            @"4 0xcedafb4137505a23238e225378293e6c0fde1745	6731,8	0,01	3000	31,90	211",
            @"5 0x9ed2af9d4ab71740e4d63fab593be7e8701ea169	5385,78	0,02	1515	50,33	107",
            @"6 0xa6ed26749cb54591291b4550a82f15ff64ae98d9	4949,81	0,01	3000	36,40	136",
            @"7 0x66b870ddf78c975af5cd8edc6de25eca81791de1	4523,5377	6	777,77	71,80	63",
            @"8 0x0228028a0c92cfd9743e561a96b16edbb4606054	4041,9545	0,01	245	7,89	512",
            @"9 113837	4000	1000	1000	1000,00	4",
            @"10 0x7bfee91193d9df2ac0bfe90191d40f23c773c060	3782,65	1	1208	18,82	201",
        };

        string[] luckyDrawsTop10Total = {
            @"1 0x0c86262354095fa35a21b58af3e0dd94d0ba767c	2850	3	1350	64,77	44",
            @"2 0xbdc149340cc73b38aebde5f67bae146a1af9e0d6	2399	100	666	342,71	7",
            @"3 0a112219	1894	25	250	145,69	13",
            @"4 0xd590fca11cd9f50fb164ecd0ded209ab0110cd20	1631	5	150	90,61	18",
            @"5 0x4e5ed30e3b4eb39abce3c150f31e180a3ae5806e	1592	192	1200	530,67	3",
            @"6 0x009515efabccdbafa485f3919d94c85ff23ba75d	1554	10	500	259,00	6",
            @"7 0xbdcd88b1967b6e0e47df420e5882286776e74afb	1429	1	500	68,05	21",
            @"8 0x8e17543e388eea7f99bc0736476875dd8d950037	1139	9	1000	189,83	6",
            @"9 0x36243ade16d74eedbb3f2b8b2ecf286f538ef5fd	1130	16	128	62,78	18",
            @"10 0x7440aec57c5e7bf6226fd319b44a50c2e709fcf6	1051	11	300	75,07	14",
        };

        string[] rewardPoolsTop10LastMonth = {
            @"1 0xbdb7819a671b83e04800a98e00294a67d7d2ec7a	9988	1	2000	64,03	156",
            @"2 113837	4000	1000	1000	1000,00	4",
            @"3 110118	3350	300	1500	837,50	4",
            @"4 0x4e5ed30e3b4eb39abce3c150f31e180a3ae5806e	2157,6	0,05	100	10,47	206",
            @"5 0x77ef4606add21389906db87674f511391cd9b692	1859,44	5	363	123,96	15",
            @"6 0x7522682a93738e7da3ab42959d61cd809fe62440	1810	1	197	54,85	33",
            @"7 0xbdcd88b1967b6e0e47df420e5882286776e74afb	1651,68	1	500	20,65	80",
            @"8 110771	1120	5	430	35,00	32",
            @"9 0x9c01b839c6091e519fd4749efa8b81e190c6d892	1039,16	0,1	100	11,94	87",
            @"10 0xbdc149340cc73b38aebde5f67bae146a1af9e0d6	904	1	66	12,05	75",
        };

        string[] luckyDrawsTop10LastMonth = {
            @"1 0x97e542ec6b81dea28f212775ce8ac436ab77a7df	660	20	400	94,29	7",
            @"2 0x3f2383068de5193b0968d93b05e46b2ee411dd94	560	25	300	93,33	6",
            @"3 0x77ef4606add21389906db87674f511391cd9b692	478	3	100	36,77	13",
            @"4 0xef7b7bfbc73931d230d4ff165e532d2d2248d1d1	447	1	111	17,19	26",
            @"5 0xbdc149340cc73b38aebde5f67bae146a1af9e0d6	333	333	333	333,00	1",
            @"6 0xa4b6eeeb7eba0fc360a7402f2ebe90c178115e91	330	2	200	66,00	5",
            @"7 0x0c86262354095fa35a21b58af3e0dd94d0ba767c	315	4	101	52,50	6",
            @"8 0x00e7a7f1189af18d2416363137dea6fca5cf936a	283	9	76	25,73	11",
            @"9 0x111728d5a789c418d1d9a282bf01ba4bb487c96a	257	10	51	18,36	14",
            @"10 0xbe934d1a6cd788532912a25eb10c53a00747465d	245	3	100	20,42	12",
        };
    }
}
