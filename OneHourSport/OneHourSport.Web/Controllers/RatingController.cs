namespace OneHourSport.Web.Controllers
{
    using System;
    using System.Linq;
    using System.Net;
    using System.Web.Mvc;

    using Services.Contracts;
    
    [Authorize]
    public class RatingController : Controller
    {
        public IRatingService ratingService;

        public IFieldService fieldService;


        public RatingController(IRatingService ratingService, IFieldService fieldService)
        {
            this.ratingService = ratingService;
            this.fieldService = fieldService;
        }

        [HttpPost]
        public ActionResult Rate(int fieldId, int value)
        {
            if (!Request.IsAjaxRequest())
            {
                Response.StatusCode = (int)HttpStatusCode.Forbidden;
                return this.Content("This action can be invoke only by AJAX call");
            }

            this.ratingService.CreateRating(fieldId, this.User.Identity.Name, value);
            var result = (int)Math.Ceiling((double)this.fieldService.GetById(fieldId).FirstOrDefault().Ratings.Sum(rg => rg.Value) / this.fieldService.GetById(fieldId).FirstOrDefault().Ratings.Count());

            Response.StatusCode = (int)HttpStatusCode.Created;
            return this.Content(result.ToString());
        }
    }
}