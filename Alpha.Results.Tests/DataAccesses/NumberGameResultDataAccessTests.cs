using System;
using Alpha.Results.Site.DataAccesses.Impl;
using NUnit.Framework;

namespace Alpha.Results.Site.Tests.DataAccesses
{
    [TestFixture]
    public class NumberGameResultDataAccessTests
    {
        private NumberGameResultDataAccess dataAccess;

        [SetUp]
        public void SetUp()
        {
            dataAccess = new NumberGameResultDataAccess();
        }

        [Test]
        public void GetNumberGameResults_CriteriaIsNull_ThrowsArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>(new TestDelegate(() => dataAccess.GetNumberGameResults(null)));
        }

        [Test]
        public void GetNumberGameResultDetails_CriteriaIsNull_ThrowsArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>(new TestDelegate(() => dataAccess.GetNumberGameResultDetails(null)));
        }
    }
}
