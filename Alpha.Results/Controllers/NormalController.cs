namespace Alpha.Results.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web.Mvc;
    using LocalResources;
    using Models;
    using Services;
    using Services.Impl;
    using Sunplus.Agent.Model.BL.Cache;
    using Sunplus.Agent.Model.BL.Definitions;
    using Sunplus.Agent.Model.Entities;
    using Sunplus.Agent.Model.Entities.Permission;
    using ViewModels;

    public class NormalController : BaseController
    {
        private readonly INormalResultService _normalResultService;
        private readonly IReportService _reportService;

        public NormalController() : this(null, null)
        {
        }

        public NormalController(INormalResultService normalResultService, IReportService reportService)
        {
            _normalResultService = normalResultService ?? new NormalResultService();
            _reportService = reportService ?? new ReportService();
        }

        [HttpGet]
        public ActionResult Index(NormalRequest request = null)
        {
            request = request ?? new NormalRequest();
            var balanceUpDate = _reportService.GetBalanceUpDate().BalanceUpDay;
            var sports = GetSportsResult(request.ResultDate);

            var viewModel = new NormalViewModel
            {
                ResultDate = request.ResultDate,
                MinResultDate = balanceUpDate,
                Sports = sports
            };

            if (viewModel.Sports.Any())
            {
                viewModel.SportId = request.SportId > 0 ? request.SportId : int.Parse(sports.First().Value);
                viewModel.Leagues = GetLeaguesResult(request.ResultDate, viewModel.SportId);
                viewModel.LeagueId = request.LeagueId;
            }

            viewModel.HtmlResults = _normalResultService.GetResults(new NormalRequest
            {
                ResultDate = viewModel.ResultDate,
                SportId = viewModel.SportId,
                LeagueId = viewModel.LeagueId
            });

            return View(viewModel);
        }

        private IEnumerable<SelectListItem> GetSportsResult(DateTime resultDate)
        {
            var sportsStatus = new Dictionary<int, bool>
            {
                { (int)SportType.NumberGame,  UserPermission.IsShowNumberGame },
                { (int)SportType.LiveCasino,  UserPermission.IsShowLiveCasino },
                { (int)SportType.GoldDeluxe,  UserPermission.IsShowGoldDeluxeSettingForCredit }
            };

            var sports = _normalResultService.GetSports(resultDate, sportsStatus);

            return sports.Select(sport => new SelectListItem
            {
                Text = CacheRef.GetSportName(sport.Id),
                Value = sport.Id.ToString()
            });
        }

        public IEnumerable<SelectListItem> GetLeaguesResult(DateTime resultDate, int sportTypeId)
        {
            var leagues = _normalResultService.GetLeagues(
                                resultDate,
                                sportTypeId,
                                UserSession.Current.Language,
                                AppSettings.Disable151_31);

            return leagues.Select(league => new SelectListItem
            {
                Text = CacheRef.GetLeagueName(league.Id),
                Value = league.Id.ToString()
            });
        }

        [HttpGet]
        public ActionResult ResultDetails(NormalDetailsRequest request)
        {
            var viewModel = new NormalDetailViewModel
            {
                Title = string.Format("{0} - {1}", CacheRef.GetSportName(request.SportId), CacheRef.GetLeagueName(request.LeagueId)),
                HtmlResults = _normalResultService.GetResultDetails(request)
            };

            return View(viewModel);
        }

        [HttpGet]
        public ActionResult ExcelResults(NormalRequest request)
        {
            var excelResult = _normalResultService.GetExcelResults(request, Server.MapPath(@"~/App_Data/Fanex.Result/"));

            return File(excelResult, "application/vnd.ms-excel", "Result.xls");
        }
    }
}