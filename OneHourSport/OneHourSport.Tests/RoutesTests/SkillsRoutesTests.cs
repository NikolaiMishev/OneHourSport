namespace OneHourSport.Tests.RoutesTests
{
    using System.Web.Routing;

    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Web;
    using Web.Controllers;
    using MvcRouteTester;

    [TestClass]
    public class SkillsRoutesTests
    {
        [TestMethod]
        public void TestRouteGetSkillsByUserName()
        {
            var routeCollection = new RouteCollection();
            RouteConfig.RegisterRoutes(routeCollection);
            var urlForTest = "/Skills/GetUserSkills?username=Nikolai";

            routeCollection
                .ShouldMap(urlForTest)
                .To<SkillsController>(x => x.GetUserSkills("Nikolai"));
        }
    }
}
