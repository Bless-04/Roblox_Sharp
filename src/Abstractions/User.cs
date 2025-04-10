using System;
using System.Diagnostics;
using System.Text.Json.Serialization;

namespace Roblox_Sharp.Abstractions
{
    /// <summary>
    /// Provides a abstraction for a roblox user containing only the UserId
    /// </summary>
    public interface IUser
    {
        /// <summary>
        /// the Unique numeric id of the <see cref="IUser"/>.
        /// </summary>
        ulong UserId { get; }
    }

    /// <summary>
    /// Represents a base implementation for a roblox user containing both UserId and Username
    /// </summary>
    [DebuggerDisplay("{Username} (ID {UserId})")]
    public abstract class User : Creation<IUser>, IUser
    {
        /// <summary>
        /// The <see cref="StringComparer"/> used to compare the <see cref="User.Username"/>
        /// </summary>
        [JsonIgnore]
        public static readonly StringComparer UsernameComparer = StringComparer.OrdinalIgnoreCase;

        /// <summary>
        /// The user's unique username
        /// </summary>
        [JsonPropertyName("username")] //virtual because sometimes the json property is "name"
        public virtual string Username { get; init; } = string.Empty;

        /// <inheritdoc/> 
        [JsonPropertyName("userId")]
        public virtual ulong UserId
        {
            get => base.Id;
            init => base.Id = value;
        }

        /// <returns>
        /// A string representation of the <see cref="User"/>
        /// </returns>
        public override string ToString() => $"{Username} (ID {UserId})";
    }
}
