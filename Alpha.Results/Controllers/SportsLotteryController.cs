namespace Alpha.Results.Site.Controllers
{
    using System.Web.Mvc;
    using AlphaPlus.User.Models;
    using MediatR;
    using Models.Requests;

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
