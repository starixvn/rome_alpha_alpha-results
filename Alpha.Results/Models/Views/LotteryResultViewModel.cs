using Alpha.Results.Site.Constants;
using Alpha.Results.Site.Services;

namespace Alpha.Results.Site.Models.Views
{
    public class LotteryResultViewModel : BaseResultTab
    {
        public LotteryResultViewModel(ICacheRefService cacheRefService)
        {
            ProductName = cacheRefService.GetProductName(ProductIdConstants.Lottery);
        }

        public string ResultPath { get; set; }

        public string ExtendTokenPath { get; set; }
    }
}