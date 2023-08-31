namespace Alpha.Results.Site.Tests.Controllers
{
    using System;
    using AlphaPlus.User.Models;
    using MediatR;
    using NSubstitute;
    using NUnit.Framework;
    using Site.Controllers;
    using Site.Helpers;
    using Site.Models.Requests;

    [TestFixture]
    public class TableGamesControllerTests
    {
        private IMediator mediator;
        private IUserSession userSession;
        private TableGamesController controller;

        [SetUp]
        public void SetUp()
        {
            mediator = Substitute.For<IMediator>();

            userSession = Substitute.For<IUserSession>();
            userSession.LangKey.Returns("EN");
            userSession.CustId.Returns(1);
            userSession.RoleId.Returns((byte)2);

            UrlHelper.CurrentAppPath = "path";

            controller = new TableGamesController(mediator, userSession);
        }

        [Test]
        public void Index_Always_CallMediatorSendTableGamesResultQuery()
        {
            // Act
            controller.Index();

            // Assert
            mediator.Received().Send(Arg.Is<TableGamesResultQuery>(
                query => query.LanguageKey == userSession.LangKey
                    && query.CustId == userSession.CustId
                    && query.EventDate == DateTime.Today
                    && query.RootUrl == "path"));
        }
    }
}
