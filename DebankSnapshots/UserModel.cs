using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace DebankSnapshots
{
    public class UserModel
    {
        [JsonPropertyName("id")]
        public string Id { get; set; }
        [JsonPropertyName("usd_value")]
        public double UsdValue { get; set; }
        [JsonPropertyName("web3_id")]
        public string Web3Id { get; set; }
        [JsonPropertyName("follower_count")]
        public int FollowerCount { get; set; }
        [JsonPropertyName("tvf")]
        public double Tvf { get; set; }
    }
}