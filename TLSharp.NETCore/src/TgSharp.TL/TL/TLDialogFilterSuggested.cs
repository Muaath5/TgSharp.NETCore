using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using TgSharp.TL;

namespace TgSharp.TL
{
    [TLObject(2004110666)]
    public class TLDialogFilterSuggested : TLAbsDialogFilterSuggested
    {
        public override int Constructor
        {
            get
            {
                return 2004110666;
            }
        }

        
		public TLAbsDialogFilter Filter { get; set; }
		public string Description { get; set; }

        public void ComputeFlags()
        {
            // do nothing
        }

        public override void DeserializeBody(BinaryReader br)
        {
            Filter = (TLAbsDialogFilter)ObjectUtils.DeserializeObject(br);
			Description = StringUtil.Deserialize(br);
			
        }

        public override void SerializeBody(BinaryWriter bw)
        {
            bw.Write(Constructor);
            ObjectUtils.SerializeObject(Filter, bw);
			StringUtil.Serialize(Description, bw);
			
        }
    }
}