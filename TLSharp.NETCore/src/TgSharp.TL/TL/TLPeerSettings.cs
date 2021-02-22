using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using TgSharp.TL;

namespace TgSharp.TL
{
    [TLObject(1933519201)]
    public class TLPeerSettings : TLAbsPeerSettings
    {
        public override int Constructor
        {
            get
            {
                return 1933519201;
            }
        }

        public int Flags { get; set; }
		public bool ReportSpam { get; set; }
		public bool AddContact { get; set; }
		public bool BlockContact { get; set; }
		public bool ShareContact { get; set; }
		public bool NeedContactsException { get; set; }
		public bool ReportGeo { get; set; }
		public bool Autoarchived { get; set; }
		public bool InviteMembers { get; set; }
		public int GeoDistance { get; set; }

        public void ComputeFlags()
        {
            // do nothing
        }

        public override void DeserializeBody(BinaryReader br)
        {
            br.ReadInt32();if ((Flags & 2) != 0)
				ReportSpam = (bool)ObjectUtils.DeserializeObject(br);
			if ((Flags & 3) != 0)
				AddContact = (bool)ObjectUtils.DeserializeObject(br);
			if ((Flags & 0) != 0)
				BlockContact = (bool)ObjectUtils.DeserializeObject(br);
			if ((Flags & 1) != 0)
				ShareContact = (bool)ObjectUtils.DeserializeObject(br);
			if ((Flags & 6) != 0)
				NeedContactsException = (bool)ObjectUtils.DeserializeObject(br);
			if ((Flags & 7) != 0)
				ReportGeo = (bool)ObjectUtils.DeserializeObject(br);
			if ((Flags & 5) != 0)
				Autoarchived = (bool)ObjectUtils.DeserializeObject(br);
			if ((Flags & 10) != 0)
				InviteMembers = (bool)ObjectUtils.DeserializeObject(br);
			if ((Flags & 4) != 0)
				GeoDistance = br.ReadInt32();
			
        }

        public override void SerializeBody(BinaryWriter bw)
        {
            bw.Write(Constructor);
            if ((Flags & 2) != 0)
	ObjectUtils.SerializeObject(ReportSpam, bw);
			if ((Flags & 3) != 0)
	ObjectUtils.SerializeObject(AddContact, bw);
			if ((Flags & 0) != 0)
	ObjectUtils.SerializeObject(BlockContact, bw);
			if ((Flags & 1) != 0)
	ObjectUtils.SerializeObject(ShareContact, bw);
			if ((Flags & 6) != 0)
	ObjectUtils.SerializeObject(NeedContactsException, bw);
			if ((Flags & 7) != 0)
	ObjectUtils.SerializeObject(ReportGeo, bw);
			if ((Flags & 5) != 0)
	ObjectUtils.SerializeObject(Autoarchived, bw);
			if ((Flags & 10) != 0)
	ObjectUtils.SerializeObject(InviteMembers, bw);
			if ((Flags & 4) != 0)
	bw.Write(GeoDistance);
			
        }
    }
}