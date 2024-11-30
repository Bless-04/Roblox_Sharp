using System;

namespace Roblox_Sharp.Exceptions
{
    /// <summary>
    /// Exception thrown when the rate limit is exceeded
    /// </summary>
    sealed public class RateLimitException : Exception
    {
        public RateLimitException() { }

        public RateLimitException(string message) : base(message) { }

        public RateLimitException(string message, Exception inner) : base(message, inner) { }
    }
}
