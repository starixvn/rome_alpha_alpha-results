namespace Alpha.Results.Site.Services.Impl
{
    using System;
    using Criteria;
    using Fanex.Caching;
    using Fanex.Data.Repository;
    using Models.Dtos;

    public class ReportDateService : IReportDateService
    {
        private const string BalanceUpDateCacheKeyService = "Alpha.Results.Site.Services.Impl.ResultService";
        private const string BalanceUpDateCacheKey = "Alpha.Results.Site.Services.Impl.BalanceUpDate";
        private const string MoveBetsDateCacheKey = "Alpha.Results.Site.Services.Impl.MoveBetsDate";

        private readonly IDynamicRepository _dynamicRepository;
        private readonly ICache _cacheManager;

        public ReportDateService(IDynamicRepository dynamicRepository, ICache cacheManager)
        {
            _dynamicRepository = dynamicRepository ?? new DynamicRepository();
            _cacheManager = cacheManager ?? CacheService.CreateInstance(CacheType.MemoryCache);
        }

        public BalanceUpAndMoveBetsDate GetBalanceUpDate()
        {
            var balanceUpDateDtoCached = _cacheManager.Get<BalanceUpAndMoveBetsDate>(BalanceUpDateCacheKeyService);

            if (balanceUpDateDtoCached == null)
            {
                balanceUpDateDtoCached = _dynamicRepository.Get<BalanceUpAndMoveBetsDate>(new GetBalanceUpAndMoveBetsDayCriteria());

                _cacheManager.Set(BalanceUpDateCacheKeyService, balanceUpDateDtoCached);
            }

            return balanceUpDateDtoCached;
        }

        public DateTime GetBalanceUpDay()
        {
            var date = _cacheManager.Get<DateTime>(BalanceUpDateCacheKey);

            if (date == DateTime.MinValue)
            {
                var data = _dynamicRepository.Get<BalanceUpAndMoveBetsDate>(new GetBalanceUpAndMoveBetsDayCriteria());

                if (data == null)
                {
                    throw new Exception("Cannot get balance up day");
                }

                date = data.BalanceUpDay;
                _cacheManager.Set(BalanceUpDateCacheKey, date);
            }

            return date;
        }

        public DateTime GetMoveBetsDate()
        {
            if (_cacheManager.Keys.Contains(MoveBetsDateCacheKey))
            {
                var moveBetsDate = _cacheManager.Get<DateTime>(MoveBetsDateCacheKey);

                return moveBetsDate;
            }

            var data = _dynamicRepository.Get<BalanceUpAndMoveBetsDate>(new GetBalanceUpAndMoveBetsDayCriteria());

            if (data != null)
            {
                var moveBetsDate = data.MoveBetsDay;

                _cacheManager.Set(MoveBetsDateCacheKey, moveBetsDate);

                return moveBetsDate;
            }
            else
            {
                throw new Exception("Cannot get balance up day and move bets day");
            }
        }
    }
}