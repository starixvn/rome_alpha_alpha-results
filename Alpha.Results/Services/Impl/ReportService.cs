namespace Alpha.Results.Services.Impl
{
    using Criteria;
    using Fanex.Caching;
    using Fanex.Data.Repository;
    using Models.Dtos;

    public class ReportService : IReportService
    {
        private const string BalanceUpDateCacheKey = "Alpha.Results.Services.Impl.ResultService";

        private IDynamicRepository _dynamicRepository;
        private ICache _cacheManager;

        public ReportService() : this(null, null)
        {
        }

        public ReportService(IDynamicRepository dynamicRepository, ICache cacheManager)
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
    }
}