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
    public class PHsController : Controller
    {
        ApplicationDbContext db = new ApplicationDbContext();

        // GET: PHs
        public ActionResult Index()
        {
            string idx = db.Users.Where(u => u.UserName == User.Identity.Name).Select(u => u.Id).FirstOrDefault();
            var pHs = db.PHs.Where(p=> p.UserId==idx).OrderBy(p => p.DateCreated).Include(p => p.AspNetUser);
            return View(pHs.ToList());
        }
        public ActionResult DeletePH()
        {
            string phCode = Request.Form["phdelete"];
            if (phCode == "code" || phCode == "") return RedirectToAction("Index");
            PH pH = db.PHs.Find(phCode);
            db.PHs.Remove(pH);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public static String RandomString(int length)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            var random = new Random();
            return new string(Enumerable.Repeat(chars, length).Select(s => s[random.Next(s.Length)]).ToArray());
        }
        // GET: PHs/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PH pH = db.PHs.Find(id);
            if (pH == null)
            {
                return HttpNotFound();
            }
            return View(pH);
        }

        // GET: PHs/Create
        public ActionResult Create()
        {
            //ViewBag.UserId = new SelectList(db.AspNetUsers, "Id", "FullName");
            return View();
        }

        // POST: PHs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,UserId,Amount,DateCreated,Status")] PH pH)
        {
            if (ModelState.IsValid)
            {
                string idx = db.Users.Where(u => u.UserName == User.Identity.Name).Select(u => u.Id).FirstOrDefault();
                pH.ID = RandomString(16);
                pH.UserId = idx;
                pH.DateCreated = DateTime.Now.Date;
                pH.Status = "Pending";
                db.PHs.Add(pH);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.UserId = new SelectList(db.Users, "Id", "FullName", pH.UserId);
            return View(pH);
        }

        // GET: PHs/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PH pH = db.PHs.Find(id);
            if (pH == null)
            {
                return HttpNotFound();
            }
            ViewBag.UserId = new SelectList(db.Users, "Id", "FullName", pH.UserId);
            return View(pH);
        }

        // POST: PHs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,UserId,Amount,DateCreated,Status")] PH pH)
        {
            if (ModelState.IsValid)
            {
                db.Entry(pH).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.UserId = new SelectList(db.Users, "Id", "FullName", pH.UserId);
            return View(pH);
        }

        // GET: PHs/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PH pH = db.PHs.Find(id);
            if (pH == null)
            {
                return HttpNotFound();
            }
            return View(pH);
        }

        // POST: PHs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            PH pH = db.PHs.Find(id);
            db.PHs.Remove(pH);
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
