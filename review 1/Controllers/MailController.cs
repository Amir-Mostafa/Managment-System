using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using review_1.BL.helper;
using Microsoft.AspNetCore.Authorization;

namespace review_1.Controllers
{
    [Authorize]
    public class MailController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult sendMail()
        {
            return View();
        }
        [HttpPost]
        public IActionResult sendMail(string title,string body)
        {
            ViewData["msg"] = Mail.SendMail(title, body);
            return RedirectToAction("index");
            
        }
    }
}
