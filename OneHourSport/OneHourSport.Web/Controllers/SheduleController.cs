namespace OneHourSport.Web.Controllers
{
    using System;
    using System.Linq;
    using System.Net;
    using System.Web.Mvc;
    
    using OneHourSport.Web.Models.OccupiedHour;
    using OneHourSport.Common.Constants;
    using OneHourSport.Services.Contracts;
    using OneHourSport.Web.Models.Shedule;
    using Infrastructure;

    [Authorize]
    public class SheduleController : Controller
    {
        private ISheduleService sheduleService;

        private IComplexService complexService;

        public SheduleController(ISheduleService sheduleService, IComplexService complexService)
        {
            this.sheduleService = sheduleService;
            this.complexService = complexService;
        }
        
        [HttpGet]
        [ActionName("GetShedule")]
        public ActionResult Shedule(DateTime date, int fieldId)
        {
            if (!Request.IsAjaxRequest())
            {
                Response.StatusCode = (int)HttpStatusCode.Forbidden;
                return this.Content("This action can be invoke only by AJAX call");
            }

            var hours = this.sheduleService
                .GetAllHoursByDateAndField(date, fieldId)
                .To<OccupiedHourViewModel>()
                .ToList();

            var complex = this.complexService.GetByFieldId(fieldId);

            var model = new SheduleViewModel
            {
                Date = date,
                OccupiedHours = hours,
                WorkHoursCount = complex.WorkHourTo - complex.WorkHourFrom,
                WorkHourFrom = complex.WorkHourFrom,
                WorkHourTo = complex.WorkHourTo,
                FieldId = fieldId,
                CurrentUserUsername = this.User.Identity.Name
            };

            return this.PartialView(GlobalConstants.SheduleFolderPathPrefix + "_ShedulePartial.cshtml", model);
        }
    }
}