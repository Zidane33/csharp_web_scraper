using System.Collections.Generic;
using System.Text.RegularExpressions;
using csharp_web_scraper.Data;

namespace csharp_web_scraper.Builders
{
    class ScrapeCriteriaBuilder
    {
        private string _data;
        private string _regex;
        private RegexOptions _regexOptions;
        private List<ScrapeCriteriaPart> _parts;

        public ScrapeCriteriaBuilder()
        {
            setDefaults();
        }

        private void setDefaults()
        {
            _data = string.Empty;
            _regex = string.Empty;
            _regexOptions = RegexOptions.None;
            _parts = new List<ScrapeCriteriaPart>();
        }

        public ScrapeCriteriaBuilder WithData(string data)
        {
           _data = data;
           return this;
        }

        public ScrapeCriteriaBuilder WithRegex(string regex)
        {
           _regex = regex;
           return this;
        }

        public ScrapeCriteriaBuilder WithRegexOptions(RegexOptions regexOptions)
        {
           _regexOptions = regexOptions;
           return this;
        }

        public ScrapeCriteriaBuilder WithParts(ScrapeCriteriaPart part)
        {
           _parts.Add(part); 
           return this;
        }

        public ScrapeCriteria Build()
        {
            ScrapeCriteria scrapeCriteria = new ScrapeCriteria();
            scrapeCriteria.Data = _data;
            scrapeCriteria.Regex = _regex;
            scrapeCriteria.RegexOptions = _regexOptions;
            scrapeCriteria.Parts = _parts;

            return scrapeCriteria;
        }
    }
}
