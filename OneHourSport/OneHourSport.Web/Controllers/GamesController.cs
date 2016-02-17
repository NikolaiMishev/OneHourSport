namespace OneHourSport.Web.Controllers
{
    using System.Linq;
    using System.Web.Mvc;

    using Services.Contracts;
    using AutoMapper.QueryableExtensions;
    using Models.Game;

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
        public ActionResult GetLastGames()
        {
            var username = this.User.Identity.Name;

            var result = this.games
                .GetLastGames(username)
                .ProjectTo<GameViewModel>()
                .ToList();

            return this.View(result);
        }
    }
}