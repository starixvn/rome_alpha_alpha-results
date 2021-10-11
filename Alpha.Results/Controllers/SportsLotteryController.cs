namespace Alpha.Results.Site.Controllers
{
    using System.Web.Mvc;
    using Alpha.Results.Site.Models.Views;
    using Alpha.Results.Site.Services;
    using MediatR;
    using Models.Requests;
    using Sunplus.Agent.Model.Entities;

    public class SportsLotteryController : ResultBaseController
    {
        private readonly ICacheRefService cacheRefService;

        public SportsLotteryController(IMediator mediator, IUserSession userSession, ICacheRefService cacheRefService)
            : base(mediator, userSession)
        {
            this.cacheRefService = cacheRefService;
        }

        public ActionResult Index()
        {
            var viewModel = mediator.Send(new SportsLotteryResultQuery
            {
                Language = userSession.Language,
            });

            return View("~/Views/SportsLottery/Index.cshtml", new SportsLotteryResultViewModel(cacheRefService) { ResultPath = viewModel });
        }
    }
}
