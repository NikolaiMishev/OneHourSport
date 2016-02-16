namespace OneHourSport.Web.Controllers
{
    using Models.HomeTop;
    using OneHourSport.Services.Contracts;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Web.Mvc;

    public class HomeController : Controller
    {
        private IUserService userService;

        private IFieldService fieldService;
        
        private IComplexService complexService;


        public HomeController(IUserService userService, IComplexService complexService, IFieldService fieldService)
        {
            this.userService = userService;
            this.complexService = complexService;
            this.fieldService = fieldService;
        }

        public ActionResult Index()
        {
            var topFields = this.fieldService.GetTopThree().ToList();
            var topComplexes = this.complexService.GetTopThree().ToList();

            var model = new HomeTop
            {
                TopComplexes = topComplexes,
                TopFields = topFields
            };

            return View(model);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}