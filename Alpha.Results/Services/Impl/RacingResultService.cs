namespace Alpha.Results.Services.Impl.Result
{
    using Alpha.Results.LocalResources;
    using Alpha.Results.Criteria;
    using Alpha.Results.Repositories.Impl.Result;
    using Alpha.Results.Repositories;
    using Alpha.Results.Services.Result;
    using Fanex.Result.Core;
    using Fanex.Result.Core.Base;
    using Fanex.Result.Core.Racing.DTO;
    using Sunplus.Agent.Model.BL.Cache;
    using Sunplus.Agent.Model.Entities;
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;

    /// <summary>
    /// The class RacingResultService.
    /// </summary>
    public class RacingResultService : IRacingResultService
    {
        private IRacingResultDataAccess _racingResultDataAccess;

        public RacingResultService(IRacingResultDataAccess racingResultDataAccess)
        {
            this._racingResultDataAccess = racingResultDataAccess ?? new RacingResultDataAccess();
        }

        public RacingResultService()
            : this(null)
        {
        }

        public string GetResult(DateTime fromDate, int sportType, int leagueId)
        {
            var criteria = GetCriteria(fromDate, sportType, leagueId);
            IList<Racing> racings = this._racingResultDataAccess.GetRacingResult(criteria);
            ResultSetting resultSetting = GetFanexResultSetting(criteria.SportType);

            return ResultEngine.HtmlParser<Racing>(racings.ToList(), resultSetting);
        }

        public MemoryStream ExportExcel(DateTime fromDate, int sportType, int leagueId, string excelTemplatePath)
        {
            return ResultEngine.ExcelParser(
                this._racingResultDataAccess.GetRacingResult(GetCriteria(fromDate, sportType, leagueId)).ToList(),
                GetExportExcelSetting(sportType, excelTemplatePath, GetExcelTitle(sportType, fromDate, leagueId)));
        }

        private static GetRacingResultCriteria GetCriteria(DateTime fromDate, int sportType, int leagueId)
        {
            return new GetRacingResultCriteria()
            {
                FromDate = fromDate,
                SportType = sportType,
                IsShowAll = true,
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
            return new ResultSetting
            {
                SportType = (SportType)sportType,
                LanguageCode = UserSession.Current.Language,
                VisibleDetailedLink = true,
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

        public string GetResultDetails(int matchId, int raceNumber, int sportType)
        {
            var criteria = new GetRacingPopupResultCriteria()
            {
                MatchId = matchId,
                RaceNo = raceNumber
            };
            var results = this._racingResultDataAccess.GetRacingPopupResult(criteria);
            ResultSetting resultSetting = new ResultSetting
            {
                SportType = (SportType)sportType,
                IsOutRight = false,
                IsParlayPopUp = false,
                IsPopUp = true,
                VisiblePopUpTitle = false,
                LanguageCode = UserSession.Current.Language,
                VisibleMatchCodeIDColumn = false,
                VisibleFreeHeader = true,
                VisibleDetailedLink = true,
                HighlightWinnerTeam = true
            };

            return ResultEngine.HtmlParser(results, resultSetting);
        }

        public string GetResultForVirtualRacing(int matchId, int raceNumber, int sportType)
        {
            return this.GetResultDetails(matchId, raceNumber, sportType);
        }
    }
}