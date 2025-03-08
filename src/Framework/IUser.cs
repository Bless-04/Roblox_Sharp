using System;

namespace Roblox_Sharp.Framework
{
    /// <summary>
    /// base class for any roblox <see cref="IUser"></see> to represents a user with a unique id
    /// </summary>
    public interface IUser
    {
        /// <summary>
        /// the Unique numeric id of the user.
        /// </summary>
        public ulong userId { get; }
    }

    /// <summary>
    /// <inheritdoc cref="IUser"/> <br/>
    /// uses <typeparamref name="T"/> to automatically implement <see cref="IComparable{T}"/> and <see cref="IEquatable{T}"/>
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IUser<T> : IUser, IComparable<T>, IEquatable<T> where T : IUser
    {

    }
}
