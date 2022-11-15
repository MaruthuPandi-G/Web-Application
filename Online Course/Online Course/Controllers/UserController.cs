using Microsoft.AspNetCore.Mvc;
using Online_Course.Models;
using System.Diagnostics;
using Online_Course.DataAccessObject;
using Online_Course.DataAccessObject.SubscriberDetails;
using Online_Course.DataAccessObject.FeedbackDetails;
using Online_Course.DataAccessObject.RegisterDetails;
using Online_Course.DataAccessObject.LoginDetails;
using Online_Course.DataAccessObject.UserCourses;
using Online_Course.Models.Register;
using Online_Course.Models.Blog;

namespace Online_Course.Controllers
{
    public class UserController : Controller
    {

        private readonly Microsoft.AspNetCore.Hosting.IHostingEnvironment hostingEnvironment;

        public UserController(Microsoft.AspNetCore.Hosting.IHostingEnvironment hostingEnvironment)
        {
            this.hostingEnvironment = hostingEnvironment;
        }

        [Route("")]
        [HttpGet]
        public IActionResult Home()
        {
            SubscriberDetail userViewModel = new SubscriberDetail();
            return View(userViewModel);
        }

        [HttpPost]
        public IActionResult Home(SubscriberDetail userViewModel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    ISubscribe subscribe = new Subscribe();
                    if (subscribe.UserSubscriberDetail(userViewModel))
                    {
                        ModelState.Clear();
                        ViewBag.SuccessMsg = "Successfully Subscribed!";
                        return View("Home");
                    }
                    else
                    {
                        return View("Home");
                    }
                } 
                else
                {
                    return View("Home");
                }
            }
            catch
            {
                return View();
            }
        }

        [HttpGet]
        public ActionResult About()
        {
            SubscriberDetail userViewModel = new SubscriberDetail();
            return View(userViewModel);
        }

        [HttpPost]
        public ActionResult About(SubscriberDetail userViewModel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    ISubscribe subscribe = new Subscribe();
                    if (subscribe.UserSubscriberDetail(userViewModel))
                    {
                        ModelState.Clear();
                        return View("About");
                    }
                    else
                    {
                        return View("About");
                    }
                }
                else
                {
                    return View("About");
                }
            }
            catch
            {
                return View();
            }
        }


        [HttpGet]
        public ActionResult Courses()
        {
            IEnumerable<CourseDetail> courseDetails;
            lock (DbContect.GetDbContext())
            {
                courseDetails = DbContect.GetDbContext().CourseDetails.ToList();
            }
           
            return View(courseDetails);             
           
        }

        public JsonResult Search(string courseName)
        {
            if (courseName == null)
            {
                courseName = "";
            }
            try
            {
                lock (DbContect.GetDbContext())
                {
                    IEnumerable<CourseDetail> courseDetails = DbContect.GetDbContext().CourseDetails.Where(a => a.CourseName.StartsWith(courseName)).ToList();
                    return Json(courseDetails);
                }                
            }
            catch
            {
                return Json(null);
            }
        }    
       
        
        [HttpGet]
        public ActionResult Blog()
        {
            BlogsModel blogModel = new BlogsModel();            
            lock (DbContect.GetDbContext())
            {
                blogModel.BlogsDetails = DbContect.GetDbContext().BlogDetails.OrderByDescending(x => x.BlogId);
            }
            
            return View(blogModel);
        }

        [HttpPost]
        public ActionResult Blog(BlogsModel blogsModel)
        {
            try
            {
                string fileName = null;
                if (blogsModel.BlogDetail.BloggerImage != null)
                {
                    string folderName = Path.Combine(hostingEnvironment.WebRootPath, "Images");
                    fileName = Guid.NewGuid().ToString() + "_" + blogsModel.BlogDetail.BloggerImage.FileName;
                    string filePath = Path.Combine(folderName, fileName);
                    blogsModel.BlogDetail.BloggerImage.CopyTo(new FileStream(filePath, FileMode.Create));
                }
                BlogDetail blogDetail = new BlogDetail
                {
                    BloggerName = blogsModel.BlogDetail.BloggerName,
                    BlogName = blogsModel.BlogDetail.BlogName,
                    BlogDetails = blogsModel.BlogDetail.BlogDetails,
                    BloggerImage = fileName,
                    BlogDate = DateTime.Now,
                };
                lock (DbContect.GetDbContext())
                {
                    DbContect.GetDbContext().BlogDetails.Add(blogDetail);                   
                }
                return RedirectToAction("Blog");
            }
            catch
            {
                return RedirectToAction("Blog");
            }
            finally
            {
                DbContect.GetDbContext().SaveChanges();
            }
        }

        [HttpGet]
        public ActionResult Contact()
        {
            FeedbackDetail feedbackDetail = new FeedbackDetail();
            return View(feedbackDetail);
        }


        
        [HttpPost]
        public async Task<IActionResult> Contact(FeedbackDetail userViewModel)

        {
            try
            {
                if (ModelState.IsValid)
                {
                    IFeedBack feedBack = new FeedBack();

                    if (await feedBack.UserFeedback(userViewModel))
                    {
                        ModelState.Clear();
                        ViewBag.Feedback = "Thank you for your feedback.";
                        return View();
                    }
                    else
                    {
                        return View();
                    }
                }
                else
                {
                    return View();
                }
            }

            catch
            {
                return View();
            }
        }

        [HttpGet]
        public ActionResult Register()
        {
          
            RegisterValidationModel reg = new RegisterValidationModel();
          
            return View(reg);
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterValidationModel registerModel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (registerModel.Password == registerModel.ConfirmPassword)
                    {
                        IRegister register = new Register();

                        if (await register.UserRegisterDetail(registerModel))
                        {
                            ModelState.Clear();
                            return View("Login");
                        }
                        else
                        {
                            ModelState.Clear();
                            return View();
                        }
                    }
                    else
                    {
                        ViewBag.Message = "Both Password field must be same";
                        return View();
                    }
                }


                else
                {
                    return View("Register");
                }
            }
            catch
            {
                return View();
            }
        }

        [HttpGet]
        public ActionResult Login()
        {
            LoginModel login = new LoginModel();
            return View(login);
        }

        [HttpPost]

        public ActionResult Login(LoginModel loginDetail)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    ILogin login = new Login();
                    RegisterModel register = login.UserLogin(loginDetail.UserEmail, loginDetail.UserPassword);
                    if (register != null)
                    {
                        HttpContext.Session.SetString("UserId", register.UserId.ToString());
                        HttpContext.Session.SetString("UserName",register.Name);
                        TempData["User Name"] = HttpContext.Session.GetString("UserName");
                        ModelState.Clear();
                        return RedirectToAction("UserPage");
                    }
                    else
                    {
                        ModelState.Clear();
                        ViewBag.Message = "User Can not be Found";
                        return View();
                    }
                }
                else
                {
                    return View();
                }
            }
            catch
            {
                return View();
            }
        }

        [HttpGet]
        public IActionResult UserPage()
        {
            if (HttpContext.Session.GetString("UserName")!=null)
            {
                ViewData["UserId"] = HttpContext.Session.GetString("UserId");
                CheckboxModel checkboxModel= new CheckboxModel();
                checkboxModel.courseDetails = DbContect.GetDbContext().CourseDetails.ToList();
                return View(checkboxModel);
            }
            return RedirectToAction("Login");
        }

        [HttpPost]
        public IActionResult UserPage(CheckboxModel courses)
        {
            try
            {
                IUserCourseInsert userCourseInsert = new UserCourseInsert();
                lock (DbContect.GetDbContext())
                {
                    courses.courseDetails = DbContect.GetDbContext().CourseDetails.ToList();
                }
                if (userCourseInsert.UserCourseDetails(courses))
                {                    
                    TempData["User Name"] = HttpContext.Session.GetString("UserName");
                    ViewData["Message"] = "You may get your course details in your account page within 24 hours";
                    return View(courses);
                }
                return View();
            }
            catch
            {
                return View();
            }
        }

        public ActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Home");
        }

    }
}
