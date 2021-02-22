using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using TgSharp.TL;

namespace TgSharp.TL
{
    [TLObject(-1791935732)]
    public class TLUpdateUserPhoto : TLAbsUpdate
    {
        public override int Constructor
        {
            get
            {
                return -1791935732;
            }
        }

        
		public int UserId { get; set; }
		public int Date { get; set; }
		public TLAbsUserProfilePhoto Photo { get; set; }
		public TLAbsBool Previous { get; set; }

        public void ComputeFlags()
        {
            // do nothing
        }

        public override void DeserializeBody(BinaryReader br)
        {
            UserId = br.ReadInt32();
			Date = br.ReadInt32();
			Photo = (TLAbsUserProfilePhoto)ObjectUtils.DeserializeObject(br);
			Previous = (TLAbsBool)ObjectUtils.DeserializeObject(br);
			
        }

        public override void SerializeBody(BinaryWriter bw)
        {
            bw.Write(Constructor);
            bw.Write(UserId);
			bw.Write(Date);
			ObjectUtils.SerializeObject(Photo, bw);
			ObjectUtils.SerializeObject(Previous, bw);
			
        }
    }
}