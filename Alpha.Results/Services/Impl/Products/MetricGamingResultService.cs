namespace Alpha.Results.Services.Impl.Products
{
    using System;
    using System.IO;
    using Alpha.Results.Criteria;
    using Commands;
    using DataAccesses;
    using DataAccesses.Impl;
    using Fanex.Result.Core;
    using Fanex.Result.Core.Base;

    public class MetricGamingResultService : IProductResultService
    {
        private readonly IMetricGamingResultDataAccess _dataAccess;

        public MetricGamingResultService(IMetricGamingResultDataAccess dynamicRepository)
        {
            _dataAccess = dynamicRepository ?? new MetricGamingResultDataAccess();
        }

        public MetricGamingResultService()
            : this(null)
        {
        }

        public string GetResult(ViewNormalResultQuery request)
        {
            throw new NotImplementedException();
        }

        public MemoryStream ExportExcel(ViewNormalResultQuery request, string excelTemplatePath)
        {
            throw new NotImplementedException();
        }

        public string GetResultDetails(ViewNormalResultDetailsQuery detailsRequest)
        {
            var criteria = new GetMetricGamingResultCriteria
            {
                TransId = detailsRequest.RefNum,
                BetType = detailsRequest.BetTypeId,
                BetId = detailsRequest.BetId,
                SportType = detailsRequest.SportId
            };

            var results = _dataAccess.GetResults(criteria);

            var resultSetting = new ResultSetting
            {
                SportType = SportType.Soccer,
                IsOutRight = false,
                IsParlayPopUp = false,
                IsPopUp = true,
                LanguageCode = "en-US",
                VisibleMatchCodeIDColumn = false,
                VisiblePopUpTitle = true,
                HighlightWinnerTeam = true
            };

            return ResultEngine.HtmlParser(results, resultSetting);
        }
    }
}