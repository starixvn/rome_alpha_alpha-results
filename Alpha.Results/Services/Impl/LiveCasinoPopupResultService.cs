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
    /// The class LiveCasinoPopupResultService.
    /// </summary>
    public class LiveCasinoPopupResultService : ILiveCasinoPopupResultService
    {
        private ILiveCasinoPopupResultDataAccess _liveCasinoPopupResultDataAccess;

        public LiveCasinoPopupResultService(ILiveCasinoPopupResultDataAccess liveCasinoPopupResultDataAccess)
        {
            this._liveCasinoPopupResultDataAccess = liveCasinoPopupResultDataAccess ?? new LiveCasinoPopupResultDataAccess();
        }

        public LiveCasinoPopupResultService()
            : this(null)
        {
        }

        public string GetResult(int matchId, int betType, string league)
        {
            var criteria = new GetLiveCasinoPopupResultCriteria()
            {
                MatchId = matchId,
                BetType = betType,
                League = league
            };

            return ResultEngine.HtmlParser(this._liveCasinoPopupResultDataAccess.GetLiveCasinoPopupResult(criteria), GetFanexResultSetting());
        }

        /// <summary>
        /// Gets the FANEX result setting.
        /// </summary>
        /// <returns>The object of ResultSetting.</returns>
        private static ResultSetting GetFanexResultSetting()
        {
            return new ResultSetting
            {
                SportType = SportType.LiveCasino,
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