namespace Alpha.Results.Site.Tests.DataAccesses
{
    using System;
    using System.Collections.Generic;
    using Alpha.Results.Site.Models.Entities;
    using Fanex.Data.Repository;
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
        private IDynamicRepository repository;
        private NumberGameResultDataAccess dataAccess;

        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
        }

        [SetUp]
        public void SetUp()
        {
            compareLogic = new CompareLogic();

            repository = Substitute.For<IDynamicRepository>();
            dataAccess = new NumberGameResultDataAccess(repository);
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

            var dataTable = new List<NumberGameEntity>();
            repository.Fetch<NumberGameEntity>(Arg.Any<ICriteria>()).Returns(dataTable);

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

            var dataTable = new List<NumberGameEntity>();
            repository.Fetch<NumberGameEntity>(Arg.Any<ICriteria>()).Returns(dataTable);

            var expectedData = new List<NumberGame>();

            // Act
            var actualData = dataAccess.GetNumberGameResultDetails(criteria);

            // Assert
            Assert.IsTrue(compareLogic.Compare(expectedData, actualData).AreEqual);
        }

        [Test]
        public void GetNumberGameResults_HasData_ReturnsDataFromObjectDb()
        {
            // Arrange
            var criteria = new GetNumberGameResultCriteria();

            var dataTable = new List<NumberGameEntity>();
            repository.Fetch<NumberGameEntity>(Arg.Any<ICriteria>()).Returns(dataTable);

            var expectedData = new List<NumberGame>
            {
                new NumberGame
                {
                    LeagueId = 1,
                    MatchId = 1201,
                    EventStatus = "completed",
                    EventDate = new DateTime(2017,11,16),
                    KickOffTime = new DateTime(2017,11,16),
                    MatchCode = "1200",
                    Seg = new List<int> { 1, 2},
                    Ball = new List<int> { 1, 2 }
                }
            };

            // Act
            var actualData = dataAccess.GetNumberGameResults(criteria);

            // Assert
            Assert.IsTrue(compareLogic.Compare(expectedData, actualData).AreEqual);
        }

        [Test]
        public void GetNumberGameResultDetails_HasData_ReturnsDataFromObjectDb()
        {
            // Arrange
            var criteria = new GetNumberGameResultDetailsCriteria();

            var dataTable = new List<NumberGameEntity>();
            repository.Fetch<NumberGameEntity>(Arg.Any<ICriteria>()).Returns(dataTable);

            var expectedData = new List<NumberGame>
            {
                new NumberGame
                {
                    LeagueId = 1,
                    MatchId = 1201,
                    EventStatus = "completed",
                    EventDate = new DateTime(2017,11,16),
                    KickOffTime = new DateTime(2017,11,16),
                    MatchCode = "1200",
                    Seg = new List<int> { 1, 2 },
                    Ball = new List<int> { 1, 2 }
                }
            };

            // Act
            var actualData = dataAccess.GetNumberGameResultDetails(criteria);

            // Assert
            Assert.IsTrue(compareLogic.Compare(expectedData, actualData).AreEqual);
        }
    }
}
