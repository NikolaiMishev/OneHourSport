namespace OneHourSport.Web.Controllers
{
    using Models.Field;
    using OneHourSport.Models;
    using Services.Contracts;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity.Validation;
    using System.IO;
    using System.Linq;
    using System.Web;
    using System.Web.Mvc;

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
        public ActionResult FieldDetails(int id)
        {
            return this.View();
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
            var dbImages = new List<Picture>();
            foreach (var item in model.ProfilePictures)
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

            modelAsEntity.Pictures = dbImages;
            complex.Fields.Add(modelAsEntity);
            try
            {
                this.complexService.Update(complex);

            }
            catch (DbEntityValidationException ex)
            {
                var errorMessages = ex.EntityValidationErrors
                   .SelectMany(x => x.ValidationErrors)
                   .Select(x => x.ErrorMessage);
                
                var fullErrorMessage = string.Join("; ", errorMessages);

                var exceptionMessage = string.Concat(ex.Message, " The validation errors are: ", fullErrorMessage);

                throw new DbEntityValidationException(exceptionMessage, ex.EntityValidationErrors);
            }

            var fieldId = this.fieldService
                .GetAll()
                .Where(x => x.SportComplexId == complex.Id)
                .FirstOrDefault()
                .Id;

            return RedirectToAction("FieldDetails", new { id = fieldId });
        }
    }
}