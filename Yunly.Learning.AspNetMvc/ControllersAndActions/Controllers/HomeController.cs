using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.AspNetCore.Mvc;
using ControllersAndActions.Infrastructure;

namespace ControllersAndActions.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View("SimpleForm");
        }



        public IActionResult ReceiveForm(string name, string city)
        {

            return View("Result", $"{name} always lives in {city}");
        }


        /*
    [HttpPost]
    public RedirectToActionResult ReceiveForm(string name, string city)=> RedirectToAction(nameof(Data));
    public ViewResult Data() => View("Result");
    */


        /*
        [HttpPost]
        public RedirectToActionResult ReceiveForm(string name, string city)
        {
            TempData["name"] = name;
            TempData["city"] = city;
            return RedirectToAction(nameof(Data));
        }
        public ViewResult Data()
        {
            string name = TempData["name"] as string;
            string city = TempData["city"] as string;
            return View("Result", $"{name} lives in {city}");
        }
        */

        /*
        public void ReceiveForm(string name, string city)
        {
            Response.StatusCode = 200;
            Response.ContentType = "text/html";
            byte[] content = Encoding.ASCII.GetBytes($"<html><body>{name} lives in {city}</body>");
            Response.Body.WriteAsync(content, 0, content.Length);
        }
        */
        //public IActionResult ReceiveForm(string name, string city)
        //=> new CustomHtmlResult { Content = $"{name} always lives in my {city}" };
    }
}