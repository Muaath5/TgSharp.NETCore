using System;

namespace TgSharp.NETCore.Network.Exceptions
{
    public class FloodException : Exception
    {
        public TimeSpan TimeToWait { get; private set; }

        internal FloodException(TimeSpan timeToWait)
            : base($"Flood prevention. Telegram now requires your program to do requests again only after {timeToWait.TotalSeconds} seconds have passed ({nameof(TimeToWait)} property), so if now it's {DateTime.Now}, wait until {(DateTime.Now+timeToWait)}" +
                   " If you think the culprit of this problem may lie in TgSharp's implementation, open a Github issue please.")
        {
            TimeToWait = timeToWait;
        }
    }
}