using Entities.Dto.AccountModel;
using Microsoft.AspNetCore.Mvc;

namespace MVC_Redis.Controllers
{
    public class AccountController : Controller
	{
		public IActionResult Index()
		{
			return View();
		}

		[HttpGet]
		public IActionResult Register()
		{
			return View();
		}


		[HttpPost]
		public IActionResult Register(Register register )
        {

            TempData["PhoneNumber"] = register.PhoneNumber;
            return RedirectToAction("SmsConfirmation");
        }

        [HttpGet]
        public IActionResult SmsConfirmation()
        {
            return View(new SmsConfirmation() { PhoneNumber = TempData["PhoneNumber"].ToString() }) ;
        }


        [HttpPost]
        public IActionResult SmsConfirmation(SmsConfirmation smsConfirmation)
        {
            return View();
        }

        [HttpPost]
        public JsonResult IsAlreadySigned(string PhoneNumber)
        {
			//yoksa true
			//varsa false
            return Json(true);

        }
    }
}
