using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using TgSharp.TL;

namespace TgSharp.TL
{
    [TLObject(1667228533)]
    public class TLPhoneConnectionWebrtc : TLAbsPhoneConnection
    {
        public override int Constructor
        {
            get
            {
                return 1667228533;
            }
        }

        public int Flags { get; set; }
		public bool Turn { get; set; }
		public bool Stun { get; set; }
		public long Id { get; set; }
		public string Ip { get; set; }
		public string Ipv6 { get; set; }
		public int Port { get; set; }
		public string Username { get; set; }
		public string Password { get; set; }

        public void ComputeFlags()
        {
            // do nothing
        }

        public override void DeserializeBody(BinaryReader br)
        {
            br.ReadInt32();if ((Flags & 2) != 0)
				Turn = (bool)ObjectUtils.DeserializeObject(br);
			if ((Flags & 3) != 0)
				Stun = (bool)ObjectUtils.DeserializeObject(br);
			Id = br.ReadInt64();
			Ip = StringUtil.Deserialize(br);
			Ipv6 = StringUtil.Deserialize(br);
			Port = br.ReadInt32();
			Username = StringUtil.Deserialize(br);
			Password = StringUtil.Deserialize(br);
			
        }

        public override void SerializeBody(BinaryWriter bw)
        {
            bw.Write(Constructor);
            if ((Flags & 2) != 0)
	ObjectUtils.SerializeObject(Turn, bw);
			if ((Flags & 3) != 0)
	ObjectUtils.SerializeObject(Stun, bw);
			bw.Write(Id);
			StringUtil.Serialize(Ip, bw);
			StringUtil.Serialize(Ipv6, bw);
			bw.Write(Port);
			StringUtil.Serialize(Username, bw);
			StringUtil.Serialize(Password, bw);
			
        }
    }
}