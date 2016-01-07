namespace Alpha.Results.Site.Handlers
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics.CodeAnalysis;
    using System.Linq;
    using System.Web.Mvc;
    using Alpha.Utilities.Extensions;
    using App_GlobalResources;
    using Fanex.Common.Helper;
    using Fanex.Result.Core.Sportsbook.DTO;
    using MediatR;
    using Models.Requests;
    using Models.Views;
    using Services;
    using Sunplus.Agent.Model.RemotingRef;

    public class OutrightResultHandler :
         IRequestHandler<OutrightResultQuery, OutrightResultViewModel>,
         IRequestHandler<ExcelOutrightResultQuery, OutrightResultExcelViewModel>
    {
        private readonly IOutrightResultService _outrightService;
        private readonly IReportDateService _reportService;

        public OutrightResultHandler(IOutrightResultService outrightService, IReportDateService reportService)
        {
            _outrightService = outrightService;
            _reportService = reportService;
        }

        public OutrightResultExcelViewModel Handle(ExcelOutrightResultQuery message)
        {
            Check.Argument.IsNotNull(message, "message");

            var excelResults = _outrightService.GetExcelResults(message, _reportService.GetBalanceUpDate());

            return new OutrightResultExcelViewModel
            {
                ExcelResults = excelResults.ToArray()
            };
        }

        [SuppressMessage("Microsoft.Design", "CA1062:Validate arguments of public methods", MessageId = "0", Justification = "Reviewed")]
        public OutrightResultViewModel Handle(OutrightResultQuery message)
        {
            Check.Argument.IsNotNull(message, "message");

            DateTime currentDate = DateTime.Today;
            DateTime balanceUpDate = _reportService.GetBalanceUpDate();

            OutrightResultViewModel viewModel = new OutrightResultViewModel
            {
                MinResultDate = balanceUpDate,
                MaxResultDate = currentDate,
                Today = currentDate.ToShortDateFormatWithSlash(),
                Yesterday = currentDate.AddDays(-1).ToShortDateFormatWithSlash(),
                MinResultDateMessage = string.Format(Resources.ViewDataFromDate, balanceUpDate.ToShortDateString()),
                FromDate = message.FromDate,
                ToDate = message.ToDate
            };

            var outrights = _outrightService.GetOutrights(message.FromDate, message.ToDate, balanceUpDate);

            if (outrights.Any())
            {
                viewModel.SportType = message.SportType > 0
                    ? message.SportType
                    : outrights.First().SportType;

                viewModel.LeagueId = message.LeagueId;
                viewModel = GetSportsAndLeagues(viewModel, outrights, viewModel.SportType, viewModel.LeagueId);
            }

            viewModel.HtmlResults = _outrightService.GetResults(outrights, message);

            return viewModel;
        }

        private OutrightResultViewModel GetSportsAndLeagues(OutrightResultViewModel viewModel, IEnumerable<Outright> outrights, int selectedSportType, int selectedLeagueId)
        {
            Check.Argument.IsNotNull(viewModel, "viewModel");
            Check.Argument.IsNotNull(outrights, "outrights");

            IList<SelectListItem> sportTypes = new List<SelectListItem>();
            IList<SelectListItem> leagues = new List<SelectListItem>();

            var outrightsGroup = outrights
                .GroupBy(outright => new
                {
                    SportType = outright.SportType,
                    LeagueId = outright.LeagueId
                });

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