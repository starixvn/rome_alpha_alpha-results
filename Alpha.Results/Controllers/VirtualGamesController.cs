namespace Alpha.Results.Site.Controllers
{
    using System.Web.Mvc;
    using Alpha.Results.Site.Services;
    using AlphaPlus.User.Models;
    using MediatR;
    using Models.Requests;

    public class VirtualGamesController : ResultBaseController
    {
        private readonly ICacheRefService cacheRefService;

        public VirtualGamesController(IMediator mediator, IUserSession userSession, ICacheRefService cacheRefService)
            : base(mediator, userSession)
        {
            this.cacheRefService = cacheRefService;
        }

        public ActionResult Index()
            => View(new VirtualGamesResultQuery(userSession));
    }
}
