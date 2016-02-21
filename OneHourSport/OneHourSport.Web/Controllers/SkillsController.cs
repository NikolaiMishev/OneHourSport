namespace OneHourSport.Web.Controllers
{
    using System.Net;
    using System.Linq;
    using System.Web.Mvc;

    using AutoMapper.QueryableExtensions;
    using Common.Constants;
    using Models.Account.UserSkill;
    using Services.Contracts;
    
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
            if (!Request.IsAjaxRequest())
            {
                Response.StatusCode = (int)HttpStatusCode.Forbidden;
                return this.Content("This action can be invoke only by AJAX call");
            }

            this.skillService.Create(category, this.User.Identity.Name, resieverUsername);

            Response.StatusCode = (int)HttpStatusCode.Created;
            return this.Content("OK");
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