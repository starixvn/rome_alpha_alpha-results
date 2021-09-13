namespace Alpha.Results.Site.Tests.Criteria
{
    using NUnit.Framework;
    using Site.Criteria;

    [TestFixture]
    public class GetBitcoinResultDetailsCriteriaTests
    {
        [Test]
        public void GetSettingKey_Always_ReturnsCorrectKey()
        {
            // Arrange
            var criteria = new GetBitcoinResultDetailsCriteria();
            var expectedSettingKey = "Acc_BetList_Match3rdResultSel";

            // Act
            var actualSettingKey = criteria.GetSettingKey();

            // Assert
            Assert.AreEqual(expectedSettingKey, actualSettingKey);
        }

        [TestCase(-1)]
        public void IsValid_InvalidMatchId_ReturnFalse(int matchId)
        {
            // Arrange
            var criteria = new GetBitcoinResultDetailsCriteria
            {
                MatchId = matchId
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
            var criteria = new GetBitcoinResultDetailsCriteria
            {
                MatchId = 1
            };

            // Act
            var isValid = criteria.IsValid();

            // Assert
            Assert.IsTrue(isValid);
        }
    }
}
