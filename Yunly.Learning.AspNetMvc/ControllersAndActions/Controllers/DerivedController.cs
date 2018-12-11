using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace ControllersAndActions.Controllers
{
    public class DerivedController : Controller
    {
        public IActionResult Index()
        {
            return View("Result", $"This is a derived controller.");
        }

        public IActionResult Headers() => View(
           "DictionaryResult",
           Request.Headers.ToDictionary(kvp=>kvp.Key, kvp=>kvp.Value.First())
            );
    }
}