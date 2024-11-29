using System.Diagnostics.CodeAnalysis;
using System;

namespace Roblox_Sharp.Templates
{
    /// <summary>
    /// Defines a generalized template for any roblox <paramref name="User"></paramref> based object
    /// </summary>
    public abstract class IUser : 
            IComparable<IUser>
    {

        /// <summary>
        /// the numeric <paramref name="id"/> of the user. Should only be set in initialization
        /// </summary>
        abstract public ulong id { get; protected set; }
        
        public IUser() { }

        public IUser(ulong id) => this.id = id;

        /// <summary>
        /// equal if and only if the ids are the same
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public override bool Equals([NotNullWhen(true)] object? obj)
        {
            if (obj is IUser user)
                return this.id == user.id;

            return false;
        }
        public override int GetHashCode() => id.GetHashCode();

        /** might not be a good idea*/
        /// <summary>
        /// explicit conversion from <see cref="IUser"/> to <see cref="ulong"/> <br></br>
        /// simply returns the users id
        /// </summary>
        /// <param name="user"></param>
        public static explicit operator ulong(IUser user) => user.id;

        /// <summary>
        /// a user is <b> less than </b> another if it is younger. Younger users have larger ids than older ones
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns>bool</returns>
        public static bool operator <(IUser left, IUser right) => left.id > right.id;

       
        /// <summary>
        /// a user is <b>greater than</b> another if it is older. Older users have smaller ids than newer users.
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns>bool</returns>
        public static bool operator >(IUser left, IUser right) => left.id < right.id;
        
        
        /// <summary>
        /// a user is greater than another if it is older. Older users have smaller ids than newer users.
        /// <br></br>
        /// example: userid 1 is the biggest user
        /// </summary>
        /// <param name="other"></param>
        /// <returns>int</returns>
        public int CompareTo(IUser? other)
        {
            if (other is null) return 1;

            //if this is older than other
            if (this.id < other.id) return 1;

            //if this is younger than other
            if (this.id > other.id) return -1;

            return 0;
        }
    }
}
