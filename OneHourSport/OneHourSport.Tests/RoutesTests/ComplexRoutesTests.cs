namespace OneHourSport.Tests.RoutesTests
{
    using System.Web.Routing;

    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Web;
    using MvcRouteTester;
    using Web.Controllers;

    [TestClass]
    public class ComplexRoutesTests
    {
        //[TestMethod]
        //public void TestRouteEditComplex()
        //{
        //    var routeCollection = new RouteCollection();
        //    RouteConfig.RegisterRoutes(routeCollection);
        //    var urlForTest = "/Complex/EditComplex?complexId=1";

        //    routeCollection
        //        .ShouldMap(urlForTest)
        //        .To<ComplexController>(x => x.EditComplex(1));
        //}

        [TestMethod]
        public void TestRouteGetAllComplexes()
        {
            var routeCollection = new RouteCollection();
            RouteConfig.RegisterRoutes(routeCollection);
            var urlForTest = "/Complex/AllComplexes?page=1";

            routeCollection
                .ShouldMap(urlForTest)
                .To<ComplexController>(x => x.GetAllComplexes(1));
        }

        //[TestMethod]
        //public void TestRouteComplexDetails()
        //{
        //    var routeCollection = new RouteCollection();
        //    RouteConfig.RegisterRoutes(routeCollection);
        //    var urlForTest = "/Complex/ComplexDetails/1";

        //    routeCollection
        //        .ShouldMap(urlForTest)
        //        .To<ComplexController>(x => x.ComplexDetails(1));
        //}

        [TestMethod]
        public void TestRouteComplexCreate()
        {
            var routeCollection = new RouteCollection();
            RouteConfig.RegisterRoutes(routeCollection);
            var urlForTest = "/Complex/Create";

            routeCollection
                .ShouldMap(urlForTest)
                .To<ComplexController>(x => x.Create());
        }
    }
}
