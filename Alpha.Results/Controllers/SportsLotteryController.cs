namespace Alpha.Results.Site.Controllers
{
    using System.Web.Mvc;
    using MediatR;
    using Models.Requests;
    using Sunplus.Agent.Model.Entities;

    public class SportsLotteryController : ResultBaseController
    {
        public SportsLotteryController(IMediator mediator, IUserSession userSession)
            : base(mediator, userSession)
        {
        }

        public ActionResult Index()
        {
            return View("~/Views/SportsLottery/Index.cshtml", new SportsLotteryResultQuery(userSession));
        }
    }
}
