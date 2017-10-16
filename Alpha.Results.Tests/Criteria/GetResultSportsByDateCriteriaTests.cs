namespace Alpha.Results.Site.Tests.Criteria
{
    using System;
    using NUnit.Framework;
    using Site.Criteria;

    [TestFixture]
    public class GetResultSportsByDateCriteriaTests
    {
        [Test]
        public void GetSettingKey_Always_ReturnsCorrectKey()
        {
            // Arrange
            var criteria = new GetResultSportsByDateCriteria(DateTime.Now);
            var expectedSettingKey = "Age_Result_SportSelByDate";

            // Act
            var actualSettingKey = criteria.GetSettingKey();

            // Assert
            Assert.AreEqual(expectedSettingKey, actualSettingKey);
        }
    }
}
