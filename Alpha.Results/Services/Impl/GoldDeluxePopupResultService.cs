namespace Alpha.Results.Services.Impl.Result
{
    using Alpha.Results.Criteria;
    using Alpha.Results.Repositories.Impl.Result;
    using Alpha.Results.Repositories;
    using Alpha.Results.Services.Result;
    using Fanex.Result.Core;
    using Fanex.Result.Core.Base;
    using Fanex.Result.Core.GoldDeluxe.DTO;
    using Sunplus.Agent.Model.Entities;

    public class GoldDeluxePopupResultService : IGoldDeluxePopupResultService
    {
        private IGoldDeluxePopupResultDataAccess _goldDeluxeDataAccess;

        public GoldDeluxePopupResultService(IGoldDeluxePopupResultDataAccess goldDeluxeDataAccess = null)
        {
            _goldDeluxeDataAccess = goldDeluxeDataAccess ?? new GoldDeluxePopupResultDataAccess();
        }

        public string GetPopupResult(long transId, int betType)
        {
            var criteria = new GetGoldDeluxePopupResultCriteria { TransId = transId, BetType = betType };
            var goldDeluxes = _goldDeluxeDataAccess.GetGoldDeluxePopupResult(criteria);

            return ResultEngine.HtmlParser<GoldDeluxe>(goldDeluxes, GetGoldDeluxeResultPopupSettings());
        }

        private ResultSetting GetGoldDeluxeResultPopupSettings()
        {
            return new ResultSetting
            {
                SportType = SportType.GoldDeluxe,
                IsOutRight = false,
                IsParlayPopUp = false,
                IsPopUp = true,
                LanguageCode = UserSession.Current.Language,
                VisibleMatchCodeIDColumn = false,
                HighlightWinnerTeam = true
            };
        }
    }
}