namespace Roblox_Sharp.Exceptions
{
    /// <summary>
    /// Exception thrown when a user ID is invalid/does not exist
    /// </summary>
    public class InvalidUserIdException : Exception
    {
        public InvalidUserIdException() { }
        
        public InvalidUserIdException(string message) : base(message) { }

        public InvalidUserIdException(string message, Exception inner) : base(message, inner) { }

        
    }
}