namespace Alpha.Results.Site.Services.Impl
{
    using System;
    using System.IO;
    using System.Linq;
    using Alpha.Results.Site.Criteria;
    using Alpha.Results.Site.DataAccesses;
    using DataAccesses.Impl;
    using Fanex.Result.Core;
    using Fanex.Result.Core.Base;
    using Models.Requests;

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

        public string GetResultDetails(ViewNormalResultDetailsQuery detailsRequest)
        {
            var results = _parlayResultDataAccess.GetParlayResults(new GetParlayResultCriteria
            {
                RefNo = detailsRequest.RefNum
            }).ToList();

            var resultSetting = new ResultSetting
            {
                IsOutright = false,
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

        public string GetResult(ViewNormalResultQuery request)
        {
            throw new NotImplementedException();
        }

        public MemoryStream ExportExcel(DownloadNormalResultExcelQuery request)
        {
            throw new NotImplementedException();
        }
    }
}