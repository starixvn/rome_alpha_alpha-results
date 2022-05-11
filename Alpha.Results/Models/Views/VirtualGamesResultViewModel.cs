using Alpha.Results.Site.Constants;
using Alpha.Results.Site.Services;

namespace Alpha.Results.Site.Models.Views
{
    public class VirtualGamesResultViewModel : KenoLotteryTableGameResultViewModel
    {
        public VirtualGamesResultViewModel(ICacheRefService cacheRefService)
        {
            ProductName = cacheRefService.GetProductName(ProductIdConstants.VirtualGames);
        }
    }
}