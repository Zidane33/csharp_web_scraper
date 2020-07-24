using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using csharp_web_scraper.Data;

namespace csharp_web_scraper.Workers
{
    class  Scraper
    {
        public List<string> Scrape(ScrapeCriteria scrapeCriteria)
        {
            List<string> scrapedElements = new List<string>();

            MatchCollection matches = Regex.Matches(scrapeCriteria.Data, scrapeCriteria.Regex, scrapeCriteria.RegexOptions);
            foreach (Match match in matches)
            {
                if(!scrapeCriteria.Parts.Any())
                {
                    scrapedElements.Add(match.Groups[0].Value);
                }
                else
                {
                    foreach (var part in scrapeCriteria.Parts)
                    {
                        Match matchedPart = Regex.Match(match.Groups[0].Value, part.Regex, part.regexOptions);
                        if(matchedPart.Success)scrapedElements.Add(matchedPart.Groups[1].Value);
                    }
                }
            }

            return scrapedElements;
        }
        
    }
}
