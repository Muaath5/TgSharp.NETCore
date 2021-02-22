using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using TgSharp.TL;

namespace TgSharp.TL
{
    [TLObject(-1043505495)]
    public class TLRequestInitConnection<X> : TLMethod
    {
        public override int Constructor
        {
            get
            {
                return -1043505495;
            }
        }

        public int Flags { get; set; }
		public int ApiId { get; set; }
		public string DeviceModel { get; set; }
		public string SystemVersion { get; set; }
		public string AppVersion { get; set; }
		public string SystemLangCode { get; set; }
		public string LangPack { get; set; }
		public string LangCode { get; set; }
		public TLAbsInputClientProxy Proxy { get; set; }
		public TLAbsJSONValue Params { get; set; }
		public X Query { get; set; }
		public X Response { get; set; }

        public void ComputeFlags()
        {
            // do nothing
        }

        public override void DeserializeBody(BinaryReader br)
        {
            br.ReadInt32();
			ApiId = br.ReadInt32();
			DeviceModel = StringUtil.Deserialize(br);
			SystemVersion = StringUtil.Deserialize(br);
			AppVersion = StringUtil.Deserialize(br);
			SystemLangCode = StringUtil.Deserialize(br);
			LangPack = StringUtil.Deserialize(br);
			LangCode = StringUtil.Deserialize(br);
			if ((Flags & 2) != 0)
				Proxy = (TLAbsInputClientProxy)ObjectUtils.DeserializeObject(br);
			if ((Flags & 3) != 0)
				Params = (TLAbsJSONValue)ObjectUtils.DeserializeObject(br);
			Query = (X)ObjectUtils.DeserializeObject(br);
			
        }

        public override void SerializeBody(BinaryWriter bw)
        {
            bw.Write(Constructor);
            
			bw.Write(ApiId);
			StringUtil.Serialize(DeviceModel, bw);
			StringUtil.Serialize(SystemVersion, bw);
			StringUtil.Serialize(AppVersion, bw);
			StringUtil.Serialize(SystemLangCode, bw);
			StringUtil.Serialize(LangPack, bw);
			StringUtil.Serialize(LangCode, bw);
			if ((Flags & 2) != 0)
	ObjectUtils.SerializeObject(Proxy, bw);
			if ((Flags & 3) != 0)
	ObjectUtils.SerializeObject(Params, bw);
			ObjectUtils.SerializeObject(Query, bw);
			
        }

        public override void DeserializeResponse(BinaryReader br)
        {
            Response = (X)ObjectUtils.DeserializeObject(br);
        }
    }
}