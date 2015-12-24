namespace Alpha.Results.Services.Impl.Result
{
    using Alpha.Results.Criteria;
    using Alpha.Results.Repositories;
    using Alpha.Results.Services.Result;
    using Fanex.Result.Core;
    using Fanex.Result.Core.Base;
    using Sunplus.Agent.Model.Entities;

    /// <summary>
    /// The class RacingPopupResultService.
    /// </summary>
    public class RacingPopupResultService : IRacingPopupResultService
    {
        private IRacingPopupResultDataAccess _virtualRacingResultDataAccess;

        public RacingPopupResultService(IRacingPopupResultDataAccess virtualRacingResultDataAccess)
        {
            this._virtualRacingResultDataAccess = virtualRacingResultDataAccess ?? new RacingPopupResultDataAccess();
        }

        public RacingPopupResultService()
            : this(null)
        {
        }

        public string GetResult(int matchId, int raceNumber, int sportType)
        {
            var criteria = GetCriteria(matchId, raceNumber);
            var results = this._virtualRacingResultDataAccess.GetRacingPopupResult(criteria);
            ResultSetting resultSetting = GetFanexResultSetting(sportType);

            return ResultEngine.HtmlParser(results, resultSetting);
        }

        public string GetResultForVirtualRacing(int matchId, int raceNumber, int sportType)
        {
            return this.GetResult(matchId, raceNumber, sportType);
        }

        private static GetRacingPopupResultCriteria GetCriteria(int matchId, int raceNumber)
        {
            return new GetRacingPopupResultCriteria()
            {
                MatchId = matchId,
                RaceNo = raceNumber
            };
        }

        /// <summary>
        /// Gets the FANEX result setting.
        /// </summary>
        /// <param name="sportType">Type of the sport.</param>
        /// <returns>The object of ResultSetting.</returns>
        private static ResultSetting GetFanexResultSetting(int sportType)
        {
            return new ResultSetting
            {
                SportType = (SportType)sportType,
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