using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using TgSharp.TL;

namespace TgSharp.TL.Contacts
{
    [TLObject(-728224331)]
    public class TLRequestGetTopPeers : TLMethod
    {
        public override int Constructor
        {
            get
            {
                return -728224331;
            }
        }

        public int Flags { get; set; }
		public bool Correspondents { get; set; }
		public bool BotsPm { get; set; }
		public bool BotsInline { get; set; }
		public bool PhoneCalls { get; set; }
		public bool ForwardUsers { get; set; }
		public bool ForwardChats { get; set; }
		public bool Groups { get; set; }
		public bool Channels { get; set; }
		public int Offset { get; set; }
		public int Limit { get; set; }
		public int Hash { get; set; }
		public Contacts.TLAbsTopPeers Response { get; set; }

        public void ComputeFlags()
        {
            // do nothing
        }

        public override void DeserializeBody(BinaryReader br)
        {
            br.ReadInt32();
			if ((Flags & 2) != 0)
				Correspondents = (bool)ObjectUtils.DeserializeObject(br);
			if ((Flags & 3) != 0)
				BotsPm = (bool)ObjectUtils.DeserializeObject(br);
			if ((Flags & 0) != 0)
				BotsInline = (bool)ObjectUtils.DeserializeObject(br);
			if ((Flags & 1) != 0)
				PhoneCalls = (bool)ObjectUtils.DeserializeObject(br);
			if ((Flags & 6) != 0)
				ForwardUsers = (bool)ObjectUtils.DeserializeObject(br);
			if ((Flags & 7) != 0)
				ForwardChats = (bool)ObjectUtils.DeserializeObject(br);
			if ((Flags & 8) != 0)
				Groups = (bool)ObjectUtils.DeserializeObject(br);
			if ((Flags & 13) != 0)
				Channels = (bool)ObjectUtils.DeserializeObject(br);
			Offset = br.ReadInt32();
			Limit = br.ReadInt32();
			Hash = br.ReadInt32();
			
        }

        public override void SerializeBody(BinaryWriter bw)
        {
            bw.Write(Constructor);
            
			if ((Flags & 2) != 0)
	ObjectUtils.SerializeObject(Correspondents, bw);
			if ((Flags & 3) != 0)
	ObjectUtils.SerializeObject(BotsPm, bw);
			if ((Flags & 0) != 0)
	ObjectUtils.SerializeObject(BotsInline, bw);
			if ((Flags & 1) != 0)
	ObjectUtils.SerializeObject(PhoneCalls, bw);
			if ((Flags & 6) != 0)
	ObjectUtils.SerializeObject(ForwardUsers, bw);
			if ((Flags & 7) != 0)
	ObjectUtils.SerializeObject(ForwardChats, bw);
			if ((Flags & 8) != 0)
	ObjectUtils.SerializeObject(Groups, bw);
			if ((Flags & 13) != 0)
	ObjectUtils.SerializeObject(Channels, bw);
			bw.Write(Offset);
			bw.Write(Limit);
			bw.Write(Hash);
			
        }

        public override void DeserializeResponse(BinaryReader br)
        {
            Response = (Contacts.TLAbsTopPeers)ObjectUtils.DeserializeObject(br);
        }
    }
}