﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Cities.Models;
using Microsoft.AspNetCore.Mvc;

namespace Cities.Controllers
{
    public class HomeController : Controller
    {
        private readonly IRepository repository;

        public HomeController(IRepository repo)
        {
            this.repository = repo;
        }

        public ViewResult Index() => View(repository.Cities);


        public ViewResult Edit()
        {
            ViewBag.CityList = this.repository.Cities.Select(c => c.Country).Distinct();
            return View("Create", repository.Cities.First());
        }

        public ViewResult Create()
        {
            ViewBag.CityList = this.repository.Cities.Select(c => c.Country).Distinct();
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(City city)
        {
            repository.AddCity(city);
            return RedirectToAction("Index");
        }

    }
}