namespace Alpha.Results.Site.DataAccesses.Impl
{
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Linq;
    using Alpha.Results.Site.Models.Entities;
    using Alpha.Results.Site.Models.Requests;
    using Criteria;
    using DataAccesses;
    using Fanex.Data.Repository;
    using Fanex.Result.Core.Sportsbook.DTO;

    public class SportsbookResultDataAccess : ISportsbookResultDataAccess
    {
        private readonly IDynamicRepository _repository;

        public SportsbookResultDataAccess(IDynamicRepository repository = null)
        {
            _repository = repository ?? new DynamicRepository();
        }

        public Sportsbook GetBetBuilderInformation(GetBetBuidlerResultDetailsCriteria criteria)
        {
            var rawdata = _repository.FetchMultiple<SportsbookEntity, BetBuilderDetail>(criteria);
            var sportsbook = rawdata.Item1.Select(sb => BindSportbook(sb)).FirstOrDefault();

            if (sportsbook != null)
            {
                sportsbook.BetBuilderDetails = rawdata.Item2.ToList();
            }

            return sportsbook;
        }

        public IList<Sportsbook> GetSportbookResults(GetSportsbookResultCriteria criteria)
        {
            if (criteria == null)
            {
                throw new ArgumentNullException(nameof(criteria), "Criteria cannot be null");
            }

            var results = new List<Sportsbook>();
            var rawdata = _repository.FetchMultiple<SportsbookEntity, GameDetail>(criteria);
            var sportsbooks = rawdata.Item1;
            var gameDetails = rawdata.Item2;

            rawdata.Item1.Select(sb => BindSportbook(sb)).ToList().ForEach(sb =>
            {
                sb.GameDetails = gameDetails.Where(i => i.MatchId == sb.MatchId).ToList();
                results.Add(sb);
            });

            return results;
        }

        private static Sportsbook BindSportbook(SportsbookEntity entity)
        {
            return new Sportsbook
            {
                HomeId = entity.HomeId,
                AwayId = entity.AwayId,
                BetStatus = entity.BetStatus ?? string.Empty,
                LeagueId = entity.LeagueId,
                MatchId = entity.MatchId,
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
                RefNo = string.Empty,
                GameDetails = new List<GameDetail>(),
                Bettype = entity.Bettype,
                BetID = entity.BetCheck,
                SettlementStatus = entity.SettlementStatus,
                NoHTScore = entity.NoHTScore
            };
        }

        public List<Sportsbook> GetScoreInformation(NormalResultDetailsQuery request)
        {
            if (request == null)
            {
                throw new ArgumentNullException(nameof(request), "Request cannot be null");
            }

            var criteria = request.IsViewResultFromBetList ? new GetSportsbookResultBetListCriteria
            {
                MatchId = request.MatchId,
                BetType = request.BetTypeId,
                SportType = request.SportId,
                BetId = request.BetId,
                Handicap2 = request.Hdp2,
                Transdesc = request.TransDesc
            } :
            new GetSportsbookResultDetailsCriteria
            {
                MatchId = request.MatchId
            };

            var results = new List<Sportsbook>();
            var rawdata = _repository.FetchMultiple<SportsbookEntity, GameDetail>(criteria);
            var result = rawdata.Item1.Select(sb => BindSportsbookDetails(sb, request)).FirstOrDefault();

            if (result != null)
            {
                var gameDetails = rawdata.Item2;
                result.GameDetails.AddRange(gameDetails.Select(gd =>
                {
                    gd.MatchId = request.MatchId;
                    return gd;
                }));

                results.Add(result);
            }

            return results;
        }

        private static Sportsbook BindSportsbookDetails(SportsbookEntity entity, NormalResultDetailsQuery request)
        {
            request.SportId = entity.SportType;

            return new Sportsbook
            {
                HomeId = entity.HomeId,
                AwayId = entity.AwayId,
                HtHomeScore = entity.HtHomeScore,
                FinalHomeScore = entity.FinalHomeScore,
                HtAwayScore = entity.HtAwayScore,
                FinalAwayScore = entity.FinalAwayScore,
                EventStatus = entity.EventStatus ?? string.Empty,
                KickOffTime = entity.KickOffTime,
                EventDate = entity.EventDate,
                IsNeutral = entity.IsNeutral,
                BetStatus = entity.BetStatus ?? string.Empty,
                LeagueId = entity.LeagueId,
                LeagueGroupId = ColumnExisted(reader, "leaguegroupid") ? int.Parse(reader["leaguegroupid"].ToString()) : 0,
                MatchId = request.MatchId,
                Color = string.Empty,
                MatchCode = entity.MatchCode ?? string.Empty,
                GoalRecord = entity.GoalRecord ?? string.Empty,
                IsHTCal = entity.IsHTCal,
                Calculate = entity.Calculate,
                RefNo = string.Empty,
                BetID = request.BetId.ToString(),
                Bettype = request.BetTypeId,
                GameDetails = new List<GameDetail>(),
                Handicap2 = request.Hdp2,
                SettlementStatus = entity.SettlementStatus,
                NoHTScore = entity.NoHTScore,
                LiveHomeScore = entity.LiveHomeScore,
                LiveAwayScore = entity.LiveAwayScore
            };
        }
    }
}