using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using TgSharp.TL;

namespace TgSharp.TL
{
    [TLObject(-668906175)]
    public class TLPhotoPathSize : TLAbsPhotoSize
    {
        public override int Constructor
        {
            get
            {
                return -668906175;
            }
        }

        
		public string Type { get; set; }
		public byte[] Bytes { get; set; }

        public void ComputeFlags()
        {
            // do nothing
        }

        public override void DeserializeBody(BinaryReader br)
        {
            Type = StringUtil.Deserialize(br);
			Bytes = (byte[])ObjectUtils.DeserializeObject(br);
			
        }

        public override void SerializeBody(BinaryWriter bw)
        {
            bw.Write(Constructor);
            StringUtil.Serialize(Type, bw);
			ObjectUtils.SerializeObject(Bytes, bw);
			
        }
    }
}