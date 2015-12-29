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
		private readonly IOutRightResultService _outrightService;

		public OutrightController()
			: this(null)
		{
		}

		public OutrightController(IOutRightResultService outrightService)
		{
			_outrightService = outrightService ?? new OutRightResultService();
		}

		[HttpGet]
		public ActionResult Index(OutRightRequest request = null)
		{
			DateTime currentDate = DateTime.Today;
			DateTime balanceUpDate = _outrightService.GetBalanceUpDate().BalanceUpDay;

			request = request ?? new OutRightRequest();
			OutRightViewModel viewModel = new OutRightViewModel
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
				viewModel.SportType = request.SportType > 0 ? request.SportType : outrights.First().SportType;
				viewModel.LeagueId = request.LeagueId;
				viewModel = GetSportsAndLeagues(viewModel, outrights, viewModel.SportType, viewModel.LeagueId);
			}

			viewModel.HtmlResults = _outrightService.GetResults(outrights, request);
			return View(viewModel);
		}

		[HttpGet]
		public ActionResult ExcelResults(OutRightRequest request)
		{
			const string excelTemplatePath = @"~/App_Data/Fanex.Result/";

			var outrights = _outrightService.GetOutRights(request.FromDate, request.ToDate);
			var excelResult = _outrightService.GetExcelResults(outrights, request, Server.MapPath(excelTemplatePath));

			return File(excelResult.ToArray(), "application/vnd.ms-excel", "Result.xls");
		}

		[NonAction]
		private OutRightViewModel GetSportsAndLeagues(OutRightViewModel viewModel, IEnumerable<OutRight> outrights, int selectedSportType, int selectedLeagueId)
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
					Selected = key.SportType == selectedSportType
				});

				leagues.Add(new SelectListItem
				{
					Value = key.LeagueId.ToString(),
					Text = CacheRef.GetLeagueName(key.LeagueId),
					Selected = key.LeagueId == selectedLeagueId
				});
			}

			viewModel.Sports = sportTypes;
			viewModel.Leagues = leagues;
			return viewModel;
		}
	}
}