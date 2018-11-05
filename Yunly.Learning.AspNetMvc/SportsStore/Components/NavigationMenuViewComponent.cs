using Microsoft.AspNetCore.Mvc;
using SportsStore.Models;
using System.Linq;

namespace SportsStore.Components
{
    public class NavigationMenuViewComponent : ViewComponent
    {
        private IProductRepository repository;

        public NavigationMenuViewComponent(IProductRepository repo) => repository = repo;

        /// <summary>
        /// The view component’s Invoke method is called when the component is used in a Razor view, and the
        /// result of the Invoke method is inserted into the HTML sent to the browser
        /// </summary>
        /// <returns></returns>
        public IViewComponentResult Invoke()
        {
            ///The ViewComponent base class provides access to context objects through a set of properties.
            ///One of the properties is called RouteData, which provides information about how the request URL was handled by the routing system.
            ViewBag.SelectedCategory = RouteData?.Values["Category"];

            return View(
                repository.Products.Select(x => x.Category).Distinct().OrderBy(x => x)
                );
        }
    }
}
