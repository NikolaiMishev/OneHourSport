namespace OneHourSport.Tests.RoutesTests
{
    using System.Web.Routing;

    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Web;
    using MvcRouteTester;
    using Web.Controllers;

    [TestClass]
    public class GameRoutesTests
    {
        [TestMethod]
        public void TestRouteGetLastGames()
        {
            var routeCollection = new RouteCollection();
            RouteConfig.RegisterRoutes(routeCollection);
            var urlForTest = "/Games/LastGames?page=1&finished=False&toBePlayed=False";

            routeCollection
                .ShouldMap(urlForTest)
                .To<GamesController>(x => x.GetLastGames(1, false, false));
        }
    }
}
