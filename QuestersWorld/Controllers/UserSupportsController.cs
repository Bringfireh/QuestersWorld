using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using QuestersWorld.Models;

namespace QuestersWorld.Controllers
{
    public class UserSupportsController : Controller
    {
        ApplicationDbContext db = new ApplicationDbContext();

        // GET: UserSupports
        public ActionResult Index()
        {
            string idx = db.Users.Where(u => u.UserName == User.Identity.Name).Select(u => u.Id).FirstOrDefault();
            var userSupports = db.UserSupports.Where(u => u.UserId == idx).Include(u => u.AspNetUser);
            return View(userSupports.ToList());
        }
        public static String RandomString(int length)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            var random = new Random();
            return new string(Enumerable.Repeat(chars, length).Select(s => s[random.Next(s.Length)]).ToArray());
        }
        // GET: UserSupports/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UserSupport userSupport = db.UserSupports.Find(id);
            if (userSupport == null)
            {
                return HttpNotFound();
            }
            return View(userSupport);
        }

        // GET: UserSupports/Create
        public ActionResult Create()
        {
            ViewBag.UserId = new SelectList(db.Users, "Id", "FullName");
            return View();
        }

        // POST: UserSupports/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,UserId,Complaint,DateCreated,Status,Remarks,DateTreated")] UserSupport userSupport)
        {
            if (ModelState.IsValid)
            {
                string idx = db.Users.Where(u => u.UserName == User.Identity.Name).Select(u => u.Id).FirstOrDefault();
                userSupport.ID = RandomString(16);
                userSupport.UserId = idx;
                db.UserSupports.Add(userSupport);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.UserId = new SelectList(db.Users, "Id", "FullName", userSupport.UserId);
            return View(userSupport);
        }

        // GET: UserSupports/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UserSupport userSupport = db.UserSupports.Find(id);
            if (userSupport == null)
            {
                return HttpNotFound();
            }
            ViewBag.UserId = new SelectList(db.Users, "Id", "FullName", userSupport.UserId);
            return View(userSupport);
        }

        // POST: UserSupports/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,UserId,Complaint,DateCreated,Status,Remarks,DateTreated")] UserSupport userSupport)
        {
            if (ModelState.IsValid)
            {
                db.Entry(userSupport).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.UserId = new SelectList(db.Users, "Id", "FullName", userSupport.UserId);
            return View(userSupport);
        }

        // GET: UserSupports/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UserSupport userSupport = db.UserSupports.Find(id);
            if (userSupport == null)
            {
                return HttpNotFound();
            }
            return View(userSupport);
        }

        // POST: UserSupports/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            UserSupport userSupport = db.UserSupports.Find(id);
            db.UserSupports.Remove(userSupport);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
