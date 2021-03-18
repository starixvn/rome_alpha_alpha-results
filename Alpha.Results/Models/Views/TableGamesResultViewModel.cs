using Alpha.Results.Site.Constants;
using Alpha.Results.Site.Services;

namespace Alpha.Results.Site.Models.Views
{
    public class TableGamesResultViewModel : BaseResultTab
    {
        public TableGamesResultViewModel(ICacheRefService cacheRefService)
        {
            ProductName = cacheRefService.GetProductName(ProductIdConstants.TableGames);
        }

        public string ResultPath { get; set; }

        public string ExtendTokenPath { get; set; }
    }
}