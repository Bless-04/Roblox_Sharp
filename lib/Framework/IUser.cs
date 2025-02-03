using System;

namespace Roblox_Sharp.Framework
{
    /// <summary>
    /// base class for any roblox <see cref="IUser"></see> based object
    /// </summary>
    public interface IUser: IComparable<IUser>, IEquatable<IUser>
    {
        /// <summary>
        /// the Unique numeric id of the user.
        /// </summary>
        public ulong userId { get;  }

        /// <summary>
        /// equal if and only if the userIds are the same
        /// </summary>
        /// <param name="other"></param>
        /// <returns></returns>
        bool IEquatable<IUser>.Equals(IUser? other) => other?.userId == this.userId;

        /// <inheritdoc cref="IComparable.CompareTo"/>
        int IComparable<IUser>.CompareTo(IUser? other)
        {
            if (other is null) return 1;

            //if this is older than other
            if (userId < other.userId) return 1;

            //if this is younger than other
            if (userId > other.userId) return -1;

            return 0;
        }

        ///<inheritdoc cref="ulong.GetHashCode"/>
        ///<remarks>uses the same hashcode function as <see langword="ulong"/></remarks>
        int GetHashCode() => userId.GetHashCode();

        /// <summary>
        /// string representation of the user <br></br> 
        /// </summary>
        string? ToString() =>$"(ID {userId})";

        /// <summary>
        /// a user is <b> less than </b> another if it is newer. newer user have larger ids than older users
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns><inheritdoc/></returns>
        static bool operator <(IUser left, IUser right) => left.userId > right.userId;

        /// <summary>
        /// a user is <b>greater than</b> another if it is older. Older users have smaller ids than newer users.
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns><inheritdoc/></returns>
        static bool operator >(IUser left, IUser right) => left.userId < right.userId;
    }
}
