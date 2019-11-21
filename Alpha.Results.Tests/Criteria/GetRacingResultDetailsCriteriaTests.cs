using Alpha.Results.Site.Criteria;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alpha.Results.Site.Tests.Criteria
{
    [TestFixture]
    public class GetRacingResultDetailsCriteriaTests
    {
        [TestCase(-1, false)]
        [TestCase(0, false)]
        [TestCase(1, true)]
        public void IsValid_Always_ReturnsCorrect(int matchId, bool expected)
        {
            // Arrange
            var criteria = new GetRacingResultDetailsCriteria() { MatchId = matchId };

            // Act
            var act = criteria.IsValid();

            // Assert
            Assert.AreEqual(expected, act);
        }
    }
}
