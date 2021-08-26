namespace Alpha.Results.Site.Tests.Criteria
{
    using System;
    using NUnit.Framework;
    using Site.Constants;
    using Site.Criteria;

    [TestFixture]
    public class GetBitcoinResultCriteriaTests
    {
        [Test]
        public void GetSettingKey_Always_ReturnsCorrectKey()
        {
            // Arrange
            var criteria = new GetBitcoinResultCriteria();
            var expectedSettingKey = "Age_Result_Match3rdSelByLeague";

            // Act
            var actualSettingKey = criteria.GetSettingKey();

            // Assert
            Assert.AreEqual(expectedSettingKey, actualSettingKey);
        }

        [Test]
        public void IsValid_InvalidFromDate_ReturnFalse()
        {
            // Arrange
            var criteria = new GetBitcoinResultCriteria
            {
                FromDate = DateTime.MinValue,
                LeagueId = 1,
                MoveBetsDay = DateTime.Now
            };

            // Act
            var isValid = criteria.IsValid();

            // Assert
            Assert.IsFalse(isValid);
        }

        [TestCase(-1)]
        public void IsValid_InvalidLeagueId_ReturnFalse(int leagueId)
        {
            // Arrange
            var criteria = new GetBitcoinResultCriteria
            {
                FromDate = DateTime.Now,
                LeagueId = leagueId,
                MoveBetsDay = DateTime.Now
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
            var criteria = new GetBitcoinResultCriteria
            {
                FromDate = DateTime.Now,
                LeagueId = 1,
                MoveBetsDay = DateTime.Now
            };

            // Act
            var isValid = criteria.IsValid();

            // Assert
            Assert.IsTrue(isValid);
        }
    }
}
