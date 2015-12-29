namespace Alpha.Results.Services.Impl.Products
{
    using System;
    using System.IO;
    using System.Linq;
    using Alpha.Results.Criteria;
    using Fanex.Data.Repository;
    using Fanex.Result.Core;
    using Fanex.Result.Core.Base;
    using Fanex.Result.Core.LiveCasino.DTO;
    using Models;

    /// <summary>
    /// The class LiveCasinoPopupResultService.
    /// </summary>
    public class LiveCasinoResultService : IProductResultService
    {
        private readonly IDynamicRepository _dynamicRepository;

        public LiveCasinoResultService(IDynamicRepository dynamicRepository)
        {
            this._dynamicRepository = dynamicRepository ?? new DynamicRepository();
        }

        public LiveCasinoResultService()
            : this(null)
        {
        }

        public string GetResultDetails(NormalDetailsRequest detailsRequest)
        {
            var criteria = new GetLiveCasinoResultCriteria()
            {
                MatchId = detailsRequest.MatchId,
                BetType = detailsRequest.BetTypeId,
                League = detailsRequest.LeagueId.ToString()
            };

            var resultSetting = new ResultSetting
            {
                SportType = SportType.LiveCasino,
                IsOutRight = false,
                IsParlayPopUp = false,
                IsPopUp = true,
                VisiblePopUpTitle = false,
                LanguageCode = detailsRequest.Language,
                VisibleMatchCodeIDColumn = false,
                VisibleFreeHeader = true,
                VisibleDetailedLink = true,
                HighlightWinnerTeam = true
            };

            var liveCasinoResults = this._dynamicRepository
                                        .Fetch<LiveCasino>(criteria)
                                        .Select(result =>
                                        {
                                            result.Bettype = detailsRequest.BetTypeId;
                                            return result;
                                        }).ToList();

            return ResultEngine.HtmlParser(liveCasinoResults, resultSetting);
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