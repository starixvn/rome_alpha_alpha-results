namespace Alpha.Results.Services.Impl
{
    using System;
    using System.IO;
    using System.Linq;
    using Alpha.Results.Criteria;
    using Alpha.Results.DataAccesses;
    using Alpha.Results.DataAccesses.Impl.Result;
    using Fanex.Result.Core;
    using Fanex.Result.Core.Base;
    using Models;

    /// <summary>
    /// The class ParlayPopupResultService.
    /// </summary>
    public class ParlayResultService : IProductResultService
    {
        private readonly IParlayResultDataAccess _parlayResultDataAccess;

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
            var results = _parlayResultDataAccess.GetParlayResults(new GetParlayResultCriteria
            {
                RefNo = detailsRequest.RefNum
            }).ToList();

            var resultSetting = new ResultSetting
            {
                IsOutRight = false,
                IsParlayPopUp = true,
                IsPopUp = true,
                VisiblePopUpTitle = false,
                LanguageCode = detailsRequest.Language,
                VisibleMatchCodeIDColumn = false,
                VisibleFreeHeader = true,
                VisibleDetailedLink = true,
                HighlightWinnerTeam = true
            };

            return ResultEngine.HtmlParser(results, resultSetting);
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