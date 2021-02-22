using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using TgSharp.TL;

namespace TgSharp.TL.Help
{
    [TLObject(-1600596305)]
    public class TLPassportConfig : TgSharp.TL.Help.TLAbsPassportConfig
    {
        public override int Constructor
        {
            get
            {
                return -1600596305;
            }
        }

        
		public int Hash { get; set; }
		public TLAbsDataJSON CountriesLangs { get; set; }

        public void ComputeFlags()
        {
            // do nothing
        }

        public override void DeserializeBody(BinaryReader br)
        {
            Hash = br.ReadInt32();
			CountriesLangs = (TLAbsDataJSON)ObjectUtils.DeserializeObject(br);
			
        }

        public override void SerializeBody(BinaryWriter bw)
        {
            bw.Write(Constructor);
            bw.Write(Hash);
			ObjectUtils.SerializeObject(CountriesLangs, bw);
			
        }
    }
}