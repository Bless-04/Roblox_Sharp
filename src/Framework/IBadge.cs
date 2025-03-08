using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Roblox_Sharp.Framework
{
    public interface IBadge
    {   
        /// <summary>
        /// The unique id of the <see cref="IBadge"/>
        /// </summary>
        ulong BadgeId { get; }
    }
}
