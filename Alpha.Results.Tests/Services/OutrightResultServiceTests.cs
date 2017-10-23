namespace Alpha.Results.Site.Tests.Services
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Constants;
    using Fanex.Data.Repository;
    using Fanex.Result.Core.Base;
    using Fanex.Result.Core.Sportsbook.DTO;
    using KellermanSoftware.CompareNetObjects;
    using NSubstitute;
    using NUnit.Framework;
    using Site.Models.Requests;
    using Site.Services;
    using Site.Services.Impl;

    [TestFixture]
    public class OutrightResultServiceTests
    {
        private IDynamicRepository _dynamicRepository;
        private IResultEngineAdapter _resultEngineAdatper;
        private OutrightResultService _resultService;

        [SetUp]
        public void SetUp()
        {
            _dynamicRepository = Substitute.For<IDynamicRepository>();
            _resultEngineAdatper = Substitute.For<IResultEngineAdapter>();
            _resultService = new OutrightResultService(_dynamicRepository, _resultEngineAdatper);
        }

        [Test]
        public void GetOutrights_FromDateIsLessThanBalanceUpDate_ReturnEmptyList()
        {
            // Arrange
            var expectedResult = Enumerable.Empty<Outright>();

            // Act
            var actualResult = _resultService.GetOutrights(DateTime.Now, DateTime.Now, DateTime.Now.AddDays(1));

            // Assert
            Assert.AreEqual(expectedResult, actualResult);
        }

        [Test]
        public void GetResults_OutrightsIsNull_ThrowArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>(new TestDelegate(() => _resultService.GetResults(null, new OutrightResultQuery())));
        }

        [Test]
        public void GetResults_RequestIsNull_ThrowArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>(new TestDelegate(() => _resultService.GetResults(new List<Outright>(), null)));
        }

        [Test]
        public void GetResults_RequestIsNotNull_ReturnResult()
        {
            // Arrange
            var compareLogic = new CompareLogic();
            var request = new OutrightResultQuery(LanguageCode.English)
            {
                SportType = 1,
                LeagueId = 1
            };
            var outrights = new List<Outright>();
            var resultSetting = new ResultSetting
            {
                LanguageCode = request.Language,
                IsOutright = true,
                IsPopUp = false,
                VisibleMatchCodeIDColumn = false,
                HighlightWinnerTeam = true
            };
            var expectedResult = _resultEngineAdatper.HtmlParser(outrights, resultSetting);

            // Act
            var actualResults = _resultService.GetResults(outrights, request);

            // Assert
            Assert.IsTrue(compareLogic.Compare(expectedResult, actualResults).AreEqual);
        }

        [Test]
        public void GetExcelResults_RequestIsNull_ThrowArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>(new TestDelegate(() => _resultService.GetExcelResults(null, DateTime.Now)));
        }

        [TestCase(null)]
        [TestCase("")]
        public void GetExcelResults_TemplatePathIsNullOrEmpty_ThrowArgumentException(string templatePath)
        {
            Assert.Throws<ArgumentException>(new TestDelegate(
                () => _resultService.GetExcelResults(new ExcelOutrightResultQuery() { TemplatePath = templatePath }, DateTime.Now)));
        }
    }
}
