using System;
using System.Diagnostics;
using System.Text.Json.Serialization;

namespace Roblox_Sharp.Abstractions
{
    /// <summary>
    /// represents any User based request that contains the unique user id
    /// </summary>
    public interface IUser
    {
        /// <summary>
        /// the Unique numeric id of the <see cref="IUser"/>.
        /// </summary>
        ulong UserId { get; }
    }

    /// <summary>
    /// represents any User based request that contains the user id and the username
    /// </summary>
    [DebuggerDisplay("{Username} (ID {UserId})")]
    public abstract class User : Creation<IUser>, IUser , IFormattable
    {
        /// <summary>
        /// The <see cref="StringComparer"/> used to compare the <see cref="User.Username"/>
        /// </summary>
        [JsonIgnore]
        public static readonly StringComparer UsernameComparer = StringComparer.OrdinalIgnoreCase;

        /// <summary>
        /// The user's unique username
        /// </summary>
        [JsonPropertyName("username")]
        public string Username { get; init; } = string.Empty;

        /// <inheritdoc/>
        [JsonPropertyName("userId")]
        public ulong UserId
        {
            get => base.Id;
            init => base.Id = value;
        }

        /// <returns>
        /// A string representation of the <see cref="User"/>
        /// </returns>
        public override string ToString() => $"{Username} (ID {UserId})";
      
        /// /// <summary>
        /// Formats the <see cref="User"/> information based on the provided format string.
        /// Supported format strings:
        /// <list type="table">
        ///   <listheader>
        ///     <term>Format</term>
        ///     <description>Output</description>
        ///   </listheader>
        ///   <item>
        ///     <term>"id"</term>
        ///     <description>Returns the <see cref="User.UserId"/></description>
        ///   </item>
        ///   <item>
        ///     <term>"name"</term>
        ///     <description>Returns the <see cref="User.Username"/></description>
        ///   </item>
        /// </list>
        /// </summary>
        /// <returns>
        /// <inheritdoc cref="IFormattable.ToString(string?, IFormatProvider?)"/>
        /// </returns>
        public string ToString(string? format, IFormatProvider? formatProvider) => format == null ? ToString()
            : format switch
            {
                //user id 
                "id" => $"(ID {UserId}) ",
                "name" => "@{username} ",
                _ => throw new FormatException()
            };

    }
}
