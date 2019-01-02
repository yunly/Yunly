using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using UsingViewComponents.Models;

namespace UsingViewComponents.Controllers
{
    public class HomeController : Controller
    {
        private readonly IProductRepository repository;

        public HomeController(IProductRepository repo)
        {
            repository = repo;
        }

        public IActionResult Index()
        {
            Response.Headers.Add("Refresh", new Microsoft.Extensions.Primitives.StringValues("5"));
            return View(repository.Products);
        }

        public ViewResult Create() => View();

        [HttpPost]
        public IActionResult Create(Product newProduct)
        {
            repository.AddProduct(newProduct);
            return RedirectToAction("Index");
        }
    }
}