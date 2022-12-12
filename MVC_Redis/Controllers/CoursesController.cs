using Microsoft.AspNetCore.Mvc;

namespace MVC_Redis.Controllers
{
    public class CoursesController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

		public IActionResult LoadPartial(string view)
		{

			return PartialView("_" + view);
		}
	}
}
