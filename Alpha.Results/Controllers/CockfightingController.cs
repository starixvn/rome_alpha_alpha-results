namespace Alpha.Results.Site.Controllers
{
    using System.Web.Mvc;
    using MediatR;
    using Models.Requests;
    using Models.Views;
    using Sunplus.Agent.Model.Entities;
    using Web;

    public class CockfightingController : BaseController
    {
        private readonly IMediator _mediator;

        public CockfightingController(IMediator mediator)
        {
            _mediator = mediator;
        }

        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public JsonResult Result(CockfightingResultQuery request)
        {
            request.CustomerId = UserSession.Current.CustId;
            request.LanguageKey = UserSession.Current.LangKey;

            var viewModel = _mediator.Send<CockfightingResultViewModel>(request);

            return Json(viewModel, JsonRequestBehavior.AllowGet);
        }
    }
}