using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using TgSharp.TL;

namespace TgSharp.TL.Help
{
    [TLObject(-2016381538)]
    public class TLCountriesList : TgSharp.TL.Help.TLAbsCountriesList
    {
        public override int Constructor
        {
            get
            {
                return -2016381538;
            }
        }

        
		public TLVector<Help.TLAbsCountry> Countries { get; set; }
		public int Hash { get; set; }

        public void ComputeFlags()
        {
            // do nothing
        }

        public override void DeserializeBody(BinaryReader br)
        {
            Countries = (TLVector<TLAbsCountry>)ObjectUtils.DeserializeObject(br);
			Hash = br.ReadInt32();
			
        }

        public override void SerializeBody(BinaryWriter bw)
        {
            bw.Write(Constructor);
            ObjectUtils.SerializeObject(Countries, bw);
			bw.Write(Hash);
			
        }
    }
}