namespace Alpha.Results.Site.Tests.Handlers
{
    using System;
    using Alpha.Results.Site.Helpers;
    using Alpha.Results.Site.Services;
    using Alpha.Results.Site.Services.Impl;
    using Alpha.Utilities.IP;
    using Fanex.Result.Core.ThirdParty.Models;
    using Fanex.Result.Core.VGaming;
    using Fanex.Result.ThirdParty.Services;
    using NSubstitute;
    using NUnit.Framework;
    using Site.Handlers;
    using Site.Models.Requests;
    using Sunplus.Agent.Model.Entities;

    [TestFixture]
    public class ThirdPartyResultHandlerTests
    {
        private IUserSession userSession;
        private ThirdPartyResultHandler handler;
        private ICacheRefService cacheRefService;
        private IMaxGameResult maxGameService;
        private ISportsLotteryDetailResult sportsLotteryResult;
        private IPPLiveCasinoResult ppLiveCasinoResult;
        private IHabaneroResult habaneroResult;
        private BrowserHelper browserHelper;
        private ICGResult cgResult;
        private IVGamingResult vGamingResultService;
        private IAdvantPlayResult advantPlayResult;
        private IAdvantPlayMiniResult advantPlayMiniResult;
        private IRNGCasinoResult rngCasinoResult;
        private IMacauGamesResult macauGamesResult;
        private ISpadeGamingResult spadeGamingResult;
        private IRNGWarResult rngWarResult;
        private IIONCasinoResult ionCasinoResult;
        private IPGSoftResult pgSoftResult;
        private IJokerResult jokerResult;
        private IHappy5LinkedGamesResult linkedGamesResult;
        private IBGResult bgResult;
        private ICardClubResult cardClubResult;
        private IPPResult ppResult;
        private IBBINResult bbinResult;
        private IGDGResult gdgResult;
        private IFGGResult fggResult;
        private IMGResult mgResult;
        private IJiliResult jiliResult;
        private IPService ipService;
        private IVirtualGamesDetailResult virtualGamesDetailResult;
        private ISEALResult sealResult;
        private ProductResultServiceFactory serviceFactory;
        private IPHelper ipHelper;

        [SetUp]
        public void SetUp()
        {
            ipService = Substitute.For<IPService>();
            userSession = Substitute.For<IUserSession>();
            browserHelper = Substitute.For<BrowserHelper>();
            cacheRefService = Substitute.For<ICacheRefService>();
            maxGameService = Substitute.For<IMaxGameResult>();
            sportsLotteryResult = Substitute.For<ISportsLotteryDetailResult>();
            ppLiveCasinoResult = Substitute.For<IPPLiveCasinoResult>();
            habaneroResult = Substitute.For<IHabaneroResult>();
            cgResult = Substitute.For<ICGResult>();
            vGamingResultService = Substitute.For<IVGamingResult>();
            advantPlayResult = Substitute.For<IAdvantPlayResult>();
            advantPlayMiniResult = Substitute.For<IAdvantPlayMiniResult>();
            rngCasinoResult = Substitute.For<IRNGCasinoResult>();
            macauGamesResult = Substitute.For<IMacauGamesResult>();
            spadeGamingResult = Substitute.For<ISpadeGamingResult>();
            rngWarResult = Substitute.For<IRNGWarResult>();
            ionCasinoResult = Substitute.For<IIONCasinoResult>();
            pgSoftResult = Substitute.For<IPGSoftResult>();
            jokerResult = Substitute.For<IJokerResult>();
            linkedGamesResult = Substitute.For<IHappy5LinkedGamesResult>();
            bgResult = Substitute.For<IBGResult>();
            cardClubResult = Substitute.For<ICardClubResult>();
            ppResult = Substitute.For<IPPResult>();
            bbinResult = Substitute.For<IBBINResult>();
            gdgResult = Substitute.For<IGDGResult>();
            fggResult = Substitute.For<IFGGResult>();
            sealResult = Substitute.For<ISEALResult>();
            mgResult = Substitute.For<IMGResult>();
            jiliResult = Substitute.For<IJiliResult>();
            virtualGamesDetailResult = Substitute.For<IVirtualGamesDetailResult>();
            serviceFactory = Substitute.For<ProductResultServiceFactory>();
            ipHelper = Substitute.For<IPHelper>();
            handler = new ThirdPartyResultHandler(serviceFactory,
                cacheRefService,
                 maxGameService,
                 ppLiveCasinoResult,
                 habaneroResult,
                 cgResult,
                 vGamingResultService,
                 advantPlayResult,
                 advantPlayMiniResult,
                 bbinResult,
                 rngCasinoResult,
                 macauGamesResult,
                 spadeGamingResult,
                 rngWarResult,
                 ionCasinoResult,
                 pgSoftResult,
                 jokerResult,
                 linkedGamesResult,
                 bgResult,
                 cardClubResult,
                 ppResult,
                 gdgResult,
                 sportsLotteryResult,
                 fggResult,                 
                 ipService,
                 virtualGamesDetailResult,
                 sealResult,
                 mgResult,
                 jiliResult,
                 browserHelper,
                 ipHelper);

            cacheRefService.GetProductName(1).Returns("Product1");
            cacheRefService.GetSportName(1).Returns("Sports1");
            cacheRefService.GetBetTypeName(1).Returns("Bettype1");
        }

        [Test]
        public void SportsLotteryDetailResultQuery_Always_CallGetResult()
        {
            // Arrange
            var query = new SportsLotteryDetailResultQuery(userSession)
            {
                ProductId = 1,
                BetType = 1,
                EndTime = DateTime.Today.ToString()
            };
            sportsLotteryResult.GetResultGET(Arg.Any<ResultRequest>()).Returns("Url result");

            // Act
            var act = handler.Handle(query);

            // Assert
            Assert.AreEqual("Product1 Result", act.Title);
            Assert.AreEqual("Url result", act.Result);
        }

        [Test]
        public void PPResultQuery_Always_CallGetResult()
        {
            // Arrange
            var query = new PPResultQuery(userSession)
            {
                ProductId = 1,
                BetType = 1,
                EndTime = DateTime.Today.ToString()
            };
            ppResult.GetResultGET(Arg.Any<ResultRequest>()).Returns("Url result");

            // Act
            var act = handler.Handle(query);

            // Assert
            Assert.AreEqual("Product1 Result", act.Title);
            Assert.AreEqual("Url result", act.Result);
        }

        [Test]
        public void PPLiveCasinoResultQuery_Always_CallGetResult()
        {
            // Arrange
            var query = new PPLiveCasinoResultQuery(userSession)
            {
                ProductId = 1,
                BetType = 1,
                EndTime = DateTime.Today.ToString()
            };
            ppLiveCasinoResult.GetResultGET(Arg.Any<ResultRequest>()).Returns("Url result");

            // Act
            var act = handler.Handle(query);

            // Assert
            Assert.AreEqual("Product1 Result", act.Title);
            Assert.AreEqual("Url result", act.Result);
        }

        [Test]
        public void HabaneroResultQuery_Always_CallGetResult()
        {
            // Arrange
            var query = new HabaneroResultQuery(userSession)
            {
                ProductId = 1,
                BetType = 1,
                EndTime = DateTime.Today.ToString()
            };
            habaneroResult.GetResultGET(Arg.Any<ResultRequest>()).Returns("Url result");

            // Act
            var act = handler.Handle(query);

            // Assert
            Assert.AreEqual("Product1 Result", act.Title);
            Assert.AreEqual("Url result", act.Result);
        }

        [Test]
        public void CGResultQuery_Always_CallGetResult()
        {
            // Arrange
            var query = new CGResultQuery(userSession)
            {
                ProductId = 1,
                BetType = 1,
                EndTime = DateTime.Today.ToString()
            };
            cgResult.GetResultGET(Arg.Any<ResultRequest>()).Returns("Url result");

            // Act
            var act = handler.Handle(query);

            // Assert
            Assert.AreEqual("Product1 Result", act.Title);
            Assert.AreEqual("Url result", act.Result);
        }

        [Test]
        public void AdvantPlayResultQuery_Always_CallGetResult()
        {
            // Arrange
            var query = new AdvantPlayResultQuery(userSession)
            {
                ProductId = 1,
                BetType = 1,
                EndTime = DateTime.Today.ToString()
            };
            advantPlayResult.GetResultGET(Arg.Any<ResultRequest>()).Returns("Url result");

            // Act
            var act = handler.Handle(query);

            // Assert
            Assert.AreEqual("Product1 Result", act.Title);
            Assert.AreEqual("Url result", act.Result);
        }

        [Test]
        public void AdvantPlayMiniResultQuery_Always_CallGetResult()
        {
            // Arrange
            var query = new AdvantPlayMiniResultQuery(userSession)
            {
                ProductId = 1,
                BetType = 1,
                EndTime = DateTime.Today.ToString()
            };
            advantPlayMiniResult.GetResultGET(Arg.Any<ResultRequest>()).Returns("Url result");

            // Act
            var act = handler.Handle(query);

            // Assert
            Assert.AreEqual("Product1 Result", act.Title);
            Assert.AreEqual("Url result", act.Result);
        }

        [Test]
        public void BBINResultQuery_Always_CallGetResult()
        {
            // Arrange
            var query = new BBINResultQuery(userSession)
            {
                ProductId = 1,
                BetType = 1,
                EndTime = DateTime.Today.ToString()
            };
            bbinResult.GetResultGET(Arg.Any<ResultRequest>()).Returns("Url result");

            // Act
            var act = handler.Handle(query);

            // Assert
            Assert.AreEqual("Product1 Result", act.Title);
            Assert.AreEqual("Url result", act.Result);
        }

        [Test]
        public void CardClubResultQuery_Always_CallGetResult()
        {
            // Arrange
            var query = new CardClubResultQuery(userSession)
            {
                ProductId = 1,
                BetType = 1,
                EndTime = DateTime.Today.ToString()
            };
            cardClubResult.GetResultGET(Arg.Any<ResultRequest>()).Returns("Url result");

            // Act
            var act = handler.Handle(query);

            // Assert
            Assert.AreEqual("Product1 Result", act.Title);
            Assert.AreEqual("Url result", act.Result);
        }

        [Test]
        public void SEALResultQuery_Always_CallGetResult()
        {
            // Arrange
            var query = new SEALResultQuery(userSession)
            {
                ProductId = 1,
                BetType = 1,
                EndTime = DateTime.Today.ToString()
            };
            sealResult.GetResultGET(Arg.Any<ResultRequest>()).Returns("Url result");

            // Act
            var act = handler.Handle(query);

            // Assert
            Assert.AreEqual("Product1 Result", act.Title);
            Assert.AreEqual("Url result", act.Result);
        }

        [Test]
        public void BGResultQuery_Always_CallGetResult()
        {
            // Arrange
            var query = new BGResultQuery(userSession)
            {
                ProductId = 1,
                BetType = 1,
                EndTime = DateTime.Today.ToString()
            };
            bgResult.GetResultGET(Arg.Any<ResultRequest>()).Returns("Url result");

            // Act
            var act = handler.Handle(query);

            // Assert
            Assert.AreEqual("Product1 Result", act.Title);
            Assert.AreEqual("Url result", act.Result);
        }

        [Test]
        public void GDGResultQuery_Always_CallGetResult()
        {
            // Arrange
            var query = new GDGResultQuery(userSession)
            {
                ProductId = 1,
                BetType = 1,
                EndTime = DateTime.Today.ToString()
            };
            gdgResult.GetResultGET(Arg.Any<ResultRequest>()).Returns("Url result");

            // Act
            var act = handler.Handle(query);

            // Assert
            Assert.AreEqual("Product1 Result", act.Title);
            Assert.AreEqual("Url result", act.Result);
        }

        [Test]
        public void JokerResultQuery_Always_CallGetResult()
        {
            // Arrange
            var query = new JokerResultQuery(userSession)
            {
                ProductId = 1,
                BetType = 1,
                EndTime = DateTime.Today.ToString()
            };
            jokerResult.GetResultGET(Arg.Any<ResultRequest>()).Returns("Url result");

            // Act
            var act = handler.Handle(query);

            // Assert
            Assert.AreEqual("Product1 Result", act.Title);
            Assert.AreEqual("Url result", act.Result);
        }

        [Test]
        public void PGSoftResultQuery_Always_CallGetResult()
        {
            // Arrange
            var query = new PGSoftResultQuery(userSession)
            {
                ProductId = 1,
                BetType = 1,
                EndTime = DateTime.Today.ToString()
            };
            pgSoftResult.GetResultGET(Arg.Any<ResultRequest>()).Returns("Url result");
            ipHelper.GetClientIP().Returns("172.168.0.0");
            ipService.GetIPInformation(Arg.Any<string>()).Returns(new Utilities.IP.Models.IPInformationModel());
            // Act
            var act = handler.Handle(query);

            // Assert
            Assert.AreEqual("Product1 Result", act.Title);
            Assert.AreEqual("Url result", act.Result);
        }

        [Test]
        public void IONCasinoResultQuery_Always_CallGetResult()
        {
            // Arrange
            var query = new IONCasinoResultQuery(userSession)
            {
                ProductId = 1,
                BetType = 1,
                EndTime = DateTime.Today.ToString()
            };
            ionCasinoResult.GetResultGET(Arg.Any<ResultRequest>()).Returns("Url result");

            // Act
            var act = handler.Handle(query);

            // Assert
            Assert.AreEqual("Product1 Result", act.Title);
            Assert.AreEqual("Url result", act.Result);
        }

        [Test]
        public void RNGWarResultQuery_Always_CallGetResult()
        {
            // Arrange
            var query = new RNGWarResultQuery(userSession)
            {
                ProductId = 1,
                BetType = 1,
                EndTime = DateTime.Today.ToString()
            };
            rngWarResult.GetResultGET(Arg.Any<ResultRequest>()).Returns("Url result");

            // Act
            var act = handler.Handle(query);

            // Assert
            Assert.AreEqual("Product1 Result", act.Title);
            Assert.AreEqual("Url result", act.Result);
        }

        [Test]
        public void SpadeGamingResultQuery_Always_CallGetResult()
        {
            // Arrange
            var query = new SpadeGamingResultQuery(userSession)
            {
                ProductId = 1,
                BetType = 1,
                EndTime = DateTime.Today.ToString()
            };
            spadeGamingResult.GetResultGET(Arg.Any<ResultRequest>()).Returns("Url result");

            // Act
            var act = handler.Handle(query);

            // Assert
            Assert.AreEqual("Product1 Result", act.Title);
            Assert.AreEqual("Url result", act.Result);
        }

        [Test]
        public void MacauGamesResultQuery_Always_CallGetResult()
        {
            // Arrange
            var query = new MacauGamesResultQuery(userSession)
            {
                ProductId = 1,
                BetType = 1,
                EndTime = DateTime.Today.ToString()
            };
            macauGamesResult.GetResultGET(Arg.Any<ResultRequest>()).Returns("Url result");

            // Act
            var act = handler.Handle(query);

            // Assert
            Assert.AreEqual("Product1 Result", act.Title);
            Assert.AreEqual("Url result", act.Result);
        }

        [Test]
        public void MaxGameResultQuery_Always_CallGetResult()
        {
            // Arrange
            var query = new MaxGameResultQuery(userSession)
            {
                ProductId = 1,
                BetType = 1,
                EndTime = DateTime.Today.ToString()
            };
            maxGameService.GetResultGET(Arg.Any<ResultRequest>()).Returns("Url result");

            // Act
            var act = handler.Handle(query);

            // Assert
            Assert.AreEqual("Product1 Result", act.Title);
            Assert.AreEqual("Url result", act.Result);
        }

        [Test]
        public void FGGResultQuery_Always_CallGetResult()
        {
            // Arrange
            var query = new FGGResultQuery(userSession)
            {
                ProductId = 1,
                BetType = 1,
                EndTime = DateTime.Today.ToString()
            };
            fggResult.GetResultGET(Arg.Any<ResultRequest>()).Returns("Url result");

            // Act
            var act = handler.Handle(query);

            // Assert
            Assert.AreEqual("Product1 Result", act.Title);
            Assert.AreEqual("Url result", act.Result);
        }

        [Test]
        public void VirtualGamesDetailResultQuery_Always_CallGetResult()
        {
            // Arrange
            var query = new VirtualGamesDetailResultQuery(userSession)
            {
                ProductId = 1,
                BetType = 1,
                EndTime = DateTime.Today.ToString()
            };
            virtualGamesDetailResult.GetResultGET(Arg.Any<ResultRequest>()).Returns("Url result");

            // Act
            var act = handler.Handle(query);

            // Assert
            Assert.AreEqual("Product1 Result", act.Title);
            Assert.AreEqual("Url result", act.Result);
        }

        [Test]
        public void LinkedGamesResultQuery_Always_CallGetResult()
        {
            // Arrange
            var query = new LinkedGamesResultQuery(userSession)
            {
                SportTypeId = 1,
                BetTypeId = 1,
                EndTime = DateTime.Today.ToString()
            };
            linkedGamesResult.GetResultGET(Arg.Any<ResultRequest>()).Returns("Url result");

            // Act
            var act = handler.Handle(query);

            // Assert
            Assert.AreEqual("Sports1 - Bettype1", act.Title);
            Assert.AreEqual("Url result", act.Result);
        }

        [Test]
        public void VGamingResultQuery_Always_CallGetResult()
        {
            // Arrange
            var query = new VGamingResultQuery(userSession)
            {
                ProductId = 1,
                BetType = 1,
                EndTime = DateTime.Today.ToString()
            };
            vGamingResultService.GetResult(Arg.Any<string>(),
                Arg.Any<string>(),
                Arg.Any<string>(),
                Arg.Any<string>(),
                Arg.Any<int>(),
                Arg.Any<string>(),
                Arg.Any<string>()).Returns("Url result");

            // Act
            var act = handler.Handle(query);

            // Assert
            Assert.AreEqual("Product1 Result", act.Title);
            Assert.AreEqual("Url result", act.Result);
        }

        [Test]
        public void MGResultQuery_Always_CallGetResult()
        {
            // Arrange
            var query = new MGResultQuery(userSession)
            {
                ProductId = 1,
                BetType = 1,
                EndTime = DateTime.Today.ToString()
            };
            mgResult.GetResultGET(Arg.Any<ResultRequest>()).Returns("Url result");

            // Act
            var act = handler.Handle(query);

            // Assert
            Assert.AreEqual("Product1 Result", act.Title);
            Assert.AreEqual("Url result", act.Result);
        }

        [Test]
        public void JiliResultQuery_Always_CallGetResult()
        {
            // Arrange
            var query = new JiliResultQuery(userSession)
            {
                ProductId = 1,
                BetType = 1,
                EndTime = DateTime.Today.ToString()
            };
            mgResult.GetResultGET(Arg.Any<ResultRequest>()).Returns("Url result");

            // Act
            var act = handler.Handle(query);

            // Assert
            Assert.AreEqual("Product1 Result", act.Title);
            Assert.AreEqual("Url result", act.Result);
        }
    }
}
