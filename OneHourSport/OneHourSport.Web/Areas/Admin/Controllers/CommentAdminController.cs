namespace OneHourSport.Web.Areas.Admin.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Data.Entity;
    using System.Linq;
    using System.Net;
    using System.Web;
    using System.Web.Mvc;
    using Kendo.Mvc.Extensions;
    using Kendo.Mvc.UI;
    using OneHourSport.Models;
    using Data.Repositories;
    using Models.Comment;
    using AutoMapper.QueryableExtensions;
    [Authorize(Roles = "admin")]
    public class CommentAdminController : Controller
    {
        private IRepository<Comment> comments;
        
        public CommentAdminController(IRepository<Comment> comments)
        {
            this.comments = comments;
        }

        public ActionResult AdminComments()
        {
            return View();
        }

        public ActionResult Comments_Read([DataSourceRequest]DataSourceRequest request)
        {
            var result = this.comments
                  .All()
                  .ProjectTo<CommentViewModel>()
                  .ToList()
                  .ToDataSourceResult(request);

            return Json(result);
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Comments_Update([DataSourceRequest]DataSourceRequest request, CommentInputModel comment)
        {
            if (ModelState.IsValid)
            {
                var entity = this.comments.GetById(comment.Id);
                entity.Text = comment.Text;
                
                this.comments.SaveChanges();
            }
            var postToDisplay = this.comments.All()
                           .ProjectTo<CommentViewModel>()
                           .FirstOrDefault(x => x.Id == comment.Id);

            return Json(new[] { comment }.ToDataSourceResult(request, ModelState));
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Comments_Destroy([DataSourceRequest]DataSourceRequest request, Comment comment)
        {
            var comentDb = this.comments.All().Where(x => x.Id == comment.Id).FirstOrDefault();

            this.comments.Delete(comentDb);
            this.comments.SaveChanges();

            return Json(new[] { comment }.ToDataSourceResult(request, ModelState));
        }

        protected override void Dispose(bool disposing)
        {
            this.comments.Dispose();
            base.Dispose(disposing);
        }
    }
}
