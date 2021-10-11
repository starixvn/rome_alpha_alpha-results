namespace Alpha.Results.Site.Controllers
{
    using System.Web.Mvc;
    using System.Web.Routing;
    using Alpha.Web.Models;
    using Sunplus.Agent.Model.Entities;
    using Web;

    public class NG2Controller : BaseController
    {
        private readonly IUserSession userSession;

        public NG2Controller(IUserSession userSession)
        {
            this.userSession = userSession;
        }

        [HttpGet]
        public ActionResult Index()
        {
            AssignDarkModeViewData();
            return View("~/Views/NG2/Index.cshtml", null, $"{Helpers.UrlHelper.NG2ResultPath}/All");
        }

        [HttpGet]
        public ActionResult TicketDetail(int gambleId)
        {
            return RedirectToAction(
                "TicketDetail",
                $"..{Helpers.UrlHelper.NG2ResultPath}",
                new RouteValueDictionary(new
                {
                    gambleId
                }));
        }

        [HttpGet]
        public ActionResult ParlayDetail(string refno)
        {
            return RedirectToAction(
                "ParlayDetail",
                $"..{Helpers.UrlHelper.NG2ResultPath}",
                new RouteValueDictionary(new
                {
                    refno
                }));
        }

        private void AssignDarkModeViewData()
        {
            ViewData["DarkModeName"] = userSession.DarkModeName;
            ViewData["TitleLevel"] = Enumeration.FromValue<UserLevel>(userSession.RoleId).DisplayName.ToLowerInvariant();
        }
    }
}
