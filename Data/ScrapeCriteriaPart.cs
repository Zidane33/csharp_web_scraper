using System.Text.RegularExpressions;

namespace csharp_web_scraper.Data 
{
    class ScrapeCriteriaPart
    {
        public string Regex { get; set; }
        public RegexOptions regexOptions { get; set; }
    }
}
