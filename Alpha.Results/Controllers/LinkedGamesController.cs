namespace Alpha.Results.Site.Controllers
{
    using System.Web.Mvc;
    using MediatR;
    using Models.Requests;
    using Sunplus.Agent.Model.Entities;

    public class LinkedGamesController : ResultBaseController
    {
        public LinkedGamesController(IMediator mediator, IUserSession userSession)
            : base(mediator, userSession)
        {
        }
       
        public ActionResult GetSoccer5Result(Soccer5ResultQuery query)
        {
            query.Language = userSession.Language;

            var viewModel = mediator.Send(query);

            return View("~/Views/LinkedGames/Index.cshtml", (object)viewModel);
        }
    }
}
