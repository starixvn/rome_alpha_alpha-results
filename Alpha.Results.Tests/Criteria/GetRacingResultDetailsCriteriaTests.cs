namespace Alpha.Results.Site.Tests.Criteria
{
    using NUnit.Framework;
    using Site.Criteria;

    [TestFixture]
    public class GetRacingResultDetailsCriteriaTests
    {
        [Test]
        public void GetSettingKey_Always_ReturnsCorrectKey()
        {
            // Arrange
            var criteria = new GetRacingResultDetailsCriteria();
            var expectedSettingKey = "Age_BetList_SelMatchResult2";

            // Act
            var actualSettingKey = criteria.GetSettingKey();

            // Assert
            Assert.AreEqual(expectedSettingKey, actualSettingKey);
        }
    }
}
