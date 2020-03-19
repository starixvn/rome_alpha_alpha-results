namespace Alpha.Results.Site.Controllers
{
    using System.Web.Mvc;
    using MediatR;
    using Models.Requests;
    using Sunplus.Agent.Model.Entities;
    using Web;

    public class VirtualGamesController : BaseController
    {
        private readonly IMediator _mediator;
        private readonly IUserSession _userSession;

        public VirtualGamesController(IMediator mediator, IUserSession userSession)
        {
            _mediator = mediator;
            _userSession = userSession;
        }

        public ActionResult Index()
        {
            var viewModel = _mediator.Send(new VirtualGamesResultQuery
            {
                Language = _userSession.Language,
            });

            return View("~/Views/VirtualGames/Index.cshtml", (object)viewModel);
        }

        public ActionResult Detail(VirtualGamesDetailResultQuery query)
        {
            query.Language = _userSession.Language;

            var viewModel = _mediator.Send(query);

            return View("~/Views/VirtualGames/Detail.cshtml", (object)viewModel);
        }
    }
}
