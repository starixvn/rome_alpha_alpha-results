namespace Alpha.Results.Site.Controllers
{
    using System.Web.Mvc;
    using MediatR;
    using Models.Requests;

    public class LinkedGamesController : ResultBaseController
    {
        public LinkedGamesController(IMediator mediator) : base(mediator)
        {
        }

        public ActionResult GetSoccer5Result(Soccer5ResultQuery query)
            => View("~/Views/LinkedGames/Index.cshtml", query);
    }
}
