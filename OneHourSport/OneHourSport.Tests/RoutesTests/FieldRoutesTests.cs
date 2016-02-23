namespace OneHourSport.Tests.RoutesTests
{
    using System.Web.Routing;

    using MvcRouteTester;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Web.Controllers;
    using Web;

    using Common.Constants;

    [TestClass]
    public class FieldRoutesTests
    {
        [TestMethod]
        public void TestRouteFieldDetailsById()
        {
            var routeCollection = new RouteCollection();
            RouteConfig.RegisterRoutes(routeCollection);
            var urlForTest = "/Field/FieldDetails/1?all=False";

            routeCollection
                .ShouldMap(urlForTest)
                .To<FieldController>(x => x.FieldDetails(1, false));
        }

        [TestMethod]
        public void TestRouteFieldDetailsByInvalidId()
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

        [TestMethod]
        public void TestRouteListAllByCategory()
        {
            var routeCollection = new RouteCollection();
            RouteConfig.RegisterRoutes(routeCollection);
            var urlForTest = "/Field/ListFieldsByCategory/FootBall?page=1";

            routeCollection
                .ShouldMap(urlForTest)
                .To<FieldController>(x => x.ListFieldsByCategory(SportCategory.FootBall, 1));
        }

        [TestMethod]
        public void TestRouteEditField()
        {
            var routeCollection = new RouteCollection();
            RouteConfig.RegisterRoutes(routeCollection);
            var urlForTest = "/Field/EditField?fieldId=1";

            routeCollection
                .ShouldMap(urlForTest)
                .To<FieldController>(x => x.EditField(1));
        }

        [TestMethod]
        public void TestRouteDestryField()
        {
            var routeCollection = new RouteCollection();
            RouteConfig.RegisterRoutes(routeCollection);
            var urlForTest = "/Field/Destroy?fieldId=1";

            routeCollection
                .ShouldMap(urlForTest)
                .To<FieldController>(x => x.Destroy(1));
        }

        [TestMethod]
        public void TestRouteCreateFieldByComplexId()
        {
            var routeCollection = new RouteCollection();
            RouteConfig.RegisterRoutes(routeCollection);
            var urlForTest = "/Field/Create?complexId=1";

            routeCollection
                .ShouldMap(urlForTest)
                .To<FieldController>(x => x.Create(1));
        }
    }
}
