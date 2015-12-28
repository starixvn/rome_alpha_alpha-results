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
        private readonly INormalService _normalService;
        private readonly IReportService _reportService;

        public NormalController() : this(null, null)
        {
        }

        public NormalController(INormalService normalService, IReportService reportService)
        {
            _normalService = normalService ?? new NormalService();
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
                Today = DateTime.Now.ToShortDateString(),
                Yesterday = DateTime.Now.AddDays(-1).ToShortDateString(),
                MinResultDate = balanceUpDate,
                MinResultDateMessage = string.Format(ResultLang.ViewDataFromDate, balanceUpDate.ToShortDateString()),
                Sports = sports
            };

            if (viewModel.Sports.Any())
            {
                viewModel.SportId = request.SportId > 0 ? request.SportId : int.Parse(sports.First().Value);
                viewModel.Leagues = GetLeaguesResult(request.ResultDate, viewModel.SportId);
                viewModel.LeagueId = request.LeagueId;
                
            }

            viewModel.HtmlResults = _normalService.GetResults(new NormalRequest
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

            var sports = _normalService.GetSports(resultDate, sportsStatus);

            return sports.Select<Sport, SelectListItem>(sport => new SelectListItem
            {
                Text = CacheRef.GetSportName(sport.Id),
                Value = sport.Id.ToString()
            });
        }

        public IEnumerable<SelectListItem> GetLeaguesResult(DateTime resultDate, int sportTypeId)
        {
            var leagues = _normalService.GetLeagues(
                                resultDate,
                                sportTypeId,
                                UserSession.Current.Language,
                                Sunplus.Agent.Model.BL.Definitions.AppSettings.Disable151_31);

            return leagues.Select<League, SelectListItem>(league => new SelectListItem
            {
                Text = CacheRef.GetLeagueName(league.Id),
                Value = league.Id.ToString()
            });
        }
    }
}