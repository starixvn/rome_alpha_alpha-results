namespace Alpha.Results.Site.Controllers
{
    using System.Web.Mvc;
    using AlphaPlus.User.Models;
    using MediatR;
    using Models.Requests;

    public class LotteryController : ResultBaseController
    {
        public LotteryController(IMediator mediator, IUserSession userSession)
            : base(mediator, userSession)
        {
        }

        [HttpGet]
        public ActionResult Index() => View(new LotteryResultQuery(userSession));
    }
}
