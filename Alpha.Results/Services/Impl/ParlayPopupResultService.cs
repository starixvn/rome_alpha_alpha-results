namespace Alpha.Results.Services.Impl.Result
{
    using Alpha.Results.Criteria;
    using Alpha.Results.Repositories.Impl.Result;
    using Alpha.Results.Repositories;
    using Alpha.Results.Services.Result;
    using Fanex.Result.Core;
    using Fanex.Result.Core.Base;
    using Sunplus.Agent.Model.Entities;
    using System.Linq;

    /// <summary>
    /// The class ParlayPopupResultService.
    /// </summary>
    public class ParlayPopupResultService : IParlayPopupResultService
    {
        private IParlayPopupResultDataAccess _parlayResultDataAccess;

        public ParlayPopupResultService(IParlayPopupResultDataAccess parlayResultDataAccess)
        {
            this._parlayResultDataAccess = parlayResultDataAccess ?? new ParlayPopupResultDataAccess();
        }

        public ParlayPopupResultService()
            : this(null)
        {
        }

        public string GetResult(long refNo)
        {
            var parlayData = this._parlayResultDataAccess.GetParlayResult(new GetParlayPopupResultCriteria
            {
                RefNo = refNo
            });

            return ResultEngine.HtmlParser(parlayData.ToList(), this.GetFanexResultSetting());
        }

        /// <summary>
        /// Gets the FANEX result setting.
        /// </summary>
        /// <returns>The object of ResultSetting.</returns>
        private ResultSetting GetFanexResultSetting()
        {
            return new ResultSetting
            {
                IsOutRight = false,
                IsParlayPopUp = true,
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