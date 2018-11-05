using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

using UrlsAndRoutes.Models;

namespace UrlsAndRoutes.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View("Result", new Result { Controller = nameof(HomeController), Action = nameof(Index) });
        }

        public IActionResult CustomVariable(string id, string color)
        {
            Result r = new Result { Controller = nameof(HomeController), Action = nameof(CustomVariable) };

            r.Data["id"] = id;
            r.Data["color"] = color;
            return View("Result", r);
        }
    }
}