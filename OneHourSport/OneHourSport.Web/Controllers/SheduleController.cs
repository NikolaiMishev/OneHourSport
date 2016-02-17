using OneHourSport.Services.Contracts;
using OneHourSport.Web.Models.Shedule;
using System;
namespace OneHourSport.Web.Controllers
{
    using System.Linq;
    using System.Web.Mvc;

    using AutoMapper.QueryableExtensions;
    using OneHourSport.Web.Models.OccupiedHour;
    using OneHourSport.Common.Constants;

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

            return PartialView(GlobalConstants.SheduleFolderPathPrefix + "_ShedulePartial.cshtml", model);
        }
    }
}