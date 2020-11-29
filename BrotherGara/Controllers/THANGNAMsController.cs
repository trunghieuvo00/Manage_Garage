using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using BrotherGara.Models;

namespace BrotherGara.Controllers
{
    public class THANGNAMsController : Controller
    {
        private BrothersGarageEntities db = new BrothersGarageEntities();

        // GET: THANGNAMs
        public ActionResult Index()
        {
            return View(db.THANGNAMs.ToList());
        }

        // GET: THANGNAMs/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            THANGNAM tHANGNAM = db.THANGNAMs.Find(id);
            if (tHANGNAM == null)
            {
                return HttpNotFound();
            }
            return View(tHANGNAM);
        }

        // GET: THANGNAMs/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: THANGNAMs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MaTN,Thang,Nam")] THANGNAM tHANGNAM)
        {
            if (ModelState.IsValid)
            {
                db.THANGNAMs.Add(tHANGNAM);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tHANGNAM);
        }

        // GET: THANGNAMs/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            THANGNAM tHANGNAM = db.THANGNAMs.Find(id);
            if (tHANGNAM == null)
            {
                return HttpNotFound();
            }
            return View(tHANGNAM);
        }

        // POST: THANGNAMs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MaTN,Thang,Nam")] THANGNAM tHANGNAM)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tHANGNAM).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tHANGNAM);
        }

        // GET: THANGNAMs/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            THANGNAM tHANGNAM = db.THANGNAMs.Find(id);
            if (tHANGNAM == null)
            {
                return HttpNotFound();
            }
            return View(tHANGNAM);
        }

        // POST: THANGNAMs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            THANGNAM tHANGNAM = db.THANGNAMs.Find(id);
            db.THANGNAMs.Remove(tHANGNAM);
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
