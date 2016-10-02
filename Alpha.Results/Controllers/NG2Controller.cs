namespace Alpha.Results.Site.Controllers
{
    using System.Web.Mvc;
    using System.Web.Routing;
    using Alpha.Results.Site.Helpers;

    public class NG2Controller : BaseController
    {
        [HttpGet]
        public ActionResult Index()
        {
            string controllerName = string.Format("..{0}", MicroSites.NG2ResultPath);

            return RedirectToAction("Index", controllerName);
        }

        [HttpGet]
        public ActionResult TicketDetail(int gambleId)
        {
            string controllerName = string.Format("..{0}", MicroSites.NG2ResultPath);

            return RedirectToAction("TicketDetail", controllerName, new RouteValueDictionary(new
            {
                gambleId
            }));
        }

        [HttpGet]
        public ActionResult ParlayDetail(string refno)
        {
            string controllerName = string.Format("..{0}", MicroSites.NG2ResultPath);

            return RedirectToAction("ParlayDetail", controllerName, new RouteValueDictionary(new
            {
                refno
            }));
        }
    }
}