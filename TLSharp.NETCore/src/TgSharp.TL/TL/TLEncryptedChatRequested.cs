using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using TgSharp.TL;

namespace TgSharp.TL
{
    [TLObject(1651608194)]
    public class TLEncryptedChatRequested : TLAbsEncryptedChat
    {
        public override int Constructor
        {
            get
            {
                return 1651608194;
            }
        }

        public int Flags { get; set; }
		public int FolderId { get; set; }
		public int Id { get; set; }
		public long AccessHash { get; set; }
		public int Date { get; set; }
		public int AdminId { get; set; }
		public int ParticipantId { get; set; }
		public byte[] GA { get; set; }

        public void ComputeFlags()
        {
            // do nothing
        }

        public override void DeserializeBody(BinaryReader br)
        {
            br.ReadInt32();if ((Flags & 2) != 0)
				FolderId = br.ReadInt32();
			Id = br.ReadInt32();
			AccessHash = br.ReadInt64();
			Date = br.ReadInt32();
			AdminId = br.ReadInt32();
			ParticipantId = br.ReadInt32();
			GA = (byte[])ObjectUtils.DeserializeObject(br);
			
        }

        public override void SerializeBody(BinaryWriter bw)
        {
            bw.Write(Constructor);
            if ((Flags & 2) != 0)
	bw.Write(FolderId);
			bw.Write(Id);
			bw.Write(AccessHash);
			bw.Write(Date);
			bw.Write(AdminId);
			bw.Write(ParticipantId);
			ObjectUtils.SerializeObject(GA, bw);
			
        }
    }
}