using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using TgSharp.TL;

namespace TgSharp.TL
{
    [TLObject(1949890536)]
    public class TLDialogFilter : TLAbsDialogFilter
    {
        public override int Constructor
        {
            get
            {
                return 1949890536;
            }
        }

        public int Flags { get; set; }
		public bool Contacts { get; set; }
		public bool NonContacts { get; set; }
		public bool Groups { get; set; }
		public bool Broadcasts { get; set; }
		public bool Bots { get; set; }
		public bool ExcludeMuted { get; set; }
		public bool ExcludeRead { get; set; }
		public bool ExcludeArchived { get; set; }
		public int Id { get; set; }
		public string Title { get; set; }
		public string Emoticon { get; set; }
		public TLVector<TLAbsInputPeer> PinnedPeers { get; set; }
		public TLVector<TLAbsInputPeer> IncludePeers { get; set; }
		public TLVector<TLAbsInputPeer> ExcludePeers { get; set; }

        public void ComputeFlags()
        {
            // do nothing
        }

        public override void DeserializeBody(BinaryReader br)
        {
            br.ReadInt32();if ((Flags & 2) != 0)
				Contacts = (bool)ObjectUtils.DeserializeObject(br);
			if ((Flags & 3) != 0)
				NonContacts = (bool)ObjectUtils.DeserializeObject(br);
			if ((Flags & 0) != 0)
				Groups = (bool)ObjectUtils.DeserializeObject(br);
			if ((Flags & 1) != 0)
				Broadcasts = (bool)ObjectUtils.DeserializeObject(br);
			if ((Flags & 6) != 0)
				Bots = (bool)ObjectUtils.DeserializeObject(br);
			if ((Flags & 9) != 0)
				ExcludeMuted = (bool)ObjectUtils.DeserializeObject(br);
			if ((Flags & 14) != 0)
				ExcludeRead = (bool)ObjectUtils.DeserializeObject(br);
			if ((Flags & 15) != 0)
				ExcludeArchived = (bool)ObjectUtils.DeserializeObject(br);
			Id = br.ReadInt32();
			Title = StringUtil.Deserialize(br);
			if ((Flags & 27) != 0)
				Emoticon = StringUtil.Deserialize(br);
			PinnedPeers = (TLVector<TLAbsInputPeer>)ObjectUtils.DeserializeObject(br);
			IncludePeers = (TLVector<TLAbsInputPeer>)ObjectUtils.DeserializeObject(br);
			ExcludePeers = (TLVector<TLAbsInputPeer>)ObjectUtils.DeserializeObject(br);
			
        }

        public override void SerializeBody(BinaryWriter bw)
        {
            bw.Write(Constructor);
            if ((Flags & 2) != 0)
	ObjectUtils.SerializeObject(Contacts, bw);
			if ((Flags & 3) != 0)
	ObjectUtils.SerializeObject(NonContacts, bw);
			if ((Flags & 0) != 0)
	ObjectUtils.SerializeObject(Groups, bw);
			if ((Flags & 1) != 0)
	ObjectUtils.SerializeObject(Broadcasts, bw);
			if ((Flags & 6) != 0)
	ObjectUtils.SerializeObject(Bots, bw);
			if ((Flags & 9) != 0)
	ObjectUtils.SerializeObject(ExcludeMuted, bw);
			if ((Flags & 14) != 0)
	ObjectUtils.SerializeObject(ExcludeRead, bw);
			if ((Flags & 15) != 0)
	ObjectUtils.SerializeObject(ExcludeArchived, bw);
			bw.Write(Id);
			StringUtil.Serialize(Title, bw);
			if ((Flags & 27) != 0)
	StringUtil.Serialize(Emoticon, bw);
			ObjectUtils.SerializeObject(PinnedPeers, bw);
			ObjectUtils.SerializeObject(IncludePeers, bw);
			ObjectUtils.SerializeObject(ExcludePeers, bw);
			
        }
    }
}