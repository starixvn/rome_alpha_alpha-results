namespace Alpha.Results.Site.Tests.Services
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Criteria;
    using Fanex.Caching;
    using Fanex.Data.Repository;
    using FluentAssertions;
    using Models;
    using Models.Dtos;
    using NSubstitute;
    using NUnit.Framework;
    using Site.Services;
    using Site.Services.Impl;
    using Sunplus.Agent.Model.BL.Definitions;
    [TestFixture]
    public class NormalResultServiceTest
    {
        private IDynamicRepository _repository;
        private IResultServiceFactory _serviceFactory;
        private INormalResultService _service;

        [SetUp]
        public void Init()
        {
            _repository = Substitute.For<IDynamicRepository>();
            _serviceFactory = Substitute.For<ResultServiceFactory>();
        }


        [Test]
        public void GetLeagues_IsNegativeOrZero_ThrowArgumentOutOfRangeException()
        {
            // Arrange
            _service = new NormalResultService(_repository, _serviceFactory);

            // Assert
            Assert.Throws<ArgumentOutOfRangeException>(() => _service.GetLeagues(Arg.Any<DateTime>(), -1, Arg.Any<string>(), Arg.Any<bool>()));
        }

        [Test]
        public void GetLeagues_LanguageIsEmptyString_ThrowArgumentException()
        {
            // Arrange
            _service = new NormalResultService(_repository, _serviceFactory);

            // Assert
            Assert.Throws<ArgumentException>(() => _service.GetLeagues(Arg.Any<DateTime>(), 1, string.Empty, Arg.Any<bool>()));
        }

        [Test]
        public void GetLeagues_SportIsHorseRacingAndSettingHRWinIsDisabled_ReturnEmptyEnumerableLeague()
        {
            // Arrange
            _service = new NormalResultService(_repository, _serviceFactory);

            // Act
            var actualResult = _service.GetLeagues(Arg.Any<DateTime>(), (int)SportType.HorseRacing, "a language", disableHorseRacingWin: true);

            // Assert
            Assert.AreEqual(Enumerable.Empty<League>(), actualResult);
        }

        [Test]
        public void GetLeagues_PreConditionsAreValid_ReturnDataGetFromRepository()
        {
            // Arrange
            var expected = new List<League>();
            expected.Add(new League { Id = 1, Name = "Leaguge 1" });
            expected.Add(new League { Id = 2, Name = "Leaguge 2" });
            _repository.Fetch<League>(new GetResultLeaguesByDateCriteria()).ReturnsForAnyArgs(expected);
            _service = new NormalResultService(_repository, _serviceFactory);

            // Act
            var actualResult = _service.GetLeagues(Arg.Any<DateTime>(), 2, "a language", disableHorseRacingWin: false);

            // Assert
            Assert.AreEqual(actualResult.ToList(), expected);
        }

    }
}
