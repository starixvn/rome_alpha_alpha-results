namespace Alpha.Results.Models
{
    using System;
    using LocalResources;
    using Sunplus.Agent.Model.RemotingRef;
    using Alpha.Utilities.Extensions;

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

        public bool IsShowTestResults { get; set; }

        public string ToExcelTitle()
        {
            var leagueName = LeagueId == 0 ? ResultLang.ShowAllLeaguesExcelTitle : CacheRefFactory.CacheRef.GetLeagueName(LeagueId);
            var resultDate = ResultDate.ToShortDateFormatWithSlash();

            return $"{ResultLang.result} - {resultDate} | {CacheRefFactory.CacheRef.GetSportName(SportId)} {leagueName}";
        }
    }
}