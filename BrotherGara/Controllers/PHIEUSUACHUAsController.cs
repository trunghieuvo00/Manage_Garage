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
    public class PHIEUSUACHUAsController : Controller
    {
        private BrothersGarageEntities db = new BrothersGarageEntities();

        // GET: PHIEUSUACHUAs
        public ActionResult Index()
        {
            var pHIEUSUACHUAs = db.PHIEUSUACHUAs;
            return View(pHIEUSUACHUAs.ToList());
        }

        // GET: PHIEUSUACHUAs/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PHIEUSUACHUA pHIEUSUACHUA = db.PHIEUSUACHUAs.Find(id);
            if (pHIEUSUACHUA == null)
            {
                return HttpNotFound();
            }
            return View(pHIEUSUACHUA);
        }

        private string CreateIdAuto()
        {
            int id_num = 1;
            if (db.PHIEUSUACHUAs.Count() != 0)
            {
                var phieu_last = db.PHIEUSUACHUAs.OrderByDescending(p => p.MaPSC).FirstOrDefault();
                id_num = Int32.Parse((phieu_last.MaPSC).Substring(3)) + 1;
            }
            string id = id_num.ToString();
            while (id.Length < 5)
                id = "0" + id;
            return "PSC" + id;
        }

        // GET: PHIEUSUACHUAs/Create
        public ActionResult Create()
        {
            ViewBag.MaTiepNhan = new SelectList(db.TIEPNHANs, "MaTiepNhan", "MaTiepNhan");

            PHIEUSUACHUA model = new PHIEUSUACHUA();
            model.MaPSC = CreateIdAuto();
            return View(model);
        }
        public ActionResult CreateWithID(string id)
        {
            ViewBag.MaTiepNhan = new SelectList(db.TIEPNHANs.Where(t => t.MaTiepNhan == id), "MaTiepNhan", "MaTiepNhan", db.TIEPNHANs.Where(t => t.MaTiepNhan == id));

            PHIEUSUACHUA model = new PHIEUSUACHUA();
            model.MaPSC = CreateIdAuto();
            return View(model);
        }

        // POST: PHIEUSUACHUAs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MaPSC,MaTiepNhan,NgaySuaChua")] PHIEUSUACHUA pHIEUSUACHUA)
        {
            if (ModelState.IsValid)
            {
                pHIEUSUACHUA.TongTien = 0;
                db.PHIEUSUACHUAs.Add(pHIEUSUACHUA);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.MaTiepNhan = new SelectList(db.TIEPNHANs, "MaTiepNhan", "BienSo", pHIEUSUACHUA.MaTiepNhan);
            return View(pHIEUSUACHUA);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateWithID([Bind(Include = "MaPSC,MaTiepNhan,NgaySuaChua")] PHIEUSUACHUA pHIEUSUACHUA)
        {
            if (ModelState.IsValid)
            {
                pHIEUSUACHUA.TongTien = 0;
                db.PHIEUSUACHUAs.Add(pHIEUSUACHUA);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.MaTiepNhan = new SelectList(db.TIEPNHANs, "MaTiepNhan", "BienSo", pHIEUSUACHUA.MaTiepNhan);
            return View(pHIEUSUACHUA);
        }
        // GET: PHIEUSUACHUAs/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PHIEUSUACHUA pHIEUSUACHUA = db.PHIEUSUACHUAs.Find(id);
            if (pHIEUSUACHUA == null)
            {
                return HttpNotFound();
            }
            ViewBag.MaTiepNhan = new SelectList(db.TIEPNHANs, "MaTiepNhan", "BienSo", pHIEUSUACHUA.MaTiepNhan);
            return View(pHIEUSUACHUA);
        }

        // POST: PHIEUSUACHUAs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MaPSC,MaTiepNhan,NgaySuaChua,TongTien")] PHIEUSUACHUA pHIEUSUACHUA)
        {
            if (ModelState.IsValid)
            {
                db.Entry(pHIEUSUACHUA).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.MaTiepNhan = new SelectList(db.TIEPNHANs, "MaTiepNhan", "BienSo", pHIEUSUACHUA.MaTiepNhan);
            return View(pHIEUSUACHUA);
        }

        // GET: PHIEUSUACHUAs/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PHIEUSUACHUA pHIEUSUACHUA = db.PHIEUSUACHUAs.Find(id);
            if (pHIEUSUACHUA == null)
            {
                return HttpNotFound();
            }
            return View(pHIEUSUACHUA);
        }

        // POST: PHIEUSUACHUAs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            PHIEUSUACHUA pHIEUSUACHUA = db.PHIEUSUACHUAs.Find(id);
            db.PHIEUSUACHUAs.Remove(pHIEUSUACHUA);
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