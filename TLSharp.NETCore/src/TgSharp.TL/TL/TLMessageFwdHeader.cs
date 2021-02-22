using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using TgSharp.TL;

namespace TgSharp.TL
{
    [TLObject(1601666510)]
    public class TLMessageFwdHeader : TLAbsMessageFwdHeader
    {
        public override int Constructor
        {
            get
            {
                return 1601666510;
            }
        }

        public int Flags { get; set; }
		public bool Imported { get; set; }
		public TLAbsPeer FromId { get; set; }
		public string FromName { get; set; }
		public int Date { get; set; }
		public int ChannelPost { get; set; }
		public string PostAuthor { get; set; }
		public TLAbsPeer SavedFromPeer { get; set; }
		public int SavedFromMsgId { get; set; }
		public string PsaType { get; set; }

        public void ComputeFlags()
        {
            // do nothing
        }

        public override void DeserializeBody(BinaryReader br)
        {
            br.ReadInt32();if ((Flags & 5) != 0)
				Imported = (bool)ObjectUtils.DeserializeObject(br);
			if ((Flags & 2) != 0)
				FromId = (TLAbsPeer)ObjectUtils.DeserializeObject(br);
			if ((Flags & 7) != 0)
				FromName = StringUtil.Deserialize(br);
			Date = br.ReadInt32();
			if ((Flags & 0) != 0)
				ChannelPost = br.ReadInt32();
			if ((Flags & 1) != 0)
				PostAuthor = StringUtil.Deserialize(br);
			if ((Flags & 6) != 0)
				SavedFromPeer = (TLAbsPeer)ObjectUtils.DeserializeObject(br);
			if ((Flags & 6) != 0)
				SavedFromMsgId = br.ReadInt32();
			if ((Flags & 4) != 0)
				PsaType = StringUtil.Deserialize(br);
			
        }

        public override void SerializeBody(BinaryWriter bw)
        {
            bw.Write(Constructor);
            if ((Flags & 5) != 0)
	ObjectUtils.SerializeObject(Imported, bw);
			if ((Flags & 2) != 0)
	ObjectUtils.SerializeObject(FromId, bw);
			if ((Flags & 7) != 0)
	StringUtil.Serialize(FromName, bw);
			bw.Write(Date);
			if ((Flags & 0) != 0)
	bw.Write(ChannelPost);
			if ((Flags & 1) != 0)
	StringUtil.Serialize(PostAuthor, bw);
			if ((Flags & 6) != 0)
	ObjectUtils.SerializeObject(SavedFromPeer, bw);
			if ((Flags & 6) != 0)
	bw.Write(SavedFromMsgId);
			if ((Flags & 4) != 0)
	StringUtil.Serialize(PsaType, bw);
			
        }
    }
}