namespace Alpha.Results.Services.Impl.Result
{
    using Alpha.Results.LocalResources;
    using Alpha.Results.Criteria;
    using Alpha.Results.Repositories.Impl.Result;
    using Alpha.Results.Repositories;
    using Alpha.Results.Services.Result;
    using Fanex.Result.Core;
    using Fanex.Result.Core.Base;
    using Sunplus.Agent.Model.BL.Cache;
    using Sunplus.Agent.Model.Entities;
    using System;
    using System.IO;
    using System.Linq;

    /// <summary>
    /// The class NumberGameResultService.
    /// </summary>
    public class NumberGameResultService : INumberGameResultService
    {
        private INumberGameResultDataAccess _numberGameResultDataAccess;

        public NumberGameResultService(INumberGameResultDataAccess numberGameResultDataAccess)
        {
            this._numberGameResultDataAccess = numberGameResultDataAccess ?? new NumberGameResultDataAccess();
        }

        public NumberGameResultService()
            : this(null)
        {
        }

        public string GetResult(DateTime fromDate, int leagueId, int sportType)
        {
            return ResultEngine.HtmlParser(
                this._numberGameResultDataAccess.GetNumberGameResult(GetCriteria(fromDate, leagueId)).ToList(),
                GetFanexResultSetting(sportType));
        }

        public MemoryStream ExportExcel(DateTime fromDate, int sportType, int leagueId, string excelTemplatePath)
        {
            return ResultEngine.ExcelParser(
                this._numberGameResultDataAccess.GetNumberGameResult(GetCriteria(fromDate, leagueId)).ToList(),
                GetExportExcelSetting(sportType, excelTemplatePath, GetExcelTitle(sportType, fromDate, leagueId)));
        }

        private static GetNumberGameResultCriteria GetCriteria(DateTime fromDate, int leagueId)
        {
            return new GetNumberGameResultCriteria()
            {
                FromDate = fromDate,
                LeagueID = leagueId,
                Language = UserSession.Current.Language
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

        public string GetResultDetails(int matchId)
        {
            var criteria = new GetNumberGamePopupResultCriteria()
            {
                MatchID = matchId
            };

            return ResultEngine.HtmlParser(
                this._numberGameResultDataAccess.GetNumberGamePopupResult(criteria),
                new ResultSetting
                {
                    SportType = SportType.NumberGame,
                    IsOutRight = false,
                    IsParlayPopUp = false,
                    IsPopUp = true,
                    VisiblePopUpTitle = false,
                    LanguageCode = UserSession.Current.Language,
                    VisibleMatchCodeIDColumn = false,
                    VisibleFreeHeader = true,
                    VisibleDetailedLink = true,
                    HighlightWinnerTeam = true
                });
        }
    }
}