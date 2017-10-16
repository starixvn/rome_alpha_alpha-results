namespace Alpha.Results.Site.Tests.DataAccesses
{
    using System;
    using NUnit.Framework;
    using Site.DataAccesses.Impl;

    [TestFixture]
    public class SportsbookResultDataAccessTests
    {
        private SportsbookResultDataAccess dataAccess;

        [SetUp]
        public void SetUp()
        {
            dataAccess = new SportsbookResultDataAccess();
        }

        [Test]
        public void GetSportbookResults_CriteriaIsNull_ThrowsArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>(new TestDelegate(() => dataAccess.GetSportbookResults(null)));
        }

        [Test]
        public void GetScoreInformation_CriteriaIsNull_ThrowsArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>(new TestDelegate(() => dataAccess.GetScoreInformation(null)));
        }
    }
}
