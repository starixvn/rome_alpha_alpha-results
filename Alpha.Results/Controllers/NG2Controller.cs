namespace Alpha.Results.Site.Controllers
{
    using System.Web.Mvc;
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

            return RedirectToAction("TicketDetail", controllerName);
        }

        [HttpGet]
        public ActionResult ParlayDetail(string transactionId)
        {
            string controllerName = string.Format("..{0}", MicroSites.NG2ResultPath);

            return RedirectToAction("ParlayDetail", controllerName);
        }
    }
}