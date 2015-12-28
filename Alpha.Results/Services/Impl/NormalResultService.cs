namespace Alpha.Results.Services.Impl
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Criteria;
    using Fanex.Common.Helper;
    using Fanex.Data.Repository;
    using Models;
    using Products;
    using Sunplus.Agent.Model.BL.Definitions;

    public class NormalResultService : INormalResultService
    {
        public const int MetricGaming60sofKick = 801;
        public const int MetricGamingEndBetType = 899;

        private IDynamicRepository _dynamicRepository;

        public NormalResultService() : this(null)
        {
        }

        public NormalResultService(IDynamicRepository dynamicRepository)
        {
            _dynamicRepository = dynamicRepository ?? new DynamicRepository();
        }

        public IEnumerable<League> GetLeagues(DateTime resultDate, int sportId, string language, bool disableHouseRacingWin)
        {
            Check.Argument.IsNotNegativeOrZero(sportId, "sportId");
            Check.Argument.IsNotEmpty(language, "language");

            if (sportId == (int)SportType.HorseRacing
                && disableHouseRacingWin)
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
                EventDate = resultDate.ToShortDateString(),
                IsShowAll = true
            }).ToList();

            if (sports.Any())
            {
                sports.RemoveAll(sport => sportsStatus.Keys.Contains(sport.Id) && !sportsStatus[sport.Id]);
            }

            return sports;
        }

        public string GetResults(NormalRequest request)
        {
            Check.Argument.IsNotNull(request, "request");

            var resultService = GetResultService((SportType)request.SportId, request.BetTypeId);

            return resultService.GetResult(request);
        }

        private IProductResultService GetResultService(SportType sportType, int betTypeId)
        {
            switch (sportType)
            {
                case SportType.Soccer:
                    if (MetricGaming60sofKick <= betTypeId && betTypeId <= MetricGamingEndBetType)
                    {
                        return new MetricGamingResultService();
                    }

                    return new SportsbookResultService();

                case SportType.BasketBall:
                case SportType.Netball:
                case SportType.FootBall:
                case SportType.Rugby:
                case SportType.IceHockey:
                case SportType.FieldHockey:
                case SportType.Tennis:
                case SportType.VolleyBall:
                case SportType.Badminton:
                case SportType.Squash:
                case SportType.BaseBall:
                case SportType.Golf:
                case SportType.Motorsports:
                case SportType.HRFixedOdds:
                case SportType.Billard:
                case SportType.Cycling:
                case SportType.Fencing:
                case SportType.Judo:
                case SportType.ModernPentathlon:
                case SportType.Rowing:
                case SportType.Sailing:
                case SportType.Shooting:
                case SportType.Taekwondo:
                case SportType.Triathlon:
                case SportType.Wrestling:
                case SportType.Winter:
                case SportType.ESports:
                case SportType.VirtualSports:
                case SportType.VirtualTennis:

                    if (betTypeId == (int)BetType.Mix_Parlay
                        || betTypeId == (int)BetType.Combine_Mix_Parlay)
                    {
                        return new ParlayResultService();
                    }

                    return new SportsbookResultService();

                case SportType.HorseRacing:
                case SportType.Greyhound:
                case SportType.Harness:
                    return new RacingResultService();

                case SportType.NumberGame:
                    return new NumberGameResultService();

                case SportType.LiveCasino:
                    return new NumberGameResultService();

                case SportType.VirtualHorsesRacing:
                case SportType.VirtualGreyhounds:
                case SportType.VirtualMotors:
                case SportType.VirtualCycling:
                case SportType.VirtualSpeedway:
                    return new VirtualRacingResultService();

                case SportType.GoldDeluxe:
                    return new GoldDeluxePopupResultService();

                default:
                    return new SportsbookResultService();
            }
        }

        public byte[] GetExcelResults(NormalRequest request, string templatePath)
        {
            Check.Argument.IsNotNull(request, "request");
            Check.Argument.IsNotNegativeOrZero(request.SportId, "request.SportId");

            var resultService = GetResultService((SportType)request.SportId, request.BetTypeId);

            var memoryResult = resultService.ExportExcel(request, templatePath);

            return memoryResult.ToArray();
        }

        public string GetResultDetails(NormalDetailsRequest detailRequest)
        {
            Check.Argument.IsNotNull(detailRequest, "detailRequest");

            var resultService = GetResultService((SportType)detailRequest.SportId, detailRequest.BetTypeId);

            return resultService.GetResultDetails(detailRequest);
        }
    }
}