using System.Web.Mvc;
using Alpha.Results.Site.Models.Requests;
using Alpha.Web;
using MediatR;
using Sunplus.Agent.Model.Entities;

namespace Alpha.Results.Site.Controllers
{
    public class LotteryController : BaseController
    {
        private readonly IMediator _mediator;

        public LotteryController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public ActionResult Index()
        {
#pragma warning disable CS0618 // Type or member is obsolete
            var userSession = UserSession.Current;
#pragma warning restore CS0618 // Type or member is obsolete

            var viewModel = _mediator.Send(new LotteryResultQuery
            {
                LanguageKey = userSession.LangKey,
                CustId = userSession.CustId,
                CustLevelId = userSession.RoleId,
                RootPath = HttpContext.Response.ApplyAppPathModifier("~/")
            });

            return View(viewModel);
        }
    }
}
