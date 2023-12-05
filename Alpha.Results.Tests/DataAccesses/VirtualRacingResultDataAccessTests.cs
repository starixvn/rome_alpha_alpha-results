namespace Alpha.Results.Site.Tests.DataAccesses
{
    using System;
    using System.Collections.Generic;
    using Fanex.Data.Repository;
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
        private IDynamicRepository repository;
        private VirtualRacingResultDataAccess dataAccess;

        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
        }

        [SetUp]
        public void SetUp()
        {
            compareLogic = new CompareLogic();

            repository = Substitute.For<IDynamicRepository>();
            dataAccess = new VirtualRacingResultDataAccess(repository);
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

            var dataTable = new List<Racing>();
            repository.Fetch<Racing>(Arg.Any<ICriteria>()).Returns(dataTable);

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

            var dataTable = new List<Racing>();
            repository.Fetch<Racing>(Arg.Any<ICriteria>()).Returns(dataTable);

            var expectedData = new List<Racing>();

            // Act
            var actualData = dataAccess.GetVirtualRacingResultDetails(criteria);

            // Assert
            Assert.IsTrue(compareLogic.Compare(expectedData, actualData).AreEqual);
        }

        [Test]
        public void GetVirtualRacingResults_HasData_ReturnsDataFromObjectDb()
        {
            // Arrange
            var criteria = new GetVirtualRacingResultCriteria();

            var dataTable = new List<Racing>();
            repository.Fetch<Racing>(Arg.Any<ICriteria>()).Returns(dataTable);

            var expectedData = new List<Racing>
            {
                new Racing
                {
                    LeagueId = 1,
                    EngineId = "1201",
                    EngineNo = "1200",
                    IsFavor = true,
                    IsSCR = true,
                    Place = 123,
                    PlaceOdds = 12.3m,
                    WinOdds = 1.2m,
                    RaceName = 1234,
                    KickOffTime = new DateTime(2017,11,16),
                    Favourite = "1",
                    RowCount = 1,
                    SCROfMatch = "scr",
                    TFOfMatch = "ff0000",
                    Status = "win",
                }
            };

            // Act
            var actualData = dataAccess.GetVirtualRacingResults(criteria);

            // Assert
            Assert.IsTrue(compareLogic.Compare(expectedData, actualData).AreEqual);
        }

        [Test]
        public void GetVirtualRacingResultDetails_HasData_ReturnsDataFromObjectDb()
        {
            // Arrange
            var criteria = new GetRacingResultDetailsCriteria();

            var dataTable = new List<Racing>();
            repository.Fetch<Racing>(Arg.Any<ICriteria>()).Returns(dataTable);

            var expectedData = new List<Racing>
            {
                new Racing
                {
                    LeagueId = 1,
                    EngineId = "1201",
                    EngineNo = "1200",
                    IsFavor = true,
                    IsSCR = true,
                    Place = 123,
                    PlaceOdds = 12.3m,
                    WinOdds = 1.2m,
                    RaceName = 1234,
                    KickOffTime = new DateTime(2017,11,16),
                    Favourite = "1",
                    RowCount = 1,
                    SCROfMatch = "scr",
                    TFOfMatch = "ff0000",
                    Status = "win",
                }
            };

            // Act
            var actualData = dataAccess.GetVirtualRacingResultDetails(criteria);

            // Assert
            Assert.IsTrue(compareLogic.Compare(expectedData, actualData).AreEqual);
        }
    }
}
