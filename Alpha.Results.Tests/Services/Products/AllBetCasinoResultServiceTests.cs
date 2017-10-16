namespace Alpha.Results.Site.Tests.Services.Products
{
    using System;
    using NUnit.Framework;
    using Site.Services.Impl.Products;

    [TestFixture]
    public class AllBetCasinoResultServiceTests
    {
        private AllBetCasinoResultService _allbetCasinoResultService;

        [SetUp]
        public void SetUp()
        {
            _allbetCasinoResultService = new AllBetCasinoResultService();
        }

        [Test]
        public void ExportExcel_ThrowNotImplementedException()
        {
            Assert.Throws<NotImplementedException>(() => _allbetCasinoResultService.ExportExcel(null));
        }

        [Test]
        public void GetResult_ThrowNotImplementedException()
        {
            Assert.Throws<NotImplementedException>(() => _allbetCasinoResultService.GetResult(null));
        }

        [Test]
        public void GetResultDetails_RequestIsNull_ThrowArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>(new TestDelegate(() => _allbetCasinoResultService.GetResultDetails(null)));
        }
    }
}
