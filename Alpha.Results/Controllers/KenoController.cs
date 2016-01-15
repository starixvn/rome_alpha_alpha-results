namespace Alpha.Results.Site.Controllers
{
    using MediatR;
    using Models.Requests;
    using Sunplus.Agent.Model.Entities;
    using System.Web.Mvc;

    public class KenoController : BaseController
    {
        private readonly IMediator _mediator;

        public KenoController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public ActionResult Index()
        {
            var userSession = UserSession.Current;

            var viewModel = _mediator.Send(new KenoResultQuery
            {
                LanguageKey = userSession.LangKey,
                CustId = userSession.CustId,
                RootUrl = HttpContext.Response.ApplyAppPathModifier("~/")
            });

            return View(viewModel);
        }
    }
}