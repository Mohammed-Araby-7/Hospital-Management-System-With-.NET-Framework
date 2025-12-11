using Microsoft.AspNetCore.Mvc;

namespace HospitalManagment.Controllers
{
    public class DashboardController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
