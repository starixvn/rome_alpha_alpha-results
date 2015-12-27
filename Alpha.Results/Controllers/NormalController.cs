namespace Alpha.Results.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Web.Mvc;
    using LocalResources;
    using System.Linq;
    using Models;
    using Services;
    using Services.Impl;
    using Sunplus.Agent.Model.Entities.Permission;
    using ViewModels;
    using Sunplus.Agent.Model.Entities;
    using Sunplus.Agent.Model.BL.Cache;
    using Sunplus.Agent.Model.BL.Definitions;
    using Services.Impl.Result;
    public class NormalController : BaseController
    {
        private readonly INormalService _normalService;
        

        public NormalController() : this(null)
        {
        }

        public NormalController(INormalService normalService)
        {
            _normalService = normalService ?? new NormalService();
        }

        [HttpGet]
        public ActionResult Index(NormalRequest request = null)
        {
            request = request ?? new NormalRequest();
            var balanceUpDate = _normalService.GetBalanceUpDate().BalanceUpDay;
            var sports = GetSportsResult(request.ResultDate);

            var viewModel = new NormalViewModel
            {
                ResultDate = request.ResultDate,
                Today = DateTime.Now.ToShortDateString(),
                Yesterday = DateTime.Now.AddDays(-1).ToShortDateString(),
                MinResultDate = balanceUpDate,
                MinResultDateMessage = string.Format(ResultLang.ViewDataFromDate, balanceUpDate.ToShortDateString()),
                Sports = sports,
                SportId = request.SportId > 0 ? request.SportId : int.Parse(sports.First().Value)
            };

            if(viewModel.Sports.Any())
            {
                viewModel.Leagues = GetLeaguesResult(request.ResultDate, viewModel.SportId);
                viewModel.LeagueId = request.LeagueId;
                viewModel.HtmlResults = _normalService.GetHtmlResults(new NormalRequest
                {
                    ResultDate = viewModel.ResultDate,
                    SportId = viewModel.SportId,
                    LeagueId = viewModel.LeagueId
                });
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