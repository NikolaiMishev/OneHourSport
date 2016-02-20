namespace OneHourSport.Web.Controllers
{
    using Services.Contracts;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Web.Mvc;

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
            this.ratingService.CreateRating(fieldId, this.User.Identity.Name, value);
            var result = (int)Math.Ceiling((double)this.fieldService.GetById(fieldId).FirstOrDefault().Ratings.Sum(rg => rg.Value) / this.fieldService.GetById(fieldId).FirstOrDefault().Ratings.Count());

            return this.Content(result.ToString());
        }
    }
}