using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Forum.Controllers
{
    public class HomeController : Controller
    {
        // GET: /serial
        public ActionResult Serial(string letterCase)
        {
            var serial = "NUMBER";
            if (letterCase.ToLower() == "lower")
                return Content(serial.ToLower());

            return new HttpStatusCodeResult(403);
        }

        // GET: /home/index
        public ActionResult Index()
        {
            return View();
        }

        // GET: /home/contact
        [HttpGet]
        public ActionResult Contact()
        {
            ViewBag.Message = "Type your message.";
            return View();
        }
        
        [HttpPost]
        public ActionResult Contact(string message)
        {
            ViewBag.Message = "Thank you for your message.";
            return View();
        }
    }
}