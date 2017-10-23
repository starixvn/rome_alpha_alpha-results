namespace Alpha.Results.Site.Tests.Criteria
{
    using System;
    using NUnit.Framework;
    using Site.Criteria;

    [TestFixture]
    public class GetRacingResultCriteriaTests
    {
        [Test]
        public void GetSettingKey_Always_ReturnsCorrectKey()
        {
            // Arrange
            var criteria = new GetRacingResultCriteria();
            var expectedSettingKey = "Age_Result_RBRaceSelByMeeting";

            // Act
            var actualSettingKey = criteria.GetSettingKey();

            // Assert
            Assert.AreEqual(expectedSettingKey, actualSettingKey);
        }

        [Test]
        public void IsValid_InvalidFromDate_ReturnFalse()
        {
            // Arrange
            var criteria = new GetRacingResultCriteria
            {
                FromDate = DateTime.MinValue,
                SportType = 1
            };

            // Act
            var isValid = criteria.IsValid();

            // Assert
            Assert.IsFalse(isValid);
        }

        [TestCase(-1)]
        [TestCase(0)]
        public void IsValid_InvalidSportType_ReturnFalse(int sportType)
        {
            // Arrange
            var criteria = new GetRacingResultCriteria
            {
                FromDate = DateTime.Now,
                SportType = sportType
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
            var criteria = new GetRacingResultCriteria
            {
                FromDate = DateTime.Now,
                SportType = 1
            };

            // Act
            var isValid = criteria.IsValid();

            // Assert
            Assert.IsTrue(isValid);
        }
    }
}
