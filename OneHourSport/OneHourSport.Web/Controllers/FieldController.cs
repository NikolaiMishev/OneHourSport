namespace OneHourSport.Web.Controllers
{
    using AutoMapper.QueryableExtensions;
    using Common.Constants;
    using Models.Field;
    using OneHourSport.Models;
    using PagedList;
    using Services.Contracts;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity.Validation;
    using System.IO;
    using System.Linq;
    using System.Web;
    using System.Web.Mvc;

    [Authorize]
    public class FieldController : Controller
    {
        private IFieldService fieldService;

        private IComplexService complexService;

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
                .ProjectTo<FieldEditViewModel>()
                .FirstOrDefault();

            return this.View(model);
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
            dbModel.Pictures.Clear();
            dbModel.Pictures = ExtractFieldPictures(model.EditProfilePictures);
            dbModel.isCovered = model.isCovered;
            dbModel.Name = model.Name;
            dbModel.Description = model.Description;
            dbModel.PricePerHour = model.PricePerHour;
            
            this.fieldService.Update(dbModel);
            
            return RedirectToAction(GlobalConstants.FieldDetailsActionName, new { id = dbModel.Id });
        }

        [HttpGet]
        [ActionName("ListFieldsByCategory")]
        public ActionResult ListFieldsByCategory(SportCategory category, int page = 1)
        {
            var result = this.fieldService
                .GetAllByCategory(category)
                .ProjectTo<FieldDisplayViewModel>()
                .ToList();
            this.ViewBag.category = category;
            return this.View(result.ToPagedList(page, GlobalConstants.PageSize));
        }

        [HttpGet]
        public ActionResult FieldDetails(int id)
        {
            var field = this.fieldService
                .GetById(id)
                .ProjectTo<FieldDetailsViewModel>()
                .FirstOrDefault();

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
            var modelAsEntity = AutoMapper.Mapper.Map<FieldRequestViewModel, OneHourSport.Models.SportField>(model);


            modelAsEntity.Pictures = ExtractFieldPictures(model.ProfilePictures);
            complex.Fields.Add(modelAsEntity);


            this.complexService.Update(complex);

            return RedirectToAction(GlobalConstants.FieldDetailsActionName, new { id = modelAsEntity.Id });
        }

        private List<Picture> ExtractFieldPictures(IEnumerable<HttpPostedFileBase> pics)
        {
            var dbImages = new List<Picture>();
            foreach (var item in pics)
            {
                Picture image = null;
                if (item != null)
                {
                    using (var memory = new MemoryStream())
                    {
                        item.InputStream.CopyTo(memory);
                        var content = memory.GetBuffer();

                        image = new Picture
                        {
                            Content = content,
                            FileExtension = item.FileName.Split(new[] { '.' }).Last()
                        };
                    }
                    dbImages.Add(image);
                }
            }
            return dbImages;
        }
    }
}