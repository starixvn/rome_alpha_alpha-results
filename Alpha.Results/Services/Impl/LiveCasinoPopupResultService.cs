namespace Alpha.Results.Services.Impl.Result
{
    using Alpha.Results.Criteria;
    using Alpha.Results.Repositories.Impl.Result;
    using Alpha.Results.Repositories;
    using Alpha.Results.Services.Result;
    using Fanex.Result.Core;
    using Fanex.Result.Core.Base;
    using System.Linq;
    using Sunplus.Agent.Model.Entities;
    using Fanex.Data.Repository;
    using Fanex.Result.Core.LiveCasino.DTO;    /// <summary>
                                               /// The class LiveCasinoPopupResultService.
                                               /// </summary>
    public class LiveCasinoPopupResultService : ILiveCasinoPopupResultService
    {
        private IDynamicRepository _dynamicRepository;

        public LiveCasinoPopupResultService(IDynamicRepository dynamicRepository)
        {
            this._dynamicRepository = dynamicRepository ?? new DynamicRepository();
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

            var resultSetting = new ResultSetting
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

            var liveCasinoResults = this._dynamicRepository
                                        .Fetch<LiveCasino>(criteria)
                                        .Select<LiveCasino, LiveCasino>(result =>
                                        {
                                            result.Bettype = betType;
                                            return result;
                                        }).ToList();

            return ResultEngine.HtmlParser(liveCasinoResults, resultSetting);
        }
    }
}