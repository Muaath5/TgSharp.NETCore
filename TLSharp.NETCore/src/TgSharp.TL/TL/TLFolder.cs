using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using TgSharp.TL;

namespace TgSharp.TL
{
    [TLObject(-11252123)]
    public class TLFolder : TLAbsFolder
    {
        public override int Constructor
        {
            get
            {
                return -11252123;
            }
        }

        public int Flags { get; set; }
		public bool AutofillNewBroadcasts { get; set; }
		public bool AutofillPublicGroups { get; set; }
		public bool AutofillNewCorrespondents { get; set; }
		public int Id { get; set; }
		public string Title { get; set; }
		public TLAbsChatPhoto Photo { get; set; }

        public void ComputeFlags()
        {
            // do nothing
        }

        public override void DeserializeBody(BinaryReader br)
        {
            br.ReadInt32();if ((Flags & 2) != 0)
				AutofillNewBroadcasts = (bool)ObjectUtils.DeserializeObject(br);
			if ((Flags & 3) != 0)
				AutofillPublicGroups = (bool)ObjectUtils.DeserializeObject(br);
			if ((Flags & 0) != 0)
				AutofillNewCorrespondents = (bool)ObjectUtils.DeserializeObject(br);
			Id = br.ReadInt32();
			Title = StringUtil.Deserialize(br);
			if ((Flags & 1) != 0)
				Photo = (TLAbsChatPhoto)ObjectUtils.DeserializeObject(br);
			
        }

        public override void SerializeBody(BinaryWriter bw)
        {
            bw.Write(Constructor);
            if ((Flags & 2) != 0)
	ObjectUtils.SerializeObject(AutofillNewBroadcasts, bw);
			if ((Flags & 3) != 0)
	ObjectUtils.SerializeObject(AutofillPublicGroups, bw);
			if ((Flags & 0) != 0)
	ObjectUtils.SerializeObject(AutofillNewCorrespondents, bw);
			bw.Write(Id);
			StringUtil.Serialize(Title, bw);
			if ((Flags & 1) != 0)
	ObjectUtils.SerializeObject(Photo, bw);
			
        }
    }
}