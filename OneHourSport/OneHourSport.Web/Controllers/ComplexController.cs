namespace OneHourSport.Web.Controllers
{
    using Models.Complex;
    using OneHourSport.Models;
    using Services.Contracts;
    using System;
    using System.IO;
    using System.Linq;
    using System.Web.Mvc;
    using AutoMapper.QueryableExtensions;
    using Models.Field;
    [Authorize]
    public class ComplexController : Controller
    {
        private IComplexService complexService;

        private IFieldService fieldService;

        private IUserService userService;


        public ComplexController(IComplexService complexService, IUserService userService, IFieldService fieldService)
        {
            this.complexService = complexService;
            this.fieldService = fieldService;
            this.userService = userService;
        }

        [HttpGet]
        [ActionName("AllComplexes")]
        public ActionResult GetAllComplexes(int page = 1)
        {
            var result = this.complexService
                .GetAllByPage(page)
                .ProjectTo<ComplexDisplayViewModel>()
                .ToList();

            return this.View(result);
        }

        [HttpGet]
        public ActionResult CheckComplex()
        {
            var user = this.userService
            .GetByUsername(this.User.Identity.Name)
            .FirstOrDefault();

            if (user.SportComplex == null)
            {
                return RedirectToAction("Create");
               
            }
            return RedirectToAction("ComplexDetails", new { id = user.SportComplex.Id });
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

            var isMine = this.userService.GetAll().Where(x => x.UserName == this.User.Identity.Name).FirstOrDefault().SportComplex.Id == id;

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

            Picture image = null;
            if (model.ProfilePicture != null)
            {
                using (var memory = new MemoryStream())
                {
                    model.ProfilePicture.InputStream.CopyTo(memory);
                    var content = memory.GetBuffer();

                    image = new Picture
                    {
                        Content = content,
                        FileExtension = model.ProfilePicture.FileName.Split(new[] { '.' }).Last()
                    };
                }
            }
            modelAsDb.Picture = image;
            var currentUser = this.userService.GetByUsername(this.User.Identity.Name).FirstOrDefault();
            var complexId = this.complexService.Create(modelAsDb);

            currentUser.SportComplex = modelAsDb;
            this.userService.UpdateUserComplex(currentUser);

            return this.RedirectToAction("ComplexDetails", new { id = complexId });
        }
    }
}