namespace Roblox_Sharp.Models;

public partial class ResourceError
{
    /// <summary>
    /// v1 Error codes model
    /// </summary>
    public enum Code : ushort
    {
        /// <summary>
        /// You passed an invalid argument, such as an invalid universeId. You might also have missing or invalid headers, such as Content-Length and Content-Type.
        /// </summary>
        INVALID_ARGUMENT = 400,

        /// <summary>
        /// The request requires higher privileges than provided by the access token.
        /// </summary>
        INSUFFICIENT_SCOPE = 403,

        PERMISSION_DENIED = 403,
        NOT_FOUND = 404,
        ABORTED = 409,
        RESOURCE_EXHAUSTED = 429,
        CANCELLED = 499, 
        INTERNAL = 500,
        NOT_IMPLEMENTED = 501,
        UNAVAILABLE = 503
    }

}
