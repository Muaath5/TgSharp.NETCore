using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using TgSharp.TL;

namespace TgSharp.TL
{
    [TLObject(-1160743548)]
    public class TLInputDocumentFileLocation : TLAbsInputFileLocation
    {
        public override int Constructor
        {
            get
            {
                return -1160743548;
            }
        }

        
		public long Id { get; set; }
		public long AccessHash { get; set; }
		public byte[] FileReference { get; set; }
		public string ThumbSize { get; set; }

        public void ComputeFlags()
        {
            // do nothing
        }

        public override void DeserializeBody(BinaryReader br)
        {
            Id = br.ReadInt64();
			AccessHash = br.ReadInt64();
			FileReference = (byte[])ObjectUtils.DeserializeObject(br);
			ThumbSize = StringUtil.Deserialize(br);
			
        }

        public override void SerializeBody(BinaryWriter bw)
        {
            bw.Write(Constructor);
            bw.Write(Id);
			bw.Write(AccessHash);
			ObjectUtils.SerializeObject(FileReference, bw);
			StringUtil.Serialize(ThumbSize, bw);
			
        }
    }
}