namespace OneHourSport.Web.Controllers
{
    using Common.Constants;
    using Helpers;
    using Infrastructure;
    using Models.Field;
    using OneHourSport.Models;
    using PagedList;
    using Services.Contracts;

    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Web.Mvc;

    [Authorize]
    public class FieldController : Controller
    {
        private IFieldService fieldService;

        private IComplexService complexService;

        private ImageConvertor extractor = new ImageConvertor();

        public FieldController(IFieldService fieldService, IComplexService complexService)
        {
            this.fieldService = fieldService;
            this.complexService = complexService;
        }

        [HttpGet]
        public ActionResult EditField(int fieldId)
        {
            var model = this.fieldService
                .GetById(fieldId)
                .To<FieldEditViewModel>()
                .FirstOrDefault();

            return this.View(model);
        }


        public ActionResult Destroy(int fieldId)
        {
            var field = this.fieldService.GetById(fieldId).FirstOrDefault();
            var complexId = field.SportComplexId;

            this.fieldService.Destroy(field);

            return this.RedirectToAction(GlobalConstants.ComplexDetailsActionName, "Complex", new { id = complexId });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditField(FieldEditViewModel model)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View(model);
            }

            var dbModel = this.fieldService.GetById(model.Id).FirstOrDefault();
            if (model.EditProfilePictures.First() != null)
            {
                dbModel.Pictures.Clear();
                dbModel.Pictures = ExtractFieldPictures(model.EditProfilePictures);
            }
           
            dbModel.isCovered = model.isCovered;
            dbModel.Name = model.Name;
            dbModel.Description = model.Description;
            dbModel.PricePerHour = model.PricePerHour;

            this.fieldService.Update(dbModel);

            return this.RedirectToActionPermanent(GlobalConstants.FieldDetailsActionName, new { id = dbModel.Id });
        }

        [HttpGet]
        [AllowAnonymous]
        [ActionName("ListFieldsByCategory")]
        public ActionResult ListFieldsByCategory(SportCategory category, int page = 1)
        {
            var result = this.fieldService
                .GetAllByCategory(category)
                .To<FieldDisplayViewModel>()
                .ToList();

            this.ViewBag.category = category;
            this.ViewBag.action = "ListFieldsByCategory";


            return this.View(result.ToPagedList(page, GlobalConstants.PageSize));
        }

        [HttpGet]
        public ActionResult FieldDetails(int id, bool all = false)
        {
            var field = this.fieldService
                .GetById(id)
                .To<FieldDetailsViewModel>()
                .FirstOrDefault();

            if (field == null)
            {
                return this.RedirectToAction("NotFound", "Error");
            }
            this.ViewBag.all = all;

            if (all)
            {
                field.Comments = field.Comments.Skip(0).Take(5);
            }

            var canBeRated = field.Ratings.Where(x => x.Creator.UserName == this.User.Identity.Name).FirstOrDefault() == null;

            field.CanBeRatedByUser = canBeRated;

            return this.View(field);
        }

        [HttpGet]
        public ActionResult Create(int complexId)
        {
            this.ViewBag.ComplexId = complexId;
            return this.View();
        }

        [HttpPost]
        public ActionResult Create(int complexId, FieldRequestViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return this.View(model);
            }

            var complex = this.complexService.GetById(complexId).FirstOrDefault();

            var mapper = AutoMapperConfig.Configuration.CreateMapper();

            var modelAsEntity = mapper.Map<SportField>(model);


            modelAsEntity.Pictures = ExtractFieldPictures(model.ProfilePictures);
            complex.Fields.Add(modelAsEntity);


            this.complexService.Update(complex);

            return this.RedirectToActionPermanent(GlobalConstants.FieldDetailsActionName, new { id = modelAsEntity.Id });
        }

        private List<Picture> ExtractFieldPictures(IEnumerable<HttpPostedFileBase> pics)
        {
            var dbImages = new List<Picture>();
            foreach (var picture in pics)
            {
                var image = this.extractor.ExtractPicture(picture);
                dbImages.Add(image);
            }
            return dbImages;
        }
    }
}