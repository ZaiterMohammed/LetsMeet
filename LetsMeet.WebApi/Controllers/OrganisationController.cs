using Microsoft.AspNetCore.Mvc;

namespace LetsMeet.WebApi.Controllers
{
    public class OrganisationController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
