namespace Alpha.Results.Services.Impl.Products
{
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using Alpha.Results.Criteria;
    using Alpha.Results.LocalResources;
    using Alpha.Results.Repositories;
    using Alpha.Results.Repositories.Impl.Result;
    using Fanex.Result.Core;
    using Fanex.Result.Core.Base;
    using Fanex.Result.Core.Sportsbook.DTO;
    using Models;
    using Sunplus.Agent.Model.BL.Cache;
    using Sunplus.Agent.Model.Entities;

    /// <summary>
    /// The class SportsBookResultService.
    /// </summary>
    public class SportsbookResultService : IProductResultService
    {
        private ISportsbookResultDataAccess _dataAccess;

        public SportsbookResultService(ISportsbookResultDataAccess dataAccess)
        {
            this._dataAccess = dataAccess ?? new SportsbookResultDataAccess();
        }

        public SportsbookResultService()
            : this(null)
        {
        }

        public string GetResult(NormalRequest request)
        {
            var criteria = GetCriteria(request);

            IList<Sportsbook> sportsbooks = 
                request.SportId == 0 ? 
                new List<Sportsbook>() : 
                _dataAccess.GetSportbookResult(criteria);

            ResultSetting resultSetting = GetFanexResultSetting(criteria.SportType > 0 ? criteria.SportType : (int)SportType.Others);

            return ResultEngine.HtmlParser<Sportsbook>(sportsbooks.ToList(), resultSetting).Replace("original-title", " title ");
        }

        public MemoryStream ExportExcel(NormalRequest request, string excelTemplatePath)
        {
            return ResultEngine.ExcelParser(
                this._dataAccess.GetSportbookResult(GetCriteria(request)).ToList(),
                GetExportExcelSetting(request.SportId, excelTemplatePath, GetExcelTitle(request)));
        }

        private static GetSportsbookResultCriteria GetCriteria(NormalRequest request)
        {
            return new GetSportsbookResultCriteria()
            {
                FromDate = request.ResultDate,
                SportType = request.SportId,
                IsShowAll = Sunplus.Agent.Model.BL.Definitions.AppSettings.LocalTest,
                LeagueID = request.LeagueId
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

        private static string GetExcelTitle(NormalRequest request)
        {
            string leagueName = request.LeagueId == 0 ? "Show All Leagues" : CacheRef.GetLeagueName(request.LeagueId);
            return ResultLang.result + " - " + request.ResultDate.ToString("MM/dd/yyyy")
                + " | " + CacheRef.GetSportName(request.SportId) + " - " + leagueName;
        }

        public string GetResultDetails(NormalDetailsRequest detailsRequest)
        {
            var criteria = GetResultDetailsCriteria(detailsRequest);
            List<Sportsbook> sportsbooks = this._dataAccess.GetScoreInformation(ref criteria);
            ResultSetting resultSetting = GetResultDetailsSetting(criteria);

            return detailsRequest.ViewDetail ?
                ResultEngine.HtmlGameDetailParser(sportsbooks[0], resultSetting).Replace("original-title", " title ") :
                ResultEngine.HtmlParser(sportsbooks, resultSetting).Replace("original-title", " title ");
        }

        private static GetSportsbookPopupResultCriteria GetResultDetailsCriteria(NormalDetailsRequest detailsRequest)
        {
            return new GetSportsbookPopupResultCriteria()
            {
                MatchId = detailsRequest.MatchId,
                BetType = detailsRequest.BetType,
                SportType = detailsRequest.SportId,
                BetId = detailsRequest.BetId,
                IsViewDetail = detailsRequest.ViewDetail
            };
        }

        /// <summary>
        /// Gets the FANEX result setting.
        /// </summary>
        /// <param name="criteria">The criteria.</param>
        /// <returns>The object of ResultSetting.</returns>
        private static ResultSetting GetResultDetailsSetting(GetSportsbookPopupResultCriteria criteria)
        {
            return new ResultSetting
            {
                SportType = (SportType)criteria.SportType,
                IsOutRight = false,
                IsParlayPopUp = false,
                IsPopUp = true,
                LanguageCode = UserSession.Current.Language,
                VisibleMatchCodeIDColumn = false,
                HighlightWinnerTeam = true
            };
        }
    }
}