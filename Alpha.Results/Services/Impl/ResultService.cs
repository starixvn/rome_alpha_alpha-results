namespace Alpha.Results.Services.Impl
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Criteria;
    using Fanex.Caching;
    using Fanex.Common.Helper;
    using Fanex.Data.Repository;
    using Fanex.Result.Core.Base;
    using Models;
    using Models.Dtos;

    public class ResultService : IResultService
    {
        private const string BalanceUpDateCacheKey = "Alpha.Results.Services.Impl.ResultService";

        private IDynamicRepository _dynamicRepository;
        private ICache _cacheManager;

        public ResultService() : this(null, null)
        {
        }

        public ResultService(IDynamicRepository dynamicRepository, ICache cacheManager)
        {
            _dynamicRepository = dynamicRepository ?? new DynamicRepository();
            _cacheManager = cacheManager ?? CacheService.CreateInstance(CacheType.MemoryCache);
        }

        public BalanceUpDateDto GetBalanceUpDate()
        {
            var balanceUpDateDtoCached = _cacheManager.Get<BalanceUpDateDto>(BalanceUpDateCacheKey);

            if (balanceUpDateDtoCached == null)
            {
                balanceUpDateDtoCached = _dynamicRepository.Get<BalanceUpDateDto>(new GetBalanceUpDateCriteria());

                _cacheManager.Set<BalanceUpDateDto>(BalanceUpDateCacheKey, balanceUpDateDtoCached);
            }

            return balanceUpDateDtoCached;
        }

        public IEnumerable<League> GetLeagues(DateTime resultDate, int sportId, string language, bool disableHouseRacingWin)
        {
            Check.Argument.IsNotNull(resultDate, "resultDate");
            Check.Argument.IsNotNegativeOrZero(sportId, "sportId");
            Check.Argument.IsNotEmpty(language, "language");

            if (sportId == (int)SportType.HorseRacing
                && disableHouseRacingWin)
            {
                return Enumerable.Empty<League>();
            }

            var leagues = _dynamicRepository.Fetch<League>(new GetResultLeaguesByDateCriteria
            {
                EventDate = resultDate,
                Language = language,
                SportId = sportId
            });

            return leagues;
        }

        public IEnumerable<Sport> GetSports(DateTime resultDate, IDictionary<int, bool> sportsStatus)
        {
            Check.Argument.IsNotNull(resultDate, "resultDate");

            var sports = _dynamicRepository.Fetch<Sport>(new GetResultSportsByDateCriteria
            {
                EventDate = resultDate
            }).ToList();

            if (sports.Any())
            {
                sports.RemoveAll(sport => sportsStatus.Keys.Contains(sport.Id) && !sportsStatus[sport.Id]);
            }

            return sports;
        }
    }
}