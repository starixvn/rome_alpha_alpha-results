namespace Alpha.Results.Site.Services.Impl.Products
{
    using System;
    using System.IO;
    using System.Linq;
    using Alpha.Results.Site.Criteria;
    using Fanex.Common.Helper;
    using Fanex.Data.Repository;
    using Fanex.Result.Core;
    using Fanex.Result.Core.Base;
    using Fanex.Result.Core.LiveCasino.DTO;
    using Models.Requests;

    /// <summary>
    /// The class LiveCasinoPopupResultService.
    /// </summary>
    public class LiveCasinoResultService : IProductResultService
    {
        private readonly IDynamicRepository _dynamicRepository;

        public LiveCasinoResultService(IDynamicRepository dynamicRepository = null)
        {
            //// Still using poorman DI here because result service factory need to create it manual
            _dynamicRepository = dynamicRepository ?? new DynamicRepository();
        }

        public string GetResultDetails(NormalResultDetailsQuery detailsRequest)
        {
            Check.Argument.IsNotNull(detailsRequest, "detailsRequest");

            var criteria = new GetLiveCasinoResultCriteria()
            {
                MatchId = detailsRequest.MatchId,
                BetType = detailsRequest.BetTypeId,
                League = detailsRequest.LeagueId.ToString()
            };

            var resultSetting = new ResultSetting
            {
                SportType = SportType.LiveCasino,
                IsOutright = false,
                IsParlayPopUp = false,
                IsPopUp = true,
                VisiblePopUpTitle = false,
                LanguageCode = detailsRequest.Language,
                VisibleMatchCodeIDColumn = false,
                VisibleFreeHeader = true,
                VisibleDetailedLink = true,
                HighlightWinnerTeam = true
            };

            var liveCasinoResults = _dynamicRepository
                                        .Fetch<LiveCasino>(criteria)
                                        .Select(result =>
                                        {
                                            result.Bettype = detailsRequest.BetTypeId;
                                            return result;
                                        }).ToList();

            return ResultEngine.HtmlParser(liveCasinoResults, resultSetting);
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