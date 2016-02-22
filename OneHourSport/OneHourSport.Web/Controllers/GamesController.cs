namespace OneHourSport.Web.Controllers
{
    using System.Linq;
    using System.Web.Mvc;
    using System.Collections.Generic;

    using Services.Contracts;
    using AutoMapper.QueryableExtensions;
    using Models.Game;
    using PagedList;
    using Common.Constants;
    using System;

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
                .Where(x => x.Date > DateTime.UtcNow)
                .ProjectTo<GameViewModel>()
                .ToList();
            }
            else if (finished)
            {
               result = this.games
                .GetLastGames(username)
               .Where(x => x.Date < DateTime.UtcNow)
               .ProjectTo<GameViewModel>()
               .ToList();
            }
            else
            {
                result = this.games
                .GetLastGames(username)
               .ProjectTo<GameViewModel>()
               .ToList();
            }
            
            this.ViewBag.finished = finished;
            this.ViewBag.toBePlayed = toBePlayed;
            this.ViewBag.action = "LastGames";

            return this.View(result.ToPagedList(page, GlobalConstants.PageSize));
        }
    }
}