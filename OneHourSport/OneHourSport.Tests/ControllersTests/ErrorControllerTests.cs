namespace OneHourSport.Tests.ControllersTests
{
    using System.Web.Mvc;
    using System.Web;

    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Moq;
    using Web.Controllers;
    using TestStack.FluentMVCTesting;

    [TestClass]
    public class ErrorControllerTests
    {
        [TestMethod]
        public void ActionNotFoundShoudReturnPageNotFoundView()
        {
            var mockHttpContext = new Mock<HttpContextBase>();
            var response = new Mock<HttpResponseBase>();
            mockHttpContext.SetupGet(x => x.Response).Returns(response.Object);

            var controller = new ErrorController()
            {
                ControllerContext = new ControllerContext()
                {
                    HttpContext = mockHttpContext.Object
                }
            };

            controller.WithCallTo(x => x.NotFound())
                .ShouldRenderView("NotFound");
        }
    }
}
