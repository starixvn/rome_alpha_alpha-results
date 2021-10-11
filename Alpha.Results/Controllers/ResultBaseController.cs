namespace Alpha.Results.Site.Controllers
{
    using System.Web.Mvc;
    using Alpha.Web;
    using Alpha.Web.Models;
    using MediatR;
    using Sunplus.Agent.Model.Entities;

#pragma warning disable S1694 // An abstract class should have both abstract and concrete methods
    public abstract class ResultBaseController : BaseController
#pragma warning restore S1694 // An abstract class should have both abstract and concrete methods
    {
        protected readonly IMediator mediator;
        protected readonly IUserSession userSession;

        protected ResultBaseController(IMediator mediator, IUserSession userSession)
        {
            this.mediator = mediator;
            this.userSession = userSession;
        }

        protected ActionResult View<TResponse>(IRequest<TResponse> message)
        {
            AssignDarkModeViewData();

            return View(mediator.Send(message));
        }

        protected ActionResult View<TResponse>(string viewName, IRequest<TResponse> message)
        {
            AssignDarkModeViewData();

            return View(viewName, mediator.Send(message));
        }

        protected void AssignDarkModeViewData()
        {
            ViewData["DarkModeName"] = userSession.DarkModeName;
            ViewData["TitleLevel"] = Enumeration.FromValue<UserLevel>(userSession.RoleId).DisplayName.ToLowerInvariant();
        }
    }
}