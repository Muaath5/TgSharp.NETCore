using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using TgSharp.TL;

namespace TgSharp.TL.Payments
{
    [TLObject(-74456004)]
    public class TLSavedInfo : TLObject
    {
        public override int Constructor
        {
            get
            {
                return -74456004;
            }
        }

        public int Flags { get; set; }
        public bool HasSavedCredentials { get; set; }
        public TLPaymentRequestedInfo SavedInfo { get; set; }

        public void ComputeFlags()
        {
            // do nothing
        }

        public override void DeserializeBody(BinaryReader br)
        {
            Flags = br.ReadInt32();
            HasSavedCredentials = (Flags & 2) != 0;
            if ((Flags & 1) != 0)
                SavedInfo = (TLPaymentRequestedInfo)ObjectUtils.DeserializeObject(br);
            else
                SavedInfo = null;

        }

        public override void SerializeBody(BinaryWriter bw)
        {
            bw.Write(Constructor);
            bw.Write(Flags);
            if ((Flags & 1) != 0)
                ObjectUtils.SerializeObject(SavedInfo, bw);
        }
    }
}
