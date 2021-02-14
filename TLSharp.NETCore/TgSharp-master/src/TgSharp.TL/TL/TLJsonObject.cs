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

        // manual edit: TLJSONObjectValue->TLJsonObjectValue
        public TLVector<TLJsonObjectValue> Value { get; set; }

        public void ComputeFlags()
        {
            // do nothing
        }

        public override void DeserializeBody(BinaryReader br)
        {
            // manual edit: TLJSONObjectValue->TLJsonObjectValue
            Value = (TLVector<TLJsonObjectValue>)ObjectUtils.DeserializeVector<TLJsonObjectValue> (br);
        }

        public override void SerializeBody(BinaryWriter bw)
        {
            bw.Write(Constructor);
            ObjectUtils.SerializeObject(Value, bw);
        }
    }
}
