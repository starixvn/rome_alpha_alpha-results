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

    public class NormalService : INormalService
    {
        private IDynamicRepository _dynamicRepository;

        public NormalService() : this(null)
        {
        }

        public NormalService(IDynamicRepository dynamicRepository)
        {
            _dynamicRepository = dynamicRepository ?? new DynamicRepository();
        }

        public IEnumerable<League> GetLeagues(DateTime resultDate, int sportId, string language, bool disableHouseRacingWin)
        {
            Check.Argument.IsNotNull(resultDate, "resultDate");
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
            Check.Argument.IsNotNull(resultDate, "resultDate");

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
            Check.Argument.IsNotNull(request.ResultDate, "request.ResultDate");

            var resultService = GetResultService((SportType)request.SportId);

            return resultService.GetResult(request);
        }

        private IProductResultService GetResultService(SportType sportType)
        {
            switch (sportType)
            {
                case SportType.Soccer:
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

        ////private string RenderSportsbookResults(NormalRequest request)
        ////{
        ////    //string result = resultRequest.MatchId > 0 ?
        ////    //    new SportsbookPopupResultService().GetResult(resultRequest) :
        ////    //    new SportsbookResultService().GetResult(resultRequest.FromDate.Value, resultRequest.SportId, resultRequest.LeagueId);
        ////    ////if (BetListHelperService.IsMetricGamingBetType(resultRequest.BetType))
        ////    ////{
        ////    ////    result = new MetricGamingResultService().GetResult(new GetMetricGamingResultCriteria
        ////    ////    {
        ////    ////        TransId = resultRequest.RefNum,
        ////    ////        BetType = resultRequest.BetType,
        ////    ////        BetId = resultRequest.BetId,
        ////    ////        SportType = resultRequest.SportId
        ////    ////    });
        ////    ////}

        ////    return new SportsbookResultService().GetResult(request.ResultDate, request.SportId, request.LeagueId);
        ////}

        ////private string RenderLiveCasinoResults(NormalRequest request)
        ////{
        ////    return string.Empty;
        ////    //return new LiveCasinoPopupResultService().GetResult(resultRequest.MatchId, resultRequest.BetType, resultRequest.LeagueId.ToString());
        ////}

        ////private string RenderGoldDeluxeResults(NormalRequest request)
        ////{
        ////    //string result = IsViewMatchResultPopup(resultRequest.MatchId) ?
        ////    //     :
        ////    //    null;

        ////    return new GoldDeluxePopupResultService().GetPopupResult(/*request.RefNum*/0, request.BetTypeId);
        ////}

        ////private string RenderRacingResults(NormalRequest request)
        ////{
        ////    //string result = resultRequest.MatchId > 0 ?
        ////    //    new RacingPopupResultService().GetResult(resultRequest.MatchId, this.GetRaceNumber(resultRequest.Race), resultRequest.SportId) :
        ////    //    new RacingResultService().GetResult(resultRequest.FromDate.Value, resultRequest.SportId, resultRequest.LeagueId);
        ////    return new RacingResultService().GetResult(request.ResultDate, request.SportId, request.LeagueId);
        ////}

        ////private string RenderNumberGameResults(NormalRequest request)
        ////{
        ////    //string result = resultRequest.MatchId > 0 ?
        ////    //   new NumberGamePopupResultService().GetResult(resultRequest.MatchId) :
        ////    //   new NumberGameResultService().GetResult(resultRequest.FromDate.Value, resultRequest.LeagueId, resultRequest.SportId);
        ////    return new NumberGameResultService().GetResult(request.ResultDate, request.SportId, request.LeagueId);
        ////}

        ////private string RenderVirtualRacingResults(NormalRequest request)
        ////{
        ////    //string result = resultRequest.MatchId > 0 ?
        ////    //    new RacingPopupResultService().GetResultForVirtualRacing(resultRequest.MatchId, this.GetRaceNumber(resultRequest.Race), resultRequest.SportId) :
        ////       return new VirtualRacingResultService().GetResult(request.ResultDate, request.SportId, request.LeagueId);
        ////}

        public byte[] GetExcelResults(NormalRequest request, string templatePath)
        {
            Check.Argument.IsNotNull(request, "request");
            Check.Argument.IsNotNull(request.ResultDate, "request.ResultDate");
            Check.Argument.IsNotNegativeOrZero(request.SportId, "request.SportId");

            var resultService = GetResultService((SportType)request.SportId);

            var memoryResult = resultService.ExportExcel(request, templatePath);

            return memoryResult.ToArray();
        }

        public string GetResultDetails(NormalDetailsRequest detailRequest)
        {
            Check.Argument.IsNotNull(detailRequest, "detailRequest");

            var resultService = GetResultService((SportType)detailRequest.SportId);

            return resultService.GetResultDetails(detailRequest);
        }
    }
}