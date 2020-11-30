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
    public class PHIEUTHUTIENsController : Controller
    {
        private BrothersGarageEntities db = new BrothersGarageEntities();

        // GET: PHIEUTHUTIENs
        public ActionResult Index()
        {
            var pHIEUTHUTIENs = db.PHIEUTHUTIENs.Include(p => p.PHIEUSUACHUA);
            return View(pHIEUTHUTIENs.ToList());
        }

        // GET: PHIEUTHUTIENs/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PHIEUTHUTIEN pHIEUTHUTIEN = db.PHIEUTHUTIENs.Find(id);
            if (pHIEUTHUTIEN == null)
            {
                return HttpNotFound();
            }
            return View(pHIEUTHUTIEN);
        }

        // GET: PHIEUTHUTIENs/Create
        public ActionResult Create()
        {
            ViewBag.MaPSC = new SelectList(db.PHIEUSUACHUAs, "MaPSC", "MaPSC");
            return View();
        }

        // POST: PHIEUTHUTIENs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MaPTT,MaPSC,NgayThuTien,SoTienThu,ConNo")] PHIEUTHUTIEN pHIEUTHUTIEN)
        {
            if (ModelState.IsValid)
            {
                db.PHIEUTHUTIENs.Add(pHIEUTHUTIEN);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.MaPSC = new SelectList(db.PHIEUSUACHUAs, "MaPSC", "MaTiepNhan", pHIEUTHUTIEN.MaPSC);
            return View(pHIEUTHUTIEN);
        }

        // GET: PHIEUTHUTIENs/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PHIEUTHUTIEN pHIEUTHUTIEN = db.PHIEUTHUTIENs.Find(id);
            if (pHIEUTHUTIEN == null)
            {
                return HttpNotFound();
            }
            ViewBag.MaPSC = new SelectList(db.PHIEUSUACHUAs, "MaPSC", "MaTiepNhan", pHIEUTHUTIEN.MaPSC);
            return View(pHIEUTHUTIEN);
        }

        // POST: PHIEUTHUTIENs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MaPTT,MaPSC,NgayThuTien,SoTienThu,ConNo")] PHIEUTHUTIEN pHIEUTHUTIEN)
        {
            if (ModelState.IsValid)
            {
                db.Entry(pHIEUTHUTIEN).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.MaPSC = new SelectList(db.PHIEUSUACHUAs, "MaPSC", "MaTiepNhan", pHIEUTHUTIEN.MaPSC);
            return View(pHIEUTHUTIEN);
        }

        // GET: PHIEUTHUTIENs/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PHIEUTHUTIEN pHIEUTHUTIEN = db.PHIEUTHUTIENs.Find(id);
            if (pHIEUTHUTIEN == null)
            {
                return HttpNotFound();
            }
            return View(pHIEUTHUTIEN);
        }

        // POST: PHIEUTHUTIENs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            PHIEUTHUTIEN pHIEUTHUTIEN = db.PHIEUTHUTIENs.Find(id);
            db.PHIEUTHUTIENs.Remove(pHIEUTHUTIEN);
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
