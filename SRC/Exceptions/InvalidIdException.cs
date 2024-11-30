using System;

namespace Roblox_Sharp.Exceptions
{
    /// <summary>
    /// Exception thrown when a ID is invalid/does not exist
    /// </summary>
    sealed public class InvalidIdException : Exception
    {
        public InvalidIdException() { }
        
        public InvalidIdException(string message) : base(message) { }

        public InvalidIdException(string message, Exception inner) : base(message, inner) { }
    }
}