using ElearningDB.Data;
using ElearningDB.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace ElearningDB.Controllers
{
    public class AdminController : Controller
    {
        private readonly ElearningDbContext db;
        private readonly IWebHostEnvironment env;
        public AdminController(ElearningDbContext db, IWebHostEnvironment env)
        {
            this.db = db;
            this.env = env;
        }

        //Add Courses
        public IActionResult AddCourse()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddCourse(CourseViewModel model)
        {
            if (model.ImagePath != null && model.ImagePath.Length > 0)
            {
                var path = env.WebRootPath;
                var filepath = Path.Combine("Content/Images", model.ImagePath.FileName);
                var fullpath = Path.Combine(path, filepath);
                using (var stream = new FileStream(fullpath, FileMode.Create))
                {
                    model.ImagePath.CopyTo(stream);
                }
                var Course = new Course()
                {
                    CourseName = model.CourseName,

                    ImagePath = filepath
                };
                db.Courses.Add(Course);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            TempData["msg"] = "Please upload an image file.";
            return View(model);
        }

        //Add SubCourses
        public IActionResult AddSubCourse()
        {
            ViewData["CourseId"] = new SelectList(db.Courses, "CourseId", "CourseName");
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddSubCourse(SubCourseViewModel model)
        {
            if (model.ImagePath != null && model.ImagePath.Length > 0)
            {
                var path = env.WebRootPath;
                var filepath = Path.Combine("Content/Images", model.ImagePath.FileName);
                var fullpath = Path.Combine(path, filepath);
                using (var stream = new FileStream(fullpath, FileMode.Create))
                {
                    model.ImagePath.CopyTo(stream);
                }
                var SubCourse = new SubCourse()
                {
                    CourseId = model.CourseId,
                    SubCourseName = model.SubCourseName,
                    Price = model.Price,
                    Course = model.Course,
                    ImagePath = filepath
                };
                db.SubCourses.Add(SubCourse);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewData["CourseId"] = new SelectList(db.Courses, "CourseId", "CourseName", model.CourseId);
            return View(model);
        }

        //UserList
        public IActionResult UsersList()
        {
            var users = GetUsersFromDatabase().ToList();
            return View(users);
        }

        [HttpPost]
        public IActionResult BlockUnblockUser(int userId, bool block)
        {
            var user = db.Users.FirstOrDefault(u => u.UserId == userId);
            if (user != null)
            {
                user.IsBlocked = block;
                db.SaveChanges();
            }
            return RedirectToAction("UsersList");
        }
        private IQueryable<User> GetUsersFromDatabase()
        {
            return db.Users.AsQueryable();
        }

        //Video
        public IActionResult UploadVideo()
        {
            ViewData["CourseId"] = new SelectList(db.Courses, "CourseId", "CourseName");
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> UploadVideo(VideoViewModel model)
        {
            if (model.ImagePath != null && model.ImagePath.Length > 0)
            {
                var path = env.WebRootPath;
                var filepath = Path.Combine("Content/Images", model.ImagePath.FileName);
                var fullpath = Path.Combine(path, filepath);
                using (var stream = new FileStream(fullpath, FileMode.Create))
                {
                    model.ImagePath.CopyTo(stream);
                }
                var Video = new Video()
                {
                    SubCourseId = model.SubCourseId,
                    TopicName = model.TopicName,
                    Url = model.Url,
                    CourseId = model.CourseId,
                    SubCourse = model.SubCourse,
                    ImagePath = filepath
                };
                db.Videos.Add(Video);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewData["SubCourseId"] = new SelectList(db.SubCourses, "SubCourseId", "SubCourseName", model.SubCourseId);
            return View(model);
        }
        public IActionResult GetSubCourses(int courseId)
        {
            var subCourses = db.SubCourses
                               .Where(sc => sc.CourseId == courseId)
                               .Select(sc => new { sc.SubCourseId, sc.SubCourseName })
                               .ToList();
            return Json(subCourses);
        }

        //VideoList
        public IActionResult VideosList()
        {
            var videos = GetVideosListFromDatabase();
            return View(videos);
        }

        private IEnumerable<VideoListModel> GetVideosListFromDatabase()
        {
            // Group videos by SubCourse and count the number of videos in each group
            var videoList = db.Videos
                .Include(v => v.SubCourse)
                .GroupBy(v => v.SubCourse.SubCourseName)
                .Select(group => new VideoListModel
                {
                    SubCourseName = group.Key,
                    VideoCount = group.Count()
                })
                .ToList();
            return videoList;
        }

    }
}
