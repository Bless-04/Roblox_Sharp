using Roblox_Sharp.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Roblox_Sharp.Models.Internal
{
    internal class Profile_Response
    {
        


        internal static Profile_Response Parse(Match match,ref Profile_Response profile_Response)
        {
            return JsonSerializer.Deserialize<Profile_Response>(match.Value) ?? throw new InvalidIdException($"User id is invalid");
        }
    }
}
