namespace OneHourSport.Web.Areas.Admin.Controllers
{
    using System;
    using System.Linq;
    using System.Web.Mvc;
    using Kendo.Mvc.Extensions;
    using Kendo.Mvc.UI;
    using OneHourSport.Models;
    using OneHourSport.Data;

    [Authorize(Roles = "admin")]
    public class UserController : Controller
    {
        private OneHourSportDbContext db = new OneHourSportDbContext();

        public ActionResult ManageUsers()
        {
            return View();
        }

        public ActionResult Users_Read([DataSourceRequest]DataSourceRequest request)
        {
            IQueryable<User> users = db.Users;
            DataSourceResult result = users.ToDataSourceResult(request, user => new {
                Id = user.Id,
                FirstName = user.FirstName,
                LastName = user.LastName,
                IsComplex = user.IsComplex,
                PhoneNumber = user.PhoneNumber,
                Email = user.Email,
                UserName = user.UserName
            });

            return Json(result);
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Users_Create([DataSourceRequest]DataSourceRequest request, User user)
        {
            if (ModelState.IsValid)
            {
                var entity = new User
                {
                    Id = user.Id,
                    FirstName = user.FirstName,
                    LastName = user.LastName,
                    IsComplex = user.IsComplex,
                    PhoneNumber = user.PhoneNumber,
                    Email = user.Email,
                    EmailConfirmed = user.EmailConfirmed,
                    PasswordHash = user.PasswordHash,
                    SecurityStamp = user.SecurityStamp,
                    PhoneNumberConfirmed = user.PhoneNumberConfirmed,
                    TwoFactorEnabled = user.TwoFactorEnabled,
                    LockoutEndDateUtc = user.LockoutEndDateUtc,
                    LockoutEnabled = user.LockoutEnabled,
                    AccessFailedCount = user.AccessFailedCount,
                    UserName = user.UserName
                };

                db.Users.Add(entity);
                db.SaveChanges();
                user.Id = entity.Id;
            }

            return Json(new[] { user }.ToDataSourceResult(request, ModelState));
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Users_Destroy([DataSourceRequest]DataSourceRequest request, User user)
        {
            if (ModelState.IsValid)
            {
                var entity = new User
                {
                    Id = user.Id,
                    FirstName = user.FirstName,
                    LastName = user.LastName,
                    IsComplex = user.IsComplex,
                    PhoneNumber = user.PhoneNumber,
                    Email = user.Email,
                    EmailConfirmed = user.EmailConfirmed,
                    PasswordHash = user.PasswordHash,
                    SecurityStamp = user.SecurityStamp,
                    PhoneNumberConfirmed = user.PhoneNumberConfirmed,
                    TwoFactorEnabled = user.TwoFactorEnabled,
                    LockoutEndDateUtc = user.LockoutEndDateUtc,
                    LockoutEnabled = user.LockoutEnabled,
                    AccessFailedCount = user.AccessFailedCount,
                    UserName = user.UserName
                };

                db.Users.Attach(entity);
                db.Users.Remove(entity);
                db.SaveChanges();
            }

            return Json(new[] { user }.ToDataSourceResult(request, ModelState));
        }
    
        [HttpPost]
        public ActionResult Pdf_Export_Save(string contentType, string base64, string fileName)
        {
            var fileContents = Convert.FromBase64String(base64);

            return File(fileContents, contentType, fileName);
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}
