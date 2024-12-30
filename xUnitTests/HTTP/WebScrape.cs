using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Roblox_Sharp.Models;

#pragma warning disable CS0618 //Testing
using static Roblox_Sharp.WebScraper;


namespace xUnitTests.HTTP
{
    public class WebScraper
    {
        [Fact]
        public async Task Get_Profile()
        {
            Scrape_ProfileAsync(1);
        }
    }
}
