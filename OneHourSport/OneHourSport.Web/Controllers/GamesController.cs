namespace OneHourSport.Web.Controllers
{
    using System.Linq;
    using System.Web.Mvc;

    using Services.Contracts;
    using AutoMapper.QueryableExtensions;
    using Models.Game;
    using PagedList;
    using Common.Constants;
    [Authorize]
    public class GamesController : Controller
    {
        private IGameService games;

        public GamesController(IGameService games)
        {
            this.games = games;
        }

        [HttpGet]
        [ActionName("LastGames")]
        public ActionResult GetLastGames(int page = 1)
        {
            var username = this.User.Identity.Name;

            var result = this.games
                .GetLastGames(username)
                .ProjectTo<GameViewModel>()
                .ToList();

            this.ViewBag.action = "LastGames";

            return this.View(result.ToPagedList(page, GlobalConstants.PageSize));
        }
    }
}