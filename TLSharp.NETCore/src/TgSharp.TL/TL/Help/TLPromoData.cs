using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using TgSharp.TL;

namespace TgSharp.TL.Help
{
    [TLObject(-1942390465)]
    public class TLPromoData : TgSharp.TL.Help.TLAbsPromoData
    {
        public override int Constructor
        {
            get
            {
                return -1942390465;
            }
        }

        public int Flags { get; set; }
		public bool Proxy { get; set; }
		public int Expires { get; set; }
		public TLAbsPeer Peer { get; set; }
		public TLVector<TLAbsChat> Chats { get; set; }
		public TLVector<TLAbsUser> Users { get; set; }
		public string PsaType { get; set; }
		public string PsaMessage { get; set; }

        public void ComputeFlags()
        {
            // do nothing
        }

        public override void DeserializeBody(BinaryReader br)
        {
            br.ReadInt32();if ((Flags & 2) != 0)
				Proxy = (bool)ObjectUtils.DeserializeObject(br);
			Expires = br.ReadInt32();
			Peer = (TLAbsPeer)ObjectUtils.DeserializeObject(br);
			Chats = (TLVector<TLAbsChat>)ObjectUtils.DeserializeObject(br);
			Users = (TLVector<TLAbsUser>)ObjectUtils.DeserializeObject(br);
			if ((Flags & 3) != 0)
				PsaType = StringUtil.Deserialize(br);
			if ((Flags & 0) != 0)
				PsaMessage = StringUtil.Deserialize(br);
			
        }

        public override void SerializeBody(BinaryWriter bw)
        {
            bw.Write(Constructor);
            if ((Flags & 2) != 0)
	ObjectUtils.SerializeObject(Proxy, bw);
			bw.Write(Expires);
			ObjectUtils.SerializeObject(Peer, bw);
			ObjectUtils.SerializeObject(Chats, bw);
			ObjectUtils.SerializeObject(Users, bw);
			if ((Flags & 3) != 0)
	StringUtil.Serialize(PsaType, bw);
			if ((Flags & 0) != 0)
	StringUtil.Serialize(PsaMessage, bw);
			
        }
    }
}