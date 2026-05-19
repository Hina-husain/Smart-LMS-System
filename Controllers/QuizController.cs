using Microsoft.AspNetCore.Mvc;
using SmartLMS.Interfaces;
using SmartLMS.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SmartLMS.Controllers
{
    // CONCEPT: MVC Pattern - Controller
    public class QuizController : Controller
    {
        private readonly IQuizService _quizService;

        public QuizController(IQuizService quizService)
        {
            _quizService = quizService;
        }

        [HttpGet]
        public async Task<IActionResult> Index(string courseId)
        {
            // Dummy data for presentation if DB is empty/unconnected
            var quizzes = await _quizService.GetQuizzesByCourseAsync(courseId);
            ViewBag.CourseId = courseId;
            return View(quizzes);
        }

        [HttpGet]
        public IActionResult Take(string id)
        {
            // Mock Quiz Data for UI Demonstration
            var mockQuiz = new Quiz
            {
                Id = id,
                Title = "C# Basics Quiz",
                TimeLimitMinutes = 15,
                Questions = new List<Question>
                {
                    new Question { Text = "What is the base class for all classes in C#?", Options = new List<string> { "System.Type", "System.Object", "System.Class", "System.Base" }, CorrectOptionIndex = 1 },
                    new Question { Text = "Which keyword is used to implement an interface?", Options = new List<string> { "implements", "using", "colon (:)", "inherits" }, CorrectOptionIndex = 2 }
                }
            };
            return View(mockQuiz);
        }

        [HttpPost]
        public IActionResult SubmitQuiz(string quizId, List<int> answers)
        {
            // Logic to calculate score would go here using _quizService.CalculateScore
            TempData["SuccessMessage"] = "Quiz submitted successfully! Your score is being calculated.";
            return RedirectToAction("Index", "Student");
        }
    }
}
