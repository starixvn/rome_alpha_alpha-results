namespace Alpha.Results.Site.Tests.DataAccesses
{
    using System;
    using NUnit.Framework;
    using Site.DataAccesses.Impl;

    [TestFixture]
    public class MetricGamingResultDataAccessTests
    {
        private MetricGamingResultDataAccess dataAccess;

        [SetUp]
        public void SetUp()
        {
            dataAccess = new MetricGamingResultDataAccess();
        }

        [Test]
        public void GetResults_CriteriaIsNull_ThrowsArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>(new TestDelegate(() => dataAccess.GetResults(null)));
        }
    }
}
