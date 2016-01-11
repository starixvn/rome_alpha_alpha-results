using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Alpha.Results.Site.Models.Views;

namespace Alpha.Results.Site.Services
{
    public class ICockfightingResultService
    {
        ResultIframeViewModel GetResult(GetResultCriteria criteria);
    }
}