using System;
using System.Collections.Generic;
using System.Text;

namespace TgSharp.NETCore.Exceptions
{

    [Serializable]
    public class TelegramException : Exception
    {
        public int Code { get; }

        internal TelegramException() { }
        internal TelegramException(string message) : base(message) { }
        internal TelegramException(string message, int code) : base(message) { Code = code; }
        internal TelegramException(string message, Exception inner) : base(message, inner) { }
        protected internal TelegramException(
          System.Runtime.Serialization.SerializationInfo info,
          System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
    }
}
