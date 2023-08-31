namespace Alpha.Results.Site.Services.Impl.Products
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using Alpha.PartialUM.Helpers;
    using Alpha.Results.Site.Criteria;
    using AlphaPlus.PartialUM.DataAccess;
    using AlphaPlus.PartialUM.Services;
    using Fanex.Data.Repository;
    using Fanex.Result.Core.Base;
    using Fanex.Result.Core.Bitcoin.DTO;
    using Models.Requests;

    public class BitcoinResultService : IProductResultService
    {
        private readonly IDynamicRepository _dynamicRepository;
        private readonly IResultEngineAdapter _resultEngineAdapter;
        private readonly IPartialUMService _partialUMService;

        public BitcoinResultService(
            IDynamicRepository dynamicRepository = null,
            IResultEngineAdapter resultEngineAdapter = null,
            IPartialUMService partialUMService = null)
        {
            _dynamicRepository = dynamicRepository ?? new DynamicRepository();
            _resultEngineAdapter = resultEngineAdapter ?? new ResultEngineAdapter();
            _partialUMService = partialUMService ?? new PartialUMService(new PartialUMDataAccess(), new PartialUMSectionHelper());
        }

        public MemoryStream ExportExcel(ExcelNormalResultQuery request)
        {
            var result = _dynamicRepository.FetchMultiple<Bitcoin, GameDetail>(new GetBitcoinResultCriteria
            {
                FromDate = request.ResultDate,
                LeagueId = request.LeagueId,
                MoveBetsDay = request.MoveBetsDate
            });

            var bitcoins = BindingGameDetail(result);
            var resultSetting = CreateSetting(isPopup: false, language: request.Language);
            resultSetting.ExcelTitle = request.ExcelTitle;

            return _resultEngineAdapter.ExcelParser(bitcoins.ToList(), resultSetting);
        }

        public string GetResult(NormalResultQuery request)
        {
            var criteria = new GetBitcoinResultCriteria
            {
                FromDate = request.ResultDate,
                LeagueId = request.LeagueId,
                MoveBetsDay = request.MoveBetsDate
            };

            _partialUMService.ThrowIfUM(criteria.GetSettingKey());
            var result = _dynamicRepository.FetchMultiple<Bitcoin, GameDetail>(criteria);
            var bitcoins = BindingGameDetail(result);
            var resultSetting = CreateSetting(isPopup: false, language: request.Language);

            return _resultEngineAdapter.HtmlParser(bitcoins.ToList(), resultSetting);
        }

        public string GetResultDetails(NormalResultDetailsQuery detailsRequest)
        {
            var result = _dynamicRepository.FetchMultiple<Bitcoin, GameDetail>(new GetBitcoinResultDetailsCriteria
            {
                MatchId = detailsRequest.MatchId
            });

            var bitcoins = BindingGameDetail(result);
            var resultSetting = CreateSetting(isPopup: true, language: detailsRequest.Language);

            return _resultEngineAdapter.HtmlParser(bitcoins.ToList(), resultSetting);
        }

        private static IEnumerable<Bitcoin> BindingGameDetail(Tuple<IEnumerable<Bitcoin>, IEnumerable<GameDetail>> result)
        {
            foreach (var item in result.Item1)
            {
                var gameDetail = result.Item2.Where(i => i.Match3rdId == item.Match3rdId);
                if (gameDetail != null)
                {
                    item.GameResults = gameDetail.ToList();
                }
            }

            return result.Item1;
        }

        private ResultSetting CreateSetting(bool isPopup, string language)
            => new ResultSetting
            {
                SportType = SportType.Bitcoin,
                IsOutright = false,
                IsParlayPopUp = false,
                IsPopUp = isPopup,
                LanguageCode = language,
                VisibleMatchCodeIDColumn = true
            };
    }
}