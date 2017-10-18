namespace Alpha.Results.Site.Controllers
{
    using System;
    using System.Web.Mvc;
    using MediatR;
    using Models.Requests;
    using Sunplus.Agent.Model.Entities;
    using Web;

    public class CockfightingController : BaseController
    {
        private readonly IMediator _mediator;
        private readonly IUserSession _userSession;

        public CockfightingController(IMediator mediator, IUserSession userSession)
        {
            _mediator = mediator;
            _userSession = userSession;
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

            request.CustomerId = _userSession.CustId;
            request.LanguageKey = _userSession.LangKey;

            var viewModel = _mediator.Send(request);

            return Json(viewModel, JsonRequestBehavior.AllowGet);
        }
    }
}
