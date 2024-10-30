namespace Alpha.Results.Site.Services.Impl.Products
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using Alpha.PartialUM.Helpers;
    using Alpha.Results.Site.Constants;
    using Alpha.Results.Site.Criteria;
    using Alpha.Results.Site.Models;
    using AlphaPlus.PartialUM.DataAccess;
    using AlphaPlus.PartialUM.Services;
    using Fanex.Data.Repository;
    using Fanex.Result.Core.Base;
    using Fanex.Result.Core.Sportsbook.DTO;
    using Models.Requests;

    public class BetByResultService : IProductResultService
    {
        private readonly IDynamicRepository _dynamicRepository;
        private readonly IResultEngineAdapter _resultEngineAdapter;
        private readonly IPartialUMService _partialUMService;

        public BetByResultService(
            IDynamicRepository dynamicRepository = null,
            IResultEngineAdapter resultEngineAdapter = null,
            IPartialUMService partialUMService = null)
        {
            _dynamicRepository = dynamicRepository ?? new DynamicRepository();
            _resultEngineAdapter = resultEngineAdapter ?? new ResultEngineAdapter();
            _partialUMService = partialUMService ?? new PartialUMService(new PartialUMDataAccess(_dynamicRepository), new PartialUMSectionHelper());
        }

        public MemoryStream ExportExcel(ExcelNormalResultQuery request)
        {
            var result = _dynamicRepository.FetchMultiple<Sportsbook, GameDetail>(new GetBetByResultCriteria
            {
                FromDate = request.ResultDate,
                LeagueId = request.LeagueId,
                MoveBetsDay = request.MoveBetsDate
            });

            var viruallysports = BindingGameDetail(result.ToTuple());
            var resultSetting = CreateSetting(isPopup: false, language: request.Language);
            resultSetting.ExcelTitle = request.ExcelTitle;

            return _resultEngineAdapter.ExcelParser(viruallysports.ToList(), resultSetting);
        }

        public string GetResult(NormalResultQuery request)
        {
            var criteria = new GetBetByResultCriteria
            {
                FromDate = request.ResultDate,
                LeagueId = request.LeagueId,
                MoveBetsDay = request.MoveBetsDate
            };

            _partialUMService.ThrowIfUM(criteria.GetSettingKey());
            var result = _dynamicRepository.FetchMultiple<Sportsbook, GameDetail>(criteria);
            var viruallysports = BindingGameDetail(result.ToTuple());
            var resultSetting = CreateSetting(isPopup: false, language: request.Language);

            return _resultEngineAdapter.HtmlParser(viruallysports.ToList(), resultSetting);
        }

        public ResultDetailModel GetResultDetails(NormalResultDetailsQuery detailsRequest)
        {
            var result = _dynamicRepository.FetchMultiple<Sportsbook, GameDetail>(new GetBetByResultDetailsCriteria
            {
                MatchId = detailsRequest.MatchId
            });

            var viruallysports = BindingGameDetail(result.ToTuple());
            var resultSetting = CreateSetting(isPopup: true, language: detailsRequest.Language);

            return new ResultDetailModel(_resultEngineAdapter.HtmlParser(viruallysports.ToList(), resultSetting));
        }

        private static IEnumerable<Sportsbook> BindingGameDetail(Tuple<IEnumerable<Sportsbook>, IEnumerable<GameDetail>> result)
        {
            foreach (var item in result.Item1)
            {
                var gameDetail = result.Item2.Where(i => i.MatchId == item.MatchId);
                if (gameDetail != null)
                {
                    item.GameDetails = gameDetail.ToList();
                }
            }

            return result.Item1;
        }

        private ResultSetting CreateSetting(bool isPopup, string language)
            => new ResultSetting
            {
                SportType = SportType.VirtualSports,
                IsOutright = false,
                IsParlayPopUp = false,
                IsPopUp = isPopup,
                LanguageCode = language,
                VisibleMatchCodeIDColumn = true
            };
    }
}