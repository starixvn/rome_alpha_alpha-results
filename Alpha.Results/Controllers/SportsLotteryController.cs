namespace Alpha.Results.Site.Controllers
{
    using System.Web.Mvc;
    using MediatR;
    using Models.Requests;
    using Sunplus.Agent.Model.Entities;
    using Web;

    public class SportsLotteryController : BaseController
    {
        private readonly IMediator _mediator;
        private readonly IUserSession _userSession;

        public SportsLotteryController(IMediator mediator, IUserSession userSession)
        {
            _mediator = mediator;
            _userSession = userSession;
        }

        public ActionResult Index()
        {
            var viewModel = _mediator.Send(new SportsLotteryResultQuery
            {
                Language = _userSession.Language,
            });

            return View("~/Views/SportsLottery/Index.cshtml", (object)viewModel);
        }        
    }
}
