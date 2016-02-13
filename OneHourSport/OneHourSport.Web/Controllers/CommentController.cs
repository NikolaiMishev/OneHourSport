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

        [HttpGet]
        public ActionResult AddComment()
        {
            return this.View();
        }



        [HttpGet]
        public ActionResult AllForField(int id)
        {
            // TODO finish
            var result =  this.commentService.GetAllByFieldId(id);

            return this.View();
        }
    }
}