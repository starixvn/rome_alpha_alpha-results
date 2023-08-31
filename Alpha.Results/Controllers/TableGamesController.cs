namespace Alpha.Results.Site.Controllers
{
    using System.Web.Mvc;
    using AlphaPlus.User.Models;
    using MediatR;
    using Models.Requests;

    public class TableGamesController : ResultBaseController
    {
        public TableGamesController(IMediator mediator, IUserSession userSession)
            : base(mediator, userSession)
        {
        }

        [HttpGet]
        public ActionResult Index() => View(new TableGamesResultQuery(userSession));
    }
}
