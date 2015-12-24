namespace Alpha.Results.Services.Impl.Result
{
    using Alpha.Results.Criteria;
    using Alpha.Results.Models;
    using Alpha.Results.Repositories.Impl.Result;
    using Alpha.Results.Repositories;
    using Alpha.Results.Services.Result;
    using Fanex.Result.Core;
    using Fanex.Result.Core.Base;
    using Fanex.Result.Core.Sportsbook.DTO;
    using Sunplus.Agent.Model.Entities;
    using System.Collections.Generic;

    /// <summary>
    /// The class SportsBookPopupResultService.
    /// </summary>
    public class SportsbookPopupResultService : ISportsbookPopupResultService
    {
        private ISportsbookPopupResultDataAccess _scoreInformationDataAccess;

        public SportsbookPopupResultService(ISportsbookPopupResultDataAccess scoreInformationDataAccess)
        {
            this._scoreInformationDataAccess = scoreInformationDataAccess ?? new SportsbookPopupResultDataAccess();
        }

        public SportsbookPopupResultService()
            : this(null)
        {
        }

        public string GetResult(ResultRequest resultRequest)
        {
            var criteria = GetCriteria(resultRequest);
            List<Sportsbook> sportsbooks = this._scoreInformationDataAccess.GetScoreInformation(ref criteria);
            ResultSetting resultSetting = GetFanexResultSetting(criteria);

            return resultRequest.ViewDetail ?
                ResultEngine.HtmlGameDetailParser(sportsbooks[0], resultSetting).Replace("original-title", " title ") :
                ResultEngine.HtmlParser(sportsbooks, resultSetting).Replace("original-title", " title ");
        }

        private static GetSportsbookPopupResultCriteria GetCriteria(ResultRequest resultRequest)
        {
            return new GetSportsbookPopupResultCriteria()
            {
                MatchId = resultRequest.MatchId,
                BetType = resultRequest.BetType,
                SportType = resultRequest.SportId,
                BetId = resultRequest.BetId,
                IsViewDetail = resultRequest.ViewDetail
            };
        }

        /// <summary>
        /// Gets the FANEX result setting.
        /// </summary>
        /// <param name="criteria">The criteria.</param>
        /// <returns>The object of ResultSetting.</returns>
        private static ResultSetting GetFanexResultSetting(GetSportsbookPopupResultCriteria criteria)
        {
            return new ResultSetting
            {
                SportType = (SportType)criteria.SportType,
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