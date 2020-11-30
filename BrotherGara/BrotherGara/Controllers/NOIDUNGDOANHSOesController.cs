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
    public class NOIDUNGDOANHSOesController : Controller
    {
        private BrothersGarageEntities db = new BrothersGarageEntities();

        // GET: NOIDUNGDOANHSOes
        public ActionResult Index()
        {
            var nOIDUNGDOANHSOes = db.NOIDUNGDOANHSOes.Include(n => n.HIEUXE).Include(n => n.PHIEUDOANHSO).Include(n => n.PHIEUTHUTIEN);
            return View(nOIDUNGDOANHSOes.ToList());
        }

        // GET: NOIDUNGDOANHSOes/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NOIDUNGDOANHSO nOIDUNGDOANHSO = db.NOIDUNGDOANHSOes.Find(id);
            if (nOIDUNGDOANHSO == null)
            {
                return HttpNotFound();
            }
            return View(nOIDUNGDOANHSO);
        }

        // GET: NOIDUNGDOANHSOes/Create
        public ActionResult Create()
        {
            ViewBag.MaHieuXe = new SelectList(db.HIEUXEs, "MaHieuXe", "TenHieuXe");
            ViewBag.MaPDS = new SelectList(db.PHIEUDOANHSOes, "MaPDS", "MaTN");
            ViewBag.MaPTT = new SelectList(db.PHIEUTHUTIENs, "MaPTT", "MaPSC");
            return View();
        }

        // POST: NOIDUNGDOANHSOes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MaNDDS,MaPDS,MaPTT,MaHieuXe,SoLuotSua,ThanhTien,TiLe")] NOIDUNGDOANHSO nOIDUNGDOANHSO)
        {
            if (ModelState.IsValid)
            {
                db.NOIDUNGDOANHSOes.Add(nOIDUNGDOANHSO);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.MaHieuXe = new SelectList(db.HIEUXEs, "MaHieuXe", "TenHieuXe", nOIDUNGDOANHSO.MaHieuXe);
            ViewBag.MaPDS = new SelectList(db.PHIEUDOANHSOes, "MaPDS", "MaTN", nOIDUNGDOANHSO.MaPDS);
            ViewBag.MaPTT = new SelectList(db.PHIEUTHUTIENs, "MaPTT", "MaPSC", nOIDUNGDOANHSO.MaPTT);
            return View(nOIDUNGDOANHSO);
        }

        // GET: NOIDUNGDOANHSOes/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NOIDUNGDOANHSO nOIDUNGDOANHSO = db.NOIDUNGDOANHSOes.Find(id);
            if (nOIDUNGDOANHSO == null)
            {
                return HttpNotFound();
            }
            ViewBag.MaHieuXe = new SelectList(db.HIEUXEs, "MaHieuXe", "TenHieuXe", nOIDUNGDOANHSO.MaHieuXe);
            ViewBag.MaPDS = new SelectList(db.PHIEUDOANHSOes, "MaPDS", "MaTN", nOIDUNGDOANHSO.MaPDS);
            ViewBag.MaPTT = new SelectList(db.PHIEUTHUTIENs, "MaPTT", "MaPSC", nOIDUNGDOANHSO.MaPTT);
            return View(nOIDUNGDOANHSO);
        }

        // POST: NOIDUNGDOANHSOes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MaNDDS,MaPDS,MaPTT,MaHieuXe,SoLuotSua,ThanhTien,TiLe")] NOIDUNGDOANHSO nOIDUNGDOANHSO)
        {
            if (ModelState.IsValid)
            {
                db.Entry(nOIDUNGDOANHSO).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.MaHieuXe = new SelectList(db.HIEUXEs, "MaHieuXe", "TenHieuXe", nOIDUNGDOANHSO.MaHieuXe);
            ViewBag.MaPDS = new SelectList(db.PHIEUDOANHSOes, "MaPDS", "MaTN", nOIDUNGDOANHSO.MaPDS);
            ViewBag.MaPTT = new SelectList(db.PHIEUTHUTIENs, "MaPTT", "MaPSC", nOIDUNGDOANHSO.MaPTT);
            return View(nOIDUNGDOANHSO);
        }

        // GET: NOIDUNGDOANHSOes/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NOIDUNGDOANHSO nOIDUNGDOANHSO = db.NOIDUNGDOANHSOes.Find(id);
            if (nOIDUNGDOANHSO == null)
            {
                return HttpNotFound();
            }
            return View(nOIDUNGDOANHSO);
        }

        // POST: NOIDUNGDOANHSOes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            NOIDUNGDOANHSO nOIDUNGDOANHSO = db.NOIDUNGDOANHSOes.Find(id);
            db.NOIDUNGDOANHSOes.Remove(nOIDUNGDOANHSO);
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
