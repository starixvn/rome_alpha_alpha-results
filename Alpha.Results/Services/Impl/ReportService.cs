namespace Alpha.Results.Site.Services.Impl
{
    using Criteria;
    using Fanex.Caching;
    using Fanex.Data.Repository;
    using Models.Dtos;

    public class ReportService : IReportService
    {
        private const string BalanceUpDateCacheKey = "Alpha.Results.Site.Services.Impl.ResultService";

        private readonly IDynamicRepository _dynamicRepository;
        private readonly ICache _cacheManager;

        public ReportService(IDynamicRepository dynamicRepository, ICache cacheManager)
        {
            _dynamicRepository = dynamicRepository;
            _cacheManager = cacheManager;
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