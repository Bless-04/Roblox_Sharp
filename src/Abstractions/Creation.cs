using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json.Serialization;

#pragma warning disable CA1707 // Identifiers should not contain underscores ;

namespace Roblox_Sharp.Abstractions
{
    /// <summary>
    /// generalized template for any roblox object that has a unique <see cref="ICreation.Id"/>
    /// </summary>
    public interface ICreation
    {
        /// <summary>
        /// The unique id of the creation
        /// </summary>
        ulong Id { get; }
    }

    /// <summary>
    /// generalized template for any roblox creation that has a unique id for comparisons <br/>
    /// uses <typeparamref name="T"/> for comparisons
    /// </summary>
    public abstract class Creation<T> : ICreation, 
        IEquatable<Creation<T>>, IComparable<Creation<T>>, IEqualityComparer<Creation<T>>
    {

        /// <inheritdoc cref="ICreation.Id"/>
        [JsonIgnore]
        protected ulong Id { get; init; } = default;

        ulong ICreation.Id => Id;

        /// <inheritdoc/>
        public int CompareTo(Creation<T>? other) => other is null
            ? 1
            : (int)(Id - other.Id); // older if smaller

        /// <summary>
        /// equal if and only if the ids are the same
        /// </summary>
        /// <param name="other"></param>
        /// <returns>
        /// <see langword="true"/> if ids are the same
        /// </returns>
        public bool Equals(Creation<T>? other) => other != null && Id == other.Id;

        /// <summary>
        /// creates a ulong using the id of the creation
        /// </summary>
        /// <param name="creation"></param>
        public static explicit operator ulong(Creation<T> creation) => creation.Id;

        /// <summary>
        /// returns <see langword="true"/> if the id is not 0
        /// </summary>
        /// <param name="creation"></param>
        public static explicit operator bool(Creation<T> creation) => creation.Id != default;

        /// <summary>
        /// a creation is <b> less than </b> another if it is newer. newer creations have larger ids than older ones
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns><inheritdoc/></returns>
        public static bool operator <(Creation<T> left, Creation<T> right) => left.Id > right.Id;

        /// <summary>
        /// a creation is <b>greater than</b> another if it is older. Older creations have smaller ids than newer creations.
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns><inheritdoc/></returns>
        public static bool operator >(Creation<T> left, Creation<T> right) => left.Id < right.Id;

        ///<inheritdoc cref="object.GetHashCode"/>
        ///<remarks>uses the same hashcode function as <see langword="ulong"/></remarks>
        public override int GetHashCode() => Id.GetHashCode();

        /// <inheritdoc/>
        public override bool Equals(object? obj) => Equals(obj as Creation<T>);

        /// <returns> A string representation of the <see cref="Creation{T}"/>
        /// </returns>
        public override string ToString() => $"Unique {typeof(T)} Id: {Id}";

        #region IEqualityComparer
        /// <inheritdoc/>
        public bool Equals(Creation<T>? x, Creation<T>? y) => x?.Id == y?.Id;

        /// <inheritdoc/>
        public int GetHashCode([DisallowNull] Creation<T> obj) => obj.Id.GetHashCode();
        #endregion
    }
}

