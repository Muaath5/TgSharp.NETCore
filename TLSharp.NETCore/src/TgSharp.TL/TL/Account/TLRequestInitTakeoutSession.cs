using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using TgSharp.TL;

namespace TgSharp.TL.Account
{
    [TLObject(-262453244)]
    public class TLRequestInitTakeoutSession : TLMethod
    {
        public override int Constructor
        {
            get
            {
                return -262453244;
            }
        }

        public int Flags { get; set; }
		public bool Contacts { get; set; }
		public bool MessageUsers { get; set; }
		public bool MessageChats { get; set; }
		public bool MessageMegagroups { get; set; }
		public bool MessageChannels { get; set; }
		public bool Files { get; set; }
		public int FileMaxSize { get; set; }
		public Account.TLAbsTakeout Response { get; set; }

        public void ComputeFlags()
        {
            // do nothing
        }

        public override void DeserializeBody(BinaryReader br)
        {
            br.ReadInt32();
			if ((Flags & 2) != 0)
				Contacts = (bool)ObjectUtils.DeserializeObject(br);
			if ((Flags & 3) != 0)
				MessageUsers = (bool)ObjectUtils.DeserializeObject(br);
			if ((Flags & 0) != 0)
				MessageChats = (bool)ObjectUtils.DeserializeObject(br);
			if ((Flags & 1) != 0)
				MessageMegagroups = (bool)ObjectUtils.DeserializeObject(br);
			if ((Flags & 6) != 0)
				MessageChannels = (bool)ObjectUtils.DeserializeObject(br);
			if ((Flags & 7) != 0)
				Files = (bool)ObjectUtils.DeserializeObject(br);
			if ((Flags & 7) != 0)
				FileMaxSize = br.ReadInt32();
			
        }

        public override void SerializeBody(BinaryWriter bw)
        {
            bw.Write(Constructor);
            
			if ((Flags & 2) != 0)
	ObjectUtils.SerializeObject(Contacts, bw);
			if ((Flags & 3) != 0)
	ObjectUtils.SerializeObject(MessageUsers, bw);
			if ((Flags & 0) != 0)
	ObjectUtils.SerializeObject(MessageChats, bw);
			if ((Flags & 1) != 0)
	ObjectUtils.SerializeObject(MessageMegagroups, bw);
			if ((Flags & 6) != 0)
	ObjectUtils.SerializeObject(MessageChannels, bw);
			if ((Flags & 7) != 0)
	ObjectUtils.SerializeObject(Files, bw);
			if ((Flags & 7) != 0)
	bw.Write(FileMaxSize);
			
        }

        public override void DeserializeResponse(BinaryReader br)
        {
            Response = (Account.TLAbsTakeout)ObjectUtils.DeserializeObject(br);
        }
    }
}