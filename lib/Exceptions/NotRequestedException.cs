using System;

namespace Roblox_Sharp.Exceptions
{
    /// <summary>
    /// thrown when <b>important</b> data that was never gotten is requested
    /// </summary>
    public sealed class NotRequestedException : NullReferenceException
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="NotRequestedException"/> class
        /// </summary>
        /// <param name="variable_name"></param>
        public NotRequestedException(string variable_name) : base($"The data for {variable_name} is was never requested") { }
    }
}
