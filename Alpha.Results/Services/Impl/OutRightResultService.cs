namespace Alpha.Results.Site.Services.Impl
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics.CodeAnalysis;
    using System.IO;
    using System.Linq;
    using Alpha.Results.Site.Criteria;
    using App_GlobalResources;
    using Fanex.Common.Helper;
    using Fanex.Data.Repository;
    using Fanex.Result.Core.Base;
    using Fanex.Result.Core.Sportsbook.DTO;
    using Models.Requests;
    using RemotingRef;
    using Sunplus.Agent.Model.BL.Definitions;

    public class OutrightResultService : IOutrightResultService
    {
        private readonly IDynamicRepository _dynamicRepository;
        private readonly IResultEngineAdapter _resultEngineAdatper;

        public OutrightResultService(
            IDynamicRepository dynamicRepository,
            IResultEngineAdapter resultEngineAdatper)
        {
            _dynamicRepository = dynamicRepository;
            _resultEngineAdatper = resultEngineAdatper;
        }

        public IEnumerable<Outright> GetOutrights(DateTime fromDate, DateTime toDate, DateTime balanceUpDate)
        {
            if (fromDate < balanceUpDate)
            {
                return Enumerable.Empty<Outright>();
            }

            fromDate = fromDate.Date;
            toDate = toDate.Date.AddDays(1).AddTicks(-1);
            ICriteria criteria = GetOutrightCriteria(fromDate, toDate);

            return _dynamicRepository.Fetch<Outright>(criteria);
        }

        [SuppressMessage("Microsoft.Design", "CA1062:Validate arguments of public methods", MessageId = "1", Justification = "Reviewed")]
        public string GetResults(IEnumerable<Outright> outrights, OutrightResultQuery request)
        {
            Check.Argument.IsNotNull(outrights, "outrights");
            Check.Argument.IsNotNull(request, "request");

            outrights = FilterOutright(outrights, request.SportType, request.LeagueId);

            var resultSetting = new ResultSetting
            {
                LanguageCode = request.Language,
                IsOutright = true,
                IsPopUp = false,
                VisibleMatchCodeIDColumn = false,
                HighlightWinnerTeam = true
            };

            return _resultEngineAdatper.HtmlParser(outrights.ToList(), resultSetting);
        }

        [SuppressMessage("Microsoft.Design", "CA1062:Validate arguments of public methods", MessageId = "0", Justification = "Reviewed")]
        public MemoryStream GetExcelResults(ExcelOutrightResultQuery request, DateTime balanceUpDate)
        {
            Check.Argument.IsNotNull(request, "request");
            Check.Argument.IsNotEmpty(request.TemplatePath, "templatePath");

            string excelTitle = GetExcelTitle(request.FromDate, request.ToDate, request.SportType, request.LeagueId);

            var outrights = GetOutrights(request.FromDate, request.ToDate, balanceUpDate);

            outrights = FilterOutright(outrights, request.SportType, request.LeagueId);

            var resultSetting = new ResultSetting
            {
                LanguageCode = request.Language,
                IsOutright = true,
                IsPopUp = false,
                HighlightWinnerTeam = true,
                ExcelTitle = excelTitle,
                ExcelTemplatePath = request.TemplatePath
            };

            return _resultEngineAdatper.ExcelParser(outrights.ToList(), resultSetting);
        }

        private GetOutRightResultCriteria GetOutrightCriteria(DateTime fromDate, DateTime toDate)
        {
            return new GetOutRightResultCriteria
            {
                FromDate = fromDate,
                ToDate = toDate,
                IsShowAll = AppSettings.LocalTest
            };
        }

        private IEnumerable<Outright> FilterOutright(IEnumerable<Outright> outrights, int sportType, int leagueId)
        {
            if (sportType != 0)
            {
                outrights = outrights.Where(outright => outright.SportType == sportType);
            }

            if (leagueId != 0)
            {
                outrights = outrights.Where(outright => outright.LeagueId == leagueId);
            }

            return outrights;
        }

        private string GetExcelTitle(DateTime fromDate, DateTime toDate, int sportType, int leagueId)
        {
            string leagueName = leagueId == 0 ? Resources.ShowAllLeaguesExcelTitle : CacheRefFactory.CacheRef.GetLeagueName(leagueId);

            return $"{Resources.OutrightResults.ToUpper()} - {fromDate.ToShortDateString()} "
                + $"-> {toDate.ToShortDateString()} | {CacheRefFactory.CacheRef.GetSportName(sportType)} - {leagueName}";
        }
    }
}
