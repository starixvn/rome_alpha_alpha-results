namespace Alpha.Results.Site.DataAccesses.Impl
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Alpha.Results.Site.Models.Entities;
    using Criteria;
    using DataAccesses;
    using Fanex.Data.Repository;
    using Fanex.Result.Core.NumberGame.DTO;

    public class NumberGameResultDataAccess : INumberGameResultDataAccess
    {
        private readonly IDynamicRepository _repository;

        public NumberGameResultDataAccess(IDynamicRepository repository = null)
        {
            _repository = repository ?? new DynamicRepository();
        }

        public IList<NumberGame> GetNumberGameResults(GetNumberGameResultCriteria criteria)
            => BuildNumberGameResults(criteria);

        public IList<NumberGame> GetNumberGameResultDetails(GetNumberGameResultDetailsCriteria criteria)
            => BuildNumberGameResults(criteria);

        private IList<NumberGame> BuildNumberGameResults(ICriteria criteria)
        {
            if (criteria == null)
            {
                throw new ArgumentNullException(nameof(criteria), "Criteria cannot be null");
            }

            var results = new List<NumberGame>();
            _repository
                .Fetch<NumberGameEntity>(criteria)
                .ToList()
                .ForEach(entity => BindNumberGame(results, entity));

            return results;
        }

        private static void BindNumberGame(List<NumberGame> results, NumberGameEntity entity)
        {
            var existMatch = results.SingleOrDefault(i => i.MatchId == entity.MatchId);
            if (existMatch != null)
            {
                existMatch.Seg.Add(entity.Seg);
                existMatch.Ball.Add(entity.Number);
            }
            else
            {
                results.Add(new NumberGame
                {
                    LeagueId = entity.LeagueId,
                    MatchId = entity.MatchId,
                    EventStatus = entity.EventStatus,
                    EventDate = entity.EventDate,
                    KickOffTime = entity.KickOffTime,
                    MatchCode = entity.MatchCode,
                    Seg = new List<int> { entity.Seg },
                    Ball = new List<int> { entity.Number }
                });
            }
        }
    }
}
