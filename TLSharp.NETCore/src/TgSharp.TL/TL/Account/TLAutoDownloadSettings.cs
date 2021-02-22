using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using TgSharp.TL;

namespace TgSharp.TL.Account
{
    [TLObject(1674235686)]
    public class TLAutoDownloadSettings : TgSharp.TL.Account.TLAbsAutoDownloadSettings
    {
        public override int Constructor
        {
            get
            {
                return 1674235686;
            }
        }

        
		public TLAbsAutoDownloadSettings Low { get; set; }
		public TLAbsAutoDownloadSettings Medium { get; set; }
		public TLAbsAutoDownloadSettings High { get; set; }

        public void ComputeFlags()
        {
            // do nothing
        }

        public override void DeserializeBody(BinaryReader br)
        {
            Low = (TLAbsAutoDownloadSettings)ObjectUtils.DeserializeObject(br);
			Medium = (TLAbsAutoDownloadSettings)ObjectUtils.DeserializeObject(br);
			High = (TLAbsAutoDownloadSettings)ObjectUtils.DeserializeObject(br);
			
        }

        public override void SerializeBody(BinaryWriter bw)
        {
            bw.Write(Constructor);
            ObjectUtils.SerializeObject(Low, bw);
			ObjectUtils.SerializeObject(Medium, bw);
			ObjectUtils.SerializeObject(High, bw);
			
        }
    }
}