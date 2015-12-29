namespace Alpha.Results.Services.Impl
{
	using Alpha.Results.Criteria;
	using Alpha.Results.LocalResources;
	using Fanex.Data.Repository;
	using Fanex.Result.Core;
	using Fanex.Result.Core.Base;
	using Fanex.Result.Core.Sportsbook.DTO;
	using Models;
	using Sunplus.Agent.Model.BL.Cache;
	using Sunplus.Agent.Model.BL.Definitions;
	using System;
	using System.Collections.Generic;
	using System.IO;
	using System.Linq;

	public class OutRightResultService : ReportService, IOutRightResultService
    {
        private readonly IDynamicRepository _dynamicRepository;

        public OutRightResultService(IDynamicRepository dynamicRepository = null)
        {
            _dynamicRepository = dynamicRepository ?? new DynamicRepository();
        }

		public IEnumerable<OutRight> GetOutRights(DateTime fromDate, DateTime toDate)
		{
			fromDate = fromDate.Date;
			toDate = toDate.Date.AddDays(1).AddTicks(-1);

			ICriteria criteria = GetCriteria(fromDate, toDate);
			if (!criteria.IsValid())
			{
				return null;
			}

			return _dynamicRepository.Fetch<OutRight>(criteria);
		}

		public string GetResults(IEnumerable<OutRight> outrights, OutRightRequest request)
		{
			outrights = FilterOutright(outrights, request.SportType, request.LeagueId);
			return ResultEngine.HtmlParser(outrights.ToList(), OutRightResultSetting(request.Language));
		}

		public MemoryStream GetExcelResults(IEnumerable<OutRight> outrights, OutRightRequest request, string templatePath)
		{
			string excelTitle = GetExcelTitle(request.FromDate, request.ToDate, request.SportType, request.LeagueId);

			outrights = FilterOutright(outrights, request.SportType, request.LeagueId);
			return ResultEngine.ExcelParser(outrights.ToList(), OutRightExcelSetting(request.Language, templatePath, excelTitle));
		}

		private GetOutRightResultCriteria GetCriteria(DateTime fromDate, DateTime toDate)
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

        private ResultSetting OutRightResultSetting(string language)
		{
			return new ResultSetting
			{
				LanguageCode = language,
				IsOutRight = true,
				IsPopUp = false,
				VisibleMatchCodeIDColumn = false,
				HighlightWinnerTeam = true
			};
        }

        private ResultSetting OutRightExcelSetting(string language, string templatePath, string title)
        {
            return new ResultSetting
            {
                LanguageCode = language,
                IsOutRight = true,
                IsPopUp = false,
                HighlightWinnerTeam = true,
				ExcelTitle = title,
				ExcelTemplatePath = templatePath
			};
        }

        private string GetExcelTitle(DateTime fromDate, DateTime toDate, int sportType, int leagueId)
        {
            string leagueName = leagueId == 0 ? "Show All Leagues" : CacheRef.GetLeagueName(leagueId);
			return string.Format(
				"{0} - {1} -> {2} | {3} - {4}",
				ResultLang.lblOutrightResult.ToUpper(),
				fromDate.ToShortDateString(),
				toDate.ToShortDateString(),
				CacheRef.GetSportName(sportType),
				leagueName
			);
        }
	}
}