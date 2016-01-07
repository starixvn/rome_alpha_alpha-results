namespace Alpha.Results.Site.Services.Impl
{
    using System;
    using System.Diagnostics.CodeAnalysis;
    using Criteria;
    using Fanex.Caching;
    using Fanex.Data.Repository;
    using Models.Dtos;

    public class ReportDateService : IReportDateService
    {
        private const string BalanceUpDateCacheKey = "Alpha.Results.Site.Services.Impl.BalanceUpDate";

        private readonly IDynamicRepository _dynamicRepository;
        private readonly ICache _cacheManager;

        public ReportDateService(IDynamicRepository dynamicRepository, ICache cacheManager)
        {
            _dynamicRepository = dynamicRepository ?? new DynamicRepository();
            _cacheManager = cacheManager ?? CacheService.CreateInstance(CacheType.MemoryCache);
        }

        [SuppressMessage("Microsoft.Usage", "CA2201:DoNotRaiseReservedExceptionTypes", Justification = "Reviewed")]
        public DateTime GetBalanceUpDate()
        {
            var date = _cacheManager.Get<DateTime>(BalanceUpDateCacheKey);

            if (date == DateTime.MinValue)
            {
                var data = _dynamicRepository.Get<BalanceUpAndMoveBetsDate>(new GetBalanceUpAndMoveBetsDayCriteria());

                if (data == null)
                {
                    throw new Exception("Cannot get balance up date");
                }

                date = data.BalanceUpDay;
                _cacheManager.Set(BalanceUpDateCacheKey, date);
            }

            return date;
        }       
    }
}