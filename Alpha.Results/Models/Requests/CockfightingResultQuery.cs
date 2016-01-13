namespace Alpha.Results.Site.Models.Requests
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;

    public class CockfightingResultQuery
    {
        public string LanguageKey { get; set; }

        public string Date { get; set; }

        public int CustomerId { get; set; }

        public int SiteId { get; set; }

        public int RoleId { get; set; }
    }
}