namespace Alpha.Results.Site.Tests.DataAccesses
{
    using System;
    using NUnit.Framework;
    using Site.DataAccesses.Impl;

    [TestFixture]
    public class ParlayResultDataAccessTests
    {
        private ParlayResultDataAccess dataAccess;

        [SetUp]
        public void SetUp()
        {
            dataAccess = new ParlayResultDataAccess();
        }

        [Test]
        public void GetParlayResults_CriteriaIsNull_ThrowsArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>(new TestDelegate(() => dataAccess.GetParlayResults(null)));
        }
    }
}
