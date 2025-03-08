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

        /// <summary>
        /// a user is  <b> less than </b> another if it is newer. newer user have larger ids than older users
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns><inheritdoc/></returns>
        public static bool operator <(IUser left, IUser right) => left.userId > right.userId;

        /// <summary>
        /// a user is <b>greater than</b> another if it is older. Older users have smaller ids than newer users.
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns><inheritdoc/></returns>
        public static bool operator >(IUser left, IUser right) => left.userId < right.userId;

        ///<inheritdoc cref="ulong.GetHashCode"/>
        ///<remarks>uses the hashcode function of the <see langword="ulong"/> <see cref="userId"/></remarks>
        int GetHashCode();

        /// <summary>
        /// <inheritdoc cref="object.Equals(object?)"/> 
        /// </summary>
        /// <param name="obj"></param>
        /// <returns>
        /// <see langword="true"/> if and only if the <see cref="IUser.userId"/>'s are the same
        /// </returns>
        bool Equals(object? obj) => obj is IUser user && userId == user.userId;
    }

    /// <summary>
    /// <inheritdoc cref="IUser"/> <br/>
    /// uses <typeparamref name="T"/> to automatically implement <see cref="IComparable{T}"/> and <see cref="IEquatable{T}"/>
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IUser<T> : IUser, IComparable<T>, IEquatable<T> where T : IUser
    {
        bool IEquatable<T>.Equals(T? other) => other?.userId == this.userId;

        /// <inheritdoc cref="IComparable.CompareTo"/>
        int IComparable<T>.CompareTo(T? other)
        {
            if (other is null) return 1;

            //if this is older than other
            if (userId < other.userId) return 1;

            //if this is younger than other
            if (userId > other.userId) return -1;

            return 0;
        }

        /// <summary>
        /// string representation of the <typeparamref name="T"/>
        /// </summary>
        string? ToString();
    }
}
