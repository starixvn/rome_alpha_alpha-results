namespace Alpha.Results.Services.Impl
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using Alpha.Results.Criteria;
    using Alpha.Results.LocalResources;
    using Fanex.Data.Repository;
    using Fanex.Result.Core;
    using Fanex.Result.Core.Base;
    using Fanex.Result.Core.Sportsbook.DTO;
    using Sunplus.Agent.Model.BL.Cache;
    using Sunplus.Agent.Model.Entities;

    /// <summary>
    /// The class OutRightResultService.
    /// </summary>
    public class OutRightResultService : IOutRightResultService
    {
        private IDynamicRepository _dynamicRepository;

        public OutRightResultService(IDynamicRepository dynamicRepository)
        {
            this._dynamicRepository = dynamicRepository ?? new DynamicRepository();
        }

        public OutRightResultService()
            : this(null)
        {
        }

        /// <summary>
        /// Gets the result.
        /// </summary>
        /// <param name="fromDate">The filter of From date.</param>
        /// <param name="toDate">The filter of To date.</param>
        /// <param name="sportId">The sport identifier.</param>
        /// <param name="leagueId">The league identifier.</param>
        /// <param name="outRights">The out rights.</param>
        /// <returns>
        /// The result for OUTRIGHT.
        /// </returns>
        public string GetResult(DateTime fromDate, DateTime toDate, int sportId, int leagueId, out List<OutRight> outRights)
        {
            var criteria = GetCriteria(fromDate, toDate);
            var result = this._dynamicRepository.Fetch<OutRight>(criteria);
            outRights = result.ToList();

            if (sportId != 0)
            {
                result = result.Where(o => o.SportType == sportId);
            }

            if (leagueId != 0)
            {
                result = result.Where(o => o.LeagueId == leagueId);
            }

            ResultSetting resultSetting = GetFanexResultSetting();
            return ResultEngine.HtmlParser<OutRight>(result.ToList(), resultSetting);
        }

        /// <summary>
        /// Exports the excel.
        /// </summary>
        /// <param name="fromDate">The filter from date.</param>
        /// <param name="toDate">The filter to date.</param>
        /// <param name="sportId">The sport identifier.</param>
        /// <param name="leagueId">The league identifier.</param>
        /// <param name="excelTemplatePath">The excel template path.</param>
        /// <returns>The MemoryStream object.</returns>
        public MemoryStream ExportExcel(DateTime fromDate, DateTime toDate, int sportId, int leagueId, string excelTemplatePath)
        {
            var result = this._dynamicRepository.Fetch<OutRight>(GetCriteria(fromDate, toDate));

            if (sportId != 0)
            {
                result = result.Where(o => o.SportType == sportId);
            }

            if (leagueId != 0)
            {
                result = result.Where(o => o.LeagueId == leagueId);
            }

            return ResultEngine.ExcelParser<OutRight>(
                result.ToList(),
                GetExportExcelSetting(excelTemplatePath, GetExcelTitle(sportId, fromDate, toDate, leagueId)));
        }

        private static GetOutRightResultCriteria GetCriteria(DateTime fromDate, DateTime toDate)
        {
            return new GetOutRightResultCriteria
            {
                FromDate = fromDate,
                IsShowAll = true,
                ToDate = toDate
            };
        }

        private static ResultSetting GetFanexResultSetting()
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

        /// <summary>
        /// Gets the export excel setting.
        /// </summary>
        /// <param name="excelTemplatePath">The excel template path.</param>
        /// <param name="excelTitle">The excel title.</param>
        /// <returns>Result Setting Model.</returns>
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