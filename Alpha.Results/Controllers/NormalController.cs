namespace Alpha.Results.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Web.Mvc;
    using Fanex.Result.Core.Base;
    using LocalResources;
    using System.Linq;
    using Models;
    using Services;
    using Services.Impl;
    using Sunplus.Agent.Model.Entities.Permission;
    using ViewModels;
    using Sunplus.Agent.Model.Entities;
    using Sunplus.Agent.Model.BL.Cache;
    public class NormalController : BaseController
    {
        private readonly IResultService _resultService;

        public NormalController() : this(null)
        {
        }

        public NormalController(IResultService resultService)
        {
            _resultService = resultService ?? new ResultService();
        }

        [HttpGet]
        public ActionResult Index(DateTime? resultDate, int? sportId, int? leagueId)
        {
            var balanceUpDate = _resultService.GetBalanceUpDate().BalanceUpDay;
            var actualResultDate = resultDate ?? DateTime.Now;
            var viewModel = new NormalResultViewModel
            {
                ResultDate = actualResultDate,
                Today = DateTime.Now.ToShortDateString(),
                Yesterday = DateTime.Now.AddDays(-1).ToShortDateString(),
                MinResultDate = balanceUpDate,
                MinResultDateMessage = string.Format(ResultLang.ViewDataFromDate, balanceUpDate.ToShortDateString()),
                Sports = GetSportsResult(actualResultDate),
                SportId = sportId ?? 0
            };

            if(viewModel.Sports.Any())
            {
                viewModel.Leagues = GetLeaguesResult(actualResultDate, int.Parse(viewModel.Sports.First().Value));
                viewModel.LeagueId = leagueId ?? 0;
            }

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

            var sports = _resultService.GetSports(resultDate, sportsStatus);

            return sports.Select<Sport, SelectListItem>(sport => new SelectListItem
            {
                Text = CacheRef.GetSportName(sport.Id),
                Value = sport.Id.ToString()
            });
        }

        public IEnumerable<SelectListItem> GetLeaguesResult(DateTime resultDate, int sportTypeId)
        {
            var leagues = _resultService.GetLeagues(
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