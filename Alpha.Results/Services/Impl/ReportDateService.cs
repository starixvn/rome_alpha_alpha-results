namespace Alpha.Results.Site.Services.Impl
{
    using Criteria;
    using Fanex.Caching;
    using Fanex.Data.Repository;
    using Models.Dtos;
    using System;
    using System.Diagnostics.CodeAnalysis;

    public class ReportDateService : IReportDateService
    {
        private const string BalanceUpAndMoveBetsDateCacheKey = "Alpha.Results.Site.Services.Impl.BalanceUpAndMoveBetsDate";

        private readonly IDynamicRepository _dynamicRepository;
        private readonly ICacheService _cacheService;

        public ReportDateService(IDynamicRepository dynamicRepository, ICacheService cacheService)
        {
            _dynamicRepository = dynamicRepository ?? new DynamicRepository();
            _cacheService = cacheService ?? new CacheService();
        }

        [SuppressMessage("Microsoft.Usage", "CA2201:DoNotRaiseReservedExceptionTypes", Justification = "Reviewed")]
        public DateTime GetBalanceUpDate()
        {
            return GetBalanceUpAndMoveBetsDate().BalanceUpDay;
        }

        public DateTime GetMoveBetsDate()
        {
            return GetBalanceUpAndMoveBetsDate().MoveBetsDay;
        }

        [SuppressMessage("Microsoft.Usage", "CA2201:DoNotRaiseReservedExceptionTypes", Justification = "Reviewed!")]
        public BalanceUpAndMoveBetsDate GetBalanceUpAndMoveBetsDate()
        {
            var data = _cacheService.Get<BalanceUpAndMoveBetsDate>(BalanceUpAndMoveBetsDateCacheKey);

            if (data == null)
            {
                data = _dynamicRepository.Get<BalanceUpAndMoveBetsDate>(new GetBalanceUpAndMoveBetsDayCriteria());

                if (data == null)
                {
                    throw new Exception("Cannot get balance up date and move bets date.");
                }

                _cacheService.Set(BalanceUpAndMoveBetsDateCacheKey, data, new CacheItemOptions().SetAbsoluteExpiration(TimeSpan.FromMinutes(2)));
            }

            return data;
        }
    }
}