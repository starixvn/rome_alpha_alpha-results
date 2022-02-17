namespace Alpha.Results.Site.Tests.Models.Views
{
    using Alpha.Results.Site.Models.Requests;
    using NSubstitute;
    using NUnit.Framework;
    using Sunplus.Agent.Model.Entities;

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