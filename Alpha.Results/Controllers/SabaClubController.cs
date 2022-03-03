namespace Alpha.Results.Site.Controllers
{
    using System.Web.Mvc;
    using MediatR;
    using Models.Requests;
    using Sunplus.Agent.Model.Entities;

    public class SabaClubController : ResultBaseController
    {
        public SabaClubController(IMediator mediator, IUserSession userSession)
            : base(mediator, userSession)
        {
        }

        public ActionResult Index(SabaClubResultQuery request)
        {
            request.Language = userSession.Language;

            return View(request);
        }
    }
}
