namespace Alpha.Results.Services.Impl
{
	using Alpha.Results.Criteria;
	using Alpha.Results.LocalResources;
	using Fanex.Common.Helper;
	using Fanex.Data.Repository;
	using Fanex.Result.Core;
	using Fanex.Result.Core.Base;
	using Fanex.Result.Core.Sportsbook.DTO;
	using Models;
	using Sunplus.Agent.Model.BL.Cache;
	using Sunplus.Agent.Model.BL.Definitions;
	using Sunplus.Agent.Model.Entities;
	using System;
	using System.Collections.Generic;
	using System.IO;
	using System.Linq;

	public class OutRightService : ReportService, IOutRightService
    {
        private readonly IDynamicRepository _dynamicRepository;

        public OutRightService(IDynamicRepository dynamicRepository = null)
        {
            _dynamicRepository = dynamicRepository ?? new DynamicRepository();
        }

		public IEnumerable<OutRight> GetOutRights(DateTime fromDate, DateTime toDate)
		{
			Check.Argument.IsNotNull(fromDate, "fromDate");
			Check.Argument.IsNotNull(toDate, "toDate");

			fromDate = fromDate.Date;
			toDate = toDate.Date.AddDays(1).AddTicks(-1);

			ICriteria criteria = GetCriteria(fromDate, toDate);
			if (!criteria.IsValid())
			{
				return null;
			}

			return _dynamicRepository.Fetch<OutRight>(criteria);
		}

		public string GetResults(IEnumerable<OutRight> outrights, int sportId, int leagueId)
		{
			outrights = FilterOutright(outrights, sportId, leagueId);
			return ResultEngine.HtmlParser<OutRight>(outrights.ToList(), OutrightResultSetting);
		}

		public MemoryStream GetExcelResults(IEnumerable<OutRight> outrights, OutrightRequest request, string excelTemplatePath)
		{
			outrights = FilterOutright(outrights, request.SportId, request.LeagueId);

			string excelTitle = GetExcelTitle(request.FromDate, request.ToDate, request.SportId, request.LeagueId);
			return ResultEngine.ExcelParser(outrights.ToList(), OutrightExcelSetting(excelTemplatePath, excelTitle));
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

		private IEnumerable<OutRight> FilterOutright(IEnumerable<OutRight> outrights, int sportId, int leagueId)
		{
			if (sportId != 0)
			{
				outrights = outrights.Where(o => o.SportType == sportId);
			}

			if (leagueId != 0)
			{
				outrights = outrights.Where(o => o.LeagueId == leagueId);
			}

			return outrights;
		}

        private ResultSetting OutrightResultSetting
		{
			get
			{
				return new ResultSetting
				{
					LanguageCode = UserSession.Current.Language,
					IsOutRight = true,
					IsPopUp = false,
					VisibleMatchCodeIDColumn = false,
					HighlightWinnerTeam = true
				};
			}
        }

        private ResultSetting OutrightExcelSetting(string excelTemplatePath, string excelTitle)
        {
            return new ResultSetting
            {
                LanguageCode = UserSession.Current.Language,
                IsOutRight = true,
                IsPopUp = false,
                HighlightWinnerTeam = true,
				ExcelTitle = excelTitle,
				ExcelTemplatePath = excelTemplatePath
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