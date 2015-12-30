namespace Alpha.Results.Site.Handlers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web.Mvc;
    using App_GlobalResources;
    using Fanex.Common.Helper;
    using Fanex.Result.Core.Sportsbook.DTO;
    using MediatR;
    using Models.Requests;
    using Models.Views;
    using Services;
    using Sunplus.Agent.Model.RemotingRef;

    public class OutrightResultHandler :
         IRequestHandler<ViewOutrightResultQuery, OutrightViewModel>,
         IRequestHandler<DownloadOutrightResultExcelQuery, OutrightResultExcelViewModel>
    {
        private readonly IOutrightResultService _outrightService;

        public OutrightResultHandler(IOutrightResultService outrightService)
        {
            _outrightService = outrightService;
        }

        public OutrightResultExcelViewModel Handle(DownloadOutrightResultExcelQuery message)
        {
            Check.Argument.IsNotNull(message, "message");

            var excelResults = _outrightService.GetExcelResults(message);

            return new OutrightResultExcelViewModel
            {
                ExcelResults = excelResults.ToArray()
            };
        }

        public OutrightViewModel Handle(ViewOutrightResultQuery message)
        {
            Check.Argument.IsNotNull(message, "message");

            DateTime currentDate = DateTime.Today;
            DateTime balanceUpDate = _outrightService.GetBalanceUpDate().BalanceUpDay;

            OutrightViewModel viewModel = new OutrightViewModel
            {
                MinResultDate = balanceUpDate,
                MaxResultDate = currentDate,
                Today = currentDate.ToShortDateString(),
                Yesterday = currentDate.AddDays(-1).ToShortDateString(),
                MinResultDateMessage = string.Format(Resources.ViewDataFromDate, balanceUpDate.ToShortDateString()),
                FromDate = message.FromDate,
                ToDate = message.ToDate
            };

            var outrights = _outrightService.GetOutrights(message.FromDate, message.ToDate);

            if (outrights.Count() > 0)
            {
                viewModel.SportType = message.SportType > 0 ? message.SportType : outrights.First().SportType;
                viewModel.LeagueId = message.LeagueId;
                viewModel = GetSportsAndLeagues(viewModel, outrights, viewModel.SportType, viewModel.LeagueId);
            }

            viewModel.HtmlResults = _outrightService.GetResults(outrights, message);

            return viewModel;
        }

        private OutrightViewModel GetSportsAndLeagues(OutrightViewModel viewModel, IEnumerable<Outright> outrights, int selectedSportType, int selectedLeagueId)
        {
            Check.Argument.IsNotNull(viewModel, "viewModel");
            Check.Argument.IsNotNull(outrights, "outrights");

            IList<SelectListItem> sportTypes = new List<SelectListItem>();
            IList<SelectListItem> leagues = new List<SelectListItem>();
            var outrightsGroup = outrights.GroupBy(o => new { SportType = o.SportType, LeagueId = o.LeagueId });

            foreach (var group in outrightsGroup)
            {
                var key = group.Key;
                sportTypes.Add(new SelectListItem
                {
                    Value = key.SportType.ToString(),
                    Text = CacheRefFactory.CacheRef.GetSportName(key.SportType),
                    Selected = key.SportType == selectedSportType
                });

                leagues.Add(new SelectListItem
                {
                    Value = key.LeagueId.ToString(),
                    Text = CacheRefFactory.CacheRef.GetLeagueName(key.LeagueId),
                    Selected = key.LeagueId == selectedLeagueId
                });
            }

            viewModel.Sports = sportTypes;
            viewModel.Leagues = leagues;

            return viewModel;
        }
    }
}