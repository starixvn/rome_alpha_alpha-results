namespace Alpha.Results.Areas.Game.Controllers
{
    using System;
    using System.Web.Mvc;
    using Site.Controllers;
    using Site.Models.Views;
    using Sunplus.Agent.Model.Entities;

    public class KenoController : BaseController
    {
        [HttpGet]
        public ActionResult Index()
        {
            var userSession = UserSession.Current;
            KenoViewModel viewModel = new KenoViewModel
            {
                ResultDate = DateTime.Today.ToString("yyyyMMdd"),
                LanguageKey = userSession.LangKey,
                CustomerId = userSession.CustId
            };

            return View("~/Areas/Game/Views/Keno/Index.cshtml", viewModel);
        }
    }
}