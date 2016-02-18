namespace OneHourSport.Web.Controllers
{
    using Models.Account.UserSkill;
    using Services.Contracts;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using AutoMapper.QueryableExtensions;
    using System.Web.Mvc;
    using Common.Constants;

    [Authorize]
    public class SkillsController : Controller
    {
        private ISkillService skillService;

        public SkillsController(ISkillService skillService)
        {
            this.skillService = skillService;
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EndorseSkill(string resieverUsername, SportCategory category)
        {
            this.skillService.Create(category, this.User.Identity.Name, resieverUsername);

            return Content("OK");
        }

        [HttpGet]
        public ActionResult GetUserSkills(string username)
        {
           
            var skills = this.skillService
                .GetByUserName(username)
                .ProjectTo<SkillViewModel>()
                .ToList();

            this.ViewBag.username = username;
            return this.PartialView("~/Views/Account/UserSkills/_SkillsPartial.cshtml", skills);
        }
    }
}