namespace Alpha.Results.Site.Controllers
{
    using System.Web.Mvc;
    using Alpha.Results.Site.Models.Views;
    using Alpha.Results.Site.Services;
    using MediatR;
    using Models.Requests;
    using Sunplus.Agent.Model.Entities;

    public class VirtualGamesController : ResultBaseController
    {
        private readonly ICacheRefService cacheRefService;

        public VirtualGamesController(IMediator mediator, IUserSession userSession, ICacheRefService cacheRefService)
            : base(mediator, userSession)
        {
            this.cacheRefService = cacheRefService;
        }

        public ActionResult Index()
        {
            var viewModel = mediator.Send(new VirtualGamesResultQuery
            {
                Language = userSession.Language,
            });

            return View("~/Views/VirtualGames/Index.cshtml", new VirtualGamesResultViewModel(cacheRefService) { ResultPath = viewModel });
        }
    }
}
