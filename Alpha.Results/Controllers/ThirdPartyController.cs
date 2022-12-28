namespace Alpha.Results.Site.Controllers
{
    using System.Web.Mvc;
    using MediatR;
    using Models.Requests;
    using Sunplus.Agent.Model.Entities;

    public class ThirdPartyController : ResultBaseController
    {
        private const string IndexView = "~/Views/ThirdParty/Index.cshtml";

        public ThirdPartyController(IMediator mediator, IUserSession userSession)
            : base(mediator, userSession)
        {
        }

        public ActionResult Detail(FishingWorldResultQuery message)
        {
            message.Language = userSession.Language;
            return View(IndexView, message);
        }

        public ActionResult MaxGameResult(MaxGameResultQuery message)
            => View(IndexView, mediator.Send(message));

        public ActionResult SportsLotteryDetailResult(SportsLotteryDetailResultQuery message)
        => View(IndexView, mediator.Send(message));

        public ActionResult PPLiveCasinoResult(PPLiveCasinoResultQuery message)
        => Json(mediator.Send(message), JsonRequestBehavior.AllowGet);

        public ActionResult HabaneroResult(HabaneroResultQuery message)
        => View(IndexView, mediator.Send(message));

        public ActionResult CGResult(CGResultQuery message)
        => View(IndexView, mediator.Send(message));

        public ActionResult VGamingResult(VGamingResultQuery message)
        => View(IndexView, mediator.Send(message));

        public ActionResult AdvantPlayResult(AdvantPlayResultQuery message)
        => View(IndexView, mediator.Send(message));

        public ActionResult AdvantPlayMiniResult(AdvantPlayMiniResultQuery message)
        => View(IndexView, mediator.Send(message));

        public ActionResult BBINResult(BBINResultQuery message)
        => View(IndexView, mediator.Send(message));

        public ActionResult RngCasinoResult(RNGCasinoResultQuery message)
        => View(IndexView, mediator.Send(message));

        public ActionResult MacauGamesResult(MacauGamesResultQuery message)
        => View(IndexView, mediator.Send(message));

        public ActionResult PPResult(PPResultQuery message)
        => View(IndexView, mediator.Send(message));

        public ActionResult SpadeGamingResult(SpadeGamingResultQuery message)
        => View(IndexView, mediator.Send(message));

        public ActionResult RNGWarResult(RNGWarResultQuery message)
        => View(IndexView, mediator.Send(message));

        public ActionResult IONCasinoResult(IONCasinoResultQuery message)
        => View(IndexView, mediator.Send(message));

        public ActionResult PGSoftResult(PGSoftResultQuery message)
        => View(IndexView, mediator.Send(message));
        public ActionResult JokerResult(JokerResultQuery message)
        => View(IndexView, mediator.Send(message));

        public ActionResult GDGResult(GDGResultQuery message)
        => View(IndexView, mediator.Send(message));

        public ActionResult LinkedGamesResult(LinkedGamesResultQuery message)
        => View(IndexView, mediator.Send(message));

        public ActionResult BGResult(BGResultQuery message)
        => View(IndexView, mediator.Send(message));

        public ActionResult CardClubResult(CardClubResultQuery message)
        => View(IndexView, mediator.Send(message));

        public ActionResult FGGResult(FGGResultQuery message)
        => View(IndexView, mediator.Send(message));

        public ActionResult VirtualGamesResult(VirtualGamesDetailResultQuery message)
        => View(IndexView, mediator.Send(message));

        public ActionResult SEALResult(SEALResultQuery message)
        => View(IndexView, mediator.Send(message));
        public ActionResult MGResult(MGResultQuery message)
        => View(IndexView, mediator.Send(message));
    }
}
