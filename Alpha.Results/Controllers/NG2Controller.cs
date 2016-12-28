namespace Alpha.Results.Site.Controllers
{
    using System.Web.Mvc;
    using System.Web.Routing;
    using Helpers;
    using Web;

    public class NG2Controller : BaseController
    {
        [HttpGet]
        public ActionResult Index()
        {
            return View("~/Views/NG2/Index.cshtml", null, $"{MicroSites.NG2ResultPath}/All");
        }

        [HttpGet]
        public ActionResult TicketDetail(int gambleId)
        {
            return RedirectToAction(
                "TicketDetail", 
                $"..{MicroSites.NG2ResultPath}", 
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
                $"..{MicroSites.NG2ResultPath}", 
                new RouteValueDictionary(new
            {
                refno
            }));
        }
    }
}