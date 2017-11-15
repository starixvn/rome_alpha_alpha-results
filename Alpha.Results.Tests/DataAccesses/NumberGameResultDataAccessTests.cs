namespace Alpha.Results.Site.Tests.DataAccesses
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Data;
    using Fanex.Data;
    using Fanex.Result.Core.NumberGame.DTO;
    using KellermanSoftware.CompareNetObjects;
    using NSubstitute;
    using NUnit.Framework;
    using Site.Criteria;
    using Site.DataAccesses.Impl;

    [TestFixture]
    public class NumberGameResultDataAccessTests
    {
        private CompareLogic compareLogic;
        private IObjectDb objectDb;
        private NumberGameResultDataAccess dataAccess;

        [SetUp]
        public void SetUp()
        {
            compareLogic = new CompareLogic();

            objectDb = Substitute.For<IObjectDb>();
            ObjectDbFactory.CreateInstance = (settingKey) => objectDb;

            dataAccess = new NumberGameResultDataAccess();
        }

        [Test]
        public void GetNumberGameResults_CriteriaIsNull_ThrowsArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>(new TestDelegate(() => dataAccess.GetNumberGameResults(null)));
        }

        [Test]
        public void GetNumberGameResults_EmptyDataReturnFromDb_ReturnsDefaultData()
        {
            // Arrange
            var criteria = new GetNumberGameResultCriteria();

            var dataTable = new DataTable();
            objectDb.ExecuteReader(Arg.Any<Hashtable>()).Returns(dataTable.CreateDataReader());

            var expectedData = new List<NumberGame>();

            // Act
            var actualData = dataAccess.GetNumberGameResults(criteria);

            // Assert
            Assert.IsTrue(compareLogic.Compare(expectedData, actualData).AreEqual);
        }

        [Test]
        public void GetNumberGameResultDetails_CriteriaIsNull_ThrowsArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>(new TestDelegate(() => dataAccess.GetNumberGameResultDetails(null)));
        }

        [Test]
        public void GetNumberGameResultDetails_EmptyDataReturnFromDb_ReturnsDefaultData()
        {
            // Arrange
            var criteria = new GetNumberGameResultDetailsCriteria();

            var dataTable = new DataTable();
            objectDb.ExecuteReader(Arg.Any<Hashtable>()).Returns(dataTable.CreateDataReader());

            var expectedData = new List<NumberGame>();

            // Act
            var actualData = dataAccess.GetNumberGameResultDetails(criteria);

            // Assert
            Assert.IsTrue(compareLogic.Compare(expectedData, actualData).AreEqual);
        }
    }
}
