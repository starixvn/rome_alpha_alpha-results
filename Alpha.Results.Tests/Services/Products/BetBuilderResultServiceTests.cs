using Alpha.Results.Site.DataAccesses;
using Alpha.Results.Site.Models.Requests;
using Alpha.Results.Site.Services;
using Alpha.Results.Site.Services.Impl.Products;
using Fanex.Result.Core.Base;
using Fanex.Result.Core.Sportsbook.DTO;
using NSubstitute;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alpha.Results.Site.Tests.Services.Products
{
    [TestFixture]
    public class BetBuilderResultServiceTests
    {
        private ISportsbookResultDataAccess dataAccess;
        private IResultEngineAdapter resultEngineAdapter;
        private BetBuilderResultService service;

        [SetUp]
        public void SetUp()
        {
            dataAccess = Substitute.For<ISportsbookResultDataAccess>();
            resultEngineAdapter = Substitute.For<IResultEngineAdapter>();
            service = new BetBuilderResultService(dataAccess, resultEngineAdapter);
        }

        [Test]
        public void GetResult_Always_ThrowsNotImplementedException()
        {
            Assert.Throws<NotImplementedException>(new TestDelegate(() => service.GetResult(null)));
        }

        [Test]
        public void ExportExcel_Always_ThrowsNotImplementedException()
        {
            Assert.Throws<NotImplementedException>(new TestDelegate(() => service.ExportExcel(null)));
        }

        [Test]
        public void GetResultDetails_Always_CheckNullArgument()
        {
            Assert.Throws<ArgumentNullException>(new TestDelegate(() => service.GetResultDetails(null)));
        }

        [Test]
        public void GetResultDetails_Always_ReceivedCall()
        {
            // Arrange
            var message = new NormalResultDetailsQuery(Arg.Any<IDictionary<int, bool>>(), "en-US");

            // Act
            service.GetResultDetails(message);

            // Assert
            resultEngineAdapter.Received();
        }
    }
}
