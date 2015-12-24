namespace Alpha.Results.Services.Impl.Result
{
    using Alpha.Results.LocalResources;
    using Alpha.Results.Criteria;
    using Alpha.Results.Repositories.Impl.Result;
    using Alpha.Results.Repositories;
    using Alpha.Results.Services.Result;
    using Fanex.Result.Core;
    using Fanex.Result.Core.Base;
    using Fanex.Result.Core.Sportsbook.DTO;
    using Sunplus.Agent.Model.BL.Cache;
    using Sunplus.Agent.Model.Entities;
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;

    /// <summary>
    /// The class SportsBookResultService.
    /// </summary>
    public class SportsbookResultService : ISportsbookResultService
    {
        private ISportsbookResultDataAccess _scoreInformationDataAccess;

        public SportsbookResultService(ISportsbookResultDataAccess scoreInformationDataAccess)
        {
            this._scoreInformationDataAccess = scoreInformationDataAccess ?? new SportsbookResultDataAccess();
        }

        public SportsbookResultService()
            : this(null)
        {
        }

        public string GetResult(DateTime fromDate, int sportType, int leagueId)
        {
            var criteria = GetCriteria(fromDate, sportType, leagueId);
            IList<Sportsbook> sportsbooks = this._scoreInformationDataAccess.GetSportbookResult(criteria);
            ResultSetting resultSetting = GetFanexResultSetting(criteria.SportType > 0 ? criteria.SportType : (int)SportType.Others);

            return ResultEngine.HtmlParser<Sportsbook>(sportsbooks.ToList(), resultSetting).Replace("original-title", " title ");
        }

        public MemoryStream ExportExcel(DateTime fromDate, int sportType, int leagueId, string excelTemplatePath)
        {
            return ResultEngine.ExcelParser(
                this._scoreInformationDataAccess.GetSportbookResult(GetCriteria(fromDate, sportType, leagueId)).ToList(),
                GetExportExcelSetting(sportType, excelTemplatePath, GetExcelTitle(sportType, fromDate, leagueId)));
        }

        private static GetSportsbookResultCriteria GetCriteria(DateTime fromDate, int sportType, int leagueId)
        {
            return new GetSportsbookResultCriteria()
            {
                FromDate = fromDate,
                SportType = sportType,
                IsShowAll = Sunplus.Agent.Model.BL.Definitions.AppSettings.LocalTest,
                LeagueID = leagueId
            };
        }

        /// <summary>
        /// Gets the FANEX result setting.
        /// </summary>
        /// <param name="sportType">Type of the sport.</param>
        /// <returns>Result Setting Model.</returns>
        private static ResultSetting GetFanexResultSetting(int sportType)
        {
            SportType type = (SportType)sportType;
            return new ResultSetting
            {
                SportType = type,
                LanguageCode = UserSession.Current.Language,
                VisibleDetailedLink = type == SportType.Soccer || type == SportType.Tennis,
                VisibleFreeHeader = true,
                VisibleMatchCodeIDColumn = false,
                HighlightWinnerTeam = true
            };
        }

        /// <summary>
        /// Gets the export excel setting.
        /// </summary>
        /// <param name="sportType">Type of the sport.</param>
        /// <param name="excelTemplatePath">The excel template path.</param>
        /// <param name="excelTitle">The excel title.</param>
        /// <returns>Result Setting Model.</returns>
        private static ResultSetting GetExportExcelSetting(int sportType, string excelTemplatePath, string excelTitle)
        {
            return new ResultSetting
            {
                SportType = (SportType)sportType,
                LanguageCode = UserSession.Current.Language,
                ExcelTitle = excelTitle,
                ExcelTemplatePath = excelTemplatePath,
                VisibleMatchCodeIDColumn = false,
                HighlightWinnerTeam = true
            };
        }

        private static string GetExcelTitle(int sportType, DateTime fromDate, int leagueId)
        {
            string leagueName = leagueId == 0 ? "Show All Leagues" : CacheRef.GetLeagueName(leagueId);
            return ResultLang.result + " - " + fromDate.ToString("MM/dd/yyyy")
                + " | " + CacheRef.GetSportName(sportType) + " - " + leagueName;
        }
    }
}