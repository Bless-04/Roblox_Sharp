using System;

namespace Roblox_Sharp.Framework
{
    /// <summary>
    /// base class for any roblox <see cref="IUser"></see> to represents a user with a unique user id
    /// </summary>
    public interface IUser
    {
        /// <summary>
        /// the Unique numeric id of the <see cref="IUser"/>.
        /// </summary>
        ulong UserId { get; }
    }
}
