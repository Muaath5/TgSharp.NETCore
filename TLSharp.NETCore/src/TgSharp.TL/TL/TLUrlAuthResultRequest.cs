using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using TgSharp.TL;

namespace TgSharp.TL
{
    [TLObject(-1831650802)]
    public class TLUrlAuthResultRequest : TLAbsUrlAuthResult
    {
        public override int Constructor
        {
            get
            {
                return -1831650802;
            }
        }

        public int Flags { get; set; }
		public bool RequestWriteAccess { get; set; }
		public TLAbsUser Bot { get; set; }
		public string Domain { get; set; }

        public void ComputeFlags()
        {
            // do nothing
        }

        public override void DeserializeBody(BinaryReader br)
        {
            br.ReadInt32();if ((Flags & 2) != 0)
				RequestWriteAccess = (bool)ObjectUtils.DeserializeObject(br);
			Bot = (TLAbsUser)ObjectUtils.DeserializeObject(br);
			Domain = StringUtil.Deserialize(br);
			
        }

        public override void SerializeBody(BinaryWriter bw)
        {
            bw.Write(Constructor);
            if ((Flags & 2) != 0)
	ObjectUtils.SerializeObject(RequestWriteAccess, bw);
			ObjectUtils.SerializeObject(Bot, bw);
			StringUtil.Serialize(Domain, bw);
			
        }
    }
}