using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace DebankSnapshots
{
    public class UserSnapshotModel : UserModel
    {
        [JsonPropertyName("snapshot_date")]
        public DateTime SnapshotDate { get; set; }

        public UserSnapshotModel(UserModel user, DateTime snapshotDate)
        {
            this.Id = user.Id;
            this.UsdValue = user.UsdValue;
            this.Web3Id = user.Web3Id;
            this.FollowerCount = user.FollowerCount;
            this.Tvf = user.Tvf;
            this.SnapshotDate = snapshotDate;
        }
    }
}
