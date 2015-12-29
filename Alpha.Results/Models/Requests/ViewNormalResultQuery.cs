namespace Alpha.Results.Commands
{
    using System;
    using Alpha.Utilities.Extensions;
    using App_GlobalResources;
    using MediatR;
    using Sunplus.Agent.Model.RemotingRef;
    using ViewModels;

    public class ViewNormalResultQuery : IRequest<NormalViewModel>
    {
        public ViewNormalResultQuery()
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