namespace Alpha.Results.Models
{
    using System;
    using LocalResources;
    using Sunplus.Agent.Model.RemotingRef;

    public class NormalRequest
    {
        public NormalRequest()
        {
            ResultDate = DateTime.Now;
        }

        public DateTime ResultDate { get; set; }

        public int SportId { get; set; }

        public int LeagueId { get; set; }

        public int BetTypeId { get; set; }

        public string Language { get; set; }

        public string ToExcelTitle()
        {
            string leagueName = LeagueId == 0 ? ResultLang.ShowAllLeagues : CacheRefFactory.CacheRef.GetLeagueName(LeagueId);

            return string.Format(
                "{0} - {1} | {2} {3}",
                ResultLang.result,
                ResultDate.ToString("MM/dd/yyyy"),
                CacheRefFactory.CacheRef.GetSportName(SportId),
                leagueName);
        }
    }
}