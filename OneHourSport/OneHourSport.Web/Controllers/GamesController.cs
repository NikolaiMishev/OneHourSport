namespace OneHourSport.Web.Controllers
{
    using System;
    using System.Linq;
    using System.Web.Mvc;
    using System.Collections.Generic;

    using Services.Contracts;
    using Models.Game;
    using PagedList;
    using Common.Constants;
    using Infrastructure;

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
        public ActionResult GetLastGames(int page = 1, bool finished = false, bool toBePlayed = false)
        {
            var username = this.User.Identity.Name;
            var result = new List<GameViewModel>();

            if (toBePlayed)
            {
                result = this.games
                    .GetLastGames(username)
                    .To<GameViewModel>()
                    .ToList()
                    .Where(x => x.Date.Date > DateTime.Now.Date || (x.Date.Date == DateTime.Now.Date && DateTime.Now.Hour < x.HourFrom))
                    .ToList();
            }
            else if (finished)
            {
                result = this.games
                    .GetLastGames(username)
                    .To<GameViewModel>()
                    .ToList()
                    .Where(x => x.Date.Date < DateTime.Now.Date || (x.Date.Date == DateTime.Now.Date && DateTime.Now.Hour > x.HourFrom))
                    .ToList();
            }
            else
            {
                result = this.games
                .GetLastGames(username)
               .To<GameViewModel>()
               .ToList();
            }
            
            this.ViewBag.finished = finished;
            this.ViewBag.toBePlayed = toBePlayed;
            this.ViewBag.action = "LastGames";

            return this.View(result.ToPagedList(page, GlobalConstants.PageSize));
        }
    }
}