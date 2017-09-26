namespace Alpha.Results.Site.Controllers
{
    using System.Web.Mvc;
    using MediatR;
    using Models.Requests;
    using Sunplus.Agent.Model.Entities;
    using Web;

    public class HandHistoryController : BaseController
    {
        private readonly IMediator _mediator;

        public HandHistoryController(IMediator mediator)
        {
            _mediator = mediator;
        }

        public ActionResult RNGCasino(RNGCasinoResultQuery message)
            => ViewResult(message);

        public ActionResult MacauGames(MacauGamesResultQuery message)
            => ViewResult(message);

        public ActionResult FishingWorld(FishingWorldResultQuery message)
            => ViewResult(message);

        private ActionResult ViewResult(HandHistoryResultBaseQuery message)
        {
            var userSession = UserSession.Current;
            message.Language = userSession.Language;

            return View("Index", _mediator.Send(message));
        }
    }
}
