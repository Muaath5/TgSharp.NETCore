using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using TgSharp.TL;

namespace TgSharp.TL
{
    [TLObject(995769920)]
    public class TLChannelAdminLogEvent : TLObject
    {
        public override int Constructor
        {
            get
            {
                return 995769920;
            }
        }

        public long Id { get; set; }
        public int Date { get; set; }
        public int UserId { get; set; }
        public TLAbsChannelAdminLogEventAction Action { get; set; }

        public void ComputeFlags()
        {
            // do nothing
        }

        public override void DeserializeBody(BinaryReader br)
        {
            Id = br.ReadInt64();
            Date = br.ReadInt32();
            UserId = br.ReadInt32();
            Action = (TLAbsChannelAdminLogEventAction)ObjectUtils.DeserializeObject(br);
        }

        public override void SerializeBody(BinaryWriter bw)
        {
            bw.Write(Constructor);
            bw.Write(Id);
            bw.Write(Date);
            bw.Write(UserId);
            ObjectUtils.SerializeObject(Action, bw);
        }
    }
}
