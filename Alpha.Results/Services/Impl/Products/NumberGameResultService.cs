namespace Alpha.Results.Services.Impl.Products
{
    using System.IO;
    using System.Linq;
    using Alpha.Results.Criteria;
    using Alpha.Results.DataAccesses;
    using Commands;
    using DataAccesses.Impl;
    using Fanex.Result.Core;
    using Fanex.Result.Core.Base;

    /// <summary>
    /// The class NumberGameResultService.
    /// </summary>
    public class NumberGameResultService : IProductResultService
    {
        private readonly INumberGameResultDataAccess _numberGameResultDataAccess;

        public NumberGameResultService(INumberGameResultDataAccess numberGameResultDataAccess)
        {
            _numberGameResultDataAccess = numberGameResultDataAccess ?? new NumberGameResultDataAccess();
        }

        public NumberGameResultService()
            : this(null)
        {
        }

        public string GetResult(ViewNormalResultCommand request)
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

        public MemoryStream ExportExcel(ViewNormalResultCommand request, string excelTemplatePath)
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

            var results = _numberGameResultDataAccess.GetNumberGameResults(GetCriteria(request)).ToList();

            return ResultEngine.ExcelParser(results, resultSetting);
        }

        private static GetNumberGameResultCriteria GetCriteria(ViewNormalResultCommand request)
        {
            return new GetNumberGameResultCriteria()
            {
                FromDate = request.ResultDate,
                LeagueID = request.LeagueId,
                Language = request.Language
            };
        }

        public string GetResultDetails(ViewNormalResultDetailsCommand detailsRequest)
        {
            var criteria = new GetNumberGameResultDetailsCriteria
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

            var results = _numberGameResultDataAccess.GetNumberGameResultDetails(criteria);

            return ResultEngine.HtmlParser(results, resultSetting);
        }
    }
}