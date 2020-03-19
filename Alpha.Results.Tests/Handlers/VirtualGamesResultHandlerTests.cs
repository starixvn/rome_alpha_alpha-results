namespace Alpha.Results.Site.Tests.Handlers
{
    using Alpha.Results.Site.Helpers;
    using Fanex.Result.Core.VirtualGames;
    using NSubstitute;
    using NUnit.Framework;
    using Site.Handlers;
    using Site.Models.Requests;

    [TestFixture]
    public class VirtualGamesResultHandlerTests
    {
        private IVirtualGamesResult result;
        private VirtualGamesResultHandler handler;
        private BrowserHelper browserHelper;

        [SetUp]
        public void SetUp()
        {
            result = Substitute.For<IVirtualGamesResult>();
            browserHelper = Substitute.For<BrowserHelper>();

            handler = new VirtualGamesResultHandler(result, browserHelper);
        }


        [Test]
        public void VirtualGamesResultQuery_Always_CallGetResult()
        {
            // Arrange


            // Act
            handler.Handle(new VirtualGamesResultQuery());

            // Assert
            result.Received().GetResult(Arg.Any<string>(), Arg.Any<string>());
        }


        [Test]
        public void VirtualGamesResultQuery_IsMobile_CallGetResultWithM()
        {
            // Arrange
            browserHelper.IsMobile().Returns(true);

            // Act
            handler.Handle(new VirtualGamesResultQuery());

            // Assert
            result.Received().GetResult(Arg.Is<string>(i => i == "m"), Arg.Any<string>());
        }

        [Test]
        public void VirtualGamesResultQuery_IsTablet_CallGetResultWithT()
        {
            // Arrange            
            browserHelper.IsTablet().Returns(true);

            // Act
            handler.Handle(new VirtualGamesResultQuery());

            // Assert
            result.Received().GetResult(Arg.Is<string>(i => i == "t"), Arg.Any<string>());
        }

        [Test]
        public void VirtualGamesResultQuery_IsDesktop_CallGetResultWithD()
        {
            // Arrange            
            browserHelper.IsMobile().Returns(false);
            browserHelper.IsTablet().Returns(false);

            // Act
            handler.Handle(new VirtualGamesResultQuery());

            // Assert
            result.Received().GetResult(Arg.Is<string>(i => i == "d"), Arg.Any<string>());
        }

        [Test]
        public void VirtualGamesDetailResultQuery_Always_CallGetResult()
        {
            // Arrange


            // Act
            handler.Handle(new VirtualGamesDetailResultQuery());

            // Assert
            result.Received().GetDetailResult(Arg.Any<string>(), Arg.Any<string>(), Arg.Any<string>());
        }


        [Test]
        public void VirtualGamesDetailResultQuery_IsMobile_CallGetResultWithM()
        {
            // Arrange
            browserHelper.IsMobile().Returns(true);

            // Act
            handler.Handle(new VirtualGamesDetailResultQuery());

            // Assert
            result.Received().GetDetailResult(Arg.Any<string>(), Arg.Is<string>(i => i == "m"), Arg.Any<string>());
        }

        [Test]
        public void VirtualGamesDetailResultQuery_IsTablet_CallGetResultWithT()
        {
            // Arrange            
            browserHelper.IsTablet().Returns(true);

            // Act
            handler.Handle(new VirtualGamesDetailResultQuery());

            // Assert
            result.Received().GetDetailResult(Arg.Any<string>(), Arg.Is<string>(i => i == "t"), Arg.Any<string>());
        }

        [Test]
        public void VirtualGamesDetailResultQuery_IsDesktop_CallGetResultWithD()
        {
            // Arrange            
            browserHelper.IsMobile().Returns(false);
            browserHelper.IsTablet().Returns(false);

            // Act
            handler.Handle(new VirtualGamesDetailResultQuery());

            // Assert
            result.Received().GetDetailResult(Arg.Any<string>(), Arg.Is<string>(i => i == "d"), Arg.Any<string>());
        }
    }
}
