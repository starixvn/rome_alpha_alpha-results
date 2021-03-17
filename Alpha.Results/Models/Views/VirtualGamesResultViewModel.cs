using Alpha.Results.Site.Constants;
using Alpha.Results.Site.Services;

namespace Alpha.Results.Site.Models.Views
{
    public class VirtualGamesResultViewModel : BaseResultTab
    {
        public VirtualGamesResultViewModel(ICacheRefService cacheRefService)
        {
            ProductName = cacheRefService.GetProductName(ProductIdConstants.VirtualGames);
        }

        public string ResultPath { get; set; }
    }
}