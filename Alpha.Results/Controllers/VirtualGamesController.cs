namespace Alpha.Results.Site.Controllers
{
    using System.Web.Mvc;
    using Alpha.Results.Site.Models.Views;
    using Alpha.Results.Site.Services;
    using MediatR;
    using Models.Requests;
    using Sunplus.Agent.Model.Entities;
    using Web;

    public class VirtualGamesController : BaseController
    {
        private readonly IMediator _mediator;
        private readonly IUserSession _userSession;
        private readonly ICacheRefService cacheRefService;

        public VirtualGamesController(IMediator mediator, IUserSession userSession, ICacheRefService cacheRefService)
        {
            _mediator = mediator;
            _userSession = userSession;
            this.cacheRefService = cacheRefService;
        }

        public ActionResult Index()
        {
            var viewModel = _mediator.Send(new VirtualGamesResultQuery
            {
                Language = _userSession.Language,
            });

            return View("~/Views/VirtualGames/Index.cshtml", new VirtualGamesResultViewModel(cacheRefService) { ResultPath = viewModel });
        }

        public ActionResult Detail(VirtualGamesDetailResultQuery query)
        {
            query.Language = _userSession.Language;

            var viewModel = _mediator.Send(query);

            return View("~/Views/VirtualGames/Detail.cshtml", new VirtualGamesResultViewModel(cacheRefService) { ResultPath = viewModel });
        }
    }
}
