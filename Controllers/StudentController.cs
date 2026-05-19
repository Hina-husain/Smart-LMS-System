using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace SmartLMS.Controllers
{
    public class StudentProfileViewModel
    {
        public string FullName { get; set; } = "John Doe";
        public string Email { get; set; } = "john.doe@example.com";
        public string Bio { get; set; } = "Enthusiastic software engineering student learning ASP.NET Core.";
    }

    [Authorize(Roles = "Student")]
    public class StudentController : Controller
    {
        public static readonly StudentProfileViewModel SimulatedProfile = new StudentProfileViewModel();

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult MyCourses()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Profile()
        {
            return View(SimulatedProfile);
        }

        // CONCEPT: Handling Form Post Data
        [HttpPost]
        public IActionResult Profile(string fullName, string email, string bio)
        {
            SimulatedProfile.FullName = fullName;
            SimulatedProfile.Email = email;
            SimulatedProfile.Bio = bio;
            // Simulate saving to database
            TempData["SuccessMessage"] = "Profile updated successfully!";
            return RedirectToAction("Profile");
        }

        [HttpGet]
        public IActionResult Settings()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Settings(string currentPassword, string newPassword)
        {
            TempData["SuccessMessage"] = "Settings updated successfully!";
            return RedirectToAction("Settings");
        }

        [HttpGet]
        public IActionResult Assignment()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Assignment(IFormFile assignmentFile, string comments)
        {
            TempData["SuccessMessage"] = "Assignment uploaded successfully! Simulated grade: Pending.";
            return RedirectToAction("Assignment");
        }

        [HttpGet]
        public IActionResult Certificates()
        {
            return View();
        }
    }
}
