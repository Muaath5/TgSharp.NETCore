using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using TgSharp.TL;

namespace TgSharp.TL.Account
{
    [TLObject(1995661875)]
    public class TLRequestSaveAutoDownloadSettings : TLMethod
    {
        public override int Constructor
        {
            get
            {
                return 1995661875;
            }
        }

        public int Flags { get; set; }
		public bool Low { get; set; }
		public bool High { get; set; }
		public TLAbsAutoDownloadSettings Settings { get; set; }
		public TLAbsBool Response { get; set; }

        public void ComputeFlags()
        {
            // do nothing
        }

        public override void DeserializeBody(BinaryReader br)
        {
            br.ReadInt32();
			if ((Flags & 2) != 0)
				Low = (bool)ObjectUtils.DeserializeObject(br);
			if ((Flags & 3) != 0)
				High = (bool)ObjectUtils.DeserializeObject(br);
			Settings = (TLAbsAutoDownloadSettings)ObjectUtils.DeserializeObject(br);
			
        }

        public override void SerializeBody(BinaryWriter bw)
        {
            bw.Write(Constructor);
            
			if ((Flags & 2) != 0)
	ObjectUtils.SerializeObject(Low, bw);
			if ((Flags & 3) != 0)
	ObjectUtils.SerializeObject(High, bw);
			ObjectUtils.SerializeObject(Settings, bw);
			
        }

        public override void DeserializeResponse(BinaryReader br)
        {
            Response = (TLAbsBool)ObjectUtils.DeserializeObject(br);
        }
    }
}