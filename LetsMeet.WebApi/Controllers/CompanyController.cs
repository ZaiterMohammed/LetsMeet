using Microsoft.AspNetCore.Mvc;

namespace LetsMeet.WebApi.Controllers
{
    public class CompanyController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
