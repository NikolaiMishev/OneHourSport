namespace OneHourSport.Web.Controllers
{
    using Services.Contracts;
    using System;
    using System.Web.Mvc;

    public class PictureController : Controller
    {
        private IPictureService pictures;

        public PictureController(IPictureService images) : base()
        {
            this.pictures = images;
        }

        public ActionResult GetImage(int id)
        {
            var imageData = this.pictures.GetById(id).Content;
            return File(imageData, "image/jpg");
        }
    }
}