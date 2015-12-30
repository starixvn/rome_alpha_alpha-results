namespace Alpha.Results.Controllers
{
    using System.Web.Mvc;
    using Models.Views;
    using Sunplus.Agent.Model.Entities.Permission;

    public class TabController : Controller
    {
        [ChildActionOnly]
        public ActionResult Index(string tabName = "Normal")
        {
            return PartialView(new TabViewModel(tabName, UserPermission.EnableKeno));
        }
    }
}