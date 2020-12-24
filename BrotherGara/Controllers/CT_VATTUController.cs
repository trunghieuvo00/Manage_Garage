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
    public class CT_VATTUController : Controller
    {
        private BrothersGarageEntities db = new BrothersGarageEntities();

        // GET: CT_VATTU
        public ActionResult Index(string id)
        {
            var cT_VATTU = db.CT_VATTU.Where(x => x.MaPSC == id);
            ViewBag.MaPSC = id;
            return View(cT_VATTU.ToList());
        }

        // GET: CT_VATTU/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CT_VATTU cT_VATTU = db.CT_VATTU.Find(id);
            if (cT_VATTU == null)
            {
                return HttpNotFound();
            }
            return View(cT_VATTU);
        }
        private string CreateIdAuto()
        {
            int id_num = 1;
            if (db.CT_VATTU.Count() != 0)
            {
                var phieu_last = db.CT_VATTU.OrderByDescending(p => p.MaCTVT).FirstOrDefault();
                id_num = Int32.Parse((phieu_last.MaCTVT).Substring(4)) + 1;
            }
            string id = id_num.ToString();
            while (id.Length < 4)
                id = "0" + id;
            return "CTVT" + id;
        }
        // GET: CT_VATTU/Create
        public ActionResult Create(string id)
        {
            ViewBag.MaPSC = id;
            ViewBag.MaVatTu = new SelectList(db.VATTUs, "MaVatTu", "TenVatTu");
            CT_VATTU model = new CT_VATTU();
            model.MaCTVT = CreateIdAuto();
            model.MaPSC = id;
            return View(model);
        }
        public ActionResult CreateWithId(string id)
        {
            ViewBag.MaPSC = new SelectList(db.PHIEUSUACHUAs.Where(t => t.MaPSC == id), "MaPSC", "MaPSC", db.PHIEUSUACHUAs.Where(t => t.MaPSC == id));
            ViewBag.MaVatTu = new SelectList(db.VATTUs, "MaVatTu", "TenVatTu");

            CT_VATTU model = new CT_VATTU();
            model.MaCTVT = CreateIdAuto();
            return View(model);
        }

        // POST: CT_VATTU/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateWithId([Bind(Include = "MaCTVT,MaPSC,MaVatTu,DonGia,SoLuong,ThanhTien")] CT_VATTU cT_VATTU)
        {
            if (ModelState.IsValid)
            {
                db.CT_VATTU.Add(cT_VATTU);

                db.SaveChanges();
                return RedirectToAction("Index", new { @id = cT_VATTU.MaPSC });
            }

            ViewBag.MaPSC = new SelectList(db.PHIEUSUACHUAs, "MaPSC", "MaTiepNhan", cT_VATTU.MaPSC);
            ViewBag.MaVatTu = new SelectList(db.VATTUs, "MaVatTu", "TenVatTu", cT_VATTU.MaVatTu);
            return View(cT_VATTU);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MaCTVT,MaPSC,MaVatTu,DonGia,SoLuong,ThanhTien")] CT_VATTU cT_VATTU)
        {
            if (ModelState.IsValid)
            {
                db.CT_VATTU.Add(cT_VATTU);

                db.SaveChanges();
                return RedirectToAction("Index", new { @id = cT_VATTU.MaPSC });
            }

            ViewBag.MaPSC = new SelectList(db.PHIEUSUACHUAs, "MaPSC", "MaTiepNhan", cT_VATTU.MaPSC);
            ViewBag.MaVatTu = new SelectList(db.VATTUs, "MaVatTu", "TenVatTu", cT_VATTU.MaVatTu);
            return View(cT_VATTU);
        }

        // GET: CT_VATTU/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CT_VATTU cT_VATTU = db.CT_VATTU.Find(id);
            if (cT_VATTU == null)
            {
                return HttpNotFound();
            }
            ViewBag.MaPSC = new SelectList(db.PHIEUSUACHUAs, "MaPSC", "MaTiepNhan", cT_VATTU.MaPSC);
            ViewBag.MaVatTu = new SelectList(db.VATTUs, "MaVatTu", "TenVatTu", cT_VATTU.MaVatTu);
            return View(cT_VATTU);
        }

        // POST: CT_VATTU/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MaCTVT,MaPSC,MaVatTu,DonGia,SoLuong,ThanhTien")] CT_VATTU cT_VATTU)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cT_VATTU).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.MaPSC = new SelectList(db.PHIEUSUACHUAs, "MaPSC", "MaTiepNhan", cT_VATTU.MaPSC);
            ViewBag.MaVatTu = new SelectList(db.VATTUs, "MaVatTu", "TenVatTu", cT_VATTU.MaVatTu);
            return View(cT_VATTU);
        }

        // GET: CT_VATTU/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CT_VATTU cT_VATTU = db.CT_VATTU.Find(id);
            if (cT_VATTU == null)
            {
                return HttpNotFound();
            }
            return View(cT_VATTU);
        }

        // POST: CT_VATTU/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            CT_VATTU cT_VATTU = db.CT_VATTU.Find(id);
            db.CT_VATTU.Remove(cT_VATTU);
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