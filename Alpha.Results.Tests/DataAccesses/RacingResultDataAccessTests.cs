namespace Alpha.Results.Site.Tests.DataAccesses
{
    using System;
    using NUnit.Framework;
    using Site.DataAccesses.Impl;

    [TestFixture]
    public class RacingResultDataAccessTests
    {
        private RacingResultDataAccess dataAccess;

        [SetUp]
        public void SetUp()
        {
            dataAccess = new RacingResultDataAccess();
        }

        [Test]
        public void GetParlayResults_CriteriaIsNull_ThrowsArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>(new TestDelegate(() => dataAccess.GetRacingResults(null)));
        }

        [Test]
        public void GetRacingResultDetails_CriteriaIsNull_ThrowsArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>(new TestDelegate(() => dataAccess.GetRacingResultDetails(null)));
        }
    }
}
