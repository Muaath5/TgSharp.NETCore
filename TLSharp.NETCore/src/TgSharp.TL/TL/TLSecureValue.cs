using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using TgSharp.TL;

namespace TgSharp.TL
{
    [TLObject(411017418)]
    public class TLSecureValue : TLAbsSecureValue
    {
        public override int Constructor
        {
            get
            {
                return 411017418;
            }
        }

        public int Flags { get; set; }
		public TLAbsSecureValueType Type { get; set; }
		public TLAbsSecureData Data { get; set; }
		public TLAbsSecureFile FrontSide { get; set; }
		public TLAbsSecureFile ReverseSide { get; set; }
		public TLAbsSecureFile Selfie { get; set; }
		public TLVector<TLAbsSecureFile> Translation { get; set; }
		public TLVector<TLAbsSecureFile> Files { get; set; }
		public TLAbsSecurePlainData PlainData { get; set; }
		public byte[] Hash { get; set; }

        public void ComputeFlags()
        {
            // do nothing
        }

        public override void DeserializeBody(BinaryReader br)
        {
            br.ReadInt32();Type = (TLAbsSecureValueType)ObjectUtils.DeserializeObject(br);
			if ((Flags & 2) != 0)
				Data = (TLAbsSecureData)ObjectUtils.DeserializeObject(br);
			if ((Flags & 3) != 0)
				FrontSide = (TLAbsSecureFile)ObjectUtils.DeserializeObject(br);
			if ((Flags & 0) != 0)
				ReverseSide = (TLAbsSecureFile)ObjectUtils.DeserializeObject(br);
			if ((Flags & 1) != 0)
				Selfie = (TLAbsSecureFile)ObjectUtils.DeserializeObject(br);
			if ((Flags & 4) != 0)
				Translation = (TLVector<TLAbsSecureFile>)ObjectUtils.DeserializeObject(br);
			if ((Flags & 6) != 0)
				Files = (TLVector<TLAbsSecureFile>)ObjectUtils.DeserializeObject(br);
			if ((Flags & 7) != 0)
				PlainData = (TLAbsSecurePlainData)ObjectUtils.DeserializeObject(br);
			Hash = (byte[])ObjectUtils.DeserializeObject(br);
			
        }

        public override void SerializeBody(BinaryWriter bw)
        {
            bw.Write(Constructor);
            ObjectUtils.SerializeObject(Type, bw);
			if ((Flags & 2) != 0)
	ObjectUtils.SerializeObject(Data, bw);
			if ((Flags & 3) != 0)
	ObjectUtils.SerializeObject(FrontSide, bw);
			if ((Flags & 0) != 0)
	ObjectUtils.SerializeObject(ReverseSide, bw);
			if ((Flags & 1) != 0)
	ObjectUtils.SerializeObject(Selfie, bw);
			if ((Flags & 4) != 0)
	ObjectUtils.SerializeObject(Translation, bw);
			if ((Flags & 6) != 0)
	ObjectUtils.SerializeObject(Files, bw);
			if ((Flags & 7) != 0)
	ObjectUtils.SerializeObject(PlainData, bw);
			ObjectUtils.SerializeObject(Hash, bw);
			
        }
    }
}