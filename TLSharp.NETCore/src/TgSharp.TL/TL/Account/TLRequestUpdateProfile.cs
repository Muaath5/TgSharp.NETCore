using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using TgSharp.TL;

namespace TgSharp.TL.Account
{
    [TLObject(2018596725)]
    public class TLRequestUpdateProfile : TLMethod
    {
        public override int Constructor
        {
            get
            {
                return 2018596725;
            }
        }

        public int Flags { get; set; }
		public string FirstName { get; set; }
		public string LastName { get; set; }
		public string About { get; set; }
		public TLAbsUser Response { get; set; }

        public void ComputeFlags()
        {
            // do nothing
        }

        public override void DeserializeBody(BinaryReader br)
        {
            br.ReadInt32();
			if ((Flags & 2) != 0)
				FirstName = StringUtil.Deserialize(br);
			if ((Flags & 3) != 0)
				LastName = StringUtil.Deserialize(br);
			if ((Flags & 0) != 0)
				About = StringUtil.Deserialize(br);
			
        }

        public override void SerializeBody(BinaryWriter bw)
        {
            bw.Write(Constructor);
            
			if ((Flags & 2) != 0)
	StringUtil.Serialize(FirstName, bw);
			if ((Flags & 3) != 0)
	StringUtil.Serialize(LastName, bw);
			if ((Flags & 0) != 0)
	StringUtil.Serialize(About, bw);
			
        }

        public override void DeserializeResponse(BinaryReader br)
        {
            Response = (TLAbsUser)ObjectUtils.DeserializeObject(br);
        }
    }
}