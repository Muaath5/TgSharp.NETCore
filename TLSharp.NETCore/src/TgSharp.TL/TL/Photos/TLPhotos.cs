using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using TgSharp.TL;

namespace TgSharp.TL.Photos
{
    [TLObject(-1916114267)]
    public class TLPhotos : TgSharp.TL.Photos.TLAbsPhotos
    {
        public override int Constructor
        {
            get
            {
                return -1916114267;
            }
        }

        
		public TLVector<TLAbsPhoto> Photos { get; set; }
		public TLVector<TLAbsUser> Users { get; set; }

        public void ComputeFlags()
        {
            // do nothing
        }

        public override void DeserializeBody(BinaryReader br)
        {
            Photos = (TLVector<TLAbsPhoto>)ObjectUtils.DeserializeObject(br);
			Users = (TLVector<TLAbsUser>)ObjectUtils.DeserializeObject(br);
			
        }

        public override void SerializeBody(BinaryWriter bw)
        {
            bw.Write(Constructor);
            ObjectUtils.SerializeObject(Photos, bw);
			ObjectUtils.SerializeObject(Users, bw);
			
        }
    }
}