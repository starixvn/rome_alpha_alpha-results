namespace Alpha.Results.Site.Tests.DataAccesses
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Data;
    using Fanex.Data;
    using Fanex.Result.Core.Sportsbook.DTO;
    using KellermanSoftware.CompareNetObjects;
    using NSubstitute;
    using NUnit.Framework;
    using Site.Criteria;
    using Site.DataAccesses.Impl;

    [TestFixture]
    public class SportsbookResultDataAccessTests
    {
        private CompareLogic compareLogic;
        private IObjectDb objectDb;
        private SportsbookResultDataAccess dataAccess;

        [SetUp]
        public void SetUp()
        {
            compareLogic = new CompareLogic();

            objectDb = Substitute.For<IObjectDb>();
            ObjectDbFactory.CreateInstance = (settingKey) => objectDb;

            dataAccess = new SportsbookResultDataAccess();
        }

        [Test]
        public void GetSportbookResults_CriteriaIsNull_ThrowsArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>(new TestDelegate(() => dataAccess.GetSportbookResults(null)));
        }

        [Test]
        public void GetSportbookResults_EmptyDataReturnFromDb_ReturnsDefaultData()
        {
            // Arrange
            var criteria = new GetSportsbookResultCriteria(DateTime.Now);

            var dataTable = new DataTable();
            objectDb.ExecuteReader(Arg.Any<Hashtable>()).Returns(dataTable.CreateDataReader());

            var expectedData = new List<Sportsbook>();

            // Act
            var actualData = dataAccess.GetSportbookResults(criteria);

            // Assert
            Assert.IsTrue(compareLogic.Compare(expectedData, actualData).AreEqual);
        }

        [Test]
        public void GetScoreInformation_CriteriaIsNull_ThrowsArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>(new TestDelegate(() => dataAccess.GetScoreInformation(null)));
        }

        [Test]
        public void GetScoreInformation_EmptyDataReturnFromDb_ReturnsDefaultData()
        {
            // Arrange
            var criteria = new GetSportsbookResultDetailsCriteria();

            var dataTable = new DataTable();
            objectDb.ExecuteReader(Arg.Any<Hashtable>()).Returns(dataTable.CreateDataReader());

            var expectedData = new List<Sportsbook>();

            // Act
            var actualData = dataAccess.GetScoreInformation(criteria);

            // Assert
            Assert.IsTrue(compareLogic.Compare(expectedData, actualData).AreEqual);
        }
    }
}
