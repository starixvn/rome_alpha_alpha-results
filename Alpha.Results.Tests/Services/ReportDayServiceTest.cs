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

        private IDynamicRepository SetupRepositoryWithDataReturn(DateTime balanceUpDate, DateTime moveBetsDate)
        {
            var dynamicRepository = Substitute.For<IDynamicRepository>();
            var reportDays = new BalanceUpAndMoveBetsDate { BalanceUpDay = balanceUpDate, MoveBetsDay = moveBetsDate };
            dynamicRepository.Get<BalanceUpAndMoveBetsDate>(Arg.Any<GetBalanceUpAndMoveBetsDayCriteria>()).Returns(reportDays);

            return dynamicRepository;
        }

        [Test]
        public void GetBalanceUpDate_DataExistInCache_MustReturnDataGetFromCache()
        {
            // Arrange            
            var cacheManager = Substitute.For<ICache>();
            var expectedDay = DateTime.Now.AddDays(-1);
            cacheManager.Get<DateTime>(BalanceUpDateCacheKey).Returns(expectedDay);

            var repository = Substitute.For<IDynamicRepository>();

            var reportService = new ReportDateService(repository, cacheManager);

            // Act
            var actual = reportService.GetBalanceUpDate();

            // Assert
            Assert.AreEqual(expectedDay, actual);
        }

        [Test]
        public void GetBalanceUpDate_CacheKeyDoesNotExist_ReturnsDateGetFromRepository()
        {
            // Arrange
            var cacheManager = Substitute.For<ICache>();

            var balanceUpDate = new DateTime(1981, 2, 15);
            var repository = Substitute.For<IDynamicRepository>();
            var reportDays = new BalanceUpAndMoveBetsDate { BalanceUpDay = balanceUpDate, MoveBetsDay = DateTime.Now };
            repository.Get<BalanceUpAndMoveBetsDate>(new GetBalanceUpAndMoveBetsDayCriteria()).ReturnsForAnyArgs(reportDays);

            var reportService = new ReportDateService(repository, cacheManager);

            // Act
            var actual = reportService.GetBalanceUpDate();

            // Assert
            Assert.AreEqual(balanceUpDate, actual);
        }

        [Test]
        public void GetBalanceUpDate_DataGetFromRepositoryIsNull_ThrowException()
        {
            // Arrange
            var cacheManager = Substitute.For<ICache>();
            cacheManager.Get<DateTime>(BalanceUpDateCacheKey).Returns(DateTime.MinValue);

            var repository = Substitute.For<IDynamicRepository>();
            BalanceUpAndMoveBetsDate data = null;
            repository.Get<BalanceUpAndMoveBetsDate>(Arg.Any<GetBalanceUpAndMoveBetsDayCriteria>()).Returns(data);

            var reportService = new ReportDateService(repository, cacheManager);

            // Act
            Assert.Throws<Exception>(() => reportService.GetBalanceUpDate());
            reportService
                .Invoking(service => service.GetBalanceUpDate())
                .ShouldThrow<Exception>()
                .WithMessage("Cannot get balance up date");
        }

        [Test]
        public void GetBalanceUpDate_DataGetFromRepositoryIsNotNull_MustBeSetToCache()
        {
            // Arrange
            var cacheManager = Substitute.For<ICache>();

            var balanceUpDate = new DateTime(1981, 2, 15);
            var repository = SetupRepositoryWithDataReturn(balanceUpDate, moveBetsDate: DateTime.Now);

            var reportService = new ReportDateService(repository, cacheManager);

            // Act
            reportService.GetBalanceUpDate();

            // Assert
            cacheManager.Received().Set(BalanceUpDateCacheKey, balanceUpDate);
        }
    }
}