namespace Alpha.Results.Services.Impl
{
    using System;
    using System.IO;
    using System.Linq;
    using Alpha.Results.Criteria;
    using Alpha.Results.Repositories;
    using Alpha.Results.Repositories.Impl.Result;
    using Fanex.Result.Core;
    using Fanex.Result.Core.Base;
    using Models;

    /// <summary>
    /// The class ParlayPopupResultService.
    /// </summary>
    public class ParlayResultService : IProductResultService
    {
        private IParlayResultDataAccess _parlayResultDataAccess;

        public ParlayResultService(IParlayResultDataAccess parlayResultDataAccess)
        {
            _parlayResultDataAccess = parlayResultDataAccess ?? new ParlayResultDataAccess();
        }

        public ParlayResultService()
            : this(null)
        {
        }

        public string GetResultDetails(NormalDetailsRequest detailsRequest)
        {
            var parlayData = _parlayResultDataAccess.GetParlayResult(new GetParlayPopupResultCriteria
            {
                RefNo = detailsRequest.RefNum
            });

            return ResultEngine.HtmlParser(parlayData.ToList(), this.GetFanexResultSetting(detailsRequest));
        }

        /// <summary>
        /// Gets the FANEX result setting.
        /// </summary>
        /// <returns>The object of ResultSetting.</returns>
        private ResultSetting GetFanexResultSetting(NormalRequest request)
        {
            return new ResultSetting
            {
                IsOutRight = false,
                IsParlayPopUp = true,
                IsPopUp = true,
                VisiblePopUpTitle = false,
                LanguageCode = request.Language,
                VisibleMatchCodeIDColumn = false,
                VisibleFreeHeader = true,
                VisibleDetailedLink = true,
                HighlightWinnerTeam = true
            };
        }

        public string GetResult(NormalRequest request)
        {
            throw new NotImplementedException();
        }

        public MemoryStream ExportExcel(NormalRequest request, string excelTemplatePath)
        {
            throw new NotImplementedException();
        }
    }
}