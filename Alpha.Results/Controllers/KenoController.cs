namespace Alpha.Results.Site.Controllers
{
    using System;
    using System.Web.Mvc;
    using Models.Views;
    using Sunplus.Agent.Model.Entities;

    public class KenoController : BaseController
    {
        public ActionResult Index()
        {
            var userSession = UserSession.Current;
            KenoViewModel viewModel = new KenoViewModel
            {
                ResultDate = DateTime.Today.ToString("yyyyMMdd"),
                LanguageKey = userSession.LangKey,
                CustomerId = userSession.CustId
            };

            return View(viewModel);
        }
    }
}