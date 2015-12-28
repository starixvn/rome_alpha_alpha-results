namespace Alpha.Results.Services.Impl.Products
{
    using System.IO;
    using System.Linq;
    using Alpha.Results.Criteria;
    using Alpha.Results.LocalResources;
    using Alpha.Results.Repositories;
    using Alpha.Results.Repositories.Impl.Result;
    using Fanex.Result.Core;
    using Fanex.Result.Core.Base;
    using Models;
    using Sunplus.Agent.Model.BL.Cache;
    using Sunplus.Agent.Model.Entities;

    /// <summary>
    /// The class NumberGameResultService.
    /// </summary>
    public class NumberGameResultService : IProductResultService
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

        public string GetResult(NormalRequest request)
        {
            var resultSetting = new ResultSetting
            {
                SportType = (SportType)request.SportId,
                LanguageCode = UserSession.Current.Language,
                VisibleDetailedLink = true,
                VisibleFreeHeader = true,
                VisibleMatchCodeIDColumn = false,
                HighlightWinnerTeam = true
            };

            return ResultEngine.HtmlParser(
                _numberGameResultDataAccess.GetNumberGameResult(GetCriteria(request)).ToList(),
                resultSetting);
        }

        public MemoryStream ExportExcel(NormalRequest request, string excelTemplatePath)
        {
            var resultSetting = new ResultSetting
            {
                SportType = (SportType)request.SportId,
                LanguageCode = UserSession.Current.Language,
                ExcelTitle = GetExcelTitle(request),
                ExcelTemplatePath = excelTemplatePath,
                VisibleMatchCodeIDColumn = false,
                HighlightWinnerTeam = true
            };

            return ResultEngine.ExcelParser(
                _numberGameResultDataAccess.GetNumberGameResult(GetCriteria(request)).ToList(),
                resultSetting);
        }

        private static GetNumberGameResultCriteria GetCriteria(NormalRequest request)
        {
            return new GetNumberGameResultCriteria()
            {
                FromDate = request.ResultDate,
                LeagueID = request.LeagueId,
                Language = UserSession.Current.Language
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
            var criteria = new GetNumberGamePopupResultCriteria
            {
                MatchID = detailsRequest.MatchId
            };

            var resultSetting = new ResultSetting
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
            };

            return ResultEngine.HtmlParser(
                _numberGameResultDataAccess.GetNumberGamePopupResult(criteria),
                resultSetting);
        }
    }
}