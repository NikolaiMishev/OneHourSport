namespace OneHourSport.Web.Controllers
{
    using Services.Contracts;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Web.Mvc;
    using AutoMapper.QueryableExtensions;

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
                .ProjectTo<OneHourSport.Web.Models.Game.GameViewModel>()
                .ToList();

            return this.View(result);
        }
    }
}