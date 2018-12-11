using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;

namespace ControllersAndActions.Controllers
{
    public class ExampleController : Controller
    {

        //public IActionResult Index() => View(DateTime.Now);

        //public IActionResult Index() => Json(new[] { "Alice", "Bob", "Joe" });

        //public IActionResult Index() => Content("[\"Alice\",\"Bob\",\"Joe\"]", "application/json");

        //public IActionResult Index() => Ok(new string[] { "Alice", "Bob", "Joe" });

        //public IActionResult Index() => File("/lib/bootstrap/css/bootstrap.css", "text/css");

        public IActionResult Index() => StatusCode(StatusCodes.Status403Forbidden);

        

        public IActionResult Result() => View((object)"Hello World");

        public IActionResult ViewBagExample()
        {
            ViewBag.Message = "Hello";
            ViewBag.Date = DateTime.Now;

            return View();
        }

        public IActionResult Redirect() => Redirect("/Example/Index");

        public IActionResult Redirect1() =>RedirectPermanent("/Example/Index");

        public IActionResult Redirect2() => RedirectToRoute("Route", new { Controller="Example", Action="Index", ID="10" });

        public IActionResult Redirect3() => RedirectToAction("Index", "Home");


        
    }
}