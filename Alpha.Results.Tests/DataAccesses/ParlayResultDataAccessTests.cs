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
    public class ParlayResultDataAccessTests
    {
        private CompareLogic compareLogic;
        private IObjectDb objectDb;
        private ParlayResultDataAccess dataAccess;

        [SetUp]
        public void SetUp()
        {
            compareLogic = new CompareLogic();

            objectDb = Substitute.For<IObjectDb>();
            ObjectDbFactory.CreateTimeOutInstance = (settingKey, commandTimeOut) => objectDb;

            dataAccess = new ParlayResultDataAccess();
        }

        [Test]
        public void GetParlayResults_CriteriaIsNull_ThrowsArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>(new TestDelegate(() => dataAccess.GetParlayResults(null)));
        }

        [Test]
        public void GetParlayResults_EmptyDataReturnFromDb_ReturnsNull()
        {
            // Arrange
            var criteria = new GetParlayResultCriteria();

            var dataTable = new DataTable();
            objectDb.ExecuteReader(Arg.Any<Hashtable>()).Returns(dataTable.CreateDataReader());

            var expectedData = new List<Parlay> {
                new Parlay {
                    SportId =0,
                    LeagueId =0,
                    Sportbook = new List<Sportsbook>()
                }
            };

            // Act
            var actualData = dataAccess.GetParlayResults(criteria);

            // Assert
            Assert.IsTrue(compareLogic.Compare(expectedData, actualData).AreEqual);
        }
    }
}
