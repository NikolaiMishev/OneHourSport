namespace OneHourSport.Web.Controllers
{
    using System;
    using System.Net;
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
            if (!Request.IsAjaxRequest())
            {
                Response.StatusCode = (int)HttpStatusCode.Forbidden;
                return this.Content("This action can be invoke only by AJAX call");
            }

            this.hourService.Create(date, hourFrom, username, fieldId);

            Response.StatusCode = (int)HttpStatusCode.Created;
            return this.Content("OK");
        }
    }
}