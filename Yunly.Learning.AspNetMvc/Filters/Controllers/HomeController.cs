using Microsoft.AspNetCore.Mvc;
using Filters.Infrastructure;
namespace Filters.Controllers
{
    [Message("This is the Controller-Scoped Filter, order=10", Order =10)]
    public class HomeController : Controller
    {
        [Message("This is the First Action-Scoped Filter, order=5", Order =5)]
        [Message("This is the Second Action-Scoped Filter, order=0", Order = 0)]
        public ViewResult Index() => View("Message", "This is the Index action on the Home controller");
    }
}