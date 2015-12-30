namespace Alpha.Results.Services.Impl
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using Alpha.Results.Criteria;
    using App_GlobalResources;
    using Fanex.Common.Helper;
    using Fanex.Data.Repository;
    using Fanex.Result.Core;
    using Fanex.Result.Core.Base;
    using Fanex.Result.Core.Sportsbook.DTO;
    using Models.Requests;
    using Sunplus.Agent.Model.BL.Cache;
    using Sunplus.Agent.Model.BL.Definitions;

    public class OutrightResultService : ReportService, IOutrightResultService
    {
        private readonly IDynamicRepository _dynamicRepository;

        public OutrightResultService(IDynamicRepository dynamicRepository)
            : base(dynamicRepository, null)
        {
            _dynamicRepository = dynamicRepository ?? new DynamicRepository();
        }

        public IEnumerable<OutRight> GetOutrights(DateTime fromDate, DateTime toDate)
        {
            Check.Argument.IsNotInvalidDate(fromDate, "fromDate");
            Check.Argument.IsNotInvalidDate(toDate, "toDate");

            fromDate = fromDate.Date;
            toDate = toDate.Date.AddDays(1).AddTicks(-1);
            ICriteria criteria = GetOutrightCriteria(fromDate, toDate);

            if (!criteria.IsValid())
            {
                return null;
            }

            DateTime balanceUpDay = GetBalanceUpDate().BalanceUpDay;
            if (fromDate < balanceUpDay)
            {
                return null;
            }

            return _dynamicRepository.Fetch<OutRight>(criteria);
        }

        public string GetResults(IEnumerable<OutRight> outrights, ViewOutrightResultQuery request)
        {
            Check.Argument.IsNotNull(outrights, "outrights");
            Check.Argument.IsNotNull(request, "request");

            outrights = FilterOutright(outrights, request.SportType, request.LeagueId);

            var resultSetting = new ResultSetting
            {
                LanguageCode = request.Language,
                IsOutRight = true,
                IsPopUp = false,
                VisibleMatchCodeIDColumn = false,
                HighlightWinnerTeam = true
            };

            return ResultEngine.HtmlParser(outrights.ToList(), resultSetting);
        }

        public MemoryStream GetExcelResults(DownloadOutrightResultExcelQuery request)
        {
            Check.Argument.IsNotNull(request, "request");
            Check.Argument.IsNotEmpty(request.TemplatePath, "templatePath");

            string excelTitle = GetExcelTitle(request.FromDate, request.ToDate, request.SportType, request.LeagueId);

            var outrights = GetOutrights(request.FromDate, request.ToDate);

            outrights = FilterOutright(outrights, request.SportType, request.LeagueId);

            var resultSetting = new ResultSetting
            {
                LanguageCode = request.Language,
                IsOutRight = true,
                IsPopUp = false,
                HighlightWinnerTeam = true,
                ExcelTitle = excelTitle,
                ExcelTemplatePath = request.TemplatePath
            };

            return ResultEngine.ExcelParser(outrights.ToList(), resultSetting);
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

        private IEnumerable<OutRight> FilterOutright(IEnumerable<OutRight> outrights, int sportType, int leagueId)
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
            string leagueName = leagueId == 0 ? ResultLang.ShowAllLeaguesExcelTitle : CacheRef.GetLeagueName(leagueId);

            return $"{ResultLang.lblOutrightResult.ToUpper()} - {fromDate.ToShortDateString()} -> {toDate.ToShortDateString()} | {CacheRef.GetSportName(sportType)} - {leagueName}";
        }
    }
}