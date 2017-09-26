namespace Alpha.Results.Site.Tests.Services.Products
{
    using Criteria;
    using DataAccesses;
    using Fanex.Result.Core.Base;
    using Fanex.Result.Core.Lucky3.DTO;
    using Models.Requests;
    using NSubstitute;
    using NUnit.Framework;
    using Site.Services;
    using Site.Services.Impl.Products;
    using System;
    using System.Collections.Generic;

    [TestFixture]
    public class Lucky3ResultServiceTests
    {
        private const string DefaultLanguage = "en-US";
        private Lucky3ResultService lucky3ResultService;
        private ILucky3ResultDataAccess lucky3ResultDataAccess;
        private IResultEngineAdapter resultEngineAdapter;

        [SetUp]
        public void SetUp()
        {
            this.lucky3ResultDataAccess = Substitute.For<ILucky3ResultDataAccess>();
            this.resultEngineAdapter = Substitute.For<IResultEngineAdapter>();
            this.lucky3ResultService = new Lucky3ResultService(lucky3ResultDataAccess, resultEngineAdapter);
        }

        [Test]
        public void GetResultDetails_QueryIsNull_ThrowArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>(() => lucky3ResultService.GetResultDetails(null));
        }

        [Test]
        public void GetResultDetails_WhenCalled_ExecuteFetch()
        {
            //// Arrange
            var query = new NormalResultDetailsQuery(new Dictionary<int, bool>(), false, DefaultLanguage)
            {
                MatchId = 1
            };

            //// Act
            lucky3ResultService.GetResultDetails(query);

            //// Assert
            lucky3ResultDataAccess.Received().GetResultDetails(
                Arg.Is<GetNumberGameResultDetailsCriteria>(criteria => criteria.MatchId == query.MatchId));
        }

        [Test]
        public void GetResultDetails_GotDataFromRepository_UpdateDataWithQueryBetType()
        {
            //// Arrange
            var query = new NormalResultDetailsQuery(new Dictionary<int, bool>(), false, DefaultLanguage)
            {
                MatchId = 3
            };

            var metricGamingTickets = new List<Lucky3>
            {
                new Lucky3()
            };

            lucky3ResultDataAccess.GetResultDetails(Arg.Any<GetNumberGameResultDetailsCriteria>()).Returns(metricGamingTickets);

            //// Act
            lucky3ResultService.GetResultDetails(query);

            //// Assert
            resultEngineAdapter.Received().HtmlParser(
                Arg.Is<List<Lucky3>>(items => items.Count == 1), 
                Arg.Any<ResultSetting>());
        }

        [Test]
        public void GetResultDetails_GotDataFromRepository_ExecuteHtmlParserWithResultSetting()
        {
            //// Arrange
            var query = new NormalResultDetailsQuery(new Dictionary<int, bool>(), false, DefaultLanguage)
            {
                MatchId = 1
            };

            //// Act
            lucky3ResultService.GetResultDetails(query);

            //// Assert
            resultEngineAdapter.Received().HtmlParser(
                Arg.Any<IList<Lucky3>>(), 
                Arg.Is<ResultSetting>(
                resultSetting => resultSetting.SportType == SportType.Lucky3
                                && !resultSetting.IsOutright
                                && !resultSetting.IsParlayPopUp
                                && resultSetting.IsPopUp
                                && !resultSetting.VisiblePopUpTitle
                                && resultSetting.LanguageCode == query.Language
                                && !resultSetting.VisibleMatchCodeIDColumn
                                && resultSetting.VisibleFreeHeader
                                && resultSetting.VisibleDetailedLink
                                && resultSetting.HighlightWinnerTeam));
        }
    }
}