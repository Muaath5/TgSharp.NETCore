using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using TgSharp.TL;

namespace TgSharp.TL.Account
{
    [TLObject(2137482273)]
    public class TLThemes : TgSharp.TL.Account.TLAbsThemes
    {
        public override int Constructor
        {
            get
            {
                return 2137482273;
            }
        }

        
		public int Hash { get; set; }
		public TLVector<TLAbsTheme> Themes { get; set; }

        public void ComputeFlags()
        {
            // do nothing
        }

        public override void DeserializeBody(BinaryReader br)
        {
            Hash = br.ReadInt32();
			Themes = (TLVector<TLAbsTheme>)ObjectUtils.DeserializeObject(br);
			
        }

        public override void SerializeBody(BinaryWriter bw)
        {
            bw.Write(Constructor);
            bw.Write(Hash);
			ObjectUtils.SerializeObject(Themes, bw);
			
        }
    }
}