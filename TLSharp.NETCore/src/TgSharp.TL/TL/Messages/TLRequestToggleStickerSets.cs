using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using TgSharp.TL;

namespace TgSharp.TL.Messages
{
    [TLObject(-1257951254)]
    public class TLRequestToggleStickerSets : TLMethod
    {
        public override int Constructor
        {
            get
            {
                return -1257951254;
            }
        }

        public int Flags { get; set; }
		public bool Uninstall { get; set; }
		public bool Archive { get; set; }
		public bool Unarchive { get; set; }
		public TLVector<TLAbsInputStickerSet> Stickersets { get; set; }
		public TLAbsBool Response { get; set; }

        public void ComputeFlags()
        {
            // do nothing
        }

        public override void DeserializeBody(BinaryReader br)
        {
            br.ReadInt32();
			if ((Flags & 2) != 0)
				Uninstall = (bool)ObjectUtils.DeserializeObject(br);
			if ((Flags & 3) != 0)
				Archive = (bool)ObjectUtils.DeserializeObject(br);
			if ((Flags & 0) != 0)
				Unarchive = (bool)ObjectUtils.DeserializeObject(br);
			Stickersets = (TLVector<TLAbsInputStickerSet>)ObjectUtils.DeserializeObject(br);
			
        }

        public override void SerializeBody(BinaryWriter bw)
        {
            bw.Write(Constructor);
            
			if ((Flags & 2) != 0)
	ObjectUtils.SerializeObject(Uninstall, bw);
			if ((Flags & 3) != 0)
	ObjectUtils.SerializeObject(Archive, bw);
			if ((Flags & 0) != 0)
	ObjectUtils.SerializeObject(Unarchive, bw);
			ObjectUtils.SerializeObject(Stickersets, bw);
			
        }

        public override void DeserializeResponse(BinaryReader br)
        {
            Response = (TLAbsBool)ObjectUtils.DeserializeObject(br);
        }
    }
}