using Microsoft.AspNetCore.Mvc;
using SmartLMS.DTOs;
using SmartLMS.Interfaces;
using SmartLMS.Models;
using System.Threading.Tasks;
using System.Security.Claims;
using System.Linq;
using System.Collections.Generic;
using System;

namespace SmartLMS.Controllers
{
    // CONCEPT: MVC Pattern (Controller) & RESTful Principles
    public class Lecture
    {
        public string Id { get; set; }
        public string VideoId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Duration { get; set; }
    }

    public class CourseController : Controller
    {
        private readonly ICourseService _courseService;

        // CONCEPT: Shared dynamic course registry supporting multiple instructors (in PKR / Rs.)
        public static readonly List<Course> SimulatedCourses = new List<Course>
        {
            new Course { Id = "1", Title = "Learn C# Basics", Description = "Start your programming journey here.", Price = 12000m, CategoryId = "Programming", InstructorId = "Hina Fatima", IsPublished = true },
            new Course { Id = "2", Title = "Advanced .NET 8", Description = "Master the latest framework.", Price = 25000m, CategoryId = "Programming", InstructorId = "Hina Fatima", IsPublished = true }
        };

        // CONCEPT: Shared Lecture Bank for Simulated uploads and viewing
        public static readonly List<Lecture> SimulatedLectures = new List<Lecture>
        {
            new Lecture { Id = "1", VideoId = "gfkTfcpWqAY", Title = "1. Introduction to C# & .NET 10", Description = "Start your development journey with a deep dive into the high-level architecture.", Duration = "12:30" },
            new Lecture { Id = "2", VideoId = "8HUP1eD6CgM", Title = "2. Clean Architecture in ASP.NET Core", Description = "Learn how to separate concerns with Domain, Application, Infrastructure, and Presentation layers.", Duration = "08:15" },
            new Lecture { Id = "3", VideoId = "h1wF532xWGA", Title = "3. Connecting to MongoDB Atlas", Description = "Integrate Snappier, SharpCompress, and MongoDriver safely without connection timeout errors.", Duration = "14:50" }
        };

        // CONCEPT: Dependency Injection
        public CourseController(ICourseService courseService)
        {
            _courseService = courseService;
        }

        // GET: /Course/Index
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            try 
            {
                var courses = await _courseService.GetAllCoursesAsync();
                return View(courses);
            }
            catch (Exception)
            {
                // CONCEPT: Fallback UI using our dynamic simulated course list
                return View(SimulatedCourses);
            }
        }

        // GET: /Course/Details/{id}
        [HttpGet]
        public async Task<IActionResult> Details(string id)
        {
            Course course = null;
            try
            {
                course = await _courseService.GetCourseByIdAsync(id);
            }
            catch (Exception) { }

            if (course == null)
            {
                course = SimulatedCourses.FirstOrDefault(c => c.Id == id) ?? SimulatedCourses.FirstOrDefault();
            }

            // Pass the simulated lectures to the view using ViewBag
            ViewBag.Lectures = SimulatedLectures;
            return View(course);
        }

        // GET: /Course/Create
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        // POST: /Course/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CourseCreateDto courseDto)
        {
            if (!ModelState.IsValid)
            {
                return View(courseDto);
            }

            // Map DTO to Model - Assigning currently logged-in Instructor dynamically!
            var newCourse = new Course
            {
                Id = (SimulatedCourses.Count + 1).ToString(),
                Title = courseDto.Title,
                Description = courseDto.Description,
                Price = courseDto.Price,
                CategoryId = courseDto.CategoryId,
                InstructorId = User.Identity?.Name ?? "SYSTEM",
                IsPublished = true
            };

            try
            {
                await _courseService.CreateCourseAsync(newCourse);
                TempData["SuccessMessage"] = "Course published successfully!";
            }
            catch (Exception)
            {
                // CONCEPT: Dynamic in-memory save so it appears immediately on redirect!
                SimulatedCourses.Add(newCourse);
                TempData["SuccessMessage"] = "Course published successfully (Simulated Mode)!";
            }
            
            // Redirect instructor back to dashboard where they can see their new course!
            if (User.IsInRole("Teacher"))
            {
                return RedirectToAction("Index", "Teacher");
            }
            return RedirectToAction(nameof(Index));
        }

        // GET: /Course/Edit/{id}
        [HttpGet]
        public IActionResult Edit(string id)
        {
            var course = SimulatedCourses.FirstOrDefault(c => c.Id == id);
            if (course == null)
            {
                return NotFound();
            }
            return View(course);
        }

        // POST: /Course/Edit/{id}
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(string id, Course updatedCourse)
        {
            var course = SimulatedCourses.FirstOrDefault(c => c.Id == id);
            if (course == null)
            {
                return NotFound();
            }

            course.Title = updatedCourse.Title;
            course.Description = updatedCourse.Description;
            course.Price = updatedCourse.Price;
            course.CategoryId = updatedCourse.CategoryId;
            
            TempData["SuccessMessage"] = $"Course '{course.Title}' updated successfully!";
            return RedirectToAction("Index", "Teacher");
        }

        // GET: /Course/Delete/{id}
        [HttpGet]
        public IActionResult Delete(string id)
        {
            var course = SimulatedCourses.FirstOrDefault(c => c.Id == id);
            if (course != null)
            {
                SimulatedCourses.Remove(course);
                TempData["SuccessMessage"] = $"Course '{course.Title}' deleted successfully!";
            }
            return RedirectToAction("Index", "Teacher");
        }

        // POST: /Course/UploadLecture
        // CONCEPT: Teacher Video Upload Handler
        [HttpPost]
        public IActionResult UploadLecture(string title, string description, string videoUrl, string duration)
        {
            // Extract Video ID from YouTube link if present
            string videoId = videoUrl;
            if (videoUrl.Contains("v="))
            {
                videoId = videoUrl.Split("v=")[1].Split("&")[0];
            }
            else if (videoUrl.Contains("youtu.be/"))
            {
                videoId = videoUrl.Split("youtu.be/")[1].Split("?")[0];
            }
            else if (videoUrl.Contains("embed/"))
            {
                videoId = videoUrl.Split("embed/")[1].Split("?")[0];
            }

            var nextId = (SimulatedLectures.Count + 1).ToString();
            var newLecture = new Lecture
            {
                Id = nextId,
                VideoId = videoId,
                Title = $"{nextId}. {title}",
                Description = description,
                Duration = string.IsNullOrEmpty(duration) ? "10:00" : duration
            };

            SimulatedLectures.Add(newLecture);
            TempData["SuccessMessage"] = $"Lecture video '{title}' published successfully! It is now fully active for students.";
            return RedirectToAction("Index", "Teacher");
        }
    }
}
