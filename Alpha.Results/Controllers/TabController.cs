
namespace Alpha.Results.Controllers
{
    using System.Web.Mvc;
    using Sunplus.Agent.Model.Entities.Permission;
    using ViewModels;
    public class TabController : Controller
    {
        [ChildActionOnly]
        public ActionResult Index(string tabName = "Normal")
        {
            return PartialView(new TabViewModel(tabName, UserPermission.EnableKeno));
        }
    }
}