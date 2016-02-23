namespace OneHourSport.Web.Controllers
{
    using System.Web.Mvc;

    public class ErrorController : Controller
    {
        public ViewResult Index()
        {
            return this.View("Error");
        }

        public ViewResult NotFound()
        {
            this.Response.StatusCode = 404;
            return this.View();
        }
    }
}