namespace Alpha.Results.Site.Controllers
{
    using System;
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
            if (request == null)
            {
                throw new ArgumentNullException(nameof(request), "Request cannot be null");
            }

#pragma warning disable CS0618 // Type or member is obsolete
            request.CustomerId = UserSession.Current.CustId;
            request.LanguageKey = UserSession.Current.LangKey;
#pragma warning restore CS0618 // Type or member is obsolete

            var viewModel = _mediator.Send<CockfightingResultViewModel>(request);

            return Json(viewModel, JsonRequestBehavior.AllowGet);
        }
    }
}
