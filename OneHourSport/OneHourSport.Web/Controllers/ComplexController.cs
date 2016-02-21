namespace OneHourSport.Web.Controllers
{
    using System.IO;
    using System.Linq;
    using System.Web.Mvc;

    using Models.Complex;
    using Models.Field;
    using OneHourSport.Models;
    using Services.Contracts;
    
    using AutoMapper.QueryableExtensions;
    using PagedList;

    using Common.Constants;
    using Helpers;

    [Authorize]
    public class ComplexController : Controller
    {
        private IComplexService complexService;

        private IFieldService fieldService;

        private IUserService userService;

        private ImageConvertor extractor = new ImageConvertor();

        public ComplexController(IComplexService complexService, IUserService userService, IFieldService fieldService)
        {
            this.complexService = complexService;
            this.fieldService = fieldService;
            this.userService = userService;
        }

        [HttpGet]
        public ActionResult EditComplex(int complexId)
        {
            var model = this.complexService
                .GetById(complexId)
                .ProjectTo<ComplexEditViewModel>()
                .FirstOrDefault();

            return this.View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditComplex(ComplexEditViewModel model)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View(model);
            }

            var dbModel = this.complexService.GetById(model.Id).FirstOrDefault();


            Picture image = null;
            if (model.EditPicture != null)
            {
                using (var memory = new MemoryStream())
                {
                    model.EditPicture.InputStream.CopyTo(memory);
                    var content = memory.GetBuffer();

                    image = new Picture
                    {
                        Content = content,
                        FileExtension = model.EditPicture.FileName.Split(new[] { '.' }).Last()
                    };
                }
            }

            dbModel.Picture = image;
            dbModel.Name = model.Name;
            dbModel.Address = model.Address;
            dbModel.Description = model.Description;
            dbModel.WorkHourFrom = model.WorkHourFrom;
            dbModel.WorkHourTo = model.WorkHourTo;
    
            this.complexService.Update(dbModel);


            return RedirectToAction(GlobalConstants.ComplexDetailsActionName, new { id = dbModel.Id });
        }

        [HttpGet]
        [ActionName("AllComplexes")]
        public ActionResult GetAllComplexes(int page = 1)
        {
            var result = this.complexService
                .GetAll()
                .ProjectTo<ComplexDisplayViewModel>()
                .ToList();

            this.ViewBag.action = "AllComplexes";

            return this.View(result.ToPagedList(page, GlobalConstants.PageSize));
        }

        [HttpGet]
        public ActionResult CheckComplex()
        {
            if (!this.User.IsInRole(GlobalConstants.ComplexRole))
            {
                return View("~/Views/Shared/Unauthorized.cshtml");
            }
            var user = this.userService
            .GetByUsername(this.User.Identity.Name)
            .FirstOrDefault();
            
            if (user.SportComplex == null)
            {
                return RedirectToAction("Create");

            }

            return RedirectToAction(GlobalConstants.ComplexDetailsActionName, new { id = user.SportComplex.Id });
        }


        [HttpGet]
        public ActionResult ComplexDetails(int id)
        {
            var result = this.complexService
                .GetById(id)
                .ProjectTo<ComplexDetailsViewModel>()
                .FirstOrDefault();

            var complexFields = this.fieldService
                .GetAll()
                .Where(x => x.SportComplex.Id == id)
                .ProjectTo<FieldDisplayViewModel>()
                .ToList();



            result.MyFields = complexFields;

            var userToDisplay = this.userService.GetAll().Where(x => x.UserName == this.User.Identity.Name).FirstOrDefault();

            var isMine = false;

            if (userToDisplay.IsComplex)
            {
                isMine = userToDisplay.SportComplex.Id == id;
            }

            result.IsMine = isMine;

            foreach (var item in complexFields)
            {
                if (isMine)
                {
                    item.IsMine = true;
                }
            }

            return this.View(result);
        }

        [HttpGet]
        public ActionResult Create()
        {
            if (!this.User.IsInRole(GlobalConstants.ComplexRole))
            {
                return View("~/Views/Shared/Unauthorized.cshtml");
            }

            return this.View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ComplexRequestViewModel model)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View(model);
            }
            var modelAsDb = AutoMapper.Mapper.Map<ComplexRequestViewModel, OneHourSport.Models.SportComplex>(model);
            
            modelAsDb.Picture = this.extractor.ExtractPicture(model.ProfilePicture);

            var currentUser = this.userService.GetByUsername(this.User.Identity.Name).FirstOrDefault();
            var complexId = this.complexService.Create(modelAsDb);

            currentUser.SportComplex = modelAsDb;
            this.userService.UpdateUserComplex(currentUser);

            return this.RedirectToAction(GlobalConstants.ComplexDetailsActionName, new { id = complexId });
        }
    }
}