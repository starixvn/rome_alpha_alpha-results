namespace Alpha.Results.Site.Tests.Services
{
    using System;
    using System.Collections.Generic;
    using Criteria;
    using Fanex.Caching;
    using Fanex.Data.Repository;
    using FluentAssertions;
    using Models.Dtos;
    using NSubstitute;
    using NUnit.Framework;
    using Site.Services.Impl;

    [TestFixture]
    public class ReportDayServiceTest
    {
        private const string BalanceUpDateCacheKey = "Alpha.Results.Site.Services.Impl.BalanceUpDate";
        private const string MoveBetsDayCacheKey = "Alpha.Results.Site.Services.Impl.MoveBetsDate";

        private IDynamicRepository SetupRepositoryWithDataReturn(DateTime balanceUpDate, DateTime moveBetsDate)
        {
            var dynamicRepository = Substitute.For<IDynamicRepository>();
            var reportDays = new BalanceUpAndMoveBetsDate { BalanceUpDay = balanceUpDate, MoveBetsDay = moveBetsDate };
            dynamicRepository.Get<BalanceUpAndMoveBetsDate>(Arg.Any<GetBalanceUpAndMoveBetsDayCriteria>()).Returns(reportDays);

            return dynamicRepository;
        }

        private ICache SetupCacheManager()
        {
            var cacheManager = Substitute.For<ICache>();
            cacheManager.Keys.Returns(new HashSet<string>());

            return cacheManager;
        }

        [Test]
        public void GetBalanceUpDate_DataExistInCache_MustReturnDataGetFromCache()
        {
            // Arrange            
            var cacheManager = SetupCacheManager();
            var expectedDay = DateTime.Now.AddDays(-1);
            cacheManager.Get<DateTime>(BalanceUpDateCacheKey).Returns(expectedDay);

            var repository = Substitute.For<IDynamicRepository>();

            var reportService = new ReportDateService(repository, cacheManager);

            // Act
            var actual = reportService.GetBalanceUpDay();

            // Assert
            Assert.AreEqual(expectedDay, actual);
        }

        [Test]
        public void GetBalanceUpDate_CacheKeyDoesNotExist_ReturnsDateGetFromRepository()
        {
            // Arrange
            var cacheManager = SetupCacheManager();

            var balanceUpDate = new DateTime(1981, 2, 15);
            var repository = SetupRepositoryWithDataReturn(balanceUpDate, moveBetsDate: DateTime.Now);

            var reportService = new ReportDateService(repository, cacheManager);

            // Act
            var actual = reportService.GetBalanceUpDay();

            // Assert
            Assert.AreEqual(balanceUpDate, actual);
        }

        [Test]
        public void GetBalanceUpDate_DataGetFromRepositoryIsNull_ThrowException()
        {
            // Arrange
            var cacheManager = SetupCacheManager();
            cacheManager.Get<DateTime>(BalanceUpDateCacheKey).Returns(DateTime.MinValue);

            var repository = Substitute.For<IDynamicRepository>();
            BalanceUpAndMoveBetsDate data = null;
            repository.Get<BalanceUpAndMoveBetsDate>(Arg.Any<GetBalanceUpAndMoveBetsDayCriteria>()).Returns(data);

            var reportService = new ReportDateService(repository, cacheManager);

            // Act
            Assert.Throws<Exception>(() => reportService.GetBalanceUpDay());
            reportService
                .Invoking(service => service.GetBalanceUpDay())
                .ShouldThrow<Exception>()
                .WithMessage("Cannot get balance up day");
        }

        [Test]
        public void GetBalanceUpDate_DataGetFromRepositoryIsNotNull_MustBeSetToCache()
        {
            // Arrange
            var cacheManager = SetupCacheManager();

            var balanceUpDate = new DateTime(1981, 2, 15);
            var repository = SetupRepositoryWithDataReturn(balanceUpDate, moveBetsDate: DateTime.Now);

            var reportService = new ReportDateService(repository, cacheManager);

            // Act
            reportService.GetBalanceUpDay();

            // Assert
            cacheManager.Received().Set(BalanceUpDateCacheKey, balanceUpDate);
        }
    }
}