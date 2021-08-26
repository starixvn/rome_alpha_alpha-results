namespace Alpha.Results.Site.Tests.Services
{
    using Fanex.Caching;
    using Fanex.Data.Repository;
    using FluentAssertions;
    using NSubstitute;
    using NUnit.Framework;
    using Site.Criteria;
    using Site.Models.Dtos;
    using Site.Services.Impl;
    using System;

    [TestFixture]
    public class ReportDayServiceTest
    {
        private const string BalanceUpAndMoveBetsDateCacheKey = "Alpha.Results.Site.Services.Impl.BalanceUpAndMoveBetsDate";

        [Test]
        public void GetBalanceUpDate_ReturnValidDate()
        {
            // Arrange
            var cacheService = Substitute.For<ICacheService>();
            var repository = Substitute.For<IDynamicRepository>();
            var expectedResults = new BalanceUpAndMoveBetsDate
            {
                BalanceUpDay = new DateTime(1981, 2, 15),
                MoveBetsDay = new DateTime(2000, 12, 1)
            };

            cacheService.Get<BalanceUpAndMoveBetsDate>(BalanceUpAndMoveBetsDateCacheKey).Returns(expectedResults);

            var reportService = new ReportDateService(repository, cacheService);

            // Act
            var actual = reportService.GetBalanceUpDate();

            // Assert
            Assert.AreEqual(expectedResults.BalanceUpDay, actual);
        }

        [Test]
        public void GetMoveBetsDate_ReturnValidDate()
        {
            // Arrange
            var cacheService = Substitute.For<ICacheService>();
            var repository = Substitute.For<IDynamicRepository>();
            var expectedResults = new BalanceUpAndMoveBetsDate
            {
                BalanceUpDay = new DateTime(1981, 2, 15),
                MoveBetsDay = new DateTime(2000, 12, 1)
            };

            cacheService.Get<BalanceUpAndMoveBetsDate>(BalanceUpAndMoveBetsDateCacheKey).Returns(expectedResults);

            var reportService = new ReportDateService(repository, cacheService);

            // Act
            var actual = reportService.GetMoveBetsDate();

            // Assert
            Assert.AreEqual(expectedResults.MoveBetsDay, actual);
        }

        [Test]
        public void GetBalanceUpAndMoveBetsDate_DataExistInCache_MustReturnDataGetFromCache()
        {
            // Arrange
            var cacheService = Substitute.For<ICacheService>();
            var expectedResults = new BalanceUpAndMoveBetsDate
            {
                BalanceUpDay = DateTime.Now.AddDays(-1),
                MoveBetsDay = DateTime.Now.AddDays(-1),
            };

            cacheService.Get<BalanceUpAndMoveBetsDate>(BalanceUpAndMoveBetsDateCacheKey).Returns(expectedResults);

            var repository = Substitute.For<IDynamicRepository>();

            var reportService = new ReportDateService(repository, cacheService);

            // Act
            var actual = reportService.GetBalanceUpAndMoveBetsDate();

            // Assert
            Assert.IsTrue(expectedResults.BalanceUpDay == actual.BalanceUpDay &&
                expectedResults.MoveBetsDay == actual.MoveBetsDay);
        }

        [Test]
        public void GetBalanceUpAndMoveBetsDate_CacheKeyDoesNotExist_ReturnsDateGetFromRepository()
        {
            // Arrange
            var cacheService = Substitute.For<ICacheService>();
            var balanceUpDate = new DateTime(1981, 2, 15);
            var moveBetsDay = new DateTime(2000, 12, 1);
            var repository = Substitute.For<IDynamicRepository>();
            var reportDays = new BalanceUpAndMoveBetsDate { BalanceUpDay = balanceUpDate, MoveBetsDay = moveBetsDay };
            repository.Get<BalanceUpAndMoveBetsDate>(new GetBalanceUpAndMoveBetsDayCriteria()).ReturnsForAnyArgs(reportDays);

            var reportService = new ReportDateService(repository, cacheService);

            // Act
            var actual = reportService.GetBalanceUpAndMoveBetsDate();

            // Assert
            Assert.IsTrue(reportDays.BalanceUpDay == actual.BalanceUpDay &&
                reportDays.MoveBetsDay == actual.MoveBetsDay);
        }

        [Test]
        public void GetBalanceUpAndMoveBetsDate_DataGetFromRepositoryIsNull_ThrowException()
        {
            // Arrange
            BalanceUpAndMoveBetsDate data = null;
            var cacheService = Substitute.For<ICacheService>();
            cacheService
                .Get<BalanceUpAndMoveBetsDate>(BalanceUpAndMoveBetsDateCacheKey)
                .Returns(data);

            var repository = Substitute.For<IDynamicRepository>();
            repository.Get<BalanceUpAndMoveBetsDate>(Arg.Any<GetBalanceUpAndMoveBetsDayCriteria>()).Returns(data);

            var reportService = new ReportDateService(repository, cacheService);

            // Act
            Assert.Throws<Exception>(() => reportService.GetBalanceUpAndMoveBetsDate());
            reportService
                .Invoking(service => service.GetBalanceUpAndMoveBetsDate())
                .ShouldThrow<Exception>()
                .WithMessage("Cannot get balance up date and move bets date.");
        }

        [Test]
        public void GetBalanceUpAndMoveBetsDate_DataGetFromRepositoryIsNotNull_MustBeSetToCache()
        {
            // Arrange
            var cacheService = Substitute.For<ICacheService>();
            var balanceUpDate = new DateTime(1981, 2, 15);
            var moveBetsDate = new DateTime(2000, 12, 01);
            var reportDays = new BalanceUpAndMoveBetsDate
            {
                BalanceUpDay = balanceUpDate,
                MoveBetsDay = moveBetsDate
            };

            var repository = Substitute.For<IDynamicRepository>();
            repository.Get<BalanceUpAndMoveBetsDate>(new GetBalanceUpAndMoveBetsDayCriteria()).ReturnsForAnyArgs(reportDays);

            var reportService = new ReportDateService(repository, cacheService);

            // Act
            reportService.GetBalanceUpAndMoveBetsDate();

            // Assert
            cacheService.Received().Set(BalanceUpAndMoveBetsDateCacheKey, reportDays, Arg.Any<CacheItemOptions>());
        }
    }
}
