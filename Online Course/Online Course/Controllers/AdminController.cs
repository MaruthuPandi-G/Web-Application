using Microsoft.AspNetCore.Mvc;
using Online_Course.Models;
using Online_Course.DataAccessObject;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace Online_Course.Controllers
{
    public class AdminController : Controller
    {
        private readonly Microsoft.AspNetCore.Hosting.IHostingEnvironment hostingEnvironment;

        public AdminController(Microsoft.AspNetCore.Hosting.IHostingEnvironment hostingEnvironment)
        {
            this.hostingEnvironment = hostingEnvironment;
        }


        [Route("Admin/Home")]
        public IActionResult Home()
        {
            IEnumerable<CourseDetail> courseDetails;
                lock (DbContect.GetDbContext())
            {
                courseDetails = DbContect.GetDbContext().CourseDetails.ToList();
            }
            return View(courseDetails);
        }

        [HttpGet]
        public async Task<IActionResult> Add()
        {           
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Add(CourseInsertModel courseDetail)
        {
            if (ModelState.IsValid)
            {
                string fileName = null;
                if (courseDetail.CourseImage != null)
                {
                    string folderName = Path.Combine(hostingEnvironment.WebRootPath, "Images");
                    fileName = Guid.NewGuid().ToString() + "_" + courseDetail.CourseImage.FileName;
                    string filePath = Path.Combine(folderName, fileName);
                    courseDetail.CourseImage.CopyTo(new FileStream(filePath, FileMode.Create));
                }
                CourseDetail course = new CourseDetail
                {
                    CourseName = courseDetail.CourseName,
                    CourseDescription = courseDetail.CourseDescription,
                    CourseImage = fileName
                };

                lock (DbContect.GetDbContext())
                {
                    DbContect.GetDbContext().CourseDetails.Add(course);
                    DbContect.GetDbContext().SaveChanges();
                }              
                
                return RedirectToAction("Home");
               
            }
            return View();
        }
        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            CourseDetail ?courseDetail = await DbContect.GetDbContext().CourseDetails.FindAsync(id);
            CourseEditModel courseEditModel = new CourseEditModel
            {
                Id = courseDetail.CourseId,
                CourseName = courseDetail.CourseName,
                CourseDescription = courseDetail.CourseDescription,
                ExistingPhotoPath = courseDetail.CourseImage
            };
            return View(courseEditModel); 
        }
        [HttpPost]
        public async Task<IActionResult> Update(CourseEditModel courseEditModel)
        {
            try
            {
                CourseDetail? courseDetail = await DbContect.GetDbContext().CourseDetails.FindAsync(courseEditModel.Id);

                string fileName = courseDetail.CourseImage;
                if (courseEditModel.CourseImage != null)
                {
                    if (courseEditModel.ExistingPhotoPath != null)
                    {
                        string existingFilePath = Path.Combine(hostingEnvironment.WebRootPath, "images", courseEditModel.ExistingPhotoPath);
                        System.IO.File.Delete(existingFilePath);
                    }

                    string folderName = Path.Combine(hostingEnvironment.WebRootPath, "Images");
                    fileName = Guid.NewGuid().ToString() + "_" + courseEditModel.CourseImage.FileName;
                    string filePath = Path.Combine(folderName, fileName);
                    courseEditModel.CourseImage.CopyTo(new FileStream(filePath, FileMode.Create));

                }

                courseDetail.CourseName = courseEditModel.CourseName;
                courseDetail.CourseDescription = courseEditModel.CourseDescription;
                courseDetail.CourseImage = fileName;
                DbContect.GetDbContext().CourseDetails.Update(courseDetail);
                return RedirectToAction("Home");
            }
            catch
            {
                return RedirectToAction("Home");
            }
            finally
            {
                DbContect.GetDbContext().SaveChanges();
            }
        }
        public async Task<IActionResult> Delete(int id)
        {
            CourseDetail ?deletedDetails = await DbContect.GetDbContext().CourseDetails.FindAsync(id);

             DbContect.GetDbContext().Entry(deletedDetails).State = EntityState.Deleted;

            await DbContect.GetDbContext().SaveChangesAsync();            

            return RedirectToAction("Home");
        }
    }
}
