﻿namespace OneHourSport.Web.Areas.Admin.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Data.Entity;
    using System.Linq;
    using System.Net;
    using System.Web;
    using System.Web.Mvc;
    using Kendo.Mvc.Extensions;
    using Kendo.Mvc.UI;
    using OneHourSport.Models;
    using Data.Repositories;
    using Models.Complex;
    using AutoMapper.QueryableExtensions;

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
                 .ProjectTo<ComplexViewModel>()
                 .ToList()
                 .ToDataSourceResult(request);

            return Json(result);
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult SportComplexes_Update([DataSourceRequest]DataSourceRequest request, ComplexInputModel sportComplex)
        {
            if (ModelState.IsValid)
            {
                var entity = this.complexes.AllWithDeleted().Where(x => x.Id == sportComplex.Id).FirstOrDefault();
                entity.Name = sportComplex.Name;
                entity.Description = sportComplex.Description;
                entity.WorkHourFrom = sportComplex.WorkHourFrom;
                entity.WorkHourTo = sportComplex.WorkHourTo;
                entity.Address = sportComplex.Address;
                

                this.complexes.SaveChanges();
            }
            var postToDisplay = this.complexes.AllWithDeleted()
                           .ProjectTo<ComplexViewModel>()
                           .FirstOrDefault(x => x.Id == sportComplex.Id);

            return Json(new[] { sportComplex }.ToDataSourceResult(request, ModelState));
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult SportComplexes_Destroy([DataSourceRequest]DataSourceRequest request, SportComplex sportComplex)
        {
            var complex = this.complexes.AllWithDeleted().Where(x => x.Id == sportComplex.Id).FirstOrDefault();

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
