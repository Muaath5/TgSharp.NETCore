using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using TgSharp.TL;

namespace TgSharp.TL
{
    [TLObject(-1715350371)]
    public class TLJsonObject : TLAbsJSONValue
    {
        public override int Constructor
        {
            get
            {
                return -1715350371;
            }
        }

        
		public TLVector<TLAbsJSONObjectValue> Value { get; set; }

        public void ComputeFlags()
        {
            // do nothing
        }

        public override void DeserializeBody(BinaryReader br)
        {
            Value = (TLVector<TLAbsJSONObjectValue>)ObjectUtils.DeserializeObject(br);
			
        }

        public override void SerializeBody(BinaryWriter bw)
        {
            bw.Write(Constructor);
            ObjectUtils.SerializeObject(Value, bw);
			
        }
    }
}