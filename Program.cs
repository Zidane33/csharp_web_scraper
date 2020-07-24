using System;
using System.Text.RegularExpressions;
using System.Net;
using csharp_web_scraper.Data;
using csharp_web_scraper.Workers;
using csharp_web_scraper.Builders;
using System.Linq;

namespace csharp_web_scraper
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter City");
            var city = Console.ReadLine() ?? string.Empty;
            Console.WriteLine("Enter Category");
            var categoy = Console.ReadLine() ?? string.Empty;

            using(WebClient client = new WebClient())
            {
                string content = client.DownloadString($"http://{city.Replace(" ", string.Empty)}.craigslist.org/search/{categoy}");
                ScrapeCriteria scrapeCriteria = new ScrapeCriteriaBuilder().WithData(content).WithRegex(@"<a href=\""(.*?)\"" data-id=\""(.*?)\"" class=\""result-title hdrlnk\"">(.*?)</a>")
                    .WithRegexOptions(RegexOptions.ExplicitCapture)
                    .WithParts(new ScrapeCriteriaPartBuilder()
                            .WithRegex(@">(.*?)</a>")
                            .WithRegexOptions(RegexOptions.Singleline)
                            .Build())
                    .WithParts(new ScrapeCriteriaPartBuilder()
                            .WithRegex(@"href=\""(.*?)\""")
                            .WithRegexOptions(RegexOptions.Singleline)
                            .Build())
                    .Build();

                Scraper scraper = new Scraper();
                var scrapedElements = scraper.Scrape(scrapeCriteria);

                if(scrapedElements.Any())
                {
                   foreach (var element in scrapedElements) Console.WriteLine(element); 
                }
                else
                {
                    Console.WriteLine("There were no matches");
                }
            }
        }
    }
}
