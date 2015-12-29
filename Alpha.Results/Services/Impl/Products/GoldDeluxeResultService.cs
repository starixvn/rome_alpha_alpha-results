namespace Alpha.Results.Services.Impl.Products
{
    using System;
    using System.IO;
    using System.Linq;
    using Alpha.Results.Criteria;
    using Commands;
    using Fanex.Data.Repository;
    using Fanex.Result.Core;
    using Fanex.Result.Core.Base;
    using Fanex.Result.Core.GoldDeluxe.DTO;

    public class GoldDeluxePopupResultService : IProductResultService
    {
        private readonly IDynamicRepository _dynamicRepository;

        public GoldDeluxePopupResultService(IDynamicRepository dynamicRepository = null)
        {
            _dynamicRepository = dynamicRepository ?? new DynamicRepository();
        }

        public MemoryStream ExportExcel(ViewNormalResultCommand request, string excelTemplatePath)
        {
            throw new NotImplementedException();
        }

        public string GetResult(ViewNormalResultCommand request)
        {
            throw new NotImplementedException();
        }

        public string GetResultDetails(ViewNormalResultDetailsCommand detailsRequest)
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
                IsOutRight = false,
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