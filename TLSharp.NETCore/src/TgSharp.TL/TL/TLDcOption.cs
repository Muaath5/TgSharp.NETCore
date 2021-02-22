using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using TgSharp.TL;

namespace TgSharp.TL
{
    [TLObject(414687501)]
    public class TLDcOption : TLAbsDcOption
    {
        public override int Constructor
        {
            get
            {
                return 414687501;
            }
        }

        public int Flags { get; set; }
		public bool Ipv6 { get; set; }
		public bool MediaOnly { get; set; }
		public bool TcpoOnly { get; set; }
		public bool Cdn { get; set; }
		public bool Static { get; set; }
		public int Id { get; set; }
		public string IpAddress { get; set; }
		public int Port { get; set; }
		public byte[] Secret { get; set; }

        public void ComputeFlags()
        {
            // do nothing
        }

        public override void DeserializeBody(BinaryReader br)
        {
            br.ReadInt32();if ((Flags & 2) != 0)
				Ipv6 = (bool)ObjectUtils.DeserializeObject(br);
			if ((Flags & 3) != 0)
				MediaOnly = (bool)ObjectUtils.DeserializeObject(br);
			if ((Flags & 0) != 0)
				TcpoOnly = (bool)ObjectUtils.DeserializeObject(br);
			if ((Flags & 1) != 0)
				Cdn = (bool)ObjectUtils.DeserializeObject(br);
			if ((Flags & 6) != 0)
				Static = (bool)ObjectUtils.DeserializeObject(br);
			Id = br.ReadInt32();
			IpAddress = StringUtil.Deserialize(br);
			Port = br.ReadInt32();
			if ((Flags & 8) != 0)
				Secret = (byte[])ObjectUtils.DeserializeObject(br);
			
        }

        public override void SerializeBody(BinaryWriter bw)
        {
            bw.Write(Constructor);
            if ((Flags & 2) != 0)
	ObjectUtils.SerializeObject(Ipv6, bw);
			if ((Flags & 3) != 0)
	ObjectUtils.SerializeObject(MediaOnly, bw);
			if ((Flags & 0) != 0)
	ObjectUtils.SerializeObject(TcpoOnly, bw);
			if ((Flags & 1) != 0)
	ObjectUtils.SerializeObject(Cdn, bw);
			if ((Flags & 6) != 0)
	ObjectUtils.SerializeObject(Static, bw);
			bw.Write(Id);
			StringUtil.Serialize(IpAddress, bw);
			bw.Write(Port);
			if ((Flags & 8) != 0)
	ObjectUtils.SerializeObject(Secret, bw);
			
        }
    }
}