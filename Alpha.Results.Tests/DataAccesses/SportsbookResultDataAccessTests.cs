namespace Alpha.Results.Site.Tests.DataAccesses
{
    using System;
    using System.Collections.Generic;
    using Alpha.Results.Site.Models.Entities;
    using Alpha.Results.Site.Models.Requests;
    using Fanex.Data.Repository;
    using Fanex.Result.Core.Sportsbook.DTO;
    using KellermanSoftware.CompareNetObjects;
    using Newtonsoft.Json;
    using NSubstitute;
    using NUnit.Framework;
    using Site.Criteria;
    using Site.DataAccesses.Impl;

    [TestFixture]
    public class SportsbookResultDataAccessTests
    {
        private CompareLogic compareLogic;
        private IDynamicRepository repository;
        private SportsbookResultDataAccess dataAccess;

        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
        }

        [SetUp]
        public void SetUp()
        {
            compareLogic = new CompareLogic();

            repository = Substitute.For<IDynamicRepository>();
            dataAccess = new SportsbookResultDataAccess(repository);
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

            var dataTable = (
                new List<SportsbookEntity>(),
                new List<GameDetail>()
            );
            repository.FetchMultiple<SportsbookEntity, GameDetail>(Arg.Any<ICriteria>()).Returns(dataTable);

            var expectedData = new List<Sportsbook>();

            // Act
            var actualData = dataAccess.GetSportbookResults(criteria);

            // Assert
            Assert.IsTrue(compareLogic.Compare(expectedData, actualData).AreEqual);
        }

        [Test]
        public void GetSportbookResults_HasData_ReturnsDataFromObjectDb()
        {
            // Arrange
            var criteria = new GetSportsbookResultCriteria(DateTime.Now);

            var dataTable = (
                new List<SportsbookEntity>(),
                new List<GameDetail>()
            );
            repository.FetchMultiple<SportsbookEntity, GameDetail>(Arg.Any<ICriteria>()).Returns(dataTable);

            var expectedData = new List<Sportsbook>
            {
                new Sportsbook
                {
                    AwayId = 1201,
                    HomeId = 1200,
                    BetStatus = "1FL:1-1;FL:1-1;",
                    LeagueId = 165,
                    MatchId = 70000113,
                    EventStatus = "completed",
                    FinalAwayScore = 1,
                    HtAwayScore = 1,
                    Color = "#ff0000",
                    FinalHomeScore = 0,
                    HtHomeScore = 0,
                    EventDate = new DateTime(2017, 11 , 16),
                    IsNeutral = false,
                    KickOffTime =  new DateTime(2017, 11, 16),
                    MatchCode = "QC_NAP_Delete_Parlay",
                    GoalRecord = "A;",
                    IsHTCal = true,
                    Calculate = true,
                    RefNo = string.Empty,
                    GameDetails = new List<GameDetail>(),
                    Bettype = 1,
                    BetID = string.Empty,
                    SettlementStatus = 0
                },
                new Sportsbook
                {
                    AwayId = 1201,
                    HomeId = 1200,
                    BetStatus = "1FL:1-1;FL:1-1;",
                    LeagueId = 166,
                    MatchId = 70000112,
                    EventStatus = "completed",
                    FinalAwayScore = 0,
                    HtAwayScore = 0,
                    Color = "#ff0000",
                    FinalHomeScore = 1,
                    HtHomeScore = 1,
                    EventDate = new DateTime(2017, 11 , 16),
                    IsNeutral = false,
                    KickOffTime =  new DateTime(2017, 11, 16),
                    MatchCode = "QC_NAP_Delete_Parlay",
                    GoalRecord = "H;",
                    IsHTCal = true,
                    Calculate = true,
                    RefNo = string.Empty,
                    GameDetails = new List<GameDetail>
                    {
                        new GameDetail { MatchId = 70000112, ResourceId = "01", HomeValue = "0", AwayValue = "1", SettlementStatusID = 4 }
                    },
                    Bettype = 0,
                    BetID = string.Empty,
                    SettlementStatus = 0
                }
            };

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
            var request = new NormalResultDetailsQuery();

            var dataTable = (
                new List<SportsbookEntity>(),
                new List<GameDetail>()
            );
            repository.FetchMultiple<SportsbookEntity, GameDetail>(Arg.Any<ICriteria>()).Returns(dataTable);

            var expectedData = new List<Sportsbook>();

            // Act
            var actualData = dataAccess.GetScoreInformation(request);

            // Assert
            Assert.IsTrue(compareLogic.Compare(expectedData, actualData).AreEqual);
        }

        [Test]
        public void GetScoreInformation_HasData_ReturnsDataFromObjectDb()
        {
            // Arrange
            var request = new NormalResultDetailsQuery
            {
                BetId = 1,
                BetTypeId = 1,
                MatchId = 70000112,
            };

            var dataTable = (
                new List<SportsbookEntity>(),
                new List<GameDetail>()
            );
            repository.FetchMultiple<SportsbookEntity, GameDetail>(Arg.Any<ICriteria>()).Returns(dataTable);

            var expectedData = new List<Sportsbook>
            {
                new Sportsbook
                {
                    AwayId = 1201,
                    HomeId = 1200,
                    BetStatus = "1FL:1-1;FL:1-1;",
                    LeagueId = 165,
                    MatchId = 70000112,
                    EventStatus = "completed",
                    FinalAwayScore = 1,
                    HtAwayScore = 1,
                    Color = string.Empty,
                    FinalHomeScore = 0,
                    HtHomeScore = 0,
                    EventDate = new DateTime(2017, 11 , 16),
                    IsNeutral = false,
                    KickOffTime =  new DateTime(2017, 11, 16),
                    MatchCode = "QC_NAP_Delete_Parlay",
                    GoalRecord = "A;",
                    IsHTCal = true,
                    Calculate = true,
                    RefNo = string.Empty,
                    GameDetails = new List<GameDetail>
                    {
                        new GameDetail { MatchId = 70000112, ResourceId = "01", HomeValue = "0", AwayValue = "1", ResultStatusID = 5, SettlementStatusID = 4, OtherInfo = "0:1" },
                        new GameDetail { MatchId = 70000112, ResourceId = "04", HomeValue = "1", AwayValue = "2", ResultStatusID = 5, SettlementStatusID = 4, OtherInfo = string.Empty }
                    },
                    BetID = "1",
                    Bettype = 1,
                    SettlementStatus = 0
                }
            };

            // Act
            var actualData = dataAccess.GetScoreInformation(request);

            // Assert
            Assert.IsTrue(compareLogic.Compare(expectedData, actualData).AreEqual);
        }

        [Test]
        public void GetBetBuilderInformation_HasData_ReturnsDataFromObjectDb()
        {
            // Arrange
            var criteria = new GetBetBuidlerResultDetailsCriteria();

            var dataTable = (
                new List<SportsbookEntity>(),
                new List<BetBuilderDetail>()
            );
            repository.FetchMultiple<SportsbookEntity, BetBuilderDetail>(Arg.Any<ICriteria>()).Returns(dataTable);

            var expectedData = new Sportsbook
            {
                AwayId = 1201,
                HomeId = 1200,
                BetStatus = "1FL:1-1;FL:1-1;",
                LeagueId = 165,
                MatchId = 70000113,
                EventStatus = "completed",
                FinalAwayScore = 1,
                HtAwayScore = 1,
                Color = "#ff0000",
                FinalHomeScore = 0,
                HtHomeScore = 0,
                EventDate = new DateTime(2017, 11, 16),
                IsNeutral = false,
                KickOffTime = new DateTime(2017, 11, 16),
                MatchCode = "QC_NAP_Delete_Parlay",
                GoalRecord = "A;",
                IsHTCal = true,
                Calculate = true,
                RefNo = string.Empty,
                BetBuilderDetails = new List<BetBuilderDetail>
                    {
                        new BetBuilderDetail { SelectionType = 12345, Result ="01", SelectionName = null}
                    },
                BetID = "1",
                Bettype = 1,
                SettlementStatus = 0
            };

            // Act
            var actualData = dataAccess.GetBetBuilderInformation(criteria);

            // Assert
            Assert.AreEqual(JsonConvert.SerializeObject(expectedData), JsonConvert.SerializeObject(actualData));
        }
    }
}
