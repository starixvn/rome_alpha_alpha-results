namespace Alpha.Results.Site.Controllers
{
    using System.Web.Mvc;
    using Alpha.Web;
    using Fanex.Result.ThirdParty.Models.Requests;
    using MediatR;
    using Models.Requests;
    using Sunplus.Agent.Model.Entities;

    public class ThirdPartyController : BaseController
    {
        private readonly string IndexView = "~/Views/ThirdParty/Index.cshtml";
        private readonly IMediator mediator;
        private readonly IUserSession userSession;

        public ThirdPartyController(IMediator mediator, IUserSession userSession)
        {
            this.mediator = mediator;
            this.userSession = userSession;
        }

        public ActionResult Index(ThirdPartyResultQuery message)
        {
            message.Language = userSession.Language;

            return View(mediator.Send(message));
        }

        public ActionResult Detail(ThirdPartyDetailResultQuery message)
        {
            message.Language = userSession.Language;

            return View(IndexView, mediator.Send(message));
        }

        public ActionResult MaxGameResult(MaxGameResultQuery message)
        {
            message.Language = userSession.Language;

            return View(IndexView, mediator.Send(message));
        }

        public ActionResult SportsLotteryResult(SportsLotteryDetailResultQuery message)
        {
            message.Language = userSession.Language;

            return View(IndexView, mediator.Send(message));
        }

        public ActionResult PPLiveCasinoResult(PPLiveCasinoResultQuery message)
        {
            message.Language = userSession.Language;

            return View(IndexView, mediator.Send(message));
        }

        public ActionResult HabaneroResult(HabaneroResultQuery message)
        {
            message.Language = userSession.Language;

            return View("~/Views/ThirdParty/Index.cshtml", mediator.Send(message));
        }

        public ActionResult CGResult(CGResultQuery message)
        {
            message.Language = userSession.Language;

            return View("~/Views/ThirdParty/Index.cshtml", mediator.Send(message));
        }

        public ActionResult VGamingResult(VGamingResultQuery message)
        {
            message.Language = userSession.Language;

            return View("~/Views/ThirdParty/Index.cshtml", mediator.Send(message));
        }
    }
}
