using Alpha.Results.Site.Criteria;
using NUnit.Framework;

namespace Alpha.Results.Site.Tests.Criteria
{
    [TestFixture]
    public class GetBetBuilderResultDetailsCriteriaTests
    {
        [Test]
        public void GetSettingKey_Always_ReturnsCorrect()
        {
            // Arrange
            var criteria = new GetBetBuidlerResultDetailsCriteria();
            var expected = "Age_TicketResult_BetBuilder";

            // Act
            var act = criteria.GetSettingKey();

            // Assert
            Assert.AreEqual(expected, act);
        }

        [TestCase(0, 0, false)]
        [TestCase(0, 1, false)]
        [TestCase(1, 0, false)]
        [TestCase(-1, 0, false)]
        [TestCase(0, -1, false)]
        [TestCase(1, 1, true)]
        public void IsValid_Always_CheckValidation(int matchId, int marketId, bool expected)
        {
            // Arrange
            var criteria = new GetBetBuidlerResultDetailsCriteria() { MatchId = matchId, MarketId = marketId };

            // Act
            var act = criteria.IsValid();

            // Assert
            Assert.AreEqual(expected, act);
        }
    }
}
