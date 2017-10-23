namespace Alpha.Results.Site.Tests.DataAccesses
{
    using System;
    using NUnit.Framework;
    using Site.DataAccesses.Impl;

    [TestFixture]
    public class VirtualRacingResultDataAccessTests
    {
        private VirtualRacingResultDataAccess dataAccess;

        [SetUp]
        public void SetUp()
        {
            dataAccess = new VirtualRacingResultDataAccess();
        }

        [Test]
        public void GetVirtualRacingResults_CriteriaIsNull_ThrowsArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>(new TestDelegate(() => dataAccess.GetVirtualRacingResults(null)));
        }

        [Test]
        public void GetVirtualRacingResultDetails_CriteriaIsNull_ThrowsArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>(new TestDelegate(() => dataAccess.GetVirtualRacingResultDetails(null)));
        }
    }
}
