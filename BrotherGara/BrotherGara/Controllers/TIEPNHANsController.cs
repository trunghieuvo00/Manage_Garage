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
    public class TIEPNHANsController : Controller
    {
        private BrothersGarageEntities db = new BrothersGarageEntities();

        // GET: TIEPNHANs
        public ActionResult Index()
        {
            var tIEPNHANs = db.TIEPNHANs.Include(t => t.HIEUXE);
            return View(tIEPNHANs.ToList());
        }

        // GET: TIEPNHANs/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TIEPNHAN tIEPNHAN = db.TIEPNHANs.Find(id);
            if (tIEPNHAN == null)
            {
                return HttpNotFound();
            }
            return View(tIEPNHAN);
        }

        // GET: TIEPNHANs/Create
        public ActionResult Create()
        {
            ViewBag.MaHieuXe = new SelectList(db.HIEUXEs, "MaHieuXe", "TenHieuXe");
            return View();
        }

        // POST: TIEPNHANs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MaTiepNhan,BienSo,TenChuXe,MaHieuXe,DiaChi,DienThoai,NgayTiepNhan,TienNo,Email")] TIEPNHAN tIEPNHAN)
        {
            if (ModelState.IsValid)
            {
                db.TIEPNHANs.Add(tIEPNHAN);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.MaHieuXe = new SelectList(db.HIEUXEs, "MaHieuXe", "TenHieuXe", tIEPNHAN.MaHieuXe);
            return View(tIEPNHAN);
        }

        // GET: TIEPNHANs/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TIEPNHAN tIEPNHAN = db.TIEPNHANs.Find(id);
            if (tIEPNHAN == null)
            {
                return HttpNotFound();
            }
            ViewBag.MaHieuXe = new SelectList(db.HIEUXEs, "MaHieuXe", "TenHieuXe", tIEPNHAN.MaHieuXe);
            return View(tIEPNHAN);
        }

        // POST: TIEPNHANs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MaTiepNhan,BienSo,TenChuXe,MaHieuXe,DiaChi,DienThoai,NgayTiepNhan,TienNo,Email")] TIEPNHAN tIEPNHAN)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tIEPNHAN).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.MaHieuXe = new SelectList(db.HIEUXEs, "MaHieuXe", "TenHieuXe", tIEPNHAN.MaHieuXe);
            return View(tIEPNHAN);
        }

        // GET: TIEPNHANs/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TIEPNHAN tIEPNHAN = db.TIEPNHANs.Find(id);
            if (tIEPNHAN == null)
            {
                return HttpNotFound();
            }
            return View(tIEPNHAN);
        }

        // POST: TIEPNHANs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            TIEPNHAN tIEPNHAN = db.TIEPNHANs.Find(id);
            db.TIEPNHANs.Remove(tIEPNHAN);
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
