namespace Alpha.Results.Services.Impl.Result
{
    using System.Linq;
    using Alpha.Results.Criteria;
    using Alpha.Results.Services.Result;
    using Fanex.Data.Repository;
    using Fanex.Result.Core;
    using Fanex.Result.Core.Base;
    using Fanex.Result.Core.MetricGaming.DTO;

    public class MetricGamingResultService : IMetricGamingResultService
    {
        private IDynamicRepository _dynamicRepository;

        public MetricGamingResultService(IDynamicRepository dynamicRepository)
        {
            this._dynamicRepository = dynamicRepository ?? new DynamicRepository();
        }

        public MetricGamingResultService()
            : this(null)
        {
        }

        public string GetResult(GetMetricGamingResultCriteria criteria)
        {
            var resultData = this._dynamicRepository.Fetch<MetricGaming>(criteria).ToList();
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

            if (resultData != null && resultData.Count > 0)
            {
                return ResultEngine.HtmlParser(resultData, resultSetting);
            }

            return string.Empty;
        }
    }
}