using System;

namespace TgSharp.NETCore.Exceptions
{
    public class InvalidPhoneCodeException : TelegramException
    {
        internal InvalidPhoneCodeException(string msg) : base(msg) { }
    }
}