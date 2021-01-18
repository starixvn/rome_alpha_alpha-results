namespace Alpha.Results.Site.Tests.Models.Views
{
    using NUnit.Framework;
    using Site.Models.Views;

    [TestFixture]
    public class ThirdPartyProductViewModelTests
    {

        [Test]
        public void Title_Always_CanSetValue()
        {
            // Arrange
            var model = new ThirdPartyProductViewModel
            {
                Title = "title",
                Result = "Result",
                IsSuccess = true
            };

            // Act


            // Assert
            Assert.AreEqual("title", model.Title);
            Assert.AreEqual("Result", model.Result);
            Assert.IsTrue(model.IsSuccess);
        }
    }
}