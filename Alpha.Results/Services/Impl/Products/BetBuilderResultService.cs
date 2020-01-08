namespace Alpha.Results.Site.Services.Impl.Products
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using Alpha.Results.Site.Criteria;
    using Alpha.Results.Site.DataAccesses;
    using DataAccesses.Impl;
    using Fanex.Common.Helper;
    using Fanex.Result.Core.Base;
    using Fanex.Result.Core.Sportsbook.DTO;
    using Models.Requests;

    public class BetBuilderResultService : IProductResultService
    {
        private readonly ISportsbookResultDataAccess _dataAccess;
        private readonly IResultEngineAdapter _resultEngineAdapter;

        public BetBuilderResultService(
            ISportsbookResultDataAccess dataAccess = null,
            IResultEngineAdapter resultEngineAdapter = null)
        {
            //// Still using poorman DI here because result service factory need to create it manual
            _dataAccess = dataAccess ?? new SportsbookResultDataAccess();
            _resultEngineAdapter = resultEngineAdapter ?? new ResultEngineAdapter();
        }

        public string GetResult(NormalResultQuery request)
        {
            throw new NotImplementedException();
        }

        public MemoryStream ExportExcel(ExcelNormalResultQuery request)
        {
            throw new NotImplementedException();
        }

        public string GetResultDetails(NormalResultDetailsQuery detailsRequest)
        {
            Check.Argument.IsNotNull(detailsRequest, "detailsRequest");
            var results = new List<Sportsbook> { GetBetBuilder(detailsRequest) };

            var resultSetting = new ResultSetting
            {
                SportType = (SportType)detailsRequest.SportId,
                IsOutright = false,
                IsParlayPopUp = false,
                IsPopUp = true,
                IsPopupOpenFromBetList = true,
                LanguageCode = detailsRequest.Language,
                VisibleMatchCodeIDColumn = false,
                HighlightWinnerTeam = true
            };

            return _resultEngineAdapter.HtmlParser(results, resultSetting).Replace("original-title", " title ");
        }

        private Sportsbook GetBetBuilder(NormalResultDetailsQuery detailsRequest)
        {
            var criteria = new GetBetBuidlerResultDetailsCriteria
            {
                MarketId = (int)detailsRequest.BetId,
                MatchId = detailsRequest.MatchId
            };

            return _dataAccess.GetBetBuilderInformation(criteria);
        }        
    }
}
