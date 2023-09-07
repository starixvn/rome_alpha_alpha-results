namespace Alpha.Results.Site.Tests.Criteria
{
    using NUnit.Framework;
    using Site.Criteria;

    [TestFixture]
    public class GetSportsbookResultDetailsCriteriaTests
    {

        [TestCase(-1)]
        [TestCase(0)]
        public void IsValid_InvalidMatchId_ReturnFalse(int matchId)
        {
            // Arrange
            var criteria = new GetSportsbookResultDetailsCriteria
            {
                MatchId = matchId
            };

            // Act
            var isValid = criteria.IsValid();

            // Assert
            Assert.IsFalse(isValid);
        }

        [Test]
        public void IsValid_ValidCriteria_ReturnFalse()
        {
            // Arrange
            var criteria = new GetSportsbookResultDetailsCriteria
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
