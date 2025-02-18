using System;

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member ; Self explanatory
namespace Roblox_Sharp.Exceptions
{
    /// <summary>
    /// Exception thrown when the rate limit is exceeded
    /// </summary>
    public sealed class RateLimitException : Exception
    {
        public RateLimitException() { }

        public RateLimitException(string message) : base(message) { }

        public RateLimitException(string message, Exception inner) : base(message, inner) { }
    }
}
