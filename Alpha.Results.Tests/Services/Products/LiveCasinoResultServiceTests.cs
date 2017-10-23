namespace Alpha.Results.Site.Tests.Services.Products
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Fanex.Data.Repository;
    using Fanex.Result.Core.Base;
    using Fanex.Result.Core.LiveCasino.DTO;
    using NSubstitute;
    using NUnit.Framework;
    using Site.Criteria;
    using Site.Models.Requests;
    using Site.Services;
    using Site.Services.Impl.Products;

    [TestFixture]
    public class LiveCasinoResultServiceTests
    {
        private const string DefaultLanguage = "en-US";
        private LiveCasinoResultService _liveCasinoResultService;
        private IDynamicRepository _dynamicRepository;
        private IResultEngineAdapter _resultEngineAdapter;

        [SetUp]
        public void SetUp()
        {
            _dynamicRepository = Substitute.For<IDynamicRepository>();
            _resultEngineAdapter = Substitute.For<IResultEngineAdapter>();
            _liveCasinoResultService = new LiveCasinoResultService(_dynamicRepository, _resultEngineAdapter);
        }

        [Test]
        public void GetResultDetails_QueryIsNull_ThrowArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>(() => _liveCasinoResultService.GetResultDetails(null));
        }

        [Test]
        public void GetResultDetails_WhenCalled_ExecuteFetch()
        {
            //// Arrange
            var query = new NormalResultDetailsQuery(new Dictionary<int, bool>(), false, DefaultLanguage)
            {
                MatchId = 1,
                BetTypeId = 1,
                LeagueId = 3
            };

            //// Act
            _liveCasinoResultService.GetResultDetails(query);

            //// Assert
            _dynamicRepository.Received().Fetch<LiveCasino>(
                Arg.Is<GetLiveCasinoResultCriteria>(criteria => criteria.League == "3"
                            && criteria.MatchId == query.MatchId
                            && criteria.BetType == query.BetTypeId));
        }

        [Test]
        public void GetResultDetails_GotDataFromRepository_UpdateDataWithQueryBetType()
        {
            //// Arrange
            var query = new NormalResultDetailsQuery(new Dictionary<int, bool>(), false, DefaultLanguage)
            {
                MatchId = 1,
                BetTypeId = 1,
                LeagueId = 3
            };

            var liveCasinoTickets = new List<LiveCasino>
            {
                new LiveCasino { Bettype = 10 }
            };

            _dynamicRepository.Fetch<LiveCasino>(Arg.Any<GetLiveCasinoResultCriteria>()).Returns(liveCasinoTickets);

            //// Act
            _liveCasinoResultService.GetResultDetails(query);

            //// Assert
            _resultEngineAdapter.Received().HtmlParser(
                Arg.Is<List<LiveCasino>>(items => items.Count == 1 && items.First().Bettype == 1),
                Arg.Any<ResultSetting>());
        }

        [Test]
        public void GetResultDetails_GotDataFromRepository_ExecuteHtmlParserWithResultSetting()
        {
            //// Arrange
            var query = new NormalResultDetailsQuery(new Dictionary<int, bool>(), false, DefaultLanguage)
            {
                MatchId = 1,
                BetTypeId = 1,
                LeagueId = 3
            };

            //// Act
            _liveCasinoResultService.GetResultDetails(query);

            //// Assert
            _resultEngineAdapter.Received().HtmlParser(
                Arg.Any<List<LiveCasino>>(),
                Arg.Is<ResultSetting>(
                resultSetting => resultSetting.SportType == SportType.LiveCasino
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

        [Test]
        public void GetResult_ThrowNotImplementedException()
        {
            Assert.Throws<NotImplementedException>(() => _liveCasinoResultService.GetResult(null));
        }

        [Test]
        public void ExportExcel_ThrowNotImplementedException()
        {
            Assert.Throws<NotImplementedException>(() => _liveCasinoResultService.ExportExcel(null));
        }
    }
}
