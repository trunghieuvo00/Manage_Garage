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
    public class PHIEUDOANHSOesController : Controller
    {
        private BrothersGarageEntities db = new BrothersGarageEntities();

        // GET: PHIEUDOANHSOes
        public ActionResult Index()
        {
            var pHIEUDOANHSOes = db.PHIEUDOANHSOes.Include(p => p.THANGNAM);
            return View(pHIEUDOANHSOes.ToList());
        }

        // GET: PHIEUDOANHSOes/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PHIEUDOANHSO pHIEUDOANHSO = db.PHIEUDOANHSOes.Find(id);
            if (pHIEUDOANHSO == null)
            {
                return HttpNotFound();
            }
            return View(pHIEUDOANHSO);
        }

        // GET: PHIEUDOANHSOes/Create
        public ActionResult Create()
        {
            ViewBag.MaTN = new SelectList(db.THANGNAMs, "MaTN", "MaTN");
            return View();
        }

        // POST: PHIEUDOANHSOes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MaPDS,MaTN,TongDoanhThu")] PHIEUDOANHSO pHIEUDOANHSO)
        {
            if (ModelState.IsValid)
            {
                db.PHIEUDOANHSOes.Add(pHIEUDOANHSO);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.MaTN = new SelectList(db.THANGNAMs, "MaTN", "MaTN", pHIEUDOANHSO.MaTN);
            return View(pHIEUDOANHSO);
        }

        // GET: PHIEUDOANHSOes/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PHIEUDOANHSO pHIEUDOANHSO = db.PHIEUDOANHSOes.Find(id);
            if (pHIEUDOANHSO == null)
            {
                return HttpNotFound();
            }
            ViewBag.MaTN = new SelectList(db.THANGNAMs, "MaTN", "MaTN", pHIEUDOANHSO.MaTN);
            return View(pHIEUDOANHSO);
        }

        // POST: PHIEUDOANHSOes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MaPDS,MaTN,TongDoanhThu")] PHIEUDOANHSO pHIEUDOANHSO)
        {
            if (ModelState.IsValid)
            {
                db.Entry(pHIEUDOANHSO).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.MaTN = new SelectList(db.THANGNAMs, "MaTN", "MaTN", pHIEUDOANHSO.MaTN);
            return View(pHIEUDOANHSO);
        }

        // GET: PHIEUDOANHSOes/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PHIEUDOANHSO pHIEUDOANHSO = db.PHIEUDOANHSOes.Find(id);
            if (pHIEUDOANHSO == null)
            {
                return HttpNotFound();
            }
            return View(pHIEUDOANHSO);
        }

        // POST: PHIEUDOANHSOes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            PHIEUDOANHSO pHIEUDOANHSO = db.PHIEUDOANHSOes.Find(id);
            db.PHIEUDOANHSOes.Remove(pHIEUDOANHSO);
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
