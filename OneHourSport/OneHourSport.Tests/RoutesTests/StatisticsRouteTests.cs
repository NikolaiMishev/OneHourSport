namespace OneHourSport.Tests.RoutesTests
{
    using System.Web.Routing;

    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Web;
    using Web.Controllers;
    using MvcRouteTester;

    [TestClass]
    public class StatisticsRouteTests
    {
        [TestMethod]
        public void TestRouteGetStatistics()
        {
            var routeCollection = new RouteCollection();
            RouteConfig.RegisterRoutes(routeCollection);
            var urlForTest = "/Statistics/Statistics";

            routeCollection
                .ShouldMap(urlForTest)
                .To<StatisticsController>(x => x.GetStatistics());
        }
    }
}
