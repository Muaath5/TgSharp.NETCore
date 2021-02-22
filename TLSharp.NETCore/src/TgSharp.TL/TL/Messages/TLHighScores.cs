using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using TgSharp.TL;

namespace TgSharp.TL.Messages
{
    [TLObject(-1707344487)]
    public class TLHighScores : TgSharp.TL.Messages.TLAbsHighScores
    {
        public override int Constructor
        {
            get
            {
                return -1707344487;
            }
        }

        
		public TLVector<TLAbsHighScore> Scores { get; set; }
		public TLVector<TLAbsUser> Users { get; set; }

        public void ComputeFlags()
        {
            // do nothing
        }

        public override void DeserializeBody(BinaryReader br)
        {
            Scores = (TLVector<TLAbsHighScore>)ObjectUtils.DeserializeObject(br);
			Users = (TLVector<TLAbsUser>)ObjectUtils.DeserializeObject(br);
			
        }

        public override void SerializeBody(BinaryWriter bw)
        {
            bw.Write(Constructor);
            ObjectUtils.SerializeObject(Scores, bw);
			ObjectUtils.SerializeObject(Users, bw);
			
        }
    }
}