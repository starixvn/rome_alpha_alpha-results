namespace Alpha.Results.Site.Tests.DataAccesses
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Data;
    using Fanex.Data;
    using Fanex.Result.Core.Racing.DTO;
    using KellermanSoftware.CompareNetObjects;
    using NSubstitute;
    using NUnit.Framework;
    using Site.Criteria;
    using Site.DataAccesses.Impl;

    [TestFixture]
    public class RacingResultDataAccessTests
    {
        private CompareLogic compareLogic;
        private IObjectDb objectDb;
        private RacingResultDataAccess dataAccess;

        [SetUp]
        public void SetUp()
        {
            compareLogic = new CompareLogic();

            objectDb = Substitute.For<IObjectDb>();
            ObjectDbFactory.CreateInstance = (settingKey) => objectDb;

            dataAccess = new RacingResultDataAccess();
        }

        [Test]
        public void GetParlayResults_CriteriaIsNull_ThrowsArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>(new TestDelegate(() => dataAccess.GetRacingResults(null)));
        }

        [Test]
        public void GetNumberGameResults_EmptyDataReturnFromDb_ReturnsDefaultData()
        {
            // Arrange
            var criteria = new GetRacingResultCriteria();

            var dataTable = new DataTable();
            objectDb.ExecuteReader(Arg.Any<Hashtable>()).Returns(dataTable.CreateDataReader());

            var expectedData = new List<Racing>();

            // Act
            var actualData = dataAccess.GetRacingResults(criteria);

            // Assert
            Assert.IsTrue(compareLogic.Compare(expectedData, actualData).AreEqual);
        }

        [Test]
        public void GetRacingResultDetails_CriteriaIsNull_ThrowsArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>(new TestDelegate(() => dataAccess.GetRacingResultDetails(null)));
        }

        [Test]
        public void GetRacingResultDetails_EmptyDataReturnFromDb_ReturnsDefaultData()
        {
            // Arrange
            var criteria = new GetRacingResultDetailsCriteria();

            var dataTable = new DataTable();
            objectDb.ExecuteReader(Arg.Any<Hashtable>()).Returns(dataTable.CreateDataReader());

            var expectedData = new List<Racing>();

            // Act
            var actualData = dataAccess.GetRacingResultDetails(criteria);

            // Assert
            Assert.IsTrue(compareLogic.Compare(expectedData, actualData).AreEqual);
        }
    }
}
