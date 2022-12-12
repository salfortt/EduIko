using Microsoft.AspNetCore.Mvc;

namespace MVC_Redis.Controllers
{
	public class StudentController : Controller
	{
		public IActionResult Index()
		{
			return View();
		}

		public IActionResult Profile()
		{
			return View();
		}

        public IActionResult LoadPartial(string view)
        {

            return PartialView("_" + view);
        }
    }
}
