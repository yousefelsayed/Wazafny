using job_offer_website.Models;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApplication1.Controllers
{

    public class HomeController : Controller
    {
        private Models.ApplicationDbContext db = new Models.ApplicationDbContext();
        public ActionResult Index()
        {

            return View(db.Categories.ToList());
        }
        public ActionResult Details(int id)
        {
            var item = db.Jobs.Find(id);
            if (item == null)
            {
                return HttpNotFound();
            }

            Session["JobId"] = id;
            return View(item);
        }
        [Authorize]
        public ActionResult Apply()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Apply(string Message)
        {
            var UserId = User.Identity.GetUserId();
            var JobId = (int)Session["JobId"];
            var check = db.ApplyForJobs.Where(a => a.UserId == UserId && a.JobId == JobId).ToList();
            if(check.Count < 1)
            {

                var Job = new ApplyForJob();
                Job.UserId = UserId;
                Job.JobId = JobId;
                Job.Message = Message;
                Job.ApplyDate = DateTime.Now;
                db.ApplyForJobs.Add(Job);
                db.SaveChanges();
                ViewBag.Result = "تمت العمليه بنجاح!";

            }

            else
            {
                ViewBag.Result = "معذره تم التقدم لهذه الوظيفه من قبل !";
            }
            return View();
        }
        public ActionResult GetJobForUser()
        {
            var UserId = User.Identity.GetUserId();
            var jobs = db.ApplyForJobs.Where(a => a.UserId == UserId);
            return View(jobs.ToList());
        }
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }
        [Authorize]
        public ActionResult DetailsForJob(int id)
        {
            var job = db.ApplyForJobs.Find(id);
            if(job == null)
            {
                return HttpNotFound();


            }
            return View(job);


        }
        public ActionResult Edit(int id)
        {
            var job = db.ApplyForJobs.Find(id);
            if (job == null)
                return HttpNotFound();
            return View(job);
        }

        // POST: Roles/Edit/5
        [HttpPost]
        public ActionResult Edit(ApplyForJob job)
        {
            if (ModelState.IsValid)
            {
                job.ApplyDate = DateTime.Now;
                db.Entry(job).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("GetJobForUser");
            }
            return View(job);
        }
        [Authorize]
        public ActionResult GetJobByPublisher()
        {
            var UserId = User.Identity.GetUserId();
            var Jobs = from app in db.ApplyForJobs
                       join job in db.Jobs
                       on app.JobId equals job.Id
                       where job.User.Id == UserId
                       select app;
            var grouped = from j in Jobs
                          group j by j.job.JobTitle
                         into jr
                          select new JobsViewModel
                          {
                              JobTitle=jr.Key,
                              Items=jr
                          };
                         
            return View(grouped.ToList());
        }
        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        public ActionResult Delete(int id)
        {
            var job = db.ApplyForJobs.Find(id);
            if (job == null)
                return HttpNotFound();
            return View(job);
        }

        // POST: Roles/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(Job job)
        {
            var myjob = db.ApplyForJobs.Find(job.Id);

            db.ApplyForJobs.Remove(myjob);
            db.SaveChanges();
            return RedirectToAction("GetJobForUser");
            
        }
        public ActionResult Search()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Search(string searchName)
        {
            var result = db.Jobs.Where(a => a.JobTitle.Contains(searchName) || a.JobContent.Contains(searchName) 
            || a.User.UserName.Contains(searchName)
            ||a.Category.CategoryDescription.Contains(searchName)
            ||a.Category.CategoryName.Contains(searchName)).ToList();
           
            return View(result);
        }

    }
}