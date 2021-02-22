using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using TgSharp.TL;

namespace TgSharp.TL.Contacts
{
    [TLObject(746589157)]
    public class TLRequestImportContacts : TLMethod
    {
        public override int Constructor
        {
            get
            {
                return 746589157;
            }
        }

        
		public TLVector<TLAbsInputContact> Contacts { get; set; }
		public Contacts.TLAbsImportedContacts Response { get; set; }

        public void ComputeFlags()
        {
            // do nothing
        }

        public override void DeserializeBody(BinaryReader br)
        {
            Contacts = (TLVector<TLAbsInputContact>)ObjectUtils.DeserializeObject(br);
			
        }

        public override void SerializeBody(BinaryWriter bw)
        {
            bw.Write(Constructor);
            
			ObjectUtils.SerializeObject(Contacts, bw);
			
        }

        public override void DeserializeResponse(BinaryReader br)
        {
            Response = (Contacts.TLAbsImportedContacts)ObjectUtils.DeserializeObject(br);
        }
    }
}