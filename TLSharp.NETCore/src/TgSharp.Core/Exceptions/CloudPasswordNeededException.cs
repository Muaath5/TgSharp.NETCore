using System;

namespace TgSharp.NETCore.Exceptions
{
    public class CloudPasswordNeededException : TelegramException
    {
        internal CloudPasswordNeededException(string msg) : base(msg, 400) { }
    }
}