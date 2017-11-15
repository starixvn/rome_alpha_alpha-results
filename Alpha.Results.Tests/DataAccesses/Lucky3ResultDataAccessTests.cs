namespace Alpha.Results.Site.Tests.DataAccesses
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Data;
    using Fanex.Data;
    using Fanex.Result.Core.Lucky3.DTO;
    using KellermanSoftware.CompareNetObjects;
    using NSubstitute;
    using NUnit.Framework;
    using Site.Criteria;
    using Site.DataAccesses.Impl;

    [TestFixture]
    public class Lucky3ResultDataAccessTests
    {
        private CompareLogic compareLogic;
        private IObjectDb objectDb;
        private Lucky3ResultDataAccess dataAccess;

        [SetUp]
        public void SetUp()
        {
            compareLogic = new CompareLogic();

            objectDb = Substitute.For<IObjectDb>();
            ObjectDbFactory.CreateInstance = (settingKey) => objectDb;

            dataAccess = new Lucky3ResultDataAccess();
        }

        [Test]
        public void GetResults_CriteriaIsNull_ThrowsArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>(new TestDelegate(() => dataAccess.GetResults(null)));
        }

        [Test]
        public void GetResults_EmptyDataReturnFromDb_ReturnsDefaultData()
        {
            // Arrange
            var criteria = new GetNumberGameResultCriteria();

            var dataTable = new DataTable();
            objectDb.ExecuteReader(Arg.Any<Hashtable>()).Returns(dataTable.CreateDataReader());

            var expectedData = new List<Lucky3>();

            // Act
            var actualData = dataAccess.GetResults(criteria);

            // Assert
            Assert.IsTrue(compareLogic.Compare(expectedData, actualData).AreEqual);
        }

        [Test]
        public void GetResultDetails_CriteriaIsNull_ThrowsArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>(new TestDelegate(() => dataAccess.GetResultDetails(null)));
        }

        [Test]
        public void GetResultDetails_EmptyDataReturnFromDb_ReturnsDefaultData()
        {
            // Arrange
            var criteria = new GetNumberGameResultDetailsCriteria();

            var dataTable = new DataTable();
            objectDb.ExecuteReader(Arg.Any<Hashtable>()).Returns(dataTable.CreateDataReader());

            var expectedData = new List<Lucky3>();

            // Act
            var actualData = dataAccess.GetResultDetails(criteria);

            // Assert
            Assert.IsTrue(compareLogic.Compare(expectedData, actualData).AreEqual);
        }
    }
}
