namespace Alpha.Results.Site.Services.Impl.Products
{
    using System;
    using System.IO;
    using System.Linq;
    using Alpha.Results.Site.Criteria;
    using Fanex.Data.Repository;
    using Fanex.Result.Core;
    using Fanex.Result.Core.Base;
    using Fanex.Result.Core.GoldDeluxe.DTO;
    using Models.Requests;

    public class GoldDeluxePopupResultService : IProductResultService
    {
        private readonly IDynamicRepository _dynamicRepository;

        public GoldDeluxePopupResultService(IDynamicRepository dynamicRepository = null)
        {
            _dynamicRepository = dynamicRepository ?? new DynamicRepository();
        }

        public MemoryStream ExportExcel(DownloadNormalResultExcelQuery request)
        {
            throw new NotImplementedException();
        }

        public string GetResult(ViewNormalResultQuery request)
        {
            throw new NotImplementedException();
        }

        public string GetResultDetails(ViewNormalResultDetailsQuery detailsRequest)
        {
            var criteria = new GetGoldDeluxeResultCriteria { TransId = detailsRequest.RefNum, BetType = detailsRequest.BetTypeId };

            var goldDeluxeResults = _dynamicRepository
                .Fetch<GoldDeluxe>(criteria)
                .Select(result =>
                {
                    result.Bettype = detailsRequest.BetTypeId;
                    return result;
                }).ToList();

            var resultSetting = new ResultSetting
            {
                SportType = SportType.GoldDeluxe,
				IsOutright = false,
                IsParlayPopUp = false,
                IsPopUp = true,
                LanguageCode = detailsRequest.Language,
                VisibleMatchCodeIDColumn = false,
                HighlightWinnerTeam = true
            };

            return ResultEngine.HtmlParser(goldDeluxeResults, resultSetting);
        }
    }
}