namespace Alpha.Results.Site.Controllers
{
    using System.Web.Mvc;
    using Models.Views;
    using Services;
    using Alpha.Results.Site.Constants;
    using AlphaPlus.User.Models;

    public class TabController : Controller
    {
        private readonly ICacheRefService cacheRefService;

        public TabController(ICacheRefService cacheRefService)
        {
            this.cacheRefService = cacheRefService;
        }

        [ChildActionOnly]
        public ActionResult Index(string tabName = "Normal")
        {
            var viewModel = new TabViewModel(
                tabName,
                UserPermission.IsEnableProduct(Constants.ProductIdConstants.Keno),
                UserPermission.IsEnableProduct(Constants.ProductIdConstants.Lottery),
                UserPermission.IsEnableProduct(Constants.ProductIdConstants.VirtualGames),
                UserPermission.IsEnableProduct(Constants.ProductIdConstants.TableGames),
                UserPermission.IsEnableProduct(Constants.ProductIdConstants.SportsLottery),
                cacheRefService.GetProductName);

            return PartialView(viewModel);
        }
    }
}
