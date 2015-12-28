namespace Alpha.Results.Controllers
{
	using Fanex.Result.Core.Sportsbook.DTO;
	using LocalResources;
	using Models;
	using Services;
	using Services.Impl;
	using Sunplus.Agent.Model.BL.Cache;
	using System;
	using System.Collections.Generic;
	using System.Linq;
	using System.Web.Mvc;
	using ViewModels;

	public class OutrightController : BaseController
	{
		private readonly IOutRightService _outrightService;

		public OutrightController()
			: this(null)
		{
		}

		public OutrightController(IOutRightService outrightService)
		{
			_outrightService = outrightService ?? new OutRightService();
		}

		[HttpGet]
		public ActionResult Index(OutrightRequest request = null)
		{
			DateTime currentDate = DateTime.Today;
			DateTime balanceUpDate = _outrightService.GetBalanceUpDate().BalanceUpDay;

			request = request ?? new OutrightRequest();
			OutrightViewModel viewModel = new OutrightViewModel
			{
				MinResultDate = balanceUpDate,
				MaxResultDate = currentDate,
				Today = currentDate.ToShortDateString(),
				Yesterday = currentDate.AddDays(-1).ToShortDateString(),
				MinResultDateMessage = string.Format(ResultLang.ViewDataFromDate, balanceUpDate.ToShortDateString()),
				FromDate = request.FromDate,
				ToDate = request.ToDate
			};

			var outrights = _outrightService.GetOutRights(request.FromDate, request.ToDate);
			if (outrights.Count() > 0)
			{
				viewModel.SportId = request.SportId > 0 ? request.SportId : outrights.First().SportType;
				viewModel.LeagueId = request.LeagueId;
				viewModel = GetSportsAndLeagues(viewModel, outrights, viewModel.SportId, viewModel.LeagueId);
			}

			viewModel.HtmlResults = _outrightService.GetResults(outrights, viewModel.SportId, viewModel.LeagueId);
			return View(viewModel);
		}

		[HttpGet]
		public ActionResult ExcelResults(OutrightRequest request)
		{
			var excelResult = _outrightService.ExportExcel(request, Server.MapPath(@"~/App_Data/Fanex.Result/"));
			return File(excelResult, "application/vnd.ms-excel", "Result.xls");
		}

		[NonAction]
		private OutrightViewModel GetSportsAndLeagues(OutrightViewModel viewModel, IEnumerable<OutRight> outrights, int sportId, int leagueId)
		{
			IList<SelectListItem> sportTypes = new List<SelectListItem>();
			IList<SelectListItem> leagues = new List<SelectListItem>();

			var outrightsGroup = outrights.GroupBy(o => new { SportType = o.SportType, LeagueId = o.LeagueId });
			foreach (var group in outrightsGroup)
			{
				var key = group.Key;
				sportTypes.Add(new SelectListItem
				{
					Value = key.SportType.ToString(),
					Text = CacheRef.GetSportName(key.SportType),
					Selected = key.SportType == sportId
				});

				leagues.Add(new SelectListItem
				{
					Value = key.LeagueId.ToString(),
					Text = CacheRef.GetLeagueName(key.LeagueId),
					Selected = key.LeagueId == leagueId
				});
			}

			viewModel.Sports = sportTypes;
			viewModel.Leagues = leagues;
			return viewModel;
		}
	}
}