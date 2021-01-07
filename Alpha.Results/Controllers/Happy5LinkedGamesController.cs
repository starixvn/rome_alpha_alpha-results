namespace Alpha.Results.Site.Controllers
{
    using System.Web.Mvc;
    using MediatR;
    using Models.Requests;
    using Sunplus.Agent.Model.Entities;
    using Web;

    public class Happy5LinkedGamesController : BaseController
    {
        private readonly IMediator _mediator;
        private readonly IUserSession _userSession;

        public Happy5LinkedGamesController(IMediator mediator, IUserSession userSession)
        {
            _mediator = mediator;
            _userSession = userSession;
        }
       
        public ActionResult Index(Happy5LinkedGamesResultQuery query)
        {
            query.Language = _userSession.Language;

            var viewModel = _mediator.Send(query);

            return View("~/Views/Happy5LinkedGames/Index.cshtml", (object)viewModel);
        }
    }
}
