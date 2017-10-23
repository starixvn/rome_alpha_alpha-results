namespace Alpha.Results.Site.Tests.Criteria
{
    using NUnit.Framework;
    using Site.Criteria;

    [TestFixture]
    public class GetLiveCasinoResultCriteriaTests
    {
        [Test]
        public void GetSettingKey_Always_ReturnsCorrectKey()
        {
            // Arrange
            var criteria = new GetLiveCasinoResultCriteria();
            var expectedSettingKey = "Age_BetList_SelMatchResult";

            // Act
            var actualSettingKey = criteria.GetSettingKey();

            // Assert
            Assert.AreEqual(expectedSettingKey, actualSettingKey);
        }

        [TestCase(-1)]
        [TestCase(0)]
        public void IsValid_InvalidMatchId_ReturnFalse(int matchId)
        {
            // Arrange
            var criteria = new GetLiveCasinoResultCriteria
            {
                MatchId = matchId,
                BetType = 1
            };

            // Act
            var isValid = criteria.IsValid();

            // Assert
            Assert.IsFalse(isValid);
        }

        [TestCase(-1)]
        [TestCase(0)]
        public void IsValid_InvalidBetType_ReturnFalse(int betType)
        {
            // Arrange
            var criteria = new GetLiveCasinoResultCriteria
            {
                MatchId = 1,
                BetType = betType
            };

            // Act
            var isValid = criteria.IsValid();

            // Assert
            Assert.IsFalse(isValid);
        }

        [Test]
        public void IsValid_ValidCriteria_ReturnTrue()
        {
            // Arrange
            var criteria = new GetLiveCasinoResultCriteria
            {
                MatchId = 1,
                BetType = 1
            };

            // Act
            var isValid = criteria.IsValid();

            // Assert
            Assert.IsTrue(isValid);
        }
    }
}
