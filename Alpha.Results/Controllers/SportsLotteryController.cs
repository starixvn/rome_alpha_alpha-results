namespace Alpha.Results.Site.Controllers
{
    using System.Web.Mvc;
    using Alpha.Results.Site.Models.Views;
    using Alpha.Results.Site.Services;
    using MediatR;
    using Models.Requests;
    using Sunplus.Agent.Model.Entities;
    using Web;

    public class SportsLotteryController : BaseController
    {
        private readonly IMediator _mediator;
        private readonly IUserSession _userSession;
        private readonly ICacheRefService cacheRefService;

        public SportsLotteryController(IMediator mediator, IUserSession userSession, ICacheRefService cacheRefService)
        {
            _mediator = mediator;
            _userSession = userSession;
            this.cacheRefService = cacheRefService;
        }

        public ActionResult Index()
        {
            var viewModel = _mediator.Send(new SportsLotteryResultQuery
            {
                Language = _userSession.Language,
            });

            return View("~/Views/SportsLottery/Index.cshtml", new SportsLotteryResultViewModel(cacheRefService) { ResultPath = viewModel });
        }
    }
}
