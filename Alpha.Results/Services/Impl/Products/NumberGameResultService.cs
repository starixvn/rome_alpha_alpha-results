namespace Alpha.Results.Site.Services.Impl.Products
{
    using System.IO;
    using System.Linq;
    using Alpha.Results.Site.Criteria;
    using Alpha.Results.Site.DataAccesses;
    using DataAccesses.Impl;
    using Fanex.Result.Core;
    using Fanex.Result.Core.Base;
    using Models.Requests;

    /// <summary>
    /// The class NumberGameResultService.
    /// </summary>
    public class NumberGameResultService : IProductResultService
    {
        private readonly INumberGameResultDataAccess _numberGameResultDataAccess;

        public NumberGameResultService(INumberGameResultDataAccess numberGameResultDataAccess = null)
        {
            //// Still using poorman DI here because result service factory need to create it manual
            _numberGameResultDataAccess = numberGameResultDataAccess ?? new NumberGameResultDataAccess();
        }

        public string GetResult(NormalResultQuery request)
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

            var results = _numberGameResultDataAccess.GetNumberGameResults(GetCriteria(request)).ToList();

            return ResultEngine.HtmlParser(results, resultSetting);
        }

        public MemoryStream ExportExcel(ExcelNormalResultQuery request)
        {
            var resultSetting = new ResultSetting
            {
                SportType = (SportType)request.SportId,
                LanguageCode = request.Language,
                ExcelTitle = request.ExcelTitle,
                ExcelTemplatePath = request.TemplatePath,
                VisibleMatchCodeIDColumn = false,
                HighlightWinnerTeam = true
            };

            var results = _numberGameResultDataAccess.GetNumberGameResults(GetCriteria(request)).ToList();

            return ResultEngine.ExcelParser(results, resultSetting);
        }

        private static GetNumberGameResultCriteria GetCriteria(NormalResultQuery request)
        {
            return new GetNumberGameResultCriteria()
            {
                FromDate = request.ResultDate,
                LeagueID = request.LeagueId,
                Language = request.Language
            };
        }

        public string GetResultDetails(NormalResultDetailsQuery detailsRequest)
        {
            var criteria = new GetNumberGameResultDetailsCriteria
            {
                MatchID = detailsRequest.MatchId
            };

            var resultSetting = new ResultSetting
            {
                SportType = SportType.NumberGame,
				IsOutright = false,
                IsParlayPopUp = false,
                IsPopUp = true,
                VisiblePopUpTitle = false,
                LanguageCode = detailsRequest.Language,
                VisibleMatchCodeIDColumn = false,
                VisibleFreeHeader = true,
                VisibleDetailedLink = true,
                HighlightWinnerTeam = true
            };

            var results = _numberGameResultDataAccess.GetNumberGameResultDetails(criteria);

            return ResultEngine.HtmlParser(results, resultSetting);
        }
    }
}