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
    public class MatchedTempsController : Controller
    {
        private QWModel db = new QWModel();

        // GET: MatchedTemps
        public ActionResult Index()
        {
            var matchedTemps = db.MatchedTemps.Include(m => m.GH).Include(m => m.PH);
            return View(matchedTemps.ToList());
        }

        // GET: MatchedTemps/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MatchedTemp matchedTemp = db.MatchedTemps.Find(id);
            if (matchedTemp == null)
            {
                return HttpNotFound();
            }
            return View(matchedTemp);
        }

        // GET: MatchedTemps/Create
        public ActionResult Create()
        {
            ViewBag.GHID = new SelectList(db.GHs, "ID", "UserId");
            ViewBag.PHID = new SelectList(db.PHs, "ID", "UserId");
            return View();
        }

        // POST: MatchedTemps/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,GHID,PHID,GHAmount,PHAmount,DateCreated,TimeCreated,ExpectedPaymentDate,ExpectedPaymentTime,PaymentDate,PaymentTime,ImageLink,Status")] MatchedTemp matchedTemp)
        {
            if (ModelState.IsValid)
            {
                db.MatchedTemps.Add(matchedTemp);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.GHID = new SelectList(db.GHs, "ID", "UserId", matchedTemp.GHID);
            ViewBag.PHID = new SelectList(db.PHs, "ID", "UserId", matchedTemp.PHID);
            return View(matchedTemp);
        }

        // GET: MatchedTemps/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MatchedTemp matchedTemp = db.MatchedTemps.Find(id);
            if (matchedTemp == null)
            {
                return HttpNotFound();
            }
            ViewBag.GHID = new SelectList(db.GHs, "ID", "UserId", matchedTemp.GHID);
            ViewBag.PHID = new SelectList(db.PHs, "ID", "UserId", matchedTemp.PHID);
            return View(matchedTemp);
        }

        // POST: MatchedTemps/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,GHID,PHID,GHAmount,PHAmount,DateCreated,TimeCreated,ExpectedPaymentDate,ExpectedPaymentTime,PaymentDate,PaymentTime,ImageLink,Status")] MatchedTemp matchedTemp)
        {
            if (ModelState.IsValid)
            {
                db.Entry(matchedTemp).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.GHID = new SelectList(db.GHs, "ID", "UserId", matchedTemp.GHID);
            ViewBag.PHID = new SelectList(db.PHs, "ID", "UserId", matchedTemp.PHID);
            return View(matchedTemp);
        }

        // GET: MatchedTemps/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MatchedTemp matchedTemp = db.MatchedTemps.Find(id);
            if (matchedTemp == null)
            {
                return HttpNotFound();
            }
            return View(matchedTemp);
        }

        // POST: MatchedTemps/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            MatchedTemp matchedTemp = db.MatchedTemps.Find(id);
            db.MatchedTemps.Remove(matchedTemp);
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
