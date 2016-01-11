using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Alpha.Results.Site.Models.Views
{
    public class ResultIframeViewModel
    {
        public string Language { get; set; }

        public string Date { get; set; }

        public int CustomerId { get; set; }

        public int SiteId { get; set; }

        public int RoleId { get; set; }

        public string Iframe { get; set; }
    }
}