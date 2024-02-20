namespace Alpha.Results.Site.DataAccesses.Impl
{
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Linq;
    using Criteria;
    using DataAccesses;
    using Fanex.Data.Repository;
    using Fanex.Result.Core.Racing.DTO;

    public class VirtualRacingResultDataAccess : IVirtualRacingResultDataAccess
    {
        private readonly IDynamicRepository _repository;

        public VirtualRacingResultDataAccess(IDynamicRepository repository = null)
        {
            _repository = repository ?? new DynamicRepository();
        }

        public IList<Racing> GetVirtualRacingResults(GetVirtualRacingResultCriteria criteria)
            => BuildVirtualRacingResults(criteria);

        public IList<Racing> GetVirtualRacingResultDetails(GetRacingResultDetailsCriteria criteria)
            => BuildVirtualRacingResults(criteria);

        private IList<Racing> BuildVirtualRacingResults(ICriteria criteria)
        {
            if (criteria == null)
            {
                throw new ArgumentNullException(nameof(criteria), "Criteria cannot be null");
            }

            return _repository.Fetch<Racing>(criteria).Select(item =>
            {
                item.SCROfMatch = GetSRCValue(item.SCROfMatch);
                return item;
            }).ToList();
        }

        private static string GetSRCValue(string src)
        {
            if (!string.IsNullOrWhiteSpace(src)
                && src.EndsWith(",", StringComparison.Ordinal))
            {
                return src.Remove(src.Length - 1);
            }

            return src;
        }
    }
}
