using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using TgSharp.TL;

namespace TgSharp.TL
{
    [TLObject(-186607933)]
    public class TLInputMediaInvoice : TLAbsInputMedia
    {
        public override int Constructor
        {
            get
            {
                return -186607933;
            }
        }

        public int Flags { get; set; }
		public string Title { get; set; }
		public string Description { get; set; }
		public TLAbsInputWebDocument Photo { get; set; }
		public TLAbsInvoice Invoice { get; set; }
		public byte[] Payload { get; set; }
		public string Provider { get; set; }
		public TLAbsDataJSON ProviderData { get; set; }
		public string StartParam { get; set; }

        public void ComputeFlags()
        {
            // do nothing
        }

        public override void DeserializeBody(BinaryReader br)
        {
            br.ReadInt32();Title = StringUtil.Deserialize(br);
			Description = StringUtil.Deserialize(br);
			if ((Flags & 2) != 0)
				Photo = (TLAbsInputWebDocument)ObjectUtils.DeserializeObject(br);
			Invoice = (TLAbsInvoice)ObjectUtils.DeserializeObject(br);
			Payload = (byte[])ObjectUtils.DeserializeObject(br);
			Provider = StringUtil.Deserialize(br);
			ProviderData = (TLAbsDataJSON)ObjectUtils.DeserializeObject(br);
			StartParam = StringUtil.Deserialize(br);
			
        }

        public override void SerializeBody(BinaryWriter bw)
        {
            bw.Write(Constructor);
            StringUtil.Serialize(Title, bw);
			StringUtil.Serialize(Description, bw);
			if ((Flags & 2) != 0)
	ObjectUtils.SerializeObject(Photo, bw);
			ObjectUtils.SerializeObject(Invoice, bw);
			ObjectUtils.SerializeObject(Payload, bw);
			StringUtil.Serialize(Provider, bw);
			ObjectUtils.SerializeObject(ProviderData, bw);
			StringUtil.Serialize(StartParam, bw);
			
        }
    }
}