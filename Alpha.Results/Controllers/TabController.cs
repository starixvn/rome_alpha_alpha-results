namespace Alpha.Results.Site.Controllers
{
    using System.Web.Mvc;
    using Fanex.Products;
    using Models.Views;
    using Services;
    using Alpha.Results.Site.Constants;
    using Sunplus.Agent.Model.Entities.Permission;

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
            var product = ProductManager.GetProduct(ProductIdConstants.NG2);
            var isEnableNG2 = product != null && product.ShowSettings;

            var viewModel = new TabViewModel(
                tabName,
                UserPermission.EnableKeno,
                isEnableNG2,
                UserPermission.IsEnableProduct(ProductIdConstants.Lottery),
                UserPermission.IsEnableProduct(ProductIdConstants.VirtualGames),
                UserPermission.IsEnableProduct(ProductIdConstants.TableGames),
                UserPermission.IsEnableProduct(ProductIdConstants.SportsLottery),
                cacheRefService.GetProductName);

            return PartialView(viewModel);
        }
    }
}
