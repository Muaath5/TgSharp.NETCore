using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using TgSharp.TL;

namespace TgSharp.TL
{
    [TLObject(-58224696)]
    public class TLPhoneCallProtocol : TLAbsPhoneCallProtocol
    {
        public override int Constructor
        {
            get
            {
                return -58224696;
            }
        }

        public int Flags { get; set; }
		public bool UdpP2p { get; set; }
		public bool UdpReflector { get; set; }
		public int MinLayer { get; set; }
		public int MaxLayer { get; set; }
		public TLVector<string> LibraryVersions { get; set; }

        public void ComputeFlags()
        {
            // do nothing
        }

        public override void DeserializeBody(BinaryReader br)
        {
            br.ReadInt32();if ((Flags & 2) != 0)
				UdpP2p = (bool)ObjectUtils.DeserializeObject(br);
			if ((Flags & 3) != 0)
				UdpReflector = (bool)ObjectUtils.DeserializeObject(br);
			MinLayer = br.ReadInt32();
			MaxLayer = br.ReadInt32();
			LibraryVersions = (TLVector<string>)ObjectUtils.DeserializeObject(br);
			
        }

        public override void SerializeBody(BinaryWriter bw)
        {
            bw.Write(Constructor);
            if ((Flags & 2) != 0)
	ObjectUtils.SerializeObject(UdpP2p, bw);
			if ((Flags & 3) != 0)
	ObjectUtils.SerializeObject(UdpReflector, bw);
			bw.Write(MinLayer);
			bw.Write(MaxLayer);
			ObjectUtils.SerializeObject(LibraryVersions, bw);
			
        }
    }
}