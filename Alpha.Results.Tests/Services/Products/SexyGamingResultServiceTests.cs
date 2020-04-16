namespace Alpha.Results.Site.Tests.Services.Products
{
    using System;
    using System.Collections.Generic;
    using Constants;
    using Fanex.Result.Core.AllBetCasino;
    using Fanex.Result.Core.SAGaming;
    using Fanex.Result.Core.SexyGaming;
    using NSubstitute;
    using NUnit.Framework;
    using Site.Models.Requests;
    using Site.Services.Impl.Products;

    [TestFixture]
    public class SexyGamingResultServiceTests
    {
        private ISexyGamingResultBuilder builder;
        private SexyGamingResultService service;

        [SetUp]
        public void SetUp()
        {
            builder = Substitute.For<ISexyGamingResultBuilder>();
            service = new SexyGamingResultService(builder);
        }

        [Test]
        public void ExportExcel_ThrowNotImplementedException()
        {
            Assert.Throws<NotImplementedException>(() => service.ExportExcel(null));
        }

        [Test]
        public void GetResult_ThrowNotImplementedException()
        {
            Assert.Throws<NotImplementedException>(() => service.GetResult(null));
        }

        [Test]
        public void GetResultDetails_RequestIsNull_ThrowArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>(new TestDelegate(() => service.GetResultDetails(null)));
        }

        [Test]
        public void GetResultDetails_ResutIsNotNull_CallSAGamingResultBuilderRender()
        {
            // Arrange
            var request = new NormalResultDetailsQuery(new Dictionary<int, bool>(), LanguageCode.English)
            {
                TransDesc = "",
                BetCheck = "",
                BetTypeId = 1
            };

            // Act
            service.GetResultDetails(request);

            // Assert
            builder.Received().Render(
                Arg.Is(request.TransDesc),
                Arg.Is(request.BetCheck),
                Arg.Is(request.BetTypeId.ToString()),
                Arg.Is(request.Language));
        }
    }
}
