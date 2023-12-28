namespace Alpha.Results.Site.Services.Impl.Products
{
    using System;
    using System.IO;
    using System.Linq;
    using Alpha.Results.Site.Criteria;
    using Fanex.Data.Repository;
    using Fanex.Result.Core.Base;
    using Fanex.Result.Core.MetricGaming.DTO;
    using Models.Requests;

    public class MetricGamingResultService : IProductResultService
    {
        private readonly IDynamicRepository _repository;
        private readonly IResultEngineAdapter _resultEngineAdapter;

        public MetricGamingResultService(
            IDynamicRepository repository = null,
            IResultEngineAdapter resultEngineAdapter = null)
        {
            //// Still using poorman DI here because result service factory need to create it manual
            _repository = repository ?? new DynamicRepository();
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

        public ResultDetailModel GetResultDetails(NormalResultDetailsQuery detailsRequest)
        {
            if (detailsRequest == null)
            {
                throw new ArgumentNullException(nameof(detailsRequest), "Request cannot be null");
            }

            var criteria = new GetMetricGamingResultCriteria
            {
                TransId = detailsRequest.RefNum,
                BetType = detailsRequest.BetTypeId,
                BetId = detailsRequest.BetId,
                SportType = detailsRequest.SportId
            };

            var results = _repository.Fetch<MetricGaming>(criteria).ToList();

            var resultSetting = new ResultSetting
            {
                SportType = SportType.Soccer,
                IsOutright = false,
                IsParlayPopUp = false,
                IsPopUp = true,
                LanguageCode = "en-US",
                VisibleMatchCodeIDColumn = false,
                VisiblePopUpTitle = true,
                HighlightWinnerTeam = true
            };

            return new ResultDetailModel(_resultEngineAdapter.HtmlParser(results, resultSetting));
        }
    }
}