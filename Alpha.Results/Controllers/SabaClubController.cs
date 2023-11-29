namespace Alpha.Results.Site.Controllers
{
    using System.Web.Mvc;
    using AlphaPlus.User.Models;
    using MediatR;
    using Models.Requests;

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
