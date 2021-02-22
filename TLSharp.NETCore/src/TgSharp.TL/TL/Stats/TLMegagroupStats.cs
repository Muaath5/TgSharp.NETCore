using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using TgSharp.TL;

namespace TgSharp.TL.Stats
{
    [TLObject(-276825834)]
    public class TLMegagroupStats : TgSharp.TL.Stats.TLAbsMegagroupStats
    {
        public override int Constructor
        {
            get
            {
                return -276825834;
            }
        }

        
		public TLAbsStatsDateRangeDays Period { get; set; }
		public TLAbsStatsAbsValueAndPrev Members { get; set; }
		public TLAbsStatsAbsValueAndPrev Messages { get; set; }
		public TLAbsStatsAbsValueAndPrev Viewers { get; set; }
		public TLAbsStatsAbsValueAndPrev Posters { get; set; }
		public TLAbsStatsGraph GrowthGraph { get; set; }
		public TLAbsStatsGraph MembersGraph { get; set; }
		public TLAbsStatsGraph NewMembersBySourceGraph { get; set; }
		public TLAbsStatsGraph LanguagesGraph { get; set; }
		public TLAbsStatsGraph MessagesGraph { get; set; }
		public TLAbsStatsGraph ActionsGraph { get; set; }
		public TLAbsStatsGraph TopHoursGraph { get; set; }
		public TLAbsStatsGraph WeekdaysGraph { get; set; }
		public TLVector<TLAbsStatsGroupTopPoster> TopPosters { get; set; }
		public TLVector<TLAbsStatsGroupTopAdmin> TopAdmins { get; set; }
		public TLVector<TLAbsStatsGroupTopInviter> TopInviters { get; set; }
		public TLVector<TLAbsUser> Users { get; set; }

        public void ComputeFlags()
        {
            // do nothing
        }

        public override void DeserializeBody(BinaryReader br)
        {
            Period = (TLAbsStatsDateRangeDays)ObjectUtils.DeserializeObject(br);
			Members = (TLAbsStatsAbsValueAndPrev)ObjectUtils.DeserializeObject(br);
			Messages = (TLAbsStatsAbsValueAndPrev)ObjectUtils.DeserializeObject(br);
			Viewers = (TLAbsStatsAbsValueAndPrev)ObjectUtils.DeserializeObject(br);
			Posters = (TLAbsStatsAbsValueAndPrev)ObjectUtils.DeserializeObject(br);
			GrowthGraph = (TLAbsStatsGraph)ObjectUtils.DeserializeObject(br);
			MembersGraph = (TLAbsStatsGraph)ObjectUtils.DeserializeObject(br);
			NewMembersBySourceGraph = (TLAbsStatsGraph)ObjectUtils.DeserializeObject(br);
			LanguagesGraph = (TLAbsStatsGraph)ObjectUtils.DeserializeObject(br);
			MessagesGraph = (TLAbsStatsGraph)ObjectUtils.DeserializeObject(br);
			ActionsGraph = (TLAbsStatsGraph)ObjectUtils.DeserializeObject(br);
			TopHoursGraph = (TLAbsStatsGraph)ObjectUtils.DeserializeObject(br);
			WeekdaysGraph = (TLAbsStatsGraph)ObjectUtils.DeserializeObject(br);
			TopPosters = (TLVector<TLAbsStatsGroupTopPoster>)ObjectUtils.DeserializeObject(br);
			TopAdmins = (TLVector<TLAbsStatsGroupTopAdmin>)ObjectUtils.DeserializeObject(br);
			TopInviters = (TLVector<TLAbsStatsGroupTopInviter>)ObjectUtils.DeserializeObject(br);
			Users = (TLVector<TLAbsUser>)ObjectUtils.DeserializeObject(br);
			
        }

        public override void SerializeBody(BinaryWriter bw)
        {
            bw.Write(Constructor);
            ObjectUtils.SerializeObject(Period, bw);
			ObjectUtils.SerializeObject(Members, bw);
			ObjectUtils.SerializeObject(Messages, bw);
			ObjectUtils.SerializeObject(Viewers, bw);
			ObjectUtils.SerializeObject(Posters, bw);
			ObjectUtils.SerializeObject(GrowthGraph, bw);
			ObjectUtils.SerializeObject(MembersGraph, bw);
			ObjectUtils.SerializeObject(NewMembersBySourceGraph, bw);
			ObjectUtils.SerializeObject(LanguagesGraph, bw);
			ObjectUtils.SerializeObject(MessagesGraph, bw);
			ObjectUtils.SerializeObject(ActionsGraph, bw);
			ObjectUtils.SerializeObject(TopHoursGraph, bw);
			ObjectUtils.SerializeObject(WeekdaysGraph, bw);
			ObjectUtils.SerializeObject(TopPosters, bw);
			ObjectUtils.SerializeObject(TopAdmins, bw);
			ObjectUtils.SerializeObject(TopInviters, bw);
			ObjectUtils.SerializeObject(Users, bw);
			
        }
    }
}