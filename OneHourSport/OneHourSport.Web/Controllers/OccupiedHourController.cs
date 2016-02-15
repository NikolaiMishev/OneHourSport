namespace OneHourSport.Web.Controllers
{
    using OneHourSport.Models;
    using Services.Contracts;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Web.Mvc;

    public class OccupiedHourController : Controller
    {
        private IOccupiedHourService hourService;

        public OccupiedHourController(IOccupiedHourService hourService)
        {
            this.hourService = hourService;
        }

        [HttpPost]
        public ActionResult CreateOccupiedHour(DateTime date, int hourFrom, int fieldId, string username)
        {
            //TODO make it onl for ajax
            this.hourService.Create(date, hourFrom, username, fieldId);

            return this.Content("OK");
        }
    }
}