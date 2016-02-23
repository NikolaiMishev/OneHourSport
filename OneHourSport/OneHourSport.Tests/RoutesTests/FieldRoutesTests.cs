namespace OneHourSport.Tests.RoutesTests
{
    using System.Web.Routing;
    using MvcRouteTester;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Web.Controllers;
    using Web;

    [TestClass]
    public class FieldRoutesTests
    {
        [TestMethod]
        public void TestRouteById()
        {
            var routeCollection = new RouteCollection();
            RouteConfig.RegisterRoutes(routeCollection);
            var urlForTest = "/Field/FieldDetails/1?all=False";

            routeCollection
                .ShouldMap(urlForTest)
                .To<FieldController>(x => x.FieldDetails(1, false));
        }

        [TestMethod]
        public void TestRouteByInvalidId()
        {
            var routeCollection = new RouteCollection();
            RouteConfig.RegisterRoutes(routeCollection);
            var urlForTest = "/Field/FieldDetails/0?all=False";

            routeCollection
                .ShouldMap(urlForTest)
                .To<FieldController>(x => x.FieldDetails(0, false));
        }

        [TestMethod]
        public void TestRouteByShowingAll()
        {
            var routeCollection = new RouteCollection();
            RouteConfig.RegisterRoutes(routeCollection);
            var urlForTest = "/Field/FieldDetails/1?all=True";

            routeCollection
                .ShouldMap(urlForTest)
                .To<FieldController>(x => x.FieldDetails(1, true));
        }
    }
}
