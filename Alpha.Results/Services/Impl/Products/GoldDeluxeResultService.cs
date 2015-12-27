namespace Alpha.Results.Services.Impl.Products
{
    using System;
    using System.IO;
    using System.Linq;
    using Alpha.Results.Criteria;
    using Fanex.Data.Repository;
    using Fanex.Result.Core;
    using Fanex.Result.Core.Base;
    using Fanex.Result.Core.GoldDeluxe.DTO;
    using Models;
    using Sunplus.Agent.Model.Entities;

    public class GoldDeluxePopupResultService : IProductResultService
    {
        private IDynamicRepository _dynamicRepository;

        public GoldDeluxePopupResultService(IDynamicRepository dynamicRepository = null)
        {
            _dynamicRepository = dynamicRepository ?? new DynamicRepository();
        }

        public MemoryStream ExportExcel(NormalRequest request, string excelTemplatePath)
        {
            throw new NotImplementedException();
        }

        public string GetResult(NormalRequest request)
        {
            throw new NotImplementedException();
        }

        public string GetResultDetails(NormalDetailsRequest detailsRequest)
        {
            var criteria = new GetGoldDeluxePopupResultCriteria { TransId = detailsRequest.RefNum, BetType = detailsRequest.BetTypeId };

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
                LanguageCode = UserSession.Current.Language,
                VisibleMatchCodeIDColumn = false,
                HighlightWinnerTeam = true
            };

            return ResultEngine.HtmlParser(goldDeluxeResults, resultSetting);
        }
    }
}