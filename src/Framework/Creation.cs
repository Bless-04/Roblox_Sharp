using System;
using System.Text.Json.Serialization;

namespace Roblox_Sharp.Framework
{

    /// <summary>
    ///  generalized template for any roblox object that has a unique id 
    /// </summary>
    public abstract class Creation(ulong? id = null) : IComparable<Creation>, IEquatable<Creation>
    {
        /// <summary>
        /// The unique id of the creation; Null if not requested
        /// </summary>
        [JsonInclude]
        protected ulong? id { get; init; } = id;

        /// <inheritdoc />
        public bool Equals(Creation? other) => other != null && id == other.id;

        /// <summary>
        /// a creation is <b> less than </b> another if it is newer. newer creations have larger ids than older ones
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns><inheritdoc/></returns>
        public static bool operator <(Creation left, Creation right) => left.id > right.id;

        /// <summary>
        /// a creation is <b>greater than</b> another if it is older. Older creations have smaller ids than newer creations.
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns><inheritdoc/></returns>
        public static bool operator >(Creation left, Creation right) => left.id < right.id;

        ///<inheritdoc cref="object.GetHashCode"/>
        ///<remarks>uses the same hashcode function as <see langword="ulong"/></remarks>
        public override int GetHashCode() => id.GetHashCode();

        /// <summary>
        /// equal if and only if the ids are the same
        /// </summary>
        /// <param name="other"></param>
        /// <returns>
        /// <see langword="true"/> if ids are the same
        /// </returns>
        public override bool Equals(object? other) => Equals(other as Creation);

        /// <inheritdoc/>
        public int CompareTo(Creation? other)
        {
            if (other is null) return 1;

            //if this is older than other
            if (id < other.id) return 1;

            //if this is younger than other
            if (id > other.id) return -1;

            return 0;
        }
    }
}

