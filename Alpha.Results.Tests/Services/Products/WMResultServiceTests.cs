namespace Alpha.Results.Site.Tests.Services.Products
{
    using System;
    using Alpha.Results.Site.Tests.Constants;
    using Fanex.Result.Core.WM;
    using NSubstitute;
    using NUnit.Framework;
    using Site.Models.Requests;
    using Site.Services.Impl.Products;

    [TestFixture]
    public class WMResultServiceTests
    {
        private WMResultService _service;
        private IWMResultBuilder resultBuilder;

        [SetUp]
        public void SetUp()
        {
            resultBuilder = Substitute.For<IWMResultBuilder>();
            _service = new WMResultService(resultBuilder);
        }

        [Test]
        public void ExportExcel_Always_ThrowNotImplementedException()
        {
            Assert.Throws<NotImplementedException>(() => _service.ExportExcel(new ExcelNormalResultQuery()));
        }

        [Test]
        public void GetResult_Always_ThrowNotImplementedException()
        {
            Assert.Throws<NotImplementedException>(() => _service.GetResult(new NormalResultQuery()));
        }

        [Test]
        public void GetResultDetails_Always_CorrectParameter()
        {
            //// Arrange
            var query = new NormalResultDetailsQuery(null, LanguageCode.English)
            {
                TransDesc = "transDecs",
                BetCheck = "betcheck",
                BetTypeId = 123
            };

            //// Act
            _service.GetResultDetails(query);

            //// Assert
            resultBuilder.Received().Render(
                Arg.Is<string>(i => i == "transDecs"),
                Arg.Is<string>(i => i == "betcheck"),
                Arg.Is<int>(i => i == 123),
                Arg.Any<string>());
        }
    }
}
