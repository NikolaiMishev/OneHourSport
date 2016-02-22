namespace OneHourSport.Web.Areas.Admin.Controllers
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
                .AllWithDeleted()
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
                var entity = this.fields.AllWithDeleted().Where(x => x.Id == sportField.Id).FirstOrDefault();
                entity.Name = sportField.Name;
                entity.Description = sportField.Description;
                entity.isCovered = sportField.isCovered;
                entity.isAprooved = sportField.isAprooved;
                entity.Category = sportField.Category;
                entity.PricePerHour = sportField.PricePerHour;



                this.fields.SaveChanges();
            }
            var postToDisplay = this.fields.AllWithDeleted()
                           .ProjectTo<FieldViewModel>()
                           .FirstOrDefault(x => x.Id == sportField.Id);

            return Json(new[] { sportField }.ToDataSourceResult(request, ModelState));
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult SportFields_Destroy([DataSourceRequest]DataSourceRequest request, SportField sportField)
        {
            var field = this.fields.AllWithDeleted().Where(x => x.Id == sportField.Id).FirstOrDefault();

            this.fields.Delete(field);
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
