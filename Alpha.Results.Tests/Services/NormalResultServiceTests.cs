namespace Alpha.Results.Site.Tests.Services
{
    using Criteria;
    using Fanex.Data.Repository;
    using Models;
    using NSubstitute;
    using NUnit.Framework;
    using Site.Services;
    using Site.Services.Impl;
    using Sunplus.Agent.Model.BL.Definitions;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    [TestFixture]
    public class NormalResultServiceTests
    {
        private IDynamicRepository _dynamicRepository;
        private IResultServiceFactory _resultServiceFactory;
        private NormalResultService _resultService;
        private const string DefaultLanguage = "en-US";

        [SetUp]
        public void SetUp()
        {
            _dynamicRepository = Substitute.For<IDynamicRepository>();
            _resultServiceFactory = Substitute.For<IResultServiceFactory>();
            _resultService = new NormalResultService(_dynamicRepository, _resultServiceFactory);
        }

        #region Get Leagues

        [TestCase(0)]
        [TestCase(-1)]
        public void GetLeagues_SportIdIsNegativeOrZero_ThrowArgumentOutOfRangeException(int sportId)
        {
            Assert.Throws<ArgumentOutOfRangeException>(new TestDelegate(
                () => _resultService.GetLeagues(DateTime.Now, sportId, DefaultLanguage, false)));
        }

        [TestCase(null)]
        [TestCase("")]
        public void GetLeagues_LanguageIsNullOrEmpty_ThrowArgumentException(string language)
        {
            Assert.Throws<ArgumentException>(new TestDelegate(
                () => _resultService.GetLeagues(DateTime.Now, 1, language, false)));
        }

        [Test]
        public void GetLeagues_ReturnLeagues()
        {
            //// Arrange
            var sportId = 1;
            var resultDate = new DateTime(1989, 5, 28);
            var expectedLeague = new List<League>
            {
                new League
                {
                    Id = 1,
                    Name = "League Name"
                }
            };

            _dynamicRepository.Fetch<League>(Arg.Is<GetResultLeaguesByDateCriteria>(criteria =>
                    criteria.EventDate == resultDate.ToShortDateString()
                    && criteria.Language == DefaultLanguage
                    && criteria.SportId == sportId)).Returns(expectedLeague);

            //// Act
            var leagues = _resultService.GetLeagues(resultDate, sportId, DefaultLanguage, false);

            //// Assert
            Assert.IsTrue(leagues.Count() == 1
                && leagues.ElementAt(0).Id == 1
                && leagues.ElementAt(0).Name == "League Name");
        }

        #endregion Get League

        #region Get Sports

        [Test]
        public void GetSports_ReturnSports()
        {
            //// Arrange
            var sportId = 1;
            var resultDate = new DateTime(1989, 5, 28);
            var expectedSports = new List<Sport>
            {
                new Sport
                {
                    Id = 1,
                    Name = "Sport Name"
                }
            };

            _dynamicRepository.Fetch<Sport>(Arg.Is<GetResultSportsByDateCriteria>(criteria =>
                criteria.EventDate == resultDate.ToShortDateString())).Returns(expectedSports);

            //// Act
            var sports = _resultService.GetSports(resultDate, new Dictionary<int, bool>());

            //// Assert
            Assert.IsTrue(sports.Count() == 1
                && sports.ElementAt(0).Id == 1
                && sports.ElementAt(0).Name == "Sport Name");
        }

        [Test]
        public void GetLeagues_SportIsHorseRacingAndDisabledHorseRacingWinInConfig_ReturnEmptyLeague()
        {
            //// Arrange
            var sportId = (int)SportType.HorseRacing;
            var disableHorseRacingWin = true;

            //// Act
            var leagues = _resultService.GetLeagues(DateTime.Now, sportId, DefaultLanguage, disableHorseRacingWin);

            //// Assert
            Assert.IsEmpty(leagues);
        }

        #endregion
    }
}