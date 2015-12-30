namespace Alpha.Results.Services.Impl.Products
{
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using Alpha.Results.Criteria;
    using Alpha.Results.DataAccesses;
    using DataAccesses.Impl;
    using Fanex.Result.Core;
    using Fanex.Result.Core.Base;
    using Fanex.Result.Core.Sportsbook.DTO;
    using Models.Requests;

    /// <summary>
    /// The class SportsBookResultService.
    /// </summary>
    public class SportsbookResultService : IProductResultService
    {
        private readonly ISportsbookResultDataAccess _dataAccess;

        public SportsbookResultService(ISportsbookResultDataAccess dataAccess)
        {
            this._dataAccess = dataAccess ?? new SportsbookResultDataAccess();
        }

        public SportsbookResultService()
            : this(null)
        {
        }

        public string GetResult(ViewNormalResultQuery request)
        {
            var criteria = GetCriteria(request);

            var results = request.SportId == 0 ? new List<Sportsbook>() : _dataAccess.GetSportbookResults(criteria).ToList();

            var sportType = request.SportId > 0 ? (SportType)request.SportId : SportType.Others;

            var resultSetting = new ResultSetting
            {
                SportType = sportType,
                LanguageCode = request.Language,
                VisibleDetailedLink = sportType == SportType.Soccer || sportType == SportType.Tennis,
                VisibleFreeHeader = true,
                VisibleMatchCodeIDColumn = false,
                HighlightWinnerTeam = true
            };

            return ResultEngine.HtmlParser(results, resultSetting).Replace("original-title", " title ");
        }

        public MemoryStream ExportExcel(DownloadNormalResultExcelQuery request)
        {
            var exportExcelSetting = new ResultSetting
            {
                SportType = (SportType)request.SportId,
                LanguageCode = request.Language,
                ExcelTitle = request.ExcelTitle,
                ExcelTemplatePath = request.TemplatePath,
                VisibleMatchCodeIDColumn = false,
                HighlightWinnerTeam = true
            };

            var results = _dataAccess.GetSportbookResults(GetCriteria(request)).ToList();

            return ResultEngine.ExcelParser(results, exportExcelSetting);
        }

        private static GetSportsbookResultCriteria GetCriteria(ViewNormalResultQuery request)
        {
            return new GetSportsbookResultCriteria()
            {
                FromDate = request.ResultDate,
                SportType = request.SportId,
                LeagueID = request.LeagueId
            };
        }

        public string GetResultDetails(ViewNormalResultDetailsQuery detailsRequest)
        {
            var criteria = new GetSportsbookResultDetailsCriteria()
            {
                MatchId = detailsRequest.MatchId,
                BetType = detailsRequest.BetTypeId,
                SportType = detailsRequest.SportId,
                BetId = detailsRequest.BetId,
                IsViewResultFromBetList = detailsRequest.IsViewResultFromBetList
            };

            var results = _dataAccess.GetScoreInformation(ref criteria);

            var resultSetting = new ResultSetting
            {
                SportType = (SportType)detailsRequest.SportId,
                IsOutRight = false,
                IsParlayPopUp = false,
                IsPopUp = true,
                LanguageCode = detailsRequest.Language,
                VisibleMatchCodeIDColumn = false,
                HighlightWinnerTeam = true
            };

            return detailsRequest.IsViewResultFromBetList
                ? ResultEngine.HtmlParser(results, resultSetting).Replace("original-title", " title ")
                : ResultEngine.HtmlGameDetailParser(results[0], resultSetting).Replace("original-title", " title ");
        }
    }
}