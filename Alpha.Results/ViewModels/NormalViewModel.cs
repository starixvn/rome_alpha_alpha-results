namespace Alpha.Results.ViewModels
{
    using System;
    using System.Collections.Generic;
    using System.Web.Mvc;
    using LocalResources;

    public class NormalViewModel
    {
        public DateTime MinResultDate { get; set; }

        public string MinResultDateMessage
        {
            get
            {
                return string.Format(ResultLang.ViewDataFromDate, MinResultDate.ToShortDateString());
            }
        }

        public DateTime ResultDate { get; set; }

        public string Yesterday
        {
            get
            {
                return DateTime.Now.AddDays(-1).ToShortDateString();
            }
        }

        public string Today
        {
            get
            {
                return DateTime.Now.ToShortDateString();
            }
        }

        public IEnumerable<SelectListItem> Sports { get; set; }

        public int SportId { get; set; }

        public IEnumerable<SelectListItem> Leagues { get; set; }

        public int LeagueId { get; set; }

        public string HtmlResults { get; set; }
    }
}