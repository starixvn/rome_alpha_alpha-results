namespace Alpha.Results.Site.Tests.Handlers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using Models.Requests;
    using NSubstitute;
    using NUnit.Framework;
    using Site.Handlers;
    using Site.Services;
    using Site.Services.Impl;
    using Sunplus.Agent.Model.Entities;
    using Sunplus.Agent.Model.RemotingRef;
    using Alpha.Utilities.Extensions;

    public class OutrightResultHandleTests
    {
        private IOutrightResultService _outrightResultService;
        private OutrightResultHandler _outrightResultHandler;
        private IReportDateService _reportDataService;

        [SetUp]
        public void SetUp()
        {
            _outrightResultService = Substitute.For<IOutrightResultService>();
            _reportDataService = Substitute.For<IReportDateService>();
            _outrightResultHandler = new OutrightResultHandler(_outrightResultService, _reportDataService);

            CacheRefFactory.CacheRef = Substitute.For<ICacheRefService>();
            UserSessionFactory.CurrentSession = Substitute.For<IUserSession>();
            UserSessionFactory.CurrentSession.Language = "en-US";
        }

        #region Outright Result Query

        [Test]
        public void HandleOutrightResultQuery_QueryIsNull_ThrowArgumentNullException()
        {
            OutrightResultQuery query = null;

            Assert.Throws<ArgumentNullException>(() => _outrightResultHandler.Handle(query));
        }

        [Test]
        public void HandleOutrightResultQuery_WhenCalled_ReturnFromDateIsToday()
        {
            //// Arrange
            var query = new OutrightResultQuery();

            //// Act
            var actualViewModel = _outrightResultHandler.Handle(query);

            //// Assert
            Assert.AreEqual(DateTime.Now.Date, actualViewModel.FromDate.Date);
        }

        [Test]
        public void HandleOutrightResultQuery_WhenCalled_ReturnToDateIsToday()
        {
            //// Arrange
            var query = new OutrightResultQuery();

            //// Act
            var actualViewModel = _outrightResultHandler.Handle(query);

            //// Assert
            Assert.AreEqual(DateTime.Now.Date, actualViewModel.ToDate.Date);
        }

        [Test]
        public void HandleOutrightResultQuery_WhenCalled_ReturnToDayText()
        {
            //// Arrange
            var query = new OutrightResultQuery();

            //// Act
            var actualViewModel = _outrightResultHandler.Handle(query);

            //// Assert
            Assert.AreEqual(actualViewModel.ToDate.ToShortDateFormatWithSlash(), actualViewModel.Today);
        }

        [Test]
        public void HandleOutrightResultQuery_WhenCalled_ReturnYesterdayText()
        {
            //// Arrange
            var query = new OutrightResultQuery();

            //// Act
            var actualViewModel = _outrightResultHandler.Handle(query);

            //// Assert
            Assert.AreEqual(actualViewModel.ToDate.AddDays(-1).ToShortDateFormatWithSlash(), actualViewModel.Yesterday);
        }

        [Test]
        public void HandleOutrightResultQuery_WhenCalled_ReturnMinResultDateIsBalanceUpDate()
        {
            //// Arrange
            var query = new OutrightResultQuery();
            var balanceUpDate = new DateTime(2016, 1, 1);

            _reportDataService.GetBalanceUpDate().Returns(balanceUpDate);

            //// Act
            var actualViewModel = _outrightResultHandler.Handle(query);

            //// Assert
            Assert.AreEqual(balanceUpDate, actualViewModel.MinResultDate);
        }

        [Test]
        public void HandleOutrightResultQuery_WhenCalled_ReturnMinResultDateMessage()
        {
            //// Arrange
            var query = new OutrightResultQuery();
            var balanceUpDate = new DateTime(2016, 1, 1);

            _reportDataService.GetBalanceUpDate().Returns(balanceUpDate);

            //// Act
            var actualViewModel = _outrightResultHandler.Handle(query);

            //// Assert
            var expectedMinResultDateMessage = $"You can view the report data from {balanceUpDate.ToShortDateFormatWithSlash()}.";
            Assert.AreEqual(expectedMinResultDateMessage, actualViewModel.MinResultDateMessage);
        }

        [Test]
        public void HandleOutrightResultQuery_WhenCalled_ReturnMaxResultDateIsToday()
        {
            //// Arrange
            var query = new OutrightResultQuery();

            //// Act
            var actualViewModel = _outrightResultHandler.Handle(query);

            //// Assert
            Assert.AreEqual(DateTime.Now.Date, actualViewModel.MaxResultDate);
        }

        [Test]
        public void HandleOutrightResultQuery_WhenCalled_ExecuteGetOutrights()
        {
            //// Arrange
            var query = new OutrightResultQuery();
            var balanceUpDate = new DateTime(2016, 1, 1);

            _reportDataService.GetBalanceUpDate().Returns(balanceUpDate);

            //// Act
            _outrightResultHandler.Handle(query);

            //// Assert
            _outrightResultService.Received().GetOutrights(query.FromDate, query.ToDate, balanceUpDate);
        }

        #endregion
    }
}
