namespace OneHourSport.Web.Controllers
{
    using System;
    using System.Web.Mvc;

    using Services.Contracts;

    public class OccupiedHourController : Controller
    {
        private IOccupiedHourService hourService;

        public OccupiedHourController(IOccupiedHourService hourService)
        {
            this.hourService = hourService;
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateOccupiedHour(DateTime date, int hourFrom, int fieldId, string username)
        {
            //TODO make it onl for ajax
            this.hourService.Create(date, hourFrom, username, fieldId);

            return this.Content("OK");
        }
    }
}