using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using TgSharp.TL;

namespace TgSharp.TL.Upload
{
    [TLObject(157948117)]
    public class TLFile : TgSharp.TL.Upload.TLAbsFile
    {
        public override int Constructor
        {
            get
            {
                return 157948117;
            }
        }

        
		public Storage.TLAbsFileType Type { get; set; }
		public int Mtime { get; set; }
		public byte[] Bytes { get; set; }

        public void ComputeFlags()
        {
            // do nothing
        }

        public override void DeserializeBody(BinaryReader br)
        {
            Type = (Storage.TLAbsFileType)ObjectUtils.DeserializeObject(br);
			Mtime = br.ReadInt32();
			Bytes = (byte[])ObjectUtils.DeserializeObject(br);
			
        }

        public override void SerializeBody(BinaryWriter bw)
        {
            bw.Write(Constructor);
            ObjectUtils.SerializeObject(Type, bw);
			bw.Write(Mtime);
			ObjectUtils.SerializeObject(Bytes, bw);
			
        }
    }
}