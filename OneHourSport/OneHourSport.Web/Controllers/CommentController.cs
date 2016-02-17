namespace OneHourSport.Web.Controllers
{
    using Services.Contracts;
    using System.Web.Mvc;

    public class CommentController : Controller
    {
        private ICommentService commentService;

        public CommentController(ICommentService commentService)
        {
            this.commentService = commentService;
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(string text, int fieldId)
        {
            var currentUserUserName = this.User.Identity.Name;
            this.commentService.Create(text, currentUserUserName, fieldId);

            return this.RedirectToAction("FieldDetails", "Field", new { id = fieldId });
        }



        [HttpGet]
        public ActionResult AllForField(int id)
        {
            var result =  this.commentService
                .GetAllByFieldId(id);

            return this.View();
        }
    }
}