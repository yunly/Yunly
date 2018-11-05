using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SportsStore.Models;
using Microsoft.AspNetCore.Authorization;

namespace SportsStore.Controllers
{
    [Authorize]
    public class AdminController : Controller
    {
        private IProductRepository repository;

        public AdminController(IProductRepository repo)
        {
            repository = repo;
        }

        public IActionResult Index() => View(repository.Products);


        public ViewResult Edit(int productId) => View(repository.Products.FirstOrDefault(p => p.ProductID == productId));

        [HttpPost]
        public IActionResult Edit(Product product)
        {
            if (ModelState.IsValid)
            {
                repository.SaveProduct(product);

                ///temp data feature, which is part of the ASP.NET Core session state feature.
                ///This is a key / value dictionary similar to the session data and view bag features I used previously.
                ///The key difference from session data is that temp data persists until it is read.
                ///I cannot use ViewBag in this situation because ViewBag passes data between the controller and view and it cannot hold data for longer than the current HTTP request.
                ///When an edit succeeds, the browser is redirected to a new URL, so the ViewBag data is lost.
                ///I could use the session data feature, but then the  message would be persistent until I explicitly removed it, which I would rather not have to do.
                ///
                ///So, the temp data feature is the perfect fit. 
                ///The data is restricted to a single user’s session (so that users do not see each other’s TempData) and will persist long enough for me to read it.
                ///I will read the data in the view rendered by the action method to which I have redirected the user, which I define in the next section.
                TempData["message"] = $"{product.Name} has been saved";

                return RedirectToAction("Index");
            }
            else
            {
                // there is something wrong with the data values
                return View(product);
            }
        }

        public ViewResult Create() => View("Edit", new Product());

        [HttpPost]
        public IActionResult Delete(int productId)
        {

            var deletedProduct = repository.DeleteProduct(productId);

            if (deletedProduct != null)
                TempData["message"] = $"{deletedProduct.Name} was deleted";

            return RedirectToAction("Index");

        }
    }
}