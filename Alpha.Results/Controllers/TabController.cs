namespace Alpha.Results.Site.Controllers
{
    using System.Web.Mvc;
    using Fanex.Products;
    using Models.Views;
    using Sunplus.Agent.Model.Definitions;
    using Sunplus.Agent.Model.Entities.Permission;

    public class TabController : Controller
    {
        [ChildActionOnly]
        public ActionResult Index(string tabName = "Normal")
        {
#pragma warning disable CS0618 // Type or member is obsolete
            var isEnableCockfighting = UserPermission.IsEnableProduct(ProductIdConstants.CockFighting);

            var product = ProductManager.GetProduct(ProductIdConstants.NG2);
            var isEnableNG2 = product != null && product.ShowSettings;
            var viewModel = new TabViewModel(
                tabName,
                UserPermission.EnableKeno,
                isEnableCockfighting,
                isEnableNG2,
                UserPermission.IsEnableProduct(ProductIdConstants.Lottery));
#pragma warning restore CS0618 // Type or member is obsolete

            return PartialView(viewModel);
        }
    }
}
