namespace Alpha.Results.Site.Tests.Criteria
{
    using NUnit.Framework;
    using Site.Criteria;

    [TestFixture]
    public class GetGoldDeluxeResultCriteriaTests
    {
        [Test]
        public void GetSettingKey_Always_ReturnsCorrectKey()
        {
            // Arrange
            var criteria = new GetGoldDeluxeResultCriteria();
            var expectedSettingKey = "All_BetList_MatchResultGDSel";

            // Act
            var actualSettingKey = criteria.GetSettingKey();

            // Assert
            Assert.AreEqual(expectedSettingKey, actualSettingKey);
        }

        [TestCase(0, false)]
        [TestCase(-1, false)]
        [TestCase(1, true)]
        public void IsValid_Always_ReturnsCorrect(int transId, bool expected)
        {
            // Arrange
            var criteria = new GetGoldDeluxeResultCriteria() { TransId = transId };

            // Act
            var actual = criteria.IsValid();

            // Assert
            Assert.AreEqual(expected, actual);
        }
    }
}
