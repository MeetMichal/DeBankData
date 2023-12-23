using Blazor.DownloadFileFast.Interfaces;
using DeBankUI.Components;
using DeBankUI.Data;
using DeBankUI.Model;
using DeBankUI.Utils;
using Microsoft.AspNetCore.Components;

namespace DeBankUI.Pages.Nett
{
    public partial class Top100Users
    {
        [Inject]
        public HttpClient HttpClient { get; set; }
        [Inject]
        public IBlazorDownloadFileService BlazorDownloadFileService { get; set; }
        public List<UserRank> UserRanks { get; set; } = new List<UserRank>();

        protected override async Task OnInitializedAsync()
        {
            UserRanks = (await NettData.GetUserRanks(HttpClient)).OrderBy(u => u.Rank).ToList();

            await base.OnInitializedAsync();
        }

        public async Task DownloadData(string title)
        {
            var stream = await HttpClient.GetStreamAsync("top100.csv");
            await BlazorDownloadFileService.DownloadFileAsync(title, stream.ReadFully());
        }
    }
}
