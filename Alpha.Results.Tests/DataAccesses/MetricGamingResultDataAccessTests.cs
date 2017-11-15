namespace Alpha.Results.Site.Tests.DataAccesses
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Data;
    using Fanex.Data;
    using Fanex.Result.Core.MetricGaming.DTO;
    using KellermanSoftware.CompareNetObjects;
    using NSubstitute;
    using NUnit.Framework;
    using Site.Criteria;
    using Site.DataAccesses.Impl;

    [TestFixture]
    public class MetricGamingResultDataAccessTests
    {
        private CompareLogic compareLogic;
        private IObjectDb objectDb;
        private MetricGamingResultDataAccess dataAccess;

        [SetUp]
        public void SetUp()
        {
            compareLogic = new CompareLogic();

            objectDb = Substitute.For<IObjectDb>();
            ObjectDbFactory.CreateInstance = (settingKey) => objectDb;

            dataAccess = new MetricGamingResultDataAccess();
        }

        [Test]
        public void GetResults_CriteriaIsNull_ThrowsArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>(new TestDelegate(() => dataAccess.GetResults(null)));
        }

        [Test]
        public void GetResult_EmptyDataReturnFromDb_ReturnsDefaultValue()
        {
            // Arrange
            var criteria = new GetMetricGamingResultCriteria();

            var dataTable = new DataTable();
            objectDb.ExecuteReader(Arg.Any<Hashtable>()).Returns(dataTable.CreateDataReader());

            var expectedData = new List<MetricGaming>();

            // Act
            var actualData = dataAccess.GetResults(criteria);

            // Assert
            Assert.IsTrue(compareLogic.Compare(expectedData, actualData).AreEqual);
        }
    }
}
