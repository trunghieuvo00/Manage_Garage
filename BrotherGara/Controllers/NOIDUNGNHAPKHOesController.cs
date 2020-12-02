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
    public class NOIDUNGNHAPKHOesController : Controller
    {
        private BrothersGarageEntities db = new BrothersGarageEntities();

        // GET: NOIDUNGNHAPKHOes
        public ActionResult Index(string id)
        {
            var nOIDUNGNHAPKHOes = db.NOIDUNGNHAPKHOes.Include(n => n.PHIEUNHAPKHO).Include(n => n.VATTU).Include(n => n.THANGNAM).Where(c => c.MaPNK == id);
            //var nOIDUNGNHAPKHOes = db.NOIDUNGNHAPKHOes.Select(x => x.MaPNK == mapnk)
            //TempData["MaPNK"] = mapnk;
            ViewBag.MaPNK = id;
            ViewBag.MaTN = db.THANGNAMs.Select(x => x.MaTN);
            return View(nOIDUNGNHAPKHOes.ToList());
        }

        // GET: NOIDUNGNHAPKHOes/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NOIDUNGNHAPKHO nOIDUNGNHAPKHO = db.NOIDUNGNHAPKHOes.Find(id);
            if (nOIDUNGNHAPKHO == null)
            {
                return HttpNotFound();
            }
            return View(nOIDUNGNHAPKHO);
        }

        // GET: NOIDUNGNHAPKHOes/Create
        public ActionResult Create(string id)
        {
            ViewBag.MaVatTu = new SelectList(db.VATTUs, "MaVatTu", "TenVatTu");
            ViewBag.MaTN = new SelectList(db.THANGNAMs, "MaTN", "MaTN");
            NOIDUNGNHAPKHO model = new NOIDUNGNHAPKHO();
            model.MaPNK = id;
            ViewBag.MaPNK = id;
            return View(model);
        }

        // POST: NOIDUNGNHAPKHOes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MaNDNK,MaPNK,MaTN,MaVatTu,DonGia,SoLuong,ThanhTien")] NOIDUNGNHAPKHO nOIDUNGNHAPKHO)
        {
            if (ModelState.IsValid)
            {
                db.NOIDUNGNHAPKHOes.Add(nOIDUNGNHAPKHO);
                db.SaveChanges();
                return RedirectToAction("Index", new { @id = nOIDUNGNHAPKHO.MaPNK });
                //return Redirect($"/NOIDUNGNHAPKHOes/Index?mapnk={nOIDUNGNHAPKHO.MaPNK}");
            }

            ViewBag.MaPNK = new SelectList(db.PHIEUNHAPKHOes, "MaPNK", "MaPNK", nOIDUNGNHAPKHO.MaPNK);
            ViewBag.MaVatTu = new SelectList(db.VATTUs, "MaVatTu", "TenVatTu", nOIDUNGNHAPKHO.MaVatTu);
            ViewBag.MaTN = new SelectList(db.THANGNAMs, "MaTN", "MaTN", nOIDUNGNHAPKHO.MaTN);
            return View(nOIDUNGNHAPKHO);
        }

        // GET: NOIDUNGNHAPKHOes/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NOIDUNGNHAPKHO nOIDUNGNHAPKHO = db.NOIDUNGNHAPKHOes.Find(id);
            if (nOIDUNGNHAPKHO == null)
            {
                return HttpNotFound();
            }
            ViewBag.MaPNK = new SelectList(db.PHIEUNHAPKHOes, "MaPNK", "MaPNK", nOIDUNGNHAPKHO.MaPNK);
            ViewBag.MaVatTu = new SelectList(db.VATTUs, "MaVatTu", "TenVatTu", nOIDUNGNHAPKHO.MaVatTu);
            ViewBag.MaTN = new SelectList(db.THANGNAMs, "MaTN", "MaTN", nOIDUNGNHAPKHO.MaTN);
            return View(nOIDUNGNHAPKHO);
        }

        // POST: NOIDUNGNHAPKHOes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MaNDNK,MaPNK,MaTN,MaVatTu,DonGia,SoLuong,ThanhTien")] NOIDUNGNHAPKHO nOIDUNGNHAPKHO)
        {
            if (ModelState.IsValid)
            {
                db.Entry(nOIDUNGNHAPKHO).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.MaPNK = new SelectList(db.PHIEUNHAPKHOes, "MaPNK", "MaPNK", nOIDUNGNHAPKHO.MaPNK);
            ViewBag.MaVatTu = new SelectList(db.VATTUs, "MaVatTu", "TenVatTu", nOIDUNGNHAPKHO.MaVatTu);
            ViewBag.MaTN = new SelectList(db.THANGNAMs, "MaTN", "MaTN", nOIDUNGNHAPKHO.MaTN);
            return View(nOIDUNGNHAPKHO);
        }

        // GET: NOIDUNGNHAPKHOes/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NOIDUNGNHAPKHO nOIDUNGNHAPKHO = db.NOIDUNGNHAPKHOes.Find(id);
            if (nOIDUNGNHAPKHO == null)
            {
                return HttpNotFound();
            }
            return View(nOIDUNGNHAPKHO);
        }

        // POST: NOIDUNGNHAPKHOes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            NOIDUNGNHAPKHO nOIDUNGNHAPKHO = db.NOIDUNGNHAPKHOes.Find(id);
            db.NOIDUNGNHAPKHOes.Remove(nOIDUNGNHAPKHO);
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
