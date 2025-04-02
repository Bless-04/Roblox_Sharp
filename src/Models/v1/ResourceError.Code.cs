namespace Roblox_Sharp.Models.v1;

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

        /// <summary>
        /// Your request doesn't have sufficient scope to perform the operation.
        /// </summary>
        PERMISSION_DENIED = INSUFFICIENT_SCOPE,

        /// <summary>
        /// The system can't find your specified resources, such as a data store.
        /// </summary>
        NOT_FOUND = 404,

        /// <summary>
        /// The operation was aborted due to a conflict, such as publishing a place that is not part of the universe.
        /// </summary>
        ABORTED = 409,

        /// <summary>
        /// You don't have enough quota to perform the operation, typically due to sending too many requests.
        /// </summary>
        RESOURCE_EXHAUSTED = 429,

        /// <summary>
        /// The system terminates the request, typically due to a client side timeout.
        /// </summary>
        CANCELLED = 499,

        /// <summary>
        /// Internal server error. Typically a server bug.
        /// </summary>
        INTERNAL = 500,

        /// <summary>
        /// The server doesn't implement the API method.
        /// </summary>
        NOT_IMPLEMENTED = 501,

        /// <summary>
        /// Service unavailable. Typically the server is down.
        /// </summary>
        UNAVAILABLE = 503
    }

}
