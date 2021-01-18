namespace Alpha.Results.Site.Tests.Services.Products
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Alpha.Results.Site.Tests.Constants;
    using Fanex.Result.Core.Base;
    using Fanex.Result.Core.LeapGaming.DTO;
    using NSubstitute;
    using NUnit.Framework;
    using Site.Models.Requests;
    using Site.Services;
    using Site.Services.Impl.Products;

    [TestFixture]
    public class LeapGamingResultServiceTests
    {
        private LeapGamingResultService _leapGaminggResultService;
        private IResultEngineAdapter _resultEngineAdapter;

        [SetUp]
        public void SetUp()
        {
            _resultEngineAdapter = Substitute.For<IResultEngineAdapter>();
            _leapGaminggResultService = new LeapGamingResultService(_resultEngineAdapter);
        }

        [Test]
        public void ExportExcel_Always_ThrowNotImplementedException()
        {
            Assert.Throws<NotImplementedException>(() => _leapGaminggResultService.ExportExcel(new ExcelNormalResultQuery()));
        }

        [Test]
        public void GetResult_Always_ThrowNotImplementedException()
        {
            Assert.Throws<NotImplementedException>(() => _leapGaminggResultService.GetResult(new NormalResultQuery()));
        }

        [Test]
        public void GetResultDetails_Always_CorrectParameter()
        {
            //// Arrange
            var query = new NormalResultDetailsQuery(null, LanguageCode.English) { TransDesc = "transDecs" };

            //// Act
            _leapGaminggResultService.GetResultDetails(query);

            //// Assert
            _resultEngineAdapter.Received().HtmlParser(
                Arg.Is<IList<LeapGaming>>(i => i.FirstOrDefault().TransDesc == "transDecs"),
                Arg.Is<ResultSetting>(
                resultSetting => resultSetting.SportType == SportType.LeapGamingVirtualSports
                                && resultSetting.IsPopUp));
        }
    }
}
