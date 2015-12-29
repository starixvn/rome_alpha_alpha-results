namespace Alpha.Results.Services.Impl
{
	using System;
	using System.Collections.Generic;
	using System.IO;
	using System.Linq;
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

	public class OutrightResultService : ReportService, IOutrightResultService
    {
        private readonly IDynamicRepository _dynamicRepository;

        public OutrightResultService(IDynamicRepository dynamicRepository = null)
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

			return _dynamicRepository.Fetch<OutRight>(criteria);
		}

		public string GetResults(IEnumerable<OutRight> outrights, OutrightRequest request)
		{
			Check.Argument.IsNotNull(outrights, "outrights");
			Check.Argument.IsNotNull(request, "request");

			outrights = FilterOutright(outrights, request.SportType, request.LeagueId);

			return ResultEngine.HtmlParser(outrights.ToList(), OutRightResultSetting(request.Language));
		}

		public MemoryStream GetExcelResults(IEnumerable<OutRight> outrights, OutrightRequest request, string templatePath)
		{
			Check.Argument.IsNotNull(outrights, "outrights");
			Check.Argument.IsNotNull(request, "request");
			Check.Argument.IsNotNull(templatePath, "templatePath");
			Check.Argument.IsNotEmpty(templatePath, "templatePath");

			string excelTitle = GetExcelTitle(request.FromDate, request.ToDate, request.SportType, request.LeagueId);
			outrights = FilterOutright(outrights, request.SportType, request.LeagueId);

			return ResultEngine.ExcelParser(outrights.ToList(), OutRightExcelSetting(request.Language, templatePath, excelTitle));
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
            string leagueName = leagueId == 0 ? ResultLang.ShowAllLeaguesExcelTitle : CacheRef.GetLeagueName(leagueId);

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