using Alpha.Results.Site.Controllers;
using Alpha.Results.Site.Services;
using NSubstitute;
using NUnit.Framework;

namespace Alpha.Results.Site.Tests.Controllers
{
    [TestFixture]
    public class TabControllerTests
    {
        private ICacheRefService cacheRefService;
        private TabController controller;

        [SetUp]
        public void SetUp()
        {
            cacheRefService = Substitute.For<ICacheRefService>();
            controller = new TabController(cacheRefService);
        }

        [Test]
        public void TabControllerCtor_Always_Called()
        {
            Assert.IsNotNull(controller);
        }
    }
}