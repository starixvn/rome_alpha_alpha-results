namespace Alpha.Results.Site.Controllers
{
    using System.Web.Mvc;
    using MediatR;
    using Models.Requests;
    using Sunplus.Agent.Model.Entities;
    using Web;

    public class TableGamesController : BaseController
    {
        private readonly IMediator _mediator;
        private readonly IUserSession _userSession;

        public TableGamesController(IMediator mediator, IUserSession userSession)
        {
            _mediator = mediator;
            _userSession = userSession;
        }

        [HttpGet]
        public ActionResult Index()
        {
            var viewModel = _mediator.Send(new TableGamesResultQuery(_userSession));

            return View(viewModel);
        }
    }
}
