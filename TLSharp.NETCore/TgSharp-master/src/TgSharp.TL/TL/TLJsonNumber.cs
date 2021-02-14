using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using TgSharp.TL;

namespace TgSharp.TL
{
    [TLObject(736157604)]
    public class TLJsonNumber : TLAbsJSONValue
    {
        public override int Constructor
        {
            get
            {
                return 736157604;
            }
        }

        public double Value { get; set; }

        public void ComputeFlags()
        {
            // do nothing
        }

        public override void DeserializeBody(BinaryReader br)
        {
            Value = br.ReadDouble();
        }

        public override void SerializeBody(BinaryWriter bw)
        {
            bw.Write(Constructor);
            bw.Write(Value);
        }
    }
}
