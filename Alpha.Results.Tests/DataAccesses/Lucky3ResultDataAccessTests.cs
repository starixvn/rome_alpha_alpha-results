namespace Alpha.Results.Site.Tests.DataAccesses
{
    using System;
    using NUnit.Framework;
    using Site.DataAccesses.Impl;

    [TestFixture]
    public class Lucky3ResultDataAccessTests
    {
        private Lucky3ResultDataAccess dataAccess;

        [SetUp]
        public void SetUp()
        {
            dataAccess = new Lucky3ResultDataAccess();
        }

        [Test]
        public void GetResults_CriteriaIsNull_ThrowsArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>(new TestDelegate(() => dataAccess.GetResults(null)));
        }

        [Test]
        public void GetResultDetails_CriteriaIsNull_ThrowsArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>(new TestDelegate(() => dataAccess.GetResultDetails(null)));
        }
    }
}
