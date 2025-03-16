using System;
using System.Text.Json.Serialization;

#pragma warning disable CA1707 // Identifiers should not contain underscores ;

namespace Roblox_Sharp.Framework
{


    /// <summary>
    /// generalized template for any roblox object that has a <paramref name="uniqueId"/>
    /// </summary>
    /// <summary>
    /// uses <typeparamref name="T"/> to automatically implement <see cref="IComparable{T}"/> and <see cref="IEquatable{T}"/>
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public abstract class Creation<T>(ulong? uniqueId = null) : ICreation, IEquatable<Creation<T>>, IComparable<Creation<T>> 
    {
        /// <summary>
        /// The unique id of the creation; Null if not requested
        /// </summary>
        [JsonInclude]
        [JsonPropertyName("id")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        protected ulong? CreationId { get; init; } = uniqueId;

        ulong? ICreation.CreationId => CreationId;

        /// <inheritdoc/>
        public int CompareTo(Creation<T>? other)
        {
            if (other is null) return 1;

            //if this is older than other
            if (CreationId < other.CreationId) return 1;

            //if this is younger than other
            if (CreationId > other.CreationId) return -1;

            return 0;
        }

        /// <summary>
        /// equal if and only if the ids are the same
        /// </summary>
        /// <param name="other"></param>
        /// <returns>
        /// <see langword="true"/> if ids are the same
        /// </returns>
        public bool Equals(Creation<T>? other) => other != null && CreationId == other.CreationId;

        /// <summary>
        /// creates a ulong using the id of the creation
        /// </summary>
        /// <param name="creation"></param>
        public static implicit operator ulong?(Creation<T> creation) => creation.CreationId;
        /// <summary>
        /// a creation is <b> less than </b> another if it is newer. newer creations have larger ids than older ones
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns><inheritdoc/></returns>
        public static bool operator <(Creation<T> left, Creation<T> right) => left.CreationId > right.CreationId;

        /// <summary>
        /// a creation is <b>greater than</b> another if it is older. Older creations have smaller ids than newer creations.
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns><inheritdoc/></returns>
        public static bool operator >(Creation<T> left, Creation<T> right) => left.CreationId < right.CreationId;

        ///<inheritdoc cref="object.GetHashCode"/>
        ///<remarks>uses the same hashcode function as <see langword="ulong"/></remarks>
        public override int GetHashCode() => CreationId.GetHashCode();

        /// <inheritdoc/>
        public override bool Equals(object? obj) => Equals(obj as Creation<T>);
    }
}

