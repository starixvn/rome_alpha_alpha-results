namespace Alpha.Results.Site.RNGCasino.Controllers
{
    using System.Web.Mvc;
    using Criteria;
    using Resources;
    using Services;
    using Web;

    public class RnGCasinoController : BaseController
    {
        private readonly IRnGCasinoService _rngCasinoService;

        public RnGCasinoController()
        {
            _rngCasinoService = new RnGCasinoService();
        }

        [HttpGet]
        public ActionResult GetHandHistory(GetRNGCasinoResultCriteria criteria)
        {
            ViewBag.ProductName = Resources.Product_6;
            var result = _rngCasinoService.GetHandHistory(criteria);
            return View("~/Views/HandHistory_API/Index.cshtml", result);
        }

        [HttpGet]
        public ActionResult GetVoidbridgeResult(GetVoidbridgeResultCriteria criteria)
        {
            ViewBag.ProductName = Resources.Voidbridge;
            var result = _rngCasinoService.GetVoidbridgeResult(criteria, "E");
            return View("~/Views/HandHistory_API/Index.cshtml", result);
        }

        [HttpGet]
        public ActionResult GetFishingWorldResult(GetResultCriteria criteria)
        {
            ViewBag.ProductName = Resources.FishingWorld;
            var result = _rngCasinoService.GetResultCriteria(criteria, "E");
            return View("~/Views/HandHistory_API/Index.cshtml", result);
        }
    }
}
