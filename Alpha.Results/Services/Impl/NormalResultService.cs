namespace Alpha.Results.Services.Impl
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Commands;
    using Criteria;
    using Fanex.Common.Helper;
    using Fanex.Data.Repository;
    using Models;
    using Sunplus.Agent.Model.BL.Definitions;

    public class NormalResultService : INormalResultService
    {
        private readonly IDynamicRepository _dynamicRepository;
        private readonly IResultServiceFactory _resultServiceFactory;

        public NormalResultService(
            IDynamicRepository dynamicRepository,
            IResultServiceFactory resultServiceFactory)
        {
            _dynamicRepository = dynamicRepository ?? new DynamicRepository();
            _resultServiceFactory = resultServiceFactory ?? new ResultServiceFactory();
        }

        public IEnumerable<League> GetLeagues(DateTime resultDate, int sportId, string language, bool disableHorseRacingWin)
        {
            Check.Argument.IsNotNegativeOrZero(sportId, "sportId");
            Check.Argument.IsNotEmpty(language, "language");

            if (sportId == (int)SportType.HorseRacing
                && disableHorseRacingWin)
            {
                return Enumerable.Empty<League>();
            }

            var leagues = _dynamicRepository.Fetch<League>(new GetResultLeaguesByDateCriteria
            {
                EventDate = resultDate.ToShortDateString(),
                Language = language,
                SportType = sportId
            });

            return leagues;
        }

        public IEnumerable<Sport> GetSports(DateTime resultDate, IDictionary<int, bool> sportsStatus)
        {
            var sports = _dynamicRepository.Fetch<Sport>(new GetResultSportsByDateCriteria
            {
                EventDate = resultDate.ToShortDateString()
            }).ToList();

            if (sports.Any())
            {
                sports.RemoveAll(sport => sportsStatus.Keys.Contains(sport.Id) && !sportsStatus[sport.Id]);
            }

            return sports;
        }

        public string GetResults(ViewNormalResultQuery request)
        {
            Check.Argument.IsNotNull(request, "request");

            var resultService = _resultServiceFactory.CreateProductResultService(request.SportId, request.BetTypeId);

            return resultService.GetResult(request);
        }

        public byte[] GetExcelResults(ViewNormalResultQuery request, string templatePath)
        {
            Check.Argument.IsNotNull(request, "request");
            Check.Argument.IsNotNegativeOrZero(request.SportId, "request.SportId");
            Check.Argument.IsNotEmpty(templatePath, "templatePath");

            var resultService = _resultServiceFactory.CreateProductResultService(request.SportId, request.BetTypeId);

            var memoryResult = resultService.ExportExcel(request, templatePath);

            return memoryResult.ToArray();
        }

        public string GetResultDetails(ViewNormalResultDetailsQuery detailRequest)
        {
            Check.Argument.IsNotNull(detailRequest, "detailRequest");

            var resultService = _resultServiceFactory.CreateProductResultService(detailRequest.SportId, detailRequest.BetTypeId);

            return resultService.GetResultDetails(detailRequest);
        }
    }
}