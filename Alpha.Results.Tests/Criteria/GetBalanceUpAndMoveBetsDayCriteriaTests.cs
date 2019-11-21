namespace Alpha.Results.Site.Tests.Criteria
{
    using NUnit.Framework;
    using Site.Criteria;

    [TestFixture]
    public class GetBalanceUpAndMoveBetsDayCriteriaTests
    {
        [Test]
        public void GetSettingKey_Always_ReturnsCorrectKey()
        {
            // Arrange
            var criteria = new GetBalanceUpAndMoveBetsDayCriteria();
            var expectedSettingKey = "Age_SelBalanceUpDay";

            // Act
            var actualSettingKey = criteria.GetSettingKey();

            // Assert
            Assert.AreEqual(expectedSettingKey, actualSettingKey);
        }

        [Test]
        public void IsValid_Always_ReturnsTrue()
        {
            // Arrange
            var criteria = new GetBalanceUpAndMoveBetsDayCriteria();
            var expected = true;

            // Act
            var actual = criteria.IsValid();

            // Assert
            Assert.AreEqual(expected, actual);
        }
    }
}
