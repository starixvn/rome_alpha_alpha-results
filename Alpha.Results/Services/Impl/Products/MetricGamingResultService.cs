namespace Alpha.Results.Services.Impl.Products
{
    using System;
    using System.IO;
    using System.Linq;
    using Alpha.Results.Criteria;
    using Fanex.Data.Repository;
    using Fanex.Result.Core;
    using Fanex.Result.Core.Base;
    using Fanex.Result.Core.MetricGaming.DTO;
    using Models;

    public class MetricGamingResultService : IProductResultService
    {
        private readonly IDynamicRepository _dynamicRepository;

        public MetricGamingResultService(IDynamicRepository dynamicRepository)
        {
            _dynamicRepository = dynamicRepository ?? new DynamicRepository();
        }

        public MetricGamingResultService()
            : this(null)
        {
        }

        public string GetResult(NormalRequest request)
        {
            throw new NotImplementedException();
        }

        public MemoryStream ExportExcel(NormalRequest request, string excelTemplatePath)
        {
            throw new NotImplementedException();
        }

        public string GetResultDetails(NormalDetailsRequest detailsRequest)
        {
            var criteria = new GetMetricGamingResultCriteria
            {
                TransId = detailsRequest.RefNum,
                BetType = detailsRequest.BetTypeId,
                BetId = detailsRequest.BetId,
                SportType = detailsRequest.SportId
            };

            var resultData = _dynamicRepository.Fetch<MetricGaming>(criteria).ToList();

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

            return resultData.Any() ? ResultEngine.HtmlParser(resultData, resultSetting) : string.Empty;
        }
    }
}