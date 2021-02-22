using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using TgSharp.TL;

namespace TgSharp.TL.Channels
{
    [TLObject(-122669393)]
    public class TLRequestGetAdminedPublicChannels : TLMethod
    {
        public override int Constructor
        {
            get
            {
                return -122669393;
            }
        }

        public int Flags { get; set; }
		public bool ByLocation { get; set; }
		public bool CheckLimit { get; set; }
		public Messages.TLAbsChats Response { get; set; }

        public void ComputeFlags()
        {
            // do nothing
        }

        public override void DeserializeBody(BinaryReader br)
        {
            br.ReadInt32();
			if ((Flags & 2) != 0)
				ByLocation = (bool)ObjectUtils.DeserializeObject(br);
			if ((Flags & 3) != 0)
				CheckLimit = (bool)ObjectUtils.DeserializeObject(br);
			
        }

        public override void SerializeBody(BinaryWriter bw)
        {
            bw.Write(Constructor);
            
			if ((Flags & 2) != 0)
	ObjectUtils.SerializeObject(ByLocation, bw);
			if ((Flags & 3) != 0)
	ObjectUtils.SerializeObject(CheckLimit, bw);
			
        }

        public override void DeserializeResponse(BinaryReader br)
        {
            Response = (Messages.TLAbsChats)ObjectUtils.DeserializeObject(br);
        }
    }
}