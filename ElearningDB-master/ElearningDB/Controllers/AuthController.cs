using ElearningDB.Data;
using ElearningDB.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ElearningDB.Controllers
{
    public class AuthController : Controller
    {
        private readonly ElearningDbContext db;
        private readonly IWebHostEnvironment env;
        public AuthController(ElearningDbContext db)
        {
            this.db = db;
        }

        //Login
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(string email, string password)
        {
            if (string.IsNullOrEmpty(email) || string.IsNullOrEmpty(password))
            {
                ViewBag.Error = "Email and password are required.";
                return View();
            }
            var user = await db.Users.FirstOrDefaultAsync(u => u.Email == email && u.Password == password);

            if (user != null)
            {
                if (user.IsBlocked)
                {
                    ViewBag.Error = "Your account is blocked by the admin.";
                    return View();
                }

                // Set user session
                HttpContext.Session.SetInt32("UserID", user.UserId);
                HttpContext.Session.SetString("Email", user.Email);

                if (user.Role == "User")
                {
                    return RedirectToAction("Index", "Home");
                }

                if (user.Role == "Admin")
                {
                    return RedirectToAction("AddCourse", "Course");
                }
                return RedirectToAction("Index", "Home");
            }
            else
            {
                ViewBag.Error = "Invalid email or password.";
            }
            return View();
        }

        //Register
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Register(User model)
        {
            if (string.IsNullOrEmpty(model.Role))
            {
                model.Role = "User";  // Default role
            }

            db.Users.Add(model);
            db.SaveChanges();

            HttpContext.Session.SetString("Username", model.Username);
            return RedirectToAction("Login", "Login");
            //return View(model);
        }

    }
}
