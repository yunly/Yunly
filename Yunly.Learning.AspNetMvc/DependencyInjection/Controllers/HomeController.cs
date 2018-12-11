using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using DependencyInjection.Models;
using DependencyInjection.Infrastructure;

namespace DependencyInjection.Controllers
{
    public class HomeController : Controller
    {
        private IRepository repository;
        private ProductTotalizer totalizer;

        public HomeController(IRepository repo, ProductTotalizer total)
        {
            repository = repo;
            this.totalizer = total;
        }

        //public IRepository Repository { get; set; } = new MemoryRepository();
        //public IRepository Repository { get; } = TypeBroker.Repository;

        //public ViewResult Index() {
        //    ViewBag.HomeController = repository.ToString();
        //    ViewBag.Totalizer = totalizer.Repository.ToString();
        //    return View(repository.Products);
        //}


        public ViewResult Index()
        {
            ViewBag.HomeController = repository.ToString();
            ViewBag.Totalizer = totalizer.Repository.ToString();
            ViewBag.total = totalizer.Total;
            return View(repository.Products);
        }
    }
}