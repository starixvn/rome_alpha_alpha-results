using Alpha.Results.Site.Constants;
using Alpha.Results.Site.Services;

namespace Alpha.Results.Site.Models.Views
{
    public class SportsLotteryResultViewModel : BaseResultTab
    {
        public SportsLotteryResultViewModel(ICacheRefService cacheRefService, string resultPath)
        {
            ProductName = cacheRefService.GetProductName(ProductIdConstants.SportsLottery);
            ResultPath = resultPath;
        }

        public string ResultPath { get; set; }
    }
}