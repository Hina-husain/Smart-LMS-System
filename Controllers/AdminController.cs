using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace SmartLMS.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AdminController : Controller
    {
        public IActionResult Index()
        {
            // Placeholder: Fetch dashboard metrics
            ViewBag.TotalStudents = 1250;
            ViewBag.TotalTeachers = 45;
            ViewBag.TotalCourses = 120;
            ViewBag.Revenue = 45000;
            return View();
        }

        public IActionResult ManageUsers()
        {
            return View();
        }
        
        public IActionResult Analytics()
        {
            return View();
        }
    }
}
