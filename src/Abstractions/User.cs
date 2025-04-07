using System;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Reflection.Metadata;
using System.Text.Json.Serialization;

namespace Roblox_Sharp.Abstractions
{
    /// <summary>
    /// interface for models representing user information containing properties that have the unique user id 
    /// </summary>
    public interface IUser
    {
        /// <summary>
        /// the Unique numeric id of the <see cref="IUser"/>.
        /// </summary>
        ulong UserId { get; }
    }

    /// <summary>
    /// abstract class for models representing User information that have properties containing both the unique user id and the unique usernae
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
