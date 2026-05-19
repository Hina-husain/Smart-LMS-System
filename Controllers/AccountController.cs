using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using SmartLMS.Models;

namespace SmartLMS.Controllers
{
    public class AccountController : Controller
    {
        // Dynamic, thread-safe in-memory database of registered users
        private static readonly List<ApplicationUser> SimulatedUsers = new List<ApplicationUser>
        {
            // Seed a default admin, teacher and student for quick testing!
            new ApplicationUser { FullName = "System Admin", Email = "admin@example.com", PasswordHash = "admin123", Role = "Admin" },
            new ApplicationUser { FullName = "Hina Fatima", Email = "teacher@example.com", PasswordHash = "teacher123", Role = "Teacher" },
            new ApplicationUser { FullName = "John Doe", Email = "student@example.com", PasswordHash = "student123", Role = "Student" }
        };

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(string email, string password)
        {
            // CONCEPT: Authentication (Simulated for UI flow without DB timeouts)
            if (!string.IsNullOrEmpty(email) && !string.IsNullOrEmpty(password))
            {
                // 1. Search in dynamically registered list
                var existingUser = SimulatedUsers.FirstOrDefault(u => 
                    u.Email.Equals(email, StringComparison.OrdinalIgnoreCase) && 
                    u.PasswordHash == password);

                string role = "Student";
                string fullName = email.Split('@')[0];

                if (existingUser != null)
                {
                    role = existingUser.Role;
                    fullName = existingUser.FullName;
                }
                else
                {
                    // Fallback heuristics for ease of instant demo logins
                    if (email.Contains("admin"))
                        role = "Admin";
                    else if (email.Contains("teacher"))
                        role = "Teacher";
                    else
                        role = "Student";
                }

                // If logged in as student, sync name and email to student profile instantly!
                if (role == "Student")
                {
                    StudentController.SimulatedProfile.FullName = fullName;
                    StudentController.SimulatedProfile.Email = email;
                }

                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, fullName),
                    new Claim(ClaimTypes.Email, email),
                    new Claim(ClaimTypes.Role, role)
                };

                var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

                HttpContext.SignInAsync(
                    CookieAuthenticationDefaults.AuthenticationScheme, 
                    new ClaimsPrincipal(claimsIdentity));

                // 2. Redirect strictly based on the user's role
                if (role == "Admin")
                {
                    return RedirectToAction("Index", "Admin");
                }
                else if (role == "Teacher")
                {
                    return RedirectToAction("Index", "Teacher");
                }
                else
                {
                    return RedirectToAction("Index", "Student");
                }
            }

            ViewBag.Error = "Invalid login attempt. Please enter any email and password.";
            return View();
        }

        [HttpGet]
        public IActionResult Signup()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Signup(ApplicationUser user)
        {
            if (user != null && !string.IsNullOrEmpty(user.Email) && !string.IsNullOrEmpty(user.PasswordHash))
            {
                // Add the user dynamically to user list
                SimulatedUsers.Add(user);
                TempData["SuccessMessage"] = "Account created successfully! Please login with your registered credentials.";
                return RedirectToAction("Login");
            }
            
            ViewBag.Error = "Sign up failed. Please check your details.";
            return View(user);
        }

        public IActionResult Logout()
        {
            HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Index", "Home");
        }
    }
}
