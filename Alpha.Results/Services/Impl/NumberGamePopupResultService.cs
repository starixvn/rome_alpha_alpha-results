namespace Alpha.Results.Services.Impl.Result
{
    using Alpha.Results.Criteria;
    using Alpha.Results.Repositories.Impl.Result;
    using Alpha.Results.Repositories;
    using Alpha.Results.Services.Result;
    using Fanex.Result.Core;
    using Fanex.Result.Core.Base;
    using Sunplus.Agent.Model.Entities;

    /// <summary>
    /// The class NumberGamePopupResultService.
    /// </summary>
    public class NumberGamePopupResultService : INumberGamePopupResultService
    {
        private INumberGamePopupResultDataAccess _numberGamePopupResultDataAccess;

        public NumberGamePopupResultService(INumberGamePopupResultDataAccess numberGamePopupResultDataAccess)
        {
            this._numberGamePopupResultDataAccess = numberGamePopupResultDataAccess ?? new NumberGamePopupResultDataAccess();
        }

        public NumberGamePopupResultService()
            : this(null)
        {
        }

        public string GetResult(int matchId)
        {
            var criteria = new GetNumberGamePopupResultCriteria()
            {
                MatchID = matchId
            };

            return ResultEngine.HtmlParser(this._numberGamePopupResultDataAccess.GetNumberGamePopupResult(criteria), this.GetFanexResultSetting());
        }

        /// <summary>
        /// Gets the FANEX result setting.
        /// </summary>
        /// <returns>The object of ResultSetting.</returns>
        private ResultSetting GetFanexResultSetting()
        {
            return new ResultSetting
            {
                SportType = SportType.NumberGame,
                IsOutRight = false,
                IsParlayPopUp = false,
                IsPopUp = true,
                VisiblePopUpTitle = false,
                LanguageCode = UserSession.Current.Language,
                VisibleMatchCodeIDColumn = false,
                VisibleFreeHeader = true,
                VisibleDetailedLink = true,
                HighlightWinnerTeam = true
            };
        }
    }
}