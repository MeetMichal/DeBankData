using CsvHelper.Configuration.Attributes;

namespace DeBankUI.Model
{
    public class UserRank
    {
        [Name("rank")]
        public int Rank { get; set; }

        [Name("rank_score")]
        public double RankScore { get; set; }

        [Name("web3_id")]
        public string Web3Id { get; set; }

        [Name("id")]
        public string Id { get; set; }

        [Name("balance")]
        public double Balance { get; set; }

        [Name("tvf")]
        public double Tvf { get; set; }

        [Name("followers")]
        public int Followers { get; set; }

        [Name("following")]
        public int Following { get; set; }

        [Name("trust")]
        public int Trust { get; set; }

        [Name("trust_7d")]
        public int Trust7d { get; set; }

        [Name("contribution")]
        public double Contribution { get; set; }

        [Name("sybil")]
        public int SybilsMark { get; set; }

        [Name("not_sybil")]
        public int NotSybilsMark { get; set; }
    }
}
