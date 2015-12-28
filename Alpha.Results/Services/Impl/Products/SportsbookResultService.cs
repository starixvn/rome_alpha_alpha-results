namespace Alpha.Results.Services.Impl.Products
{
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using Alpha.Results.Criteria;
    using Alpha.Results.Repositories;
    using Alpha.Results.Repositories.Impl.Result;
    using Fanex.Result.Core;
    using Fanex.Result.Core.Base;
    using Fanex.Result.Core.Sportsbook.DTO;
    using Models;

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

            var sportId = criteria.SportType > 0 ? criteria.SportType : (int)SportType.Others;

            ResultSetting resultSetting = GetFanexResultSetting(sportId, request.Language);

            return ResultEngine.HtmlParser(sportsbooks.ToList(), resultSetting).Replace("original-title", " title ");
        }

        public MemoryStream ExportExcel(NormalRequest request, string excelTemplatePath)
        {
            var exportExcelSetting = new ResultSetting
            {
                SportType = (SportType)request.SportId,
                LanguageCode = request.Language,
                ExcelTitle = request.ToExcelTitle(),
                ExcelTemplatePath = excelTemplatePath,
                VisibleMatchCodeIDColumn = false,
                HighlightWinnerTeam = true
            };

            return ResultEngine.ExcelParser(
                this._dataAccess.GetSportbookResult(GetCriteria(request)).ToList(),
                exportExcelSetting);
        }

        private static GetSportsbookResultCriteria GetCriteria(NormalRequest request)
        {
            return new GetSportsbookResultCriteria()
            {
                FromDate = request.ResultDate,
                SportType = request.SportId,
                IsShowAll = false,
                LeagueID = request.LeagueId
            };
        }

        /// <summary>
        /// Gets the FANEX result setting.
        /// </summary>
        /// <param name="sportType">Type of the sport.</param>
        /// <returns>Result Setting Model.</returns>
        private static ResultSetting GetFanexResultSetting(int sportType, string language)
        {
            SportType type = (SportType)sportType;
            return new ResultSetting
            {
                SportType = type,
                LanguageCode = language,
                VisibleDetailedLink = type == SportType.Soccer || type == SportType.Tennis,
                VisibleFreeHeader = true,
                VisibleMatchCodeIDColumn = false,
                HighlightWinnerTeam = true
            };
        }

        public string GetResultDetails(NormalDetailsRequest detailsRequest)
        {
            var criteria = new GetSportsbookPopupResultCriteria()
            {
                MatchId = detailsRequest.MatchId,
                BetType = detailsRequest.BetTypeId,
                SportType = detailsRequest.SportId,
                BetId = detailsRequest.BetId,
                IsViewDetail = true
            };

            List<Sportsbook> sportsbooks = _dataAccess.GetScoreInformation(ref criteria);

            ResultSetting resultSetting = GetResultDetailsSetting(detailsRequest);

            return ResultEngine.HtmlGameDetailParser(sportsbooks[0], resultSetting)
                .Replace("original-title", " title ");
        }

        /// <summary>
        /// Gets the FANEX result setting.
        /// </summary>
        /// <param name="criteria">The criteria.</param>
        /// <returns>The object of ResultSetting.</returns>
        private static ResultSetting GetResultDetailsSetting(NormalRequest request)
        {
            return new ResultSetting
            {
                SportType = (SportType)request.SportId,
                IsOutRight = false,
                IsParlayPopUp = false,
                IsPopUp = true,
                LanguageCode = request.Language,
                VisibleMatchCodeIDColumn = false,
                HighlightWinnerTeam = true
            };
        }
    }
}