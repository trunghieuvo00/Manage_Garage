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

        private string CreateIdAuto()
        {
            int id_num = 1;
            if (db.PHIEUTHUTIENs.Count() != 0)
            {
                var phieu_last = db.PHIEUTHUTIENs.OrderByDescending(p => p.MaPTT).FirstOrDefault();
                id_num = Int32.Parse((phieu_last.MaPTT).Substring(3)) + 1;
            }
            string id = id_num.ToString();
            while (id.Length < 5)
                id = "0" + id;
            return "PTT" + id;
        }

        // GET: PHIEUTHUTIENs/Create
        public ActionResult Create()
        {
            ViewBag.MaPSC = new SelectList(db.PHIEUSUACHUAs, "MaPSC", "MaPSC");

            PHIEUTHUTIEN model = new PHIEUTHUTIEN();
            model.MaPTT = CreateIdAuto();
            return View(model);
        }

        // POST: PHIEUTHUTIENs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MaPTT,MaPSC,NgayThuTien,SoTienThu")] PHIEUTHUTIEN pHIEUTHUTIEN)
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
        public ActionResult Edit([Bind(Include = "MaPTT,MaPSC,NgayThuTien,SoTienThu")] PHIEUTHUTIEN pHIEUTHUTIEN)
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
