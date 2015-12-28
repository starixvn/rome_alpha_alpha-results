namespace Alpha.Results.Services.Impl.Products
{
    using System.IO;
    using System.Linq;
    using Alpha.Results.Criteria;
    using Alpha.Results.Repositories;
    using Alpha.Results.Repositories.Impl.Result;
    using Fanex.Result.Core;
    using Fanex.Result.Core.Base;
    using Models;

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
                LanguageCode = request.Language,
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
                LanguageCode = request.Language,
                ExcelTitle = request.ToExcelTitle(),
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
                Language = request.Language
            };
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
                LanguageCode = detailsRequest.Language,
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