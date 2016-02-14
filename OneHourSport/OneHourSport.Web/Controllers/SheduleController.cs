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
        public ActionResult Shedule(string date, int fieldId)
        {
            DateTime realDate = DateTime.Parse(date);

            var hours = this.sheduleService
                .GetAllHoursByDateAndField(realDate, fieldId)
                .ProjectTo<OccupiedHourViewModel>()
                .ToList();

            var complex = this.complexService.GetByFieldId(fieldId);

            var model = new SheduleViewModel
            {
                Date = realDate,
                OccupiedHours = hours,
                WorkHoursCount = hours.Count()

            };

            return this.View(model);
        }
    }
}