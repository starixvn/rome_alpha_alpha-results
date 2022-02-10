namespace Alpha.Results.Site.Controllers
{
    using System.Web.Mvc;
    using MediatR;
    using Models.Requests;
    using Sunplus.Agent.Model.Entities;
    using Web;

    public class LinkedGamesController : BaseController
    {
        private readonly IMediator _mediator;
        private readonly IUserSession _userSession;

        public LinkedGamesController(IMediator mediator, IUserSession userSession)
        {
            _mediator = mediator;
            _userSession = userSession;
        }
       
        public ActionResult GetSoccer5Result(Soccer5ResultQuery query)
        {
            query.Language = _userSession.Language;

            var viewModel = _mediator.Send(query);

            return View("~/Views/LinkedGames/Index.cshtml", (object)viewModel);
        }
    }
}
