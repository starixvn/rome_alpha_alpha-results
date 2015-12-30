namespace Alpha.Results.Models.Views
{
    using System;
    using System.Collections.Generic;
    using System.Web.Mvc;
    using Alpha.Utilities.Extensions;
    using App_GlobalResources;

    public class NormalResultViewModel
    {
        public DateTime MinResultDate { get; set; }

        public string MinResultDateMessage
        {
            get
            {
                return string.Format(Resources.ViewDataFromDate, MinResultDate.ToShortDateFormatWithSlash());
            }
        }

        public DateTime ResultDate { get; set; }

        public string Yesterday
        {
            get
            {
                return DateTime.Now.AddDays(-1).ToShortDateFormatWithSlash();
            }
        }

        public string Today
        {
            get
            {
                return DateTime.Now.ToShortDateFormatWithSlash();
            }
        }

        public IEnumerable<SelectListItem> Sports { get; set; }

        public int SportId { get; set; }

        public IEnumerable<SelectListItem> Leagues { get; set; }

        public int LeagueId { get; set; }

        public string HtmlResults { get; set; }
    }
}