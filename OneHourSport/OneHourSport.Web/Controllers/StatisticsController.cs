namespace OneHourSport.Web.Controllers
{
    using System;
    using System.Web.Mvc;

    using Models.Statistic;
    using Services.Contracts;

    [Authorize(Roles = "complex")]
    public class StatisticsController : Controller
    {
        private IStatisticService statisticService;

        public StatisticsController(IStatisticService statisticService)
        {
            this.statisticService = statisticService;
        }

        [HttpGet]
        [ActionName("Statistics")]
        public ActionResult GetStatistics()
        {
            var newStats = this.statisticService
                .GetYearlyStatistics(DateTime.Now.Year, this.User.Identity.Name);
            var oldStats = this.statisticService
                .GetYearlyStatistics(DateTime.Now.Year - 1, this.User.Identity.Name);

            var model = new StatisticsModel
            {
                NewStats = newStats,
                OldStats = oldStats,
                MaxUserVisits = 100
            };

            return this.View(model);
        }
    }
}