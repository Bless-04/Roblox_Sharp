using System;
namespace Roblox_Sharp.Exceptions
{
    /// <summary>
    /// Exception thrown when a <see cref="Roblox_Sharp.Framework.IUser"/> based argument is invalid/does not exist/banned/terminated 
    /// </summary>
    sealed public class InvalidUserException : Exception
    {
        public InvalidUserException() { }

        public InvalidUserException(string message) : base(message) { }

        public InvalidUserException(string message, Exception inner) : base(message, inner) { }


    }
}