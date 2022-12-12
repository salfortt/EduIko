using Microsoft.AspNetCore.Mvc;

namespace MVC_Redis.Controllers
{
	public class PaymentController : Controller
	{
		public IActionResult Index()
		{
			return View();
		}

		public IActionResult Invoice()
		{
			return View();
		}
	}
}
