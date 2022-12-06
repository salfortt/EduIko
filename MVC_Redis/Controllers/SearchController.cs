using Microsoft.AspNetCore.Mvc;

namespace MVC_Redis.Controllers
{
    public class SearchController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
