namespace OneHourSport.Web.Controllers
{
    using Common.Constants;
    using Services.Contracts;

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
            var imageData = this.pictures.GetById(id);
          

            if (imageData == null)
            {
                return this.Content("None");
            }

            return File(imageData.Content, GlobalConstants.ImageContentType);
        }
    }
}