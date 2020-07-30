namespace Alpha.Results.Site.Controllers
{
    using System.Web.Mvc;
    using MediatR;
    using Models.Requests;
    using Sunplus.Agent.Model.Entities;
    using Web;

    public class SabaClubController : BaseController
    {
        private readonly IMediator _mediator;
        private readonly IUserSession _userSession;

        public SabaClubController(IMediator mediator, IUserSession userSession)
        {
            _mediator = mediator;
            _userSession = userSession;
        }

        public ActionResult Index(SabaClubResultQuery request)
        {
            request.Language = _userSession.Language;

            var viewModel = _mediator.Send(request);

            return View(viewModel);
        }
    }
}
