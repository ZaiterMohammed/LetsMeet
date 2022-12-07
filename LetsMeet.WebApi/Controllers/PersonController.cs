using Microsoft.AspNetCore.Mvc;

namespace LetsMeet.WebApi.Controllers
{
    public class PersonController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
