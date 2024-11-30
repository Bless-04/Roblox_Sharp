using System;

namespace Roblox_Sharp.Exceptions
{
    /// <summary>
    /// Exception thrown when a username argument is invalid/does not exist/banned/terminated
    /// </summary>
    sealed public class InvalidUsernameException : Exception
    {
        public InvalidUsernameException() { }
        
        public InvalidUsernameException(string message) : base(message) { }

        public InvalidUsernameException(string message, Exception inner) : base(message, inner) { }

        
    }
}