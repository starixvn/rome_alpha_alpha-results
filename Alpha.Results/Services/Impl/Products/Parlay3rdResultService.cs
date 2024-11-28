namespace Alpha.Results.Site.Services.Impl.Products
{
    using System;
    using System.IO;
    using System.Linq;
    using Alpha.Results.Site.Criteria;
    using Alpha.Results.Site.DataAccesses;
    using Alpha.Results.Site.Models;
    using AlphaPlus.Configurations;
    using DataAccesses.Impl;
    using Fanex.Result.Core.Base;
    using Impl;
    using Models.Requests;

    public class Parlay3rdResultService : IProductResultService
    {
        private readonly IParlayResultDataAccess _parlayResultDataAccess;
        private readonly IResultEngineAdapter _resultEngineAdapter;

        public Parlay3rdResultService(
            IParlayResultDataAccess parlayResultDataAccess = null,
            IResultEngineAdapter resultEngineAdapter = null)
        {
            //// Still using poorman DI here because result service factory need to create it manual
            _parlayResultDataAccess = parlayResultDataAccess ?? new ParlayResultDataAccess();
            _resultEngineAdapter = resultEngineAdapter ?? new ResultEngineAdapter();
        }

        public ResultDetailModel GetResultDetails(NormalResultDetailsQuery detailsRequest)
        {
            if (detailsRequest == null)
            {
                throw new ArgumentNullException(nameof(detailsRequest), "Detail Request cannot be null");
            }

            var results = _parlayResultDataAccess.GetParlay3rdResults(new GetParlay3rdResultCriteria
            {
                RefNo = detailsRequest.RefNum
            }).ToList();

            var resultSetting = new ResultSetting
            {
                IsPopupOpenFromBetList = detailsRequest.IsViewResultFromBetList,
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

            return new ResultDetailModel(_resultEngineAdapter.HtmlParser(results, resultSetting));
        }        

        public string GetResult(NormalResultQuery request)
        {
            throw new NotImplementedException();
        }

        public MemoryStream ExportExcel(ExcelNormalResultQuery request)
        {
            throw new NotImplementedException();
        }
    }
}