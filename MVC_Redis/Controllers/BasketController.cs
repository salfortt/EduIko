using Microsoft.AspNetCore.Mvc;

namespace MVC_Redis.Controllers
{
	public class BasketController : Controller
	{
		public IActionResult Index()
		{
			return View();
		}

		
	}
}
