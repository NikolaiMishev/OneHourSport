﻿namespace OneHourSport.Web.Areas.Admin.Controllers
{
    using System.Data.Entity;
    using System.Linq;
    using System.Web.Mvc;

    using Kendo.Mvc.Extensions;
    using Kendo.Mvc.UI;
    using AutoMapper.QueryableExtensions;

    using OneHourSport.Models;
    using Data.Repositories;
    using Models.Field;

    [Authorize(Roles = "admin")]
    public class FieldAdminController : Controller
    {
        private IRepository<SportField> fields;

        public FieldAdminController(IRepository<SportField> fields)
        {
            this.fields = fields;
        }

        public ActionResult FieldsAdmin()
        {
            return View();
        }

        public ActionResult SportFields_Read([DataSourceRequest]DataSourceRequest request)
        {
            var result = this.fields
                .All()
                .ProjectTo<FieldViewModel>()
                .ToList()
                .ToDataSourceResult(request);
            
            return Json(result);
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult SportFields_Update([DataSourceRequest]DataSourceRequest request, FieldInputModel sportField)
        {
            if (ModelState.IsValid)
            {
                var entity = this.fields.GetById(sportField.Id);
                entity.Name = sportField.Name;
                entity.Description = sportField.Description;
                entity.isCovered = sportField.isCovered;
                entity.isAprooved = sportField.isAprooved;
                entity.Category = sportField.Category;
                entity.PricePerHour = sportField.PricePerHour;



                this.fields.SaveChanges();
            }
            var postToDisplay = this.fields.All()
                           .ProjectTo<FieldViewModel>()
                           .FirstOrDefault(x => x.Id == sportField.Id);

            return Json(new[] { sportField }.ToDataSourceResult(request, ModelState));
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult SportFields_Destroy([DataSourceRequest]DataSourceRequest request, SportField sportField)
        {
            this.fields.Delete(sportField.Id);
            this.fields.SaveChanges();
            
            return Json(new[] { sportField }.ToDataSourceResult(request, ModelState));
        }

        protected override void Dispose(bool disposing)
        {
            this.fields.Dispose();
            base.Dispose(disposing);
        }
    }
}
