using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace SmartLMS.Controllers
{
    [Authorize(Roles = "Teacher")]
    public class TeacherController : Controller
    {
        public IActionResult Index()
        {
            // 1. Retrieve currently authenticated Instructor Name
            string instructorName = User.Identity?.Name ?? "Hina Fatima";

            // 2. Filter courses dynamically from CourseController registry for this teacher!
            var teacherCourses = CourseController.SimulatedCourses
                .Where(c => c.InstructorId.Equals(instructorName, System.StringComparison.OrdinalIgnoreCase))
                .ToList();

            // 3. Calculate dynamic instructor metrics based on their actual catalog
            int totalCourses = teacherCourses.Count;
            int activeStudents = totalCourses > 0 ? totalCourses * 60 : 0;
            decimal totalEarnings = teacherCourses.Sum(c => 60 * c.Price * 0.70m); // 70% dynamic split

            ViewBag.InstructorName = instructorName;
            ViewBag.ActiveStudents = activeStudents;
            ViewBag.TotalCourses = totalCourses;
            ViewBag.TotalEarnings = totalEarnings.ToString("N0");

            return View(teacherCourses); // Pass their courses to the View model!
        }

        public IActionResult ManageCourses()
        {
            return RedirectToAction("Index");
        }
        
        public IActionResult CreateCourse()
        {
            return RedirectToAction("Create", "Course");
        }
    }
}
