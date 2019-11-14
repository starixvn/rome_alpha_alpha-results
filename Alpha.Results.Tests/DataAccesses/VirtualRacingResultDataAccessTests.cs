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
    public class VirtualRacingResultDataAccessTests
    {
        private CompareLogic compareLogic;
        private IObjectDb objectDb;
        private VirtualRacingResultDataAccess dataAccess;

        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            DbSettingProviderManager
                .StartTestingSession()
                .Run();
        }

        [SetUp]
        public void SetUp()
        {
            compareLogic = new CompareLogic();

            objectDb = Substitute.For<IObjectDb>();
            ObjectDbFactory.Mock((key, commandTimeout) => objectDb);

            dataAccess = new VirtualRacingResultDataAccess();
        }

        [Test]
        public void GetVirtualRacingResults_CriteriaIsNull_ThrowsArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>(new TestDelegate(() => dataAccess.GetVirtualRacingResults(null)));
        }

        [Test]
        public void GetVirtualRacingResults_EmptyDataReturnFromDb_ReturnsDefaultData()
        {
            // Arrange
            var criteria = new GetVirtualRacingResultCriteria();

            var dataTable = new DataTable();
            objectDb.ExecuteReader(Arg.Any<Hashtable>()).Returns(dataTable.CreateDataReader());

            var expectedData = new List<Racing>();

            // Act
            var actualData = dataAccess.GetVirtualRacingResults(criteria);

            // Assert
            Assert.IsTrue(compareLogic.Compare(expectedData, actualData).AreEqual);
        }

        [Test]
        public void GetVirtualRacingResultDetails_CriteriaIsNull_ThrowsArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>(new TestDelegate(() => dataAccess.GetVirtualRacingResultDetails(null)));
        }

        [Test]
        public void GetVirtualRacingResultDetails_EmptyDataReturnFromDb_ReturnsDefaultData()
        {
            // Arrange
            var criteria = new GetRacingResultDetailsCriteria();

            var dataTable = new DataTable();
            objectDb.ExecuteReader(Arg.Any<Hashtable>()).Returns(dataTable.CreateDataReader());

            var expectedData = new List<Racing>();

            // Act
            var actualData = dataAccess.GetVirtualRacingResultDetails(criteria);

            // Assert
            Assert.IsTrue(compareLogic.Compare(expectedData, actualData).AreEqual);
        }
    }
}
