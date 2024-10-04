namespace Alpha.Results.Site.DataAccesses.Impl
{
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Linq;
    using DataAccesses;
    using Fanex.Data.Repository;
    using Fanex.Result.Core.VirtualRacing.DTO;

    public class VirtualRacingResultDataAccess : IVirtualRacingResultDataAccess
    {
        private readonly IDynamicRepository _repository;

        public VirtualRacingResultDataAccess(IDynamicRepository repository = null)
        {
            _repository = repository ?? new DynamicRepository();
        }

        public IList<VirtualRacing> GetVirtualRacingResultDetails(ICriteria criteria)
        {
            if (criteria == null)
            {
                throw new ArgumentNullException(nameof(criteria), "Criteria cannot be null");
            }

            var rawdata = _repository.FetchMultiple<VirtualRacing, VirtualRacingDetail>(criteria);
            var results = rawdata.Item1;
            var gameDetails = rawdata.Item2;

            AddGameDetailsToResults(gameDetails, results);

            return results.ToList();
        }

        private static void AddGameDetailsToResults(IEnumerable<VirtualRacingDetail> gameDetails, IEnumerable<VirtualRacing> results)
        {
            if (gameDetails.Any())
            {
                foreach (var result in results)
                {
                    result.Details.AddRange(gameDetails.Where(i => i.EventId == result.EventId));
                }
            }
        }
    }
}
