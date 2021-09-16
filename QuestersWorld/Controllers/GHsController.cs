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
    public class GHsController : Controller
    {
        private QWModel db = new QWModel();

        // GET: GHs
        public ActionResult Index()
        {
            string idx = db.AspNetUsers.Where(u => u.UserName == User.Identity.Name).Select(u => u.Id).FirstOrDefault();

            var gHs = db.GHs.Where(g => g.UserId==idx).OrderBy(g =>g.DateCreated).Include(g => g.AspNetUser).Include(g=>g.Matcheds);
            return View(gHs.ToList());
        }
        public ActionResult DeleteGH()
        {
            string ghCode = Request.Form["ghdelete"];
            if (ghCode == "code" || ghCode == "") return RedirectToAction("Index");
            GH gH = db.GHs.Find(ghCode);
            db.GHs.Remove(gH);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        // GET: GHs/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GH gH = db.GHs.Find(id);
            if (gH == null)
            {
                return HttpNotFound();
            }
            return View(gH);
        }

        // GET: GHs/Create
        public ActionResult Create()
        {
            ViewBag.UserId = new SelectList(db.AspNetUsers, "Id", "FullName");
            return View();
        }

        // POST: GHs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,UserId,Amount,DateCreated,Status")] GH gH)
        {
            if (ModelState.IsValid)
            {
                db.GHs.Add(gH);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.UserId = new SelectList(db.AspNetUsers, "Id", "FullName", gH.UserId);
            return View(gH);
        }

        // GET: GHs/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GH gH = db.GHs.Find(id);
            if (gH == null)
            {
                return HttpNotFound();
            }
            ViewBag.UserId = new SelectList(db.AspNetUsers, "Id", "FullName", gH.UserId);
            return View(gH);
        }

        // POST: GHs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,UserId,Amount,DateCreated,Status")] GH gH)
        {
            if (ModelState.IsValid)
            {
                db.Entry(gH).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.UserId = new SelectList(db.AspNetUsers, "Id", "FullName", gH.UserId);
            return View(gH);
        }

        // GET: GHs/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GH gH = db.GHs.Find(id);
            if (gH == null)
            {
                return HttpNotFound();
            }
            return View(gH);
        }

        // POST: GHs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            GH gH = db.GHs.Find(id);
            db.GHs.Remove(gH);
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
