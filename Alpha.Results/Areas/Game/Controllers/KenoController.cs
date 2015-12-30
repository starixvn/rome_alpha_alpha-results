namespace Alpha.Results.Areas.Game.Controllers
{
	using Models.Views;
	using Results.Controllers;
	using Sunplus.Agent.Model.Entities;
	using System;
	using System.Web.Mvc;

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