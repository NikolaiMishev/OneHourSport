﻿namespace OneHourSport.Web.Areas.Admin.Controllers
{
    using System.Data;
    using System.Linq;
    using System.Web.Mvc;
    using Kendo.Mvc.Extensions;
    using Kendo.Mvc.UI;
    using OneHourSport.Models;
    using Data.Repositories;
    using Models.Complex;
    using Infrastructure;

    [Authorize(Roles = "admin")]
    public class ComplexAdminController : Controller
    {
        private IRepository<SportComplex> complexes;

        public ComplexAdminController(IRepository<SportComplex> complexes)
        {
            this.complexes = complexes;
        }

        public ActionResult AdminComplex()
        {
            return View();
        }

        public ActionResult SportComplexes_Read([DataSourceRequest]DataSourceRequest request)
        {
            var result = this.complexes
                 .AllWithDeleted()
                 .To<ComplexViewModel>()
                 .ToList()
                 .ToDataSourceResult(request);

            return Json(result);
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult SportComplexes_Update([DataSourceRequest]DataSourceRequest request, ComplexInputModel sportComplex)
        {
            if (ModelState.IsValid)
            {
                var entity = this.complexes.AllWithDeleted().Where(x => x.OwnerId == sportComplex.OwnerId).FirstOrDefault();
                entity.Name = sportComplex.Name;
                entity.Description = sportComplex.Description;
                entity.WorkHourFrom = sportComplex.WorkHourFrom;
                entity.WorkHourTo = sportComplex.WorkHourTo;
                entity.Address = sportComplex.Address;
                

                this.complexes.SaveChanges();
            }
            var complexToDisplay = this.complexes.AllWithDeleted()
                           .To<ComplexViewModel>()
                           .FirstOrDefault(x => x.OwnerId == sportComplex.OwnerId);

            return Json(new[] { complexToDisplay }.ToDataSourceResult(request, ModelState));
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult SportComplexes_Destroy([DataSourceRequest]DataSourceRequest request, SportComplex sportComplex)
        {
            var complex = this.complexes.AllWithDeleted().Where(x => x.OwnerId == sportComplex.OwnerId).FirstOrDefault();

            this.complexes.Delete(complex);
            this.complexes.SaveChanges();

            return Json(new[] { sportComplex }.ToDataSourceResult(request, ModelState));
        }

        protected override void Dispose(bool disposing)
        {
            this.complexes.Dispose();
            base.Dispose(disposing);
        }
    }
}
