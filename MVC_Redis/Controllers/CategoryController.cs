using Microsoft.AspNetCore.Mvc;

namespace MVC_Redis.Controllers
{
    //[Route("api")]
    //[ApiController]
    public class CategoryController : Controller
    {
        private readonly ICategoryService _categoryService;
        private readonly ILogger<CategoryController> _logger;

        public CategoryController(ICategoryService categoryService, ILogger<CategoryController> logger)
        {
            _categoryService = categoryService;
            _logger = logger;
        }
        //[HttpGet("category/getall")]
        //public IActionResult GetAll()
        //{
        //    return Ok(_categoryService.GetAllCategory());
        //}
      
        public IActionResult Index()
        {
            return View();
        }
      
        public IActionResult GetAll()
        {

            var test = _categoryService.GetAllCategory();
            return View();
        }
    }
}
