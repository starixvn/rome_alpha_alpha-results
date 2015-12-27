namespace Alpha.Results.Services.Impl.Result
{
    using Alpha.Results.Criteria;
    using Alpha.Results.Repositories.Impl.Result;
    using Alpha.Results.Repositories;
    using System.Linq;
    using Alpha.Results.Services.Result;
    using Fanex.Result.Core;
    using Fanex.Result.Core.Base;
    using Fanex.Result.Core.GoldDeluxe.DTO;
    using Sunplus.Agent.Model.Entities;
    using Fanex.Data.Repository;
    public class GoldDeluxePopupResultService : IGoldDeluxePopupResultService
    {
        private IDynamicRepository _dynamicRepository;

        public GoldDeluxePopupResultService(IDynamicRepository dynamicRepository = null)
        {
            _dynamicRepository = dynamicRepository ?? new DynamicRepository();
        }

        public string GetPopupResult(long transId, int betType)
        {
            var criteria = new GetGoldDeluxePopupResultCriteria { TransId = transId, BetType = betType };

            var goldDeluxeResults = _dynamicRepository
                .Fetch<GoldDeluxe>(criteria)
                .Select(result =>
                {
                    result.Bettype = betType;
                    return result;
                }).ToList();

            var resultSetting = new ResultSetting
            {
                SportType = SportType.GoldDeluxe,
                IsOutRight = false,
                IsParlayPopUp = false,
                IsPopUp = true,
                LanguageCode = UserSession.Current.Language,
                VisibleMatchCodeIDColumn = false,
                HighlightWinnerTeam = true
            };

            return ResultEngine.HtmlParser(goldDeluxeResults, resultSetting);
        }
    }
}