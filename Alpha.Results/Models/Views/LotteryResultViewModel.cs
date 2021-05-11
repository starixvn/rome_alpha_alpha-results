namespace Alpha.Results.Site.Models.Views
{
    using Alpha.Results.Site.Constants;
    using Alpha.Results.Site.Services;

    public class LotteryResultViewModel : KenoLotteryTableGameResultViewModel
    {
        public LotteryResultViewModel(ICacheRefService cacheRefService)
        {
            ProductName = cacheRefService.GetProductName(ProductIdConstants.Lottery);
        }
    }
}