namespace Alpha.Results.Site.Models.Requests
{
    using System;
    using Alpha.Results.Site.Helpers;
    using Sunplus.Agent.Model.Entities;

    public class KenoLotteryTableGameResultQuery
    {
        public KenoLotteryTableGameResultQuery(IUserSession userSession)
        {
            CustId = userSession.CustId;
            LanguageKey = userSession.LangKey;
            EventDate = DateTime.Today;
            RootUrl = UrlHelper.CurrentAppPath;
        }

        public int CustId { get; }

        public string LanguageKey { get; }

        public DateTime EventDate { get; }

        public string RootUrl { get; }
    }
}
