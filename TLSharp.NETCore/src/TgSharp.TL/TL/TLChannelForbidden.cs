using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using TgSharp.TL;

namespace TgSharp.TL
{
    [TLObject(681420594)]
    public class TLChannelForbidden : TLAbsChat
    {
        public override int Constructor
        {
            get
            {
                return 681420594;
            }
        }

        public int Flags { get; set; }
		public bool Broadcast { get; set; }
		public bool Megagroup { get; set; }
		public int Id { get; set; }
		public long AccessHash { get; set; }
		public string Title { get; set; }
		public int UntilDate { get; set; }

        public void ComputeFlags()
        {
            // do nothing
        }

        public override void DeserializeBody(BinaryReader br)
        {
            br.ReadInt32();if ((Flags & 7) != 0)
				Broadcast = (bool)ObjectUtils.DeserializeObject(br);
			if ((Flags & 10) != 0)
				Megagroup = (bool)ObjectUtils.DeserializeObject(br);
			Id = br.ReadInt32();
			AccessHash = br.ReadInt64();
			Title = StringUtil.Deserialize(br);
			if ((Flags & 18) != 0)
				UntilDate = br.ReadInt32();
			
        }

        public override void SerializeBody(BinaryWriter bw)
        {
            bw.Write(Constructor);
            if ((Flags & 7) != 0)
	ObjectUtils.SerializeObject(Broadcast, bw);
			if ((Flags & 10) != 0)
	ObjectUtils.SerializeObject(Megagroup, bw);
			bw.Write(Id);
			bw.Write(AccessHash);
			StringUtil.Serialize(Title, bw);
			if ((Flags & 18) != 0)
	bw.Write(UntilDate);
			
        }
    }
}