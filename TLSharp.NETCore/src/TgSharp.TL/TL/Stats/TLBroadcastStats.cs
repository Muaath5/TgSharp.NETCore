using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using TgSharp.TL;

namespace TgSharp.TL.Stats
{
    [TLObject(-1107852396)]
    public class TLBroadcastStats : TgSharp.TL.Stats.TLAbsBroadcastStats
    {
        public override int Constructor
        {
            get
            {
                return -1107852396;
            }
        }

        
		public TLAbsStatsDateRangeDays Period { get; set; }
		public TLAbsStatsAbsValueAndPrev Followers { get; set; }
		public TLAbsStatsAbsValueAndPrev ViewsPerPost { get; set; }
		public TLAbsStatsAbsValueAndPrev SharesPerPost { get; set; }
		public TLAbsStatsPercentValue EnabledNotifications { get; set; }
		public TLAbsStatsGraph GrowthGraph { get; set; }
		public TLAbsStatsGraph FollowersGraph { get; set; }
		public TLAbsStatsGraph MuteGraph { get; set; }
		public TLAbsStatsGraph TopHoursGraph { get; set; }
		public TLAbsStatsGraph InteractionsGraph { get; set; }
		public TLAbsStatsGraph IvInteractionsGraph { get; set; }
		public TLAbsStatsGraph ViewsBySourceGraph { get; set; }
		public TLAbsStatsGraph NewFollowersBySourceGraph { get; set; }
		public TLAbsStatsGraph LanguagesGraph { get; set; }
		public TLVector<TLAbsMessageInteractionCounters> RecentMessageInteractions { get; set; }

        public void ComputeFlags()
        {
            // do nothing
        }

        public override void DeserializeBody(BinaryReader br)
        {
            Period = (TLAbsStatsDateRangeDays)ObjectUtils.DeserializeObject(br);
			Followers = (TLAbsStatsAbsValueAndPrev)ObjectUtils.DeserializeObject(br);
			ViewsPerPost = (TLAbsStatsAbsValueAndPrev)ObjectUtils.DeserializeObject(br);
			SharesPerPost = (TLAbsStatsAbsValueAndPrev)ObjectUtils.DeserializeObject(br);
			EnabledNotifications = (TLAbsStatsPercentValue)ObjectUtils.DeserializeObject(br);
			GrowthGraph = (TLAbsStatsGraph)ObjectUtils.DeserializeObject(br);
			FollowersGraph = (TLAbsStatsGraph)ObjectUtils.DeserializeObject(br);
			MuteGraph = (TLAbsStatsGraph)ObjectUtils.DeserializeObject(br);
			TopHoursGraph = (TLAbsStatsGraph)ObjectUtils.DeserializeObject(br);
			InteractionsGraph = (TLAbsStatsGraph)ObjectUtils.DeserializeObject(br);
			IvInteractionsGraph = (TLAbsStatsGraph)ObjectUtils.DeserializeObject(br);
			ViewsBySourceGraph = (TLAbsStatsGraph)ObjectUtils.DeserializeObject(br);
			NewFollowersBySourceGraph = (TLAbsStatsGraph)ObjectUtils.DeserializeObject(br);
			LanguagesGraph = (TLAbsStatsGraph)ObjectUtils.DeserializeObject(br);
			RecentMessageInteractions = (TLVector<TLAbsMessageInteractionCounters>)ObjectUtils.DeserializeObject(br);
			
        }

        public override void SerializeBody(BinaryWriter bw)
        {
            bw.Write(Constructor);
            ObjectUtils.SerializeObject(Period, bw);
			ObjectUtils.SerializeObject(Followers, bw);
			ObjectUtils.SerializeObject(ViewsPerPost, bw);
			ObjectUtils.SerializeObject(SharesPerPost, bw);
			ObjectUtils.SerializeObject(EnabledNotifications, bw);
			ObjectUtils.SerializeObject(GrowthGraph, bw);
			ObjectUtils.SerializeObject(FollowersGraph, bw);
			ObjectUtils.SerializeObject(MuteGraph, bw);
			ObjectUtils.SerializeObject(TopHoursGraph, bw);
			ObjectUtils.SerializeObject(InteractionsGraph, bw);
			ObjectUtils.SerializeObject(IvInteractionsGraph, bw);
			ObjectUtils.SerializeObject(ViewsBySourceGraph, bw);
			ObjectUtils.SerializeObject(NewFollowersBySourceGraph, bw);
			ObjectUtils.SerializeObject(LanguagesGraph, bw);
			ObjectUtils.SerializeObject(RecentMessageInteractions, bw);
			
        }
    }
}