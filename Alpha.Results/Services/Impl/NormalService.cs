namespace Alpha.Results.Services.Impl
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Criteria;
    using Fanex.Caching;
    using Fanex.Common.Helper;
    using Fanex.Data.Repository;
    using Models;
    using Models.Dtos;
    using Result;
    using Sunplus.Agent.Model.BL.Definitions;

    public class NormalService : INormalService
    {
        private const string BalanceUpDateCacheKey = "Alpha.Results.Services.Impl.ResultService";

        private Dictionary<int, Func<NormalRequest, string>> _resultHandlers = new Dictionary<int, Func<NormalRequest, string>>();

        private IDynamicRepository _dynamicRepository;
        private ICache _cacheManager;

        public NormalService() : this(null, null)
        {
        }

        public NormalService(IDynamicRepository dynamicRepository, ICache cacheManager)
        {
            _dynamicRepository = dynamicRepository ?? new DynamicRepository();
            _cacheManager = cacheManager ?? CacheService.CreateInstance(CacheType.MemoryCache);
        }

        public BalanceUpDateDto GetBalanceUpDate()
        {
            var balanceUpDateDtoCached = _cacheManager.Get<BalanceUpDateDto>(BalanceUpDateCacheKey);

            if (balanceUpDateDtoCached == null)
            {
                balanceUpDateDtoCached = _dynamicRepository.Get<BalanceUpDateDto>(new GetBalanceUpDateCriteria());

                _cacheManager.Set<BalanceUpDateDto>(BalanceUpDateCacheKey, balanceUpDateDtoCached);
            }

            return balanceUpDateDtoCached;
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

        public string GetHtmlResults(NormalRequest request)
        {
            Check.Argument.IsNotNull(request, "request");
            Check.Argument.IsNotNull(request.ResultDate, "request.ResultDate");
            Check.Argument.IsNotNegativeOrZero(request.SportId, "request.SportId");

            CreateResultHandlers();

            var resultHandler = _resultHandlers.Keys.Contains(request.SportId) 
                ? _resultHandlers[request.SportId] 
                : _resultHandlers[(int)SportType.None];

            return resultHandler(request);
        }

        private void CreateResultHandlers()
        {
            _resultHandlers.Add((int)SportType.Soccer, this.RenderSportsbookResults);
            _resultHandlers.Add((int)SportType.BasketBall, this.RenderSportsbookResults);
            _resultHandlers.Add((int)SportType.Netball, this.RenderSportsbookResults);
            _resultHandlers.Add((int)SportType.FootBall, this.RenderSportsbookResults);
            _resultHandlers.Add((int)SportType.Rugby, this.RenderSportsbookResults);
            _resultHandlers.Add((int)SportType.IceHockey, this.RenderSportsbookResults);
            _resultHandlers.Add((int)SportType.FieldHockey, this.RenderSportsbookResults);
            _resultHandlers.Add((int)SportType.Tennis, this.RenderSportsbookResults);
            _resultHandlers.Add((int)SportType.VolleyBall, this.RenderSportsbookResults);
            _resultHandlers.Add((int)SportType.Badminton, this.RenderSportsbookResults);
            _resultHandlers.Add((int)SportType.Squash, this.RenderSportsbookResults);
            _resultHandlers.Add((int)SportType.BaseBall, this.RenderSportsbookResults);
            _resultHandlers.Add((int)SportType.Golf, this.RenderSportsbookResults);
            _resultHandlers.Add((int)SportType.Motorsports, this.RenderSportsbookResults);
            _resultHandlers.Add((int)SportType.HRFixedOdds, this.RenderSportsbookResults);
            _resultHandlers.Add((int)SportType.Billard, this.RenderSportsbookResults);
            _resultHandlers.Add((int)SportType.Cycling, this.RenderSportsbookResults);
            _resultHandlers.Add((int)SportType.Fencing, this.RenderSportsbookResults);
            _resultHandlers.Add((int)SportType.Judo, this.RenderSportsbookResults);
            _resultHandlers.Add((int)SportType.ModernPentathlon, this.RenderSportsbookResults);
            _resultHandlers.Add((int)SportType.Rowing, this.RenderSportsbookResults);
            _resultHandlers.Add((int)SportType.Sailing, this.RenderSportsbookResults);
            _resultHandlers.Add((int)SportType.Shooting, this.RenderSportsbookResults);
            _resultHandlers.Add((int)SportType.Taekwondo, this.RenderSportsbookResults);
            _resultHandlers.Add((int)SportType.Triathlon, this.RenderSportsbookResults);
            _resultHandlers.Add((int)SportType.Wrestling, this.RenderSportsbookResults);
            _resultHandlers.Add((int)SportType.Winter, this.RenderSportsbookResults);
            _resultHandlers.Add((int)SportType.ESports, this.RenderSportsbookResults);
            _resultHandlers.Add((int)SportType.HorseRacing, this.RenderRacingResults);
            _resultHandlers.Add((int)SportType.Greyhound, this.RenderRacingResults);
            _resultHandlers.Add((int)SportType.Harness, this.RenderRacingResults);
            _resultHandlers.Add((int)SportType.NumberGame, this.RenderNumberGameResults);
            //_resultHandlers.Add((int)SportType.LiveCasino, this.RenderLiveCasinoResults); Details
            _resultHandlers.Add((int)SportType.VirtualHorsesRacing, this.RenderVirtualRacingResults);
            _resultHandlers.Add((int)SportType.VirtualGreyhounds, this.RenderVirtualRacingResults);
            _resultHandlers.Add((int)SportType.VirtualMotors, this.RenderVirtualRacingResults);
            _resultHandlers.Add((int)SportType.VirtualSports, this.RenderSportsbookResults);
            _resultHandlers.Add((int)SportType.VirtualTennis, this.RenderSportsbookResults);
            _resultHandlers.Add((int)SportType.VirtualCycling, this.RenderVirtualRacingResults);
            _resultHandlers.Add((int)SportType.VirtualSpeedway, this.RenderVirtualRacingResults);
            //_resultHandlers.Add((int)SportType.GoldDeluxe, this.RenderGoldDeluxe); Details
            _resultHandlers.Add((int)SportType.None, this.RenderSportsbookResults);
        }

        private string RenderSportsbookResults(NormalRequest request)
        {
            //string result = resultRequest.MatchId > 0 ?
            //    new SportsbookPopupResultService().GetResult(resultRequest) :
            //    new SportsbookResultService().GetResult(resultRequest.FromDate.Value, resultRequest.SportId, resultRequest.LeagueId);
            return new SportsbookResultService().GetResult(request.ResultDate, request.SportId, request.LeagueId);
        }


        ////private void RenderLiveCasino(ResultRequest resultRequest)
        ////{
        ////    string result = new LiveCasinoPopupResultService().GetResult(resultRequest.MatchId, resultRequest.BetType, resultRequest.LeagueId.ToString());
        ////    ViewBag.Result = result;
        ////}

        ////string result = IsViewMatchResultPopup(resultRequest.MatchId) ?
        ////    new GoldDeluxePopupResultService().GetPopupResult(resultRequest.RefNum, resultRequest.BetType) :
        ////    null;

        private string RenderRacingResults(NormalRequest request)
        {
            //string result = resultRequest.MatchId > 0 ?
            //    new RacingPopupResultService().GetResult(resultRequest.MatchId, this.GetRaceNumber(resultRequest.Race), resultRequest.SportId) :
            //    new RacingResultService().GetResult(resultRequest.FromDate.Value, resultRequest.SportId, resultRequest.LeagueId);
            return new RacingResultService().GetResult(request.ResultDate, request.SportId, request.LeagueId);
        }

        private string RenderNumberGameResults(NormalRequest request)
        {
            //string result = resultRequest.MatchId > 0 ?
            //   new NumberGamePopupResultService().GetResult(resultRequest.MatchId) :
            //   new NumberGameResultService().GetResult(resultRequest.FromDate.Value, resultRequest.LeagueId, resultRequest.SportId);
            return new NumberGameResultService().GetResult(request.ResultDate, request.SportId, request.LeagueId);
        }

        private string RenderVirtualRacingResults(NormalRequest request)
        {
            //string result = resultRequest.MatchId > 0 ?
            //    new RacingPopupResultService().GetResultForVirtualRacing(resultRequest.MatchId, this.GetRaceNumber(resultRequest.Race), resultRequest.SportId) :
               return new VirtualRacingResultService().GetResult(request.ResultDate, request.SportId, request.LeagueId);
        }

        public byte[] GetExcelResults(NormalRequest request, string templatePath)
        {
            throw new NotImplementedException();
        }

        public string GetHtmlResultDetails(NormalDetailRequest detailRequest)
        {
            throw new NotImplementedException();
        }
    }
}