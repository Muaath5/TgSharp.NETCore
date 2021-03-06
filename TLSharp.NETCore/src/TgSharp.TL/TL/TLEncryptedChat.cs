using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using TgSharp.TL;

namespace TgSharp.TL
{
    [TLObject(-94974410)]
    public class TLEncryptedChat : TLAbsEncryptedChat
    {
        public override int Constructor
        {
            get
            {
                return -94974410;
            }
        }

        
		public int Id { get; set; }
		public long AccessHash { get; set; }
		public int Date { get; set; }
		public int AdminId { get; set; }
		public int ParticipantId { get; set; }
		public byte[] GAOrB { get; set; }
		public long KeyFingerprint { get; set; }

        public void ComputeFlags()
        {
            // do nothing
        }

        public override void DeserializeBody(BinaryReader br)
        {
            Id = br.ReadInt32();
			AccessHash = br.ReadInt64();
			Date = br.ReadInt32();
			AdminId = br.ReadInt32();
			ParticipantId = br.ReadInt32();
			GAOrB = (byte[])ObjectUtils.DeserializeObject(br);
			KeyFingerprint = br.ReadInt64();
			
        }

        public override void SerializeBody(BinaryWriter bw)
        {
            bw.Write(Constructor);
            bw.Write(Id);
			bw.Write(AccessHash);
			bw.Write(Date);
			bw.Write(AdminId);
			bw.Write(ParticipantId);
			ObjectUtils.SerializeObject(GAOrB, bw);
			bw.Write(KeyFingerprint);
			
        }
    }
}