using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace csharp_web_scraper.Data 
{
    class ScrapeCriteria
    {
        public ScrapeCriteria()
        {
           Parts = new List<ScrapeCriteriaPart>();
        }

        public string Data { get; set ;}
        public string Regex { get; set ;}
        public RegexOptions RegexOptions { get; set ;}
        public List<ScrapeCriteriaPart> Parts { get; set ;}
    }
}
