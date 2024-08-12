namespace Alpha.Results.Site.DataAccesses.Impl
{
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Linq;
    using Alpha.Results.Site.Models.Entities;
    using Criteria;
    using DataAccesses;
    using Fanex.Data.Repository;
    using Fanex.Result.Core.Sportsbook.DTO;

    public class ParlayResultDataAccess : IParlayResultDataAccess
    {
        private readonly IDynamicRepository _repository;

        public ParlayResultDataAccess(IDynamicRepository repository = null)
        {
            _repository = repository ?? new DynamicRepository();
        }

        public IList<Parlay> GetParlay3rdResults(GetParlay3rdResultCriteria criteria)
        {
            if (criteria == null)
            {
                throw new ArgumentNullException(nameof(criteria), "Criteria cannot be null");
            }

            var sportsbooks = _repository.Fetch<SportsbookEntity>(criteria);
            

            var results = GetParlays(sportsbooks);            

            return results;
        }

        public IList<Parlay> GetParlayResults(GetParlayResultCriteria criteria)
        {
            if (criteria == null)
            {
                throw new ArgumentNullException(nameof(criteria), "Criteria cannot be null");
            }

            var rawdata = _repository.FetchMultiple<SportsbookEntity, GameDetail>(criteria);
            var sportsbooks = rawdata.Item1;
            var gameDetails = rawdata.Item2;

            var results = GetParlays(sportsbooks);
            AddGameDetailsToResults(gameDetails, results);

            return results;
        }

        private static List<Parlay> GetParlays(IEnumerable<SportsbookEntity> sportsbookList)
        {
            var results = new List<Parlay>();
            var leagueId = 0;
            var leagueGroupId = 0;
            var sportId = 0;
            var sportbooks = new List<Sportsbook>();

            foreach (var entity in sportsbookList)
            {
                var newLeagueId = entity.LeagueId;
                var newsportId = entity.SportType;
                var newLeagueGroupId = entity.LeagueGroupId;

                if (leagueId != newLeagueId && leagueId > 0)
                {
                    results.Add(new Parlay
                    {
                        SportId = sportId,
                        LeagueId = leagueId,
                        Sportbook = sportbooks,
                        LeagueGroupId = leagueGroupId
                    });
                    sportbooks = new List<Sportsbook>();
                }

                sportbooks.Add(BindSportbook(entity));

                leagueId = newLeagueId;
                sportId = newsportId;
                leagueGroupId = newLeagueGroupId;
            }

            results.Add(new Parlay
            {
                SportId = sportId,
                LeagueId = leagueId,
                LeagueGroupId = leagueGroupId,
                Sportbook = sportbooks
            });

            return results;
        }

        private static Sportsbook BindSportbook(SportsbookEntity entity)
        {
            return new Sportsbook
            {
                AwayId = entity.AwayId,
                HomeId = entity.HomeId,
                BetStatus = entity.BetStatus ?? string.Empty,
                LeagueId = entity.LeagueId,
                MatchId = entity.MatchId,
                LeagueGroupId = entity.LeagueGroupId,
                EventStatus = entity.EventStatus ?? string.Empty,
                FinalAwayScore = entity.FinalAwayScore,
                HtAwayScore = entity.HtAwayScore,
                Color = entity.Lcolor ?? string.Empty,
                FinalHomeScore = entity.FinalHomeScore,
                HtHomeScore = entity.HtHomeScore,
                EventDate = entity.EventDate,
                IsNeutral = entity.IsNeutral,
                KickOffTime = entity.KickOffTime,
                MatchCode = entity.MatchCode ?? string.Empty,
                GoalRecord = entity.GoalRecord ?? string.Empty,
                IsHTCal = entity.IsHTCal,
                Calculate = entity.Calculate,
                SettlementStatus = entity.SettlementStatus,
                NoHTScore = entity.NoHTScore,
                RefNo = string.Empty,
                GameDetails = new List<GameDetail>(),
                Bettype = entity.Bettype,
                BetID = entity.BetCheck,
                LiveHomeScore = entity.LiveHomeScore,
                LiveAwayScore = entity.LiveAwayScore,
                MainType = entity.MainType,
                SubType = entity.SubType,
                SessionTime = entity.SessionTime
            };
        }

        private static void AddGameDetailsToResults(IEnumerable<GameDetail> gameDetails, List<Parlay> results)
        {
            if (gameDetails.Any())
            {
                foreach (var result in results)
                {
                    foreach (var sb in result.Sportbook)
                    {
                        sb.GameDetails.AddRange(gameDetails.Where(i => i.MatchId == sb.MatchId));
                    }
                }
            }
        }
    }
}
