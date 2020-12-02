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
    public class CT_TIENCONGController : Controller
    {
        private BrothersGarageEntities db = new BrothersGarageEntities();

        // GET: CT_TIENCONG
        public ActionResult Index()
        {
            var cT_TIENCONG = db.CT_TIENCONG;
            return View(cT_TIENCONG.ToList());
        }

        // GET: CT_TIENCONG/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CT_TIENCONG cT_TIENCONG = db.CT_TIENCONG.Find(id);
            if (cT_TIENCONG == null)
            {
                return HttpNotFound();
            }
            return View(cT_TIENCONG);
        }

        // GET: CT_TIENCONG/Create
        public ActionResult Create(string id)
        {
            ViewBag.MaPSC = new SelectList(db.PHIEUSUACHUAs, "MaPSC", "MaTiepNhan");
            ViewBag.MaTienCong = new SelectList(db.TIENCONGs, "MaTienCong", "TenTienCong");
            CT_TIENCONG model = new CT_TIENCONG();
            model.MaPSC = id;
            return View(model);
        }

        // POST: CT_TIENCONG/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MaCTTC,MaPSC,MaTienCong,TienCong")] CT_TIENCONG cT_TIENCONG)
        {
            if (ModelState.IsValid)
            {
                db.CT_TIENCONG.Add(cT_TIENCONG);
                db.SaveChanges();
                return RedirectToAction("Index", new { @id = cT_TIENCONG.MaPSC });
            }

            ViewBag.MaPSC = new SelectList(db.PHIEUSUACHUAs, "MaPSC", "MaTiepNhan", cT_TIENCONG.MaPSC);
            ViewBag.MaTienCong = new SelectList(db.TIENCONGs, "MaTienCong", "TenTienCong", cT_TIENCONG.MaTienCong);
            return View(cT_TIENCONG);
        }
        public ActionResult CreateWithId(string id)
        {
            ViewBag.MaPSC = new SelectList(db.PHIEUSUACHUAs.Where(t => t.MaPSC == id), "MaPSC", "MaPSC", db.PHIEUSUACHUAs.Where(t => t.MaPSC == id));
            ViewBag.MaTienCong = new SelectList(db.TIENCONGs, "MaTienCong", "TenTienCong");
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateWithId([Bind(Include = "MaCTTC,MaPSC,MaTienCong,TienCong")] CT_TIENCONG cT_TIENCONG)
        {
            if (ModelState.IsValid)
            {
                db.CT_TIENCONG.Add(cT_TIENCONG);
                db.SaveChanges();
                return RedirectToAction("Index", new { @id = cT_TIENCONG.MaPSC });
            }

            ViewBag.MaPSC = new SelectList(db.PHIEUSUACHUAs, "MaPSC", "MaTiepNhan", cT_TIENCONG.MaPSC);
            ViewBag.MaTienCong = new SelectList(db.TIENCONGs, "MaTienCong", "TenTienCong", cT_TIENCONG.MaTienCong);
            return View(cT_TIENCONG);
        }

        // GET: CT_TIENCONG/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CT_TIENCONG cT_TIENCONG = db.CT_TIENCONG.Find(id);
            if (cT_TIENCONG == null)
            {
                return HttpNotFound();
            }
            ViewBag.MaPSC = new SelectList(db.PHIEUSUACHUAs, "MaPSC", "MaTiepNhan", cT_TIENCONG.MaPSC);
            ViewBag.MaTienCong = new SelectList(db.TIENCONGs, "MaTienCong", "TenTienCong", cT_TIENCONG.MaTienCong);
            return View(cT_TIENCONG);
        }

        // POST: CT_TIENCONG/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MaCTTC,MaPSC,MaTienCong,TienCong")] CT_TIENCONG cT_TIENCONG)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cT_TIENCONG).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.MaPSC = new SelectList(db.PHIEUSUACHUAs, "MaPSC", "MaTiepNhan", cT_TIENCONG.MaPSC);
            ViewBag.MaTienCong = new SelectList(db.TIENCONGs, "MaTienCong", "TenTienCong", cT_TIENCONG.MaTienCong);
            return View(cT_TIENCONG);
        }

        // GET: CT_TIENCONG/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CT_TIENCONG cT_TIENCONG = db.CT_TIENCONG.Find(id);
            if (cT_TIENCONG == null)
            {
                return HttpNotFound();
            }
            return View(cT_TIENCONG);
        }

        // POST: CT_TIENCONG/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            CT_TIENCONG cT_TIENCONG = db.CT_TIENCONG.Find(id);
            db.CT_TIENCONG.Remove(cT_TIENCONG);
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
