using System.Text.RegularExpressions;
using csharp_web_scraper.Data;

namespace csharp_web_scraper.Builders
{
    class ScrapeCriteriaPartBuilder
    {
        private string _regex;
        private RegexOptions _regexOption;

        public ScrapeCriteriaPartBuilder()
        {
            setDefaults();
        }

        private void setDefaults()
        {
            _regex = string.Empty;
            _regexOption = RegexOptions.None;
        }

        public ScrapeCriteriaPartBuilder WithRegex(string regex)
        {
           _regex = regex;
           return this;
        }

        public ScrapeCriteriaPartBuilder WithRegexOptions(RegexOptions regexOptions)
        {
           _regexOption = regexOptions;
           return this;
        }

        public ScrapeCriteriaPart Build()
        {
            ScrapeCriteriaPart scrapeCriteriaPart = new ScrapeCriteriaPart();
            scrapeCriteriaPart.Regex = _regex;
            scrapeCriteriaPart.regexOptions = _regexOption;

            return scrapeCriteriaPart;
        }
    }
}
