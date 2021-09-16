using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using QuestersWorld.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace QuestersWorld.Controllers
{
    [Authorize]
    public class CcController : Controller
    {
        // GET: Cc
        private QWModel db = new QWModel();
        public ActionResult Index()
        {
            if (User.Identity.IsAuthenticated)
            {
                var user = User.Identity;
                ApplicationDbContext context = new ApplicationDbContext();
                var UserManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));
                var s = UserManager.GetRoles(user.GetUserId());
                if (s[0].ToString() == "Admin")
                {
                    return RedirectToAction("Am");
                }
                else
                {
                    return RedirectToAction("Pm");
                }
            }
            return View();
        }
        public ActionResult Am()
        {
            if (db.AspNetUsers.Where(u => u.UserName == User.Identity.Name).Select(u => u.ActiveStatus).FirstOrDefault() != "Active") return RedirectToAction("DeactivatedUser");
            var user = db.AspNetUsers.ToList();
            ViewBag.TotalUsers = db.AspNetUsers.Count();
            return View(user);
        }
        public ActionResult Pm()
        {
            if (db.AspNetUsers.Where(u => u.UserName == User.Identity.Name).Select(u => u.ActiveStatus).FirstOrDefault() != "Active") return RedirectToAction("DeactivatedUser");
            string idx = db.AspNetUsers.Where(u => u.UserName == User.Identity.Name).Select(u => u.Id).FirstOrDefault();
            var pHs = db.PHs.Where(p => p.UserId == idx).OrderBy(p => p.DateCreated);
            return View(pHs.ToList());
           
        }
        public ActionResult DeactivatedUser()
        {
            if (db.AspNetUsers.Where(u => u.UserName == User.Identity.Name).Select(u => u.ActiveStatus).FirstOrDefault() == "Active") return RedirectToAction("Pm");
            string idx = db.AspNetUsers.Where(u => u.UserName == User.Identity.Name).Select(u => u.Id).FirstOrDefault();
            var userSupports = db.UserSupports.Where(u => u.UserId == idx);
            return View(userSupports.ToList());
        }
    }
}