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
    public class MatchedsController : Controller
    {
        ApplicationDbContext db = new ApplicationDbContext();

        // GET: Matcheds
        public ActionResult Index()
        {
            var matcheds = db.Matcheds.Include(m => m.GH).Include(m => m.PH);
            return View(matcheds.ToList());
        }

        // GET: Matcheds/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Matched matched = db.Matcheds.Find(id);
            if (matched == null)
            {
                return HttpNotFound();
            }
            return View(matched);
        }

        // GET: Matcheds/Create
        public ActionResult Create()
        {
            ViewBag.GHID = new SelectList(db.GHs, "ID", "UserId");
            ViewBag.PHID = new SelectList(db.PHs, "ID", "UserId");
            return View();
        }

        // POST: Matcheds/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,GHID,PHID,GHAmount,PHAmount,DateCreated,TimeCreated,ExpectedPaymentDate,ExpectedPaymentTime,PaymentDate,PaymentTime,ImageLink,Status")] Matched matched)
        {
            if (ModelState.IsValid)
            {
                db.Matcheds.Add(matched);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.GHID = new SelectList(db.GHs, "ID", "UserId", matched.GHID);
            ViewBag.PHID = new SelectList(db.PHs, "ID", "UserId", matched.PHID);
            return View(matched);
        }

        // GET: Matcheds/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Matched matched = db.Matcheds.Find(id);
            if (matched == null)
            {
                return HttpNotFound();
            }
            ViewBag.GHID = new SelectList(db.GHs, "ID", "UserId", matched.GHID);
            ViewBag.PHID = new SelectList(db.PHs, "ID", "UserId", matched.PHID);
            return View(matched);
        }

        // POST: Matcheds/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,GHID,PHID,GHAmount,PHAmount,DateCreated,TimeCreated,ExpectedPaymentDate,ExpectedPaymentTime,PaymentDate,PaymentTime,ImageLink,Status")] Matched matched)
        {
            if (ModelState.IsValid)
            {
                db.Entry(matched).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.GHID = new SelectList(db.GHs, "ID", "UserId", matched.GHID);
            ViewBag.PHID = new SelectList(db.PHs, "ID", "UserId", matched.PHID);
            return View(matched);
        }

        // GET: Matcheds/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Matched matched = db.Matcheds.Find(id);
            if (matched == null)
            {
                return HttpNotFound();
            }
            return View(matched);
        }

        // POST: Matcheds/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            Matched matched = db.Matcheds.Find(id);
            db.Matcheds.Remove(matched);
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
