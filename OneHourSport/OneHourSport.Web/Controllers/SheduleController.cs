using OneHourSport.Services.Contracts;
using OneHourSport.Web.Models.Shedule;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AutoMapper.QueryableExtensions;
using OneHourSport.Web.Models.OccupiedHour;

namespace OneHourSport.Web.Controllers
{
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
        //15.2.2016 г. 2:35:49
        [HttpGet]
        [ActionName("GetShedule")]
        public ActionResult Shedule(DateTime date, int fieldId)
        {
            var hours = this.sheduleService
                .GetAllHoursByDateAndField(date, fieldId)
                .ProjectTo<OccupiedHourViewModel>()
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

            return PartialView("~/Views/Shedule/Shedule.cshtml", model);
        }
    }
}