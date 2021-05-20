namespace Alpha.Results.Site.Models.Views
{
    using Alpha.Results.Site.Constants;
    using Alpha.Results.Site.Services;

    public class TableGamesResultViewModel : KenoLotteryTableGameResultViewModel
    {
        public TableGamesResultViewModel(ICacheRefService cacheRefService)
        {
            ProductName = cacheRefService.GetProductName(ProductIdConstants.TableGames);
        }
    }
}