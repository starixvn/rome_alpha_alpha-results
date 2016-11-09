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
            var isEnableCockfighting = UserPermission.IsEnableProduct(ProductIdConstants.CockFighting);

            var product = ProductManager.GetProduct(ProductIdConstants.NG2);
            var isEnableNG2 = product != null && product.ShowSettings;

            return PartialView(new TabViewModel(tabName, UserPermission.EnableKeno, isEnableCockfighting, isEnableNG2));
        }
    }
}