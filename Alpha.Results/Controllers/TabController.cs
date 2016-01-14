namespace Alpha.Results.Site.Controllers
{
    using System.Web.Mvc;
    using Models.Views;
    using Sunplus.Agent.Model.Entities.Permission;

    public class TabController : Controller
    {
        /// <summary>
        /// Temporary use this constant here, will be updated when update Sunplus.Agent.Model.Definitions.
        /// </summary>
        private readonly int CockFightingProductId = 19;

        [ChildActionOnly]
        public ActionResult Index(string tabName = "Normal")
        {
            var isEnableCockfighting = UserPermission.IsEnableProduct(CockFightingProductId);

            return PartialView(new TabViewModel(tabName, UserPermission.EnableKeno, isEnableCockfighting));
        }
    }
}