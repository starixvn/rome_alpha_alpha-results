namespace Alpha.Results.Site.Tests.Models.Views
{
    using AlphaPlus.User.Models;
    using NSubstitute;
    using NUnit.Framework;

    [TestFixture]
    public class Soccer5ResultQueryTests
    {
        private IUserSession userSession;

        [SetUp]
        public void SetUp()
        {
            this.userSession = Substitute.For<IUserSession>();
            userSession.Language.Returns("EN");
        }
    }
}