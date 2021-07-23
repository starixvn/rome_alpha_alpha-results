namespace Alpha.Results.Site.Controllers
{
    using System.Web.Mvc;
    using MediatR;
    using Models.Requests;
    using Sunplus.Agent.Model.Entities;

    public class KenoController : ResultBaseController
    {
        public KenoController(IMediator mediator, IUserSession userSession)
            : base(mediator, userSession)
        {
        }

        [HttpGet]
        public ActionResult Index() => View(new KenoResultQuery(userSession));
    }
}
