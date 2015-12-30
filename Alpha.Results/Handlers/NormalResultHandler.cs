namespace Alpha.Results.Handlers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web.Mvc;
    using Alpha.Utilities.Extensions;
    using App_GlobalResources;
    using Fanex.Common.Helper;
    using MediatR;
    using Models.Requests;
    using Models.Views;
    using Services;
    using Sunplus.Agent.Model.RemotingRef;

    public class NormalResultHandler :
        IRequestHandler<ViewNormalResultQuery, NormalViewModel>,
        IRequestHandler<ViewNormalResultDetailsQuery, NormalDetailViewModel>,
        IRequestHandler<DownloadNormalResultExcelQuery, NormalResultExcelViewModel>
    {
        private readonly INormalResultService _normalResultService;
        private readonly IReportService _reportService;

        public NormalResultHandler(INormalResultService normalResultService, IReportService reportService)
        {
            _normalResultService = normalResultService;
            _reportService = reportService;
        }

        public NormalViewModel Handle(ViewNormalResultQuery message)
        {
            Check.Argument.IsNotNull(message, "message");
            Check.Argument.IsNotEmpty(message.Language, "message.Language");

            var balanceUpDate = _reportService.GetBalanceUpDate().BalanceUpDay;
            var sports = GetSportsResult(message.ResultDate, message.SportsStatus);

            var viewModel = new NormalViewModel
            {
                ResultDate = message.ResultDate,
                MinResultDate = balanceUpDate,
                Sports = sports
            };

            if (viewModel.Sports.Any())
            {
                viewModel.SportId = message.SportId > 0 ? message.SportId : int.Parse(sports.First().Value);
                viewModel.Leagues = GetLeaguesResult(message.ResultDate, viewModel.SportId, message.Language, message.DisableHorseRacingWin);
                viewModel.LeagueId = message.LeagueId;
            }

            viewModel.HtmlResults = _normalResultService.GetResults(new ViewNormalResultQuery
            {
                ResultDate = viewModel.ResultDate,
                SportId = viewModel.SportId,
                LeagueId = viewModel.LeagueId,
                Language = message.Language
            });

            return viewModel;
        }

        private IEnumerable<SelectListItem> GetSportsResult(DateTime resultDate, IDictionary<int, bool> sportsStatus)
        {
            Check.Argument.IsNotNull(sportsStatus, "sportsStatus");

            var sports = _normalResultService.GetSports(resultDate, sportsStatus);

            return sports.Select(sport => new SelectListItem
            {
                Text = CacheRefFactory.CacheRef.GetSportName(sport.Id),
                Value = sport.Id.ToString()
            });
        }

        public IEnumerable<SelectListItem> GetLeaguesResult(DateTime resultDate, int sportTypeId, string language, bool disableHorseRacingWin)
        {
            var leagues = _normalResultService.GetLeagues(
                                resultDate,
                                sportTypeId,
                                language,
                                disableHorseRacingWin);

            return leagues.Select(league => new SelectListItem
            {
                Text = CacheRefFactory.CacheRef.GetLeagueName(league.Id),
                Value = league.Id.ToString()
            });
        }

        public NormalDetailViewModel Handle(ViewNormalResultDetailsQuery message)
        {
            Check.Argument.IsNotNull(message, "message");

            var viewModel = new NormalDetailViewModel
            {
                Title = $"{CacheRefFactory.CacheRef.GetSportName(message.SportId)} - {CacheRefFactory.CacheRef.GetLeagueName(message.LeagueId)}",
                HtmlResults = _normalResultService.GetResultDetails(message),
                IsViewResultFromBetList = message.IsViewResultFromBetList
            };

            return viewModel;
        }

        public NormalResultExcelViewModel Handle(DownloadNormalResultExcelQuery message)
        {
            Check.Argument.IsNotNull(message, "message");

            var leagueName = message.LeagueId == 0 ? Resources.ShowAllLeaguesExcelTitle : CacheRefFactory.CacheRef.GetLeagueName(message.LeagueId);
            var resultDate = message.ResultDate.ToShortDateFormatWithSlash();

            message.ExcelTitle = $"{Resources.Results} - {resultDate} | {CacheRefFactory.CacheRef.GetSportName(message.SportId)} {leagueName}";

            var excelResults = _normalResultService.GetExcelResults(message);

            return new NormalResultExcelViewModel
            {
                ExcelResults = excelResults
            };
        }
    }
}