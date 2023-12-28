using Fanex.Result.Core.Sportsbook.DTO;
using System.Collections.Generic;

namespace Alpha.Results.Site.Models
{
    public class ResultDetailModel
    {
        public ResultDetailModel(string html) : this(html, new List<Sportsbook>())
        {
        }

        public ResultDetailModel(string html, IEnumerable<Sportsbook> matchs)
        {
            Html = html;
            Matchs = matchs;
        }

        public string Html { get; set; }

        public IEnumerable<Sportsbook> Matchs { get; set; }
    }
}