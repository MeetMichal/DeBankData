using CsvHelper;
using DeBankUI.Model;
using System.Globalization;
using static System.Net.WebRequestMethods;

namespace DeBankUI.Data
{
    public static class NettData
    {
        public static async Task<List<UserRank>> GetUserRanks(HttpClient client)
        {
            var csvData = await client.GetStringAsync("top100.csv");

            using (var reader = new StringReader(csvData))
            using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
            {
                var records = csv.GetRecords<UserRank>();
                return records.ToList();
            }
        }
    }
}
