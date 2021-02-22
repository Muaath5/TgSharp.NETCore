using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using TgSharp.TL;

namespace TgSharp.TL.Folders
{
    [TLObject(1749536939)]
    public class TLRequestEditPeerFolders : TLMethod
    {
        public override int Constructor
        {
            get
            {
                return 1749536939;
            }
        }

        
		public TLVector<TLAbsInputFolderPeer> FolderPeers { get; set; }
		public TLAbsUpdates Response { get; set; }

        public void ComputeFlags()
        {
            // do nothing
        }

        public override void DeserializeBody(BinaryReader br)
        {
            FolderPeers = (TLVector<TLAbsInputFolderPeer>)ObjectUtils.DeserializeObject(br);
			
        }

        public override void SerializeBody(BinaryWriter bw)
        {
            bw.Write(Constructor);
            
			ObjectUtils.SerializeObject(FolderPeers, bw);
			
        }

        public override void DeserializeResponse(BinaryReader br)
        {
            Response = (TLAbsUpdates)ObjectUtils.DeserializeObject(br);
        }
    }
}