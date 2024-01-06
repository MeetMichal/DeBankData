using CsvHelper;
using System.Globalization;

namespace DebankSnapshots
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var directory = "C:\\Repozytoria\\Inne\\web3-data\\valuable-users";

            var userSnapshotsByusdValue = new List<UserSnapshotModel>();
            var userSnapshotsByFollowerCount = new List<UserSnapshotModel>();
            var userSnapshotsByTvf = new List<UserSnapshotModel>();

            foreach(var file in System.IO.Directory.GetFiles(directory).Where(p => p.EndsWith(".json")))
            {
                var fileName = System.IO.Path.GetFileName(file);
                var date = System.DateTime.Parse(fileName.Substring(0, fileName.IndexOf('.')));
                var json = System.IO.File.ReadAllText(file);
                var users = System.Text.Json.JsonSerializer.Deserialize<UserModel[]>(json);

                var top10ByUsdValue = users.Where(u => !String.IsNullOrWhiteSpace(u.Web3Id)).OrderByDescending(u => u.UsdValue).Take(10).Select(u => new UserSnapshotModel(u, date));
                var top10ByFollowerCount = users.Where(u => !String.IsNullOrWhiteSpace(u.Web3Id)).OrderByDescending(u => u.FollowerCount).Take(10).Select(u => new UserSnapshotModel(u, date));
                var top10ByTvf = users.Where(u => !String.IsNullOrWhiteSpace(u.Web3Id)).OrderByDescending(u => u.Tvf).Take(10).Select(u => new UserSnapshotModel(u, date));

                userSnapshotsByusdValue.AddRange(top10ByUsdValue);
                userSnapshotsByFollowerCount.AddRange(top10ByFollowerCount);
                userSnapshotsByTvf.AddRange(top10ByTvf);
            }

            userSnapshotsByusdValue = userSnapshotsByusdValue.OrderBy(u => u.SnapshotDate).ToList();
            userSnapshotsByFollowerCount = userSnapshotsByFollowerCount.OrderBy(u => u.SnapshotDate).ToList();
            userSnapshotsByTvf = userSnapshotsByTvf.OrderBy(u => u.SnapshotDate).ToList();

            using (var writer = new StreamWriter("SnapshotByUsdValue.csv"))
            using (var csv = new CsvWriter(writer, CultureInfo.InvariantCulture))
            {
                csv.WriteRecords(userSnapshotsByusdValue);
            }

            using (var writer = new StreamWriter("SnapshotByFollowerCount.csv"))
            using (var csv = new CsvWriter(writer, CultureInfo.InvariantCulture))
            {
                csv.WriteRecords(userSnapshotsByFollowerCount);
            }

            using (var writer = new StreamWriter("SnapshotByTvf.csv"))
            using (var csv = new CsvWriter(writer, CultureInfo.InvariantCulture))
            {
                csv.WriteRecords(userSnapshotsByTvf);
            }
        }
    }
}
