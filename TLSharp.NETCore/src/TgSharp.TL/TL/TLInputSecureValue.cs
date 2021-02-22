using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using TgSharp.TL;

namespace TgSharp.TL
{
    [TLObject(-618540889)]
    public class TLInputSecureValue : TLAbsInputSecureValue
    {
        public override int Constructor
        {
            get
            {
                return -618540889;
            }
        }

        public int Flags { get; set; }
		public TLAbsSecureValueType Type { get; set; }
		public TLAbsSecureData Data { get; set; }
		public TLAbsInputSecureFile FrontSide { get; set; }
		public TLAbsInputSecureFile ReverseSide { get; set; }
		public TLAbsInputSecureFile Selfie { get; set; }
		public TLVector<TLAbsInputSecureFile> Translation { get; set; }
		public TLVector<TLAbsInputSecureFile> Files { get; set; }
		public TLAbsSecurePlainData PlainData { get; set; }

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
				FrontSide = (TLAbsInputSecureFile)ObjectUtils.DeserializeObject(br);
			if ((Flags & 0) != 0)
				ReverseSide = (TLAbsInputSecureFile)ObjectUtils.DeserializeObject(br);
			if ((Flags & 1) != 0)
				Selfie = (TLAbsInputSecureFile)ObjectUtils.DeserializeObject(br);
			if ((Flags & 4) != 0)
				Translation = (TLVector<TLAbsInputSecureFile>)ObjectUtils.DeserializeObject(br);
			if ((Flags & 6) != 0)
				Files = (TLVector<TLAbsInputSecureFile>)ObjectUtils.DeserializeObject(br);
			if ((Flags & 7) != 0)
				PlainData = (TLAbsSecurePlainData)ObjectUtils.DeserializeObject(br);
			
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
			
        }
    }
}