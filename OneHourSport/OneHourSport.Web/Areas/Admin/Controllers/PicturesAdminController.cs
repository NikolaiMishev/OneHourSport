﻿namespace OneHourSport.Web.Areas.Admin.Controllers
{
    using System.Data;
    using System.Linq;
    using System.Web.Mvc;
    using Kendo.Mvc.Extensions;
    using Kendo.Mvc.UI;
    using OneHourSport.Models;
    using Data.Repositories;
    using Web.Models.Picture;
    using Infrastructure;

    [Authorize(Roles = "admin")]
    public class PicturesAdminController : Controller
    {
        private IRepository<Picture> pictures;

        public PicturesAdminController(IRepository<Picture> pictures)
        {
            this.pictures = pictures;
        }

        public ActionResult AdminPictures()
        {
            return View();
        }

        public ActionResult Pictures_Read([DataSourceRequest]DataSourceRequest request)
        {
            var result = this.pictures
               .All()
               .To<PictureViewModel>()
               .ToList()
               .ToDataSourceResult(request);

            return Json(result);
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Pictures_Destroy([DataSourceRequest]DataSourceRequest request, PictureViewModel picture)
        {
            var pic = this.pictures.AllWithDeleted().Where(x => x.Id == picture.PictureId).FirstOrDefault();

            this.pictures.HardDelete(pic);
            this.pictures.SaveChanges();

            return Json(new[] { picture }.ToDataSourceResult(request, ModelState));
        }

        protected override void Dispose(bool disposing)
        {
            this.pictures.Dispose();
            base.Dispose(disposing);
        }
    }
}
