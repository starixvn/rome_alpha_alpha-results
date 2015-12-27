namespace Alpha.Results.ViewModels
{
    using System;
    using System.Collections.Generic;
    using Models;
    using System.Web.Mvc;
    public class NormalViewModel
    {
        public DateTime MinResultDate { get; set; }

        public string MinResultDateMessage { get; set; }

        public DateTime ResultDate { get; set; }

        public string Yesterday { get; set; }

        public string Today { get; set; }

        public IEnumerable<SelectListItem> Sports { get; set; }

        public int SportId { get; set; }

        public IEnumerable<SelectListItem> Leagues { get; set; }

        public int LeagueId { get; set; }

        public string HtmlResults { get; set; }

    }
}