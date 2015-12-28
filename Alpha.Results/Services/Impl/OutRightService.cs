namespace Alpha.Results.Services.Impl
{
	using Alpha.Results.Criteria;
	using Alpha.Results.LocalResources;
	using Fanex.Common.Helper;
	using Fanex.Data.Repository;
	using Fanex.Result.Core;
	using Fanex.Result.Core.Base;
	using Fanex.Result.Core.Sportsbook.DTO;
	using Sunplus.Agent.Model.BL.Cache;
	using Sunplus.Agent.Model.Entities;
	using System;
	using System.Collections.Generic;
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
			if (sportId != 0)
			{
				outrights = outrights.Where(o => o.SportType == sportId);
			}

			if (leagueId != 0)
			{
				outrights = outrights.Where(o => o.LeagueId == leagueId);
			}

			return ResultEngine.HtmlParser<OutRight>(outrights.ToList(), CoreResultSetting);
		}

  //      public MemoryStream ExportExcel(DateTime fromDate, DateTime toDate, int sportId, int leagueId, string excelTemplatePath)
  //      {
  //          var result = this._dynamicRepository.Fetch<OutRight>(GetCriteria(fromDate, toDate));

  //          if (sportId != 0)
  //          {
  //              result = result.Where(o => o.SportType == sportId);
  //          }

  //          if (leagueId != 0)
  //          {
  //              result = result.Where(o => o.LeagueId == leagueId);
  //          }

  //          return ResultEngine.ExcelParser<OutRight>(
  //              result.ToList(),
  //              GetExportExcelSetting(excelTemplatePath, GetExcelTitle(sportId, fromDate, toDate, leagueId)));
  //      }

        private GetOutRightResultCriteria GetCriteria(DateTime fromDate, DateTime toDate)
        {
            return new GetOutRightResultCriteria
            {
                FromDate = fromDate,
                ToDate = toDate,
				IsShowAll = true
			};
        }

        private ResultSetting CoreResultSetting
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

        private static ResultSetting GetExportExcelSetting(string excelTemplatePath, string excelTitle)
        {
            return new ResultSetting
            {
                LanguageCode = UserSession.Current.Language,
                IsOutRight = true,
                IsPopUp = false,
                ExcelTitle = excelTitle,
                ExcelTemplatePath = excelTemplatePath,
                HighlightWinnerTeam = true
            };
        }

        private static string GetExcelTitle(int sportType, DateTime fromDate, DateTime toDate, int leagueId)
        {
            string leagueName = leagueId == 0 ? "Show All Leagues" : CacheRef.GetLeagueName(leagueId);
            return ResultLang.lblOutrightResult.ToUpper() + " - " + fromDate.ToString("MM/dd/yyyy") + " -> "
               + toDate.ToString("MM/dd/yyyy") + " | " + CacheRef.GetSportName(sportType) + " - " + leagueName;
        }
	}
}